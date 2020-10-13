using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Expedientes.Models
{
    public class Estados
    {
        public Estados()
        {
            Expediente = new HashSet<Expediente>();
        }
        [Key]
        public short IdEstado { get; set; }
        [Display(Name = "Estado")]
        public string DescEstado { get; set; }

        public virtual ICollection<Expediente> Expediente { get; set; }
    }
}
