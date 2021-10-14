using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class GradeCreate
    {
        public int ClassId { get; set; }

        public int? AssignmentId { get; set; }

        public int? StudentId { get; set; }
        public double Points { get; set; }
    }
}
