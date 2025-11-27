using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class LancamentoServicoDAL
    {
        private readonly string connectionString;

        public LancamentoServicoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<LancamentoServicoInfo>> ListarAsync()
        {
            var lancamentosList = new List<LancamentoServicoInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        SELECT ls.IDOrdenServico, ls.DataEmissao, ls.DataConclusao, 
                               c.Nome_RazaoSocial AS Cliente, 
                               m.Descricao AS Marca, 
                               p.Descricao AS Produto, 
                               ls.NumeroSerie, ls.DescricaoDefeito,
                               ls.ValorTotalServico, ls.ValorTotalMaterial, ls.Imagem 
                        FROM DBLancamentoServicos ls
                        JOIN DBClientes c ON ls.IDCliente = c.IDCliente
                        JOIN DBMarcas m ON ls.IDMarca = m.IDMarca
                        JOIN DBProdutos p ON ls.IDProduto = p.IDProduto";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var lancamento = new LancamentoServicoInfo
                            {
                                IDOrdenServico = Convert.ToInt32(reader["IDOrdenServico"]),
                                DataEmissao = reader["DataEmissao"] != DBNull.Value ? Convert.ToDateTime(reader["DataEmissao"]) : DateTime.MinValue,
                                DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : DateTime.MinValue,
                                Cliente = reader["Cliente"].ToString(),
                                Marca = reader["Marca"].ToString(),
                                Produto = reader["Produto"].ToString(),
                                NumeroSerie = reader["NumeroSerie"].ToString(),
                                DescricaoDefeito = reader["DescricaoDefeito"].ToString(),
                                ValorTotalServico = Convert.ToDecimal(reader["ValorTotalServico"]),
                                ValorTotalMaterial = Convert.ToDecimal(reader["ValorTotalMaterial"]),
                                Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                            };
                            lancamentosList.Add(lancamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar lançamentos de serviço: " + ex.Message, ex);
            }

            return lancamentosList;
        }

        public async Task<LancamentoServicoInfo> GetLancamentoServicoAsync(int idOrdenServico)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM DBLancamentoServicos WHERE IDOrdenServico = @IDOrdenServico";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new LancamentoServicoInfo
                                {
                                    IDOrdenServico = Convert.ToInt32(reader["IDOrdenServico"]),
                                    DataEmissao = reader["DataEmissao"] != DBNull.Value ? Convert.ToDateTime(reader["DataEmissao"]) : DateTime.MinValue,
                                    DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : DateTime.MinValue,
                                    IDCliente = Convert.ToInt32(reader["IDCliente"]),
                                    IDMarca = Convert.ToInt32(reader["IDMarca"]),
                                    IDProduto = Convert.ToInt32(reader["IDProduto"]),
                                    NumeroSerie = reader["NumeroSerie"].ToString(),
                                    DescricaoDefeito = reader["DescricaoDefeito"].ToString(),
                                    ValorTotalServico = Convert.ToDecimal(reader["ValorTotalServico"]),
                                    ValorTotalMaterial = Convert.ToDecimal(reader["ValorTotalMaterial"]),
                                    Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar lançamento de serviço: " + ex.Message, ex);
            }

            return null;
        }

        public async Task AtualizarLancamentoServicoAsync(LancamentoServicoInfo lancamento)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        UPDATE DBLancamentoServicos 
                        SET DataEmissao = @DataEmissao,
                            DataConclusao = @DataConclusao, 
                            IDCliente = @IDCliente, 
                            IDMarca = @IDMarca,
                            IDProduto = @IDProduto, 
                            NumeroSerie = @NumeroSerie, 
                            DescricaoDefeito = @DescricaoDefeito,
                            ValorTotalServico = @ValorTotalServico, 
                            ValorTotalMaterial = @ValorTotalMaterial,
                            Imagem = @Imagem 
                        WHERE IDOrdenServico = @IDOrdenServico";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOrdenServico", lancamento.IDOrdenServico);
                        cmd.Parameters.AddWithValue("@DataEmissao", lancamento.DataEmissao);
                        cmd.Parameters.AddWithValue("@DataConclusao", lancamento.DataConclusao);
                        cmd.Parameters.AddWithValue("@IDCliente", lancamento.IDCliente);
                        cmd.Parameters.AddWithValue("@IDMarca", lancamento.IDMarca);
                        cmd.Parameters.AddWithValue("@IDProduto", lancamento.IDProduto);
                        cmd.Parameters.AddWithValue("@NumeroSerie", lancamento.NumeroSerie);
                        cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamento.DescricaoDefeito);
                        cmd.Parameters.AddWithValue("@ValorTotalServico", lancamento.ValorTotalServico);
                        cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamento.ValorTotalMaterial);
                        cmd.Parameters.AddWithValue("@Imagem", lancamento.Imagem ?? (object)DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar lançamento de serviço: " + ex.Message, ex);
            }
        }

        public async Task InserirLancamentoServicoAsync(LancamentoServicoInfo lancamento)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        INSERT INTO DBLancamentoServicos 
                        (DataEmissao, DataConclusao, IDCliente, IDMarca, IDProduto, NumeroSerie, DescricaoDefeito, ValorTotalServico, ValorTotalMaterial, Imagem)
                        VALUES 
                        (@DataEmissao, @DataConclusao, @IDCliente, @IDMarca, @IDProduto, @NumeroSerie, @DescricaoDefeito, @ValorTotalServico, @ValorTotalMaterial, @Imagem)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DataEmissao", lancamento.DataEmissao);
                        cmd.Parameters.AddWithValue("@DataConclusao", lancamento.DataConclusao);
                        cmd.Parameters.AddWithValue("@IDCliente", lancamento.IDCliente);
                        cmd.Parameters.AddWithValue("@IDMarca", lancamento.IDMarca);
                        cmd.Parameters.AddWithValue("@IDProduto", lancamento.IDProduto);
                        cmd.Parameters.AddWithValue("@NumeroSerie", lancamento.NumeroSerie);
                        cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamento.DescricaoDefeito);
                        cmd.Parameters.AddWithValue("@ValorTotalServico", lancamento.ValorTotalServico);
                        cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamento.ValorTotalMaterial);
                        cmd.Parameters.AddWithValue("@Imagem", lancamento.Imagem ?? (object)DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir lançamento de serviço: " + ex.Message, ex);
            }
        }

        public async Task ExcluirLancamentoServicoAsync(int idOrdenServico)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM DBLancamentoServicos WHERE IDOrdenServico = @IDOrdenServico";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir lançamento de serviço: " + ex.Message, ex);
            }
        }
    }
}
