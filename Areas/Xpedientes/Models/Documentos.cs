using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Expedientes.Models
{
    public class Documentos
    {
        public Documentos()
        {
            Eventos = new HashSet<Eventos>();
        }
        [Key]
        public int IdDocumento { get; set; }
        [Display(Name = "Documento")]
        public string DescDocumento { get; set; }
        [Display(Name = "Ruta")]
        public string RutaDocumento { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha de Alta")]
        public DateTime? FechaAlta { get; set; }

        public virtual ICollection<Eventos> Eventos { get; set; }
    }
}
