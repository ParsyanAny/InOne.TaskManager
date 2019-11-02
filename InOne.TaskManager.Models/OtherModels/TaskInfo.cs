using System;
using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Models.OtherModels
{
    public class TaskInfo
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AssignedFirstName { get; set; }
        public string AssignedLastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpireDate { get; set; }
        public int AttachmentCount { get; set; }
        public int StatusId { get; set; }
    }
}
