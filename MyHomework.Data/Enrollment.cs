using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int ClassId { get; set; }
        public int StudentId { get; set; }
    }
}
