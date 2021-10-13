using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public int AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public double Points { get; set; }
    }
}
