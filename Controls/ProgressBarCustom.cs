using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrdemServicos.Controls
{
    public partial class ProgressBarCustom : ProgressBar
    {
        // Propriedade pública para definir o texto exibido
        public string DisplayText { get; set; } = "";

        // Propriedade para centralizar automaticamente no formulário/container
        private bool _autoCenter = false;
        public bool AutoCenter
        {
            get => _autoCenter;
            set
            {
                _autoCenter = value;
                if (_autoCenter && this.Parent != null)
                {
                    CenterInParent();
                }
            }
        }

        public ProgressBarCustom()
        {
            // Permite que o controle seja redesenhado pelo usuário
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (_autoCenter && this.Parent != null)
            {
                CenterInParent();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_autoCenter && this.Parent != null)
            {
                CenterInParent();
            }
        }

        private void CenterInParent()
        {
            if (this.Parent != null)
            {
                int x = (this.Parent.ClientSize.Width - this.Width); // / 8;
                int y = (this.Parent.ClientSize.Height - this.Height); // / 8;
                this.Location = new Point(x, y);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            // Fundo
            e.Graphics.FillRectangle(Brushes.White, rect);

            // Barra preenchida
            if (this.Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y,
                    (int)(rect.Width * ((double)this.Value / this.Maximum)), rect.Height);
                e.Graphics.FillRectangle(Brushes.Green, clip);
            }

            // Texto centralizado dentro da barra
            double percent = (double)this.Value / this.Maximum * 100;
            string text = $"{DisplayText}\nProgresso: {percent:F2}% ({this.Value}/{this.Maximum})";

            using (Font f = new Font("Times New Roman", 12, FontStyle.Bold))
            {
                SizeF textSize = e.Graphics.MeasureString(text, f);
                float x = (rect.Width - textSize.Width) / 2;
                float y = (rect.Height - textSize.Height) / 2;
                e.Graphics.DrawString(text, f, Brushes.Black, x, y);
            }
        }
    }
}