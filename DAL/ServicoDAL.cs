using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class ServicoDAL
    {
        private readonly string connectionString;
        public ServicoDAL()
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

        public List<ServicoInfo> Listar()
        {
            List<ServicoInfo> ServicosList = new List<ServicoInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT s.IDServico, s.IDCodigoBase, cs.Descricao AS Categoria, s.Descricao, s.ValorServico 
                        FROM DBServicos s
                        JOIN DBCategoriaServicos cs ON s.IDCategoriaServico = cs.IDCategoriaServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ServicoInfo servico = new ServicoInfo
                            {
                                IDServico = Convert.ToInt32(reader["IDServico"]),
                                IDCodigoBase = reader["IDCodigoBase"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                                ValorServico = Convert.ToDecimal(reader["ValorServico"]),
                            };
                            ServicosList.Add(servico);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar serviços: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar serviços: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ServicosList;
        }

        public ServicoInfo GetServico(int IDServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBServicos WHERE IDServico = @IDServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDServico", IDServico);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ServicoInfo
                            {
                                IDServico = Convert.ToInt32(reader["IDServico"]),
                                IDCodigoBase = reader["IDCodigoBase"].ToString(),
                                IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                                Descricao = reader["Descricao"].ToString(),
                                ValorServico = Convert.ToDecimal(reader["ValorServico"])
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void AtualizarServico(ServicoInfo servico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBServicos SET IDCodigoBase = @IDCodigoBase, IDCategoriaServico = @IDCategoriaServico, " +
                                   "Descricao = @Descricao, ValorServico = @ValorServico WHERE IDServico = @IDServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDServico", servico.IDServico);
                    cmd.Parameters.AddWithValue("@IDCodigoBase", servico.IDCodigoBase);
                    cmd.Parameters.AddWithValue("@IDCategoriaServico", servico.IDCategoriaServico);
                    cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
                    cmd.Parameters.AddWithValue("@ValorServico", servico.ValorServico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirServico(ServicoInfo servico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBServicos (IDCodigoBase, IDCategoriaServico, Descricao, ValorServico) " +
                                   "VALUES (@IDCodigoBase, @IDCategoriaServico, @Descricao, @ValorServico)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDCodigoBase", servico.IDCodigoBase);
                    cmd.Parameters.AddWithValue("@IDCategoriaServico", servico.IDCategoriaServico);
                    cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
                    cmd.Parameters.AddWithValue("@ValorServico", servico.ValorServico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirServico(int IDServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBServicos WHERE IDServico = @IDServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDServico", IDServico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
