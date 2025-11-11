namespace OrdemServicos
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.listViewClientes = new System.Windows.Forms.ListView();
            this.erpProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lbTotalRegistros = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControlClientes = new System.Windows.Forms.TabControl();
            this.tabDadosClientes = new System.Windows.Forms.TabPage();
            this.progressBarCNPJs = new System.Windows.Forms.ProgressBar();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblProgressoCNPJs = new System.Windows.Forms.Label();
            this.txtPesquisaListView = new System.Windows.Forms.TextBox();
            this.lbContato = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.lblPesquisaListView = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbUF = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lbMunicipio = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lbEndereco = new System.Windows.Forms.Label();
            this.rdbCnpj = new System.Windows.Forms.RadioButton();
            this.rdbCpf = new System.Windows.Forms.RadioButton();
            this.txtFone_2 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_2 = new System.Windows.Forms.Label();
            this.txtFone_1 = new System.Windows.Forms.MaskedTextBox();
            this.lbFone_1 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.lbDataCadastro = new System.Windows.Forms.Label();
            this.txtNomeRazaoSocial = new System.Windows.Forms.TextBox();
            this.lbNomeRazaoSocial = new System.Windows.Forms.Label();
            this.txtCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lbCpfCnpj = new System.Windows.Forms.Label();
            this.btnCarregaArquivoCnpj = new System.Windows.Forms.Button();
            this.btnCarregaArquivoCpf = new System.Windows.Forms.Button();
            this.tabInformacoesAdicionais = new System.Windows.Forms.TabPage();
            this.tlpDicas = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).BeginInit();
            this.pnlBotoes.SuspendLayout();
            this.tabControlClientes.SuspendLayout();
            this.tabDadosClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewClientes
            // 
            this.listViewClientes.CausesValidation = false;
            this.listViewClientes.FullRowSelect = true;
            this.listViewClientes.GridLines = true;
            this.listViewClientes.HideSelection = false;
            this.listViewClientes.Location = new System.Drawing.Point(18, 290);
            this.listViewClientes.Margin = new System.Windows.Forms.Padding(4);
            this.listViewClientes.Name = "listViewClientes";
            this.listViewClientes.Size = new System.Drawing.Size(1423, 276);
            this.listViewClientes.TabIndex = 18;
            this.listViewClientes.UseCompatibleStateImageBehavior = false;
            this.listViewClientes.View = System.Windows.Forms.View.Details;
            // 
            // erpProvider
            // 
            this.erpProvider.ContainerControl = this;
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDCliente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCliente.Location = new System.Drawing.Point(1363, 210);
            this.txtIDCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(29, 22);
            this.txtIDCliente.TabIndex = 13;
            this.txtIDCliente.Text = " ";
            this.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIDCliente.Visible = false;
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnNovo);
            this.pnlBotoes.Controls.Add(this.lbTotalRegistros);
            this.pnlBotoes.Controls.Add(this.btnFechar);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Location = new System.Drawing.Point(18, 573);
            this.pnlBotoes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Size = new System.Drawing.Size(1423, 61);
            this.pnlBotoes.TabIndex = 97;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1007, 3);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(126, 51);
            this.btnSalvar.TabIndex = 67;
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
            this.btnAlterar.Location = new System.Drawing.Point(873, 3);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(126, 51);
            this.btnAlterar.TabIndex = 66;
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
            this.btnExcluir.Location = new System.Drawing.Point(1140, 3);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(126, 51);
            this.btnExcluir.TabIndex = 68;
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
            this.btnNovo.Location = new System.Drawing.Point(739, 3);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(126, 51);
            this.btnNovo.TabIndex = 65;
            this.btnNovo.Text = "     Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lbTotalRegistros
            // 
            this.lbTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTotalRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbTotalRegistros.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRegistros.Location = new System.Drawing.Point(10, 8);
            this.lbTotalRegistros.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTotalRegistros.Name = "lbTotalRegistros";
            this.lbTotalRegistros.Size = new System.Drawing.Size(401, 42);
            this.lbTotalRegistros.TabIndex = 58;
            this.lbTotalRegistros.Tag = "naoAplicar";
            this.lbTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFechar
            // 
            this.btnFechar.AutoSize = true;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(1274, 3);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(126, 51);
            this.btnFechar.TabIndex = 69;
            this.btnFechar.Text = "     Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1274, 3);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 51);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "     Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControlClientes
            // 
            this.tabControlClientes.Controls.Add(this.tabDadosClientes);
            this.tabControlClientes.Controls.Add(this.tabInformacoesAdicionais);
            this.tabControlClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlClientes.ItemSize = new System.Drawing.Size(109, 20);
            this.tabControlClientes.Location = new System.Drawing.Point(18, 4);
            this.tabControlClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlClientes.Multiline = true;
            this.tabControlClientes.Name = "tabControlClientes";
            this.tabControlClientes.SelectedIndex = 0;
            this.tabControlClientes.Size = new System.Drawing.Size(1423, 281);
            this.tabControlClientes.TabIndex = 98;
            // 
            // tabDadosClientes
            // 
            this.tabDadosClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDadosClientes.Controls.Add(this.progressBarCNPJs);
            this.tabDadosClientes.Controls.Add(this.lblEmail);
            this.tabDadosClientes.Controls.Add(this.lblProgressoCNPJs);
            this.tabDadosClientes.Controls.Add(this.txtIDCliente);
            this.tabDadosClientes.Controls.Add(this.txtPesquisaListView);
            this.tabDadosClientes.Controls.Add(this.lbContato);
            this.tabDadosClientes.Controls.Add(this.txtUF);
            this.tabDadosClientes.Controls.Add(this.txtContato);
            this.tabDadosClientes.Controls.Add(this.lblPesquisaListView);
            this.tabDadosClientes.Controls.Add(this.txtEmail);
            this.tabDadosClientes.Controls.Add(this.lbUF);
            this.tabDadosClientes.Controls.Add(this.txtMunicipio);
            this.tabDadosClientes.Controls.Add(this.lbMunicipio);
            this.tabDadosClientes.Controls.Add(this.txtBairro);
            this.tabDadosClientes.Controls.Add(this.lbBairro);
            this.tabDadosClientes.Controls.Add(this.txtNumero);
            this.tabDadosClientes.Controls.Add(this.lbNumero);
            this.tabDadosClientes.Controls.Add(this.txtEndereco);
            this.tabDadosClientes.Controls.Add(this.lbEndereco);
            this.tabDadosClientes.Controls.Add(this.rdbCnpj);
            this.tabDadosClientes.Controls.Add(this.rdbCpf);
            this.tabDadosClientes.Controls.Add(this.txtFone_2);
            this.tabDadosClientes.Controls.Add(this.lbFone_2);
            this.tabDadosClientes.Controls.Add(this.txtFone_1);
            this.tabDadosClientes.Controls.Add(this.lbFone_1);
            this.tabDadosClientes.Controls.Add(this.txtCep);
            this.tabDadosClientes.Controls.Add(this.lbCep);
            this.tabDadosClientes.Controls.Add(this.txtDataCadastro);
            this.tabDadosClientes.Controls.Add(this.lbDataCadastro);
            this.tabDadosClientes.Controls.Add(this.txtNomeRazaoSocial);
            this.tabDadosClientes.Controls.Add(this.lbNomeRazaoSocial);
            this.tabDadosClientes.Controls.Add(this.txtCpfCnpj);
            this.tabDadosClientes.Controls.Add(this.lbCpfCnpj);
            this.tabDadosClientes.Controls.Add(this.btnCarregaArquivoCnpj);
            this.tabDadosClientes.Controls.Add(this.btnCarregaArquivoCpf);
            this.tabDadosClientes.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDadosClientes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDadosClientes.Location = new System.Drawing.Point(4, 24);
            this.tabDadosClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tabDadosClientes.Name = "tabDadosClientes";
            this.tabDadosClientes.Padding = new System.Windows.Forms.Padding(4);
            this.tabDadosClientes.Size = new System.Drawing.Size(1415, 253);
            this.tabDadosClientes.TabIndex = 0;
            this.tabDadosClientes.Text = "   Dados do Cliente   ";
            // 
            // progressBarCNPJs
            // 
            this.progressBarCNPJs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.progressBarCNPJs.ForeColor = System.Drawing.Color.Blue;
            this.progressBarCNPJs.Location = new System.Drawing.Point(363, 140);
            this.progressBarCNPJs.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarCNPJs.Name = "progressBarCNPJs";
            this.progressBarCNPJs.Size = new System.Drawing.Size(648, 54);
            this.progressBarCNPJs.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCNPJs.TabIndex = 122;
            this.progressBarCNPJs.Tag = "naoAplicar";
            this.progressBarCNPJs.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(782, 132);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(69, 19);
            this.lblEmail.TabIndex = 118;
            this.lblEmail.Text = "E-Mail..:";
            // 
            // lblProgressoCNPJs
            // 
            this.lblProgressoCNPJs.BackColor = System.Drawing.Color.Azure;
            this.lblProgressoCNPJs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProgressoCNPJs.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressoCNPJs.ForeColor = System.Drawing.Color.Red;
            this.lblProgressoCNPJs.Location = new System.Drawing.Point(363, 87);
            this.lblProgressoCNPJs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgressoCNPJs.Name = "lblProgressoCNPJs";
            this.lblProgressoCNPJs.Size = new System.Drawing.Size(647, 54);
            this.lblProgressoCNPJs.TabIndex = 99;
            this.lblProgressoCNPJs.Tag = "";
            this.lblProgressoCNPJs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgressoCNPJs.Visible = false;
            // 
            // txtPesquisaListView
            // 
            this.txtPesquisaListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisaListView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisaListView.Enabled = false;
            this.txtPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaListView.Location = new System.Drawing.Point(10, 210);
            this.txtPesquisaListView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPesquisaListView.Name = "txtPesquisaListView";
            this.txtPesquisaListView.Size = new System.Drawing.Size(431, 26);
            this.txtPesquisaListView.TabIndex = 119;
            this.txtPesquisaListView.TextChanged += new System.EventHandler(this.txtPesquisaListView_TextChanged);
            // 
            // lbContato
            // 
            this.lbContato.AutoSize = true;
            this.lbContato.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContato.Location = new System.Drawing.Point(10, 132);
            this.lbContato.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbContato.Name = "lbContato";
            this.lbContato.Size = new System.Drawing.Size(75, 19);
            this.lbContato.TabIndex = 117;
            this.lbContato.Text = "Contato..:";
            // 
            // txtUF
            // 
            this.txtUF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(1337, 91);
            this.txtUF.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(51, 26);
            this.txtUF.TabIndex = 102;
            this.txtUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContato
            // 
            this.txtContato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContato.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContato.Location = new System.Drawing.Point(10, 152);
            this.txtContato.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(431, 26);
            this.txtContato.TabIndex = 104;
            // 
            // lblPesquisaListView
            // 
            this.lblPesquisaListView.AutoSize = true;
            this.lblPesquisaListView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisaListView.Location = new System.Drawing.Point(10, 190);
            this.lblPesquisaListView.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPesquisaListView.Name = "lblPesquisaListView";
            this.lblPesquisaListView.Size = new System.Drawing.Size(133, 19);
            this.lblPesquisaListView.TabIndex = 120;
            this.lblPesquisaListView.Text = "Pesquisa Cliente..:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(782, 152);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(606, 26);
            this.txtEmail.TabIndex = 107;
            // 
            // lbUF
            // 
            this.lbUF.AutoSize = true;
            this.lbUF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUF.Location = new System.Drawing.Point(1342, 71);
            this.lbUF.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbUF.Name = "lbUF";
            this.lbUF.Size = new System.Drawing.Size(41, 19);
            this.lbUF.TabIndex = 116;
            this.lbUF.Text = "UF..:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMunicipio.Location = new System.Drawing.Point(895, 91);
            this.txtMunicipio.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(411, 26);
            this.txtMunicipio.TabIndex = 101;
            // 
            // lbMunicipio
            // 
            this.lbMunicipio.AutoSize = true;
            this.lbMunicipio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMunicipio.Location = new System.Drawing.Point(896, 71);
            this.lbMunicipio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbMunicipio.Name = "lbMunicipio";
            this.lbMunicipio.Size = new System.Drawing.Size(89, 19);
            this.lbMunicipio.TabIndex = 115;
            this.lbMunicipio.Text = "Municipio..:";
            // 
            // txtBairro
            // 
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(597, 91);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(267, 26);
            this.txtBairro.TabIndex = 99;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBairro.Location = new System.Drawing.Point(597, 71);
            this.lbBairro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(65, 19);
            this.lbBairro.TabIndex = 114;
            this.lbBairro.Text = "Bairro..:";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(473, 91);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(92, 26);
            this.txtNumero.TabIndex = 97;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(473, 71);
            this.lbNumero.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(76, 19);
            this.lbNumero.TabIndex = 113;
            this.lbNumero.Text = "Numero..:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(10, 91);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(431, 26);
            this.txtEndereco.TabIndex = 96;
            // 
            // lbEndereco
            // 
            this.lbEndereco.AutoSize = true;
            this.lbEndereco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndereco.Location = new System.Drawing.Point(10, 71);
            this.lbEndereco.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEndereco.Name = "lbEndereco";
            this.lbEndereco.Size = new System.Drawing.Size(85, 19);
            this.lbEndereco.TabIndex = 112;
            this.lbEndereco.Text = "Endereço..:";
            // 
            // rdbCnpj
            // 
            this.rdbCnpj.AutoSize = true;
            this.rdbCnpj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCnpj.Location = new System.Drawing.Point(10, 34);
            this.rdbCnpj.Margin = new System.Windows.Forms.Padding(4);
            this.rdbCnpj.Name = "rdbCnpj";
            this.rdbCnpj.Size = new System.Drawing.Size(131, 23);
            this.rdbCnpj.TabIndex = 90;
            this.rdbCnpj.Text = "Pessoa Jurídica";
            this.rdbCnpj.UseVisualStyleBackColor = false;
            // 
            // rdbCpf
            // 
            this.rdbCpf.AutoSize = true;
            this.rdbCpf.Checked = true;
            this.rdbCpf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCpf.Location = new System.Drawing.Point(10, 10);
            this.rdbCpf.Margin = new System.Windows.Forms.Padding(4);
            this.rdbCpf.Name = "rdbCpf";
            this.rdbCpf.Size = new System.Drawing.Size(117, 23);
            this.rdbCpf.TabIndex = 89;
            this.rdbCpf.TabStop = true;
            this.rdbCpf.Text = "Pessoa Física";
            this.rdbCpf.UseVisualStyleBackColor = false;
            // 
            // txtFone_2
            // 
            this.txtFone_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_2.Location = new System.Drawing.Point(627, 152);
            this.txtFone_2.Margin = new System.Windows.Forms.Padding(4);
            this.txtFone_2.Name = "txtFone_2";
            this.txtFone_2.Size = new System.Drawing.Size(123, 26);
            this.txtFone_2.TabIndex = 106;
            this.txtFone_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_2
            // 
            this.lbFone_2.AutoSize = true;
            this.lbFone_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_2.Location = new System.Drawing.Point(627, 132);
            this.lbFone_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFone_2.Name = "lbFone_2";
            this.lbFone_2.Size = new System.Drawing.Size(51, 19);
            this.lbFone_2.TabIndex = 109;
            this.lbFone_2.Text = "Fixo..:";
            // 
            // txtFone_1
            // 
            this.txtFone_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFone_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFone_1.Location = new System.Drawing.Point(473, 152);
            this.txtFone_1.Margin = new System.Windows.Forms.Padding(4);
            this.txtFone_1.Name = "txtFone_1";
            this.txtFone_1.Size = new System.Drawing.Size(123, 26);
            this.txtFone_1.TabIndex = 105;
            this.txtFone_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFone_1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbFone_1
            // 
            this.lbFone_1.AutoSize = true;
            this.lbFone_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFone_1.Location = new System.Drawing.Point(473, 132);
            this.lbFone_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFone_1.Name = "lbFone_1";
            this.lbFone_1.Size = new System.Drawing.Size(70, 19);
            this.lbFone_1.TabIndex = 108;
            this.lbFone_1.Text = "Celular..:";
            // 
            // txtCep
            // 
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Culture = new System.Globalization.CultureInfo("");
            this.txtCep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCep.Location = new System.Drawing.Point(1295, 30);
            this.txtCep.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCep.Name = "txtCep";
            this.txtCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCep.Size = new System.Drawing.Size(93, 26);
            this.txtCep.TabIndex = 94;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCep
            // 
            this.lbCep.AutoSize = true;
            this.lbCep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCep.Location = new System.Drawing.Point(1295, 10);
            this.lbCep.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(49, 19);
            this.lbCep.TabIndex = 103;
            this.lbCep.Text = "Cep..:";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCadastro.Location = new System.Drawing.Point(1107, 33);
            this.txtDataCadastro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(154, 26);
            this.txtDataCadastro.TabIndex = 92;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbDataCadastro
            // 
            this.lbDataCadastro.AutoSize = true;
            this.lbDataCadastro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataCadastro.Location = new System.Drawing.Point(1107, 10);
            this.lbDataCadastro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDataCadastro.Name = "lbDataCadastro";
            this.lbDataCadastro.Size = new System.Drawing.Size(120, 19);
            this.lbDataCadastro.TabIndex = 100;
            this.lbDataCadastro.Text = "Data Cadastro..:";
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeRazaoSocial.Location = new System.Drawing.Point(377, 30);
            this.txtNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            this.txtNomeRazaoSocial.Size = new System.Drawing.Size(682, 26);
            this.txtNomeRazaoSocial.TabIndex = 93;
            this.tlpDicas.SetToolTip(this.txtNomeRazaoSocial, "Favor informar o Nome do Cliente");
            // 
            // lbNomeRazaoSocial
            // 
            this.lbNomeRazaoSocial.AutoSize = true;
            this.lbNomeRazaoSocial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeRazaoSocial.Location = new System.Drawing.Point(377, 10);
            this.lbNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbNomeRazaoSocial.Name = "lbNomeRazaoSocial";
            this.lbNomeRazaoSocial.Size = new System.Drawing.Size(152, 19);
            this.lbNomeRazaoSocial.TabIndex = 98;
            this.lbNomeRazaoSocial.Text = "Nome/Razão Social..:";
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpfCnpj.Culture = new System.Globalization.CultureInfo("");
            this.txtCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpfCnpj.Location = new System.Drawing.Point(175, 30);
            this.txtCpfCnpj.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(156, 26);
            this.txtCpfCnpj.TabIndex = 91;
            this.txtCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCpfCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbCpfCnpj
            // 
            this.lbCpfCnpj.AutoSize = true;
            this.lbCpfCnpj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCpfCnpj.Location = new System.Drawing.Point(175, 10);
            this.lbCpfCnpj.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCpfCnpj.Name = "lbCpfCnpj";
            this.lbCpfCnpj.Size = new System.Drawing.Size(81, 19);
            this.lbCpfCnpj.TabIndex = 95;
            this.lbCpfCnpj.Text = "Cpf/Cnpj..:";
            // 
            // btnCarregaArquivoCnpj
            // 
            this.btnCarregaArquivoCnpj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarregaArquivoCnpj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregaArquivoCnpj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarregaArquivoCnpj.Location = new System.Drawing.Point(477, 198);
            this.btnCarregaArquivoCnpj.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarregaArquivoCnpj.Name = "btnCarregaArquivoCnpj";
            this.btnCarregaArquivoCnpj.Size = new System.Drawing.Size(252, 41);
            this.btnCarregaArquivoCnpj.TabIndex = 121;
            this.btnCarregaArquivoCnpj.Text = "Carregar Arquivo CNPJ";
            this.btnCarregaArquivoCnpj.UseVisualStyleBackColor = false;
            this.btnCarregaArquivoCnpj.Click += new System.EventHandler(this.btnCarregaArquivoCnpj_Click);
            // 
            // btnCarregaArquivoCpf
            // 
            this.btnCarregaArquivoCpf.AutoSize = true;
            this.btnCarregaArquivoCpf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarregaArquivoCpf.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregaArquivoCpf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarregaArquivoCpf.Location = new System.Drawing.Point(753, 198);
            this.btnCarregaArquivoCpf.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarregaArquivoCpf.Name = "btnCarregaArquivoCpf";
            this.btnCarregaArquivoCpf.Size = new System.Drawing.Size(252, 41);
            this.btnCarregaArquivoCpf.TabIndex = 122;
            this.btnCarregaArquivoCpf.Text = "Carregar Arquivo CPF";
            this.btnCarregaArquivoCpf.UseVisualStyleBackColor = false;
            this.btnCarregaArquivoCpf.Click += new System.EventHandler(this.btnCarregaArquivoCpf_Click);
            // 
            // tabInformacoesAdicionais
            // 
            this.tabInformacoesAdicionais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabInformacoesAdicionais.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInformacoesAdicionais.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoesAdicionais.Location = new System.Drawing.Point(4, 24);
            this.tabInformacoesAdicionais.Margin = new System.Windows.Forms.Padding(4);
            this.tabInformacoesAdicionais.Name = "tabInformacoesAdicionais";
            this.tabInformacoesAdicionais.Padding = new System.Windows.Forms.Padding(4);
            this.tabInformacoesAdicionais.Size = new System.Drawing.Size(1415, 253);
            this.tabInformacoesAdicionais.TabIndex = 1;
            this.tabInformacoesAdicionais.Text = "   Informações Adicionais   ";
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 640);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlClientes);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.listViewClientes);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.erpProvider)).EndInit();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.tabControlClientes.ResumeLayout(false);
            this.tabDadosClientes.ResumeLayout(false);
            this.tabDadosClientes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewClientes;
        private System.Windows.Forms.ErrorProvider erpProvider;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label lbTotalRegistros;
        private System.Windows.Forms.TabControl tabControlClientes;
        private System.Windows.Forms.TabPage tabDadosClientes;
        private System.Windows.Forms.TabPage tabInformacoesAdicionais;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPesquisaListView;
        private System.Windows.Forms.Label lbContato;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label lblPesquisaListView;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbUF;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lbMunicipio;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lbEndereco;
        private System.Windows.Forms.RadioButton rdbCnpj;
        private System.Windows.Forms.RadioButton rdbCpf;
        private System.Windows.Forms.MaskedTextBox txtFone_2;
        private System.Windows.Forms.Label lbFone_2;
        private System.Windows.Forms.MaskedTextBox txtFone_1;
        private System.Windows.Forms.Label lbFone_1;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label lbDataCadastro;
        private System.Windows.Forms.TextBox txtNomeRazaoSocial;
        private System.Windows.Forms.Label lbNomeRazaoSocial;
        private System.Windows.Forms.MaskedTextBox txtCpfCnpj;
        private System.Windows.Forms.Label lbCpfCnpj;
        private System.Windows.Forms.ToolTip tlpDicas;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnNovo;
		private System.Windows.Forms.Button btnFechar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnCarregaArquivoCnpj;
		private System.Windows.Forms.ProgressBar progressBarCNPJs;
		private System.Windows.Forms.Label lblProgressoCNPJs;
		private System.Windows.Forms.Button btnCarregaArquivoCpf;
	}
}
