using OrdemServicos.DAL;
using OrdemServicos.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL clienteDAL;

        public ClienteBLL()
        {
            clienteDAL = new ClienteDAL();
        }

        public async Task<List<ClienteInfo>> ListarAsync()
        {
            return await clienteDAL.ListarAsync();
        }

        public async Task<ClienteInfo> GetClienteAsync(int idCliente)
        {
            return await clienteDAL.GetClienteAsync(idCliente);
        }

        public async Task AtualizarClienteAsync(ClienteInfo cliente)
        {
            await clienteDAL.AtualizarClienteAsync(cliente);
        }

        public async Task InserirClienteAsync(ClienteInfo cliente)
        {
            await clienteDAL.InserirClienteAsync(cliente);
        }

        public async Task ExcluirClienteAsync(int idCliente)
        {
            await clienteDAL.ExcluirClienteAsync(idCliente);
        }
    }
}
