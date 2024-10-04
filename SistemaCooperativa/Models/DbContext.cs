using Microsoft.EntityFrameworkCore;

namespace SistemaCooperativa.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<DetallePrestamo> DetallePrestamos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public DbSet<TipoPrestamo> TipoPrestamos { get; set; }
        public DbSet<TipoCuenta> TipoCuentas { get; set; }
        public DbSet<Cede> Cedes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=BDCooperativa;Password=Escuadron;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir las claves primarias
            modelBuilder.Entity<Persona>().HasKey(p => p.IdPersona);
            modelBuilder.Entity<TipoPersona>().HasKey(tp => tp.IdTipoPersona);
            modelBuilder.Entity<Estatus>().HasKey(e => e.IdEstatus);
            modelBuilder.Entity<Producto>().HasKey(pr => pr.IdProducto);
            modelBuilder.Entity<Prestamo>().HasKey(p => p.IdPrestamo);
            modelBuilder.Entity<DetallePrestamo>().HasKey(dp => dp.IdDetallePrestamo);
            modelBuilder.Entity<Cuenta>().HasKey(c => c.IdCuenta);
            modelBuilder.Entity<Saldo>().HasKey(s => s.IdSaldo);
            modelBuilder.Entity<TipoPrestamo>().HasKey(tp => tp.IdTipoPrestamo);
            modelBuilder.Entity<TipoCuenta>().HasKey(tc => tc.IdTipoCuenta);
            modelBuilder.Entity<CategoriaProducto>().HasKey(cp => cp.IdCategoriaProducto);
            modelBuilder.Entity<Cede>().HasKey(c => c.IdCede);

            // Definir relaciones entre tablas
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.TipoPersona)
                .WithMany(tp => tp.Personas)
                .HasForeignKey(p => p.IdTipoPersona);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Estatus)
                .WithMany()
                .HasForeignKey(p => p.IdEstatus);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Persona)
                .WithMany()
                .HasForeignKey(p => p.IdPersona);

            modelBuilder.Entity<Cuenta>()
                .HasOne(c => c.Persona)
                .WithMany()
                .HasForeignKey(c => c.IdPersona);

            modelBuilder.Entity<DetallePrestamo>()
                .HasOne(dp => dp.Prestamo)
                .WithMany(p => p.DetallePrestamos)

                .HasForeignKey(dp => dp.IdPrestamo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
