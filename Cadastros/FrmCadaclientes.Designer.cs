namespace OrdemServicos
{
	partial class frmCadaclientes
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
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // frmCadaclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1461, 645);
            this.Name = "frmCadaclientes";
            this.Text = "FrmCadaclientes";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ErrorProvider erpProvider;
		private System.Windows.Forms.ToolTip tlpDicas;
	}
}