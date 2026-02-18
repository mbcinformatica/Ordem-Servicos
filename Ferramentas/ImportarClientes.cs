using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdemServicos.DAL;
using OrdemServicos.Model;

namespace OrdemServicos.Ferramentas
{
    public class ImportarClientes
    {
        private readonly ClienteDAL _clienteDAL;

        public ImportarClientes()
        {
            _clienteDAL = new ClienteDAL();
        }

        public async Task ExecutarImportacaoAsync(ProgressBarCustom.ProgressBarCustom progressBar)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                dialog.Title = "Selecione o arquivo CSV de Clientes";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoCSV = dialog.FileName;
                    int totalLinhas = File.ReadAllLines(caminhoCSV).Length - 1;

                    using (var reader = new StreamReader(caminhoCSV))
                    {
                        // Valida cabeçalho
                        var cabecalho = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(cabecalho) ||
                            !cabecalho.Trim().Equals("TipoPessoa;Cpf_Cnpj;Nome_RazaoSocial;Endereco;Numero;Bairro;Municipio;UF;Cep;Contato;Fone_1;Fone_2;Email;DataCadastro", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Estrutura inválida! O cabeçalho deve conter todas as colunas de Clientes.",
                                            "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Configura barra de progresso
                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalLinhas;
                        progressBar.Value = 0;
                        progressBar.DisplayText = "Aguarde, realizando importação de clientes...";
                        progressBar.Visible = true;
                        progressBar.AutoCenter = true;

                        int totalImportados = 0;
                        while (!reader.EndOfStream)
                        {
                            var linha = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            var partes = linha.Split(';');
                            if (partes.Length < 14) continue;

                            try
                            {
                                var cliente = new ClienteInfo
                                {
                                    TipoPessoa = partes[0].Trim().ToUpperInvariant(),
                                    Cpf_Cnpj = partes[1].Trim(),
                                    Nome_RazaoSocial = partes[2].Trim().ToUpperInvariant(),
                                    Endereco = partes[3].Trim(),
                                    Numero = partes[4].Trim(),
                                    Bairro = partes[5].Trim(),
                                    Municipio = partes[6].Trim(),
                                    UF = partes[7].Trim().ToUpperInvariant(),
                                    Cep = partes[8].Trim(),
                                    Contato = partes[9].Trim(),
                                    Fone_1 = partes[10].Trim(),
                                    Fone_2 = partes[11].Trim(),
                                    Email = partes[12].Trim(),
                                    DataCadastro = DateTime.TryParse(partes[13].Trim(), out DateTime data) ? data : DateTime.Now
                                };

                                await _clienteDAL.InserirClienteAsync(cliente);
                                totalImportados++;

                                progressBar.Value = totalImportados;
                                progressBar.Refresh();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("Duplicate"))
                                {
                                    Console.WriteLine($"Duplicado ignorado: {partes[1]} - {partes[2]}");
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao inserir cliente: " + ex.Message,
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
