using CapaDatosExternos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidadesExternos;

namespace CapaNegocioExternos
{
    public class PadronEmpresasNegocio : IPadronEmpresas 
    {
       readonly PadronEmpresaApplication PadronNegocio = new PadronEmpresaApplication();

        public List<PadronEmpresas> ConsultaEmpresa(string RUC)
        {
            return PadronNegocio.ConsultaEmpresa(RUC);
        }
    }
}
