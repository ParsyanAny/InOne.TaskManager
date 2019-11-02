using InOne.TaskManager.Entities;
using System.Data.Entity;

namespace InOne.TaskManager.DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<StatusCode> StatusCodes { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public ApplicationContext() : base("ConString") { }

    }
}
