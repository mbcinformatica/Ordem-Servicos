Relatorio Clientes em Excel

private void AbrirRelatorioClientes()
{
    // Defina o caminho base onde o relatório será salvo
    string diretorioRelatorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RelatorioExcel");

    // Verifique se o diretório existe, se não, crie-o
    if (!Directory.Exists(diretorioRelatorio))
    {
        Directory.CreateDirectory(diretorioRelatorio);
    }

    // Nome base do arquivo
    string caminhoBase = Path.Combine(diretorioRelatorio, "RelatorioClientes.xlsx");
    string caminhoArquivo = caminhoBase;

    // Verifique se o arquivo já existe e gere um novo nome se necessário
    int contador = 1;
    while (File.Exists(caminhoArquivo))
    {
        string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(caminhoBase);
        string extensao = Path.GetExtension(caminhoBase);
        caminhoArquivo = Path.Combine(diretorioRelatorio, $"{nomeArquivoSemExtensao}_{contador}{extensao}");
        contador++;
    }

    // Crie uma instância da classe RelatorioClientes
    RelatorioClientes relatorio = new RelatorioClientes();

    // Gere o relatório em Excel
    relatorio.GerarRelatorioClientes(caminhoArquivo);
}



using ClosedXML.Excel;
using OrdemServicos.BLL;
using OrdemServicos.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OrdemServicos
{
    public class RelatorioClientes
    {
        public void GerarRelatorioClientes(string caminhoArquivo)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            List<ClienteInfo> clientes = clienteBLL.Listar();

            if (clientes.Count == 0)
            {
                MessageBox.Show("Nenhum dado de cliente disponível para gerar o relatório.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ordenar por Nome/Razão Social
            clientes = clientes.OrderBy(c => c.Nome_RazaoSocial).ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clientes");

            // Mesclar células A1:C5 para o logo
            worksheet.Range("A1:C5").Merge();

            // Inserir logo na célula A1 (se existir)
            string caminhoLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "LogoRelatorio.png");
            if (File.Exists(caminhoLogo))
            {
                worksheet.AddPicture(caminhoLogo)
                         .MoveTo(worksheet.Cell("A1"))
                         .WithSize(180, 80); // ajuste conforme proporção da imagem mostrada
            }

            // Mesclar células D1:L5 para o título
            worksheet.Range("D1:L5").Merge();
            var titulo = worksheet.Cell("D1");
            titulo.Value = "Relatório de Clientes";
            titulo.Style.Font.Bold = true;
            titulo.Style.Font.FontSize = 24;
            titulo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titulo.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cabeçalho da tabela
            string[] cabecalhos = {
                "CPF/CNPJ", "NOME/RAZÃO SOCIAL", "ENDEREÇO", "NUMERO", "BAIRRO",
                "MUNICIPIO", "CEP", "CONTATO", "CELULAR", "FIXO", "EMAIL"
            };

            for (int i = 0; i < cabecalhos.Length; i++)
            {
                var cell = worksheet.Cell(6, i + 1);
                cell.Value = cabecalhos[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            int row = 7;

            foreach (var cliente in clientes)
            {
                worksheet.Cell(row, 1).Value = cliente.TipoPessoa == "FÍSICA"
                    ? Utils.StringUtils.FormatCPF(cliente.Cpf_Cnpj)
                    : Utils.StringUtils.FormatCNPJ(cliente.Cpf_Cnpj);

                worksheet.Cell(row, 2).Value = cliente.Nome_RazaoSocial;
                worksheet.Cell(row, 3).Value = cliente.Endereco;
                worksheet.Cell(row, 4).Value = cliente.Numero;
                worksheet.Cell(row, 5).Value = cliente.Bairro;
                worksheet.Cell(row, 6).Value = cliente.Municipio;
                worksheet.Cell(row, 7).Value = Utils.StringUtils.FormatCEP(cliente.Cep);
                worksheet.Cell(row, 8).Value = cliente.Contato;
                worksheet.Cell(row, 9).Value = Utils.StringUtils.FormatPhoneNumber(cliente.Fone_1);
                worksheet.Cell(row, 10).Value = Utils.StringUtils.FormatPhoneNumber(cliente.Fone_2);
                worksheet.Cell(row, 11).Value = cliente.Email;

                for (int col = 1; col <= 11; col++)
                {
                    var cell = worksheet.Cell(row, col);
                    cell.Style.Alignment.Horizontal = (col == 1 || col == 4 || col == 7 || col == 9 || col == 10)
                        ? XLAlignmentHorizontalValues.Right
                        : XLAlignmentHorizontalValues.Left;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                row++;
            }

            worksheet.Columns().AdjustToContents();

            // Congelar cabeçalho e aplicar filtros
            worksheet.SheetView.FreezeRows(6);
            worksheet.Range("A6:K" + (row - 1)).SetAutoFilter();

            // Configuração de impressão
            worksheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
            worksheet.PageSetup.FitToPages(1, 0);
            worksheet.PageSetup.CenterHorizontally = true;

            // Cabeçalho e rodapé de impressão
            worksheet.PageSetup.Header.Left.AddText("Relatório de Clientes");
            worksheet.PageSetup.Header.Right.AddText(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            worksheet.PageSetup.Footer.Left.AddText("Página &P de &N");
            worksheet.PageSetup.Footer.Right.AddText(Path.GetFileName(caminhoArquivo));

            workbook.SaveAs(caminhoArquivo);
            MessageBox.Show("Relatório gerado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(caminhoArquivo);
        }
    }
}
