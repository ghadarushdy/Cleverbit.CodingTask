using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cleverbit.CodingTask.Data
{
    public interface IBaseDataAccess<TEntity, Tkey> where TEntity : class
    {
        TEntity GetById(Tkey id);
        List<TEntity> GetAllNotTracked();
        List<TEntity> GetAllTracked();
        int Add(TEntity obj);
        int Update(TEntity obj);
        void Delete(TEntity id);
        int RowsCount();
        TEntity FindByQueryTracked(Expression<Func<TEntity, bool>> predicate);
        TEntity FindByQueryNotTracked(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindAllByQueryTracked(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindAllByQueryNotTracked(Expression<Func<TEntity, bool>> predicate);
    }
}
