using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.DataContext.Repositories
{
  /// <summary>
  /// Represents the interface for UnitOfWork.
  /// Follows Unit of Work Repository Pattern
  /// </summary>
  public interface IUnitOfWork
  {
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<Duration> DurationRepository { get; }
    IRepository<Status> StatusRepository { get; }
    IRepository<Guest> GuestRepository { get; }
    void Commit();
  }
}
