using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarUnidadesMedida
    {
        private readonly UnidadeDAL _unidadeDAL;

        public ImportarUnidadesMedida()
        {
            _unidadeDAL = new UnidadeDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o arquivo CSV de Unidades de Medidas";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;

                    // Conta o número de linhas do arquivo (menos o cabeçalho)
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("Unidade de Medidas", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura inválida! O cabeçalho deve conter 'Unidade de Medidas'.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, realizando importação de dados...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var unidade = new UnidadeInfo
                            {
                                // Converte para maiúsculo antes de salvar
                                Descricao = linha.Trim().ToUpper()
                            };

                            try
                            {
                                await _unidadeDAL.InserirUnidadeAsync(unidade);
                                totalImportados++;

                                // Atualiza barra
                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                                await Task.Delay(1000);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado ignorado: {unidade.Descricao}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao inserir unidade: " + ex.Message,
                                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        progressBar.Visible = false;
                        progressBar.Refresh();

                        MessageBox.Show($"Importação concluída! {totalImportados} registros inseridos.",
                                        "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
