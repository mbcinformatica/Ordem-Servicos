using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarModelos
    {
        private readonly ModeloDAL _modeloDAL;
        private readonly MarcaDAL _marcaDAL;

        public ImportarModelos()
        {
            _modeloDAL = new ModeloDAL();
            _marcaDAL = new MarcaDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o arquivo CSV de Modelos";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("Marca;Modelo", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura inválida! O cabeçalho deve conter 'Marca;Modelo'.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, realizando importação de modelos...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var partes = linha.Split(';');
                            if (partes.Length < 2) continue;

                            string marcaNome = partes[0].Trim().ToUpper();
                            string modeloNome = partes[1].Trim().ToUpper();

                            try
                            {
                                // Busca marca no banco
                                var marca = await _marcaDAL.GetMarcaByNomeAsync(marcaNome);
                                if (marca == null)
                                {
                                    Console.WriteLine($"Marca não encontrada: {marcaNome}. Modelo ignorado.");
                                    continue;
                                }

                                var modelo = new ModeloInfo
                                {
                                    IDMarca = marca.IDMarca,
                                    Descricao = modeloNome
                                };

                                await _modeloDAL.InserirModeloAsync(modelo);
                                totalImportados++;

                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado ignorado: {marcaNome} - {modeloNome}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao inserir modelo: " + ex.Message,
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
