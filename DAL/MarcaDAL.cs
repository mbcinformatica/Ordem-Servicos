using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class MarcaDAL
    {
        private readonly string connectionString;

        public MarcaDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<MarcaInfo>> ListarAsync()
        {
            var marcasList = new List<MarcaInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM DBMarcas";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var marca = new MarcaInfo
                            {
                                IDMarca = Convert.ToInt32(reader["IDMarca"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                            marcasList.Add(marca);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar marcas: " + ex.Message, ex);
            }

            return marcasList;
        }

        public async Task<MarcaInfo> GetMarcaAsync(int idMarca)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM DBMarcas WHERE IDMarca = @IDMarca";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", idMarca);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new MarcaInfo
                                {
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
                throw new Exception("Erro ao buscar marca: " + ex.Message, ex);
            }

            return null;
        }
        public async Task<MarcaInfo> GetMarcaByNomeAsync(string nome)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM DBMarcas WHERE UPPER(Descricao) = @Descricao";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Descricao", nome.ToUpperInvariant());

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new MarcaInfo
                                {
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
                throw new Exception("Erro ao buscar marca por nome: " + ex.Message, ex);
            }

            return null;
        }
        public async Task AtualizarMarcaAsync(MarcaInfo marca)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "UPDATE DBMarcas SET Descricao = @Descricao WHERE IDMarca = @IDMarca";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);
                        cmd.Parameters.AddWithValue("@IDMarca", marca.IDMarca);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar marca: " + ex.Message, ex);
            }
        }

        public async Task InserirMarcaAsync(MarcaInfo marca)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO DBMarcas (Descricao) VALUES (@Descricao)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Descricao", marca.Descricao);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir marca: " + ex.Message, ex);
            }
        }

        public async Task ExcluirMarcaAsync(int idMarca)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "DELETE FROM DBMarcas WHERE IDMarca = @IDMarca";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDMarca", idMarca);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir marca: " + ex.Message, ex);
            }
        }
    }
}
