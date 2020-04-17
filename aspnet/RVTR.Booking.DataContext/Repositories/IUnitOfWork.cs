using System.Collections.Generic;

namespace RVTR.Booking.DataContext.Repositories
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}
