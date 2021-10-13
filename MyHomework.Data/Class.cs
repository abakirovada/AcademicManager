using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [Display(Name ="Name of the Class")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Teacher))]
        public Teacher TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
