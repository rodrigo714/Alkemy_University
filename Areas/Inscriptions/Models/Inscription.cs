using Alkemy_University.Areas.Course.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_University.Areas.Inscriptions.Models
{
    public class Inscription
    {
        [Key]
        public int InscriptionID { get; set; }
        public string StudentID { get; set; }
        public DateTime Date { get; set; }
        public int CourseID { get; set; }
        public TCourse Course { get; set; }
    }
}
