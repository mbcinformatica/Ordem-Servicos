namespace OrdemServicos
{
    partial class frmModelos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModelos));
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.tabDadosModelo = new System.Windows.Forms.TabPage();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lbMarcaProduto = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.lbIDModelo = new System.Windows.Forms.Label();
            this.txtIDModelo = new System.Windows.Forms.TextBox();
            this.tabControlModelos = new System.Windows.Forms.TabControl();
            this.listViewModelos = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabDadosModelo.SuspendLayout();
            this.tabControlModelos.SuspendLayout();
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
            this.tabInformacoesAdicionais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1415, 249);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // tabDadosModelo
            // 
            this.tabDadosModelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosModelo.Controls.Add(this.cmbMarca);
            this.tabDadosModelo.Controls.Add(this.lbMarcaProduto);
            this.tabDadosModelo.Controls.Add(this.txtPesquisaListView);
            this.tabDadosModelo.Controls.Add(this.lblPesquisaListView);
            this.tabDadosModelo.Controls.Add(this.txtDescricao);
            this.tabDadosModelo.Controls.Add(this.lbDescricao);
            this.tabDadosModelo.Controls.Add(this.lbIDModelo);
            this.tabDadosModelo.Controls.Add(this.txtIDModelo);
            this.tabDadosModelo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosModelo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosModelo.Location = new System.Drawing.Point(4, 28);
            this.tabDadosModelo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDadosModelo.Name = "tabDadosModelo";
            this.tabDadosModelo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDadosModelo.Size = new System.Drawing.Size(1415, 249);
            this.tabDadosModelo.TabIndex = 0;
            this.tabDadosModelo.Text = "Dados do Modelo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.Color.White;
            this.cmbMarca.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(165, 30);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(268, 27);
            this.cmbMarca.TabIndex = 78;
            // 
            // lbMarcaProduto
            // 
            this.lbMarcaProduto.AutoSize = true;
            this.lbMarcaProduto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarcaProduto.Location = new System.Drawing.Point(165, 10);
            this.lbMarcaProduto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbMarcaProduto.Name = "lbMarcaProduto";
            this.lbMarcaProduto.Size = new System.Drawing.Size(67, 19);
            this.lbMarcaProduto.TabIndex = 77;
            this.lbMarcaProduto.Text = "Marca..:";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(10, 117);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(490, 26);
            this.txtPesquisaListView.TabIndex = 56;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(10, 97);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(137, 19);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Modelo..:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AccessibleDescription = "";
            this.txtDescricao.AccessibleName = "";
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(482, 30);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(646, 26);
            this.txtDescricao.TabIndex = 65;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescricao.Location = new System.Drawing.Point(482, 10);
            this.lbDescricao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(89, 19);
            this.lbDescricao.TabIndex = 63;
            this.lbDescricao.Text = "Descrição..:";
            // 
            // lbIDModelo
            // 
            this.lbIDModelo.AutoSize = true;
            this.lbIDModelo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDModelo.Location = new System.Drawing.Point(10, 10);
            this.lbIDModelo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbIDModelo.Name = "lbIDModelo";
            this.lbIDModelo.Size = new System.Drawing.Size(40, 19);
            this.lbIDModelo.TabIndex = 61;
            this.lbIDModelo.Text = "ID..:";
            // 
            // txtIDModelo
            // 
            this.txtIDModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDModelo.Enabled = false;
            this.txtIDModelo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDModelo.Location = new System.Drawing.Point(10, 30);
            this.txtIDModelo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtIDModelo.Name = "txtIDModelo";
            this.txtIDModelo.Size = new System.Drawing.Size(106, 26);
            this.txtIDModelo.TabIndex = 64;
            this.txtIDModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControlModelos
            // 
            this.tabControlModelos.Controls.Add(this.tabDadosModelo);
            this.tabControlModelos.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlModelos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlModelos.Location = new System.Drawing.Point(18, 4);
            this.tabControlModelos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlModelos.Multiline = true;
            this.tabControlModelos.Name = "tabControlModelos";
            this.tabControlModelos.SelectedIndex = 0;
            this.tabControlModelos.Size = new System.Drawing.Size(1423, 281);
            this.tabControlModelos.TabIndex = 73;
            // 
            // listViewModelos
            // 
            this.listViewModelos.CausesValidation = false;
            this.listViewModelos.FullRowSelect = true;
            this.listViewModelos.GridLines = true;
            this.listViewModelos.HideSelection = false;
            this.listViewModelos.Location = new System.Drawing.Point(18, 290);
            this.listViewModelos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewModelos.Name = "listViewModelos";
            this.listViewModelos.Size = new System.Drawing.Size(1423, 276);
            this.listViewModelos.TabIndex = 71;
            this.listViewModelos.UseCompatibleStateImageBehavior = false;
            this.listViewModelos.View = System.Windows.Forms.View.Details;
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
            this.pnlBotoes.TabIndex = 98;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1007, 3);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 51);
            this.btnSalvar.TabIndex = 67;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(873, 3);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(126, 51);
            this.btnAlterar.TabIndex = 66;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "       Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(1140, 3);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(126, 51);
            this.btnExcluir.TabIndex = 68;
            this.btnExcluir.Text = "     Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(739, 3);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(126, 51);
            this.btnNovo.TabIndex = 65;
            this.btnNovo.Text = "     Novo";
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
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(1274, 3);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 51);
            this.btnFechar.TabIndex = 69;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1274, 3);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 51);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmModelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.tabControlModelos);
            this.Controls.Add(this.listViewModelos);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmModelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Modelos";
            this.tabDadosModelo.ResumeLayout(false);
            this.tabDadosModelo.PerformLayout();
            this.tabControlModelos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TabPage tabDadosModelo;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.Label lbIDModelo;
        private System.Windows.Forms.TextBox txtIDModelo;
        private System.Windows.Forms.TabControl tabControlModelos;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.ListView listViewModelos;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lbMarcaProduto;
		private System.Windows.Forms.Panel pnlBotoes;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnNovo;
		private System.Windows.Forms.Label lbTotalRegistros;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnCancelar;
	}
}
