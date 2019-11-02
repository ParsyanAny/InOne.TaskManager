using System;
using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(75)]
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public bool Deleted { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegistrationDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDay { get; set; }
    }
}
