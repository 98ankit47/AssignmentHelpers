using System.ComponentModel.DataAnnotations;
namespace AssignmentHelpers.Models
{
    public class feed
    {
        [Key]
        public int Id { get; set; }
        public string feedPic { get; set; }
        [Required]
        public string description { get; set; }
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
