using System.ComponentModel.DataAnnotations;

namespace InOne.TaskManager.Models.OtherModels
{
    public class AttachmentAdd
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Location { get; set; }
    }
}
