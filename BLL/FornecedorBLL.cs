using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class FornecedorBLL
    {
        private readonly FornecedorDAL fornecedorDAL;

        public FornecedorBLL()
        {
            fornecedorDAL = new FornecedorDAL();
        }

        public async Task<List<FornecedorInfo>> ListarAsync()
        {
            return await fornecedorDAL.ListarAsync();
        }

        public async Task<FornecedorInfo> GetFornecedorAsync(int idFornecedor)
        {
            return await fornecedorDAL.GetFornecedorAsync(idFornecedor);
        }

        public async Task AtualizarFornecedorAsync(FornecedorInfo fornecedor)
        {
            await fornecedorDAL.AtualizarFornecedorAsync(fornecedor);
        }

        public async Task InserirFornecedorAsync(FornecedorInfo fornecedor)
        {
            await fornecedorDAL.InserirFornecedorAsync(fornecedor);
        }

        public async Task ExcluirFornecedorAsync(int idFornecedor)
        {
            await fornecedorDAL.ExcluirFornecedorAsync(idFornecedor);
        }
    }
}
