using Alkemy_University.Areas.Career.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        [Required(ErrorMessage = "Select one career")]
        public int CareerID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public TCareer Career { get; set; }
    }
}
