﻿using OrdemServicos.DAL;

namespace OrdemServicos.BLL
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
