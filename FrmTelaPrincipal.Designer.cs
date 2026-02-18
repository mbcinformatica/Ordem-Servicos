using System;

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
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaDeServiçosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesDeMedidaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbcProgressoBar = new ProgressBarCustom.ProgressBarCustom();
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
            mnSMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            mnSMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.lancamentosToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.configuracoesToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.sairToolStripMenuItem});
            mnSMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            mnSMenu.Location = new System.Drawing.Point(0, 0);
            mnSMenu.MdiWindowListItem = this.relatoriosToolStripMenuItem;
            mnSMenu.Name = "mnSMenu";
            mnSMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            mnSMenu.ShowItemToolTips = true;
            mnSMenu.Size = new System.Drawing.Size(1578, 31);
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
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(109, 27);
            this.cadastrosToolStripMenuItem.Text = "&Cadastros";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.ProdutosToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // categoriaDeServiçosToolStripMenuItem
            // 
            this.categoriaDeServiçosToolStripMenuItem.Name = "categoriaDeServiçosToolStripMenuItem";
            this.categoriaDeServiçosToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.categoriaDeServiçosToolStripMenuItem.Text = "Categoria de Serviços";
            this.categoriaDeServiçosToolStripMenuItem.Click += new System.EventHandler(this.categoriaDeServiçosToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.marcasToolStripMenuItem.Text = "Marcas de Produtos";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.modelosToolStripMenuItem.Text = "Modelos de Prdutos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(279, 28);
            this.unidadesToolStripMenuItem.Text = "Unidades de Medidas";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // lancamentosToolStripMenuItem
            // 
            this.lancamentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviçosToolStripMenuItem1});
            this.lancamentosToolStripMenuItem.Name = "lancamentosToolStripMenuItem";
            this.lancamentosToolStripMenuItem.Size = new System.Drawing.Size(136, 27);
            this.lancamentosToolStripMenuItem.Text = "&Lançamentos";
            // 
            // serviçosToolStripMenuItem1
            // 
            this.serviçosToolStripMenuItem1.Name = "serviçosToolStripMenuItem1";
            this.serviçosToolStripMenuItem1.Size = new System.Drawing.Size(165, 28);
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
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(111, 27);
            this.relatoriosToolStripMenuItem.Text = "&Relatórios";
            // 
            // cadastroDeClientesToolStripMenuItem
            // 
            this.cadastroDeClientesToolStripMenuItem.Name = "cadastroDeClientesToolStripMenuItem";
            this.cadastroDeClientesToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
            this.cadastroDeClientesToolStripMenuItem.Text = "Cadastro de Clientes";
            this.cadastroDeClientesToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeClientesToolStripMenuItem_Click);
            // 
            // cadastroDeFornecedoresToolStripMenuItem
            // 
            this.cadastroDeFornecedoresToolStripMenuItem.Name = "cadastroDeFornecedoresToolStripMenuItem";
            this.cadastroDeFornecedoresToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
            this.cadastroDeFornecedoresToolStripMenuItem.Text = "Cadastro de Fornecedores";
            this.cadastroDeFornecedoresToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeFornecedoresToolStripMenuItem_Click);
            // 
            // cadastroDeUsuáriosToolStripMenuItem
            // 
            this.cadastroDeUsuáriosToolStripMenuItem.Name = "cadastroDeUsuáriosToolStripMenuItem";
            this.cadastroDeUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
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
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(145, 27);
            this.configuracoesToolStripMenuItem.Text = "Con&figurações";
            // 
            // formularioToolStripMenuItem
            // 
            this.formularioToolStripMenuItem.Name = "formularioToolStripMenuItem";
            this.formularioToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.formularioToolStripMenuItem.Text = "Formulario";
            this.formularioToolStripMenuItem.Click += new System.EventHandler(this.formularioToolStripMenuItem_Click);
            // 
            // conexãoDBToolStripMenuItem
            // 
            this.conexãoDBToolStripMenuItem.Name = "conexãoDBToolStripMenuItem";
            this.conexãoDBToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.conexãoDBToolStripMenuItem.Text = "Conexão DB";
            this.conexãoDBToolStripMenuItem.Click += new System.EventHandler(this.conexãoDBToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restoureToolStripMenuItem
            // 
            this.restoureToolStripMenuItem.Name = "restoureToolStripMenuItem";
            this.restoureToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.restoureToolStripMenuItem.Text = "Restoure ";
            this.restoureToolStripMenuItem.Click += new System.EventHandler(this.restoureToolStripMenuItem_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarDadosToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(131, 27);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // importarDadosToolStripMenuItem
            // 
            this.importarDadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem1,
            this.fornecedoresToolStripMenuItem1,
            this.produtosToolStripMenuItem1,
            this.serviçosToolStripMenuItem2,
            this.categoriaDeServiçosToolStripMenuItem1,
            this.marcasToolStripMenuItem1,
            this.modelosToolStripMenuItem1,
            this.unidadesDeMedidaToolStripMenuItem1});
            this.importarDadosToolStripMenuItem.Name = "importarDadosToolStripMenuItem";
            this.importarDadosToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.importarDadosToolStripMenuItem.Text = "Importar Dados";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // fornecedoresToolStripMenuItem1
            // 
            this.fornecedoresToolStripMenuItem1.Name = "fornecedoresToolStripMenuItem1";
            this.fornecedoresToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.fornecedoresToolStripMenuItem1.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem1.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem1_Click);
            // 
            // produtosToolStripMenuItem1
            // 
            this.produtosToolStripMenuItem1.Name = "produtosToolStripMenuItem1";
            this.produtosToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.produtosToolStripMenuItem1.Text = "Produtos";
            // 
            // serviçosToolStripMenuItem2
            // 
            this.serviçosToolStripMenuItem2.Name = "serviçosToolStripMenuItem2";
            this.serviçosToolStripMenuItem2.Size = new System.Drawing.Size(279, 28);
            this.serviçosToolStripMenuItem2.Text = "Serviços";
            this.serviçosToolStripMenuItem2.Click += new System.EventHandler(this.serviçosToolStripMenuItem2_Click);
            // 
            // categoriaDeServiçosToolStripMenuItem1
            // 
            this.categoriaDeServiçosToolStripMenuItem1.Name = "categoriaDeServiçosToolStripMenuItem1";
            this.categoriaDeServiçosToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.categoriaDeServiçosToolStripMenuItem1.Text = "Categoria de Serviços";
            this.categoriaDeServiçosToolStripMenuItem1.Click += new System.EventHandler(this.categoriaDeServiçosToolStripMenuItem1_ClickAsync);
            // 
            // marcasToolStripMenuItem1
            // 
            this.marcasToolStripMenuItem1.Name = "marcasToolStripMenuItem1";
            this.marcasToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.marcasToolStripMenuItem1.Text = "Marcas";
            this.marcasToolStripMenuItem1.Click += new System.EventHandler(this.marcasToolStripMenuItem1_ClickAsync);
            // 
            // modelosToolStripMenuItem1
            // 
            this.modelosToolStripMenuItem1.Name = "modelosToolStripMenuItem1";
            this.modelosToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.modelosToolStripMenuItem1.Text = "Modelos";
            this.modelosToolStripMenuItem1.Click += new System.EventHandler(this.modelosToolStripMenuItem1_ClickAsync);
            // 
            // unidadesDeMedidaToolStripMenuItem1
            // 
            this.unidadesDeMedidaToolStripMenuItem1.Name = "unidadesDeMedidaToolStripMenuItem1";
            this.unidadesDeMedidaToolStripMenuItem1.Size = new System.Drawing.Size(279, 28);
            this.unidadesDeMedidaToolStripMenuItem1.Text = "Unidades de Medidas";
            this.unidadesDeMedidaToolStripMenuItem1.Click += new System.EventHandler(this.unidadesDeMedidaToolStripMenuItem1_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(58, 27);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pbcProgressoBar
            // 
            this.pbcProgressoBar.AutoCenter = false;
            this.pbcProgressoBar.DisplayText = "AAAAAAAAA";
            this.pbcProgressoBar.Location = new System.Drawing.Point(593, 221);
            this.pbcProgressoBar.Name = "pbcProgressoBar";
            this.pbcProgressoBar.Size = new System.Drawing.Size(419, 59);
            this.pbcProgressoBar.TabIndex = 2;
            this.pbcProgressoBar.Visible = false;
            // 
            // frmTelaPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(1578, 744);
            this.ControlBox = false;
            this.Controls.Add(this.pbcProgressoBar);
            this.Controls.Add(mnSMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = mnSMenu;
            this.Name = "frmTelaPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
		private ProgressBarCustom.ProgressBarCustom pbcProgressoBar;
		private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importarDadosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem categoriaDeServiçosToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem unidadesDeMedidaToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem1;
	}
}

