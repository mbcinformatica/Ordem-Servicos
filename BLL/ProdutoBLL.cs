using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class ProdutoBLL
    {
        public async Task<List<ProdutoInfo>> ListarAsync()
        {
            var produtoDAL = new ProdutoDAL();
            return await produtoDAL.ListarAsync();
        }

        public async Task<List<ProdutoInfo>> ListarPorMarcaAsync(int idMarca)
        {
            var produtoDAL = new ProdutoDAL();
            return await produtoDAL.ListarPorMarcaAsync(idMarca);
        }

        public async Task<ProdutoInfo> GetProdutoAsync(int idProduto)
        {
            var produtoDAL = new ProdutoDAL();
            return await produtoDAL.GetProdutoAsync(idProduto);
        }

        public async Task AtualizarProdutoAsync(ProdutoInfo produto)
        {
            var produtoDAL = new ProdutoDAL();
            await produtoDAL.AtualizarProdutoAsync(produto);
        }

        public async Task InserirProdutoAsync(ProdutoInfo produto)
        {
            var produtoDAL = new ProdutoDAL();
            await produtoDAL.InserirProdutoAsync(produto);
        }

        public async Task ExcluirProdutoAsync(int idProduto)
        {
            var produtoDAL = new ProdutoDAL();
            await produtoDAL.ExcluirProdutoAsync(idProduto);
        }
    }
}
