using Microsoft.EntityFrameworkCore;
using RVTR.Booking.DataContext.Database;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.DataContext.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly BookingDbContext _context;
    public IRepository<Reservation> ReservationRepository { get; set; }
    public IRepository<Duration> DurationRepository { get; set; }
    public IRepository<Status> StatusRepository { get; set; }
    public IRepository<Guest> GuestRepository { get; set; }
    public UnitOfWork() {}
    public UnitOfWork(BookingDbContext context)
    {
      _context = context;
      ReservationRepository = new Repository<Reservation>(_context);
      DurationRepository = new Repository<Duration>(_context);
      StatusRepository = new Repository<Status>(_context);
      GuestRepository = new Repository<Guest>(_context);
    }
    /// <summary>
    /// Commit() saves all changes to the database
    /// </summary>
    /// <returns>void</returns>
    public void Commit()
    {
      _context.SaveChanges();
    }
  }
}
