using System.ComponentModel.DataAnnotations;
namespace AssignmentHelpers.Models
{
    public class banner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string bannerName { get; set; }
        [Required]
        public string updatedBy { get; set; }
        [Required]
        public DateTime updatedDate { get; set; }
        [Required]
        public string createdBy { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
    }
}
