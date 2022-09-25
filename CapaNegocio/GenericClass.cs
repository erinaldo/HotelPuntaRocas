using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace CapaNegocio
{
    public class GenericClass<T, TEntity> where T : DbContext, new() where TEntity : class
    {
        public TEntity SelectSingle(Expression<Func<TEntity, bool>> predicate, bool detach = false)
        {
            T db = new T();
            var query = db.Set<TEntity>().Where(predicate);
            var entity = query.SingleOrDefault();
            if (entity != null && detach)
                ((IObjectContextAdapter)db).ObjectContext.Detach(entity);
            return entity;
        }

        public int SelectCount(Expression<Func<TEntity, bool>> predicate, bool detach = false)
        {
            T db = new T();
            var query = db.Set<TEntity>().Where(predicate);
            var entity = query.ToList().Count;
            if (detach)
                ((IObjectContextAdapter)db).ObjectContext.Detach(entity);
            return entity;
        }

        public List<TEntity> SelectList(Expression<Func<TEntity, bool>> predicate = null, bool detach = false)
        {
            T db = new T();
            var query = db.Set<TEntity>().AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            var entityList = query.ToList();
            if (entityList.Count > 0 && detach)
            {
                foreach (var e in entityList)
                {
                    ((IObjectContextAdapter)db).ObjectContext.Detach(e);
                }
            }
            return entityList;
        }

        public bool Insert(TEntity entity)
        {
            bool success = false;
            try
            {
                using (T db = new T())
                {
                    db.Set(typeof(TEntity)).Add(entity);
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Added);
                    success = db.SaveChanges() > 0;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return success;
        }

        public bool Update(TEntity entity)
        {
            bool success = false;
            try
            {
                using (T db = new T())
                {
                    db.Set(typeof(TEntity)).Add(entity);
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                    success = db.SaveChanges() > 0;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return success;
        }

        public bool Delete(TEntity entity)
        {
            bool success = false;
            using (T db = new T())
            {
                db.Set(typeof(TEntity)).Add(entity);
                ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);

                success = db.SaveChanges() > 0;
            }
            return success;
        }

        ///// <summary>
        ///// Pages the specified query.
        ///// </summary>
        ///// <typeparam name="T">Generic Type Object</typeparam>
        ///// <typeparam name="TResult">The type of the result.</typeparam>
        ///// <param name="query">The Object query where paging needs to be applied.</param>
        ///// <param name="pageNum">The page number.</param>
        ///// <param name="pageSize">Size of the page.</param>
        ///// <param name="orderByProperty">The order by property.</param>
        ///// <param name="isAscendingOrder">if set to <c>true</c> [is ascending order].</param>
        ///// <param name="rowsCount">The total rows count.</param>
        ///// <returns></returns>
        //private static IQueryable<T> PagedResult<T, TResult>(IQueryable<T> query, int pageNum, int pageSize,
        //                Expression<Func<T, TResult>> orderByProperty, bool isAscendingOrder, out int rowsCount)
        //{
        //    if (pageSize <= 0) pageSize = 20;

        //    //Total result count
        //    rowsCount = query.Count();

        //    //If page number should be > 0 else set to first page
        //    if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

        //    //Calculate nunber of rows to skip on pagesize
        //    int excludedRows = (pageNum - 1) * pageSize;

        //    query = isAscendingOrder ? query.OrderBy(orderByProperty) : query.OrderByDescending(orderByProperty);

        //    //Skip the required rows for the current page and take the next records of pagesize count
        //    return query.Skip(excludedRows).Take(pageSize);
        //} 
    }
}
