using System;
using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Location { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
