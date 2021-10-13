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

        public int ClassId { get; set; }

    }
}
