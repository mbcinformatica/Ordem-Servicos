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
            this.imgCadeadoAberto = new System.Windows.Forms.PictureBox();
            this.imgCadeadoFechado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoAberto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoFechado)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCadeadoAberto
            // 
            this.imgCadeadoAberto.Enabled = false;
            this.imgCadeadoAberto.Location = new System.Drawing.Point(344, 165);
            this.imgCadeadoAberto.Name = "imgCadeadoAberto";
            this.imgCadeadoAberto.Size = new System.Drawing.Size(112, 120);
            this.imgCadeadoAberto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCadeadoAberto.TabIndex = 12;
            this.imgCadeadoAberto.TabStop = false;
            this.imgCadeadoAberto.Visible = false;
            // 
            // imgCadeadoFechado
            // 
            this.imgCadeadoFechado.Enabled = false;
            this.imgCadeadoFechado.Location = new System.Drawing.Point(161, 116);
            this.imgCadeadoFechado.Name = "imgCadeadoFechado";
            this.imgCadeadoFechado.Size = new System.Drawing.Size(112, 120);
            this.imgCadeadoFechado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCadeadoFechado.TabIndex = 13;
            this.imgCadeadoFechado.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imgCadeadoFechado);
            this.Controls.Add(this.imgCadeadoAberto);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoAberto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeadoFechado)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imgCadeadoAberto;
		private System.Windows.Forms.PictureBox imgCadeadoFechado;
	}
}