﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOne.TaskManager.Models.OtherModels
{
    public class TaskChange
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedId { get; set; }
    }
}
