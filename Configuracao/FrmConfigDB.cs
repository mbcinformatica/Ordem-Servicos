using MySql.Data.MySqlClient;
using OrdemServicos.DAL;
using OrdemServicos.Forms;
using OrdemServicos.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos
{
    public partial class frmConfigDB : BaseForm
    {
        private string connectionString = ConfigurationManager.AppSettings["ConnectionStringWithoutDatabase"];
        private string connectionStringWithoutDatabase = ConfigurationManager.AppSettings["ConnectionStringWithoutDatabase"];
        private (Control, string)[] camposObrigatorios;
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesMouseMove = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();
        public bool vCloseSistema;

        public frmConfigDB()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            LimparCampos();
            vCloseSistema = false;
        }
        private void CarregaKey()
        {
            // Adicionar controles às listas específicas com base no tipo de evento
            controlesKeyPress.AddRange(new Control[] {
                txtPorta
            });

            controlesEnter.AddRange(new Control[] {
                txtServidor,
                txtPorta,
                txtUsuario,
                txtSenha,
                txtBanco
            });

            controlesMouseDown.AddRange(new Control[] { });
            controlesLeave.AddRange(new Control[] {
                txtServidor,
                txtPorta,
                txtUsuario,
                txtSenha,
                txtBanco
            });

            controlesKeyDown.AddRange(new Control[] {
                txtServidor,
                txtPorta,
                txtUsuario,
                txtSenha,
                txtBanco
            });

            controlesBotoes.AddRange(new Control[] {
                btnTestarConexao,
                btnSalvar,
                btnSair
            });

            this.Tag = "frmConfigDB";

            TabControl tabControl = null;
            TabPage tabPage = null;
            txtPorta.Tag = new BaseForm { TagAction = "SomenteNumeros" }; // Permitir somente letras

            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesMouseMove, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                (txtServidor,"Servidor"),
                (txtPorta,"Porta"),
                (txtUsuario,"Usuario"),
                (txtSenha,"Senha"),
                (txtBanco,"Banco")
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        private new void LimparCampos()
        {
            // Carrega valores atuais do App.config
            txtServidor.Text = ExtrairValor("Server", ConfigurationManager.AppSettings["ConnectionString"]);
            txtPorta.Text = ExtrairValor("Port", ConfigurationManager.AppSettings["ConnectionString"]);
            txtUsuario.Text = ExtrairValor("Uid", ConfigurationManager.AppSettings["ConnectionString"]);
            txtSenha.Text = ExtrairValor("Pwd", ConfigurationManager.AppSettings["ConnectionString"]);
            txtBanco.Text = ExtrairValor("Database", ConfigurationManager.AppSettings["ConnectionString"]);
        }
        private string ExtrairValor(string chave, string connStr)
        {
            if (string.IsNullOrEmpty(connStr)) return "";
            foreach (var parte in connStr.Split(';'))
            {
                if (parte.StartsWith(chave, StringComparison.OrdinalIgnoreCase))
                {
                    return parte.Split('=')[1];
                }
            }
            return "";
        }
        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            if (TestarConexao())
            {
                btnSalvar.Focus();
            }
            else
            {
                txtServidor.Focus();
            }
        }
        private bool TestarConexao()
        {
            bool sucesso = false;
            string connStr = $"Server={txtServidor.Text};Port={txtPorta.Text};Database={txtBanco.Text};Uid={txtUsuario.Text};Pwd={txtSenha.Text};";
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(connStr))
                {
                    conexao.Open();
                    MessageBox.Show("Conexão bem-sucedida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sucesso = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sucesso;
        }
        private async void btnSalvar_ClickAsync(object sender, EventArgs e)
        {
            string connStr = $"Server={txtServidor.Text};Port={txtPorta.Text};Database={txtBanco.Text};Uid={txtUsuario.Text};Pwd={txtSenha.Text};";
            string connStrSemDB = $"Server={txtServidor.Text};Port={txtPorta.Text};Uid={txtUsuario.Text};Pwd={txtSenha.Text};";

            // Atualiza App.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ConnectionString"].Value = connStr;
            config.AppSettings.Settings["ConnectionStringWithoutDatabase"].Value = connStrSemDB;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            connectionStringWithoutDatabase = ConfigurationManager.AppSettings["ConnectionStringWithoutDatabase"];

            try
            {
                var mysqlSetup = new DBSetupDAL();
                mysqlSetup.CheckAndSetupDatabaseAsync();
                using (MySqlConnection conexao = new MySqlConnection(connStr))
                {
                    conexao.Open();
                }
                var dbSetup = new DBSetupDAL();
                if (await dbSetup.CheckAndSetupDatabaseAsync())
                {
                    MessageBox.Show("Configuração salva e banco/tabelas criados com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vCloseSistema = true;
                    btnSair.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com os dados informados: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vCloseSistema = false;
                txtServidor.Focus();
            }
            LimparCampos();
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (!vCloseSistema)
            {
                Application.Exit();
            }
            else
			{
                Close();
                return;
            }
        }
    }
}
