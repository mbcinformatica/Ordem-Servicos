using iTextSharp.text;
using iTextSharp.text.pdf;
using OrdemServicos.BLL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OrdemServicos
{
    public class RelatorioUsuarios
    {
        public void GerarRelatorioUsuarios(string caminhoArquivo)
        {
            // Obter dados dos usuarios usando a camada BLL
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            List<UsuarioInfo> usuarios = usuarioBLL.Listar();

            // Verificar se a lista de usuarios está vazia
            if (usuarios.Count == 0)
            {
                MessageBox.Show("Nenhum Dados de Usuários Disponível para Gerar o Relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Configurar documento para A4 paisagem com margens
            Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(20f, 20f, 90f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            // Adicionar evento de página personalizado com título
            HeaderFooter eventHandler = new HeaderFooter("Relatório de Usuários");
            writer.PageEvent = eventHandler;

            doc.Open();


            // Criar tabela
            PdfPTable tabela = new PdfPTable(10);
            tabela.WidthPercentage = 100;

            // Configurar larguras das colunas
            tabela.SetWidths(new float[] { 56f, 56f, 40f, 14f, 30f, 36f, 14f, 20f, 20f, 35f });

            // Adicionar cabeçalhos
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "NOME");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "LOGIN");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "ENDEREÇO");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "NUMERO");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "BAIRRO");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "MUNICIPIO");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "CEP");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "CELULAR");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "FIXO");
            HeaderFooter.AdicionarCelulaCabecalho(tabela, "EMAIL");

            // Configurar a tabela para repetir os cabeçalhos em todas as páginas
            tabela.HeaderRows = 1;

            // Adicionar dados dos usuarios com cores alternadas
            bool linhaPar = false;
            foreach (var usuario in usuarios)
            {
                BaseColor corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Nome, 125f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Login, 125f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Endereco, 90f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Numero, 10f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Bairro, 70f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Municipio, 90f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatCEP(usuario.Cep), 40f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(usuario.Fone_1), 47f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(usuario.Fone_2), 45f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, usuario.Email, 80f, Element.ALIGN_LEFT, corLinha);
                linhaPar = !linhaPar;
            }

            // Adicionar tabela ao documento
            doc.Add(tabela);

            // Fechar documento
            doc.Close();

            // Exiba uma mensagem de confirmação
            MessageBox.Show("Relatório Gerado com Sucesso em: \n\n " + caminhoArquivo, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Abre arquivo PDF
            Process.Start(new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true });
        }
    }
}
