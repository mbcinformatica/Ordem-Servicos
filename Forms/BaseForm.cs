using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OrdemServicos.Forms
{
    public partial class BaseForm : Form, BaseFormFuncoes
    {
        // 🎨 Estilo visual - Gradientes e cores
        protected Color gradientStartColor { get; set; }
        protected Color gradientEndColor { get; set; }

        // 📝 Formulário
        protected Color formBackgroundColor { get; set; }
        protected string formFontFamily { get; set; }
        protected float formFontSize { get; set; }
        protected FontStyle formFontStyle { get; set; }

        // 📝 TextBox
        protected Color textBoxBackgroundColor { get; set; }
        protected Color textBoxFontColor { get; set; }
        protected BorderStyle textBoxBorderStyle { get; set; }
        protected string textBoxFontFamily { get; set; }
        protected float textBoxFontSize { get; set; }
        protected FontStyle textBoxFontStyle { get; set; }

        // 🔢 MaskedTextBox
        protected Color maskedTextBoxBackgroundColor { get; set; }
        protected Color maskedTextBoxFontColor { get; set; }
        protected BorderStyle maskedTextBoxBorderStyle { get; set; }
        protected string maskedTextBoxFontFamily { get; set; }
        protected float maskedTextBoxFontSize { get; set; }
        protected FontStyle maskedTextBoxFontStyle { get; set; }

        // 🔘 Button
        public Color buttonBackgroundColor { get; set; }
        public Color buttonFontColor { get; set; }
        protected Color buttonBorderColor { get; set; }
        protected Color buttonMouseDownBackColor { get; set; }
        protected Color buttonMouseOverBackColor { get; set; }
        protected string buttonFontFamily { get; set; }
        protected float buttonFontSize { get; set; }
        protected FontStyle buttonFontStyle { get; set; }
        protected bool buttonAutoSize { get; set; }

        // 🏷️ Label
        protected Color labelBackgroundColor { get; set; }
        protected Color labelFontColor { get; set; }
        protected bool labelAutoSize { get; set; }
        protected string labelFontFamily { get; set; }
        protected float labelFontSize { get; set; }
        protected FontStyle labelFontStyle { get; set; }

        // 🔗 LinkLabel
        protected Color linkLabelBackgroundColor { get; set; }
        protected Color linkLabelActiveLinkColor { get; set; }
        protected Color linkLabelLinkColor { get; set; }
        protected Color linkLabelVisitedLinkColor { get; set; }
        protected string linkLabelFontFamily { get; set; }
        protected float linkLabelFontSize { get; set; }
        protected FontStyle linkLabelFontStyle { get; set; }

        // 📦 Panel
        protected Color panelBackgroundColor { get; set; }
        protected BorderStyle panelBorderStyle { get; set; }
        protected string panelFontFamily { get; set; }
        protected float panelFontSize { get; set; }
        protected FontStyle panelFontStyle { get; set; }

        // 📋 ListView
        protected Color listViewBackColor { get; set; }
        protected Color listViewForeColor { get; set; }
        protected bool listViewFullRowSelect { get; set; }
        protected bool listViewGridLines { get; set; }
        protected bool listViewHideSelection { get; set; }
        protected string listViewFontFamily { get; set; }
        protected float listViewFontSize { get; set; }
        protected FontStyle listViewFontStyle { get; set; }

        // 🔽 ComboBox
        protected Color comboBoxBackColor { get; set; }
        protected Color comboBoxForeColor { get; set; }
        protected ComboBoxStyle comboBoxDropDownStyle { get; set; }
        protected string comboBoxFontFamily { get; set; }
        protected float comboBoxFontSize { get; set; }
        protected FontStyle comboBoxFontStyle { get; set; }

        // 📑 ToolStripMenuItem
        protected Color toolStripMenuItemBackColor { get; set; }
        protected Color toolStripMenuItemForeColor { get; set; }
        protected string toolStripMenuItemFontFamily { get; set; }
        protected float toolStripMenuItemFontSize { get; set; }
        protected FontStyle toolStripMenuItemFontStyle { get; set; }

        //  MenuStrip
        protected Color menuStripBackgroundColor { get; set; }
        protected Color gradientMenuStartColor { get; set; }
        protected Color gradientMenuEndColor { get; set; }
        protected string menuStripFontFamily { get; set; }
        protected float menuStripFontSize { get; set; }
        protected FontStyle menuStripFontStyle { get; set; }

        // 📂 TabControl
        protected string tabControlFontFamily { get; set; }
        protected float tabControlFontSize { get; set; }
        protected FontStyle tabControlFontStyle { get; set; }

        // 📂 TabPage
        protected Color tabPageBackColor { get; set; }
        protected Color tabPageForeColor { get; set; }
        protected BorderStyle tabPageBorderStyle { get; set; }
        protected string tabPageFontFamily { get; set; }
        protected float tabPageFontSize { get; set; }
        protected FontStyle tabPageFontStyle { get; set; }

        // 📊 ProgressBar
        protected Color progressBarBackColor { get; set; }
        protected Color progressBarForeColor { get; set; }
        protected ProgressBarStyle progressBarStyle { get; set; }

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
        public virtual async Task CarregarRegistros() { }
        public virtual void LimparCampos() { }
        public virtual void ExecutaFuncaoEventoAsync(Control control) { }

        // 🖱️ ToolTip para ListView
        public ToolTip tlpListViewCelula = new ToolTip();
        public string ultimoTextoTooltip = "";

        private static string temaAtual = "config.xml";
        private static bool configCarregada = false;
        private static XDocument configGlobal;

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

                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        textBox.Font = new Font(textBoxFontFamily, textBoxFontSize, textBoxFontStyle);
                    }
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    maskedTextBox.BackColor = maskedTextBoxBackgroundColor;
                    maskedTextBox.ForeColor = maskedTextBoxFontColor;
                    maskedTextBox.BorderStyle = maskedTextBoxBorderStyle;

                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        maskedTextBox.Font = new Font(maskedTextBoxFontFamily, maskedTextBoxFontSize, maskedTextBoxFontStyle);
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = comboBoxBackColor;
                    comboBox.ForeColor = comboBoxForeColor;
                    comboBox.DropDownStyle = comboBoxDropDownStyle;

                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        comboBox.Font = new Font(comboBoxFontFamily, comboBoxFontSize, comboBoxFontStyle);
                    }
                }
                else if (control is Label label)
                {
                    string tag = label.Tag?.ToString();
                    label.BackColor = labelBackgroundColor;

                    if (tag != "naoAplicar" && tag != "naoAplicarSize")
                    {
                        label.ForeColor = labelFontColor;
                        label.Font = new Font(labelFontFamily, labelFontSize, labelFontStyle);
                        label.AutoSize = labelAutoSize;
                    }
                    else if (tag == "naoAplicarAutoSize")
                    {
                        label.AutoSize = false;
                    }
                }
                else if (control is LinkLabel linkLabel)
                {
                    linkLabel.ActiveLinkColor = linkLabelActiveLinkColor;
                    linkLabel.LinkColor = linkLabelLinkColor;
                    linkLabel.VisitedLinkColor = linkLabelVisitedLinkColor;
                    linkLabel.BackColor = linkLabelBackgroundColor;
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        linkLabel.Font = new Font(linkLabelFontFamily, linkLabelFontSize, linkLabelFontStyle);
                    }
                }
                else if (control is Button button)
                {
                    button.BackColor = buttonBackgroundColor;
                    button.ForeColor = buttonFontColor;
                    button.AutoSize = buttonAutoSize;
                    // Fonte do botão
                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        button.Font = new Font(buttonFontFamily, buttonFontSize, buttonFontStyle);
                    }
                    // Configura aparência Flat para aplicar cores de interação
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = buttonBorderColor;
                    button.FlatAppearance.MouseOverBackColor = buttonMouseOverBackColor;
                    button.FlatAppearance.MouseDownBackColor = buttonMouseDownBackColor;
                }

                else if (control is Panel panel)
                {
                    panel.BackColor = panelBackgroundColor;
                    panel.BorderStyle = panelBorderStyle;

                    if (control.FindForm()?.Tag?.ToString() != "naoAplicar")
                    {
                        panel.Font = new Font(panelFontFamily, panelFontSize, panelFontStyle);
                    }

                    ApplyConfigToControls(panel.Controls, config);
                }
                else if (control is TabControl tabControl)
                {
                    // aplica fonte no TabControl
                    tabControl.Font = new Font(tabControlFontFamily, tabControlFontSize, tabControlFontStyle);

                    foreach (TabPage tabPage in tabControl.TabPages)
                    {
                        // aplica estilo em cada TabPage
                        tabPage.BackColor = tabPageBackColor;
                        tabPage.ForeColor = tabPageForeColor;
                        tabPage.BorderStyle = tabPageBorderStyle;
                        tabPage.Font = new Font(tabPageFontFamily, tabPageFontSize, tabPageFontStyle);

                        // aplica configuração nos controles internos da TabPage
                        ApplyConfigToControls(tabPage.Controls, config);
                    }
                }

                else if (control is MenuStrip menuStrip)
                {
                    // Renderer com degradê
                    menuStrip.Renderer = new GradientMenuRenderer(this);

                    // Aplica estilo no MenuStrip
                    menuStrip.BackColor = menuStripBackgroundColor;
                    menuStrip.Font = new Font(menuStripFontFamily, menuStripFontSize, menuStripFontStyle);

                    // Aplica estilo nos itens e subitens
                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        if (item is ToolStripMenuItem menuItem)
                        {
                            menuItem.BackColor = toolStripMenuItemBackColor;
                            menuItem.ForeColor = toolStripMenuItemForeColor;
                            menuItem.Font = new Font(toolStripMenuItemFontFamily, toolStripMenuItemFontSize, toolStripMenuItemFontStyle);

                            // Subitens
                            foreach (ToolStripItem subItem in menuItem.DropDownItems)
                            {
                                if (subItem is ToolStripMenuItem subMenuItem)
                                {
                                    subMenuItem.BackColor = toolStripMenuItemBackColor;
                                    subMenuItem.ForeColor = toolStripMenuItemForeColor;
                                    subMenuItem.Font = new Font(toolStripMenuItemFontFamily, toolStripMenuItemFontSize, toolStripMenuItemFontStyle);

                                    // Sub-subitens
                                    foreach (ToolStripItem subSubItem in subMenuItem.DropDownItems)
                                    {
                                        if (subSubItem is ToolStripMenuItem subSubMenuItem)
                                        {
                                            subSubMenuItem.BackColor = toolStripMenuItemBackColor;
                                            subSubMenuItem.ForeColor = toolStripMenuItemForeColor;
                                            subSubMenuItem.Font = new Font(toolStripMenuItemFontFamily, toolStripMenuItemFontSize, toolStripMenuItemFontStyle);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (control is ListView listView)
                {
                    listView.BackColor = listViewBackColor;
                    listView.ForeColor = listViewForeColor;
                    listView.FullRowSelect = listViewFullRowSelect;
                    listView.GridLines = listViewGridLines;
                    listView.HideSelection = listViewHideSelection;
                    listView.Font = new Font(listViewFontFamily, listViewFontSize, listViewFontStyle);

                    // Exemplo de tooltip customizado
                    tlpListViewCelula.ShowAlways = true;
                    tlpListViewCelula.OwnerDraw = true;
                    tlpListViewCelula.Draw += tlpListViewCelula_Draw;
                }
                else if (control is ProgressBar progressBar)
                {
                    progressBar.BackColor = progressBarBackColor;
                    progressBar.ForeColor = progressBarForeColor;
                    progressBar.Style = progressBarStyle;
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
            private readonly BaseForm baseForm;

            public GradientMenuRenderer(BaseForm form)
            {
                baseForm = form;
            }

            // Fundo do MenuStrip
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    e.AffectedBounds,
                    baseForm.gradientMenuStartColor,
                    baseForm.gradientMenuEndColor,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }

            // Fundo dos itens do MenuStrip com efeito hover
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

                Color startColor;
                Color endColor;

                if (e.Item.Selected || e.Item.Pressed)
                {
                    // Efeito hover: usa cores de destaque
                    startColor = baseForm.buttonMouseOverBackColor;
                    endColor = baseForm.buttonMouseDownBackColor;
                }
                else
                {
                    // Normal: mesmo degradê do MenuStrip
                    startColor = baseForm.gradientMenuStartColor;
                    endColor = baseForm.gradientMenuEndColor;
                }

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    startColor,
                    endColor,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
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

                //  Gradiente
                gradientStartColor = ConvertHexToColor(config.Root.Element("GradientStartColor").Value);
                gradientEndColor = ConvertHexToColor(config.Root.Element("GradientEndColor").Value);

                // Form
                formBackgroundColor = ConvertHexToColor(config.Root.Element("FormBackgroundColor").Value);
                formFontFamily = config.Root.Element("FormFontFamily").Value;
                formFontSize = float.Parse(config.Root.Element("FormFontSize").Value);
                formFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("FormFontStyle").Value);

                // MenuStrip
                menuStripBackgroundColor = ConvertHexToColor(config.Root.Element("MenuStripBackgroundColor").Value);
                gradientMenuStartColor = ConvertHexToColor(config.Root.Element("GradientMenuStartColor").Value);
                gradientMenuEndColor = ConvertHexToColor(config.Root.Element("GradientMenuEndColor").Value);
                menuStripFontFamily = config.Root.Element("MenuStripFontFamily").Value;
                menuStripFontSize = float.Parse(config.Root.Element("MenuStripFontSize").Value);
                menuStripFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("MenuStripFontStyle").Value);

                // TextBox
                textBoxBackgroundColor = ConvertHexToColor(config.Root.Element("TextBoxBackgroundColor").Value);
                textBoxFontColor = ConvertHexToColor(config.Root.Element("TextBoxFontColor").Value);
                textBoxBorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), config.Root.Element("TextBoxBorderStyle").Value);
                textBoxFontFamily = config.Root.Element("TextBoxFontFamily").Value;
                textBoxFontSize = float.Parse(config.Root.Element("TextBoxFontSize").Value);
                textBoxFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("TextBoxFontStyle").Value);
   
                // MaskedTextBox
                maskedTextBoxBackgroundColor = ConvertHexToColor(config.Root.Element("MaskedTextBoxBackgroundColor").Value);
                maskedTextBoxFontColor = ConvertHexToColor(config.Root.Element("MaskedTextBoxFontColor").Value);
                maskedTextBoxBorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), config.Root.Element("MaskedTextBoxBorderStyle").Value);
                maskedTextBoxFontFamily = config.Root.Element("MaskedTextBoxFontFamily").Value;
                maskedTextBoxFontSize = float.Parse(config.Root.Element("MaskedTextBoxFontSize").Value);
                maskedTextBoxFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("MaskedTextBoxFontStyle").Value);

                // Botão
                buttonBackgroundColor = ConvertHexToColor(config.Root.Element("ButtonBackgroundColor").Value);
                buttonFontColor = ConvertHexToColor(config.Root.Element("ButtonFontColor").Value);
                buttonAutoSize = bool.Parse(config.Root.Element("ButtonAutoSize").Value);
                var buttonAppearance = config.Root.Element("ButtonAppearance");
                if (buttonAppearance != null)
                {
                    buttonBorderColor = ConvertHexToColor(buttonAppearance.Element("BorderColor").Value);
                    buttonMouseDownBackColor = ConvertHexToColor(buttonAppearance.Element("MouseDownBackColor").Value);
                    buttonMouseOverBackColor = ConvertHexToColor(buttonAppearance.Element("MouseOverBackColor").Value);
                }
                buttonFontFamily = config.Root.Element("ButtonFontFamily").Value;
                buttonFontSize = float.Parse(config.Root.Element("ButtonFontSize").Value);
                buttonFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("ButtonFontStyle").Value);

                // Label
                labelBackgroundColor = ConvertHexToColor(config.Root.Element("LabelBackgroundColor").Value);
                labelFontColor = ConvertHexToColor(config.Root.Element("LabelFontColor").Value);
                labelAutoSize = bool.Parse(config.Root.Element("LabelAutoSize").Value);
                labelFontFamily = config.Root.Element("LabelFontFamily").Value;
                labelFontSize = float.Parse(config.Root.Element("LabelFontSize").Value);
                labelFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("LabelFontStyle").Value);
      
                // LinkLabel
                linkLabelBackgroundColor = ConvertHexToColor(config.Root.Element("LinkLabelBackgroundColor").Value);
                linkLabelActiveLinkColor = ConvertHexToColor(config.Root.Element("LinkLabelActiveLinkColor").Value);
                linkLabelLinkColor = ConvertHexToColor(config.Root.Element("LinkLabelLinkColor").Value);
                linkLabelVisitedLinkColor = ConvertHexToColor(config.Root.Element("LinkLabelVisitedLinkColor").Value);
                linkLabelFontFamily = config.Root.Element("LinkLabelFontFamily").Value;
                linkLabelFontSize = float.Parse(config.Root.Element("LinkLabelFontSize").Value);
                linkLabelFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("LinkLabelFontStyle").Value);

                // Panel
                panelBackgroundColor = ConvertHexToColor(config.Root.Element("PanelBackgroundColor").Value);
                panelBorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), config.Root.Element("PanelBorderStyle").Value);
                panelFontFamily = config.Root.Element("PanelFontFamily").Value;
                panelFontSize = float.Parse(config.Root.Element("PanelFontSize").Value);
                panelFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("PanelFontStyle").Value);

                // ListView
                listViewBackColor = ConvertHexToColor(config.Root.Element("ListViewBackColor").Value);
                listViewForeColor = ConvertHexToColor(config.Root.Element("ListViewForeColor").Value);
                listViewFullRowSelect = bool.Parse(config.Root.Element("ListViewFullRowSelect").Value);
                listViewGridLines = bool.Parse(config.Root.Element("ListViewGridLines").Value);
                listViewHideSelection = bool.Parse(config.Root.Element("ListViewHideSelection").Value);
                listViewFontFamily = config.Root.Element("ListViewFontFamily").Value;
                listViewFontSize = float.Parse(config.Root.Element("ListViewFontSize").Value);
                listViewFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("ListViewFontStyle").Value);

                // ComboBox
                comboBoxBackColor = ConvertHexToColor(config.Root.Element("ComboBoxBackColor").Value);
                comboBoxForeColor = ConvertHexToColor(config.Root.Element("ComboBoxForeColor").Value);
                var dropDownStr = config.Root.Element("ComboBoxDropDownStyle")?.Value ?? "DropDown";
                if (!Enum.TryParse(dropDownStr, true, out ComboBoxStyle parsedStyle))
                    parsedStyle = ComboBoxStyle.DropDown;
                comboBoxDropDownStyle = parsedStyle;
                comboBoxFontFamily = config.Root.Element("ComboBoxFontFamily").Value;
                comboBoxFontSize = float.Parse(config.Root.Element("ComboBoxFontSize").Value);
                comboBoxFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("ComboBoxFontStyle").Value);
     
                // ToolStripMenuItem
                toolStripMenuItemBackColor = ConvertHexToColor(config.Root.Element("ToolStripMenuItemBackColor").Value);
                toolStripMenuItemForeColor = ConvertHexToColor(config.Root.Element("ToolStripMenuItemForeColor").Value);
                toolStripMenuItemFontFamily = config.Root.Element("ToolStripMenuItemFontFamily").Value;
                toolStripMenuItemFontSize = float.Parse(config.Root.Element("ToolStripMenuItemFontSize").Value);
                toolStripMenuItemFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("ToolStripMenuItemFontStyle").Value);

                // TabControl
                tabControlFontFamily = config.Root.Element("TabControlFontFamily").Value;
                tabControlFontSize = float.Parse(config.Root.Element("TabControlFontSize").Value);
                tabControlFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("TabControlFontStyle").Value);


                // TabPage
                tabPageBackColor = ConvertHexToColor(config.Root.Element("TabPageBackColor").Value);
                tabPageForeColor = ConvertHexToColor(config.Root.Element("TabPageForeColor").Value);
                tabPageBorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), config.Root.Element("TabPageBorderStyle").Value);
                tabPageFontFamily = config.Root.Element("TabPageFontFamily").Value;
                tabPageFontSize = float.Parse(config.Root.Element("TabPageFontSize").Value);
                tabPageFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config.Root.Element("TabPageFontStyle").Value);

                // ProgressBar
                progressBarBackColor = ConvertHexToColor(config.Root.Element("ProgressBarBackColor").Value);
                progressBarForeColor = ConvertHexToColor(config.Root.Element("ProgressBarForeColor").Value);
                progressBarStyle = (ProgressBarStyle)Enum.Parse(typeof(ProgressBarStyle), config.Root.Element("ProgressBarStyle").Value);

                // Aplica nos controles
                ApplyConfigToControls(Controls, config);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o arquivo de configuração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected Color ConvertHexToColor(string hex)
        {
            try
            {
                if (hex.Length == 8)
                {
                    byte a = Convert.ToByte(hex.Substring(0, 2), 16);
                    byte r = Convert.ToByte(hex.Substring(2, 2), 16);
                    byte g = Convert.ToByte(hex.Substring(4, 2), 16);
                    byte b = Convert.ToByte(hex.Substring(6, 2), 16);
                    return Color.FromArgb(a, r, g, b);
                }
                return Color.Black; // fallback
            }
            catch
            {
                return Color.Black; // fallback em caso de erro
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

                listView.Columns[i].Width = Math.Max(larguraConteudo, larguraCabecalho);
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
        protected void ConfigurarComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown; // permite digitação
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.FormattingEnabled = true;
        }
    }
}
