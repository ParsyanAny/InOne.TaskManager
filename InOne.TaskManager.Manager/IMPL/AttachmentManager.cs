using InOne.TaskManager.DataAccessLayer;
using InOne.TaskManager.Entities;
using InOne.TaskManager.Models;
using InOne.TaskManager.Models.OtherModels;
using System;

namespace InOne.TaskManager.Manager.IMPL
{
    public class AttachmentManager : BaseManager<Attachment, AttachmentModel>, IAttachmentManager
    {
        public AttachmentManager(ApplicationContext context) : base(context) { }

        public void AddAttachment(AttachmentAdd attachment) => Add(addModelToAttachment(attachment));

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
        private Attachment addModelToAttachment(AttachmentAdd attachmentAdd)
            => new Attachment
            {
                Name = attachmentAdd.Name,
                Location = attachmentAdd.Location,
                CreateDate = DateTime.Now
            };
        #endregion
    }
}
