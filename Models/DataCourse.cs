using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Models
{
    public class DataCourse
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Hours { get; set; }
        public bool Status { get; set; }
        public int CareerID { get; set; }
        public string ProfessorID { get; set; }
        public string ErrorMessage { get; set; }
    }
}
