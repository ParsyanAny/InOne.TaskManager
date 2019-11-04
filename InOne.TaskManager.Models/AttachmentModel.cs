using System;

namespace InOne.TaskManager.Models
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreateDate { get; set; }
        public int TaskId { get; set; }
    }
}
