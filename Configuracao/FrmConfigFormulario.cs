using OrdemServicos.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OrdemServicos
{
    public partial class frmConfigFormulario : BaseForm
    {
        private bool salvaConfigPadrao = false;
        private bool salvaConfigTemaClaro = false;
        private bool salvaConfigTemaEscuro = false;

        public frmConfigFormulario()
        {
            InitializeComponent();

            // ✅ Carrega último tema usado
            LoadConfig();

            Paint += new PaintEventHandler(BaseForm_Paint);
            erpProvider = new ErrorProvider();
            CarregaControlesFormulario();
        }
        private void CarregaControlesFormulario()
        {
            // Exemplo de uso
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosAtual, btnExemploAtual, lblDescricaoAtual, txtExemploAtual);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosAlterado, btnExemploAlterada, lblDescricaoAlterada, txtExemploAlterada);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosConfiguracaoAtual, lbConfiguracaoAtual);
            CentralizarControlesHorizontalmenteNoPanel(pnlExemplosConfiguracaoAlterada, lbConfiguracaoAlterada);

            // Definindo o tamanho e a posição dos Panels
            Size panelSize = new Size(580, 256); // Exemplo de tamanho
            Point panelLocation = new Point(838, 23); // Exemplo de posição

            pnlOpcaoFormulario.Size = panelSize;
            pnlOpcaoFormulario.Location = panelLocation;
            pnlOpcaoFormulario.Visible = false;

            pnlOpcaoCampos.Size = panelSize;
            pnlOpcaoCampos.Location = panelLocation;
            pnlOpcaoCampos.Visible = false;

            pnlOpcaoBotoes.Size = panelSize;
            pnlOpcaoBotoes.Location = panelLocation;
            pnlOpcaoBotoes.Visible = false;

            pnlOpcaoDescricao.Size = panelSize;
            pnlOpcaoDescricao.Location = panelLocation;
            pnlOpcaoDescricao.Visible = false;

            btnExemploAlterada.Visible = false;
            lblDescricaoAlterada.Visible = false;
            txtExemploAlterada.Visible = false;
            mnsStripExemploAlterado.Visible = false;
        }
        private void lnkConfiguracaoCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = true;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = false;
        }
        private void lnkConfiguracaoFormulario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = true;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = false;
        }
        private void lnkConfiguracaoBotoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = true;
            pnlOpcaoDescricao.Visible = false;
        }
        private void lnkConfiguracaoRotuloCampos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlOpcaoFormulario.Visible = false;
            pnlOpcaoCampos.Visible = false;
            pnlOpcaoBotoes.Visible = false;
            pnlOpcaoDescricao.Visible = true;
        }
        private void LnkConfiguracaoTemaClaro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            salvaConfigTemaClaro = true;
            btnSalvarSair_Click(sender, e);
            salvaConfigTemaClaro = false;
        }
        private void LnkConfiguracaoTemaEscuro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            salvaConfigTemaEscuro = true;
            btnSalvarSair_Click(sender, e);
            salvaConfigTemaEscuro = false;
        }
        private void LnkConfiguracaoPadrao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            salvaConfigPadrao = true;
            btnSalvarSair_Click(sender, e);
            salvaConfigPadrao = false;
        }
        private void lnkOpcaoCorFormulario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = gradientStartColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                gradientStartColor = cldCores.Color;
                MessageBox.Show("Escolha a segunda cor para fazer um efeito gradiente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cldCores.ShowDialog() == DialogResult.OK)
                {
                    gradientEndColor = cldCores.Color;
                    ApplyGradientColors();
                }
            }
        }
        private void lnkOpcaoCorFundoMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = gradientMenuStartColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                gradientMenuStartColor = cldCores.Color;
                MessageBox.Show("Escolha a segunda cor para fazer um efeito gradiente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cldCores.ShowDialog() == DialogResult.OK)
                {
                    gradientMenuEndColor = cldCores.Color;
                }
                mnsStripExemploAlterado.Visible = true;
                ApplyGradientColors();

            }
        }
        private void lnkOpcaoCorFonteMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            cldCores.Color = toolStripMenuItemForeColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                toolStripMenuItemForeColor = cldCores.Color;
                toolStriExemploAlterado1.ForeColor = toolStripMenuItemForeColor;
                toolStriExemploAlterado2.ForeColor = toolStripMenuItemForeColor;
                toolStriExemploAlterado3.ForeColor = toolStripMenuItemForeColor;
                toolStriExemploAlterado4.ForeColor = toolStripMenuItemForeColor;
                mnsStripExemploAlterado.Visible = true;
                ApplyGradientColors();
            }
        }
        private void lnkOpcaoCorFundoDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = labelBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                labelBackgroundColor = cldCores.Color;
                lblDescricaoAlterada.Visible = true;
                lblDescricaoAlterada.BackColor = labelBackgroundColor;
            }
        }
        private void lnkOpcaoCorFundoDescricaoTransparente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            labelBackgroundColor = Color.FromArgb(0, 255, 255, 255);
            lblDescricaoAlterada.BackColor = labelBackgroundColor;
            lblDescricaoAlterada.ForeColor = labelFontColor;
            lblDescricaoAlterada.Visible = true;
        }
        private void lnkOpcaoCorFonteDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = labelFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                labelFontColor = cldCores.Color;
                lblDescricaoAlterada.ForeColor = labelFontColor;
                lblDescricaoAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteDescricao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                labelFontFamily = ftdFontes.Font.FontFamily.Name;
                labelFontSize = ftdFontes.Font.Size;
                labelFontStyle = ftdFontes.Font.Style;
                lblDescricaoAlterada.Font = new Font(
                    labelFontFamily,
                    labelFontSize,
                    labelFontStyle
                );
                lblDescricaoAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFundoCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = textBoxBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                textBoxBackgroundColor = cldCores.Color;
                txtExemploAlterada.BackColor = textBoxBackgroundColor;
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFonteCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = textBoxFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                textBoxFontColor = cldCores.Color;
                txtExemploAlterada.ForeColor = textBoxFontColor;
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteCampo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                textBoxFontFamily = ftdFontes.Font.FontFamily.Name;
                textBoxFontSize = ftdFontes.Font.Size;
                textBoxFontStyle = ftdFontes.Font.Style;
                txtExemploAlterada.Font = new Font(
                    ftdFontes.Font.FontFamily,
                    ftdFontes.Font.Size,
                    ftdFontes.Font.Style
                );
                txtExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFundoBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = buttonBackgroundColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                buttonBackgroundColor = cldCores.Color;
                btnExemploAlterada.BackColor = buttonBackgroundColor;
                btnExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoCorFonteBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cldCores.Color = buttonFontColor;
            if (cldCores.ShowDialog() == DialogResult.OK)
            {
                buttonFontColor = cldCores.Color;
                btnExemploAlterada.ForeColor = buttonFontColor;
                btnExemploAlterada.Visible = true;
            }
        }
        private void lnkOpcaoFonteBotao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ftdFontes.ShowDialog() == DialogResult.OK)
            {
                buttonFontFamily = ftdFontes.Font.FontFamily.Name;
                buttonFontSize = ftdFontes.Font.Size;
                buttonFontStyle = ftdFontes.Font.Style;
                btnExemploAlterada.Font = new Font(
                    ftdFontes.Font.FontFamily,
                    ftdFontes.Font.Size,
                    ftdFontes.Font.Style
                );
                btnExemploAlterada.Visible = true;
            }
        }
        private void btnSalvarSair_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                "Deseja realmente salvar as alterações?",
                "Confirmar Alterações",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                if (salvaConfigTemaClaro)
                {
                    // ✅ Carrega valores do tema claro e salva no config.xml
                    CarregaDadosControles("temaClaro.xml");
                }
                else if (salvaConfigTemaEscuro)
                {
                    CarregaDadosControles("temaEscuro.xml");
                }
                else if (salvaConfigPadrao)
                {
                    CarregaDadosControles("configpadrao.xml");
                }
                // Define o caminho do arquivo de configuração
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XML", "config.xml");

                SalvarConfiguracoesPersonalizadas(configPath);

                // Exibe uma mensagem de confirmação para reiniciar o sistema
                DialogResult restartResult = MessageBox.Show("As configurações foram salvas. O sistema precisa ser reiniciado para aplicar as alterações. Deseja reiniciar agora?", "Reiniciar Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (restartResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo de configuração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ✅ Recarrega os controles do formulário atual
            CarregaControlesFormulario();
        }
        private void SalvarConfiguracoesPersonalizadas(string configPath)
        {
            // Carrega ou cria o documento base
            XDocument config;
            if (File.Exists(configPath))
                config = XDocument.Load(configPath);
            else
                config = new XDocument(new XElement("Config"));

            var root = config.Root ?? new XElement("Config");

            // Helper: define valor do elemento, criando se não existir
            void SetValue(string elementName, string value)
            {
                var el = root.Element(elementName);
                if (el == null)
                {
                    el = new XElement(elementName);
                    root.Add(el);
                }
                el.Value = value ?? string.Empty;
            }

            // Helper: ARGB em 8 dígitos
            string HEX(Color c) => c.ToArgb().ToString("X8");

            // 🎨 Efeito Gradiente
            SetValue("GradientStartColor", HEX(gradientStartColor));
            SetValue("GradientEndColor", HEX(gradientEndColor));

            // Form
            SetValue("FormBackgroundColor", HEX(formBackgroundColor));
            SetValue("FormFontFamily", formFontFamily);
            SetValue("FormFontSize", (formFontSize <= 0 ? 12 : formFontSize).ToString());
            SetValue("FormFontStyle", formFontStyle.ToString());

            // 📋 MenuStrip
            SetValue("MenuStripBackgroundColor", HEX(menuStripBackgroundColor));
            SetValue("MenuStripFontColor", HEX(menuStripFontColor));
            SetValue("GradientMenuStartColor", HEX(gradientMenuStartColor));
            SetValue("GradientMenuEndColor", HEX(gradientMenuEndColor));
            SetValue("MenuStripFontFamily", menuStripFontFamily);
            SetValue("MenuStripFontSize", (menuStripFontSize <= 0 ? 12 : menuStripFontSize).ToString());
            SetValue("MenuStripFontStyle", menuStripFontStyle.ToString());

            // 📑 ToolStripMenuItem
            SetValue("ToolStripMenuItemBackColor", HEX(toolStripMenuItemBackColor));
            SetValue("ToolStripMenuItemForeColor", HEX(toolStripMenuItemForeColor));
            SetValue("ToolStripMenuItemFontFamily", toolStripMenuItemFontFamily);
            SetValue("ToolStripMenuItemFontSize", (toolStripMenuItemFontSize <= 0 ? 12 : toolStripMenuItemFontSize).ToString());
            SetValue("ToolStripMenuItemFontStyle", toolStripMenuItemFontStyle.ToString());


            // 📝 TextBox
            SetValue("TextBoxBackgroundColor", HEX(textBoxBackgroundColor));
            SetValue("TextBoxFontColor", HEX(textBoxFontColor));
            SetValue("TextBoxBorderStyle", textBoxBorderStyle.ToString());
            SetValue("TextBoxFontFamily", textBoxFontFamily);
            SetValue("TextBoxFontSize", (textBoxFontSize <= 0 ? 12 : textBoxFontSize).ToString());
            SetValue("TextBoxFontStyle", textBoxFontStyle.ToString());

            // 🔢 MaskedTextBox
            SetValue("MaskedTextBoxBackgroundColor", HEX(maskedTextBoxBackgroundColor));
            SetValue("MaskedTextBoxFontColor", HEX(maskedTextBoxFontColor));
            SetValue("MaskedTextBoxBorderStyle", maskedTextBoxBorderStyle.ToString());
            SetValue("MaskedTextBoxFontFamily", maskedTextBoxFontFamily);
            SetValue("MaskedTextBoxFontSize", (maskedTextBoxFontSize <= 0 ? 12 : maskedTextBoxFontSize).ToString());
            SetValue("MaskedTextBoxFontStyle", maskedTextBoxFontStyle.ToString());


            // 🔘 Button
            SetValue("ButtonBackgroundColor", HEX(buttonBackgroundColor));
            SetValue("ButtonFontColor", HEX(buttonFontColor));
            SetValue("ButtonAutoSize", buttonAutoSize.ToString());
            SetValue("ButtonFontFamily", buttonFontFamily);
            SetValue("ButtonFontSize", (buttonFontSize <= 0 ? 12 : buttonFontSize).ToString());
            SetValue("ButtonFontStyle", buttonFontStyle.ToString());

            var buttonAppearance = root.Element("ButtonAppearance");
            if (buttonAppearance == null)
            {
                buttonAppearance = new XElement("ButtonAppearance");
                root.Add(buttonAppearance);
            }
            void SetButtonAppearance(string childName, string value)
            {
                var child = buttonAppearance.Element(childName);
                if (child == null)
                {
                    child = new XElement(childName);
                    buttonAppearance.Add(child);
                }
                child.Value = value ?? string.Empty;
            }
            SetButtonAppearance("BorderColor", HEX(buttonBorderColor));
            SetButtonAppearance("MouseDownBackColor", HEX(buttonMouseDownBackColor));
            SetButtonAppearance("MouseOverBackColor", HEX(buttonMouseOverBackColor));

            // 🏷️ Label
            SetValue("LabelBackgroundColor", HEX(labelBackgroundColor));
            SetValue("LabelFontColor", HEX(labelFontColor));
            SetValue("LabelAutoSize", labelAutoSize.ToString());
            SetValue("LabelFontFamily", labelFontFamily);
            SetValue("LabelFontSize", (labelFontSize <= 0 ? 12 : labelFontSize).ToString());
            SetValue("LabelFontStyle", labelFontStyle.ToString());

            // 🔗 LinkLabel
            SetValue("LinkLabelActiveLinkColor", HEX(linkLabelActiveLinkColor));
            SetValue("LinkLabelLinkColor", HEX(linkLabelLinkColor));
            SetValue("LinkLabelVisitedLinkColor", HEX(linkLabelVisitedLinkColor));
            SetValue("LinkLabelFontFamily", linkLabelFontFamily);
            SetValue("LinkLabelFontSize", (linkLabelFontSize <= 0 ? 12 : linkLabelFontSize).ToString());
            SetValue("LinkLabelFontStyle", linkLabelFontStyle.ToString());

            // 📦 Panel
            SetValue("PanelBackgroundColor", HEX(panelBackgroundColor));
            SetValue("PanelBorderStyle", panelBorderStyle.ToString());
            SetValue("PanelFontFamily", panelFontFamily);
            SetValue("PanelFontSize", (panelFontSize <= 0 ? 12 : panelFontSize).ToString());
            SetValue("PanelFontStyle", panelFontStyle.ToString());

            // 📋 ListView
            SetValue("ListViewBackColor", HEX(listViewBackColor));
            SetValue("ListViewForeColor", HEX(listViewForeColor));
            SetValue("ListViewFullRowSelect", listViewFullRowSelect.ToString());
            SetValue("ListViewGridLines", listViewGridLines.ToString());
            SetValue("ListViewHideSelection", listViewHideSelection.ToString());
            SetValue("ListViewFontFamily", listViewFontFamily);
            SetValue("ListViewFontSize", (listViewFontSize <= 0 ? 12 : listViewFontSize).ToString());
            SetValue("ListViewFontStyle", listViewFontStyle.ToString());

            // 🔽 ComboBox
            SetValue("ComboBoxBackColor", HEX(comboBoxBackColor));
            SetValue("ComboBoxForeColor", HEX(comboBoxForeColor));
            SetValue("ComboBoxDropDownStyle", comboBoxDropDownStyle.ToString());
            SetValue("ComboBoxFontFamily", comboBoxFontFamily);
            SetValue("ComboBoxFontSize", (comboBoxFontSize <= 0 ? 12 : comboBoxFontSize).ToString());
            SetValue("ComboBoxFontStyle", comboBoxFontStyle.ToString());

            // 📂 TabControl
            SetValue("TabControlFontFamily", tabControlFontFamily);
            SetValue("TabControlFontSize", (tabControlFontSize <= 0 ? 12 : tabControlFontSize).ToString());
            SetValue("TabControlFontStyle", tabControlFontStyle.ToString());

            // 📂 TabPage
            SetValue("TabPageBackColor", HEX(tabPageBackColor));
            SetValue("TabPageForeColor", HEX(tabPageForeColor));
            SetValue("TabPageBorderStyle", tabPageBorderStyle.ToString());
            SetValue("TabPageFontFamily", tabPageFontFamily);
            SetValue("TabPageFontSize", (tabPageFontSize <= 0 ? 12 : tabPageFontSize).ToString());
            SetValue("TabPageFontStyle", tabPageFontStyle.ToString());

            // 📊 ProgressBar
            SetValue("ProgressBarBackColor", HEX(progressBarBackColor));
            SetValue("ProgressBarForeColor", HEX(progressBarForeColor));
            SetValue("ProgressBarStyle", progressBarStyle.ToString());

            // Garante que root esteja no documento antes de salvar
            if (config.Root == null)
                config.Add(root);

            // ✅ Salva o documento XML atualizado
            config.Save(configPath);
        }
        private void btnCancelarSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ApplyGradientColors()
        {
            Invalidate(); // Isso força o formulário a repintar com as novas cores
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientStartColor, gradientEndColor, 70F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void CentralizarControlesHorizontalmenteNoPanel(Panel panel, params Control[] controles)
        {
            foreach (Control controle in controles)
            {
                // Calcular a nova posição X do controle para centralizá-lo horizontalmente no painel
                int x = (panel.Width - controle.Width) / 2;

                // Manter a posição Y atual do controle
                int y = controle.Location.Y;

                // Definir a nova posição do controle
                controle.Location = new Point(x, y);
            }
        }
    }
}
