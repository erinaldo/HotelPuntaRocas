using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CapaDatos;
using CapaEntidades;
using System.Linq.Expressions;

namespace CapaNegocio
{
    public class UsuarioNegocio : GenericClass<SysHotelEntities, Usuario>, IDisposable
    {
        private SysHotelEntities _dataContext;
        public UsuarioNegocio()
        {
            _dataContext = new SysHotelEntities();
        }
        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaUsuarioList> SelectListView(Expression<Func<vistaUsuarioList,
                                                bool>> predicate = null,
                                                bool detach = false)
        {
            var query = _dataContext.Set<vistaUsuarioList>().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var entityList = query.ToList();
            if (entityList.Count <= 0 || !detach) return entityList;
            foreach (var e in entityList)
            {
                ((IObjectContextAdapter)_dataContext).ObjectContext.Detach(e);
            }
            return entityList;
        }
        public byte[] ObtenerPassword(int _id)
        {
            var e = _dataContext.Usuario.SingleOrDefault(item => item.id == _id);
            return e != null ? e.password_usuario : new byte[] {};
        }
    }
}
