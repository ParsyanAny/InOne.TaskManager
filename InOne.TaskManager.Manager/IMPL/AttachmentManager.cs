using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;

namespace InOne.TaskManager.Manager.IMPL
{
    public class AttachmentManager : BaseManager<Attachment, AttachmentModel>, IAttachmentManager
    {
        public AttachmentManager(ApplicationContext context) : base(context) { }


        public void AddAttachment(Attachment attachment) => _context.Attachments.Add(attachment);
        public void AddAttachment(string name, string location)
            => _context.Attachments.Add(new Attachment {  Location = location, Name = name});


        #region Attachment -> AttachmentModel, AttachmentModel -> Attachment
        public override AttachmentModel EntityToModel(Attachment entity)
            => new AttachmentModel
            {
                Id = entity.Id,
                Location = entity.Location,
                Name = entity.Name
            };
        public override Attachment ModelToEntity(AttachmentModel model)
            => new Attachment
            {
                Id = model.Id,
                Location = model.Location,
                Name = model.Name
            };
        #endregion
    }
}
