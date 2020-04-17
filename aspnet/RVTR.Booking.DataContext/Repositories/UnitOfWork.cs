using System;

namespace RVTR.Booking.DataContext.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    public void Commit() => throw new NotImplementedException();
  }
}
