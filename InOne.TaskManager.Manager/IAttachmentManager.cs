using InOne.TaskManager.Entities;

namespace InOne.TaskManager.Manager
{
    public interface IAttachmentManager
    {
        void AddAttachment(Attachment attachment);
        void AddAttachment(string name, string location);
    }
}
