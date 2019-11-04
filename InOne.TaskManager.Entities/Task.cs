using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static InOne.TaskManager.Entities.Enums;

namespace InOne.TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        [ForeignKey("Assigned")]
        public int AssignedId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public User Assigned { get; set; }
        public Status Status { get; set; }
    }
}
