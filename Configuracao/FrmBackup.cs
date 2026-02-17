using OrdemServicos.Forms;
using OrdemServicos.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrdemServicos
{
    public partial class frmBackup : BaseForm
    {
        public frmBackup()
        {
            InitializeComponent();
            LoadConfig();

            Paint += new PaintEventHandler(BaseForm_Paint);
            erpProvider = new ErrorProvider();

            // Melhor chamar no evento Load
            this.Load += frmBackup_Load;
        }

        private async void frmBackup_Load(object sender, EventArgs e)
        {
            await ExecutaBackup();
        }

        private async Task ExecutaBackup()
        {
            try
            {
                var dbUtils = new DockerMySqlUtils();

                // Usa a barra do formulário (já adicionada no Designer)
                await dbUtils.BackupTablesAsync(new List<string>
                {
                    "DBCategoriaServicos",
                    "DBClientes",
                    "DBFornecedores",
                    "DBLancamentoServicos",
                    "DBMarcas",
                    "DBModelos",
                    "DBProdutos",
                    "DBServicos",
                    "DBUnidades",
                    "DBUsuarios"
                }, CustomProgressBar);

                MessageBox.Show("Backup concluído com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar backup:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close(); // fecha automaticamente após backup
            }
        }
    }
}