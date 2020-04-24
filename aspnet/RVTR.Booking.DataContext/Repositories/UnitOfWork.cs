using System;
using Microsoft.EntityFrameworkCore;
using RVTR.Booking.DataContext.Database;
using RVTR.Booking.ObjectModel.Models;
using RVTR.Booking.DataContext.Repositories;

namespace RVTR.Booking.DataContext.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly BookingDbContext _context;
    public Repository<Reservation> ReservationRepository { get; set; }
    public Repository<Duration> DurationRepository { get; set; }
    public Repository<Status> StatusRepository { get; set; }
    public Repository<Guest> GuestRepository { get; set; }
    public UnitOfWork() {}
    public UnitOfWork(BookingDbContext context)
    {
      _context = context;
      ReservationRepository = new Repository<Reservation>(_context);
      DurationRepository = new Repository<Duration>(_context);
      StatusRepository = new Repository<Status>(_context);
      GuestRepository = new Repository<Guest>(_context);
    }

    public void Commit()
    {
      _context.SaveChanges();
    }
  }
}
