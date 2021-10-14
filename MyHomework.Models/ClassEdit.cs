using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class ClassEdit
    {
        public int ClassId { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
