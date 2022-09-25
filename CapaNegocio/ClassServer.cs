using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClassServer<T> where T : DbContext, new()
    {
        public DateTime GetTimeServer()
        {
            DateTime query;
            using (T db = new T())
            {
                query = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").SingleOrDefault();
            }
            return query;
        }
    }
}
