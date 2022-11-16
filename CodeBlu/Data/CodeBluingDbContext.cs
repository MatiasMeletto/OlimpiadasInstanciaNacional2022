using CodeBlu.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeBlu.Data
{
    public class CodeBluingDbContext : IdentityDbContext
    {
        public DbSet<Zona> Zonas{ get; set;}
        public DbSet<Paciente> Pacientes{ get; set;}
        public DbSet<PersonalMedico> Personal { get; set;}
        public DbSet<Llamado> Llamados { get; set;}
        public DbSet<User> Usuarios { get; set;}
        public CodeBluingDbContext(DbContextOptions<CodeBluingDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.DNI)
                .IsUnique();
            
            modelBuilder.Entity<PersonalMedico>()
                .HasIndex(p => p.DNI)
                .IsUnique();

            modelBuilder
                .Entity<Llamado>()
                .Property(l => l.OrigenLlamado)
                .HasConversion<string>()
                .HasMaxLength(255);
            
            modelBuilder
                .Entity<Llamado>()
                .Property(l => l.TipoLlamado)
                .HasConversion<string>()
                .HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}