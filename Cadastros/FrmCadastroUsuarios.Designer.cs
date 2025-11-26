namespace OrdemServicos
{
    partial class frmUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.txtIDUsuario = new System.Windows.Forms.TextBox();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.listViewUsuario = new System.Windows.Forms.ListView();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControlUsuarios = new System.Windows.Forms.TabControl();
            this.tabDadosUsuario = new System.Windows.Forms.TabPage();
            this.btnExcluirImagem = new System.Windows.Forms.Button();
            this.btnInserirImagem = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFone_2 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_2 = new System.Windows.Forms.Label();
            this.txtFone_1 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_1 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lbUF = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lbMunicipio = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtConfirmaSenha = new System.Windows.Forms.TextBox();
            this.lblConfirme = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.lbImagemUsuario = new System.Windows.Forms.Label();
            this.imgImagemUsuario = new System.Windows.Forms.PictureBox();
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.tabControlUsuarios.SuspendLayout();
            this.tabDadosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemUsuario)).BeginInit();
            this.tabInformacoesAdicionais.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDUsuario
            // 
            this.txtIDUsuario.Location = new System.Drawing.Point(1602, 245);
            this.txtIDUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDUsuario.Name = "txtIDUsuario";
            this.txtIDUsuario.Size = new System.Drawing.Size(28, 26);
            this.txtIDUsuario.TabIndex = 69;
            this.txtIDUsuario.Text = " ";
            this.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDUsuario.Visible = false;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erpProvider.SetIconAlignment(this.lbTotalRegistros, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.lbTotalRegistros.Location = new System.Drawing.Point(16, 5);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(468, 51);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.Tag = "naoAplicar";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewUsuario
            // 
            this.listViewUsuario.CausesValidation = false;
            this.listViewUsuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUsuario.FullRowSelect = true;
            this.listViewUsuario.GridLines = true;
            this.listViewUsuario.HideSelection = false;
            this.listViewUsuario.Location = new System.Drawing.Point(18, 290);
            this.listViewUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewUsuario.Name = "listViewUsuario";
            this.listViewUsuario.Size = new System.Drawing.Size(1423, 281);
            this.listViewUsuario.TabIndex = 75;
            this.listViewUsuario.UseCompatibleStateImageBehavior = false;
            this.listViewUsuario.View = System.Windows.Forms.View.Details;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBotoes.Location = new System.Drawing.Point(18, 573);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1423, 61);
            this.pnlBotoes.TabIndex = 96;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(1274, 5);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 51);
            this.btnFechar.TabIndex = 63;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1005, 5);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 51);
            this.btnSalvar.TabIndex = 61;
            this.btnSalvar.Text = "      Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.AutoSize = true;
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(872, 5);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(126, 51);
            this.btnAlterar.TabIndex = 60;
            this.btnAlterar.Tag = "";
            this.btnAlterar.Text = "       Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(1138, 5);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(126, 51);
            this.btnExcluir.TabIndex = 62;
            this.btnExcluir.Text = "     Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.AutoSize = true;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(739, 5);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(126, 51);
            this.btnNovo.TabIndex = 59;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1271, 5);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 51);
            this.btnCancelar.TabIndex = 64;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControlUsuarios
            // 
            this.tabControlUsuarios.Controls.Add(this.tabDadosUsuario);
            this.tabControlUsuarios.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlUsuarios.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlUsuarios.Location = new System.Drawing.Point(18, 4);
            this.tabControlUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlUsuarios.Multiline = true;
            this.tabControlUsuarios.Name = "tabControlUsuarios";
            this.tabControlUsuarios.SelectedIndex = 0;
            this.tabControlUsuarios.Size = new System.Drawing.Size(1423, 281);
            this.tabControlUsuarios.TabIndex = 97;
            // 
            // tabDadosUsuario
            // 
            this.tabDadosUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosUsuario.Controls.Add(this.btnExcluirImagem);
            this.tabDadosUsuario.Controls.Add(this.btnInserirImagem);
            this.tabDadosUsuario.Controls.Add(this.txtEmail);
            this.tabDadosUsuario.Controls.Add(this.lblEmail);
            this.tabDadosUsuario.Controls.Add(this.txtFone_2);
            this.tabDadosUsuario.Controls.Add(this.lbFone_2);
            this.tabDadosUsuario.Controls.Add(this.txtFone_1);
            this.tabDadosUsuario.Controls.Add(this.lbFone_1);
            this.tabDadosUsuario.Controls.Add(this.txtIDUsuario);
            this.tabDadosUsuario.Controls.Add(this.txtUF);
            this.tabDadosUsuario.Controls.Add(this.lbUF);
            this.tabDadosUsuario.Controls.Add(this.txtMunicipio);
            this.tabDadosUsuario.Controls.Add(this.lbMunicipio);
            this.tabDadosUsuario.Controls.Add(this.txtBairro);
            this.tabDadosUsuario.Controls.Add(this.lbBairro);
            this.tabDadosUsuario.Controls.Add(this.txtNumero);
            this.tabDadosUsuario.Controls.Add(this.lbNumero);
            this.tabDadosUsuario.Controls.Add(this.txtEndereco);
            this.tabDadosUsuario.Controls.Add(this.lbEndereco);
            this.tabDadosUsuario.Controls.Add(this.txtCep);
            this.tabDadosUsuario.Controls.Add(this.lbCep);
            this.tabDadosUsuario.Controls.Add(this.txtConfirmaSenha);
            this.tabDadosUsuario.Controls.Add(this.lblConfirme);
            this.tabDadosUsuario.Controls.Add(this.txtSenha);
            this.tabDadosUsuario.Controls.Add(this.lblSenha);
            this.tabDadosUsuario.Controls.Add(this.txtLogin);
            this.tabDadosUsuario.Controls.Add(this.lblLogin);
            this.tabDadosUsuario.Controls.Add(this.txtNome);
            this.tabDadosUsuario.Controls.Add(this.lbNome);
            this.tabDadosUsuario.Controls.Add(this.txtPesquisaListView);
            this.tabDadosUsuario.Controls.Add(this.lblPesquisaListView);
            this.tabDadosUsuario.Controls.Add(this.lbImagemUsuario);
            this.tabDadosUsuario.Controls.Add(this.imgImagemUsuario);
            this.tabDadosUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosUsuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosUsuario.Location = new System.Drawing.Point(4, 28);
            this.tabDadosUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDadosUsuario.Name = "tabDadosUsuario";
            this.tabDadosUsuario.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDadosUsuario.Size = new System.Drawing.Size(1415, 249);
            this.tabDadosUsuario.TabIndex = 0;
            this.tabDadosUsuario.Text = "Dados do Usuário";
            // 
            // btnExcluirImagem
            // 
            this.btnExcluirImagem.AutoSize = true;
            this.btnExcluirImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluirImagem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirImagem.Image")));
            this.btnExcluirImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirImagem.Location = new System.Drawing.Point(1464, 117);
            this.btnExcluirImagem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcluirImagem.Name = "btnExcluirImagem";
            this.btnExcluirImagem.Size = new System.Drawing.Size(147, 59);
            this.btnExcluirImagem.TabIndex = 156;
            this.btnExcluirImagem.Text = "     Excluir";
            this.btnExcluirImagem.UseVisualStyleBackColor = false;
            this.btnExcluirImagem.Click += new System.EventHandler(this.btnExcluirImagem_Click);
            // 
            // btnInserirImagem
            // 
            this.btnInserirImagem.AutoSize = true;
            this.btnInserirImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserirImagem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnInserirImagem.Image")));
            this.btnInserirImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInserirImagem.Location = new System.Drawing.Point(1464, 47);
            this.btnInserirImagem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInserirImagem.Name = "btnInserirImagem";
            this.btnInserirImagem.Size = new System.Drawing.Size(147, 59);
            this.btnInserirImagem.TabIndex = 155;
            this.btnInserirImagem.Text = "     Inserir";
            this.btnInserirImagem.UseVisualStyleBackColor = false;
            this.btnInserirImagem.Click += new System.EventHandler(this.btnInserirImagem_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(804, 152);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(410, 26);
            this.txtEmail.TabIndex = 151;
            this.tlpDicas.SetToolTip(this.txtEmail, "Informe o E-Mail.");
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(804, 132);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(69, 19);
            this.lblEmail.TabIndex = 154;
            this.lblEmail.Text = "E-Mail..:";
            // 
            // txtFone_2
            // 
            this.txtFone_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_2.Location = new System.Drawing.Point(630, 152);
            this.txtFone_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFone_2.Name = "txtFone_2";
            this.txtFone_2.Size = new System.Drawing.Size(138, 26);
            this.txtFone_2.TabIndex = 150;
            this.txtFone_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtFone_2, "Informe o Telefone Fixo.");
            // 
            // lbFone_2
            // 
            this.lbFone_2.AutoSize = true;
            this.lbFone_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_2.Location = new System.Drawing.Point(630, 132);
            this.lbFone_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFone_2.Name = "lbFone_2";
            this.lbFone_2.Size = new System.Drawing.Size(51, 19);
            this.lbFone_2.TabIndex = 153;
            this.lbFone_2.Text = "Fixo..:";
            // 
            // txtFone_1
            // 
            this.txtFone_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_1.Location = new System.Drawing.Point(456, 152);
            this.txtFone_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFone_1.Name = "txtFone_1";
            this.txtFone_1.Size = new System.Drawing.Size(138, 26);
            this.txtFone_1.TabIndex = 149;
            this.txtFone_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtFone_1, "Informe o Celular.");
            // 
            // lbFone_1
            // 
            this.lbFone_1.AutoSize = true;
            this.lbFone_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_1.Location = new System.Drawing.Point(458, 132);
            this.lbFone_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFone_1.Name = "lbFone_1";
            this.lbFone_1.Size = new System.Drawing.Size(70, 19);
            this.lbFone_1.TabIndex = 152;
            this.lbFone_1.Text = "Celular..:";
            // 
            // txtUF
            // 
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(368, 152);
            this.txtUF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(52, 26);
            this.txtUF.TabIndex = 146;
            this.txtUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tlpDicas.SetToolTip(this.txtUF, "Informe o Estado.");
            // 
            // lbUF
            // 
            this.lbUF.AutoSize = true;
            this.lbUF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.Location = new System.Drawing.Point(368, 132);
            this.lbUF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(41, 19);
            this.lbUF.TabIndex = 148;
            this.lbUF.Text = "UF..:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(10, 152);
            this.txtMunicipio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(322, 26);
            this.txtMunicipio.TabIndex = 145;
            this.tlpDicas.SetToolTip(this.txtMunicipio, "Informe o Municipio.");
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.AutoSize = true;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.Location = new System.Drawing.Point(10, 132);
            this.lbMunicipio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Size = new System.Drawing.Size(89, 19);
            this.lbMunicipio.TabIndex = 147;
            this.lbMunicipio.Text = "Municipio..:";
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(866, 91);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(348, 26);
            this.txtBairro.TabIndex = 141;
            this.tlpDicas.SetToolTip(this.txtBairro, "Informe o Bairro.");
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.Location = new System.Drawing.Point(866, 71);
            this.lbBairro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(65, 19);
            this.lbBairro.TabIndex = 144;
            this.lbBairro.Text = "Bairro..:";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(720, 91);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(98, 26);
            this.txtNumero.TabIndex = 140;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tlpDicas.SetToolTip(this.txtNumero, "Informe o Numero.");
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(720, 71);
            this.lbNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(76, 19);
            this.lbNumero.TabIndex = 143;
            this.lbNumero.Text = "Numero..:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(166, 91);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(506, 26);
            this.txtEndereco.TabIndex = 139;
            this.tlpDicas.SetToolTip(this.txtEndereco, "Informe o Endereço.");
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(168, 71);
            this.lbEndereco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(85, 19);
            this.lbEndereco.TabIndex = 142;
            this.lbEndereco.Text = "Endereço..:";
            // 
            // txtCep
            // 
            this.txtCep.Culture = new System.Globalization.CultureInfo("");
            this.txtCep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(10, 91);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCep.Name = "txtCep";
            this.txtCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCep.Size = new System.Drawing.Size(108, 26);
            this.txtCep.TabIndex = 136;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tlpDicas.SetToolTip(this.txtCep, "Informe o Cep.");
            // 
            // lbCep
            // 
            this.lbCep.AutoSize = true;
            this.lbCep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.Location = new System.Drawing.Point(10, 71);
            this.lbCep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(49, 19);
            this.lbCep.TabIndex = 137;
            this.lbCep.Text = "Cep..:";
            // 
            // txtConfirmaSenha
            // 
            this.txtConfirmaSenha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmaSenha.Location = new System.Drawing.Point(1015, 30);
            this.txtConfirmaSenha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmaSenha.Name = "txtConfirmaSenha";
            this.txtConfirmaSenha.Size = new System.Drawing.Size(199, 26);
            this.txtConfirmaSenha.TabIndex = 134;
            this.tlpDicas.SetToolTip(this.txtConfirmaSenha, "Confirme a Senha.");
            this.txtConfirmaSenha.UseSystemPasswordChar = true;
            // 
            // lblConfirme
            // 
            this.lblConfirme.AutoSize = true;
            this.lblConfirme.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirme.Location = new System.Drawing.Point(1015, 10);
            this.lblConfirme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirme.Name = "lblConfirme";
            this.lblConfirme.Size = new System.Drawing.Size(129, 19);
            this.lblConfirme.TabIndex = 135;
            this.lblConfirme.Text = "Confirme Senha..:";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(804, 30);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(168, 26);
            this.txtSenha.TabIndex = 130;
            this.tlpDicas.SetToolTip(this.txtSenha, "Informe a Senha.");
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(804, 10);
            this.lblSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(63, 19);
            this.lblSenha.TabIndex = 133;
            this.lblSenha.Text = "Senha..:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(495, 30);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(266, 26);
            this.txtLogin.TabIndex = 129;
            this.tlpDicas.SetToolTip(this.txtLogin, "Informe o Login.");
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(497, 10);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(60, 19);
            this.lblLogin.TabIndex = 132;
            this.lblLogin.Text = "Login..:";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(10, 30);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(442, 26);
            this.txtNome.TabIndex = 128;
            this.tlpDicas.SetToolTip(this.txtNome, "Informe o Nome Completo.");
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(10, 10);
            this.lbNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(130, 19);
            this.lbNome.TabIndex = 131;
            this.lbNome.Text = "Nome Completo..:";
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(10, 210);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(490, 26);
            this.txtPesquisaListView.TabIndex = 56;
            this.tlpDicas.SetToolTip(this.txtPesquisaListView, "Informe o Usuário a Pesquisar.");
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(10, 190);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(137, 19);
            this.lblPesquisaListView.TabIndex = 57;
            this.lblPesquisaListView.Text = "Pesquisa Usuário..:";
            // 
            // lbImagemUsuario
            // 
            this.lbImagemUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImagemUsuario.AutoSize = true;
            this.lbImagemUsuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImagemUsuario.Location = new System.Drawing.Point(1246, 10);
            this.lbImagemUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbImagemUsuario.Name = "lbImagemUsuario";
            this.lbImagemUsuario.Size = new System.Drawing.Size(132, 19);
            this.lbImagemUsuario.TabIndex = 90;
            this.lbImagemUsuario.Text = "Imagem Usuário..:";
            this.lbImagemUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgImagemUsuario
            // 
            this.imgImagemUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgImagemUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImagemUsuario.Location = new System.Drawing.Point(1240, 30);
            this.imgImagemUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgImagemUsuario.Name = "imgImagemUsuario";
            this.imgImagemUsuario.Size = new System.Drawing.Size(156, 156);
            this.imgImagemUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImagemUsuario.TabIndex = 89;
            this.imgImagemUsuario.TabStop = false;
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Controls.Add(this.txtDataCadastro);
            this.tabInformacoesAdicionais.Controls.Add(this.lbDataCadastro);
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 28);
            this.tabInformacoesAdicionais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1415, 249);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "  Informações Adicionais";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Location = new System.Drawing.Point(12, 35);
            this.txtDataCadastro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(174, 26);
            this.txtDataCadastro.TabIndex = 114;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tlpDicas.SetToolTip(this.txtDataCadastro, "Informe a Data do Cadastro.");
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.Location = new System.Drawing.Point(12, 10);
            this.lbDataCadastro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(134, 22);
            this.lbDataCadastro.TabIndex = 115;
            this.lbDataCadastro.Text = "Data Cadastro..:";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 640);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlUsuarios);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.listViewUsuario);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUsuarios";
            this.Text = "Cadastro de Usuários";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.tabControlUsuarios.ResumeLayout(false);
            this.tabDadosUsuario.ResumeLayout(false);
            this.tabDadosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImagemUsuario)).EndInit();
            this.tabInformacoesAdicionais.ResumeLayout(false);
            this.tabInformacoesAdicionais.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TextBox txtIDUsuario;
        private System.Windows.Forms.ListView listViewUsuario;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TabControl tabControlUsuarios;
        private System.Windows.Forms.TabPage tabDadosUsuario;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.Label lbImagemUsuario;
        private System.Windows.Forms.PictureBox imgImagemUsuario;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtConfirmaSenha;
        private System.Windows.Forms.Label lblConfirme;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lbMunicipio;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.MaskedTextBox txtFone_2;
        private System.Windows.Forms.Label lbFone_2;
        private System.Windows.Forms.MaskedTextBox txtFone_1;
        private System.Windows.Forms.Label lbFone_1;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.ToolTip tlpDicas;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnInserirImagem;
        private System.Windows.Forms.Button btnExcluirImagem;
        private System.Windows.Forms.Button btnCancelar;
	}
}
