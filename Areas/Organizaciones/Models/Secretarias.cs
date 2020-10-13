using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Organizaciones.Models
{
    public class Secretarias
    {
        public Secretarias()
        {
            Dependencia = new HashSet<Dependencias>();
        }
        [Key]
        public short IdSecretaria { get; set; }
        [Display(Name ="Secretaria")]
        public string DescSecretaria { get; set; }
        [Display(Name ="Direccion")]
        public string DirSecretaria { get; set; }
        [Display(Name ="Telefono")]
        public string TelSecretaria { get; set; }
        [Display(Name ="Email")]
        public string MailSecretaria { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<Dependencias> Dependencia { get; set; }
    }
}
