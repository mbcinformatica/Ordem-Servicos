using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarCategoriasServicos
    {
        private readonly CategoriaServicoDAL _categoriaDAL;

        public ImportarCategoriasServicos()
        {
            _categoriaDAL = new CategoriaServicoDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o arquivo CSV de Categorias de Serviços";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("Categoria de Serviços", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura inválida! O cabeçalho deve conter 'Categoria de Serviços'.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, realizando importação de categorias...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var categoria = new CategoriaServicoInfo
                            {
                                // Converte para maiúsculo antes de salvar
                                Descricao = linha.Trim().ToUpperInvariant()
                            };

                            try
                            {
                                _categoriaDAL.InserirCategoriaServico(categoria);
                                totalImportados++;

                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado ignorado: {categoria.Descricao}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao inserir categoria: " + ex.Message,
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
