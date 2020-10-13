using Expedientes_Goya.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Organizaciones.Models
{
    public class Dependencias
    {
        public Dependencias()
        {
            AspNetUsers = new HashSet<IdentityExtends>();
        }
        [Key]
        public short IdDependencia { get; set; }
        [Display(Name ="Dependencia")]
        public string DescDependencia { get; set; }
        public short? IdSecretaria { get; set; }
        [Display(Name ="Direccion")]
        public string DirDependencia { get; set; }
        [Display(Name ="Telefono")]
        public string TelDependencia { get; set; }
        [Display(Name ="Email")]
        public string MailDependencia { get; set; }
        public string Observaciones { get; set; }

        public virtual Secretarias IdSecretariaNavigation { get; set; }
        public virtual ICollection<IdentityExtends> AspNetUsers { get; set; }
    }
}
