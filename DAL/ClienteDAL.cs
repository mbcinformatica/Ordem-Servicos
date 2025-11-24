using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class ClienteDAL
    {
        private readonly string connectionString;
        public ClienteDAL()
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

        public List<ClienteInfo> Listar()
        {
            List<ClienteInfo> ClientesList = new List<ClienteInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBClientes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteInfo Cliente = new ClienteInfo
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
                            ClientesList.Add(Cliente);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar clientes: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar clientes: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ClientesList;
        }

        public ClienteInfo GetCliente(int IDCliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBClientes WHERE IDCliente = @IDCliente";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar cliente: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar cliente: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public void AtualizarCliente(ClienteInfo cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBClientes SET TipoPessoa = @TipoPessoa, Cpf_Cnpj = @Cpf_Cnpj, Nome_RazaoSocial = @Nome_RazaoSocial, " +
                                   "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                                   "UF = @UF, Cep = @Cep, Contato = @Contato, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                                   "Email = @Email WHERE IDCliente = @IDCliente";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar cliente: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar cliente: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirCliente(ClienteInfo cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBClientes (TipoPessoa, Cpf_Cnpj, Nome_RazaoSocial, Endereco, Numero, Bairro, Municipio, UF, Cep, Contato, Fone_1, Fone_2, Email, DataCadastro) " +
                                   "VALUES (@TipoPessoa, @Cpf_Cnpj, @Nome_RazaoSocial, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Contato, @Fone_1, @Fone_2, @Email, @DataCadastro)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir cliente: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir cliente: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExcluirCliente(int IDCliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBClientes WHERE IDCliente = @IDCliente";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir cliente: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir cliente: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}