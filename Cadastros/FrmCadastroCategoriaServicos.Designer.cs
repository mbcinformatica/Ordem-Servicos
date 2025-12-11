namespace OrdemServicos
{
    partial class frmCategoriaServicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriaServicos));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.tabDadosCategoriaServico = new System.Windows.Forms.TabPage();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbIDCategoriaServico = new System.Windows.Forms.Label();
            this.txtIDCategoriaServico = new System.Windows.Forms.TextBox();
            this.tabControlCategoriaServicos = new System.Windows.Forms.TabControl();
            this.listViewCategoriaServico = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabDadosCategoriaServico.SuspendLayout();
            this.tabControlCategoriaServicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 28);
            this.tabInformacoesAdicionais.Margin = new System.Windows.Forms.Padding(4);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(4);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1415, 177);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // tabDadosCategoriaServico
            // 
            this.tabDadosCategoriaServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosCategoriaServico.Controls.Add(this.txtPesquisaListView);
            this.tabDadosCategoriaServico.Controls.Add(this.lblPesquisaListView);
            this.tabDadosCategoriaServico.Controls.Add(this.txtDescricao);
            this.tabDadosCategoriaServico.Controls.Add(this.lbDescricao);
            this.tabDadosCategoriaServico.Controls.Add(this.lbIDCategoriaServico);
            this.tabDadosCategoriaServico.Controls.Add(this.txtIDCategoriaServico);
            this.tabDadosCategoriaServico.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosCategoriaServico.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosCategoriaServico.Location = new System.Drawing.Point(4, 28);
            this.tabDadosCategoriaServico.Margin = new System.Windows.Forms.Padding(4);
            this.tabDadosCategoriaServico.Name = "tabDadosCategoriaServico";
            this.tabDadosCategoriaServico.Padding = new System.Windows.Forms.Padding(4);
            this.tabDadosCategoriaServico.Size = new System.Drawing.Size(1415, 177);
            this.tabDadosCategoriaServico.TabIndex = 0;
            this.tabDadosCategoriaServico.Text = "Dados da Categoria";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(27, 117);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(490, 26);
            this.txtPesquisaListView.TabIndex = 56;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(27, 94);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(225, 19);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Categoria de Serviço..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(210, 37);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(646, 26);
            this.txtDescricao.TabIndex = 65;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(210, 12);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(89, 19);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // lbIDCategoriaServico
            // 
            this.lbIDCategoriaServico.AutoSize = true;
            this.lbIDCategoriaServico.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDCategoriaServico.Location = new System.Drawing.Point(27, 12);
            this.lbIDCategoriaServico.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbIDCategoriaServico.Name = "lbIDCategoriaServico";
            this.lbIDCategoriaServico.Size = new System.Drawing.Size(40, 19);
            this.lbIDCategoriaServico.TabIndex = 61;
            this.lbIDCategoriaServico.Text = "ID..:";
            // 
            // txtIDCategoriaServico
            // 
            this.txtIDCategoriaServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDCategoriaServico.Enabled = false;
            this.txtIDCategoriaServico.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCategoriaServico.Location = new System.Drawing.Point(27, 37);
            this.txtIDCategoriaServico.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtIDCategoriaServico.Name = "txtIDCategoriaServico";
            this.txtIDCategoriaServico.Size = new System.Drawing.Size(142, 26);
            this.txtIDCategoriaServico.TabIndex = 64;
            this.txtIDCategoriaServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControlCategoriaServicos
            // 
            this.tabControlCategoriaServicos.Controls.Add(this.tabDadosCategoriaServico);
            this.tabControlCategoriaServicos.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlCategoriaServicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlCategoriaServicos.Location = new System.Drawing.Point(23, 5);
            this.tabControlCategoriaServicos.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlCategoriaServicos.Multiline = true;
            this.tabControlCategoriaServicos.Name = "tabControlCategoriaServicos";
            this.tabControlCategoriaServicos.SelectedIndex = 0;
            this.tabControlCategoriaServicos.Size = new System.Drawing.Size(1423, 209);
            this.tabControlCategoriaServicos.TabIndex = 73;
            // 
            // listViewCategoriaServico
            // 
            this.listViewCategoriaServico.CausesValidation = false;
            this.listViewCategoriaServico.FullRowSelect = true;
            this.listViewCategoriaServico.GridLines = true;
            this.listViewCategoriaServico.HideSelection = false;
            this.listViewCategoriaServico.Location = new System.Drawing.Point(23, 220);
            this.listViewCategoriaServico.Margin = new System.Windows.Forms.Padding(4);
            this.listViewCategoriaServico.Name = "listViewCategoriaServico";
            this.listViewCategoriaServico.Size = new System.Drawing.Size(1423, 348);
            this.listViewCategoriaServico.TabIndex = 71;
            this.listViewCategoriaServico.UseCompatibleStateImageBehavior = false;
            this.listViewCategoriaServico.View = System.Windows.Forms.View.Details;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Location = new System.Drawing.Point(18, 573);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1423, 61);
            this.pnlBotoes.TabIndex = 99;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(1007, 3);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 51);
            this.btnSalvar.TabIndex = 67;
            this.btnSalvar.Text = "    Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.Location = new System.Drawing.Point(873, 3);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(126, 51);
            this.btnAlterar.TabIndex = 66;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "   Alterar";
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(1140, 3);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(126, 51);
            this.btnExcluir.TabIndex = 68;
            this.btnExcluir.Text = "   Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.Location = new System.Drawing.Point(739, 3);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(126, 51);
            this.btnNovo.TabIndex = 65;
            this.btnNovo.Text = "   Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRegistros.Location = new System.Drawing.Point(10, 8);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(401, 42);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.Tag = "naoAplicar";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(1274, 3);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 51);
            this.btnFechar.TabIndex = 69;
            this.btnFechar.Text = "   Fechar";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1274, 3);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 51);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCategoriaServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.tabControlCategoriaServicos);
            this.Controls.Add(this.listViewCategoriaServico);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCategoriaServicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Categoria de Serviços";
            this.tabDadosCategoriaServico.ResumeLayout(false);
            this.tabDadosCategoriaServico.PerformLayout();
            this.tabControlCategoriaServicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TabPage tabDadosCategoriaServico;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.Label lbIDCategoriaServico;
        private System.Windows.Forms.TextBox txtIDCategoriaServico;
        private System.Windows.Forms.TabControl tabControlCategoriaServicos;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ListView listViewCategoriaServico;
		private System.Windows.Forms.Panel pnlBotoes;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnNovo;
		private System.Windows.Forms.Label lbTotalRegistros;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnCancelar;
//		private System.Windows.Forms.ToolTip tlpListViewCelula;
	}
}
