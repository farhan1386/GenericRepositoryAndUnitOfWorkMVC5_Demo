using System;
using System.ComponentModel.DataAnnotations;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Course Fee")]
        [DataType(DataType.Currency)]
        public int CourseFee { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Display(Name = "Course Duration")]
        public int CourseDuration { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Batch Time")]
        [DataType(DataType.Time)]
        public DateTime BatchTime { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}