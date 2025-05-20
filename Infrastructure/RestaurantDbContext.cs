using Microsoft.EntityFrameworkCore;
using Nina.Restoran.Api.Domain;

namespace Nina.Restoran.Api.Infrastructure
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Table>(b =>
            {
                b.ToTable("Tables");
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.HasKey(e => e.Id);
                b.Property(e => e.NumberOfChairs).IsRequired();
                b.Property(e => e.Position).IsRequired();
            });

            modelBuilder.Entity<People>(b =>
            {
                b.ToTable("People");
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.HasKey(e => e.Id);
                b.Property(e => e.FirstName).IsRequired();
                b.Property(e => e.LastName).IsRequired();
                b.Property(e => e.PhoneNumber).IsRequired();
            });

            modelBuilder.Entity<Reservation>(b =>
            {
                b.ToTable("Reservation");
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.HasKey(e => e.Id);
                b.Property(e => e.NumberOfPeople).IsRequired();
                b.Property(e => e.TimeOfReservation).IsRequired();
                b.HasOne(r => r.Table)
                    .WithMany()
                    .HasForeignKey(r => r.TableId)
                    .OnDelete(DeleteBehavior.Cascade); //Cascade: Ako obrišeš Table, EF automatski briše i sve Reservation-e koje su bile vezane za taj stol.
                b.HasOne(r => r.People)
                    .WithMany()
                    .HasForeignKey(r => r.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
