using System;

namespace InOne.TaskManager.Models.OtherModels
{
    public class UserChange
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
