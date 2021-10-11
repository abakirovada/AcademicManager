using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class GradeList
    {
        public int GradeId { get; set; }
        public virtual Assignment Assignment { get; set; }
        public double Points { get; set; }
    }
}
