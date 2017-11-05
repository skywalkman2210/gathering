using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gathering.Models
{
    public class AddGradeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Section / Period Number")]
        public string CourseNumber { get; set; }
    }
}