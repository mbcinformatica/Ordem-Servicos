using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class ModeloDAL
    {
        private readonly string connectionString;

        public ModeloDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<ModeloInfo>> ListarAsync()
        {
            var modelosList = new List<ModeloInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        SELECT mo.IDModelo, m.Descricao AS Marca, mo.Descricao 
                        FROM DBModelos mo
                        JOIN DBMarcas m ON mo.IDMarca = m.IDMarca";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var modelo = new ModeloInfo
                            {
                                IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                Marca = reader["Marca"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                            };
                            modelosList.Add(modelo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar modelos: " + ex.Message, ex);
            }

            return modelosList;
        }

        public async Task<List<ModeloInfo>> ListarPorMarcaAsync(int idMarca)
        {
            var modelosList = new List<ModeloInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT IDModelo, Descricao FROM DBModelos WHERE IDMarca = @IDMarca";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", idMarca);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var modelo = new ModeloInfo
                                {
                                    IDModelo = Convert.ToInt32(reader["IDModelo"]),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                modelosList.Add(modelo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar modelos por marca: " + ex.Message, ex);
            }

            return modelosList;
        }

        public async Task<ModeloInfo> GetModeloAsync(int idModelo)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM DBModelos WHERE IDModelo = @IDModelo";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDModelo", idModelo);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
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
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar modelo: " + ex.Message, ex);
            }

            return null;
        }

        public async Task AtualizarModeloAsync(ModeloInfo modelo)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "UPDATE DBModelos SET IDMarca = @IDMarca, Descricao = @Descricao WHERE IDModelo = @IDModelo";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                        cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);
                        cmd.Parameters.AddWithValue("@IDModelo", modelo.IDModelo);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar modelo: " + ex.Message, ex);
            }
        }

        public async Task InserirModeloAsync(ModeloInfo modelo)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "INSERT INTO DBModelos (IDMarca, Descricao) VALUES (@IDMarca, @Descricao)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", modelo.IDMarca);
                        cmd.Parameters.AddWithValue("@Descricao", modelo.Descricao);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir modelo: " + ex.Message, ex);
            }
        }

        public async Task ExcluirModeloAsync(int idModelo)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM DBModelos WHERE IDModelo = @IDModelo";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDModelo", idModelo);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir modelo: " + ex.Message, ex);
            }
        }
    }
}
