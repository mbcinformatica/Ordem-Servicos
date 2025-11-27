using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace OrdemServicos.DAL
{
    public class FornecedorDAL
    {
        private readonly string connectionString;

        public FornecedorDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public async Task<List<FornecedorInfo>> ListarAsync()
        {
            var fornecedoresList = new List<FornecedorInfo>();

            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT IDFornecedor, TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro 
                                 FROM DBFornecedores";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fornecedoresList.Add(new FornecedorInfo
                        {
                            IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]),
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

            return fornecedoresList;
        }

        public async Task<FornecedorInfo> GetFornecedorAsync(int idFornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"SELECT IDFornecedor, TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro 
                                 FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDFornecedor", idFornecedor);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new FornecedorInfo
                            {
                                IDFornecedor = Convert.ToInt32(reader["IDFornecedor"]),
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

        public async Task AtualizarFornecedorAsync(FornecedorInfo fornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"UPDATE DBFornecedores SET TipoPessoa=@TipoPessoa, Cpf_Cnpj=@Cpf_Cnpj, Nome_RazaoSocial=@Nome_RazaoSocial,
                                 Endereco=@Endereco, Numero=@Numero, Bairro=@Bairro, Municipio=@Municipio, UF=@UF, Cep=@Cep,
                                 Contato=@Contato, Fone_1=@Fone_1, Fone_2=@Fone_2, Email=@Email WHERE IDFornecedor=@IDFornecedor";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoPessoa", fornecedor.TipoPessoa);
                    cmd.Parameters.AddWithValue("@Cpf_Cnpj", fornecedor.Cpf_Cnpj);
                    cmd.Parameters.AddWithValue("@Nome_RazaoSocial", fornecedor.Nome_RazaoSocial);
                    cmd.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", fornecedor.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", fornecedor.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", fornecedor.Municipio);
                    cmd.Parameters.AddWithValue("@UF", fornecedor.UF);
                    cmd.Parameters.AddWithValue("@Cep", fornecedor.Cep);
                    cmd.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                    cmd.Parameters.AddWithValue("@Fone_1", fornecedor.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", fornecedor.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@IDFornecedor", fornecedor.IDFornecedor);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task InserirFornecedorAsync(FornecedorInfo fornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = @"INSERT INTO DBFornecedores (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro)
                                 VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TipoPessoa", fornecedor.TipoPessoa);
                    cmd.Parameters.AddWithValue("@Cpf_Cnpj", fornecedor.Cpf_Cnpj);
                    cmd.Parameters.AddWithValue("@Nome_RazaoSocial", fornecedor.Nome_RazaoSocial);
                    cmd.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", fornecedor.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", fornecedor.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", fornecedor.Municipio);
                    cmd.Parameters.AddWithValue("@UF", fornecedor.UF);
                    cmd.Parameters.AddWithValue("@Cep", fornecedor.Cep);
                    cmd.Parameters.AddWithValue("@Contato", fornecedor.Contato);
                    cmd.Parameters.AddWithValue("@Fone_1", fornecedor.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", fornecedor.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", fornecedor.Email);
                    cmd.Parameters.AddWithValue("@DataCadastro", fornecedor.DataCadastro);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ExcluirFornecedorAsync(int idFornecedor)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IDFornecedor", idFornecedor);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
