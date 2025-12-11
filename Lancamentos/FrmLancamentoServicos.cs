using OrdemServicos.BLL;
using OrdemServicos.DAL;
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
using static OrdemServicos.Utils.ListViewUtils;

namespace OrdemServicos
{
    public partial class frmLancamentoServicos : BaseForm
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

        public frmLancamentoServicos()
        {
            InitializeComponent();
            LoadConfig();
            Paint += new System.Windows.Forms.PaintEventHandler(BaseForm_Paint);
            InitializeTabControl(tabControlOrdenServico); // Chama o método para inicializar o TabControl
            erpProvider = new ErrorProvider();
            ConfigurarComboBox(cmbMarca);
            ConfigurarComboBox(cmbCliente);
            ConfigurarComboBox(cmbProduto);
            ConfigurarTextBox();
            CarregaKey();
            ConfigurarTabIndexControles();
            InitializeListView(); // garante colunas
            Task task = CarregarRegistros();
        }
        private void InitializeListView()
        {
            // Configuração inicial usando a classe utilitária
            ListViewUtils.ConfigurarListView(
                listViewLancamentoServicos,
                listViewLancamentoServicos_ColumnClick,
                listViewLancamentoServicos_DrawColumnHeader,
                listViewLancamentoServicos_DrawItem
            );

            // Adicionar colunas
            listViewLancamentoServicos.Columns.Add("ID", 50, HorizontalAlignment.Right);
            listViewLancamentoServicos.Columns.Add("DATA EMISSÃO", 200, HorizontalAlignment.Center);
            listViewLancamentoServicos.Columns.Add("DATA CONCLUSÃO", 200, HorizontalAlignment.Center);
            listViewLancamentoServicos.Columns.Add("CLIENTE", 120, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("MARCA", 200, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("PRODUTO", 150, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("NUMERO DE SÉRIE", 200, HorizontalAlignment.Right);
            listViewLancamentoServicos.Columns.Add("DESCRIÇÃO DO DEFEITO", 200, HorizontalAlignment.Left);
            listViewLancamentoServicos.Columns.Add("VALOR TOTAL SERVIÇO", 200, HorizontalAlignment.Right);

            var colValorTotalMaterial = listViewLancamentoServicos.Columns.Add(" VALOR TOTAL MATERIAIS", 200, HorizontalAlignment.Right);
            colValorTotalMaterial.Width = 200;

            listViewLancamentoServicos.SelectedIndexChanged += ListViewLancamentoServicos_SelectedIndexChanged;
            cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
            txtPesquisaListView.Enter += txtPesquisaListView_Enter;
        }

        private async void ListViewLancamentoServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPesquisaListView.Focused) return;
            txtPesquisaListView.Clear();
            txtPesquisaListView.Text = "";
            escPressed = false;
            if (listViewLancamentoServicos.SelectedItems.Count == 0) return;

            var item = listViewLancamentoServicos.SelectedItems[0];

            txtIDOrdenServico.Text = item.SubItems.Count > 0 ? item.SubItems[0].Text : "";
            txtDataEmissao.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
            txtDataConclusao.Text = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";

            // Cliente
            string clienteNome = item.SubItems.Count > 3 ? item.SubItems[3].Text : "";
            var clienteBLL = new ClienteBLL();
            var clientes = await clienteBLL.ListarAsync();
            var cliente = clientes.FirstOrDefault(c => c.Nome_RazaoSocial == clienteNome);
            if (cliente != null)
                cmbCliente.SelectedValue = cliente.IDCliente;

            // Marca
            string marcaNome = item.SubItems.Count > 4 ? item.SubItems[4].Text : "";
            var marcaBLL = new MarcaBLL();
            var marcas = await marcaBLL.ListarAsync();
            var marca = marcas.FirstOrDefault(m => m.Descricao == marcaNome);
            if (marca != null)
                cmbMarca.SelectedValue = marca.IDMarca;

            // Produto
            string produtoNome = item.SubItems.Count > 5 ? item.SubItems[5].Text : "";
            var produtoBLL = new ProdutoBLL();
            var produtos = await produtoBLL.ListarAsync();
            var produto = produtos.FirstOrDefault(p => p.Descricao == produtoNome);
            if (produto != null)
                cmbProduto.SelectedValue = produto.IDProduto;

            // Demais campos
            txtNumeroSerie.Text = item.SubItems.Count > 6 ? item.SubItems[6].Text : "";
            txtDescricaoDefeito.Text = item.SubItems.Count > 7 ? item.SubItems[7].Text : "";
            txtValorTotalServico.Text = item.SubItems.Count > 8 ? item.SubItems[8].Text : "";
            txtValorTotalMaterial.Text = item.SubItems.Count > 9 ? item.SubItems[9].Text : "";

            // Exibir a imagem no PictureBox
            var lancamentoServicoBLL = new LancamentoServicoBLL();
            var lancamentoServico = await lancamentoServicoBLL.GetLancamentoServicoAsync(
                                        Convert.ToInt32(item.SubItems[0].Text));

            if (lancamentoServico?.Imagem != null && lancamentoServico.Imagem.Length > 0)
            {
                using (var ms = new MemoryStream(lancamentoServico.Imagem))
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

        private void listViewLancamentoServicos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewUtils.HandleColumnClick(
                listViewLancamentoServicos,
                e,
                ref sortColumn,
                ref sortAscending,
                new[] {
                            "ID"
                            },   // colunas numéricas
                new[] {
                            "DATA EMISSÃO",
                            "DATA CONCLUSÃO"
                            },                            // colunas de data
                new string[] {
                                        "VALOR TOTAL SERVIÇO",
                                        "VALOR TOTAL MATERIAIS"
                                        },                                     // colunas monetárias
                new string[] { },                                     // colunas percentuais
                txtPesquisaListView,                                  // campo de pesquisa
                new[] { 0, 3 }                                        // colunas permitidas (CPF/CNPJ e Nome)
            );
        }
        private void listViewLancamentoServicos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            string[] colunasCentralizadas = {
                "ID",
                "DATA EMISSÃO",
                "DATA CONCLUSÃO",
                "VALOR TOTAL SERVIÇO",
                "VALOR TOTAL MATERIAIS"
            };

            ListViewUtils.DesenharCabecalho(
                e,
                sortColumn,
                listViewHeaderDefaultColor,
                listViewHeaderSelectedColor,
                listViewHeaderFontFamily,
                listViewHeaderFontSize,
                listViewHeaderFontStyle,
                colunasCentralizadas
            );
        }
        private void listViewLancamentoServicos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewUtils.DesenharItem(e, listViewItemBackColorEven, listViewItemBackColorOdd);
        }
        private void txtPesquisaListView_TextChanged(object sender, EventArgs e)
        {
            ListViewUtils.PesquisarListView(txtPesquisaListView.Text, listViewLancamentoServicos, sortColumn, listaOriginalItens);
        }
        private void txtPesquisaListView_Enter(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void CarregaKey()
        {
            // Adicionar controles às listas específicas com base no tipo de evento
            controlesKeyPress.AddRange(new Control[] {
                cmbCliente,
                cmbMarca,
                cmbProduto,
                txtIDOrdenServico
            });

            controlesLeave.AddRange(new Control[] {
                txtValorTotalServico,
                txtValorTotalMaterial,
                txtDataEmissao,
                txtDataConclusao,
                cmbCliente,
                cmbMarca,
                cmbProduto
            });

            controlesEnter.AddRange(new Control[] {
                txtDataConclusao,
                txtValorTotalServico,
                txtValorTotalMaterial,
                cmbCliente,
                cmbMarca,
                cmbProduto,
                txtNumeroSerie,
                txtDescricaoDefeito,
                txtPesquisaListView,
                txtIDOrdenServico
            });

            controlesMouseDown.AddRange(new Control[] {
                txtIDOrdenServico
            });

            controlesMouseMove.AddRange(new Control[] {
                 listViewLancamentoServicos
            });

            controlesKeyDown.AddRange(new Control[] {
                txtDataEmissao,
                txtDataConclusao,
                cmbCliente,
                cmbMarca,
                cmbProduto,
                txtNumeroSerie,
                txtDescricaoDefeito,
                txtValorTotalServico,
                txtValorTotalMaterial,
                txtPesquisaListView,
                listViewLancamentoServicos
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
            this.Tag = "frmLancamentoServicos";
            txtIDOrdenServico.Tag = new BaseForm { TagAction = "no-input" }; // Bloquear qualquer entrada

            txtValorTotalMaterial.Tag = new BaseForm { TagFormato = "FormatoMoeda", TagAction = "TabPage" }; // Formato de moeda e ação de TabPage
            txtValorTotalServico.Tag = new BaseForm { TagFormato = "FormatoMoeda" }; // Formato de moeda

            txtNumeroSerie.Tag = new BaseForm { TagAction = "SomenteLetras" }; // Permitir somente letras
            txtDataEmissao.Tag = new BaseForm { TagAction = "data-inicial" }; // Tag específica para txtDataEmissao
            txtDataConclusao.Tag = new BaseForm { TagAction = "data-final" }; // Tag específica para txtDataConclusao

            // Localizar o TabControl e a TabPage
            var tabControl = Controls.Find("tabControlOrdenServico", true).FirstOrDefault() as TabControl;
            var tabPage = tabControl?.TabPages["tabDadosCliente"];

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

            // Associar eventos SelectedIndexChanged e Click
            listViewLancamentoServicos.Click += ListViewLancamentoServicos_SelectedIndexChanged;
            cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
            txtPesquisaListView.Enter += txtPesquisaListView_Enter;

            AdicionarToolTipsAosControles();
        }
        private void AdicionarToolTipsAosControles()
        {
            List<ControlToolTipPair> controlToolTipPairs = new List<ControlToolTipPair>
        {
            new ControlToolTipPair { Control = txtDataEmissao, ToolTipText = "Data de Emissão da Ordem de Serviço" },
            new ControlToolTipPair { Control = txtDataConclusao, ToolTipText = "Data de Conclusão da Ordem de Serviço" },
            new ControlToolTipPair { Control = cmbCliente, ToolTipText = "Selecione o Cliente" },
            new ControlToolTipPair { Control = cmbMarca, ToolTipText = "Selecione a Marca" },
            new ControlToolTipPair { Control = cmbProduto, ToolTipText = "Selecione o Produto" },
            new ControlToolTipPair { Control = txtNumeroSerie, ToolTipText = "Digite o Número de Série" },
            new ControlToolTipPair { Control = txtDescricaoDefeito, ToolTipText = "Descreva o Defeito" },
            new ControlToolTipPair { Control = txtValorTotalServico, ToolTipText = "Valor Total do Serviço" },
            new ControlToolTipPair { Control = txtValorTotalMaterial, ToolTipText = "Valor Total do Material" },
            new ControlToolTipPair { Control = txtPesquisaListView, ToolTipText = "Inserir Informações para Pesquisa" }

        };
            EventosUtils.AdicionarToolTips(this, controlToolTipPairs, tlpDicas);
        }
        private void ConfigurarTabIndexControles()
        {
            txtDataEmissao.TabIndex = 0;
            txtDataConclusao.TabIndex = 1;
            cmbCliente.TabIndex = 2;
            cmbMarca.TabIndex = 3;
            cmbProduto.TabIndex = 4;
            txtNumeroSerie.TabIndex = 5;
            txtDescricaoDefeito.TabIndex = 6;
            txtValorTotalServico.TabIndex = 7;
            txtValorTotalMaterial.TabIndex = 8;
            btnSalvar.TabIndex = 9;
        }
        private void ConfigurarTextBox()
        {
            camposObrigatorios = new (Control, string)[]
            {
                (txtDataEmissao, "DataEmissao"),
                (txtDataConclusao, "DataConclusao"),
                (cmbCliente, "IDCliente"),
                (cmbMarca, "IDMarca"),
                (cmbProduto, "IDProduto")
            };
            AdicionarValidacao(
                erpProvider,
                camposObrigatorios
            );
            List<Control> controlesCampos = new List<Control>
            {
                txtDataEmissao,
                txtDataConclusao,
                txtNumeroSerie,
                txtDescricaoDefeito,
                txtValorTotalServico,
                txtValorTotalMaterial,
            };
            EventosUtils.AjustarCamposTexto(controlesCampos, "DBLancamentoServicos");
        }
        public override async Task CarregarRegistros()
        {
            LimparCampos();
            DesabilitarCamposDoFormulario();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
            listViewLancamentoServicos.Items.Clear();

            try
            {
                var lancamentoServicoBLL = new LancamentoServicoBLL();
                var lancamentoServicos = (await lancamentoServicoBLL.ListarAsync());
                foreach (LancamentoServicoInfo lancamentoServico in lancamentoServicos)
                {
                    var item = new ListViewItem(lancamentoServico.IDOrdenServico.ToString());

                    item.SubItems.Add(lancamentoServico.DataEmissao.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lancamentoServico.DataConclusao.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(lancamentoServico.Cliente); // Usar o nome do cliente
                    item.SubItems.Add(lancamentoServico.Marca); // Usar o nome da marca
                    item.SubItems.Add(lancamentoServico.Produto); // Usar o nome da produto
                    item.SubItems.Add(lancamentoServico.NumeroSerie);
                    item.SubItems.Add(lancamentoServico.DescricaoDefeito);
                    item.SubItems.Add(StringUtils.FormatValorMoeda(lancamentoServico.ValorTotalServico.ToString()));
                    item.SubItems.Add(StringUtils.FormatValorMoeda(lancamentoServico.ValorTotalMaterial.ToString()));

                    // Carregar a imagem (sem exibir na ListView)
                    if (lancamentoServico.Imagem != null && lancamentoServico.Imagem.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(lancamentoServico.Imagem))
                        {
                            Image imgImagemProduto = Image.FromStream(ms);
                            // A imagem é carregada, mas não exibida na ListView
                        }
                    }
                    listViewLancamentoServicos.Items.Add(item);
                }

                listaOriginalItens = listViewLancamentoServicos.Items.Cast<ListViewItem>().ToList();
                lbTotalRegistros.Text = $"Total de Registros..: {listViewLancamentoServicos.Items.Count}";

                sortColumn = 3;
                sortAscending = true;
                listViewLancamentoServicos.ListViewItemSorter = new ListViewItemComparer(
                    sortColumn,
                    sortAscending,
                new[] {
                            "ID"
                            },   // colunas numéricas
                new[] {
                            "DATA EMISSÃO",
                            "DATA CONCLUSÃO"
                            },                            // colunas de data
                new string[] {
                                        "VALOR TOTAL SERVIÇO",
                                        "VALOR TOTAL MATERIAIS"
                                        },                                     // colunas monetárias
                new string[] { }                                     // colunas percentuais  
                );
                listViewLancamentoServicos.Sort();

                ajustaLarguraCabecalho(listViewLancamentoServicos);
                tabControlOrdenServico.SelectedTab = tabDadosOrdenServico;

                // Carregar clientes no ComboBox em ordem alfabética crescente
                var clienteBLL = new ClienteBLL();
                var clientes = (await clienteBLL.ListarAsync())
                    .OrderBy(c => c.Nome_RazaoSocial?.ToUpperInvariant())
                    .ToList();
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "Nome_RazaoSocial";
                cmbCliente.ValueMember = "IDCliente";

                // Carregar marcas no ComboBox
                var marcaBLL = new MarcaBLL();
                var marcas = (await marcaBLL.ListarAsync())
                    .OrderBy(m => m.Descricao?.ToUpperInvariant())
                    .ToList();
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Descricao";
                cmbMarca.ValueMember = "IDMarca";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar registros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override async void ExecutaFuncaoEventoAsync(Control control)
        {
            if (control == cmbCliente)
            {
                string clienteDigitado = cmbCliente.Text.ToUpper(); // Converte para maiúsculas
                cmbCliente.Text = clienteDigitado; // Atualiza o texto no ComboBox
                if (!await ClienteExisteAsync(clienteDigitado) && !string.IsNullOrEmpty(clienteDigitado))
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"Cliente '{clienteDigitado}' não Cadastrado", "Cliente não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmClientes
                            frmClientes frm = new frmClientes();
                            frm.ShowDialog();

                            // Carregar clientes no ComboBox em ordem alfabética crescente
                            var clienteBLL = new ClienteBLL();
                            var clientes = (await clienteBLL.ListarAsync())
                                .OrderBy(c => c.Nome_RazaoSocial?.ToUpperInvariant())
                                .ToList();
                            cmbCliente.DataSource = clientes;
                            cmbCliente.DisplayMember = "Nome_RazaoSocial";
                            cmbCliente.ValueMember = "IDCliente";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cmbCliente.Text = string.Empty;
                    cmbCliente.Focus();
                }
                if (string.IsNullOrEmpty(clienteDigitado))
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCliente.Focus();
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
                        DialogResult result = MessageBox.Show(
                            $"A Marca '{marcaDigitada}' não Existe. Deseja Cadastrá-la?",
                            "Marca não Encontrada",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmMarcas
                            frmMarcas frm = new frmMarcas();
                            frm.ShowDialog();

                            // Recarrega marcas
                            var marcaBLL = new MarcaBLL();
                            var marcas = (await marcaBLL.ListarAsync())
                                .OrderBy(m => m.Descricao?.ToUpperInvariant())
                                .ToList();

                            cmbMarca.DataSource = marcas;
                            cmbMarca.DisplayMember = "Descricao";
                            cmbMarca.ValueMember = "IDMarca";

                            // ✅ Carrega modelos da marca recém-cadastrada
                            if (cmbMarca.SelectedValue != null)
                            {
                                await CarregarProdutosPorMarcaAsync(Convert.ToInt32(cmbMarca.SelectedValue));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    cmbMarca.Text = string.Empty;
                    cmbMarca.Focus();
                }

                if (string.IsNullOrEmpty(marcaDigitada) && !string.IsNullOrEmpty(cmbCliente.Text))
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMarca.Focus();
                }
            }
            else if (control == cmbProduto)
            {
                string produtoDigitado = cmbProduto.Text.ToUpper(); // Converte para maiúsculas
                cmbProduto.Text = produtoDigitado; // Atualiza o texto no ComboBox
                int idMarca = Convert.ToInt32(cmbMarca.SelectedValue); // Método para obter o ID da Marca selecionada
                if (!await ProdutoExisteAsync(idMarca, produtoDigitado) && produtoDigitado != string.Empty && idMarca != 0)
                {
                    try
                    {
                        DialogResult result = MessageBox.Show($"O Produto '{produtoDigitado}' não Existe para a Marca Selecionada. Deseja Cadastrá-lo?", "Produto não Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Abre o formulário frmProdutos
                            frmProdutos frm = new frmProdutos();
                            frm.ShowDialog();
                            if (cmbMarca.SelectedValue != null)
                            {
                                int idmarca = Convert.ToInt32(cmbMarca.SelectedValue);
                                CarregarProdutosPorMarcaAsync(idmarca);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi Possível Estabelecer Conexão com o BD: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cmbProduto.Text = string.Empty;
                    cmbProduto.Focus();
                }
                if (string.IsNullOrEmpty(produtoDigitado) && !string.IsNullOrEmpty(cmbMarca.Text))
                {
                    MessageBox.Show("O Preenchimento Desse Campo é Obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbProduto.Focus();
                }
            }
        }
        private async void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedValue is int idMarca)
            {
                await CarregarProdutosPorMarcaAsync(idMarca);
            }
        }
        private async Task<bool> ClienteExisteAsync(string nome_RazaoSocial)
        {
            var clienteBLL = new ClienteBLL();
            var clientes = (await clienteBLL.ListarAsync());
            return clientes.Any(c => c.Nome_RazaoSocial.Equals(nome_RazaoSocial, StringComparison.OrdinalIgnoreCase));
        }
        private async Task<bool> ProdutoExisteAsync(int idMarca, string descricao)
        {
            var produtoDAL = new ProdutoDAL();
            var produtos = (await produtoDAL.ListarPorMarcaAsync(idMarca));
            return produtos.Any(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private async Task<bool> MarcaExisteAsync(string descricao)
        {
            var marcaBLL = new MarcaBLL();
            var marcas = (await marcaBLL.ListarAsync());
            return marcas.Any(m => m.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }
        private async Task CarregarProdutosPorMarcaAsync(int idMarca)
        {
            var produtoDAL = new ProdutoDAL();
            var produtos = (await produtoDAL.ListarPorMarcaAsync(idMarca))
                .OrderBy(p => p.Descricao?.ToUpperInvariant())
                .ToList();

            if (produtos.Count > 0)
            {
                cmbProduto.DataSource = produtos;
                cmbProduto.DisplayMember = "Descricao";
                cmbProduto.ValueMember = "IDProduto";
            }
            else
            {
                cmbProduto.DataSource = null;
                cmbProduto.Items.Clear();
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            txtIDOrdenServico.Text = "0";
            bNovo = true;
            HabilitarCamposDoFormulario("Novo");
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            var lancamentoServicoBLL = new LancamentoServicoBLL();
            bool isAtualizacao = false;

            if (!string.IsNullOrWhiteSpace(txtIDOrdenServico.Text))
            {
                int idOrdenServico = Convert.ToInt32(txtIDOrdenServico.Text);
                var lancamentoExistente = await lancamentoServicoBLL.GetLancamentoServicoAsync(idOrdenServico); // ✅ chamada assíncrona
                isAtualizacao = lancamentoExistente != null;
            }

            var lancamentoServico = new LancamentoServicoInfo
            {
                DataEmissao = txtDataEmissao.Value,
                DataConclusao = txtDataConclusao.Value,
                IDCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                IDMarca = Convert.ToInt32(cmbMarca.SelectedValue),
                IDProduto = Convert.ToInt32(cmbProduto.SelectedValue),
                NumeroSerie = txtNumeroSerie.Text,
                DescricaoDefeito = txtDescricaoDefeito.Text,
                ValorTotalServico = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalServico.Text)),
                ValorTotalMaterial = Convert.ToDecimal(StringUtils.SemFormatacao(txtValorTotalMaterial.Text)),
                Imagem = ImageToByteArray(imgImagemProduto.Image)
            };

            if (!isAtualizacao)
            {
                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja incluir esse lançamento de serviço?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await InserirLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
                }
            }
            else
            {
                lancamentoServico.IDOrdenServico = Convert.ToInt32(txtIDOrdenServico.Text);

                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja salvar as alterações realizadas?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await AtualizarLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
                }
            }

            await CarregarRegistros(); // ✅ aguarda recarregamento
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EventosUtils.AcaoBotoes("HabilitarBotaoSalvar", this);
            HabilitarCamposDoFormulario("Alterar");
        }
        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem Certeza que Deseja Excluir Esse Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (int.TryParse(txtIDOrdenServico.Text, out int ordenServicoID))
                {
                    await ExcluirLancamentoServicoAsync(ordenServicoID);
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Informaçâo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            await CarregarRegistros();
            EventosUtils.AcaoBotoes("DesabilitarBotoesAcoes", this);
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            await CarregarRegistros();
        }
        private void DesabilitarCamposDoFormulario()
        {
            List<Control> controlesDesabilitar = new List<Control>
        {
            txtDataEmissao,
            txtDataConclusao,
            cmbCliente,
            cmbMarca,
            cmbProduto,
            txtNumeroSerie,
            txtDescricaoDefeito,
            txtValorTotalServico,
            txtValorTotalMaterial
        };

            EventosUtils.DesabilitarControles(controlesDesabilitar, this);
            listViewLancamentoServicos.Enabled = true;
            txtPesquisaListView.Enabled = true;
        }
        private void HabilitarCamposDoFormulario(string buttonPressed)
        {
            listViewLancamentoServicos.Enabled = false;
            txtPesquisaListView.Enabled = false;
            List<Control> controlesHabilitar = new List<Control>
            {
                txtDescricaoDefeito,
                txtDataConclusao,
                txtValorTotalServico,
                txtValorTotalMaterial
            };
            EventosUtils.HabilitarControles(controlesHabilitar, this);
            switch (buttonPressed)
            {
                case "Novo":
                    List<Control> controlesHabilitarNovo = new List<Control>
                     {
                          txtDataEmissao,
                          cmbCliente,
                          cmbMarca,
                          cmbProduto,
                          txtNumeroSerie
                     };
                    EventosUtils.HabilitarControles(controlesHabilitarNovo, this);
                    txtIDOrdenServico.Text = "0";
                    txtDataEmissao.Text = DateTime.Now.ToString();
                    txtDataConclusao.Text = DateTime.Now.ToString();
                    txtDataEmissao.Focus();
                    break;
                case "Alterar":
                    txtDataConclusao.Focus();
                    break;
            }
        }
        public override void LimparCampos()
        {
            txtIDOrdenServico.Clear();
            txtIDOrdenServico.Text = "0";
            txtDataEmissao.Value = DateTime.Now;
            txtDataConclusao.Value = DateTime.Now;
            cmbCliente.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbProduto.SelectedIndex = -1;
            txtNumeroSerie.Clear();
            txtDescricaoDefeito.Clear();
            txtValorTotalServico.Text = StringUtils.FormatValorMoeda("0"); ;
            txtValorTotalMaterial.Text = StringUtils.FormatValorMoeda("0");
            imgImagemProduto.Image = null;
            bNovo = false;
            escPressed = false;

        }
        private static async Task InserirLancamentoServicoAsync(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                var lancamentoServicoBLL = new LancamentoServicoBLL();
                await lancamentoServicoBLL.InserirLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
                MessageBox.Show("Ordem de Serviço inserida com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task AtualizarLancamentoServicoAsync(LancamentoServicoInfo lancamentoServico)
        {
            try
            {
                var lancamentoServicoBLL = new LancamentoServicoBLL();
                await lancamentoServicoBLL.AtualizarLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
                MessageBox.Show("Ordem de Serviço atualizada com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task ExcluirLancamentoServicoAsync(int idOrdenServico)
        {
            try
            {
                var lancamentoServicoBLL = new LancamentoServicoBLL();
                await lancamentoServicoBLL.ExcluirLancamentoServicoAsync(idOrdenServico); // ✅ chamada assíncrona
                MessageBox.Show("Ordem de Serviço excluída com sucesso!",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer conexão com o BD: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
