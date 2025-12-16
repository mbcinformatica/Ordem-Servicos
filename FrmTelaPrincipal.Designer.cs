namespace OrdemServicos
{
    partial class frmTelaPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.MenuStrip mnSMenu;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaPrincipal));
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaDeServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeFornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeUsuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexãoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnSMenu = new System.Windows.Forms.MenuStrip();
            mnSMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnSMenu
            // 
            mnSMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            mnSMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            mnSMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            mnSMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mnSMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            mnSMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            mnSMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.lancamentosToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.configuracoesToolStripMenuItem,
            this.sairToolStripMenuItem});
            mnSMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mnSMenu.Location = new System.Drawing.Point(0, 0);
            mnSMenu.MdiWindowListItem = this.relatoriosToolStripMenuItem;
            mnSMenu.Name = "mnSMenu";
            mnSMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            mnSMenu.ShowItemToolTips = true;
            mnSMenu.Size = new System.Drawing.Size(1578, 34);
            mnSMenu.Stretch = false;
            mnSMenu.TabIndex = 0;
            mnSMenu.Text = "mnSMenu";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.serviçosToolStripMenuItem,
            this.categoriaDeServiçosToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.unidadesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(131, 30);
            this.cadastrosToolStripMenuItem.Text = "&Cadastros";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.ProdutosToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // categoriaDeServiçosToolStripMenuItem
            // 
            this.categoriaDeServiçosToolStripMenuItem.Name = "categoriaDeServiçosToolStripMenuItem";
            this.categoriaDeServiçosToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.categoriaDeServiçosToolStripMenuItem.Text = "Categoria de Serviços";
            this.categoriaDeServiçosToolStripMenuItem.Click += new System.EventHandler(this.categoriaDeServiçosToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.marcasToolStripMenuItem.Text = "Marcas de Produtos";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.modelosToolStripMenuItem.Text = "Modelos de Prdutos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(337, 34);
            this.unidadesToolStripMenuItem.Text = "Unidades de Medidas";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // lancamentosToolStripMenuItem
            // 
            this.lancamentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviçosToolStripMenuItem1});
            this.lancamentosToolStripMenuItem.Name = "lancamentosToolStripMenuItem";
            this.lancamentosToolStripMenuItem.Size = new System.Drawing.Size(164, 30);
            this.lancamentosToolStripMenuItem.Text = "&Lançamentos";
            // 
            // serviçosToolStripMenuItem1
            // 
            this.serviçosToolStripMenuItem1.Name = "serviçosToolStripMenuItem1";
            this.serviçosToolStripMenuItem1.Size = new System.Drawing.Size(199, 34);
            this.serviçosToolStripMenuItem1.Text = "Serviços";
            this.serviçosToolStripMenuItem1.Click += new System.EventHandler(this.serviçosToolStripMenuItem1_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeClientesToolStripMenuItem,
            this.cadastroDeFornecedoresToolStripMenuItem,
            this.cadastroDeUsuáriosToolStripMenuItem});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(134, 30);
            this.relatoriosToolStripMenuItem.Text = "&Relatórios";
            // 
            // cadastroDeClientesToolStripMenuItem
            // 
            this.cadastroDeClientesToolStripMenuItem.Name = "cadastroDeClientesToolStripMenuItem";
            this.cadastroDeClientesToolStripMenuItem.Size = new System.Drawing.Size(384, 34);
            this.cadastroDeClientesToolStripMenuItem.Text = "Cadastro de Clientes";
            this.cadastroDeClientesToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeClientesToolStripMenuItem_Click);
            // 
            // cadastroDeFornecedoresToolStripMenuItem
            // 
            this.cadastroDeFornecedoresToolStripMenuItem.Name = "cadastroDeFornecedoresToolStripMenuItem";
            this.cadastroDeFornecedoresToolStripMenuItem.Size = new System.Drawing.Size(384, 34);
            this.cadastroDeFornecedoresToolStripMenuItem.Text = "Cadastro de Fornecedores";
            this.cadastroDeFornecedoresToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeFornecedoresToolStripMenuItem_Click);
            // 
            // cadastroDeUsuáriosToolStripMenuItem
            // 
            this.cadastroDeUsuáriosToolStripMenuItem.Name = "cadastroDeUsuáriosToolStripMenuItem";
            this.cadastroDeUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(384, 34);
            this.cadastroDeUsuáriosToolStripMenuItem.Text = "Cadastro de Usuários";
            this.cadastroDeUsuáriosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeUsuáriosToolStripMenuItem_Click);
            // 
            // configuracoesToolStripMenuItem
            // 
            this.configuracoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formularioToolStripMenuItem,
            this.conexãoDBToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.restoureToolStripMenuItem});
            this.configuracoesToolStripMenuItem.Name = "configuracoesToolStripMenuItem";
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(175, 30);
            this.configuracoesToolStripMenuItem.Text = "Con&figurações";
            // 
            // formularioToolStripMenuItem
            // 
            this.formularioToolStripMenuItem.Name = "formularioToolStripMenuItem";
            this.formularioToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.formularioToolStripMenuItem.Text = "Formulario";
            this.formularioToolStripMenuItem.Click += new System.EventHandler(this.formularioToolStripMenuItem_Click);
            // 
            // conexãoDBToolStripMenuItem
            // 
            this.conexãoDBToolStripMenuItem.Name = "conexãoDBToolStripMenuItem";
            this.conexãoDBToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.conexãoDBToolStripMenuItem.Text = "Conexão DB";
            this.conexãoDBToolStripMenuItem.Click += new System.EventHandler(this.conexãoDBToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restoureToolStripMenuItem
            // 
            this.restoureToolStripMenuItem.Name = "restoureToolStripMenuItem";
            this.restoureToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.restoureToolStripMenuItem.Text = "Restoure ";
            this.restoureToolStripMenuItem.Click += new System.EventHandler(this.restoureToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(71, 30);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // frmTelaPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(1578, 744);
            this.ControlBox = false;
            this.Controls.Add(mnSMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = mnSMenu;
            this.Name = "frmTelaPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Sistema Orden Serviços  -  Usuário Logado..: ";
            mnSMenu.ResumeLayout(false);
            mnSMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lancamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeFornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeUsuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formularioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaDeServiçosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem conexãoDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restoureToolStripMenuItem;
	}
}

