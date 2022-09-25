using System;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class RolNegocio : GenericClass<SysHotelEntities, Rol>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public RolNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }
        public void ActualizarPermisos(int idRol, string permisosRol)
        {
            _dataContext.pa_ActualizarPermiso(idRol, permisosRol);
        }
    }
}