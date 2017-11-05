using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gathering.Models
{
    public class AssignmentCreateViewModel
    {
        public string Description { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public int PointsPossible { get; set; }

        public int PointsTotal { get; set; }

        public DateTime DueDate { get; set; }
    }
}