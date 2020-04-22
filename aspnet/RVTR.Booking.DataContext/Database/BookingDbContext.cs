// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using RVTR.Booking.ObjectModel.Models;

// namespace RVTR.Booking.DataContext.Database
// {
//   public class ContagionDbContext : DbContext
//   {
//     public DbSet<Reservation> Reservation { get; set; }
//     public DbSet<Duration> Duration { get; set; }
//     public DbSet<Guest> Guest { get; set; }
//     public DbSet<Status> Status { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder builder)
//     {
//       builder.UseSqlServer("server=sql;database=bookingdb;user id=sa;password=Password12345;");
//     }

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//       builder.Entity<Reservation>().HasKey(r => r.ReservationId);
//       builder.Entity<Duration>().HasKey(d=> d.DurationId);
//       builder.Entity<Guest>().HasKey(g => g.GuestId);
//       builder.Entity<Status>().HasKey(s => s.StatusId);

//       builder.Entity<Status>().HasMany(s => s.Reservations).WithOne(r => r.Status);
//     }
//   }
// }
