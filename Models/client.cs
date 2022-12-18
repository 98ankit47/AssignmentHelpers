using System.ComponentModel.DataAnnotations;

namespace AssignmentHelpers.Models
{ 
    public class client
    {
        //public client()
        //{
            //assignments = new HashSet<assignment>();
            //testimonies = new HashSet<testimony>();
        //}
        [Key]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be at least 3 characters long.")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
       [StringLength(20, MinimumLength = 6, ErrorMessage = "Must be at least 6 characters long.")]
        public string password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string country { get; set; }
        public string course { get; set; }
        public string university { get; set; }
        public int duration { get; set; }
        public string google_api_id { get; set; }

       // public ICollection<assignment> assignments { get; set; }
        //public ICollection<testimony> testimonies { get; set; }

    }
}
