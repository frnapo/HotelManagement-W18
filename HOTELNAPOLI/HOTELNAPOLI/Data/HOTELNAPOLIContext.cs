using HOTELNAPOLI.Models;
using Microsoft.EntityFrameworkCore;

namespace HOTELNAPOLI.Data
{
    public class HOTELNAPOLIContext : DbContext
    {
        public HOTELNAPOLIContext(DbContextOptions<HOTELNAPOLIContext> options)
            : base(options)
        {
        }

        public DbSet<HOTELNAPOLI.Models.Clienti> Clienti { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.Camere> Camere { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.Servizi> Servizi { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.Pensioni> Pensioni { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.Prenotazioni> Prenotazioni { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.Login> Login { get; set; } = default!;
        public DbSet<HOTELNAPOLI.Models.CheckoutViewModel> CheckoutViewModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckoutViewModel>().HasNoKey();
        }
    }
}
