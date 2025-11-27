using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class LancamentoServicoBLL
    {
        public async Task<List<LancamentoServicoInfo>> ListarAsync()
        {
            var lancamentoServicoDAL = new LancamentoServicoDAL();
            return await lancamentoServicoDAL.ListarAsync(); // ✅ chamada assíncrona
        }

        public async Task<LancamentoServicoInfo> GetLancamentoServicoAsync(int idOrdenServico)
        {
            var lancamentoServicoDAL = new LancamentoServicoDAL();
            return await lancamentoServicoDAL.GetLancamentoServicoAsync(idOrdenServico); // ✅ chamada assíncrona
        }

        public async Task AtualizarLancamentoServicoAsync(LancamentoServicoInfo lancamentoServico)
        {
            var lancamentoServicoDAL = new LancamentoServicoDAL();
            await lancamentoServicoDAL.AtualizarLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
        }

        public async Task InserirLancamentoServicoAsync(LancamentoServicoInfo lancamentoServico)
        {
            var lancamentoServicoDAL = new LancamentoServicoDAL();
            await lancamentoServicoDAL.InserirLancamentoServicoAsync(lancamentoServico); // ✅ chamada assíncrona
        }

        public async Task ExcluirLancamentoServicoAsync(int idOrdenServico)
        {
            var lancamentoServicoDAL = new LancamentoServicoDAL();
            await lancamentoServicoDAL.ExcluirLancamentoServicoAsync(idOrdenServico); // ✅ chamada assíncrona
        }
    }
}
