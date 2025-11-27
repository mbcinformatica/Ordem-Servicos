using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class ModeloBLL
    {
        public async Task<List<ModeloInfo>> ListarAsync()
        {
            var modeloDAL = new ModeloDAL();
            return await modeloDAL.ListarAsync();
        }

        public async Task<List<ModeloInfo>> ListarPorMarcaAsync(int idMarca)
        {
            var modeloDAL = new ModeloDAL();
            return await modeloDAL.ListarPorMarcaAsync(idMarca);
        }

        public async Task<ModeloInfo> GetModeloAsync(int idModelo)
        {
            var modeloDAL = new ModeloDAL();
            return await modeloDAL.GetModeloAsync(idModelo);
        }

        public async Task AtualizarModeloAsync(ModeloInfo modelo)
        {
            var modeloDAL = new ModeloDAL();
            await modeloDAL.AtualizarModeloAsync(modelo);
        }

        public async Task InserirModeloAsync(ModeloInfo modelo)
        {
            var modeloDAL = new ModeloDAL();
            await modeloDAL.InserirModeloAsync(modelo);
        }

        public async Task ExcluirModeloAsync(int idModelo)
        {
            var modeloDAL = new ModeloDAL();
            await modeloDAL.ExcluirModeloAsync(idModelo);
        }
    }
}
