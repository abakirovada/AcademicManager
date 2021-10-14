using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class GradeList
    {
        public int GradeId { get; set; }

        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
        public double Points { get; set; }
    }
}
