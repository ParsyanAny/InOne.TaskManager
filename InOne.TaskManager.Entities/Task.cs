using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InOne.TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        [ForeignKey("Assigned")]
        public int AssignedId { get; set; }
        [ForeignKey("StatusCode")]
        public int StatusId { get; set; }
        [Required]
        //DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }
        [Required]
        //DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }



        [ForeignKey("Attachments")]
        public IEnumerable<int> AttachmentIds { get; set; }

        public User Creator { get; set; }
        public User Assigned { get; set; }
        public StatusCode StatusCode { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
