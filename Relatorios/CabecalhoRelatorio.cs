using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace OrdemServicos
{
    public class HeaderFooter : PdfPageEventHelper
    {
        private Image logo;
        private readonly string titulo;

        public HeaderFooter(string titulo)
        {
            this.titulo = titulo;

            // Carregar a imagem do logo
            string caminhoLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "LogoRelatorio.png");
            if (File.Exists(caminhoLogo))
            {
                logo = Image.GetInstance(caminhoLogo);
                logo.ScaleToFit(400f, 400f); // tamanho ajustado conforme solicitado
                logo.Alignment = Element.ALIGN_LEFT;
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Cabeçalho com 2 colunas: logo + título + data/hora
            PdfPTable header = new PdfPTable(2);
            header.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
            header.SetWidths(new float[] { 35f, 65f }); // proporção ajustada para logo grande
            header.DefaultCell.Border = Rectangle.NO_BORDER;

            // Logo
            PdfPCell logoCell = logo != null
                ? new PdfPCell(logo)
                : new PdfPCell(new Phrase(" "));
            logoCell.Border = Rectangle.NO_BORDER;
            logoCell.HorizontalAlignment = Element.ALIGN_LEFT;
            logoCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            logoCell.PaddingBottom = 5f;
            header.AddCell(logoCell);

            // Título + data/hora à direita
            Font fonteTitulo = new Font(Font.FontFamily.COURIER, 16, Font.BOLD);
            Font fonteDataHora = new Font(Font.FontFamily.COURIER, 12, Font.BOLD);

            Paragraph blocoTexto = new Paragraph();
            blocoTexto.Alignment = Element.ALIGN_RIGHT;
            blocoTexto.Add(new Phrase(titulo + "\n", fonteTitulo));
            blocoTexto.Add(new Phrase("\n"));
            blocoTexto.Add(new Phrase("\n"));
            blocoTexto.Add(new Phrase(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fonteDataHora));

            PdfPCell textoCell = new PdfPCell(blocoTexto);
            textoCell.Border = Rectangle.NO_BORDER;
            textoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            textoCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            textoCell.PaddingBottom = 5f;
            header.AddCell(textoCell);

            // Desenhar cabeçalho
            header.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 20, writer.DirectContent);

            // Rodapé com número da página
            PdfPTable footer = new PdfPTable(1);
            footer.TotalWidth = document.PageSize.Width - (document.LeftMargin + document.RightMargin);
            footer.DefaultCell.Border = Rectangle.NO_BORDER;

            PdfPCell footerCell = new PdfPCell(new Phrase($"Página {writer.PageNumber}", new Font(Font.FontFamily.COURIER, 12, Font.NORMAL)));
            footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            footerCell.Border = Rectangle.NO_BORDER;
            footer.AddCell(footerCell);

            footer.WriteSelectedRows(0, -1, document.LeftMargin, 40, writer.DirectContent);
        }
        public static void AdicionarCelulaCabecalho(PdfPTable tabela, string texto)
        {
            PdfPCell celula = new PdfPCell(new Phrase(texto, new Font(Font.FontFamily.COURIER, 8, Font.BOLD)));
            celula.HorizontalAlignment = Element.ALIGN_CENTER;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            celula.BackgroundColor = BaseColor.LIGHT_GRAY;
            celula.NoWrap = true;
            tabela.AddCell(celula);
        }
        public static void AdicionarCelulaDado(PdfPTable tabela, string texto, float larguraColuna, int alinhamento, BaseColor corFundo)
        {
            // Ajustar o tamanho da fonte
            Font fonte = new Font(Font.FontFamily.COURIER, 5, Font.BOLD);
            BaseFont bf = fonte.GetCalculatedBaseFont(false);

            // Medir a largura do texto em pontos
            float larguraTexto = bf.GetWidthPoint(texto, fonte.Size);

            // Truncar o texto se necessário
            while (larguraTexto > larguraColuna)
            {
                texto = texto.Substring(0, texto.Length - 1);
                larguraTexto = bf.GetWidthPoint(texto, fonte.Size);
            }

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            celula.BackgroundColor = corFundo;
            celula.NoWrap = true; // Evita quebra de linha
            tabela.AddCell(celula);
        }
    }
}

