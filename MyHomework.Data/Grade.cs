using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [ForeignKey(nameof(Class))]
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey(nameof(Assignment))]
        public int? AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public double Points { get; set; }
    }
}
