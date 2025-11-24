using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class ModeloDAL
    {
        private readonly string connectionString;
        public ModeloDAL()
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

        public List<ModeloInfo> Listar()
        {
            List<ModeloInfo> ModelosList = new List<ModeloInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT mo.IDModelo, m.Descricao AS Marca, mo.Descricao 
                        FROM DBModelos mo
                        JOIN DBMarcas m ON mo.IDMarca = m.IDMarca";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModeloInfo modelo = new ModeloInfo
                            {
                                IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                Marca = reader["Marca"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                            };
                            ModelosList.Add(modelo);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar modelos: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar modelos: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ModelosList;
        }

        public List<ModeloInfo> ListarPorMarca(int idMarca)
        {
            List<ModeloInfo> modelosList = new List<ModeloInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IDModelo, Descricao FROM DBModelos WHERE IDMarca = @IDMarca";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDMarca", idMarca);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModeloInfo modelo = new ModeloInfo
                            {
                                IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                            modelosList.Add(modelo);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar modelos por marca: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar modelos por marca: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return modelosList;
        }

        public ModeloInfo GetModelo(int IDModelo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBModelos WHERE IDModelo = @IDModelo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDModelo", IDModelo);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ModeloInfo
                            {
                                IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                IDMarca = Convert.ToInt32(reader["IDMarca"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar modelo: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar modelo: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void AtualizarModelo(ModeloInfo modelo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBModelos SET IDMarca = @IDMarca, Descricao = @Descricao WHERE IDModelo = @IDModelo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                    cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                    cmd.Parameters.AddWithValue("@IDModelo", modelo.IDModelo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar modelo: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar modelo: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirModelo(ModeloInfo modelo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBModelos (IDMarca, Descricao) VALUES (@IDMarca, @Descricao)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                    cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir modelo: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir modelo: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirModelo(int IDModelo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBModelos WHERE IDModelo = @IDModelo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDModelo", IDModelo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir modelo: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir modelo: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
