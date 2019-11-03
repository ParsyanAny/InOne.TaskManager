using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;

namespace InOne.TaskManager.Manager
{
    public interface IAttachmentManager : IBaseManager<Attachment, AttachmentModel>
    {
        void AddAttachment(AttachmentAdd attachmentAdd);
    }
}
