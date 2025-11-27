using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class ProdutoDAL
    {
        private readonly string connectionString;

        public ProdutoDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<ProdutoInfo>> ListarAsync()
        {
            var produtosList = new List<ProdutoInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        SELECT p.IDProduto, p.IDProdutoInterno, p.IDProdutoFabricante, p.Descricao, 
                               f.Nome_RazaoSocial AS Fornecedor, m.Descricao AS Marca, mo.Descricao AS Modelo, 
                               u.Descricao AS Unidade, p.PrecoCompra, p.PrecoVenda, p.EstoqueAtual, 
                               p.EstoqueMinimo, p.DataUltimaCompra, p.Garantia, p.Imagem
                        FROM DBProdutos p
                        JOIN DBFornecedores f ON p.IDFornecedor = f.IDFornecedor
                        JOIN DBMarcas m ON p.IDMarca = m.IDMarca
                        JOIN DBModelos mo ON p.IDModelo = mo.IDModelo
                        JOIN DBUnidades u ON p.IDUnidade = u.IDUnidade";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var produto = new ProdutoInfo
                            {
                                IDProduto = Convert.ToInt32(reader["IDProduto"]),
                                IDProdutoInterno = reader["IDProdutoInterno"].ToString(),
                                IDProdutoFabricante = reader["IDProdutoFabricante"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                                Fornecedor = reader["Fornecedor"].ToString(),
                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                Unidade = reader["Unidade"].ToString(),
                                PrecoCompra = Convert.ToDecimal(reader["PrecoCompra"]),
                                PrecoVenda = Convert.ToDecimal(reader["PrecoVenda"]),
                                EstoqueAtual = Convert.ToDecimal(reader["EstoqueAtual"]),
                                EstoqueMinimo = Convert.ToDecimal(reader["EstoqueMinimo"]),
                                DataUltimaCompra = Convert.ToDateTime(reader["DataUltimaCompra"]),
                                Garantia = reader["Garantia"].ToString(),
                                Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                            };
                            produtosList.Add(produto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produtos: " + ex.Message, ex);
            }

            return produtosList;
        }

        public async Task<List<ProdutoInfo>> ListarPorMarcaAsync(int idMarca)
        {
            var produtosList = new List<ProdutoInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT IDProduto, Descricao, Imagem FROM DBProdutos WHERE IDMarca = @IDMarca";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", idMarca);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var produto = new ProdutoInfo
                                {
                                    IDProduto = Convert.ToInt32(reader["IDProduto"]),
                                    Descricao = reader["Descricao"].ToString(),
                                    Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                                };
                                produtosList.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar produtos por marca: " + ex.Message, ex);
            }

            return produtosList;
        }

        public async Task<ProdutoInfo> GetProdutoAsync(int idProduto)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM DBProdutos WHERE IDProduto = @IDProduto";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDProduto", idProduto);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ProdutoInfo
                                {
                                    IDProduto = Convert.ToInt32(reader["IDProduto"]),
                                    IDProdutoInterno = reader["IDProdutoInterno"].ToString(),
                                    IDProdutoFabricante = reader["IDProdutoFabricante"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]),
                                    IDMarca = Convert.ToInt32(reader["IDMarca"]),
                                    IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                    IDUnidade = Convert.ToInt32(reader["IDUnidade"]),
                                    PrecoCompra = Convert.ToDecimal(reader["PrecoCompra"]),
                                    PrecoVenda = Convert.ToDecimal(reader["PrecoVenda"]),
                                    EstoqueAtual = Convert.ToDecimal(reader["EstoqueAtual"]),
                                    EstoqueMinimo = Convert.ToDecimal(reader["EstoqueMinimo"]),
                                    DataUltimaCompra = Convert.ToDateTime(reader["DataUltimaCompra"]),
                                    Garantia = reader["Garantia"].ToString(),
                                    Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar produto: " + ex.Message, ex);
            }

            return null;
        }

        public async Task AtualizarProdutoAsync(ProdutoInfo produto)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"UPDATE DBProdutos 
                                     SET IDProdutoInterno = @IDProdutoInterno, 
                                         IDProdutoFabricante = @IDProdutoFabricante, 
                                         Descricao = @Descricao, 
                                         IDFornecedor = @IDFornecedor, 
                                         IDMarca = @IDMarca, 
                                         IDModelo = @IDModelo, 
                                         IDUnidade = @IDUnidade, 
                                         PrecoCompra = @PrecoCompra, 
                                         PrecoVenda = @PrecoVenda, 
                                         EstoqueAtual = @EstoqueAtual, 
                                         EstoqueMinimo = @EstoqueMinimo, 
                                         Garantia = @Garantia, 
                                         Imagem = @Imagem 
                                     WHERE IDProduto = @IDProduto";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDProdutoInterno", produto.IDProdutoInterno);
                        cmd.Parameters.AddWithValue("@IDProdutoFabricante", produto.IDProdutoFabricante);
                        cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        cmd.Parameters.AddWithValue("@IDFornecedor", produto.IDFornecedor);
                        cmd.Parameters.AddWithValue("@IDMarca", produto.IDMarca);
                        cmd.Parameters.AddWithValue("@IDModelo", produto.IDModelo);
                        cmd.Parameters.AddWithValue("@IDUnidade", produto.IDUnidade);
                        cmd.Parameters.AddWithValue("@PrecoCompra", produto.PrecoCompra);
                        cmd.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                        cmd.Parameters.AddWithValue("@EstoqueAtual", produto.EstoqueAtual);
                        cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                        cmd.Parameters.AddWithValue("@Garantia", produto.Garantia);
                        cmd.Parameters.AddWithValue("@Imagem", produto.Imagem ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDProduto", produto.IDProduto);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto: " + ex.Message, ex);
            }
        }

        public async Task InserirProdutoAsync(ProdutoInfo produto)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"INSERT INTO DBProdutos 
                                    (IDProdutoInterno, IDProdutoFabricante, Descricao, IDFornecedor, IDMarca, IDModelo, 
                                     IDUnidade, PrecoCompra, PrecoVenda, EstoqueAtual, EstoqueMinimo, DataUltimaCompra, Garantia, Imagem) 
                                    VALUES (@IDProdutoInterno, @IDProdutoFabricante, @Descricao, @IDFornecedor, @IDMarca, @IDModelo, 
                                            @IDUnidade, @PrecoCompra, @PrecoVenda, @EstoqueAtual, @EstoqueMinimo, @DataUltimaCompra, @Garantia, @Imagem)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDProdutoInterno", produto.IDProdutoInterno);
                        cmd.Parameters.AddWithValue("@IDProdutoFabricante", produto.IDProdutoFabricante);
                        cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        cmd.Parameters.AddWithValue("@IDFornecedor", produto.IDFornecedor);
                        cmd.Parameters.AddWithValue("@IDMarca", produto.IDMarca);
                        cmd.Parameters.AddWithValue("@IDModelo", produto.IDModelo);
                        cmd.Parameters.AddWithValue("@IDUnidade", produto.IDUnidade);
                        cmd.Parameters.AddWithValue("@PrecoCompra", produto.PrecoCompra);
                        cmd.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                        cmd.Parameters.AddWithValue("@EstoqueAtual", produto.EstoqueAtual);
                        cmd.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                        cmd.Parameters.AddWithValue("@DataUltimaCompra", produto.DataUltimaCompra);
                        cmd.Parameters.AddWithValue("@Garantia", produto.Garantia);
                        cmd.Parameters.AddWithValue("@Imagem", produto.Imagem ?? (object)DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto: " + ex.Message, ex);
            }
        }

        public async Task ExcluirProdutoAsync(int idProduto)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM DBProdutos WHERE IDProduto = @IDProduto";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDProduto", idProduto);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir produto: " + ex.Message, ex);
            }
        }
    }
}