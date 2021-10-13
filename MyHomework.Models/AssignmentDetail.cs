using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class AssignmentDetail
    {
        public int AssignmentId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public int ClassId { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}
