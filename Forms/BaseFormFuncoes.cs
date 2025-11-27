using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdemServicos.Forms
{
    public interface BaseFormFuncoes
    {
        DateTime dataEmissaoControl { get; set; }
        bool escPressed { get; set; }
        bool CampoObrigatorio { get; set; }
        bool bNovo { get; set; }
        string TagFormato { get; set; }
        string TagAction { get; set; }
        int TagMaxDigito { get; set; }
        Control ControleAnterior { get; set; }
        Task CarregarRegistros();
        void LimparCampos();
        void ExecutaFuncaoEventoAsync(Control control);
    }
}
