using Alkemy_University.Areas.Career.Models;
using Alkemy_University.Areas.Course.Models;
using Alkemy_University.Areas.Inscriptions.Models;
using Alkemy_University.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alkemy_University.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityExtends>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TCareer> _TCareer { get; set; }
        public DbSet<TCourse> _TCourse { get; set; }
        public DbSet<Inscription> _TInscription { get; set; }
    }
}
