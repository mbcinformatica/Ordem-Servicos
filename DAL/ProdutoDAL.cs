using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class ProdutoDAL
    {
        private readonly string connectionString;
        public ProdutoDAL()
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Erro ao carregar configuração do banco: " + ex.Message,
                                "Erro de Configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<ProdutoInfo> Listar()
        {
            List<ProdutoInfo> ProdutosList = new List<ProdutoInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
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
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoInfo produto = new ProdutoInfo
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
                            ProdutosList.Add(produto);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar produtos: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar produtos: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ProdutosList;
        }

        public List<ProdutoInfo> ListarPorMarca(int idMarca)
        {
            List<ProdutoInfo> produtosList = new List<ProdutoInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IDProduto, Descricao, Imagem FROM DBProdutos WHERE IDMarca = @IDMarca";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDMarca", idMarca);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoInfo produto = new ProdutoInfo
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar produtos por marca: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar produtos por marca: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return produtosList;
        }

        public ProdutoInfo GetProduto(int idProduto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBProdutos WHERE IDProduto = @IDProduto";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDProduto", idProduto);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar produto: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar produto: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void AtualizarProduto(ProdutoInfo produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBProdutos SET IDProdutoInterno = @IDProdutoInterno, IDProdutoFabricante = @IDProdutoFabricante, Descricao = @Descricao, " +
                                   "IDFornecedor = @IDFornecedor, IDMarca = @IDMarca, IDModelo = @IDModelo, IDUnidade = @IDUnidade, PrecoCompra = @PrecoCompra, PrecoVenda = @PrecoVenda, " +
                                   "EstoqueAtual = @EstoqueAtual, EstoqueMinimo = @EstoqueMinimo, Garantia = @Garantia, Imagem = @Imagem WHERE IDProduto = @IDProduto";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar produto: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar produto: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InserirProduto(ProdutoInfo produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBProdutos (IDProdutoInterno, IDProdutoFabricante, Descricao, IDFornecedor, IDMarca, IDModelo, " +
                                   "IDUnidade, PrecoCompra, PrecoVenda, EstoqueAtual, EstoqueMinimo, DataUltimaCompra, Garantia, Imagem) " +
                                   "VALUES (@IDProdutoInterno, @IDProdutoFabricante, @Descricao, @IDFornecedor, @IDMarca, @IDModelo, @IDUnidade, @PrecoCompra, " +
                                   "@PrecoVenda, @EstoqueAtual, @EstoqueMinimo, @DataUltimaCompra, @Garantia, @Imagem)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
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

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir produto: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir produto: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirProduto(int idProduto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBProdutos WHERE IDProduto = @IDProduto";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDProduto", idProduto);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir produto: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir produto: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}