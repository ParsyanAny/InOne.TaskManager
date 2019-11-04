using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static InOne.TaskManager.Entities.Enums;

namespace InOne.TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int AssignedId { get; set; }
        public int CreatorId { get; set; }
        public Status StatusId { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Deleted { get; set; }
    }
}
