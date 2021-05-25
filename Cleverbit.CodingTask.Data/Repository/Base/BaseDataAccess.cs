using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public abstract class BaseDataAccess<TEntity, Tkey> : IBaseDataAccess<TEntity, Tkey> where TEntity : class
    {
        protected readonly DbSet<TEntity> entity;
        protected readonly CodingTaskContext context;

        public BaseDataAccess(CodingTaskContext _Context)
        {
            context = _Context;
            entity = context.Set<TEntity>();
        }

        public List<TEntity> GetAllNotTracked()
        {
            return entity.AsNoTracking().ToList();
        }

        public List<TEntity> GetAllTracked()
        {
            return entity.ToList();
        }

        public int RowsCount()
        {
            return entity.AsNoTracking().Count();
        }

        public int Add(TEntity entity)
        {
            this.entity.Add(entity);
            return context.SaveChanges();
        }
        public TEntity FindByQueryTracked(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Where(predicate).FirstOrDefault();
        }

        public List<TEntity> FindAllByQueryTracked(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.Where(predicate).ToList();
        }

        public TEntity GetById(Tkey id)
        {
            return entity.Find(id);
        }

        public int Update(TEntity obj)
        {
            entity.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            entity.Remove(obj);
            context.SaveChanges();
        }

        public TEntity FindByQueryNotTracked(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public List<TEntity> FindAllByQueryNotTracked(Expression<Func<TEntity, bool>> predicate)
        {
            return entity.AsNoTracking().Where(predicate).ToList();
        }
    }
}
