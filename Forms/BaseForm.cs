using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace OrdemServicos.Forms
{
    public partial class BaseForm : Form, BaseFormFuncoes
    {
        // 🎨 Estilo visual - Gradientes e cores
        protected Color gradientStartColor { get; set; }
        protected Color gradientEndColor { get; set; }
        protected Color menuStripBackgroundColor { get; set; }
        protected Color gradientMenuEndColor { get; set; }
        protected Color menuStripFontColor { get; set; }

        // 📝 TextBox
        protected Color textBoxBackgroundColor { get; set; }
        protected Color textBoxFontColor { get; set; }
        protected BorderStyle textBoxBorderStyle { get; set; }
        protected string textBoxFontFamily { get; set; }
        protected float textBoxFontSize { get; set; }
        protected FontStyle textBoxFontStyle { get; set; }
        protected int textBoxMarginLeft { get; set; }
        protected int textBoxMarginTop { get; set; }
        protected int textBoxMarginRight { get; set; }
        protected int textBoxMarginBottom { get; set; }

        // 🔘 Button
        public Color buttonBackgroundColor { get; set; }
        public Color buttonFontColor { get; set; }
        protected bool buttonAutoSize { get; set; }
        protected Color buttonBorderColor { get; set; }
        protected Color buttonMouseDownBackColor { get; set; }
        protected Color buttonMouseOverBackColor { get; set; }
        protected string buttonFontFamily { get; set; }
        protected float buttonFontSize { get; set; }
        protected FontStyle buttonFontStyle { get; set; }

        // 🏷️ Label
        protected Color labelBackgroundColor { get; set; }
        protected Color labelFontColor { get; set; }
        protected bool labelAutoSize { get; set; }
        protected string labelFontFamily { get; set; }
        protected float labelFontSize { get; set; }
        protected FontStyle labelFontStyle { get; set; }
        protected int labelMarginLeft { get; set; }
        protected int labelMarginTop { get; set; }
        protected int labelMarginRight { get; set; }
        protected int labelMarginBottom { get; set; }

        // 📦 Panel
        protected Color panelBackgroundColor { get; set; }

        // ⚙️ Estado e controle de formulário
        public DateTime dataEmissaoControl { get; set; }
        public bool escPressed { get; set; }
        public bool bNovo { get; set; }
        public bool CampoObrigatorio { get; set; }
        public Control ControleAnterior { get; set; }
        public string TagFormato { get; set; }
        public string TagAction { get; set; }
        public int TagMaxDigito { get; set; }
        public static string UsuarioLogado { get; set; }

        // 📌 Métodos virtuais
        public virtual void CarregarRegistros() { }
        public virtual void LimparCampos() { }
        public virtual void ExecutaFuncaoEvento(Control control) { }

        // 🖱️ ToolTip para ListView
        public ToolTip tlpListViewCelula = new ToolTip();
        public string ultimoTextoTooltip = "";

        protected void LoadConfig() 
        {
            CarregaDadosControles("config.xml");
        }
        protected void ApplyConfigToControls(Control.ControlCollection controls, XDocument config)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = textBoxBackgroundColor;
                    textBox.ForeColor = textBoxFontColor;
                    textBox.BorderStyle = textBoxBorderStyle;
                    textBox.Margin = new Padding(textBoxMarginLeft, textBoxMarginTop, textBoxMarginRight, textBoxMarginBottom);

                    // Verificar se a tag do formulário é diferente de "naoAplicar"
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        textBox.Font = new Font(textBoxFontFamily, textBoxFontSize, textBoxFontStyle);
                    }
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.BackColor = textBoxBackgroundColor;
                    maskedTextBox.ForeColor = textBoxFontColor;
                    maskedTextBox.BorderStyle = textBoxBorderStyle;

                    // Verificar se a tag do formulário é diferente de "naoAplicar"
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        maskedTextBox.Font = new Font(textBoxFontFamily, textBoxFontSize, textBoxFontStyle);
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = textBoxBackgroundColor;
                    comboBox.ForeColor = textBoxFontColor;

                    // Verificar se a tag do formulário é diferente de "naoAplicar"
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        comboBox.Font = new Font(textBoxFontFamily, textBoxFontSize, textBoxFontStyle);
                    }
                }
                else if (control is Label label)
                {
                    string tag = label.Tag?.ToString();
                    label.BackColor = labelBackgroundColor;

                    // Verificar se a tag do formulário é diferente de "naoAplicar"
                    if (tag != "naoAplicar"  && tag != "naoAplicarSize")
                    {
                        label.ForeColor = labelFontColor;
                        label.Margin = new Padding(labelMarginLeft, labelMarginTop, labelMarginRight, labelMarginBottom);
                        label.Font = new Font(labelFontFamily, labelFontSize, labelFontStyle);
                        label.AutoSize = labelAutoSize;
                    }
                    // Verificar se a tag do controle Label é "naoAplicar"
                    else if (tag == "naoAplicarAutoSize")
                    {
                        label.AutoSize = false;
                    }
                }
                else if (control is Button button)
                {
                    button.BackColor = buttonBackgroundColor;
                    button.ForeColor = buttonFontColor;
                    button.Cursor = Cursors.Hand;

                    // Verificar se a tag do formulário é diferente de "naoAplicar"
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        button.Font = new Font(buttonFontFamily, buttonFontSize, buttonFontStyle);
                    }
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = panelBackgroundColor;
                    // Aplicar configurações aos controles dentro do Panel
                    ApplyConfigToControls(panel.Controls, config);
                }
                else if (control is TabControl tabControl)
                {
                    foreach (TabPage tabPage in tabControl.TabPages)
                    {
                        ApplyConfigToControls(tabPage.Controls, config);
                    }
                }
                else if (control is MenuStrip menuStrip)
                {
                    menuStrip.Renderer = new GradientMenuRenderer(this);
                    menuStrip.ForeColor = menuStripFontColor;
                }
                else if (control is ListView listView)
                {
  //                  tlpListViewCelula.InitialDelay = 100;     // Aparece quase instantaneamente
  //                  tlpListViewCelula.ReshowDelay = 50;       // Reaparece rapidamente ao mover o mouse
  //                  tlpListViewCelula.AutoPopDelay = 3000;    // Some após 3s
                    tlpListViewCelula.ShowAlways = true;
                    tlpListViewCelula.OwnerDraw = true;
                    tlpListViewCelula.Draw += tlpListViewCelula_Draw;
                }
            }
        }
        protected void BaseForm_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control control = sender as Control;
                if (control != null)
                {
                    Debug.WriteLine($"BaseForm_Paint called by {control.Name}");
                }

                // Usar as variáveis gradientStartColor e gradientEndColor carregadas anteriormente
                using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, gradientStartColor, gradientEndColor, 70F))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar o gradiente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void InitializeTabControl(TabControl tabControl)
        {
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
            tabControl.SizeMode = TabSizeMode.FillToRight;
            tabControl.Alignment = TabAlignment.Top;

            // Aplicar cor degradê nas TabPages
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.Paint += new PaintEventHandler(TabPage_Paint);
                tabPage.BackColor = Color.Transparent;
            }
        }
        protected void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = ((TabControl)sender).TabPages[e.Index];
            Rectangle tabRect = ((TabControl)sender).GetTabRect(e.Index);

            // Defina a cor sólida para a aba ativa
            Color activeTabBackColor = Color.SteelBlue;
            Color activeTabForeColor = Color.White;

            if (e.Index == ((TabControl)sender).SelectedIndex)
            {
                // Desenhar a aba ativa com cor sólida
                using (SolidBrush brush = new SolidBrush(activeTabBackColor))
                {
                    e.Graphics.FillRectangle(brush, tabRect);
                }
                // Desenhar o texto da aba ativa com cor branca
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, activeTabForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                // Desenhar abas inativas com gradiente
                using (LinearGradientBrush brush = new LinearGradientBrush(tabRect, gradientStartColor, gradientEndColor, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, tabRect);
                }
                // Desenhar o texto das abas inativas com a cor padrão
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
        protected void tlpListViewCelula_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Fundo personalizado
            using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(198, 242, 242))) // fundo escuro
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(0, 0, 0))) // texto branco
            using (Pen borderPen = new Pen(Color.SteelBlue)) // borda azul
            {
                // Desenhar fundo
                e.Graphics.FillRectangle(backBrush, e.Bounds);

                // Desenhar borda
                e.Graphics.DrawRectangle(borderPen, e.Bounds);

                // Desenhar texto com fonte personalizada
                Font fonte = new Font("Times New Roman", 10, FontStyle.Bold);
                e.Graphics.DrawString(e.ToolTipText, fonte, textBrush, e.Bounds);
            }
        }
        protected void TabPage_Paint(object sender, PaintEventArgs e)
        {
            TabPage tabPage = sender as TabPage;
            Rectangle tabRect = tabPage.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(tabRect, gradientStartColor, gradientEndColor, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }
        }
        private class GradientMenuRenderer : ToolStripProfessionalRenderer
        {
            private BaseForm baseForm;
            public GradientMenuRenderer(BaseForm form)
            {
                baseForm = form;
            }
        }
        protected void ValidarControle(object sender, System.ComponentModel.CancelEventArgs e, string campo, ErrorProvider errorProvider)
        {
            if (!escPressed)
            {
                if (sender is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(textBox, $"{campo} é obrigatório.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(textBox, string.Empty);
                    }
                }
                else if (sender is MaskedTextBox maskedTextBox)
                {
                    if (string.IsNullOrWhiteSpace(maskedTextBox.Text.Replace(maskedTextBox.PromptChar.ToString(), "").Trim()))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(maskedTextBox, $"{campo} é obrigatório.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(maskedTextBox, string.Empty);
                    }
                }
                else if (sender is RadioButton radioButton)
                {
                    if (!radioButton.Checked)
                    {
                        e.Cancel = true;
                        errorProvider.SetError(radioButton, $"{campo} é obrigatório.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(radioButton, string.Empty);
                    }
                }
                else if (sender is DateTimePicker dateTimePicker)
                {
                    if (string.IsNullOrWhiteSpace(dateTimePicker.Text))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(dateTimePicker, $"{campo} é obrigatório.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(dateTimePicker, string.Empty);
                    }
                }
                else if (sender is ComboBox comboBox)
                {
                    if (string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        e.Cancel = true;
                        errorProvider.SetError(comboBox, $"{campo} é obrigatório.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(comboBox, string.Empty);
                    }
                }
                if (e.Cancel)
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        protected void AdicionarValidacao(ErrorProvider errorProvider, params (Control, string)[] controlCampos)
        {
            foreach (var (control, campo) in controlCampos)
            {
                control.Validating += (sender, e) => ValidarControle(sender, e, campo, errorProvider);
            }
        }
        protected bool ValidarCamposObrigatorios((Control, string)[] camposObrigatorios, ErrorProvider errorProvider)
        {
            foreach (var (control, campo) in camposObrigatorios)
            {
                var args = new System.ComponentModel.CancelEventArgs();
                ValidarControle(control, args, campo, errorProvider);
                if (args.Cancel)
                {
                    control.Focus();
                    return false;
                }
            }

            return true;
        }
        protected bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        protected bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        protected void CarregaDadosControles(string fileName)
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XML", fileName);
                XDocument config = XDocument.Load(configPath);

                gradientStartColor = ConvertHexToColor(config.Root.Element("GradientStartColor").Value);
                gradientEndColor = ConvertHexToColor(config.Root.Element("GradientEndColor").Value);

                menuStripBackgroundColor = ConvertHexToColor(config.Root.Element("MenuStripBackgroundColor").Value);
                gradientMenuEndColor = ConvertHexToColor(config.Root.Element("GradientMenuEndColor").Value);
                menuStripFontColor = ConvertHexToColor(config.Root.Element("MenuStripFontColor").Value);

                textBoxBackgroundColor = ConvertHexToColor(config.Root.Element("TextBoxBackgroundColor").Value);
                textBoxFontColor = ConvertHexToColor(config.Root.Element("TextBoxFontColor").Value);
                textBoxBorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), config.Root.Element("TextBoxBorderStyle").Value);
                textBoxFontFamily = config.Root.Element("TextBoxFontFamily").Value;
                textBoxFontSize = float.Parse(config.Root.Element("TextBoxFontSize").Value);
                textBoxFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("TextBoxFontStyle").Value);
                textBoxMarginLeft = int.Parse(config.Root.Element("TextBoxMarginLeft").Value);
                textBoxMarginTop = int.Parse(config.Root.Element("TextBoxMarginTop").Value);
                textBoxMarginRight = int.Parse(config.Root.Element("TextBoxMarginRight").Value);
                textBoxMarginBottom = int.Parse(config.Root.Element("TextBoxMarginBottom").Value);

                buttonBackgroundColor = ConvertHexToColor(config.Root.Element("ButtonBackgroundColor").Value);
                buttonFontColor = ConvertHexToColor(config.Root.Element("ButtonFontColor").Value);
                buttonAutoSize = bool.Parse(config.Root.Element("ButtonAutoSize").Value);
                buttonBorderColor = ConvertHexToColor(config.Root.Element("ButtonAppearance").Element("BorderColor").Value);
                buttonMouseDownBackColor = ConvertHexToColor(config.Root.Element("ButtonAppearance").Element("MouseDownBackColor").Value);
                buttonMouseOverBackColor = ConvertHexToColor(config.Root.Element("ButtonAppearance").Element("MouseOverBackColor").Value);
                // buttonCursor = (Cursors)Enum.Parse(typeof(Cursor), config.Root.Element("ButtonCursor").Value);
                buttonFontFamily = config.Root.Element("ButtonFontFamily").Value;
                buttonFontSize = float.Parse(config.Root.Element("ButtonFontSize").Value);
                buttonFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("ButtonFontStyle").Value);

                labelBackgroundColor = ConvertHexToColor(config.Root.Element("LabelBackgroundColor").Value);
                labelFontColor = ConvertHexToColor(config.Root.Element("LabelFontColor").Value);
                labelAutoSize = bool.Parse(config.Root.Element("LabelAutoSize").Value);
                labelFontFamily = config.Root.Element("LabelFontFamily").Value;
                labelFontSize = float.Parse(config.Root.Element("LabelFontSize").Value);
                labelFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("LabelFontStyle").Value);
                labelMarginLeft = int.Parse(config.Root.Element("LabelMarginLeft").Value);
                labelMarginTop = int.Parse(config.Root.Element("LabelMarginTop").Value);
                labelMarginRight = int.Parse(config.Root.Element("LabelMarginRight").Value);
                labelMarginBottom = int.Parse(config.Root.Element("LabelMarginBottom").Value);

                panelBackgroundColor = ConvertHexToColor(config.Root.Element("PanelBackgroundColor").Value);
                ApplyConfigToControls(Controls, config);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o arquivo de configuração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected Color ConvertHexToColor(string hex)
        {
            // Remove any leading '#' characters
            hex = hex.Replace("#", "");

            // Ensure the hex string is valid
            if (hex.Length == 6 || hex.Length == 8)
            {
                int argb = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                return Color.FromArgb(argb);
            }
            else
            {
                throw new ArgumentException("Invalid hex color format");
            }
        }
        protected byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (Image resizedImage = ResizeImage(image, 136, 160))
            using (var ms = new MemoryStream())
            {
                // Tenta localizar um encoder correspondente ao RawFormat
                ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders()
                    .FirstOrDefault(c => c.FormatID == image.RawFormat.Guid);

                if (codec != null)
                {
                    // Exemplo: definir qualidade para JPEG (opcional)
                    if (codec.FormatID == ImageFormat.Jpeg.Guid)
                    {
                        var encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
                        resizedImage.Save(ms, codec, encoderParams);
                    }
                    else
                    {
                        // Usa encoder encontrado
                        resizedImage.Save(ms, codec, null);
                    }
                }
                else
                {
                    // Fallback seguro para PNG (sempre disponível)
                    resizedImage.Save(ms, ImageFormat.Png);
                }

                return ms.ToArray();
            }
        }
        protected Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        protected void ajustaLarguraCabecalho(ListView listView)
        {
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                int larguraConteudo = listView.Columns[i].Width + 20;

                listView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                int larguraCabecalho = listView.Columns[i].Width + 20;

                listView.Columns[i].Width  = Math.Max(larguraConteudo, larguraCabecalho);
            }

            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }
        public static void RegistrarErroLog(string mensagem)
        {
            try
            {
                string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "CnpjErros.txt");
                using (StreamWriter logWriter = new StreamWriter(logPath, true))
                {
                    string logEntry = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagem}";
                    logWriter.WriteLine(logEntry);
                }
            }
            catch
            {
                // Se falhar ao registrar o log, não interrompe o fluxo
            }
        }
    }
}
