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
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnTestarConexao = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.AllowDrop = true;
            this.btnTestarConexao.AutoSize = true;
            this.btnTestarConexao.BackColor = System.Drawing.SystemColors.Control;
            this.btnTestarConexao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestarConexao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestarConexao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.erpProvider.SetIconAlignment(this.btnTestarConexao, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.btnTestarConexao.Image = ((System.Drawing.Image)(resources.GetObject("btnTestarConexao.Image")));
            this.btnTestarConexao.Location = new System.Drawing.Point(166, 244);
            this.btnTestarConexao.Margin = new System.Windows.Forms.Padding(6);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(238, 75);
            this.btnTestarConexao.TabIndex = 97;
            this.btnTestarConexao.Tag = "";
            this.btnTestarConexao.Text = "   Testar Conexão";
            this.btnTestarConexao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestarConexao.UseVisualStyleBackColor = false;
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.erpProvider.SetIconAlignment(this.btnSalvar, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(440, 244);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(238, 75);
            this.btnSalvar.TabIndex = 96;
            this.btnSalvar.Text = "   Salvar Configuração";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_ClickAsync);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnTestarConexao);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.txtPorta);
            this.panel1.Controls.Add(this.lblPorta);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.lblSenha);
            this.panel1.Controls.Add(this.txtBanco);
            this.panel1.Controls.Add(this.lblBanco);
            this.panel1.Controls.Add(this.txtServidor);
            this.panel1.Controls.Add(this.lblServidor);
            this.panel1.Location = new System.Drawing.Point(10, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 359);
            this.panel1.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.SystemColors.Control;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(714, 244);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnFechar.Size = new System.Drawing.Size(238, 75);
            this.btnFechar.TabIndex = 95;
            this.btnFechar.Text = "   Sair";
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(864, 96);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(285, 40);
            this.txtUsuario.TabIndex = 93;
            this.txtUsuario.Tag = "naoAplicar";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(708, 96);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(139, 32);
            this.lblUsuario.TabIndex = 94;
            this.lblUsuario.Tag = "naoAplicar";
            this.lblUsuario.Text = "Usuario...:";
            // 
            // txtPorta
            // 
            this.txtPorta.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorta.Location = new System.Drawing.Point(864, 41);
            this.txtPorta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(103, 40);
            this.txtPorta.TabIndex = 91;
            this.txtPorta.Tag = "naoAplicar";
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorta.Location = new System.Drawing.Point(708, 49);
            this.lblPorta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(111, 32);
            this.lblPorta.TabIndex = 92;
            this.lblPorta.Tag = "naoAplicar";
            this.lblPorta.Text = "Porta...:";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(190, 151);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(479, 40);
            this.txtSenha.TabIndex = 89;
            this.txtSenha.Tag = "naoAplicar";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(28, 159);
            this.lblSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(118, 32);
            this.lblSenha.TabIndex = 90;
            this.lblSenha.Tag = "naoAplicar";
            this.lblSenha.Text = "Senha...:";
            // 
            // txtBanco
            // 
            this.txtBanco.Enabled = false;
            this.txtBanco.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanco.Location = new System.Drawing.Point(190, 96);
            this.txtBanco.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(479, 40);
            this.txtBanco.TabIndex = 87;
            this.txtBanco.Tag = "naoAplicar";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.ForeColor = System.Drawing.Color.Black;
            this.lblBanco.Location = new System.Drawing.Point(28, 99);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(141, 32);
            this.lblBanco.TabIndex = 88;
            this.lblBanco.Tag = "naoAplicar";
            this.lblBanco.Text = "Banco......:";
            // 
            // txtServidor
            // 
            this.txtServidor.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.Location = new System.Drawing.Point(190, 41);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(4);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(479, 40);
            this.txtServidor.TabIndex = 85;
            this.txtServidor.Tag = "naoAplicar";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidor.ForeColor = System.Drawing.Color.Black;
            this.lblServidor.Location = new System.Drawing.Point(28, 44);
            this.lblServidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(145, 32);
            this.lblServidor.TabIndex = 86;
            this.lblServidor.Tag = "naoAplicar";
            this.lblServidor.Text = "Servidor...:";
            // 
            // frmConfigDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 390);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmConfigDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuração DB";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip tlpDicas;
		private System.Windows.Forms.ErrorProvider erpProvider;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtSenha;
		private System.Windows.Forms.Label lblSenha;
		private System.Windows.Forms.TextBox txtBanco;
		private System.Windows.Forms.Label lblBanco;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.Label lblServidor;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.TextBox txtPorta;
		private System.Windows.Forms.Label lblPorta;
		private System.Windows.Forms.Button btnTestarConexao;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnSalvar;
	}
}