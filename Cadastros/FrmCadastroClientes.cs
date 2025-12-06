using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using OrdemServicos.BLL;
using OrdemServicos.Forms;
using OrdemServicos.Model;
using OrdemServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OrdemServicos.DAL.PesquisaWebDAL;
using static OrdemServicos.Model.PesquisaWebInfo;
using static OrdemServicos.Utils.ListViewUtils;

namespace OrdemServicos
{
    public partial class frmClientes : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private bool leituraAutomaticaAtiva;
        private List<string> listaCNPJs = new List<string>();
        private int indiceAtualCNPJ = 0;
        private string caminhoArquivoDestino = string.Empty;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesMouseMove = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();
        private readonly EventArgs e = new EventArgs();

        public frmClientes()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlClientes);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configuração inicial usando a classe utilitária
            ListViewUtils.ConfigurarListView(
                listViewClientes,
                ListViewClientes_ColumnClick,
                listViewClientes_DrawColumnHeader,
                listViewClientes_DrawItem,
                listViewClientes_DrawSubItem
            );

            // Adicionar colunas
            listViewClientes.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("PESSOA", 80, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CPF/CNPJ", 120, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("NOME/RAZÃO SOCIAL", 300, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("NUMERO", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("BAIRRO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("UF", 30, HorizontalAlignment.Center);
            listViewClientes.Columns.Add("CEP", 70, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("CONTATO", 150, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("CELULAR", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("FIXO", 100, HorizontalAlignment.Right);
            listViewClientes.Columns.Add("EMAIL", 300, HorizontalAlignment.Left);

            var colDataCadastro = listViewClientes.Columns.Add("DATA CADASTRO", 120, HorizontalAlignment.Right);
            colDataCadastro.Width = 120;
        }
        private void ListViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewClientes.SelectedItems.Count == 0) return;

            var item = listViewClientes.SelectedItems[0];

            txtIDCliente.Text = item.SubItems.Count > 0 ? item.SubItems[0].Text : "";
            rdbCpf.Checked = item.SubItems.Count > 1 && item.SubItems[1].Text == "FÍSICA";
            rdbCnpj.Checked = item.SubItems.Count > 1 && item.SubItems[1].Text == "JURÍDICA";
            txtCpf_Cnpj.Text = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";
            txtNome_RazaoSocial.Text = item.SubItems.Count > 3 ? item.SubItems[3].Text : "";
            txtEndereco.Text = item.SubItems.Count > 4 ? item.SubItems[4].Text : "";
            txtNumero.Text = item.SubItems.Count > 5 ? item.SubItems[5].Text : "";
            txtBairro.Text = item.SubItems.Count > 6 ? item.SubItems[6].Text : "";
            txtMunicipio.Text = item.SubItems.Count > 7 ? item.SubItems[7].Text : "";
            txtUF.Text = item.SubItems.Count > 8 ? item.SubItems[8].Text : "";
            txtCep.Text = item.SubItems.Count > 9 ? item.SubItems[9].Text : "";
            txtContato.Text = item.SubItems.Count > 10 ? item.SubItems[10].Text : "";
            txtFone_1.Text = item.SubItems.Count > 11 ? item.SubItems[11].Text : "";
            txtFone_2.Text = item.SubItems.Count > 12 ? item.SubItems[12].Text : "";
            txtEmail.Text = item.SubItems.Count > 13 ? item.SubItems[13].Text : "";
            txtDataCadastro.Text = item.SubItems.Count > 14 ? item.SubItems[14].Text : "";

            EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
        }
        private void ListViewClientes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Permitir apenas cliques nas colunas "CPF/CNPJ" (index 2) e "NOME/RAZÃO SOCIAL" (index 3)
            if (e.Column != 2 && e.Column != 3)
                return; // Ignorar cliques em outras colunas

            // Atualizar a coluna anteriormente ordenada antes de mudar a coluna atual
            int oldSortColumn = sortColumn;
            if (e.Column == sortColumn)
            {
                // Alternar ordem se a mesma coluna for clicada
                sortAscending = !sortAscending;
            }
            else
            {
                // Nova coluna clicada
                sortColumn = e.Column;
                sortAscending = true;
            }

            // Forçar redesenho da coluna anterior
            if (oldSortColumn != -1)
                listViewClientes.Columns[oldSortColumn].Width = listViewClientes.Columns[oldSortColumn].Width;

            // Usar o comparador parametrizado
            listViewClientes.ListViewItemSorter = new ListViewItemComparer(
                e.Column,
                sortAscending,
                new[] { "ID", "CEP", "NUMERO", "CELULAR", "FIXO" },   // colunas numéricas
                new[] { "DATA CADASTRO" },                            // colunas de data
                new string[] { },                                     // colunas monetárias
                new string[] { }                                      // colunas percentuais
            );

            listViewClientes.Sort();

            // Forçar redesenho da nova coluna
            listViewClientes.Columns[sortColumn].Width = listViewClientes.Columns[sortColumn].Width;
            listViewClientes.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho

            txtPesquisaListView.Focus();
        }
        private void listViewClientes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewUtils.DesenharCabecalho(e, sortColumn, Color.DarkTurquoise, Color.CadetBlue);
        }
        private void listViewClientes_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewUtils.DesenharItem(e);
        }
        private void listViewClientes_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewUtils.DesenharSubItem(e, listViewClientes);
        }
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            ListViewUtils.PesquisarListView(txtPesquisaListView.Text, listViewClientes, sortColumn, listaOriginalItens);
        }
        public override async Task CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);

            listViewClientes.Items.Clear(); // limpa apenas os itens

            btnCarregaArquivoCnpj.Enabled = true;
            btnCarregaArquivoCpf.Enabled = true;

            InitializeListView(); // garante colunas

            try
            {
                var clienteBLL = new ClienteBLL();
                var clientes = await clienteBLL.ListarAsync(); // ✅ chamada assíncrona

                foreach (var cliente in clientes)
                {
                    var item = new ListViewItem(cliente.IDCliente.ToString())
                    {
                        Tag = cliente // opcional: guardar objeto original
                    };

                    item.SubItems.Add(cliente.TipoPessoa);
                    item.SubItems.Add(cliente.TipoPessoa == "FÍSICA"
                        ? StringUtils.FormatCPF(cliente.Cpf_Cnpj)
                        : StringUtils.FormatCNPJ(cliente.Cpf_Cnpj));

                    item.SubItems.Add(cliente.Nome_RazaoSocial);
                    item.SubItems.Add(cliente.Endereco);
                    item.SubItems.Add(cliente.Numero);
                    item.SubItems.Add(cliente.Bairro);
                    item.SubItems.Add(cliente.Municipio);
                    item.SubItems.Add(cliente.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(cliente.Cep));
                    item.SubItems.Add(cliente.Contato);
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(cliente.Fone_2));
                    item.SubItems.Add(cliente.Email);
                    item.SubItems.Add(cliente.DataCadastro.ToString("dd/MM/yyyy"));

                    listViewClientes.Items.Add(item);
                }

                listaOriginalItens = listViewClientes.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = $"Total de Registros..: {listViewClientes.Items.Count}";

                // Ordenação inicial
                sortColumn = 3; // Nome/Razão Social
                sortAscending = true;
                listViewClientes.ListViewItemSorter = new ListViewItemComparer(
                    sortColumn,
                    sortAscending,
                    new[] { "ID", "CEP", "NUMERO", "CELULAR", "FIXO" },   // numéricos
                    new[] { "DATA CADASTRO" },                            // datas
                    new string[] { },                                     // monetários
                    new string[] { }                                      // percentuais
                );
                listViewClientes.Sort();

                // Ajustar largura das colunas automaticamente
                listViewClientes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                tabControlClientes.SelectedTab = tabDadosClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar registros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimparCampos();
        }
        private void CarregaKey()
        {
            // Controles que disparam KeyPress
            controlesKeyPress.AddRange(new Control[] {
                txtCpf_Cnpj,
                txtCep,
                txtFone_1,
                txtFone_2
            });

            // Controles que disparam Leave
            controlesLeave.AddRange(new Control[] {
                txtCpf_Cnpj,
                txtCep,
                txtNumero,
                txtFone_1,
                txtFone_2
            });

            // Controles que disparam Enter
            controlesEnter.AddRange(new Control[] {
                txtCpf_Cnpj,
                txtNome_RazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj,
                txtPesquisaListView,
                listViewClientes
            });

            // Controles que disparam MouseDown
            controlesMouseDown.AddRange(new Control[] { });

            // Controles que disparam MouseMove
            controlesMouseMove.AddRange(new Control[] {
                listViewClientes
            });

            // Controles que disparam KeyDown
            controlesKeyDown.AddRange(new Control[] {
                txtCpf_Cnpj,
                txtNome_RazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj,
                txtPesquisaListView,
                listViewClientes
            });

            // Botões
            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo,
                btnCarregaArquivoCpf,
                btnCarregaArquivoCnpj
            });

            // Tag para identificar o formulário
            this.Tag = "frmClientes";

            // Configuração de validação via Tag
            txtCep.Tag = new BaseForm { TagFormato = "FormataCep", TagMaxDigito = 8 };
            txtFone_1.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 11 };
            txtFone_2.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 10 };
            txtCpf_Cnpj.Tag = new BaseForm { TagFormato = "FormataCpfCnpj", TagMaxDigito = 14 };
            txtEmail.Tag = new BaseForm { TagAction = "FocaBotaoSalvar" };

            // Localiza TabControl e TabPage
            var tabControl = Controls.Find("tabControlClientes", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            // Inicializa eventos
            EventosUtils.InicializarEventos(
                Controls,
                controlesKeyPress,
                controlesLeave,
                controlesEnter,
                controlesMouseDown,
                controlesMouseMove,
                controlesKeyDown,
                controlesBotoes,
                this,
                tabControl,
                tabPage
            );

            // Melhor usar SelectedIndexChanged em vez de Click
            listViewClientes.SelectedIndexChanged += ListViewClientes_SelectedIndexChanged;

            // Foco inicial
            if (txtPesquisaListView != null)
                txtPesquisaListView.Focus();
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
   //             (txtCpf_Cnpj, "Cpf_Cnpj"),
    //            (txtNome_RazaoSocial, "Nome"),
    //            (txtCep, "Cep"),
    //            (txtFone_1, "Celular"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );

            List<Control> controlesCampos = new List<Control>
            {
                txtNome_RazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail
            };
            EventosUtils.AjustarCamposTexto(controlesCampos, "DBClientes");
        }
        private void ConfigurarTabIndexControles()
        {
            rdbCpf.TabIndex = 0;
            rdbCnpj.TabIndex = 1;
            txtCpf_Cnpj.TabIndex = 2;
            txtNome_RazaoSocial.TabIndex = 4;
            txtCep.TabIndex = 5;
            txtEndereco.TabIndex = 6;
            txtNumero.TabIndex = 7;
            txtBairro.TabIndex = 8;
            txtMunicipio.TabIndex = 9;
            txtUF.TabIndex = 10;
            txtContato.TabIndex = 11;
            txtFone_1.TabIndex = 12;
            txtFone_2.TabIndex = 13;
            txtEmail.TabIndex = 14;
            btnSalvar.TabIndex = 15;
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDCliente.Enabled = false;
            txtIDCliente.Text = "0";
            bNovo = true;
            leituraAutomaticaAtiva = false;
            HabilitarCamposDoFormulario("Novo");
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var clienteBLL = new ClienteBLL();
            bool isAtualizacao = false;

            if (!string.IsNullOrWhiteSpace(txtIDCliente.Text))
            {
                int idCliente = Convert.ToInt32(txtIDCliente.Text);
                var clienteExistente = await clienteBLL.GetClienteAsync(idCliente); // ✅ chamada assíncrona
                isAtualizacao = clienteExistente != null;
            }

            var cliente = new ClienteInfo
            {
                TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA",
                Cpf_Cnpj = StringUtils.SemFormatacao(txtCpf_Cnpj.Text),
                Nome_RazaoSocial = txtNome_RazaoSocial.Text,
                Endereco = txtEndereco.Text,
                Numero = txtNumero.Text,
                Bairro = txtBairro.Text,
                Municipio = txtMunicipio.Text,
                UF = txtUF.Text,
                Cep = StringUtils.SemFormatacao(txtCep.Text),
                Contato = txtContato.Text,
                Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                Email = txtEmail.Text
            };

            if (!isAtualizacao)
            {
                cliente.DataCadastro = DateTime.Now;

                DialogResult result = DialogResult.Yes; // ✅ pode usar MessageBox se quiser confirmação
                if (result == DialogResult.Yes)
                {
                    InserirClienteAsync(cliente); // ✅ chamada assíncrona
                }
            }
            else
            {
                cliente.IDCliente = Convert.ToInt32(txtIDCliente.Text);

                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja salvar as alterações realizadas?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    AtualizarClienteAsync(cliente); // ✅ chamada assíncrona
                }
            }

            await CarregarRegistros(); // ✅ aguarda recarregamento
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            HabilitarCamposDoFormulario("Alterar");
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDCliente.Text, out int clienteID))
                {
                    ExcluirClienteAsync(clienteID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CarregarRegistros();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarRegistros();
        }
        public override async void ExecutaFuncaoEventoAsync(Control control)
        {
            if (control == txtCpf_Cnpj && !string.IsNullOrEmpty(txtCpf_Cnpj.Text))
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpf_Cnpj.Text);
                var dbSetupBLL = new DBSetupBLL();
                string cpfCnpj = txtCpf_Cnpj.Text;

                if (await dbSetupBLL.VerificarSeCadastradoAsync(cpfcnpj, "DBClientes", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Cliente já Cadastrado. Favor Verificar!",
                                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpf_Cnpj.Clear();
                    txtCpf_Cnpj.Focus();
                    return;
                }

                if (rdbCpf.Checked)
                {
                    if (!ValidaCpf(cpfCnpj))
                    {
                        MessageBox.Show("CPF Informado está Incorreto. Favor Verificar!",
                                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpf_Cnpj.Clear();
                        txtCpf_Cnpj.Focus();
                        return;
                    }
                    else
                    {
                        PesquisarCpf(cpfcnpj);
                    }
                    control.Text = StringUtils.FormatCPF(cpfCnpj);
                }
                else if (rdbCnpj.Checked)
                {
                    if (!ValidaCnpj(cpfCnpj))
                    {
                        MessageBox.Show("CNPJ Informado está Incorreto. Favor Verificar!",
                                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpf_Cnpj.Clear();
                        txtCpf_Cnpj.Focus();
                        return;
                    }
                    else
                    {
                        PesquisarCnpj(cpfcnpj);
                    }
                    control.Text = StringUtils.FormatCNPJ(cpfCnpj);
                }
            }
            else if (control == txtNumero)
            {
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    txtNumero.Text = "S/N";
                }
            }
            else if (control == txtCep && !string.IsNullOrEmpty(txtCep.Text))
            {
                string cep = StringUtils.SemFormatacao(txtCep.Text);
                PesquisaCep(cep);
                control.Text = StringUtils.FormatCEP(cep);
            }
        }
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
            {
                txtCpf_Cnpj,
                txtNome_RazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail,
                rdbCpf,
                rdbCnpj
            };
            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewClientes.Enabled = true;
            txtPesquisaListView.Enabled = true;
            btnCarregaArquivoCnpj.Enabled = true;
            btnCarregaArquivoCpf.Enabled = true;


        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            List<Control> controlesHabilitar = new List<Control>
            {
                txtNome_RazaoSocial,
                txtEndereco,
                txtNumero,
                txtBairro,
                txtMunicipio,
                txtUF,
                txtCep,
                txtContato,
                txtFone_1,
                txtFone_2,
                txtEmail
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            listViewClientes.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    List<Control> controlesHabilitarNovo = new List<Control>
                     {
                        rdbCpf,
                        rdbCnpj,
                        txtCpf_Cnpj
                     };
                    EventosUtils.HabilitarControles(controlesHabilitarNovo, this);
                    rdbCpf.Checked = false;
                    rdbCnpj.Checked = false;
                    txtDataCadastro.Text = DateTime.Now.ToString();
                    rdbCpf.Focus();
                    break;
                case "Alterar":
                    rdbCpf.Enabled = false;
                    rdbCnpj.Enabled = false;
                    txtCpf_Cnpj.Enabled = false;
                    txtNome_RazaoSocial.Focus();
                    break;
            }
            btnCarregaArquivoCnpj.Enabled = false;
            btnCarregaArquivoCpf.Enabled = false;

        }
        public override void LimparCampos()
        {
            txtIDCliente.Clear();
            txtCpf_Cnpj.Clear();
            txtNome_RazaoSocial.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtMunicipio.Clear();
            txtUF.Clear();
            txtCep.Clear();
            txtContato.Clear();
            txtFone_1.Clear();
            txtFone_2.Clear();
            txtEmail.Clear();
            txtDataCadastro.Clear();
            txtPesquisaListView.Clear();
            rdbCpf.Checked = false;
            rdbCnpj.Checked = true;
            escPressed = false;
        }
        private static async Task<bool> InserirClienteAsync(ClienteInfo cliente)
        {
            try
            {
                var clienteBLL = new ClienteBLL();
                await clienteBLL.InserirClienteAsync(cliente); // ✅ chamada assíncrona

                // Opcional: exibir mensagem de sucesso
                // MessageBox.Show("Cliente inserido com sucesso!",
                //                 "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true; // inclusão realizada com sucesso
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false; // falha na inclusão
            }
        }
        private static async Task AtualizarClienteAsync(ClienteInfo cliente)
        {
            try
            {
                var clienteBLL = new ClienteBLL();
                await clienteBLL.AtualizarClienteAsync(cliente); // ✅ chamada assíncrona

                MessageBox.Show("Cliente atualizado com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task ExcluirClienteAsync(int idCliente)
        {
            try
            {
                var clienteBLL = new ClienteBLL();
                await clienteBLL.ExcluirClienteAsync(idCliente); // ✅ chamada assíncrona

                MessageBox.Show("Cliente excluído com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<bool> PesquisarCnpj(string cnpj)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CnpjInfo info = await ReceitaFederalApi.PesquisarCnpjAsync(cnpj);
                if (info != null)
                {
                    txtCpf_Cnpj.Text = info.Cpf_Cnpj;
                    txtNome_RazaoSocial.Text = info.Nome_RazaoSocial;
                    txtEndereco.Text = info.Endereco;
                    txtNumero.Text = info.Numero;
                    txtBairro.Text = info.Bairro;
                    txtMunicipio.Text = info.Municipio;
                    txtUF.Text = info.UF;
                    txtCep.Text = info.Cep;
                    txtContato.Text = info.Contato;
                    txtFone_1.Text = info.Fone_1;
                    txtFone_2.Text = info.Fone_2;
                    txtEmail.Text = info.Email;
                    txtDataCadastro.Text = info.DataCadastro;

                    if (leituraAutomaticaAtiva)
                    {
                        rdbCnpj.Checked = true;
                        rdbCpf.Checked = false;
                        txtIDCliente.Enabled = false;
                        bNovo = true;

                        ClienteInfo cliente = new ClienteInfo
                        {
                            TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA",
                            Cpf_Cnpj = StringUtils.SemFormatacao(txtCpf_Cnpj.Text),
                            Nome_RazaoSocial = txtNome_RazaoSocial.Text,
                            Endereco = txtEndereco.Text,
                            Numero = txtNumero.Text,
                            Bairro = txtBairro.Text,
                            Municipio = txtMunicipio.Text,
                            UF = txtUF.Text,
                            Cep = StringUtils.SemFormatacao(txtCep.Text),
                            Contato = txtContato.Text,
                            Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                            Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                            Email = txtEmail.Text,
                            DataCadastro = DateTime.Now
                        };

                        bool inserido = await InserirClienteAsync(cliente);
                        LimparCampos();
                        return inserido;
                    }

                    if (!leituraAutomaticaAtiva)
                    {
                        txtNome_RazaoSocial.Focus();
                    }

                    return false; // info foi preenchido, mas não houve inclusão
                }
                else if (!leituraAutomaticaAtiva)
                {
                    MessageBox.Show(cnpj + " CNPJ não encontrado ou erro na pesquisa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (!leituraAutomaticaAtiva)
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private async void PesquisarCpf(String cpf)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // Mudar o cursor para ocupado
                CpfInfo info = await ReceitaFederalApi.PesquisarCpfAsync(cpf);
                if (info != null)
                {
                    txtCpf_Cnpj.Text = info.Cpf_Cnpj;
                    txtNome_RazaoSocial.Text = info.Nome_RazaoSocial;
                    txtEndereco.Text = info.Endereco;
                    txtBairro.Text = info.Bairro;
                    txtMunicipio.Text = info.Municipio;
                    txtUF.Text = info.UF;
                    txtCep.Text = info.Cep;
                    txtContato.Text = info.Contato;
                    txtEmail.Text = info.Email;
                    txtNome_RazaoSocial.Focus();
                }
                else
                {
                    MessageBox.Show("CPF não encontrado ou erro na pesquisa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private async void PesquisaCep(String Cep)
        {
            if (!string.IsNullOrEmpty(Cep))
            {
                string cep = StringUtils.SemFormatacao(Cep);
                var resultado = await StringUtils.BuscarCEP(cep);

                if (!string.IsNullOrEmpty(resultado))
                {
                    dynamic dados = JObject.Parse(resultado);
                    txtEndereco.Text = dados.logradouro ?? "";
                    if (string.IsNullOrEmpty(txtNumero.Text))
                    {
                        txtNumero.Clear();
                    }
                    txtBairro.Text = dados.bairro ?? "";
                    txtMunicipio.Text = dados.localidade ?? "";
                    txtUF.Text = dados.uf ?? "";
                }
                else
                {
                    MessageBox.Show("CEP não encontrado ou erro ao buscar o CEP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            txtEndereco.Focus();
        }
        private async void btnCarregaArquivoCnpj_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                openFileDialog.InitialDirectory = downloadsPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        EventosUtils.AcaoBotoes("DesabilitarTodosBotoesAcoes", this);

                        string[] linhas = File.ReadAllLines(filePath);
                        List<string> cnpjsRestantes = new List<string>();
                        int total = linhas.Length;
                        int atual = 0;

                        progressBarCNPJs.Minimum = 0;
                        progressBarCNPJs.Maximum = total;
                        progressBarCNPJs.Value = 0;
                        progressBarCNPJs.Visible = true;
                        lblProgressoCNPJs.Visible = true;
                        lblProgressoCNPJs.Enabled = true;
                        lblProgressoCNPJs.BackColor = Color.Azure;
                        lblProgressoCNPJs.ForeColor = Color.Red;
                        lblProgressoCNPJs.Font = new Font("Times New Roman", 16F, FontStyle.Regular);
                        lblProgressoCNPJs.AutoSize = false;
                        leituraAutomaticaAtiva = true;

                        DBSetupBLL dbSetupBLL = new DBSetupBLL();

                        foreach (string linha in linhas)
                        {
                            string cnpj = linha.Trim();
                            string txt_CNPJ = StringUtils.FormatCNPJ(cnpj);
                            int porcentagem = (int)(((double)atual / total) * 100);
                            lblProgressoCNPJs.Text = $"Processando CNPJ {txt_CNPJ}... ({porcentagem}%)";
                            await Task.Delay(500);

                            bool incluirNoArquivo = true;

                            if (ValidaCnpj(cnpj))
                            {
                                if (await dbSetupBLL.VerificarSeCadastradoAsync(cnpj, "DBClientes", "Cpf_Cnpj"))
                                {
                                        incluirNoArquivo = false;
                                }
                                else
                                {
                                    try
                                    {
                                        bool sucesso = await PesquisarCnpj(cnpj); // retorna true se inclusão no BD foi bem-sucedida
                                        if (sucesso)
                                        {
                                            incluirNoArquivo = false;
                                        }
                                    }
                                    catch {}
                                }
                            }
                            else
                            {
                                incluirNoArquivo = false;
                            }

                            if (incluirNoArquivo)
                            {
                                cnpjsRestantes.Add(cnpj);
                            }

                            atual++;
                            progressBarCNPJs.Value = atual;
                        }

                        // Criar backup antes de sobrescrever
                        string backupFile = filePath + ".bak";
                        File.Copy(filePath, backupFile, true);

                        // Sobrescrever o arquivo original com os CNPJs restantes
                        File.WriteAllLines(filePath, cnpjsRestantes);

                        lblProgressoCNPJs.Text = "Processamento concluído!";
                        MessageBox.Show($"Todos os CNPJs foram processados.\nArquivo atualizado em:\n{filePath}\nBackup salvo em:\n{backupFile}",
                                        "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        progressBarCNPJs.Visible = false;
                        lblProgressoCNPJs.Visible = false;
                        lblProgressoCNPJs.Enabled = false;
                        CarregarRegistros();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao processar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private async void btnCarregaArquivoCpf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                openFileDialog.InitialDirectory = downloadsPath;
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        EventosUtils.AcaoBotoes("DesabilitarTodosBotoesAcoes", this);

                        string[] linhas = File.ReadAllLines(filePath);
                        int total = linhas.Length;
                        int atual = 0;

                        progressBarCNPJs.Minimum = 0;
                        progressBarCNPJs.Maximum = total;
                        progressBarCNPJs.Value = 0;
                        progressBarCNPJs.Visible = true;
                        lblProgressoCNPJs.Visible = true;
                        lblProgressoCNPJs.Enabled = true;
                        lblProgressoCNPJs.BackColor = Color.Azure;
                        lblProgressoCNPJs.ForeColor = Color.Red;
                        lblProgressoCNPJs.Font = new Font("Times New Roman", 16F, FontStyle.Regular);
                        lblProgressoCNPJs.AutoSize = false;
                        leituraAutomaticaAtiva = true;
                        Cursor.Current = Cursors.WaitCursor;

                        foreach (string linha in linhas)
                        {
                            atual++;
                            RegistrarErroLog($"Linha {atual}: {linha}");

                            if (string.IsNullOrWhiteSpace(linha)) continue;

                            int porcentagem = (int)(((double)atual / total) * 100);
                            lblProgressoCNPJs.Text = $"Processando CPF... ({porcentagem}%)";
                            await Task.Delay(500);

                            try
                            {
                                JObject json = JObject.Parse(linha);
                                string cpf = json["cpf"]?.ToString();

                                if (ValidaCpf(cpf))
                                {
                                    try
                                    {
                                        DBSetupBLL dbSetupBLL = new DBSetupBLL();
                                        if (!await dbSetupBLL.VerificarSeCadastradoAsync(cpf, "DBClientes", "Cpf_Cnpj"))

                                        {

                                            CpfInfo info = new CpfInfo
                                            {
                                                Cpf_Cnpj = cpf,
                                                Nome_RazaoSocial = json["nome"]?.ToString(),
                                                DataCadastro = json["data_nascimento"]?.ToString(),
                                                Endereco = json["endereco"]?.ToString(),
                                                Bairro = json["bairro"]?.ToString(),
                                                Municipio = json["municipio"]?.ToString(),
                                                UF = json["uf"]?.ToString(),
                                                Cep = json["cep"]?.ToString(),
                                                Contato = json["telefone"]?.ToString(),
                                                Email = json["email"]?.ToString()
                                            };

                                            // Preenche os campos do formulário
                                            txtCpf_Cnpj.Text = info.Cpf_Cnpj;
                                            txtNome_RazaoSocial.Text = info.Nome_RazaoSocial;
                                            txtEndereco.Text = info.Endereco;
                                            txtBairro.Text = info.Bairro;
                                            txtMunicipio.Text = info.Municipio;
                                            txtUF.Text = info.UF;
                                            txtCep.Text = info.Cep;
                                            txtContato.Text = info.Contato;
                                            txtEmail.Text = info.Email;

                                            rdbCnpj.Checked = false;
                                            rdbCpf.Checked = true;
                                            txtIDCliente.Enabled = false;
                                            bNovo = true;

                                            ClienteInfo cliente = new ClienteInfo
                                            {
                                                TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA",
                                                Cpf_Cnpj = StringUtils.SemFormatacao(txtCpf_Cnpj.Text),
                                                Nome_RazaoSocial = txtNome_RazaoSocial.Text,
                                                Endereco = txtEndereco.Text,
                                                Numero = txtNumero.Text,
                                                Bairro = txtBairro.Text,
                                                Municipio = txtMunicipio.Text,
                                                UF = txtUF.Text,
                                                Cep = StringUtils.SemFormatacao(txtCep.Text),
                                                Contato = txtContato.Text,
                                                Fone_1 = StringUtils.SemFormatacao(txtFone_1.Text),
                                                Fone_2 = StringUtils.SemFormatacao(txtFone_2.Text),
                                                Email = txtEmail.Text,
                                                DataCadastro = DateTime.Now
                                            };
                                            InserirClienteAsync(cliente);
                                            LimparCampos();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        RegistrarErroLog($"Erro ao interpretar JSON na linha {atual}: {ex.Message}");
                                    }

                                    progressBarCNPJs.Value = atual;
                                }

                                lblProgressoCNPJs.Text = "Processamento concluído!";
                                MessageBox.Show("Todos os CPFs foram processados.", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                progressBarCNPJs.Visible = false;
                                lblProgressoCNPJs.Visible = false;
                                lblProgressoCNPJs.Enabled = false;
                                CarregarRegistros();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao processar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default; // Restaurar o cursor padrão
                    }
                }

            }

        }
    }
}