using Ordem-Servicos.DAL;

namespace Ordem-Servicos.BLL
{
    public class DBSetupBLL
    {
        public bool CheckAndSetupDatabase()
        {
            DBSetupDAL dbsetupDAL = new DBSetupDAL();
            return dbsetupDAL.CheckAndSetupDatabase();
        }
        public bool VerificarSeCadastrado(object valor, string tabela, string coluna)
        {
            DBSetupDAL dbsetupDAL = new DBSetupDAL();
            return dbsetupDAL.VerificarSeCadastrado(valor, tabela, coluna);
        }
    }
}
