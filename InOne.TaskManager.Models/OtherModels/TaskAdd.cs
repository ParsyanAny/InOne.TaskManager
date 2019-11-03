using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Models.OtherModels
{
    public class TaskAdd
    {
        public int CreatorId { get; set; }
        public int AssignedId { get; set; }
        public DateTime ExpirationDate { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> AttachmentIds { get; set; }
    }
}
