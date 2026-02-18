using OrdemServicos.BLL;
using OrdemServicos.Forms;
using OrdemServicos.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos
{
    public partial class frmTelaPrincipal : BaseForm
    {
        public bool vCloseSistema;
        public frmTelaPrincipal()
        {
            InitializeComponent();
            LoadConfig();
            this.Paint += new PaintEventHandler(BaseForm_Paint);
            this.Load += frmTelaPrincipal_Load;

            // Inicialmente oculto
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
        }
        private async void frmTelaPrincipal_Load(object sender, EventArgs e)
        {
            bool loginOK = await VerificaLoginAsync();
            if (!loginOK)
            {
                BeginInvoke(new Action(() => Application.Exit()));
                return;
            }

            AbrirFormularioLogin();

            if (vCloseSistema)
            {
                this.Text = $"Sistema - Usuário: {BaseForm.UsuarioLogado}";
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;

                // Pega a resolução atual do monitor onde o formulário está
                Rectangle screenArea = Screen.FromControl(this).WorkingArea;

                // Ajusta tamanho proporcional (80% da tela)
                Width = (int)(screenArea.Width * 0.8);
                Height = (int)(screenArea.Height * 0.8);

                // Centraliza
                StartPosition = FormStartPosition.Manual;
                Location = new Point(
                    (screenArea.Width - Width) / 2,
                    (screenArea.Height - Height) / 2
                );

                // Escala proporcional à resolução atual (sem valores fixos)
                float escalaX = (float)screenArea.Width / (float)Width;
                float escalaY = (float)screenArea.Height / (float)Height;
                this.AutoScaleMode = AutoScaleMode.Font;
  //              this.Scale(new SizeF(escalaX, escalaY));
            }
        }
        private async Task<bool> VerificaLoginAsync()
        {
            var dbsetupBLL = new DBSetupBLL();

            if (await dbsetupBLL.CheckAndSetupDatabaseAsync()) // ✅ chamada assíncrona
            {
                try
                {
                    var usuarioBLL = new UsuarioBLL();

                    if (usuarioBLL.IsUsuariosEmpty())
                    {
                        string mensagem = "Não existe Usuário Cadastrado.\n\nAntes de continuar a usar o sistema, \nFavor Cadastrar um Usuário com Direitos Administrativos.\n\nCadastre um novo usuário.";
                        MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AbrirFormularioUsuarios();

                        if (usuarioBLL.IsUsuariosEmpty())
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    string mensagem = "Erro de Conexão.\n\nNão foi Posivel Conectar ao Banco de Dados.";
                    MessageBox.Show(mensagem, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        private void AbrirFormularioLogin()
        {
            frmLogin FrmLogin = new frmLogin();
            frmLogin formularioLogin = FrmLogin;

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioLogin.StartPosition = FormStartPosition.CenterScreen;
            formularioLogin.ShowDialog();
            vCloseSistema = formularioLogin.vCloseSistema;

        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimparRelatoriosPDF();
            Application.Exit(); // Fecha o programa inteiro
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioClientes();
        }
        private void AbrirFormularioClientes()
        {
            frmClientes FrmClientes = new frmClientes();
            frmClientes formularioClientes = FrmClientes;
            /*
                        // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
                        formularioClientes.Width = (int)(Width * 0.9);
                        formularioClientes.Height = (int)(Height * 0.8);

             //           formularioClientes.StartPosition = FormStartPosition.Manual;
              //          formularioClientes.Location = new Point(
             //               Location.X + (Width - formularioClientes.Width) / 2,
              //              Location.Y + (Height - formularioClientes.Height) / 2);
              */
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioClientes.StartPosition = FormStartPosition.CenterScreen;
            formularioClientes.ShowDialog();
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUsuarios();
        }
        private void AbrirFormularioUsuarios()
        {
            frmUsuarios FrmUsuarios = new frmUsuarios();
            frmUsuarios formularioUsuarios = FrmUsuarios;
            /*
            // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
            formularioUsuarios.Width = (int)(Width );
            formularioUsuarios.Height = (int)(Height * 0.9);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioUsuarios.StartPosition = FormStartPosition.Manual;
            formularioUsuarios.Location = new Point(
                Location.X + (Width - formularioUsuarios.Width) /2 ,
                Location.Y + (Height - formularioUsuarios.Height) / 2);
            */
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioUsuarios.StartPosition = FormStartPosition.CenterScreen;
            formularioUsuarios.ShowDialog();
        }
        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioFornecedores();
        }
        private void AbrirformularioFornecedores()
        {
            frmFornecedores FrmFornecedores = new frmFornecedores();
            frmFornecedores formularioFornecedores = FrmFornecedores;

            /* Define o tamanho do formulário de fornecedores para 90% da largura e 90% da altura da tela principal
            formularioFornecedores.Width = (int)(Width * 0.9);
           formularioFornecedores.Height = (int)(Height * 0.8);

            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioFornecedores.StartPosition = FormStartPosition.Manual;
            formularioFornecedores.Location = new Point(
                Location.X + (Width - formularioFornecedores.Width) / 2,
               Location.Y + (Height - formularioFornecedores.Height) / 2);
            */
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioFornecedores.StartPosition = FormStartPosition.CenterScreen;
            formularioFornecedores.ShowDialog();
        }
        private void categoriaDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioCategoriaServicos();
        }
        private void AbrirformularioCategoriaServicos()
        {
            frmCategoriaServicos FrmCategoriaServicos = new frmCategoriaServicos();
            frmCategoriaServicos formularioCategoriaServicos = FrmCategoriaServicos;
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioCategoriaServicos.StartPosition = FormStartPosition.CenterScreen;
            formularioCategoriaServicos.ShowDialog();
        }
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioMarcas();
        }
        private void AbrirformularioMarcas()
        {
            frmMarcas FrmMarcas = new frmMarcas();
            frmMarcas formularioMarcas = FrmMarcas;
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioMarcas.StartPosition = FormStartPosition.CenterScreen;
            formularioMarcas.ShowDialog();
        }
        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioModelos();

        }
        private void AbrirformularioModelos()
        {
            frmModelos FrmModelos = new frmModelos();
            frmModelos formularioModelos = FrmModelos;
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioModelos.StartPosition = FormStartPosition.CenterScreen;
            formularioModelos.ShowDialog();
        }
        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioUnidades();

        }
        private void AbrirformularioUnidades()
        {
            frmUnidades FrmUnidades = new frmUnidades();
            frmUnidades formularioUnidades = FrmUnidades;
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioUnidades.StartPosition = FormStartPosition.CenterScreen;
            formularioUnidades.ShowDialog();
        }
        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirformularioServicos();

        }
        private void AbrirformularioServicos()
        {
            frmServicos FrmServicos = new frmServicos();
            frmServicos formularioServicos = FrmServicos;
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioServicos.StartPosition = FormStartPosition.CenterScreen;
            formularioServicos.ShowDialog();
        }
        private async void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await AbrirRelatorioClientesAsync();
        }
        private async Task AbrirRelatorioClientesAsync()
        {
            // Defina o caminho base onde o relatório será salvo
            string diretorioRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RelatorioPDF");

            // Verifique se o diretório existe, se não, crie-o
            if (!Directory.Exists(diretorioRelatorio))
            {
                Directory.CreateDirectory(diretorioRelatorio);
            }

            string caminhoBase = Path.Combine(diretorioRelatorio, "RelatorioClientes.pdf");
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorioRelatorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioClientes
            var relatorio = new RelatorioClientes();

            // Gere o relatório de forma assíncrona
            string resultado = await relatorio.GerarRelatorioClientesAsync(caminhoArquivo);

            if (resultado == null)
            {
                MessageBox.Show("Nenhum dado de clientes disponível para gerar o relatório.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Relatório gerado com sucesso em:\n\n" + resultado,
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre o PDF
                Process.Start(new ProcessStartInfo(resultado) { UseShellExecute = true });
            }
        }
        private async void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await AbrirRelatorioFornecedoresAsync();
        }
        private async Task AbrirRelatorioFornecedoresAsync()
        {
            // Defina o caminho base onde o relatório será salvo
            string diretorioRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RelatorioPDF");

            // Verifique se o diretório existe, se não, crie-o
            if (!Directory.Exists(diretorioRelatorio))
            {
                Directory.CreateDirectory(diretorioRelatorio);
            }

            string caminhoBase = Path.Combine(diretorioRelatorio, "RelatorioFornecedores.pdf");
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorioRelatorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioFornecedores
            var relatorio = new RelatorioFornecedores();

            // Gere o relatório de forma assíncrona
            string resultado = await relatorio.GerarRelatorioFornecedoresAsync(caminhoArquivo);

            if (resultado == null)
            {
                MessageBox.Show("Nenhum dado de fornecedores disponível para gerar o relatório.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Relatório gerado com sucesso em:\n\n" + resultado,
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre o PDF
                Process.Start(new ProcessStartInfo(resultado) { UseShellExecute = true });
            }
        }
        private async void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await AbrirRelatorioUsuariosAsync();
        }
        private async Task AbrirRelatorioUsuariosAsync()
        {
            // Defina o caminho base onde o relatório será salvo
            string diretorioRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RelatorioPDF");

            // Verifique se o diretório existe, se não, crie-o
            if (!Directory.Exists(diretorioRelatorio))
            {
                Directory.CreateDirectory(diretorioRelatorio);
            }

            string caminhoBase = Path.Combine(diretorioRelatorio, "RelatorioUsuarios.pdf");
            string caminhoArquivo = caminhoBase;

            // Verifique se o arquivo já existe e gere um novo nome se necessário
            int contador = 1;
            while (File.Exists(caminhoArquivo))
            {
                string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
                string extensao = Path.GetExtension(caminhoBase);
                caminhoArquivo = Path.Combine(diretorioRelatorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
                contador++;
            }

            // Crie uma instância da classe RelatorioUsuarios
            var relatorio = new RelatorioUsuarios();

            // Gere o relatório de forma assíncrona
            string resultado = await relatorio.GerarRelatorioUsuariosAsync(caminhoArquivo);

            if (resultado == null)
            {
                MessageBox.Show("Nenhum dado de usuários disponível para gerar o relatório.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Relatório gerado com sucesso em:\n\n" + resultado,
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre o PDF
                Process.Start(new ProcessStartInfo(resultado) { UseShellExecute = true });
            }
        }
        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioProdutos();
        }
        private void AbrirFormularioProdutos()
        {
            frmProdutos FrmProdutos = new frmProdutos();
            frmProdutos formularioProdutos = FrmProdutos;
            /*
                        // Define o tamanho do formulário de clientes para 90% da largura e 90% da altura da tela principal
                        formularioProdutos.Width = (int)(Width * 0.9);
                        formularioProdutos.Height = (int)(Height * 0.8);

                        // Ajusta a localização para ficar abaixo do menu do formulário principal
                        formularioProdutos.StartPosition = FormStartPosition.Manual;
                        formularioProdutos.Location = new Point(
                            Location.X + (Width - formularioProdutos.Width) / 2,
                            Location.Y + (Height - formularioProdutos.Height) / 2);
            */
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioProdutos.StartPosition = FormStartPosition.CenterScreen;
            formularioProdutos.ShowDialog();
        }
        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirConfiguracaoFormulaio();
        }
        private void AbrirConfiguracaoFormulaio()
        {
            frmConfigFormulario FrmConfigFormulario = new frmConfigFormulario();
            frmConfigFormulario formularioConfigFormulario = FrmConfigFormulario;
            formularioConfigFormulario.StartPosition = FormStartPosition.CenterScreen;
            formularioConfigFormulario.ShowDialog();
        }
        private void serviçosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulaioLancamentoServicos();
        }
        private void AbrirFormulaioLancamentoServicos()
        {
            frmLancamentoServicos FrmLancamentoServicos = new frmLancamentoServicos();
            frmLancamentoServicos formularioLancamentoServicos = FrmLancamentoServicos;
            /*
                        // Define o tamanho do formulário de ConfigFormulario para 90% da largura e 90% da altura da tela principal
                        formularioLancamentoServicos.Width = (int)(Width * 0.9);
                        formularioLancamentoServicos.Height = (int)(Height * 0.8);

                        // Ajusta a localização para ficar abaixo do menu do formulário principal
                        formularioLancamentoServicos.StartPosition = FormStartPosition.Manual;
                        formularioLancamentoServicos.Location = new Point(
                            Location.X + (Width - formularioLancamentoServicos.Width) / 2,
                            Location.Y + (Height - formularioLancamentoServicos.Height) / 2);
            */
            // Ajusta a localização para ficar abaixo do menu do formulário principal
            formularioLancamentoServicos.StartPosition = FormStartPosition.CenterScreen;
            formularioLancamentoServicos.ShowDialog();
        }
        private void LimparRelatoriosPDF()
        {
            string diretorioRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RelatorioPDF");

            if (Directory.Exists(diretorioRelatorio))
            {
                try
                {
                    string[] arquivos = Directory.GetFiles(diretorioRelatorio, "*.pdf");

                    foreach (string arquivo in arquivos)
                    {
                        File.Delete(arquivo);
                    }
                }
                catch
                {
                    //  MessageBox.Show("Erro ao limpar relatórios PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            LimparRelatoriosPDF();
            base.OnFormClosing(e);
        }
        private void conexãoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioConexaoDB();
        }
        private void AbrirFormularioConexaoDB()
        {
            frmConfigDB FrmConfigDB = new frmConfigDB(true);
            frmConfigDB formulariofrmConfigDB = FrmConfigDB;
            formulariofrmConfigDB.StartPosition = FormStartPosition.CenterScreen;
            formulariofrmConfigDB.ShowDialog();
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dbUtils = new DockerMySqlUtils();
                dbUtils.BackupTablesAsync(new List<string>
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
                }, pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Realizar Backup:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void restoureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dbUtils = new DockerMySqlUtils();
                dbUtils.RestoreTableAsync(pbcProgressoBar);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Restaurar Backup:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void unidadesDeMedidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarUnidadesMedida();
                await importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar Unidades de Medida:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private async void marcasToolStripMenuItem1_ClickAsync( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarMarcas();
                await importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Marcas:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private async void modelosToolStripMenuItem1_ClickAsync( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarModelos();
                await importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Marcas:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private async void categoriaDeServiçosToolStripMenuItem1_ClickAsync( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarCategoriasServicos();
                await importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Categorias de Serviços:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void serviçosToolStripMenuItem2_Click( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarServicos();
                importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Serviços:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void clientesToolStripMenuItem1_Click( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarClientes();
                importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Clientes:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void fornecedoresToolStripMenuItem1_Click( object sender, EventArgs e )
		{
            try
            {
                var importador = new OrdemServicos.Ferramentas.ImportarFornecedores();
                importador.ExecutarImportacaoAsync(pbcProgressoBar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Importar Fornecedore:\n\n" + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}
}