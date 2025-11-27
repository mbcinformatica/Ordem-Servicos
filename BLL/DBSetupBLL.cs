using OrdemServicos.DAL;
using System.Threading.Tasks;

namespace OrdemServicos.BLL
{
    public class DBSetupBLL
    {
        public async Task<bool> CheckAndSetupDatabaseAsync()
        {
            var dbsetupDAL = new DBSetupDAL();
            return await dbsetupDAL.CheckAndSetupDatabaseAsync();
        }

        public async Task<bool> VerificarSeCadastradoAsync(object valor, string tabela, string coluna)
        {
            var dbsetupDAL = new DBSetupDAL();
            return await dbsetupDAL.VerificarSeCadastradoAsync(valor, tabela, coluna);
        }
    }
}
