using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class ClienteDAL
    {
        private readonly string connectionString;

        public ClienteDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<ClienteInfo>> ListarAsync()
        {
            var clientesList = new List<ClienteInfo>();

            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT IDCliente, TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro 
                                 FROM DBClientes";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clientesList.Add(new ClienteInfo
                        {
                            IDCliente = Convert.ToInt32(reader["IDCliente"]),
                            TipoPessoa = reader["TipoPessoa"].ToString(),
                            Cpf_Cnpj = reader["Cpf_Cnpj"].ToString(),
                            Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString(),
                            Endereco = reader["Endereco"].ToString(),
                            Numero = reader["Numero"].ToString(),
                            Bairro = reader["Bairro"].ToString(),
                            Municipio = reader["Municipio"].ToString(),
                            UF = reader["UF"].ToString(),
                            Cep = reader["Cep"].ToString(),
                            Contato = reader["Contato"].ToString(),
                            Fone_1 = reader["Fone_1"].ToString(),
                            Fone_2 = reader["Fone_2"].ToString(),
                            Email = reader["Email"].ToString(),
                            DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
                        });
                    }
                }
            }

            return clientesList;
        }

        public async Task<ClienteInfo> GetClienteAsync(int idCliente)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT IDCliente, TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro 
                                 FROM DBClientes WHERE IDCliente = @IDCliente";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDCliente", idCliente);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ClienteInfo
                            {
                                IDCliente = Convert.ToInt32(reader["IDCliente"]),
                                TipoPessoa = reader["TipoPessoa"].ToString(),
                                Cpf_Cnpj = reader["Cpf_Cnpj"].ToString(),
                                Nome_RazaoSocial = reader["Nome_RazaoSocial"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Municipio = reader["Municipio"].ToString(),
                                UF = reader["UF"].ToString(),
                                Cep = reader["Cep"].ToString(),
                                Contato = reader["Contato"].ToString(),
                                Fone_1 = reader["Fone_1"].ToString(),
                                Fone_2 = reader["Fone_2"].ToString(),
                                Email = reader["Email"].ToString(),
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task AtualizarClienteAsync(ClienteInfo cliente)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"UPDATE DBClientes SET TipoPessoa=@TipoPessoa, Cpf_Cnpj=@Cpf_Cnpj, Nome_RazaoSocial=@Nome_RazaoSocial,
                                 Endereco=@Endereco, Numero=@Numero, Bairro=@Bairro, Municipio=@Municipio, UF=@UF, Cep=@Cep,
                                 Contato=@Contato, Fone_1=@Fone_1, Fone_2=@Fone_2, Email=@Email WHERE IDCliente=@IDCliente";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoPessoa", cliente.TipoPessoa);
                    cmd.Parameters.AddWithValue("@Cpf_Cnpj", cliente.Cpf_Cnpj);
                    cmd.Parameters.AddWithValue("@Nome_RazaoSocial", cliente.Nome_RazaoSocial);
                    cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                    cmd.Parameters.AddWithValue("@UF", cliente.UF);
                    cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                    cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
                    cmd.Parameters.AddWithValue("@Fone_1", cliente.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", cliente.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@IDCliente", cliente.IDCliente);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task InserirClienteAsync(ClienteInfo cliente)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO DBClientes (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro)
                                 VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoPessoa", cliente.TipoPessoa);
                    cmd.Parameters.AddWithValue("@Cpf_Cnpj", cliente.Cpf_Cnpj);
                    cmd.Parameters.AddWithValue("@Nome_RazaoSocial", cliente.Nome_RazaoSocial);
                    cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                    cmd.Parameters.AddWithValue("@UF", cliente.UF);
                    cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                    cmd.Parameters.AddWithValue("@Contato", cliente.Contato);
                    cmd.Parameters.AddWithValue("@Fone_1", cliente.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", cliente.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ExcluirClienteAsync(int idCliente)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM DBClientes WHERE IDCliente = @IDCliente";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDCliente", idCliente);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
