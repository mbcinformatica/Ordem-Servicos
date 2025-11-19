namespace OrdemServicos
{
	partial class frmConfigDB
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDB));
            this.btnSair = new System.Windows.Forms.Button();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnTestarConexao = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(397, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(159, 51);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "    Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtPorta
            // 
            this.txtPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorta.Location = new System.Drawing.Point(477, 25);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(91, 22);
            this.txtPorta.TabIndex = 6;
            // 
            // txtServidor
            // 
            this.txtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.Location = new System.Drawing.Point(85, 28);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(307, 22);
            this.txtServidor.TabIndex = 4;
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorta.Location = new System.Drawing.Point(424, 27);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(47, 20);
            this.lblPorta.TabIndex = 7;
            this.lblPorta.Tag = "";
            this.lblPorta.Text = "Porta";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidor.ForeColor = System.Drawing.Color.Black;
            this.lblServidor.Location = new System.Drawing.Point(18, 27);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(67, 20);
            this.lblServidor.TabIndex = 5;
            this.lblServidor.Tag = "";
            this.lblServidor.Text = "Servidor";
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(336, 66);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(232, 22);
            this.txtUsuario.TabIndex = 12;
            // 
            // txtBanco
            // 
            this.txtBanco.Enabled = false;
            this.txtBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanco.Location = new System.Drawing.Point(85, 66);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(169, 22);
            this.txtBanco.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(269, 65);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblUsuario.TabIndex = 13;
            this.lblUsuario.Tag = "";
            this.lblUsuario.Text = "Usuario";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.ForeColor = System.Drawing.Color.Black;
            this.lblBanco.Location = new System.Drawing.Point(18, 65);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(55, 20);
            this.lblBanco.TabIndex = 11;
            this.lblBanco.Tag = "";
            this.lblBanco.Text = "Banco";
            // 
            // txtSenha
            // 
            this.txtSenha.Enabled = false;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(85, 107);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(232, 22);
            this.txtSenha.TabIndex = 14;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(18, 106);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(56, 20);
            this.lblSenha.TabIndex = 15;
            this.lblSenha.Tag = "";
            this.lblSenha.Text = "Senha";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(211, 3);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(179, 51);
            this.btnSalvar.TabIndex = 68;
            this.btnSalvar.Text = "      Salvar Configuração";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.AutoSize = true;
            this.btnTestarConexao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestarConexao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestarConexao.Image = ((System.Drawing.Image)(resources.GetObject("btnTestarConexao.Image")));
            this.btnTestarConexao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestarConexao.Location = new System.Drawing.Point(45, 3);
            this.btnTestarConexao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(159, 51);
            this.btnTestarConexao.TabIndex = 69;
            this.btnTestarConexao.Tag = "";
            this.btnTestarConexao.Text = "      Testar Conexão";
            this.btnTestarConexao.UseVisualStyleBackColor = false;
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnSair);
            this.pnlBotoes.Controls.Add(this.btnTestarConexao);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Location = new System.Drawing.Point(1, 146);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(581, 62);
            this.pnlBotoes.TabIndex = 99;
            // 
            // frmConfigDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 199);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.lblServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfigDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configuração DB";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSair;
		private System.Windows.Forms.TextBox txtPorta;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.Label lblPorta;
		private System.Windows.Forms.Label lblServidor;
		private System.Windows.Forms.ToolTip tlpDicas;
		private System.Windows.Forms.ErrorProvider erpProvider;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtBanco;
		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.Label lblBanco;
		private System.Windows.Forms.TextBox txtSenha;
		private System.Windows.Forms.Label lblSenha;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnTestarConexao;
		private System.Windows.Forms.Panel pnlBotoes;
	}
}