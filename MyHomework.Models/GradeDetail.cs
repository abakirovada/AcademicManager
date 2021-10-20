using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class GradeDetail
    {
        public int GradeId { get; set; }
        public int? ClassId { get; set; }

        public int? AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public double Points { get; set; }
    }
}
