using System.ComponentModel.DataAnnotations;
namespace AssignmentHelpers.Models
{
    public class assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int clientId { get; set; }
        [Required]
        public string subject { get; set; }
        public string university { get; set; }
        [Required]
        public int paymentRecieved { get; set; }
        [Required]
        public int paymentPending { get; set; }
        [Required]
        public string currency { get; set; }

        public DateTime deadline { get; set; }
        //public client client { get; set; }
    }
}
