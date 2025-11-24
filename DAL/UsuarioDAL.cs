using MySql.Data.MySqlClient;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace OrdemServicos.DAL
{
    public class UsuarioDAL
    {
        private readonly string connectionString;
        public UsuarioDAL()
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

        public List<UsuarioInfo> Listar()
        {
            List<UsuarioInfo> UsuariosList = new List<UsuarioInfo>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBUsuarios";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioInfo usuario = new UsuarioInfo
                            {
                                IDUsuario = Convert.ToInt32(reader["IDUsuario"]),
                                Nome = reader["Nome"].ToString(),
                                Login = reader["Login"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Municipio = reader["Municipio"].ToString(),
                                UF = reader["UF"].ToString(),
                                Cep = reader["Cep"].ToString(),
                                Fone_1 = reader["Fone_1"].ToString(),
                                Fone_2 = reader["Fone_2"].ToString(),
                                Email = reader["Email"].ToString(),
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"]),
                                Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                            };
                            UsuariosList.Add(usuario);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao listar usuários: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao listar usuários: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return UsuariosList;
        }

        public UsuarioInfo GetUsuario(int IDUsuario)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM DBUsuarios WHERE IDUsuario = @IDUsuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDUsuario", IDUsuario);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UsuarioInfo
                            {
                                IDUsuario = Convert.ToInt32(reader["IDUsuario"]),
                                Nome = reader["Nome"].ToString(),
                                Login = reader["Login"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Numero = reader["Numero"].ToString(),
                                Bairro = reader["Bairro"].ToString(),
                                Municipio = reader["Municipio"].ToString(),
                                UF = reader["UF"].ToString(),
                                Cep = reader["Cep"].ToString(),
                                Fone_1 = reader["Fone_1"].ToString(),
                                Fone_2 = reader["Fone_2"].ToString(),
                                Email = reader["Email"].ToString(),
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"]),
                                Imagem = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao buscar usuário: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao buscar usuário: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void AtualizarUsuario(UsuarioInfo usuario)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DBUsuarios SET Nome = @Nome, Login = @Login, " +
                                   "Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Municipio = @Municipio, " +
                                   "UF = @UF, Cep = @Cep, Fone_1 = @Fone_1, Fone_2 = @Fone_2, " +
                                   "Email = @Email, Imagem = @Imagem WHERE IDUsuario = @IDUsuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Login", usuario.Login);
                    cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", usuario.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", usuario.Municipio);
                    cmd.Parameters.AddWithValue("@UF", usuario.UF);
                    cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                    cmd.Parameters.AddWithValue("@Fone_1", usuario.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", usuario.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Imagem", usuario.Imagem ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDUsuario", usuario.IDUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao atualizar usuário: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao atualizar usuário: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirUsuario(UsuarioInfo usuario)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO DBUsuarios (Nome, Login, Senha, Endereco, Numero, Bairro, Municipio, UF, Cep, Fone_1, Fone_2, Email, DataCadastro, Imagem) " +
                                   "VALUES (@Nome, @Login, @Senha, @Endereco, @Numero, @Bairro, @Municipio, @UF, @Cep, @Fone_1, @Fone_2, @Email, @DataCadastro, @Imagem)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Login", usuario.Login);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@Endereco", usuario.Endereco);
                    cmd.Parameters.AddWithValue("@Numero", usuario.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
                    cmd.Parameters.AddWithValue("@Municipio", usuario.Municipio);
                    cmd.Parameters.AddWithValue("@UF", usuario.UF);
                    cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                    cmd.Parameters.AddWithValue("@Fone_1", usuario.Fone_1);
                    cmd.Parameters.AddWithValue("@Fone_2", usuario.Fone_2);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
                    cmd.Parameters.AddWithValue("@Imagem", usuario.Imagem ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao inserir usuário: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao inserir usuário: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ExcluirUsuario(int IDUsuario)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DBUsuarios WHERE IDUsuario = @IDUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDUsuario", IDUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao excluir usuário: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao excluir usuário: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool IsUsuariosEmpty()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM DBUsuarios";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro MySQL ao verificar se há usuários cadastrados: " + ex.Message,
                                "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Em caso de erro, retorna true para evitar bloqueio do sistema
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao verificar se há usuários cadastrados: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
    }
}
