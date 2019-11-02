using InOne.TaskManager.Manager;

namespace InOne.Reservation.Manager
{
    public interface IUnitOfWork
    {
        IUserManager UserManager { get; }
        ITaskManager TaskManager { get; }
        IAttachmentManager AttachmentManager { get; }
        void Commit();
        void RejectChanges();
        void Dispose();
    }
}
