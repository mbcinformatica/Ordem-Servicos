using Newtonsoft.Json.Linq;
using OrdemServicos.Forms;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static OrdemServicos.Model.PesquisaWebInfo;


namespace OrdemServicos.DAL
{
    public class PesquisaWebDAL:BaseForm
    {
        public class ReceitaFederalApi
        {
            private static readonly HttpClient client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
            private static async Task<string> ExecutarComRetryAsync(string url)
            {
                int tentativas = 0;
                const int maxTentativas = 3;

                while (tentativas < maxTentativas)
                {
                    try
                    {

                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        string conteudo = await response.Content.ReadAsStringAsync();
                        return conteudo;
                    }
                    catch  { }

                    tentativas++;
                    await Task.Delay(2000); // espera 5 segundos antes da próxima tentativa
                }
                return null;
            }
            public static async Task<CnpjInfo> PesquisarCnpjAsync(string cnpj)
            {
                string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
                string responseBody = await ExecutarComRetryAsync(url);

                if (string.IsNullOrEmpty(responseBody)) return null;

                try
                {
                    JObject json = JObject.Parse(responseBody);

                    return new CnpjInfo
                    {
                        Cpf_Cnpj = json["cnpj"]?.ToString(),
                        Nome_RazaoSocial = json["nome"]?.ToString(),
                        Endereco = json["logradouro"]?.ToString(),
                        Numero = json["numero"]?.ToString(),
                        Bairro = json["bairro"]?.ToString(),
                        Municipio = json["municipio"]?.ToString(),
                        UF = json["uf"]?.ToString(),
                        Cep = json["cep"]?.ToString(),
                        Contato = json["telefone"]?.ToString(),
                        Fone_1 = json["telefone"]?.ToString()?.Length >= 14 ? json["telefone"].ToString().Substring(0, 14) : json["telefone"]?.ToString(),
                        Fone_2 = json["telefone"]?.ToString()?.Length >= 14 ? json["telefone"].ToString().Substring(0, 14) : json["telefone"]?.ToString(),
                        Email = json["email"]?.ToString(),
                        DataCadastro = json["ultima_atualizacao"]?.ToString()
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao interpretar JSON do CNPJ: {e.Message}");
                    return null;
                }
            }
            public static async Task<CpfInfo> PesquisarCpfAsync(string cpf)
            {
                string url = $"https://www.gov.br/receitafederal/pt-br/assuntos/{cpf}";
                string responseBody = await ExecutarComRetryAsync(url);

                if (string.IsNullOrEmpty(responseBody)) return null;

                try
                {
                    JObject json = JObject.Parse(responseBody);

                    return new CpfInfo
                    {
                        Cpf_Cnpj = json["cnpj"]?.ToString(),
                        Nome_RazaoSocial = json["nome"]?.ToString(),
                        DataCadastro = json["data_nascimento"]?.ToString(),
                        Endereco = json["endereco"]?.ToString(),
                        Bairro = json["bairro"]?.ToString(),
                        Municipio = json["municipio"]?.ToString(),
                        UF = json["uf"]?.ToString(),
                        Cep = json["cep"]?.ToString(),
                        Contato = json["telefone"]?.ToString(),
                        Email = json["email"]?.ToString()
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao interpretar JSON do CPF: {e.Message}");
                    return null;
                }
            }
        }
    }
}
