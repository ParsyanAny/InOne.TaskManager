using InOne.TaskManager.DataAccessLayer;

namespace InOne.TaskManager.Manager.IMPL
{
    public abstract class BaseManager<TEntity, TModel>
            where TEntity : class
            where TModel : class
    {
        protected readonly ApplicationContext _context;
        protected BaseManager(ApplicationContext context)
        {
            _context = context;
        }

        public abstract TModel EntityToModel(TEntity entity);
        public abstract TEntity ModelToEntity(TModel model);

    }
}
