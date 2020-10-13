using Expedientes_Goya.Areas.Career.Models;
using Expedientes_Goya.Areas.Course.Models;
using Expedientes_Goya.Areas.Expedientes.Models;
using Expedientes_Goya.Areas.Inscriptions.Models;
using Expedientes_Goya.Areas.Organizaciones.Models;
using Expedientes_Goya.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expedientes_Goya.Data
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
        public DbSet<Documentos> _TDocumentos { get; set; }
        public DbSet<Estados> _TEstados { get; set; }
        public DbSet<Eventos> _TEventos { get; set; }
        public DbSet<Expediente> _TExpedientes { get; set; }
        public DbSet<TipoEventos> _TTipoEventos { get; set; }
        public DbSet<Dependencias> _TDependencias { get; set; }
        public DbSet<Organizaciones> _TOrganizaciones { get; set; }
        public DbSet<Secretarias> _TSecretarias { get; set; }
    }
}
