using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class UnidadeDAL
    {
        private readonly string connectionString;

        public UnidadeDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<UnidadeInfo>> ListarAsync()
        {
            var unidadesList = new List<UnidadeInfo>();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM DBUnidades";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var unidade = new UnidadeInfo
                            {
                                IDUnidade = Convert.ToInt32(reader["IDUnidade"]),
                                Descricao = reader["Descricao"].ToString()
                            };
                            unidadesList.Add(unidade);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar unidades: " + ex.Message, ex);
            }

            return unidadesList;
        }

        public async Task<UnidadeInfo> GetUnidadeAsync(int idUnidade)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM DBUnidades WHERE IDUnidade = @IDUnidade";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDUnidade", idUnidade);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new UnidadeInfo
                                {
                                    IDUnidade = Convert.ToInt32(reader["IDUnidade"]),
                                    Descricao = reader["Descricao"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar unidade: " + ex.Message, ex);
            }

            return null;
        }

        public async Task AtualizarUnidadeAsync(UnidadeInfo unidade)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "UPDATE DBUnidades SET Descricao = @Descricao WHERE IDUnidade = @IDUnidade";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Descricao", unidade.Descricao);
                        cmd.Parameters.AddWithValue("@IDUnidade", unidade.IDUnidade);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar unidade: " + ex.Message, ex);
            }
        }

        public async Task InserirUnidadeAsync(UnidadeInfo unidade)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO DBUnidades (Descricao) VALUES (@Descricao)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Descricao", unidade.Descricao);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir unidade: " + ex.Message, ex);
            }
        }

        public async Task ExcluirUnidadeAsync(int idUnidade)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "DELETE FROM DBUnidades WHERE IDUnidade = @IDUnidade";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDUnidade", idUnidade);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir unidade: " + ex.Message, ex);
            }
        }
    }
}
