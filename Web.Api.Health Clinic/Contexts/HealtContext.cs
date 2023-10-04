using Microsoft.EntityFrameworkCore;
using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Contexts
{
    public class HealtContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EspecialidadeMedica> EspecialidadeMedica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE18-S15; Database=Web.Api.Healt_Clinic; User id = sa; pwd = Senai@134; TrustServerCertificate=True; ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
