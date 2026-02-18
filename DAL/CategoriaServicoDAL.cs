using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class CategoriaServicoDAL
    {
        private readonly string connectionString;
        public CategoriaServicoDAL()
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

        public List<CategoriaServicoInfo> Listar()
        {
            List<CategoriaServicoInfo> CategoriaServicosList = new List<CategoriaServicoInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBCategoriaServicos";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoriaServicoInfo categoria = new CategoriaServicoInfo
                            {
                                IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                            CategoriaServicosList.Add(categoria);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar categorias de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar categorias de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return CategoriaServicosList;
        }

        public CategoriaServicoInfo GetCategoriaServico(int idCategoriaServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBCategoriaServicos WHERE IDCategoriaServico = @IDCategoriaServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDCategoriaServico", idCategoriaServico);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CategoriaServicoInfo
                            {
                                IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar categoria de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar categoria de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public async Task<CategoriaServicoInfo> GetCategoriaByNomeAsync(string nome)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM DBCategoriaServicos WHERE UPPER(Descricao) = @Descricao";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descricao", nome.ToUpperInvariant());
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new CategoriaServicoInfo
                            {
                                IDCategoriaServico = Convert.ToInt32(reader["IDCategoriaServico"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AtualizarCategoriaServico(CategoriaServicoInfo categoria)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBCategoriaServicos SET Descricao = @Descricao WHERE IDCategoriaServico = @IDCategoriaServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDCategoriaServico", categoria.IDCategoriaServico);
                    cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar categoria de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar categoria de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirCategoriaServico(CategoriaServicoInfo categoria)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBCategoriaServicos (Descricao) VALUES (@Descricao)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir categoria de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir categoria de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirCategoriaServico(int IDCategoriaServico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBCategoriaServicos WHERE IDCategoriaServico = @IDCategoriaServico";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDCategoriaServico", IDCategoriaServico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir categoria de serviço: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir categoria de serviço: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
