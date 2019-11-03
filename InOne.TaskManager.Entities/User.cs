using System;
using System.ComponentModel.DataAnnotations;
using static InOne.TaskManager.Entities.Enums;

namespace InOne.TaskManager.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        //[ForeignKey("Gender")]
        //public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
