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
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnTestarConexao = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnTestarConexao);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnSair);
            this.pnlBotoes.Location = new System.Drawing.Point(122, 161);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(581, 62);
            this.pnlBotoes.TabIndex = 98;
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.AutoSize = true;
            this.btnTestarConexao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestarConexao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestarConexao.Image = ((System.Drawing.Image)(resources.GetObject("btnTestarConexao.Image")));
            this.btnTestarConexao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestarConexao.Location = new System.Drawing.Point(73, 4);
            this.btnTestarConexao.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(159, 51);
            this.btnTestarConexao.TabIndex = 72;
            this.btnTestarConexao.Tag = "";
            this.btnTestarConexao.Text = "      Testar Conexão";
            this.btnTestarConexao.UseVisualStyleBackColor = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(240, 4);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(179, 51);
            this.btnSalvar.TabIndex = 71;
            this.btnSalvar.Text = "      Salvar Configuração";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(406, 4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(159, 51);
            this.btnSair.TabIndex = 70;
            this.btnSair.Text = "    Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 514);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "Form3";
            this.Text = "Form3";
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel pnlBotoes;
		private System.Windows.Forms.Button btnTestarConexao;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnSair;
	}
}