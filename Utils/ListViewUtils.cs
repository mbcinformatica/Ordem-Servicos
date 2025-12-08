using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OrdemServicos.Utils
{
    public static class ListViewUtils
    {
        // Configuração inicial do ListView
        public static void ConfigurarListView(ListView listView,
            ColumnClickEventHandler columnClickHandler,
            DrawListViewColumnHeaderEventHandler headerHandler,
            DrawListViewItemEventHandler itemHandler)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.OwnerDraw = true;

            listView.DrawColumnHeader += headerHandler;
            listView.DrawItem += itemHandler;
            listView.ColumnClick += columnClickHandler;
        }

        // Comparador para ordenação
        public class ListViewItemComparer : IComparer
        {
            private readonly int col;
            private readonly bool ascending;
            private readonly HashSet<string> numericColumns;
            private readonly HashSet<string> dateColumns;
            private readonly HashSet<string> moneyColumns;
            private readonly HashSet<string> percentColumns;

            public ListViewItemComparer(int column, bool ascending,
                IEnumerable<string> numericColumns,
                IEnumerable<string> dateColumns,
                IEnumerable<string> moneyColumns,
                IEnumerable<string> percentColumns)
            {
                col = column;
                this.ascending = ascending;

                if (numericColumns == null)
                    throw new ArgumentNullException(nameof(numericColumns), "Informe as colunas numéricas.");
                if (dateColumns == null)
                    throw new ArgumentNullException(nameof(dateColumns), "Informe as colunas de data.");
                if (moneyColumns == null)
                    throw new ArgumentNullException(nameof(moneyColumns), "Informe as colunas monetárias.");
                if (percentColumns == null)
                    throw new ArgumentNullException(nameof(percentColumns), "Informe as colunas percentuais.");

                this.numericColumns = new HashSet<string>(numericColumns.Select(c => c.Trim().ToUpper()));
                this.dateColumns = new HashSet<string>(dateColumns.Select(c => c.Trim().ToUpper()));
                this.moneyColumns = new HashSet<string>(moneyColumns.Select(c => c.Trim().ToUpper()));
                this.percentColumns = new HashSet<string>(percentColumns.Select(c => c.Trim().ToUpper()));
            }
            public int Compare(object x, object y)
            {
                var itemX = (ListViewItem)x;
                var itemY = (ListViewItem)y;

                string valX = itemX.SubItems[col].Text;
                string valY = itemY.SubItems[col].Text;
                string colName = itemX.ListView.Columns[col].Text.Trim().ToUpper();

                int result;

                if (numericColumns.Contains(colName))
                {
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
                else if (moneyColumns.Contains(colName))
                {
                    // Remove símbolos monetários e espaços antes de tentar converter
                    string cleanX = new string(valX.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
                    string cleanY = new string(valY.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());

                    if (decimal.TryParse(cleanX, out decimal moneyX) && decimal.TryParse(cleanY, out decimal moneyY))
                        result = moneyX.CompareTo(moneyY);
                    else
                        result = string.Compare(valX, valY, StringComparison.OrdinalIgnoreCase);
                }
                else if (percentColumns.Contains(colName))
                {
                    // Remove símbolo de porcentagem e espaços
                    string cleanX = valX.Replace("%", "").Trim();
                    string cleanY = valY.Replace("%", "").Trim();

                    if (decimal.TryParse(cleanX, out decimal percX) && decimal.TryParse(cleanY, out decimal percY))
                        result = percX.CompareTo(percY);
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
        public static void HandleColumnClick(
            ListView listView,
            ColumnClickEventArgs e,
            ref int sortColumn,
            ref bool sortAscending,
            IEnumerable<string> numericColumns,
            IEnumerable<string> dateColumns,
            IEnumerable<string> moneyColumns,
            IEnumerable<string> percentColumns,
            TextBox txtPesquisa = null,
            int[] allowedColumns = null)
        {
            // Se houver restrição de colunas permitidas
            if (allowedColumns != null && !allowedColumns.Contains(e.Column))
                return;

            int oldSortColumn = sortColumn;
            if (e.Column == sortColumn)
            {
                sortAscending = !sortAscending; // alterna ordem
            }
            else
            {
                sortColumn = e.Column;
                sortAscending = true;
            }

            // Forçar redesenho da coluna anterior
            if (oldSortColumn != -1)
                listView.Columns[oldSortColumn].Width = listView.Columns[oldSortColumn].Width;

            // Comparador parametrizado
            listView.ListViewItemSorter = new ListViewItemComparer(
                e.Column,
                sortAscending,
                numericColumns,
                dateColumns,
                moneyColumns,
                percentColumns
            );

            listView.Sort();

            // Forçar redesenho da nova coluna
            listView.Columns[sortColumn].Width = listView.Columns[sortColumn].Width;
            listView.Invalidate();

            // Foco no campo de pesquisa
            txtPesquisa?.Focus();
        }
        public static void PesquisarListView(string texto, ListView listView, int coluna, List<ListViewItem> listaOriginalItens)
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
        public static void DesenharCabecalho(
            DrawListViewColumnHeaderEventArgs e,
            int sortColumn,
            Color defaultColor,
            Color clickedColor,
            string fontFamily,
            float fontSize,
            FontStyle fontStyle,
            string[] centerColumnList // agora é parâmetro
        )
        {
            Color headerBackColor = e.ColumnIndex == sortColumn ? clickedColor : defaultColor;

            using (SolidBrush backBrush = new SolidBrush(headerBackColor))
                e.Graphics.FillRectangle(backBrush, e.Bounds);

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.Alignment = centerColumnList.Contains(e.Header.Text)
                    ? StringAlignment.Center
                    : StringAlignment.Near;

                using (Font headerFont = new Font(fontFamily, fontSize, fontStyle))
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);

                using (Pen gridLinePen = new Pen(Color.Black, 2))
                    e.Graphics.DrawRectangle(gridLinePen, e.Bounds);
            }
        }
        public static void DesenharItem(DrawListViewItemEventArgs e, Color evenColor, Color oddColor)
        {
            e.Item.BackColor = e.ItemIndex % 2 == 0 ? evenColor : oddColor;
            e.DrawDefault = true;
        }
    }
}