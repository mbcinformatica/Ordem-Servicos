using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarServicos
    {
        private readonly ServicoDAL _servicoDAL;
        private readonly CategoriaServicoDAL _categoriaDAL;

        public ImportarServicos()
        {
            _servicoDAL = new ServicoDAL();
            _categoriaDAL = new CategoriaServicoDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o arquivo CSV de Serviços";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("IDCodigoBase;CategoriaServico;Descricao;ValorServico", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura inválida! O cabeçalho deve conter 'IDCodigoBase;CategoriaServico;Descricao;ValorServico'.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, realizando importação de serviços...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var partes = linha.Split(';');
                            if (partes.Length < 4) continue;

                            string codigoBase = partes[0].Trim().ToUpperInvariant();
                            string categoriaNome = partes[1].Trim().ToUpperInvariant();
                            string descricao = partes[2].Trim().ToUpperInvariant();
                            string valorStr = partes[3].Trim().Replace(",", ".");

                            if (!decimal.TryParse(valorStr, out decimal valorServico))
                                continue; // ignora se valor inválido

                            try
                            {
                                // Busca categoria no banco
                                var categoria = await _categoriaDAL.GetCategoriaByNomeAsync(categoriaNome);
                                if (categoria == null)
                                {
                                    Console.WriteLine($"Categoria não encontrada: {categoriaNome}. Serviço ignorado.");
                                    continue;
                                }

                                var servico = new ServicoInfo
                                {
                                    IDCodigoBase = codigoBase,
                                    IDCategoriaServico = categoria.IDCategoriaServico,
                                    Descricao = descricao,
                                    ValorServico = valorServico
                                };

                                _servicoDAL.InserirServico(servico);
                                totalImportados++;

                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado ignorado: {codigoBase} - {descricao}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao inserir serviço: " + ex.Message,
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
