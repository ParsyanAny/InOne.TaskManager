using System;
using System.Linq.Expressions;

namespace InOne.TaskManager.Manager
{
    public interface IBaseManager<TEntity,TModel>
    {
        void Add(TEntity model);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        void DeleteById(int Id);
        void DeleteSaveLog(int Id);
        TEntity GetEntity(int Id);
    }
}
