﻿using System;
using System.ComponentModel.DataAnnotations;
using static InOne.TaskManager.Entities.Enums;

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
        public string Status { get; set; }
    }
}
