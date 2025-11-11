using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OrdemServicos.DAL
{
    public class FornecedorDAL
    {
        private readonly string connectionString;
        public FornecedorDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public List<FornecedorInfo> Listar()
        {
            List<FornecedorInfo> FornecedoresList = new List<FornecedorInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBFornecedores";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FornecedorInfo Fornecedor = new FornecedorInfo
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
                            FornecedoresList.Add(Fornecedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar fornecedores: " + ex.Message);
            }

            return FornecedoresList;
        }

        public FornecedorInfo GetFornecedor(int IDFornecedor)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDFornecedor", IDFornecedor);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar fornecedor: " + ex.Message);
            }

            return null;
        }

        public void AtualizarFornecedor(FornecedorInfo fornecedor)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBFornecedores SET TipoPessoa = @TipoPessoa, Cpf_Cnpj = @Cpf_Cnpj, Nome_RazaoSocial = @Nome_RazaoSocial, " +
                                   "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                                   "UF = @UF, Cep = @Cep, Contato = @Contato, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                                   "Email = @Email WHERE IDFornecedor = @IDFornecedor";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar fornecedor: " + ex.Message);
            }
        }

        public void InserirFornecedor(FornecedorInfo fornecedor)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBFornecedores (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro) " +
                                   "VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir fornecedor: " + ex.Message);
            }
        }

        public void ExcluirFornecedor(int IDFornecedor)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBFornecedores WHERE IDFornecedor = @IDFornecedor";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDFornecedor", IDFornecedor);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir fornecedor: " + ex.Message);
            }
        }
    }
}