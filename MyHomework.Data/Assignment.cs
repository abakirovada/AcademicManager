using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset Deadline { get; set; }

        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}
