using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidadesExternos;

namespace CapaNegocioExternos
{
    public interface IPadronEmpresas
    {
        List<PadronEmpresas> ConsultaEmpresa(string RUC);
    }
}
