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
    public class RelatorioClientes 
    {
        public void GerarRelatorioClientes(string caminhoArquivo)
        {
            // Obter dados dos clientes usando a camada BLL
            ClienteBLL clienteBLL = new ClienteBLL();
            List<ClienteInfo> clientes = clienteBLL.Listar();

            // Verificar se a lista de clientes está vazia
            if (clientes.Count == 0)
            {
                MessageBox.Show("Nenhum Dados de Clintes Disponível para Gerar o Relatório.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Configurar documento para A4 paisagem com margens
            Document doc = new Document(PageSize.A4.Rotate());
            doc.SetMargins(20f, 20f, 90f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));

            // Adicionar evento de página personalizado com título
            HeaderFooter eventHandler = new HeaderFooter("Relatório de Clientes");
            writer.PageEvent = eventHandler;

            doc.Open();

            // Criar tabela
            PdfPTable tabela = new PdfPTable(11);
            tabela.WidthPercentage = 100;

            // Configurar larguras das colunas
            tabela.SetWidths(new float[] { 24f, 56f, 40f, 14f, 30f, 36f, 14f, 40f, 20f, 20f, 35f });

            // Adicionar cabeçalhos
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

            // Configurar a tabela para repetir os cabeçalhos em todas as páginas
            tabela.HeaderRows = 1;

            // Adicionar dados dos clientes com cores alternadas
            bool linhaPar = false;
            foreach (var cliente in clientes)
            {
                BaseColor corLinha = linhaPar ? BaseColor.LIGHT_GRAY : BaseColor.WHITE;
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.TipoPessoa == "FÍSICA" ? Utils.StringUtils.FormatCPF(cliente.Cpf_Cnpj) : Utils.StringUtils.FormatCNPJ(cliente.Cpf_Cnpj), 54f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Nome_RazaoSocial, 125f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Endereco, 90f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Numero, 10f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Bairro, 70f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Municipio, 90f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatCEP(cliente.Cep), 40f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Contato, 90f, Element.ALIGN_LEFT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(cliente.Fone_1), 47f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, Utils.StringUtils.FormatPhoneNumber(cliente.Fone_2), 45f, Element.ALIGN_RIGHT, corLinha);
                HeaderFooter.AdicionarCelulaDado(tabela, cliente.Email, 80f, Element.ALIGN_LEFT, corLinha);
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