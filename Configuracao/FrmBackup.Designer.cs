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
            this.pbcProgressoBar = new ProgressBarCustom.ProgressBarCustom();
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // pbcProgressoBar
            // 
            this.pbcProgressoBar.AutoCenter = false;
            this.pbcProgressoBar.DisplayText = "Aguarde Realizando Backup...";
            this.pbcProgressoBar.Location = new System.Drawing.Point(1, 2);
            this.pbcProgressoBar.Name = "pbcProgressoBar";
            this.pbcProgressoBar.Size = new System.Drawing.Size(681, 91);
            this.pbcProgressoBar.TabIndex = 0;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 97);
            this.ControlBox = false;
            this.Controls.Add(this.pbcProgressoBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip tlpDicas;
		private System.Windows.Forms.ErrorProvider erpProvider;
		private ProgressBarCustom.ProgressBarCustom pbcProgressoBar;
	}
}