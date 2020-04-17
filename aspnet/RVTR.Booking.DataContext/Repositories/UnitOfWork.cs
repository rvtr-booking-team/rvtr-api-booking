using System;

namespace RVTR.Booking.DataContext.Repositories
{
  public class UnitOfWork : IUnitofWork
  {
    public void Commit() => throw new NotImplementedException();
  }
}
