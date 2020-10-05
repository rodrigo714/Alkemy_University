using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Areas.Career.Models
{
    public class TCareer
    {
        public int CareerID { get; set; }
        [Required(ErrorMessage ="This field must be filled")]
        public string Name { get; set; }
        [Required(ErrorMessage ="This field must be filled")]
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        //public ICollection<TCourses> Courses { get; set; }
    }
}
