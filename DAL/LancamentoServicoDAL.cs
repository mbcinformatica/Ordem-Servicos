using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class LancamentoServicoDAL
    {
        private readonly string connectionString;
        public LancamentoServicoDAL()
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

        public List<LancamentoServicoInfo> Listar()
        {
            List<LancamentoServicoInfo> LancamentoServicosList = new List<LancamentoServicoInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ls.IDOrdenServico, ls.DataEmissao, ls.DataConclusao, c.Nome_RazaoSocial AS Cliente, 
                               m.Descricao AS Marca, p.Descricao AS Produto, ls.NumeroSerie, ls.DescricaoDefeito,
                               ls.ValorTotalServico, ls.ValorTotalMaterial, ls.Imagem 
                        FROM DBLancamentoServicos ls
                        JOIN DBClientes c ON ls.IDCliente = c.IDCliente
                        JOIN DBMarcas m ON ls.IDMarca = m.IDMarca
                        JOIN DBProdutos p ON ls.IDProduto = p.IDProduto";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LancamentoServicoInfo lancamentoServico = new LancamentoServicoInfo
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
                            LancamentoServicosList.Add(lancamentoServico);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar lançamentos de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar lançamentos de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return LancamentoServicosList;
        }

        public LancamentoServicoInfo GetLancamentoServico(int idOrdenServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBLancamentoServicos WHERE IDOrdenServico = @IDOrdenServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar lançamento de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar lançamento de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public void AtualizarLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
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

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDOrdenServico", lancamentoServico.IDOrdenServico);
                    cmd.Parameters.AddWithValue("@DataEmissao", lancamentoServico.DataEmissao);
                    cmd.Parameters.AddWithValue("@DataConclusao", lancamentoServico.DataConclusao);
                    cmd.Parameters.AddWithValue("@IDCliente", lancamentoServico.IDCliente);
                    cmd.Parameters.AddWithValue("@IDMarca", lancamentoServico.IDMarca);
                    cmd.Parameters.AddWithValue("@IDProduto", lancamentoServico.IDProduto);
                    cmd.Parameters.AddWithValue("@NumeroSerie", lancamentoServico.NumeroSerie);
                    cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamentoServico.DescricaoDefeito);
                    cmd.Parameters.AddWithValue("@ValorTotalServico", lancamentoServico.ValorTotalServico);
                    cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamentoServico.ValorTotalMaterial);
                    cmd.Parameters.AddWithValue("@Imagem", lancamentoServico.Imagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar lançamento de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar lançamento de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO DBLancamentoServicos 
                (DataEmissao, DataConclusao, IDCliente, IDMarca, IDProduto, NumeroSerie, DescricaoDefeito, ValorTotalServico, ValorTotalMaterial, Imagem)
                VALUES 
                (@DataEmissao, @DataConclusao, @IDCliente, @IDMarca, @IDProduto, @NumeroSerie, @DescricaoDefeito, @ValorTotalServico, @ValorTotalMaterial, @Imagem)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DataEmissao", lancamentoServico.DataEmissao);
                        cmd.Parameters.AddWithValue("@DataConclusao", lancamentoServico.DataConclusao);
                        cmd.Parameters.AddWithValue("@IDCliente", lancamentoServico.IDCliente);
                        cmd.Parameters.AddWithValue("@IDMarca", lancamentoServico.IDMarca);
                        cmd.Parameters.AddWithValue("@IDProduto", lancamentoServico.IDProduto);
                        cmd.Parameters.AddWithValue("@NumeroSerie", lancamentoServico.NumeroSerie);
                        cmd.Parameters.AddWithValue("@DescricaoDefeito", lancamentoServico.DescricaoDefeito);
                        cmd.Parameters.AddWithValue("@ValorTotalServico", lancamentoServico.ValorTotalServico);
                        cmd.Parameters.AddWithValue("@ValorTotalMaterial", lancamentoServico.ValorTotalMaterial);
                        cmd.Parameters.AddWithValue("@Imagem", lancamentoServico.Imagem ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir lançamento de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir lançamento de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirLancamentoServico(int idOrdenServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBLancamentoServicos WHERE IDOrdenServico = @IDOrdenServico";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOrdenServico", idOrdenServico);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir lançamento de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir lançamento de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}