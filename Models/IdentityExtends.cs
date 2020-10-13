using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expedientes_Goya.Models
{
    public class IdentityExtends : IdentityUser
    {
        [Display(Name ="Nombre")]
        public string First_Name { get; set; }
        [Display(Name ="Apellido")]
        public string Last_Name { get; set; }
        public string DNI { get; set; }
        [Display(Name ="Estado")]
        public bool Status { get; set; }
        public DateTime? Fecha_Alta { get; set; }
        public short? IdDependencia { get; set; }
        public int? IdOrganizacion { get; set; }
    }
}