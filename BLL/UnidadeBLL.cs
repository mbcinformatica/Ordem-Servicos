using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class UnidadeBLL
    {
        public async Task<List<UnidadeInfo>> ListarAsync()
        {
            var unidadeDAL = new UnidadeDAL();
            return await unidadeDAL.ListarAsync();
        }

        public async Task<UnidadeInfo> GetUnidadeAsync(int idUnidade)
        {
            var unidadeDAL = new UnidadeDAL();
            return await unidadeDAL.GetUnidadeAsync(idUnidade);
        }

        public async Task AtualizarUnidadeAsync(UnidadeInfo unidade)
        {
            var unidadeDAL = new UnidadeDAL();
            await unidadeDAL.AtualizarUnidadeAsync(unidade);
        }

        public async Task InserirUnidadeAsync(UnidadeInfo unidade)
        {
            var unidadeDAL = new UnidadeDAL();
            await unidadeDAL.InserirUnidadeAsync(unidade);
        }

        public async Task ExcluirUnidadeAsync(int idUnidade)
        {
            var unidadeDAL = new UnidadeDAL();
            await unidadeDAL.ExcluirUnidadeAsync(idUnidade);
        }
    }
}
