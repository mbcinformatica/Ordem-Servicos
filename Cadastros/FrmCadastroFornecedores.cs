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

namespace OrdemServicos
{
    public partial class frmFornecedores : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private bool leituraAutomaticaAtiva ;
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

        public frmFornecedores()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlFornecedores);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewFornecedores.View = View.Details;
            listViewFornecedores.FullRowSelect = true;
            listViewFornecedores.OwnerDraw = true; // Permitir desenho personalizado
            listViewFornecedores.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewFornecedores_DrawColumnHeader);
            listViewFornecedores.DrawItem += new DrawListViewItemEventHandler(listViewFornecedores_DrawItem);
            listViewFornecedores.DrawSubItem += new DrawListViewSubItemEventHandler(listViewFornecedores_DrawSubItem);

            // Adicionar colunas
            listViewFornecedores.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("PESSOA", 80, HorizontalAlignment.Center);
            listViewFornecedores.Columns.Add("CPF/CNPJ", 120, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  NOME/RAZÃO SOCIAL", 300, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("  ENDEREÇO", 200, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("NUMERO", 70, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  BAIRRO", 150, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("  MUNICIPIO", 200, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("UF", 30, HorizontalAlignment.Center);
            listViewFornecedores.Columns.Add("CEP", 70, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  CONTATO", 150, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("CELULAR", 100, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("FIXO", 100, HorizontalAlignment.Right);
            listViewFornecedores.Columns.Add("  EMAIL", 300, HorizontalAlignment.Left);
            listViewFornecedores.Columns.Add("DATA CADASTRO", 150, HorizontalAlignment.Right);

            listViewFornecedores.ColumnClick += new ColumnClickEventHandler(ListViewFornecedores_ColumnClick);

        }
        private void ListViewFornecedores_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Permitir apenas cliques nas colunas "CPF/CNPJ" (index 2) e "NOME/RAZÃO SOCIAL" (index 3)
            if (e.Column != 2 && e.Column != 3)
            {
                return; // Ignorar cliques em outras colunas
            }

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
            {
                listViewFornecedores.Columns[oldSortColumn].Width = listViewFornecedores.Columns[oldSortColumn].Width;
            }

            listViewFornecedores.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewFornecedores.Sort();

            // Forçar redesenho da nova coluna
            listViewFornecedores.Columns[sortColumn].Width = listViewFornecedores.Columns[sortColumn].Width;
            listViewFornecedores.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
            txtPesquisaListView.Focus();
        }
        public class ListViewItemComparer : IComparer
        {
            private int col;
            private bool ascending;

            public ListViewItemComparer(int column, bool ascending)
            {
                this.col = column;
                this.ascending = ascending;
            }
            public int Compare(object x, object y)
            {
                // Comparar valores das subitens
                int returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                              ((ListViewItem)y).SubItems[col].Text);
                return ascending ? returnVal : -returnVal; // Ordem crescente ou decrescente
            }
        }
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            PesquisarListView(txtPesquisaListView.Text, listViewFornecedores, sortColumn);
        }
        private void PesquisarListView(string texto, ListView listView, int coluna)
        {
            listView.BeginUpdate();
            var itemsVisiveis = new List<ListViewItem>();

            foreach (ListViewItem item in listaOriginalItens)
            {
                if (item.SubItems[coluna].Text.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    itemsVisiveis.Add(item);
                }
            }

            listView.Items.Clear();
            listView.Items.AddRange(itemsVisiveis.ToArray());
            listView.EndUpdate();
            listView.Invalidate(); // Redesenha a ListView para refletir as mudanças
        }
        private void listViewFornecedores_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedHeaderBackColor : defaultHeaderBackColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap; // Adiciona esta linha para evitar quebra de linha

                if (e.Header.Text == "ID" || e.Header.Text == "PESSOA" || e.Header.Text == "CPF/CNPJ" ||
                    e.Header.Text == "UF" || e.Header.Text == "CEP" || e.Header.Text == "NUMERO" ||
                    e.Header.Text == "CELULAR" || e.Header.Text == "FIXO" || e.Header.Text == "DATA CADASTRO")
                {
                    sf.Alignment = StringAlignment.Center; // Alinhar cabeçalhos numéricos no centro
                }
                else
                {
                    sf.Alignment = StringAlignment.Near; // Alinhar cabeçalhos de texto à esquerda
                }

                // Definir a fonte em negrito
                using (Font headerFont = new Font(e.Font, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }

                using (Pen gridLinePen = new Pen(Color.Black, 2)) // Define a cor e a espessura das linhas do cabeçalho
                {
                    e.Graphics.DrawRectangle(gridLinePen, e.Bounds);
                }
            }
        }
        private void listViewFornecedores_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Alternar cores das linhas
            if (e.ItemIndex % 2 == 0)
            {
                e.Item.BackColor = Color.White;
            }
            else
            {
                e.Item.BackColor = Color.LightBlue;
            }
            e.DrawDefault = true;
        }
        private void listViewFornecedores_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewFornecedores.Columns[e.ColumnIndex].Text == "ID" || listViewFornecedores.Columns[e.ColumnIndex].Text == "PESSOA" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CPF/CNPJ" || listViewFornecedores.Columns[e.ColumnIndex].Text == "UF" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CEP" || listViewFornecedores.Columns[e.ColumnIndex].Text == "NUMERO" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "CELULAR" || listViewFornecedores.Columns[e.ColumnIndex].Text == "FIXO" ||
                    listViewFornecedores.Columns[e.ColumnIndex].Text == "DATA CADASTRO")
                {
                    sf.Alignment = StringAlignment.Far; // Alinhar conteúdo numérico à direita
                }
                else
                {
                    sf.Alignment = StringAlignment.Near; // Alinhar conteúdo de texto à esquerda
                }
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, Brushes.Black, e.Bounds, sf);
            }
        }
        private void CarregaKey()
        {
            controlesKeyPress.AddRange(new Control[] {
                txtCpfCnpj,
                txtCep,
                txtFone_1,
                txtFone_2
            });
            controlesLeave.AddRange(new Control[] {
                txtCpfCnpj,
                txtCep,
                txtNumero,
                txtFone_1,
                txtFone_2
            });
            controlesEnter.AddRange(new Control[] {
                txtCpfCnpj,
                txtNomeRazaoSocial,
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
                listViewFornecedores
            });

            controlesMouseDown.AddRange(new Control[] { });

            controlesMouseMove.AddRange(new Control[] {
                 listViewFornecedores
            });

            controlesKeyDown.AddRange(new Control[] {
                txtCpfCnpj,
                txtNomeRazaoSocial,
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
                listViewFornecedores
            });

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

            this.Tag = "frmFornecedores";

            txtCep.Tag = new BaseForm { TagFormato = "FormataCep", TagMaxDigito = 8 };
            txtFone_1.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 11 };
            txtFone_2.Tag = new BaseForm { TagFormato = "FormataFone", TagMaxDigito = 10 };
            txtCpfCnpj.Tag = new BaseForm { TagFormato = "FormataCpfCnpj", TagMaxDigito = 14 };
            txtEmail.Tag = new BaseForm { TagAction = "FocaBotaoSalvar" };

            var tabControl = Controls.Find("tabControlFornecedores", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesMouseMove, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

            listViewFornecedores.Click += ListViewFornecedores_Click;
            txtPesquisaListView.Focus();
        }
        private void ConfigurarTabIndexControles()
        {
            rdbCpf.TabIndex = 0;
            rdbCnpj.TabIndex = 1;
            txtCpfCnpj.TabIndex = 2;
            txtNomeRazaoSocial.TabIndex = 4;
            txtCep.TabIndex = 5;
            txtEndereco.TabIndex = 7;
            txtNumero.TabIndex = 8;
            txtBairro.TabIndex = 9;
            txtMunicipio.TabIndex = 10;
            txtUF.TabIndex = 11;
            txtContato.TabIndex = 12;
            txtFone_1.TabIndex = 13;
            txtFone_2.TabIndex = 14;
            txtEmail.TabIndex = 15;
            btnSalvar.TabIndex = 16;
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
   //             (txtCpfCnpj, "Cpf_Cnpj"),
    //            (txtNomeRazaoSocial, "Nome"),
    //            (txtCep, "Cep"),
    //            (txtFone_1, "Celular"),
            };

            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
        }
        public override void CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewFornecedores.Items.Clear();
            listViewFornecedores.Columns.Clear();
            btnCarregaArquivoCnpj.Enabled = true;
            btnCarregaArquivoCpf.Enabled = true;

            InitializeListView(); // Adicionar colunas novamente, caso necessário

            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                List<FornecedorInfo> fornecedores = fornecedorBLL.Listar();
                foreach (FornecedorInfo fornecedor in fornecedores)
                {
                    ListViewItem item = new ListViewItem(fornecedor.IDFornecedor.ToString());
                    item.SubItems.Add(fornecedor.TipoPessoa);
                    if (fornecedor.TipoPessoa == "FÍSICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCPF(fornecedor.Cpf_Cnpj));
                    }
                    else if (fornecedor.TipoPessoa == "JURÍDICA")
                    {
                        item.SubItems.Add(StringUtils.FormatCNPJ(fornecedor.Cpf_Cnpj));
                    }
                    item.SubItems.Add(fornecedor.Nome_RazaoSocial);
                    item.SubItems.Add(fornecedor.Endereco);
                    item.SubItems.Add(fornecedor.Numero);
                    item.SubItems.Add(fornecedor.Bairro);
                    item.SubItems.Add(fornecedor.Municipio);
                    item.SubItems.Add(fornecedor.UF);
                    item.SubItems.Add(StringUtils.FormatCEP(fornecedor.Cep));
                    item.SubItems.Add(fornecedor.Contato);
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(fornecedor.Fone_1));
                    item.SubItems.Add(StringUtils.FormatPhoneNumber(fornecedor.Fone_2));
                    item.SubItems.Add(fornecedor.Email);
                    item.SubItems.Add(fornecedor.DataCadastro.ToString("dd/MM/yyyy"));
                    listViewFornecedores.Items.Add(item);
                }
                listaOriginalItens = listViewFornecedores.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros..:  " + listViewFornecedores.Items.Count;
                sortColumn = 3;
                sortAscending = true;
                listViewFornecedores.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewFornecedores.Sort();
                ajustaLarguraCabecalho(listViewFornecedores);
                tabControlFornecedores.SelectedTab = tabDadosFornecedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar registros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimparCampos();
        }
        private void ListViewFornecedores_Click(object sender, EventArgs e)
        {
            escPressed = false;
            if (listViewFornecedores.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewFornecedores.SelectedItems[0];
                txtIDFornecedor.Text = item.SubItems[0].Text;
                // Carregar os RadioButton com base no valor do campo TipoPessoa
                rdbCpf.Checked = item.SubItems[1].Text == "FÍSICA";
                rdbCnpj.Checked = item.SubItems[1].Text == "JURÍDICA";
                txtCpfCnpj.Text = item.SubItems[2].Text;
                txtNomeRazaoSocial.Text = item.SubItems[3].Text;
                txtEndereco.Text = item.SubItems[4].Text;
                txtNumero.Text = item.SubItems[5].Text;
                txtBairro.Text = item.SubItems[6].Text;
                txtMunicipio.Text = item.SubItems[7].Text;
                txtUF.Text = item.SubItems[8].Text;
                txtCep.Text = item.SubItems[9].Text;
                txtContato.Text = item.SubItems[10].Text;
                txtFone_1.Text = item.SubItems[11].Text;
                txtFone_2.Text = item.SubItems[12].Text;
                txtEmail.Text = item.SubItems[13].Text;
                txtDataCadastro.Text = item.SubItems[14].Text;
                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            btnCarregaArquivoCnpj.Enabled = false;
            btnCarregaArquivoCpf.Enabled = false;
            txtIDFornecedor.Enabled = false;
            txtIDFornecedor.Text = "0";
            bNovo = true;
            leituraAutomaticaAtiva = false;
            HabilitarCamposDoFormulario("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            FornecedorBLL fornecedorBLL = new FornecedorBLL();
            bool isAtualizacao = false;

            if (!string.IsNullOrEmpty(txtIDFornecedor.Text))
            {
                int idFornecedor = Convert.ToInt32(txtIDFornecedor.Text);
                isAtualizacao = fornecedorBLL.GetFornecedor(idFornecedor) != null;
            }

            if (!isAtualizacao)
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();

                DialogResult result = DialogResult.Yes;
                if (result == DialogResult.Yes)
                {
                    FornecedorInfo fornecedor = new FornecedorInfo
                    {
                        TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA", // Define o valor do RadioButton
                        Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                        Nome_RazaoSocial = txtNomeRazaoSocial.Text,
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
                    InserirFornecedor(fornecedor);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Ralizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FornecedorInfo fornecedor = new FornecedorInfo
                    {
                        IDFornecedor = int.Parse(txtIDFornecedor.Text),
                        TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA", // Define o valor do RadioButton
                        Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                        Nome_RazaoSocial = txtNomeRazaoSocial.Text,
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
                    };
                    AtualizarFornecedor(fornecedor);
                }
            }
            CarregarRegistros();
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
                if (int.TryParse(txtIDFornecedor.Text, out int fornecedorID))
                {
                    ExcluirFornecedor(fornecedorID);
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarRegistros();
        }
        public override void ExecutaFuncaoEvento(Control control)
        {
            if (control == txtCpfCnpj && !string.IsNullOrEmpty(txtCpfCnpj.Text))
            {
                string cpfcnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text);
                DBSetupBLL dbSetupBLL = new DBSetupBLL();
                string cpfCnpj = txtCpfCnpj.Text;
                if (dbSetupBLL.VerificarSeCadastrado(cpfcnpj, "DBFornecedores", "Cpf_Cnpj"))
                {
                    MessageBox.Show("Fornecedor já Cadastrado. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Clear();
                    txtCpfCnpj.Focus();
                    return;
                }
                if (rdbCpf.Checked)
                {
                    if (!ValidaCpf(cpfCnpj))
                    {
                        MessageBox.Show("CPF informado está incorreto. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
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
                        MessageBox.Show("CNPJ informado está incorreto. Favor verificar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
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
                txtCpfCnpj,
                txtNomeRazaoSocial,
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
            listViewFornecedores.Enabled = true;
            txtPesquisaListView.Enabled = true;
            btnCarregaArquivoCnpj.Enabled = true;
            btnCarregaArquivoCpf.Enabled = true;

        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            List<Control> controlesHabilitar = new List<Control>
            {
                txtNomeRazaoSocial,
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
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            listViewFornecedores.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    List<Control> controlesHabilitarNovo = new List<Control>
                     {
                        rdbCpf,
                        rdbCnpj,
                        txtCpfCnpj
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
                    txtCpfCnpj.Enabled = false;
                    txtNomeRazaoSocial.Focus();
                    break;
            }
            btnCarregaArquivoCnpj.Enabled = false;
            btnCarregaArquivoCpf.Enabled = false;

        }
        public override void LimparCampos()
        {
            txtIDFornecedor.Clear();
            txtCpfCnpj.Clear();
            txtNomeRazaoSocial.Clear();
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
            rdbCpf.Checked = true;
            rdbCnpj.Checked = false;
            escPressed = false;
        }
        static bool InserirFornecedor(FornecedorInfo Fornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.InserirFornecedor(Fornecedor);
                //              MessageBox.Show("Fornecedor inserido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true; // inclusão realizada com sucesso
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // falha na inclusão

            }
        }
        static void AtualizarFornecedor(FornecedorInfo Fornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.AtualizarFornecedor(Fornecedor);
                MessageBox.Show("Fornecedor atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirFornecedor(int idFornecedor)
        {
            try
            {
                FornecedorBLL fornecedorBLL = new FornecedorBLL();
                fornecedorBLL.ExcluirFornecedor(idFornecedor);
                MessageBox.Show("Fornecedor excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtCpfCnpj.Text = info.Cpf_Cnpj;
                    txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
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
                        txtIDFornecedor.Enabled = false;
                        bNovo = true;

                        FornecedorInfo fornecedor = new FornecedorInfo
                        {
                            TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA",
                            Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                            Nome_RazaoSocial = txtNomeRazaoSocial.Text,
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

                        bool inserido = InserirFornecedor(fornecedor);
                        LimparCampos();
                        return inserido;
                    }

                    if (!leituraAutomaticaAtiva)
                    {
                        txtNomeRazaoSocial.Focus();
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
                    txtCpfCnpj.Text = info.Cpf_Cnpj;
                    txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
                    txtEndereco.Text = info.Endereco;
                    txtBairro.Text = info.Bairro;
                    txtMunicipio.Text = info.Municipio;
                    txtUF.Text = info.UF;
                    txtCep.Text = info.Cep;
                    txtContato.Text = info.Contato;
                    txtEmail.Text = info.Email;
                    txtNomeRazaoSocial.Focus();
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
            if (!string.IsNullOrEmpty(txtCep.Text))
            {
                string cep = StringUtils.SemFormatacao(txtCep.Text);
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
                                if (dbSetupBLL.VerificarSeCadastrado(cnpj, "DBFornecedores", "Cpf_Cnpj"))
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
                                    catch { }
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
                                        if (!dbSetupBLL.VerificarSeCadastrado(cpf, "DBFornecedores", "Cpf_Cnpj"))
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
                                            txtCpfCnpj.Text = info.Cpf_Cnpj;
                                            txtNomeRazaoSocial.Text = info.Nome_RazaoSocial;
                                            txtEndereco.Text = info.Endereco;
                                            txtBairro.Text = info.Bairro;
                                            txtMunicipio.Text = info.Municipio;
                                            txtUF.Text = info.UF;
                                            txtCep.Text = info.Cep;
                                            txtContato.Text = info.Contato;
                                            txtEmail.Text = info.Email;

                                            rdbCnpj.Checked = false;
                                            rdbCpf.Checked = true;
                                            txtIDFornecedor.Enabled = false;
                                            bNovo = true;

                                            FornecedorInfo fornecedor = new FornecedorInfo
                                            {
                                                TipoPessoa = rdbCpf.Checked ? "FÍSICA" : "JURÍDICA",
                                                Cpf_Cnpj = StringUtils.SemFormatacao(txtCpfCnpj.Text),
                                                Nome_RazaoSocial = txtNomeRazaoSocial.Text,
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
                                            InserirFornecedor(fornecedor);
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
