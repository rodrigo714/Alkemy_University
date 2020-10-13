using Expedientes_Goya.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expedientes_Goya.Areas.Organizaciones.Models
{
    public class Organizaciones
    {
        public Organizaciones()
        {
            AspNetUsers = new HashSet<IdentityExtends>();
        }
        [Key]
        public int IdOrganizacion { get; set; }
        [Display(Name ="Organizacion")]
        public string DescOrganizacion { get; set; }
        [Display(Name = "Direccion")]
        public string DirOrganizacion { get; set; }
        [Display(Name = "Telefono")]
        public string TelOrganizacion { get; set; }
        [Display(Name = "Email")]
        public string MailOrganizacion { get; set; }

        public virtual ICollection<IdentityExtends> AspNetUsers { get; set; }
    }
}
