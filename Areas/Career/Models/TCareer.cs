using Alkemy_University.Areas.Course.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alkemy_University.Areas.Career.Models
{
    public class TCareer
    {
        [Key]
        public int CareerID { get; set; }
        [Required(ErrorMessage ="This field must be filled")]
        public string Name { get; set; }
        [Required(ErrorMessage ="This field must be filled")]
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        public ICollection<TCourse> Courses { get; set; }
    }
}
