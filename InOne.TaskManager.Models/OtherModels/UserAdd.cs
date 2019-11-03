using System;
using static InOne.TaskManager.Entities.Enums;

namespace InOne.TaskManager.Models.OtherModels
{
    public class UserAdd
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
