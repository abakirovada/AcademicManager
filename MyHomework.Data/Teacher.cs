using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        //[Required]
        //public Guid MyId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name ="Classes Taught")]
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
