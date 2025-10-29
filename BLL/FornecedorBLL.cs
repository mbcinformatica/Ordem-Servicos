using Ordem-Servicos.DAL;
using Ordem-Servicos.Model;
using System.Collections.Generic;

namespace Ordem-Servicos.BLL
{
    public class FornecedorBLL
    {
        public List<FornecedorInfo> Listar()
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            return fornecedorDAL.Listar();
        }
        public FornecedorInfo GetFornecedor(int IDFornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            return fornecedorDAL.GetFornecedor(IDFornecedor);
        }
        public void AtualizarFornecedor(FornecedorInfo Fornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.AtualizarFornecedor(Fornecedor);
        }
        public void InserirFornecedor(FornecedorInfo Fornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.InserirFornecedor(Fornecedor);
        }
        public void ExcluirFornecedor(int IdFornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.ExcluirFornecedor(IdFornecedor);
        }
    }
}
