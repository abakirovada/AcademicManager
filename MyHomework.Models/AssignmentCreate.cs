﻿using MyHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework.Models
{
    public class AssignmentCreate
    {
        public string Name { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public virtual Class Class { get; set; }

        public bool IsAssigned { get; set; }

        public bool IsGraded { get; set; }
    }
}