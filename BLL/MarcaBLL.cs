using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class MarcaBLL
    {
        public async Task<List<MarcaInfo>> ListarAsync()
        {
            var marcaDAL = new MarcaDAL();
            return await marcaDAL.ListarAsync();
        }

        public async Task<MarcaInfo> GetMarcaAsync(int idMarca)
        {
            var marcaDAL = new MarcaDAL();
            return await marcaDAL.GetMarcaAsync(idMarca);
        }

        public async Task AtualizarMarcaAsync(MarcaInfo marca)
        {
            var marcaDAL = new MarcaDAL();
            await marcaDAL.AtualizarMarcaAsync(marca);
        }

        public async Task InserirMarcaAsync(MarcaInfo marca)
        {
            var marcaDAL = new MarcaDAL();
            await marcaDAL.InserirMarcaAsync(marca);
        }

        public async Task ExcluirMarcaAsync(int idMarca)
        {
            var marcaDAL = new MarcaDAL();
            await marcaDAL.ExcluirMarcaAsync(idMarca);
        }
    }
}
