// using System.Collections.Generic;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Reservation>().HasKey(r => r.ReservationId);
      builder.Entity<Duration>().HasKey(d=> d.DurationId);
      builder.Entity<Guest>().HasKey(g => g.GuestId);
      builder.Entity<Status>().HasKey(s => s.StatusId);

      builder.Entity<Status>().HasMany(s => s.Reservations).WithOne(r => r.Status); // Does this need a foreign key?
      builder.Entity<Reservation>().HasMany(r => r.Guests).WithOne(g => g.Reservation);
      builder.Entity<Reservation>().HasOne(d => d.Duration).WithOne(r => r.Reservation).HasForeignKey<Duration>(d => d.DurationId);
    }
  }
}
