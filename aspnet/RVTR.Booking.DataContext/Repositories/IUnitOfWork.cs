using System.Collections.Generic;
using System;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.DataContext.Repositories
{
  public interface IUnitOfWork
  {
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<Duration> DurationRepository { get; }
    IRepository<Status> StatusRepository { get; }
    IRepository<Guest> GuestRepository { get; }
    void Commit();
  }
}
