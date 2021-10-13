using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Enrolled Classes")]
        public int EnrollmentId { get; set; }
        public virtual List<Enrollment> Classes { get; set; }

        [Display(Name = "Assignments")]
        public int AssignmentId { get; set; }
        public virtual List<Assignment> Assignments { get; set; }

        public int GradeId { get; set; }
        public virtual List<Grade> Points { get; set; }
    }
}
