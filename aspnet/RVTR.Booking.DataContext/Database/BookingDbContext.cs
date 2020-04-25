using Microsoft.EntityFrameworkCore;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.DataContext.Database
{
  public class BookingDbContext : DbContext
  {
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Duration> Duration { get; set; }
    public DbSet<Guest> Guest { get; set; }
    public DbSet<Status> Status { get; set; }
  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //  {
  //   if (!optionsBuilder.IsConfigured)
  //   {
  //     optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
  //   }
  //  }
    public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);
      modelBuilder.Entity<Duration>().HasKey(d=> d.DurationId);
      modelBuilder.Entity<Guest>().HasKey(g => g.GuestId);
      modelBuilder.Entity<Status>().HasKey(s => s.StatusId);

      modelBuilder.Entity<Status>().HasMany(s => s.Reservations).WithOne(r => r.Status); // Does this need a foreign key?
      modelBuilder.Entity<Reservation>().HasMany(r => r.Guests).WithOne(g => g.Reservation);
      modelBuilder.Entity<Reservation>().HasOne(d => d.Duration).WithOne(r => r.Reservation).HasForeignKey<Duration>(d => d.DurationId);
    }
  }
}
