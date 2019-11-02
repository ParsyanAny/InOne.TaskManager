using System;
using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(75)]
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public bool Deleted { get; set; }
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDay { get; set; }
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
