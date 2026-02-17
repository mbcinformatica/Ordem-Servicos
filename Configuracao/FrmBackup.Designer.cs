namespace OrdemServicos
{
	partial class frmBackup
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
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.customProgressBar1 = new CustomProgressBar.CustomProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // customProgressBar1
            // 
            this.customProgressBar1.Location = new System.Drawing.Point(12, 23);
            this.customProgressBar1.Name = "customProgressBar1";
            this.customProgressBar1.Size = new System.Drawing.Size(511, 79);
            this.customProgressBar1.TabIndex = 2;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 79);
            this.Controls.Add(this.customProgressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.Text = "Backup";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip tlpDicas;
		private System.Windows.Forms.ErrorProvider erpProvider;
		private CustomProgressBar.CustomProgressBar customProgressBar1;
	}
}