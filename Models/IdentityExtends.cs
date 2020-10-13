using Microsoft.AspNetCore.Identity;

namespace Alkemy_University.Models
{
    public class IdentityExtends : IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DNI { get; set; }
        public bool Status { get; set; }
    }
}