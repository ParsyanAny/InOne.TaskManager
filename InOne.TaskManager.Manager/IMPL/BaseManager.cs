using InOne.TaskManager.DataAccessLayer;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace InOne.TaskManager.Manager.IMPL
{
    public abstract class BaseManager<TEntity, TModel> : IBaseManager<TEntity, TModel>
            where TEntity : class
            where TModel : class
    {
        protected readonly ApplicationContext _context;
        protected BaseManager(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(TEntity model) => _context.Set<TEntity>().Add(model);
        public bool Any(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Any(predicate);
        public void DeleteById(int Id)
             => TrySetProperty(GetEntity(Id), "Deleted", true);
        public void DeleteSaveLog(int Id)
        {
            DeleteById(Id);
            _context.SaveChanges();
            Logger(Id);
        }
        public TEntity GetEntity(int Id) => _context.Set<TEntity>().Find(Id);

        public abstract TModel EntityToModel(TEntity entity);
        public abstract TEntity ModelToEntity(TModel model);

        private void TrySetProperty(object entity, string property, object value)
        {
            var prop = entity.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(entity, value, null);
        }
        protected void Logger(int Id)
        {
            var entity = GetEntity(Id);
            const string LogPath = @"C:\Users\Any\source\repos\InOne.TaskManager\InOne.TaskManager.Api\logs\";      
            const string LogFile = "UsersLog.txt";
            string logWrite = "";
            var changeDate = entity.GetType().GetProperty("CreateDate");
            var registrationDate = entity.GetType().GetProperty("RegistrationDate");

           // bool exists = Directory.Exists(LogPath);
           // if (!exists)
             //   Directory.CreateDirectory(LogPath);

            if (registrationDate == null && changeDate == null)
                return;
            if (changeDate != null)
                logWrite = $"Deleted Id {Id}, CreateDate {changeDate}";

            logWrite = $"Deleted Id {Id}, Registration Date {registrationDate.GetValue(entity).ToString()}";
            
            using (StreamWriter sw = File.AppendText(LogPath + LogFile)) 
            {
                sw.WriteLine(logWrite);
            }
        }

        //public void Update(TModel model, int Id)
        //{
        //    var entity = ModelToEntity(model);
        //    var nameBuilder = new StringBuilder();
        //    var valueBuilder = new StringBuilder();

        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    foreach (var prop in entity.GetType().GetProperties().Where(p => p.Name != "Id" && p.GetValue(entity) != null))
        //    {
        //        if (prop != null)
        //        {
        //            nameBuilder.Append(prop.Name).Append("=").Append("@").Append(prop.Name).Append(",");

        //            var sqlP = new SqlParameter(prop.Name, prop.PropertyType);
        //            object value = prop.GetValue(entity);
        //            if (value == null)
        //                value = DBNull.Value;
        //            sqlP.Value = value;
        //            parameters.Add(sqlP);
        //        }
        //    }
        //    string nameText = nameBuilder.ToString().TrimEnd(',');
        //    string tableName = _context.Set<TEntity>().ToString();
        //    string query = string.Format($"UPDATE {tableName} SET {nameText} WHERE Id = {Id} " + $"SELECT id FROM {tableName}");

        //}
    }
}
