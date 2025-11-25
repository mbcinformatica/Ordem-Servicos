using OrdemServicos.BLL;
using OrdemServicos.Forms;
using OrdemServicos.Model;
using OrdemServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace OrdemServicos
{
    public partial class frmModelos : BaseForm
    {
        private int sortColumn = -1;
        private bool sortAscending = true;
        private Color defaultHeaderBackColor = Color.DarkTurquoise;
        private Color clickedHeaderBackColor = Color.CadetBlue;
        private (Control, string)[] camposObrigatorios;
        private List<ListViewItem> listaOriginalItens = new List<ListViewItem>();
        private List<Control> controlesKeyPress = new List<Control>();
        private List<Control> controlesLeave = new List<Control>();
        private List<Control> controlesEnter = new List<Control>();
        private List<Control> controlesMouseDown = new List<Control>();
        private List<Control> controlesMouseMove = new List<Control>();
        private List<Control> controlesBotoes = new List<Control>();
        private List<Control> controlesKeyDown = new List<Control>();

        public frmModelos()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlModelos);
            erpProvider = new ErrorProvider();
            ConfigurarComboBoxMarcas();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewModelos.View = View.Details;
            listViewModelos.FullRowSelect = true;
            listViewModelos.OwnerDraw = true; // Permitir desenho personalizado
            listViewModelos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewModelos_DrawColumnHeader);
            listViewModelos.DrawItem += new DrawListViewItemEventHandler(listViewModelos_DrawItem);
            listViewModelos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewModelos_DrawSubItem);
            // Adicionar colunas
            listViewModelos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewModelos.Columns.Add("  MARCA", 370, HorizontalAlignment.Left);
            listViewModelos.Columns.Add("  DESCRIÇÃO", 1000, HorizontalAlignment.Left);
            // Adicionar evento de clique no cabeçalho da coluna
            listViewModelos.ColumnClick += new ColumnClickEventHandler(ListViewModelos_ColumnClick);
        }
        private void ListViewModelos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1 && e.Column != 2)
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
                listViewModelos.Columns[oldSortColumn].Width = listViewModelos.Columns[oldSortColumn].Width;
            }
            listViewModelos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewModelos.Sort();
            // Forçar redesenho da nova coluna
            listViewModelos.Columns[sortColumn].Width = listViewModelos.Columns[sortColumn].Width;
            listViewModelos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
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
            PesquisarListView(txtPesquisaListView.Text, listViewModelos, sortColumn);
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
        private void listViewModelos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
                if (e.Header.Text == "ID")

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
        private void listViewModelos_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewModelos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewModelos.Columns[e.ColumnIndex].Text == "ID")
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
            // Adicionar controles às listas específicas com base no tipo de evento
            controlesKeyPress.AddRange(new Control[] {
                cmbMarca
            });

            controlesLeave.AddRange(new Control[] {
                cmbMarca,
                txtDescricao
            });

            controlesEnter.AddRange(new Control[] {
                cmbMarca,
                txtDescricao,
                txtPesquisaListView,
                listViewModelos
            });

            controlesMouseDown.AddRange(new Control[] { });

            controlesMouseMove.AddRange(new Control[] {
                 listViewModelos
            });

            controlesKeyDown.AddRange(new Control[] {
                cmbMarca,
                txtDescricao,
                txtPesquisaListView,
                listViewModelos
            });

            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo
            });

            // Definir a propriedade Tag para comportamentos específicos
            this.Tag = "frmModelos";

            txtDescricao.Tag = new BaseForm { TagAction = "TabPage" }; // Permitir somente letras

            // Localizar o TabControl e a TabPage
            var tabControl = Controls.Find("tabDadosModelo", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabInformacoesAdicionais"];

            // Inicializar eventos para os controles
            EventosUtils.InicializarEventos(Controls, controlesKeyPress, controlesLeave, controlesEnter, controlesMouseDown, controlesMouseMove, controlesKeyDown, controlesBotoes, this, tabControl, tabPage);

            listViewModelos.Click += ListViewModelos_Click;

            // Focar no btnNovo ao iniciar
            txtPesquisaListView.Focus();
        }
        private void ConfigurarTabIndexControles()
        {

            cmbMarca.TabIndex = 0;
            txtDescricao.TabIndex = 1;
            btnSalvar.TabIndex = 2;
        }
        private bool MarcaExiste(string descricao)
        {
            MarcaBLL marcaBLL = new MarcaBLL();
            List<MarcaInfo> marcas = marcaBLL.Listar();
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private void ConfigurarComboBoxMarcas()
        {
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public override void ExecutaFuncaoEvento(Control control)
        {
            if (control == cmbMarca)
            {
                string marcaDigitada = cmbMarca.Text.ToUpper(); // Converte para maiúsculas
                cmbMarca.Text = marcaDigitada; // Atualiza o texto no ComboBox
                if (!MarcaExiste(marcaDigitada) && !string.IsNullOrEmpty(marcaDigitada))
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"A Marca '{marcaDigitada}' não Existe. Deseja Cadastrá-la?", "Marca não Encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmMarcas
                            frmMarcas frm = new frmMarcas();
                            frm.ShowDialog();
                            MarcaBLL marcaBLL = new MarcaBLL();
                            List<MarcaInfo> marcas = marcaBLL.Listar()
                                .OrderBy(m => m.Descricao?.ToUpperInvariant())
                                .ToList();
                            cmbMarca.DataSource = marcas;
                            cmbMarca.DisplayMember = "Descricao";
                            cmbMarca.ValueMember = "IDMarca";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cmbMarca.Text = string.Empty;
                    cmbMarca.Focus();
                }
                if (string.IsNullOrEmpty(marcaDigitada))
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMarca.Focus();
                }
            }

        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                 (cmbMarca, "IDMarca"),
                 (txtDescricao, "Descricao"),
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
            List<Control> controlesCampos = new List<Control>
            {
                txtDescricao
            };
            EventosUtils.AjustarCamposTexto(controlesCampos, "DBModelos");
        }
        public override void CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewModelos.Items.Clear();
            listViewModelos.Columns.Clear();
            InitializeListView();
            try
            {
                ModeloBLL modeloBLL = new ModeloBLL();
                List<ModeloInfo> modelos = modeloBLL.Listar();
                foreach (ModeloInfo modelo in modelos)
                {
                    ListViewItem item = new ListViewItem(modelo.IDModelo.ToString());
                    item.SubItems.Add(modelo.Marca); // Usar o nome da marca
                    item.SubItems.Add(modelo.Descricao);
                    listViewModelos.Items.Add(item);
                }

                listaOriginalItens = listViewModelos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewModelos.Items.Count;
                sortColumn = 2;
                sortAscending = true;
                listViewModelos.Sort();
                listViewModelos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                tabControlModelos.SelectedTab = tabDadosModelo;

                MarcaBLL marcaBLL = new MarcaBLL();
                List<MarcaInfo> marcas = marcaBLL.Listar()
                    .OrderBy(m => m.Descricao?.ToUpperInvariant())
                    .ToList();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimparCampos();
        }
        private void ListViewModelos_Click(object sender, EventArgs e)
        {
            escPressed = false; // Reseta a variável de controle
            try
            {
                if (listViewModelos.SelectedItems.Count > 0)
                {
                    ListViewItem item = listViewModelos.SelectedItems[0];
                    txtIDModelo.Text = item.SubItems[0].Text;
                    string marcaNome = item.SubItems[1].Text; // Índice da coluna da marca
                    MarcaBLL marcaBLL = new MarcaBLL();
                    List<MarcaInfo> marcas = marcaBLL.Listar();
                    MarcaInfo marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
                    if (marca != null)
                    {
                        cmbMarca.SelectedValue = marca.IDMarca;
                    }
                    txtDescricao.Text = item.SubItems[2].Text;
                    EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDModelo.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ModeloBLL modeloBLL = new ModeloBLL();
            // Verificar se algum campo obrigatório está vazio
            if (!ValidarCamposObrigatorios(camposObrigatorios, erpProvider))
            {
                MessageBox.Show("Favor, Preencha Todos os Campos Obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isAtualizacao = false;
            if (!string.IsNullOrEmpty(txtIDModelo.Text))
            {
                int idModelo = Convert.ToInt32(txtIDModelo.Text);
                isAtualizacao = modeloBLL.GetModelo(idModelo) != null;
            }
            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Incluir Esse Modelo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ModeloInfo modelo = new ModeloInfo
                    {
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        Descricao = txtDescricao.Text,
                    };
                    InserirModelo(modelo);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem Certeza que Deseja Salvar as Alterações Realizadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ModeloInfo modelo = new ModeloInfo
                    {
                        IDModelo = int.Parse(txtIDModelo.Text),
                        IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                        Descricao = txtDescricao.Text,
                    };
                    AtualizarModelo(modelo);
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Modelo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDModelo.Text, out int modeloID))
                {
                    ExcluirModelo(modeloID);
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
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
        {
            cmbMarca,
            txtDescricao
        };
            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewModelos.Enabled = true;
            txtPesquisaListView.Enabled = true;

        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {

            listViewModelos.Enabled = false;
            txtPesquisaListView.Enabled = false;

            List<Control> controlesHabilitar = new List<Control>
            {
            cmbMarca,
            txtDescricao
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            switch (buttonPressed)
            {
                case "Novo":
                    cmbMarca.Focus();
                    break;
                case "Alterar":
                    cmbMarca.Focus();
                    break;
            }
        }
        public override void LimparCampos()
        {
            txtIDModelo.Clear();
            cmbMarca.SelectedIndex = -1;
            txtDescricao.Clear();
            txtPesquisaListView.Clear();
            bNovo = false;
        }
        static void InserirModelo(ModeloInfo Modelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.InserirModelo(Modelo);
                MessageBox.Show("Modelo Inserido com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void AtualizarModelo(ModeloInfo Modelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.AtualizarModelo(Modelo);
                MessageBox.Show("Modelo Atualizado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void ExcluirModelo(int idModelo)
        {
            try
            {
                ModeloBLL ModeloBLL = new ModeloBLL();
                ModeloBLL.ExcluirModelo(idModelo);
                MessageBox.Show("Modelo Excluído com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
