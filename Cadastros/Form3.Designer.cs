namespace OrdemServicos.Cadastros
{
	partial class Form3
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.listViewProdutos = new System.Windows.Forms.ListView();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlOpcaoListView = new System.Windows.Forms.Panel();
            this.lnkOpcaoCorFundoLinha2 = new System.Windows.Forms.LinkLabel();
            this.lnkOpcaoCorFundoLinha1 = new System.Windows.Forms.LinkLabel();
            this.lnkOpcaoCorFundoColunaSelecionada = new System.Windows.Forms.LinkLabel();
            this.lnkOpcaoCorFundoCabecalho = new System.Windows.Forms.LinkLabel();
            this.pnlBotoes.SuspendLayout();
            this.pnlOpcaoListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProdutos
            // 
            this.listViewProdutos.CausesValidation = false;
            this.listViewProdutos.FullRowSelect = true;
            this.listViewProdutos.GridLines = true;
            this.listViewProdutos.HideSelection = false;
            this.listViewProdutos.Location = new System.Drawing.Point(18, 290);
            this.listViewProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.listViewProdutos.Name = "listViewProdutos";
            this.listViewProdutos.Size = new System.Drawing.Size(1423, 276);
            this.listViewProdutos.TabIndex = 72;
            this.listViewProdutos.UseCompatibleStateImageBehavior = false;
            this.listViewProdutos.View = System.Windows.Forms.View.Details;
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
            this.pnlBotoes.TabIndex = 73;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1002, 3);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 51);
            this.btnSalvar.TabIndex = 67;
            this.btnSalvar.Text = "    Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(868, 3);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(126, 51);
            this.btnAlterar.TabIndex = 66;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "   Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(1135, 3);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(126, 51);
            this.btnExcluir.TabIndex = 68;
            this.btnExcluir.Text = "   Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(734, 3);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(126, 51);
            this.btnNovo.TabIndex = 65;
            this.btnNovo.Text = "   Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
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
            this.btnFechar.Location = new System.Drawing.Point(1269, 3);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 51);
            this.btnFechar.TabIndex = 69;
            this.btnFechar.Text = "   Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1269, 3);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 51);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "   Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlOpcaoListView
            // 
            this.pnlOpcaoListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOpcaoListView.Controls.Add(this.lnkOpcaoCorFundoLinha2);
            this.pnlOpcaoListView.Controls.Add(this.lnkOpcaoCorFundoLinha1);
            this.pnlOpcaoListView.Controls.Add(this.lnkOpcaoCorFundoColunaSelecionada);
            this.pnlOpcaoListView.Controls.Add(this.lnkOpcaoCorFundoCabecalho);
            this.pnlOpcaoListView.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.pnlOpcaoListView.Location = new System.Drawing.Point(281, 82);
            this.pnlOpcaoListView.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOpcaoListView.Name = "pnlOpcaoListView";
            this.pnlOpcaoListView.Size = new System.Drawing.Size(303, 103);
            this.pnlOpcaoListView.TabIndex = 91;
            this.pnlOpcaoListView.Visible = false;
            // 
            // lnkOpcaoCorFundoLinha2
            // 
            this.lnkOpcaoCorFundoLinha2.AutoSize = true;
            this.lnkOpcaoCorFundoLinha2.BackColor = System.Drawing.Color.Transparent;
            this.lnkOpcaoCorFundoLinha2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpcaoCorFundoLinha2.ForeColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoLinha2.LinkColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoLinha2.Location = new System.Drawing.Point(27, 121);
            this.lnkOpcaoCorFundoLinha2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOpcaoCorFundoLinha2.Name = "lnkOpcaoCorFundoLinha2";
            this.lnkOpcaoCorFundoLinha2.Size = new System.Drawing.Size(311, 23);
            this.lnkOpcaoCorFundoLinha2.TabIndex = 6;
            this.lnkOpcaoCorFundoLinha2.TabStop = true;
            this.lnkOpcaoCorFundoLinha2.Text = "Alterar a Cor de Fundo do 2° Linha ";
            // 
            // lnkOpcaoCorFundoLinha1
            // 
            this.lnkOpcaoCorFundoLinha1.AutoSize = true;
            this.lnkOpcaoCorFundoLinha1.BackColor = System.Drawing.Color.Transparent;
            this.lnkOpcaoCorFundoLinha1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpcaoCorFundoLinha1.ForeColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoLinha1.LinkColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoLinha1.Location = new System.Drawing.Point(4, 68);
            this.lnkOpcaoCorFundoLinha1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOpcaoCorFundoLinha1.Name = "lnkOpcaoCorFundoLinha1";
            this.lnkOpcaoCorFundoLinha1.Size = new System.Drawing.Size(311, 23);
            this.lnkOpcaoCorFundoLinha1.TabIndex = 5;
            this.lnkOpcaoCorFundoLinha1.TabStop = true;
            this.lnkOpcaoCorFundoLinha1.Text = "Alterar a Cor de Fundo do 1° Linha ";
            // 
            // lnkOpcaoCorFundoColunaSelecionada
            // 
            this.lnkOpcaoCorFundoColunaSelecionada.AutoSize = true;
            this.lnkOpcaoCorFundoColunaSelecionada.BackColor = System.Drawing.Color.Transparent;
            this.lnkOpcaoCorFundoColunaSelecionada.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpcaoCorFundoColunaSelecionada.ForeColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoColunaSelecionada.LinkColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoColunaSelecionada.Location = new System.Drawing.Point(4, 33);
            this.lnkOpcaoCorFundoColunaSelecionada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOpcaoCorFundoColunaSelecionada.Name = "lnkOpcaoCorFundoColunaSelecionada";
            this.lnkOpcaoCorFundoColunaSelecionada.Size = new System.Drawing.Size(399, 23);
            this.lnkOpcaoCorFundoColunaSelecionada.TabIndex = 4;
            this.lnkOpcaoCorFundoColunaSelecionada.TabStop = true;
            this.lnkOpcaoCorFundoColunaSelecionada.Text = "Alterar a Cor de Fundo da Coluna Selecionada";
            // 
            // lnkOpcaoCorFundoCabecalho
            // 
            this.lnkOpcaoCorFundoCabecalho.AutoSize = true;
            this.lnkOpcaoCorFundoCabecalho.BackColor = System.Drawing.Color.Transparent;
            this.lnkOpcaoCorFundoCabecalho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOpcaoCorFundoCabecalho.ForeColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoCabecalho.LinkColor = System.Drawing.Color.Black;
            this.lnkOpcaoCorFundoCabecalho.Location = new System.Drawing.Point(4, -2);
            this.lnkOpcaoCorFundoCabecalho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOpcaoCorFundoCabecalho.Name = "lnkOpcaoCorFundoCabecalho";
            this.lnkOpcaoCorFundoCabecalho.Size = new System.Drawing.Size(323, 23);
            this.lnkOpcaoCorFundoCabecalho.TabIndex = 3;
            this.lnkOpcaoCorFundoCabecalho.TabStop = true;
            this.lnkOpcaoCorFundoCabecalho.Text = "Alterar a Cor de Fundo do Cabeçalho";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 640);
            this.Controls.Add(this.pnlOpcaoListView);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.listViewProdutos);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.pnlOpcaoListView.ResumeLayout(false);
            this.pnlOpcaoListView.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView listViewProdutos;
		private System.Windows.Forms.Panel pnlBotoes;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnNovo;
		private System.Windows.Forms.Label lbTotalRegistros;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Panel pnlOpcaoListView;
		private System.Windows.Forms.LinkLabel lnkOpcaoCorFundoLinha2;
		private System.Windows.Forms.LinkLabel lnkOpcaoCorFundoLinha1;
		private System.Windows.Forms.LinkLabel lnkOpcaoCorFundoColunaSelecionada;
		private System.Windows.Forms.LinkLabel lnkOpcaoCorFundoCabecalho;
	}
}