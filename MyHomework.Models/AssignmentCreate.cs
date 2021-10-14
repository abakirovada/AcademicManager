using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class AssignmentCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy HH:mm:ss}")]
        public DateTimeOffset Deadline { get; set; }

        public int ClassId { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}
