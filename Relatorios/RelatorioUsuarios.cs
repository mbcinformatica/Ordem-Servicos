using iTextSharp.text;
using iTextSharp.text.pdf;
using OrdemServicos.BLL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrdemServicos
{
    public class RelatorioUsuarios
    {
        public async Task<string> GerarRelatorioUsuariosAsync(string caminhoArquivo)
        {
            return await Task.Run(() =>
            {
                var usuarioBLL = new UsuarioBLL();
                List<UsuarioInfo> usuarios = usuarioBLL.Listar();

                if (usuarios.Count == 0)
                {
                    return null; // retorna nulo se não houver dados
                }

                using (Document doc = new Document(PageSize.A4.Rotate()))
                {
                    doc.SetMargins(20f, 20f, 90f, 40f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                    HeaderFooter eventHandler = new HeaderFooter("Relatório de Usuários");
                    writer.PageEvent = eventHandler;

                    doc.Open();

                    PdfPTable tabela = new PdfPTable(10);
                    tabela.WidthPercentage = 100;
                    tabela.SetWidths(new float[] { 56f, 56f, 40f, 14f, 30f, 36f, 14f, 20f, 20f, 35f });

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

                    tabela.HeaderRows = 1;

                    bool linhaPar = false;
                    foreach (var usuario in usuarios)
                    {
                        var corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
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

                    doc.Add(tabela);
                    doc.Close();
                }
                return caminhoArquivo;
            });
        }
    }
}
