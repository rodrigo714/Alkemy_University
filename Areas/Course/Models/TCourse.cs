using Alkemy_University.Areas.Career.Models;
using System.ComponentModel.DataAnnotations;

namespace Alkemy_University.Areas.Course.Models
{
    public class TCourse
    {
        [Key]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "This field must be filled")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field must be filled")]
        public string Description { get; set; }
        public byte Hours { get; set; }
        public bool Status { get; set; }
        public int CareerID { get; set; }
        public TCareer Career { get; set; }
    }
}
