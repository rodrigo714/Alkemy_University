using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Expedientes.Models
{
    public class Expediente
    {
        [Key]
        public int IdExpdt { get; set; }
        public string NumExpdt { get; set; }
        public short IdDepInicio { get; set; }
        public string IdOperador { get; set; }
        public string IdUsuario { get; set; }
        public string Extracto { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime FechaAltaExpte { get; set; }
        [Display(Name = "Fecha de Finalizacion")]
        public DateTime? FechaFinalExpte { get; set; }
        public short? Estado { get; set; }
    }
}
