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
        public string Email { get; set; }

        [Display(Name ="Enrolled Classes")]
        public virtual ICollection<Class> Classes { get; set; }

        [ForeignKey(nameof(Points))]
        public int Grade { get; set; }
        public virtual Grade Points { get; set; }
    }
}
