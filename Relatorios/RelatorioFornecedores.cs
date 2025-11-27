using iTextSharp.text;
using iTextSharp.text.pdf;
using OrdemServicos.BLL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrdemServicos
{
    public class RelatorioFornecedores
    {
        public async Task<string> GerarRelatorioFornecedoresAsync(string caminhoArquivo)
        {
            return await Task.Run(async () =>
            {
                var fornecedorBLL = new FornecedorBLL();
                var fornecedores = await fornecedorBLL.ListarAsync(); 

                if (fornecedores.Count == 0)
                {
                    return null; // retorna nulo se não houver dados
                }

                using (Document doc = new Document(PageSize.A4.Rotate()))
                {
                    doc.SetMargins(20f, 20f, 90f, 40f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

                    HeaderFooter eventHandler = new HeaderFooter("Relatório de Fornecedores");
                    writer.PageEvent = eventHandler;

                    doc.Open();

                    PdfPTable tabela = new PdfPTable(11);
                    tabela.WidthPercentage = 100;
                    tabela.SetWidths(new float[] { 24f, 56f, 40f, 14f, 30f, 36f, 14f, 40f, 20f, 20f, 35f });

                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "CPF/CNPJ");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "NOME/RAZÃO SOCIAL");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "ENDEREÇO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "NUMERO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "BAIRRO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "MUNICIPIO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "CEP");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "CONTATO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "CELULAR");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "FIXO");
                    HeaderFooter.AdicionarCelulaCabecalho(tabela, "EMAIL");

                    tabela.HeaderRows = 1;

                    bool linhaPar = false;
                    foreach (var fornecedor in fornecedores)
                    {
                        var corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.TipoPessoa == "FÍSICA" ? Utils.StringUtils.FormatCPF(fornecedor.Cpf_Cnpj) : Utils.StringUtils.FormatCNPJ(fornecedor.Cpf_Cnpj), 54f, Element.ALIGN_RIGHT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Nome_RazaoSocial, 125f, Element.ALIGN_LEFT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Endereco, 90f, Element.ALIGN_LEFT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Numero, 10f, Element.ALIGN_RIGHT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Bairro, 70f, Element.ALIGN_LEFT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Municipio, 90f, Element.ALIGN_LEFT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatCEP(fornecedor.Cep), 40f, Element.ALIGN_RIGHT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Contato, 90f, Element.ALIGN_LEFT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(fornecedor.Fone_1), 47f, Element.ALIGN_RIGHT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(fornecedor.Fone_2), 45f, Element.ALIGN_RIGHT, corLinha);
                        HeaderFooter.AdicionarCelulaDado(tabela, fornecedor.Email, 80f, Element.ALIGN_LEFT, corLinha);
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
