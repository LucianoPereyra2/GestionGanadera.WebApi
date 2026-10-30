using GestionGanadera.Entities;
using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGanadera.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<MovimientoLote> MovimientoLotes { get; set; }
        public virtual DbSet<Pesaje> Pesajes { get; set; }
        public virtual DbSet<Sector> Sectores { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EspecieAnimal> EspeciesAnimales { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.Write);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.Entity<Pesaje>()
                .HasOne(p => p.Lote)
                .WithMany()
                .HasForeignKey(p => p.LoteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovimientoLote>()
                .HasOne(m => m.lote)
                .WithMany()
                .HasForeignKey(m => m.LoteId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
