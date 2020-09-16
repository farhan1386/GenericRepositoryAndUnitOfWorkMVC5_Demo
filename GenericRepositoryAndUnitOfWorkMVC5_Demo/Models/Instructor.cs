using System.ComponentModel.DataAnnotations;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }

        [Required]
        public int Experience { get; set; }
    }
}