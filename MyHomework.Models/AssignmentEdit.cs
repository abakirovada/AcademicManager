using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class AssignmentEdit
    {
        public int AssignmentId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}
