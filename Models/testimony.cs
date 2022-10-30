using System.ComponentModel.DataAnnotations;
namespace AssignmentHelpers.Models
{
    public class testimony
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public string feedback { get; set; }
        public client client { get; set; }
    }
}
