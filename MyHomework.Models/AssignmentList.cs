using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class AssignmentList
    {
        public int AssignmentId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public virtual Class Class { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}
