using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
