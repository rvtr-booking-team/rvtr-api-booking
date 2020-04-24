using System.Collections.Generic;
using System;

namespace RVTR.Booking.DataContext.Repositories
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}
