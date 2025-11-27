using AForge.Video;
using AForge.Video.DirectShow;
using OrdemServicos.BLL;
using OrdemServicos.DAL;
using OrdemServicos.Forms;
using OrdemServicos.Model;
using OrdemServicos.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos

{
    public partial class frmProdutos : BaseForm
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
        private readonly EventArgs e = new EventArgs();
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        public frmProdutos()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlProdutos);
            erpProvider = new ErrorProvider();
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            ConfigurarComboBox(cmbFornecedor);
            ConfigurarComboBox(cmbMarca);
            ConfigurarComboBox(cmbModelo);
            ConfigurarComboBox(cmbUnidade);
            CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configurar a ListView
            listViewProdutos.View = View.Details;
            listViewProdutos.FullRowSelect = true;
            listViewProdutos.OwnerDraw = true; // Permitir desenho personalizado
            listViewProdutos.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listViewProdutos_DrawColumnHeader);
            listViewProdutos.DrawItem += new DrawListViewItemEventHandler(listViewProdutos_DrawItem);
            listViewProdutos.DrawSubItem += new DrawListViewSubItemEventHandler(listViewProdutos_DrawSubItem);

            // Adicionar colunas
            listViewProdutos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("CÓD. INTERNO", 120, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("CÓD. FABRICANTE", 120, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("DESCRIÇÃO", 120, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("FORNECEDOR", 300, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("MARCA", 200, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("MODELO", 200, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("UNIDADE", 150, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("PREÇO COMPRA", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("PREÇO VENDA", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ESTOQUE ATUAL", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ESTOQUE MINIMO", 200, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("ULTIMA COMPRA", 100, HorizontalAlignment.Center);

            var colGarantia = listViewProdutos.Columns.Add("GARANTIA", 100, HorizontalAlignment.Left);
            colGarantia.Width = -2; // auto-size

            listViewProdutos.ColumnClick += ListViewProdutos_ColumnClick;
            listViewProdutos.SelectedIndexChanged += ListViewProdutos_SelectedIndexChanged;
        }
        private async void ListViewProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            escPressed = false; // Reseta a variável de controle

            if (listViewProdutos.SelectedItems.Count > 0)
            {
                var item = listViewProdutos.SelectedItems[0];

                txtIDProduto.Text = item.SubItems[0].Text;
                txtIDProdutoInterno.Text = item.SubItems[1].Text;
                txtIDProdutoFabricante.Text = item.SubItems[2].Text;
                txtDescricao.Text = item.SubItems[3].Text;

                // Fornecedor
                string fornecedorNome = item.SubItems[4].Text;
                var fornecedorBLL = new FornecedorBLL();
                var fornecedores = await fornecedorBLL.ListarAsync(); // ✅ chamada assíncrona
                var fornecedor = fornecedores.FirstOrDefault(f => f.Nome_RazaoSocial == fornecedorNome);
                if (fornecedor != null)
                {
                    cmbFornecedor.SelectedValue = fornecedor.IDFornecedor;
                }

                // Marca
                string marcaNome = item.SubItems[5].Text;
                var marcaBLL = new MarcaBLL();
                var marcas = await marcaBLL.ListarAsync(); // ✅ chamada assíncrona
                var marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
                if (marca != null)
                {
                    cmbMarca.SelectedValue = marca.IDMarca;
                }

                // Modelo
                string modeloNome = item.SubItems[6].Text;
                var modeloBLL = new ModeloBLL();
                var modelos = await modeloBLL.ListarAsync(); // ✅ chamada assíncrona
                var modelo = modelos.FirstOrDefault(mo => mo.Descricao == modeloNome);
                if (modelo != null)
                {
                    cmbModelo.SelectedValue = modelo.IDModelo;
                }

                // Unidade
                string unidadeNome = item.SubItems[7].Text;
                var unidadeBLL = new UnidadeBLL();
                var unidades = await unidadeBLL.ListarAsync(); // ✅ chamada assíncrona
                var unidade = unidades.FirstOrDefault(u => u.Descricao == unidadeNome);
                if (unidade != null)
                {
                    cmbUnidade.SelectedValue = unidade.IDUnidade;
                }

                // Preços e estoque
                txtPrecoCompra.Text = item.SubItems[8].Text;
                txtPrecoVenda.Text = item.SubItems[9].Text;
                txtEstoqueAtual.Text = item.SubItems[10].Text;
                txtEstoqueMinimo.Text = item.SubItems[11].Text;
                txtDataUltimaCompra.Text = item.SubItems[12].Text;
                txtGarantia.Text = item.SubItems[13].Text;

                // Exibir imagem
                var produtoBLL = new ProdutoBLL();
                var produto = await produtoBLL.GetProdutoAsync(Convert.ToInt32(item.SubItems[0].Text)); // ✅ assíncrono
                if (produto?.Imagem != null && produto.Imagem.Length > 0)
                {
                    using (var ms = new MemoryStream(produto.Imagem))
                    {
                        imgImagemProduto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    imgImagemProduto.Image = null;
                }

                EventosUtils.AcaoBotoes("HabilitarBotoesAlterarExcluir", this);
            }
        }
        private void ListViewProdutos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != 1 && e.Column != 2 && e.Column != 3)
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
                listViewProdutos.Columns[oldSortColumn].Width = listViewProdutos.Columns[oldSortColumn].Width;
            }
            listViewProdutos.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            listViewProdutos.Sort();
            // Forçar redesenho da nova coluna
            listViewProdutos.Columns[sortColumn].Width = listViewProdutos.Columns[sortColumn].Width;
            listViewProdutos.Invalidate(); // Redesenhar ListView para atualizar a cor do cabeçalho
            txtPesquisaListView.Focus();
        }
        private class ListViewItemComparer : IComparer
        {
            private readonly int col;
            private readonly bool ascending;

            // Colunas tratadas como numéricas
            private readonly HashSet<string> numericColumns = new HashSet<string>
            {
                "ID", "PREÇO COMPRA", "PREÇO VENDA",
                "ESTOQUE ATUAL", "ESTOQUE MINIMO"
            };
            // Colunas tratadas como datas
            private readonly HashSet<string> dateColumns = new HashSet<string>
            {
                 "ULTIMA COMPRA"
            };
            public ListViewItemComparer(int column, bool ascending)
            {
                col = column;
                this.ascending = ascending;
            }
            public int Compare(object x, object y)
            {
                var itemX = x as ListViewItem;
                var itemY = y as ListViewItem;

                if (itemX == null || itemY == null)
                    return 0;

                string valX = itemX.SubItems[col].Text ?? string.Empty;
                string valY = itemY.SubItems[col].Text ?? string.Empty;

                string colName = itemX.ListView.Columns[col].Text.Trim().ToUpper();
                int result;

                if (numericColumns.Contains(colName))
                {
                    // Remove formatação de moeda/unidade antes de comparar
                    valX = StringUtils.SemFormatacao(valX);
                    valY = StringUtils.SemFormatacao(valY);

                    if (decimal.TryParse(valX, out decimal numX) && decimal.TryParse(valY, out decimal numY))
                        result = numX.CompareTo(numY);
                    else
                        result = string.Compare(valX, valY, StringComparison.OrdinalIgnoreCase);
                }
                else if (dateColumns.Contains(colName))
                {
                    if (DateTime.TryParse(valX, out DateTime dtX) && DateTime.TryParse(valY, out DateTime dtY))
                        result = dtX.CompareTo(dtY);
                    else
                        result = string.Compare(valX, valY, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    result = string.Compare(valX, valY, StringComparison.OrdinalIgnoreCase);
                }

                return ascending ? result : -result;
            }
        }
        private void listViewProdutos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
                if (e.Header.Text == "ID" || e.Header.Text == "CÓD. INTERNO" || e.Header.Text == "CÓD. FABRICANTE" || e.Header.Text == "PREÇO COMPRA" || e.Header.Text == "PREÇO VENDA" || e.Header.Text == "ESTOQUE ATUAL" || e.Header.Text == "ESTOQUE MINIMO")
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
        private void listViewProdutos_DrawItem(object sender, DrawListViewItemEventArgs e)
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
        private void listViewProdutos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                if (listViewProdutos.Columns[e.ColumnIndex].Text == "ID" || listViewProdutos.Columns[e.ColumnIndex].Text == "CÓD. INTERNO" || listViewProdutos.Columns[e.ColumnIndex].Text == "CÓD. FABRICANTE" || listViewProdutos.Columns[e.ColumnIndex].Text == "PREÇO COMPRA" || listViewProdutos.Columns[e.ColumnIndex].Text == "PREÇO VENDA" || listViewProdutos.Columns[e.ColumnIndex].Text == "ESTOQUE ATUAL"
                     || listViewProdutos.Columns[e.ColumnIndex].Text == "ESTOQUE MINIMO")
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
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            PesquisarListView(txtPesquisaListView.Text, listViewProdutos, sortColumn);
        }
        private void PesquisarListView(string texto, ListView listView, int coluna)
        {
            listView.BeginUpdate();
            var itemsVisiveis = new List<ListViewItem>();

            foreach (ListViewItem item in listaOriginalItens)
            {
                string valorCelula = item.SubItems[coluna].Text;

                if (string.IsNullOrEmpty(texto) || valorCelula.StartsWith(texto, StringComparison.OrdinalIgnoreCase))
                    itemsVisiveis.Add(item);
            }

            listView.Items.Clear();
            listView.Items.AddRange(itemsVisiveis.ToArray());
            listView.EndUpdate();
        }
        private void CarregaKey()
        {
            // Controles que disparam KeyPress
            controlesKeyPress.AddRange(new Control[] {
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo
             });

            // Controles que disparam Leave
            controlesLeave.AddRange(new Control[] {
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtGarantia,
                cmbFornecedor,
                cmbMarca,
                cmbModelo,
                cmbUnidade
             });

            // Controles que disparam Enter
            controlesEnter.AddRange(new Control[] {
                txtIDProdutoInterno,
                txtIDProdutoFabricante,
                txtDescricao,
                cmbFornecedor,
                cmbMarca,
                cmbModelo,
                cmbUnidade,
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtDataUltimaCompra,
                txtGarantia,
                txtPesquisaListView,
                listViewProdutos
             });

            // Controles que disparam MouseDown
            controlesMouseDown.AddRange(new Control[] { });

            // Controles que disparam MouseMove
            controlesMouseMove.AddRange(new Control[] {
                listViewProdutos
             });

            // Controles que disparam KeyDown
            controlesKeyDown.AddRange(new Control[] {
                txtIDProdutoInterno,
                txtIDProdutoFabricante,
                txtDescricao,
                cmbFornecedor,
                cmbMarca,
                cmbModelo,
                cmbUnidade,
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtDataUltimaCompra,
                txtGarantia,
                txtPesquisaListView,
                listViewProdutos
             });

            // Botões
            controlesBotoes.AddRange(new Control[] {
                btnSalvar,
                btnAlterar,
                btnExcluir,
                btnFechar,
                btnCancelar,
                btnNovo,
                btnInserirImagem,
                btnExcluirImagem
             });

            // Tag para identificar o formulário
            this.Tag = "frmProdutos";

            // Configuração de validação via Tag
            txtPrecoCompra.Tag = new BaseForm { TagFormato = "FormatoMoeda", TagAction = "TabPage" }; // Formato de moeda e ação de TabPage
            txtPrecoVenda.Tag = new BaseForm { TagFormato = "FormatoMoeda" }; // Formato de moeda
            txtEstoqueAtual.Tag = new BaseForm { TagFormato = "FormatoUnidade" }; // Formato de moed
            txtEstoqueMinimo.Tag = new BaseForm { TagFormato = "FormatoUnidade" }; // Formato de moed
            txtGarantia.Tag = new BaseForm { TagAction = "FocaBotaoSalvar" };

            // Localiza TabControl e TabPage
            var tabControl = Controls.Find("tabControlProdutos", true).FirstOrDefault() as TabControl;
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
            listViewProdutos.SelectedIndexChanged += ListViewProdutos_SelectedIndexChanged;

            // Foco inicial
            if (txtPesquisaListView != null)
                txtPesquisaListView.Focus();
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                /*
                (txtIDProduto, "IDProduto"),
                (txtIDProdutoInterno, "IDProdutoInterno"),
                (txtIDProdutoFabricante, "IDProdutoFabricante"),
                (txtDescricao, "Descricao"),
                (cmbFornecedor, "IDFornecedor"),
                (cmbMarca, "IDMarca"),
                (cmbModelo, "IDModelo"),
                (cmbUnidade, "IDUnidade"),
                (txtPrecoCompra, "PrecoCompra"),
                (txtPrecoVenda, "PrecoVenda"),
                (txtEstoqueAtual, "EstoqueAtual"),
                */
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
            List<Control> controlesCampos = new List<Control>
            {
                txtIDProdutoFabricante,
                txtIDProdutoInterno,
                txtDescricao,
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtGarantia
            };
            EventosUtils.AjustarCamposTexto(controlesCampos, "DBProdutos");
        }
        private void ConfigurarTabIndexControles()
        {
            txtIDProdutoInterno.TabIndex = 0;
            txtIDProdutoFabricante.TabIndex = 1;
            txtDescricao.TabIndex = 2;
            cmbFornecedor.TabIndex = 3;
            cmbMarca.TabIndex = 4;
            cmbModelo.TabIndex = 5;
            cmbUnidade.TabIndex = 6;
            txtPrecoCompra.TabIndex = 7;
            txtPrecoVenda.TabIndex = 8;
            txtEstoqueAtual.TabIndex = 9;
            txtEstoqueMinimo.TabIndex = 10;
            txtGarantia.TabIndex = 11;
            btnSalvar.TabIndex = 12;
        }
        public override async Task CarregarRegistros()
        {
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewProdutos.Items.Clear();
            InitializeListView();

            try
            {
                var produtoBLL = new ProdutoBLL();
                var produtos = await produtoBLL.ListarAsync(); // ✅ chamada assíncrona

                foreach (var produto in produtos)
                {
                    var item = new ListViewItem(produto.IDProduto.ToString());
                    item.SubItems.Add(produto.IDProdutoInterno);
                    item.SubItems.Add(produto.IDProdutoFabricante);
                    item.SubItems.Add(produto.Descricao);
                    item.SubItems.Add(produto.Fornecedor);
                    item.SubItems.Add(produto.Marca);
                    item.SubItems.Add(produto.Modelo);
                    item.SubItems.Add(produto.Unidade);
                    item.SubItems.Add(StringUtils.FormatValorMoeda(produto.PrecoCompra.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorMoeda(produto.PrecoVenda.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorUnidade(produto.EstoqueAtual.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorUnidade(produto.EstoqueMinimo.ToString()));
                    item.SubItems.Add(produto.DataUltimaCompra.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(produto.Garantia);

                    if (produto.Imagem != null && produto.Imagem.Length > 0)
                    {
                        using (var ms = new MemoryStream(produto.Imagem))
                        {
                            // Se quiser exibir a imagem em algum PictureBox, pode atribuir aqui
                            var imgImagemProduto = Image.FromStream(ms);
                        }
                    }

                    listViewProdutos.Items.Add(item);
                }

                // Ajuste automático das colunas
                foreach (ColumnHeader column in listViewProdutos.Columns)
                {
                    column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    int headerWidth = TextRenderer.MeasureText(column.Text, listViewProdutos.Font).Width + 20;
                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    if (column.Width < headerWidth)
                    {
                        column.Width = headerWidth;
                    }
                }

                listaOriginalItens = listViewProdutos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = "Total de Registros: " + listViewProdutos.Items.Count;

                sortColumn = 3;
                sortAscending = true;
                listViewProdutos.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
                listViewProdutos.Sort();
                listViewProdutos.Columns[sortColumn].Width = listViewProdutos.Columns[sortColumn].Width;

                // 🔠 Carregar fornecedores ordenados
                var fornecedorBLL = new FornecedorBLL();
                var fornecedores = (await fornecedorBLL.ListarAsync()) // ✅ assíncrono
                    .OrderBy(f => f.Nome_RazaoSocial?.ToUpperInvariant())
                    .ToList();
                cmbFornecedor.DataSource = fornecedores;
                cmbFornecedor.DisplayMember = "Nome_RazaoSocial";
                cmbFornecedor.ValueMember = "IDFornecedor";

                // 🔠 Carregar marcas ordenadas
                var marcaBLL = new MarcaBLL();
                var marcas = (await marcaBLL.ListarAsync()) // ✅ assíncrono
                    .OrderBy(m => m.Descricao?.ToUpperInvariant())
                    .ToList();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";

                // 🔠 Carregar unidades ordenadas
                var unidadeBLL = new UnidadeBLL();
                var unidades = (await unidadeBLL.ListarAsync()) // ✅ assíncrono
                    .OrderBy(u => u.Descricao?.ToUpperInvariant())
                    .ToList();
                cmbUnidade.DataSource = unidades;
                cmbUnidade.DisplayMember = "Descricao";
                cmbUnidade.ValueMember = "IDUnidade";

                tabControlProdutos.SelectedTab = tabDadosProduto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimparCampos();
        }
        public override async void ExecutaFuncaoEventoAsync(Control control)
        {
            if (control == cmbFornecedor)
            {
                string fornecedorDigitado = cmbFornecedor.Text.ToUpper(); // Converte para maiúsculas
                cmbFornecedor.Text = fornecedorDigitado; // Atualiza o texto no ComboBox
                if (!await FornecedorExisteAsync(fornecedorDigitado) && !string.IsNullOrEmpty(fornecedorDigitado))
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"Cliente '{fornecedorDigitado}' não Cadastrado", "Cliente não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmClientes
                            frmFornecedores frm = new frmFornecedores();
                            frm.ShowDialog();

                            // Carregar clientes no ComboBox em ordem alfabética crescente
                            var fornecedorBLL = new FornecedorBLL();
                            var fornecedor = (await fornecedorBLL.ListarAsync())
                                .OrderBy(c => c.Nome_RazaoSocial?.ToUpperInvariant())
                                .ToList();
                            cmbFornecedor.DataSource = fornecedor;
                            cmbFornecedor.DisplayMember = "Nome_RazaoSocial";
                            cmbFornecedor.ValueMember = "IDFornecedor";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cmbFornecedor.Text = string.Empty;
                    cmbFornecedor.Focus();
                }
                if (string.IsNullOrEmpty(fornecedorDigitado))
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFornecedor.Focus();
                }
            }
            else if (control == cmbMarca)
            {
                string marcaDigitada = cmbMarca.Text.ToUpper(); // Converte para maiúsculas
                cmbMarca.Text = marcaDigitada; // Atualiza o texto no ComboBox
                if (!await MarcaExisteAsync(marcaDigitada) && !string.IsNullOrEmpty(marcaDigitada))
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"A Marca '{marcaDigitada}' não Existe. Deseja Cadastrá-la?", "Marca não Encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmMarcas
                            frmMarcas frm = new frmMarcas();
                            frm.ShowDialog();

                            // Carregar marcas no ComboBox
                            var marcaBLL = new MarcaBLL();
                            var marcas = (await marcaBLL.ListarAsync())
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
            else if (control == cmbModelo)
            {
                string modeloDigitado = cmbModelo.Text.ToUpper(); // Converte para maiúsculas
                cmbModelo.Text = modeloDigitado; // Atualiza o texto no ComboBox
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue); // Método para obter o ID da marca selecionada
                if (!await ModeloExisteAsync(idMarca, modeloDigitado) && modeloDigitado != string.Empty && idMarca != 0)
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"O Modelo '{modeloDigitado}' não Existe para a Marca Selecionada. Deseja Cadastrá-lo?", "Modelo não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmProdutos
                            frmProdutos frm = new frmProdutos();
                            frm.ShowDialog();
                            if (cmbMarca.SelectedValue != null)
                            {
                                int idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
                                CarregarModelosPorMarcaAsync(idmarca);
                            }
                        }
                        else
                        {
                            cmbModelo.Text = string.Empty;
                            cmbModelo.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (modeloDigitado == string.Empty || idMarca == 0)
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbModelo.Focus();
                }
            }
            else if (control == cmbUnidade)
            {
                string unidadeDigitado = cmbUnidade.Text.ToUpper(); // Converte para maiúsculas
                cmbUnidade.Text = unidadeDigitado; // Atualiza o texto no ComboBox
                if (unidadeDigitado == string.Empty)
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbUnidade.Focus();
                }
            }

        }
        private void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedValue != null)
            {
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                CarregarModelosPorMarcaAsync(idMarca);
            }
        }
        private async Task<bool> FornecedorExisteAsync(string nome_RazaoSocial)
        {
            var fornecedorBLL = new FornecedorBLL();
            var fornecedores = await fornecedorBLL.ListarAsync(); // ✅ chamada assíncrona
            return fornecedores.Any(f => f.Nome_RazaoSocial.Equals(nome_RazaoSocial, StringComparison.OrdinalIgnoreCase));
        }
        private async Task<bool> MarcaExisteAsync(string descricao)
        {
            var marcaBLL = new MarcaBLL();
            var marcas = await marcaBLL.ListarAsync(); // ✅ chamada assíncrona
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private async Task<bool> ModeloExisteAsync(int idMarca, string descricao)
        {
            var modeloBLL = new ModeloBLL(); // melhor usar BLL em vez de DAL direto
            var modelos = await modeloBLL.ListarPorMarcaAsync(idMarca); // ✅ chamada assíncrona
            return modelos.Any(mo => mo.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private async Task CarregarModelosPorMarcaAsync(int idMarca)
        {
            var modeloBLL = new ModeloBLL();
            var modelos = (await modeloBLL.ListarPorMarcaAsync(idMarca)) // ✅ chamada assíncrona
                .OrderBy(mo => mo.Descricao?.ToUpperInvariant())
                .ToList();

            if (modelos.Count > 0)
            {
                cmbModelo.DataSource = modelos;
                cmbModelo.DisplayMember = "Descricao";
                cmbModelo.ValueMember = "IDModelo";
            }
            else
            {
                cmbModelo.DataSource = null;
                cmbModelo.Items.Clear();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDProduto.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var produtoBLL = new ProdutoBLL();
            var dbSetupBLL = new DBSetupBLL();
            bool isAtualizacao = false;

            // Verifica se já existe ID informado
            if (!string.IsNullOrWhiteSpace(txtIDProduto.Text))
            {
                int idProduto = Convert.ToInt32(txtIDProduto.Text);
                var produtoExistente = await produtoBLL.GetProdutoAsync(idProduto); // ✅ chamada assíncrona
                isAtualizacao = produtoExistente != null;
            }

            var produto = new ProdutoInfo
            {
                IDProdutoInterno = txtIDProdutoInterno.Text,
                IDProdutoFabricante = txtIDProdutoFabricante.Text,
                Descricao = txtDescricao.Text,
                IDFornecedor = Convert.ToInt32(cmbFornecedor.SelectedValue),
                IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                IDModelo = Convert.ToInt32(cmbModelo.SelectedValue),
                IDUnidade = Convert.ToInt32(cmbUnidade.SelectedValue),
                PrecoCompra = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoCompra.Text)),
                PrecoVenda = Convert.ToDecimal(StringUtils.SemFormatacao(txtPrecoVenda.Text)),
                EstoqueAtual = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueAtual.Text)),
                EstoqueMinimo = Convert.ToDecimal(StringUtils.SemFormatacao(txtEstoqueMinimo.Text)),
                Garantia = txtGarantia.Text,
                Imagem = ImageToByteArray(imgImagemProduto.Image)
            };

            if (!isAtualizacao)
            {
                // Verifica duplicidade de códigos
                if (await dbSetupBLL.VerificarSeCadastradoAsync(produto.IDProdutoInterno, "DBProdutos", "IDProdutoInterno"))
                {
                    MessageBox.Show("Código de Produto Interno já cadastrado. Favor verificar!",
                                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (await dbSetupBLL.VerificarSeCadastradoAsync(produto.IDProdutoFabricante, "DBProdutos", "IDProdutoFabricante"))
                {
                    MessageBox.Show("Código de Produto do Fabricante já cadastrado. Favor verificar!",
                                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                produto.DataUltimaCompra = DateTime.Now;

                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja incluir esse produto?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await produtoBLL.InserirProdutoAsync(produto); // ✅ chamada assíncrona
                }
            }
            else
            {
                produto.IDProduto = Convert.ToInt32(txtIDProduto.Text);

                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja salvar as alterações realizadas?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await produtoBLL.AtualizarProdutoAsync(produto); // ✅ chamada assíncrona
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
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDProduto.Text, out int produtoID))
                {
                    ExcluirProdutoAsync(produtoID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtIDProdutoInterno,
                txtIDProdutoFabricante,
                txtDescricao,
                cmbFornecedor,
                cmbMarca,
                cmbModelo,
                cmbUnidade,
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtDataUltimaCompra,
                txtGarantia
            };
            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewProdutos.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            List<Control> controlesHabilitar = new List<Control>
            {
                txtIDProdutoFabricante,
                txtDescricao,
                cmbFornecedor,
                cmbMarca,
                cmbModelo,
                cmbUnidade,
                txtPrecoCompra,
                txtPrecoVenda,
                txtEstoqueAtual,
                txtEstoqueMinimo,
                txtGarantia
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            listViewProdutos.Enabled = false;
            txtPesquisaListView.Enabled = false;
            switch (buttonPressed)
            {
                case "Novo":
                    txtDataUltimaCompra.Text = DateTime.Now.ToString();
                    txtIDProdutoInterno.Enabled = true;
                    txtIDProdutoInterno.Focus();
                    break;
                case "Alterar":
                    txtIDProdutoFabricante.Focus();
                    break;
            }
        }
        private new void LimparCampos()
        {
            txtIDProdutoInterno.Clear();
            txtIDProdutoFabricante.Clear();
            txtDescricao.Clear();
            cmbFornecedor.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbModelo.SelectedIndex = -1;
            cmbUnidade.SelectedIndex = -1;
            txtPrecoCompra.Clear();
            txtPrecoVenda.Clear();
            txtEstoqueAtual.Clear();
            txtEstoqueMinimo.Clear();
            txtDataUltimaCompra.Clear();
            txtGarantia.Clear();
            imgImagemProduto.Image = null;
            txtPesquisaListView.Clear();
            bNovo = false;
            escPressed = false;
        }
        private static async Task InserirProdutoAsync(ProdutoInfo produto)
        {
            try
            {
                var produtoBLL = new ProdutoBLL();
                await produtoBLL.InserirProdutoAsync(produto); // ✅ chamada assíncrona
                MessageBox.Show("Produto inserido com sucesso!",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task AtualizarProdutoAsync(ProdutoInfo produto)
        {
            try
            {
                var produtoBLL = new ProdutoBLL();
                await produtoBLL.AtualizarProdutoAsync(produto); // ✅ chamada assíncrona
                MessageBox.Show("Produto atualizado com sucesso!",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task ExcluirProdutoAsync(int idProduto)
        {
            try
            {
                var produtoBLL = new ProdutoBLL();
                await produtoBLL.ExcluirProdutoAsync(idProduto); // ✅ chamada assíncrona
                MessageBox.Show("Produto excluído com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInserirImagem_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                // Remover a barra de título
                form.Size = new Size(380, 186);
                form.FormBorderStyle = FormBorderStyle.None;

                // Evento de pintura para aplicar o gradiente no formulário
                form.Paint += new PaintEventHandler(BaseForm_Paint);

                // Centralizar e alinhar componentes
                int formWidth = form.ClientSize.Width;
                int formHeight = form.ClientSize.Height;

                // Definindo a Label
                var labelTitle = new Label
                {
                    Text = "Escolha uma opção",
                    Font = new Font("Times New Roman", 16, FontStyle.Bold),
                    Size = new Size(230, 26),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent, // Definindo fundo transparente
                    Location = new Point((formWidth - 230) / 2, 26)
                };
                form.Controls.Add(labelTitle);

                // Definindo os Botões
                var btnLocal = new Button
                {
                    Text = "Local",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };
                var btnWebcam = new Button
                {
                    Text = "WebCam",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };
                var btnFechar = new Button
                {
                    Text = "Fechar",
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    Size = new Size(98, 40),
                    BackColor = buttonBackgroundColor,
                    ForeColor = buttonFontColor
                };

                // Adicionando eventos de mouse aos botões
                btnLocal.MouseEnter += Button_MouseEnterImg;
                btnLocal.MouseLeave += Button_MouseLeaveImg;
                btnWebcam.MouseEnter += Button_MouseEnterImg;
                btnWebcam.MouseLeave += Button_MouseLeaveImg;
                btnFechar.MouseEnter += Button_MouseEnterImg;
                btnFechar.MouseLeave += Button_MouseLeaveImg;

                // Calculando a posição inicial para centralizar os botões
                int totalButtonWidth = 3 * 98 + 20; // 3 botões de 98px cada e 10px de espaço entre eles
                int startX = (formWidth - totalButtonWidth) / 2;
                int buttonY = (formHeight / 2) + 20;

                // Posicionando os botões
                btnLocal.Location = new Point(startX, buttonY);
                btnWebcam.Location = new Point(startX + 98 + 10, buttonY); // 10px de espaço entre os botões
                btnFechar.Location = new Point(startX + 2 * 98 + 20, buttonY); // 20px de espaço entre os botões

                // Adicionando eventos aos botões
                btnLocal.Click += BtnLocal_Click;
                btnWebcam.Click += BtnWebcam_Click;
                btnFechar.Click += (s, ee) => form.Close();

                // Adicionando botões ao formulário
                form.Controls.Add(btnLocal);
                form.Controls.Add(btnWebcam);
                form.Controls.Add(btnFechar);

                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }
        private void Button_MouseEnterImg(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = buttonFontColor; // Cor de fundo ao passar o mouse
                button.ForeColor = buttonBackgroundColor; // Cor da fonte ao passar o mouse
            }
        }
        private void Button_MouseLeaveImg(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = buttonBackgroundColor; // Cor de fundo original
                button.ForeColor = buttonFontColor; // Cor da fonte original
            }
        }
        private void BtnLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obter o caminho do arquivo selecionado
                    string filePath = openFileDialog.FileName;
                    // Exibir a imagem no PictureBox
                    imgImagemProduto.Image = Image.FromFile(filePath);
                    imgImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private void BtnWebcam_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Webcam";
                form.Size = new Size(800, 600);

                var pictureBoxWebcam = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                form.Controls.Add(pictureBoxWebcam);

                var btnCapture = new Button
                {
                    Text = "Capturar",
                    Dock = DockStyle.Bottom
                };
                form.Controls.Add(btnCapture);

                NewFrameEventHandler newFrameHandler = null;

                try
                {
                    videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    if (videoDevices == null || videoDevices.Count == 0)
                    {
                        MessageBox.Show("Nenhum dispositivo de vídeo encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Escolhe o primeiro dispositivo disponível (índice 0)
                    var moniker = videoDevices[0].MonikerString;
                    videoSource = new VideoCaptureDevice(moniker);

                    // Handler com remoção possível
                    newFrameHandler = (s, eFrame) =>
                    {
                        try
                        {
                            var bitmap = (Bitmap)eFrame.Frame.Clone();
                            if (pictureBoxWebcam.InvokeRequired)
                            {
                                pictureBoxWebcam.Invoke(new Action(() =>
                                {
                                    var old = pictureBoxWebcam.Image;
                                    pictureBoxWebcam.Image = bitmap;
                                    old?.Dispose();
                                }));
                            }
                            else
                            {
                                var old = pictureBoxWebcam.Image;
                                pictureBoxWebcam.Image = bitmap;
                                old?.Dispose();
                            }
                        }
                        catch
                        {
                            // não propagar exceção de frame; opcional: log
                        }
                    };

                    videoSource.NewFrame += newFrameHandler;
                    videoSource.Start();

                    btnCapture.Click += (s, eCapture) =>
                    {
                        try
                        {
                            // Para a captura antes de clonar para evitar race
                            if (videoSource != null && videoSource.IsRunning)
                            {
                                videoSource.SignalToStop();
                                videoSource.WaitForStop();
                            }
                        }
                        catch { /* ignorar falha de parada, mas tentar prosseguir */ }

                        if (pictureBoxWebcam.Image == null)
                        {
                            MessageBox.Show("Nenhum frame disponível para captura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Clona a imagem para o PictureBox principal
                        var captured = (Image)pictureBoxWebcam.Image.Clone();
                        imgImagemProduto.Image?.Dispose();
                        imgImagemProduto.Image = captured;
                        imgImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage;

                        form.Close();
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao acessar dispositivos de vídeo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                form.StartPosition = FormStartPosition.CenterParent;
                form.FormClosing += (s, eClosing) =>
                {
                    try
                    {
                        if (videoSource != null)
                        {
                            if (videoSource.IsRunning)
                            {
                                videoSource.SignalToStop();
                                videoSource.WaitForStop();
                            }
                            if (newFrameHandler != null)
                                videoSource.NewFrame -= newFrameHandler;
                        }
                    }
                    catch { /* ignorar erros no fechamento */ }
                };
                form.ShowDialog(this);
            }
        }
        private void btnExcluirImagem_Click(object sender, EventArgs e)
        {
            // Limpar a imagem do PictureBox
            imgImagemProduto.Image = null;
        }
        private void imgImagemProduto_Click(object sender, EventArgs e)
        {
            imgImagemProduto.Cursor = Cursors.AppStarting;
            // Obtém o objeto selecionado no ComboBox
            var modeloInfo = cmbModelo.SelectedItem as ModeloInfo;
            if (modeloInfo != null)
            {
                // Obtém a descrição completa do modelo
                string modelo = modeloInfo.Descricao;
                // Codifica a descrição para ser usada na URL
                string encodedModelo = Uri.EscapeDataString(modelo);
                // Cria a URL de pesquisa no Google
                string url = $"https://www.google.com/search?q={encodedModelo}";
                // Abre o navegador padrão com a URL de pesquisa
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else
            {
                MessageBox.Show("Por favor, selecione um modelo.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            imgImagemProduto.Cursor = Cursors.Hand;
        }
    }
}
