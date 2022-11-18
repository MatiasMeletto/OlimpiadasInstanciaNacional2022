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
            //indico llave unica
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.DNI)
                .IsUnique();
            
            //indico llave unica
            modelBuilder.Entity<PersonalMedico>()
                .HasIndex(p => p.DNI)
                .IsUnique();

            //guardo los enum como string para mejor legibilidad de la base de datos desde las tablas
            modelBuilder
                .Entity<Llamado>()
                .Property(l => l.OrigenLlamado)
                .HasConversion<string>()
                .HasMaxLength(255);

            //guardo los enum como string para mejor legibilidad de la base de datos desde las tablas
            modelBuilder
                .Entity<Llamado>()
                .Property(l => l.TipoLlamado)
                .HasConversion<string>()
                .HasMaxLength(255);

            //guardo los enum como string para mejor legibilidad de la base de datos desde las tablas
            modelBuilder
                .Entity<User>()
                .Property(u => u.Rol)
                .HasConversion<string>()
                .HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}