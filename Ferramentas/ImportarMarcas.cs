using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarMarcas
    {
        private readonly MarcaDAL _marcaDAL;

        public ImportarMarcas()
        {
            _marcaDAL = new MarcaDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o Arquivo CSV de Marcas";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;

                    // Conta linhas (menos cabeçalho)
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("Marcas", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura Inválida! O Cabeçalho deve Conter 'Marcas'.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, Realizando Importação de Marcas...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var marca = new MarcaInfo
                            {
                                // Converte para maiúsculo
                                Descricao = linha.Trim().ToUpper()
                            };

                            try
                            {
                                await _marcaDAL.InserirMarcaAsync(marca);
                                totalImportados++;

                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado Ignorado: {marca.Descricao}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao Inserir Marca: " + ex.Message,
                                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        progressBar.Visible = false;
                        progressBar.Refresh();

                        MessageBox.Show($"Importação Concluída! {totalImportados} Registros Inseridos.",
                                        "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
