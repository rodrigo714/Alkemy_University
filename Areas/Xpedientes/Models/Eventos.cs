using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Expedientes.Models
{
    public class Eventos
    {
        [Key]
        public int IdEvento { get; set; }
        public int IdExpdt { get; set; }
        public short IdNuevaDep { get; set; }
        public string IdOperador { get; set; }
        public int? IdDocumento { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FechaEvento { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public short TipoEvento { get; set; }

        public virtual Documentos IdDocumentoNavigation { get; set; }
        public virtual Expediente IdExpdtNavigation { get; set; }
        public virtual TipoEventos TipoEventoNavigation { get; set; }
    }
}
