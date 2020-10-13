using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Expedientes.Models
{
    public class TipoEventos
    {
        public TipoEventos()
        {
            Eventos = new HashSet<Eventos>();
        }
        [Key]
        public short IdTipoEvento { get; set; }
        [Display(Name = "Tipo de Evento")]
        public string DescTipoEvento { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<Eventos> Eventos { get; set; }
    }
}
