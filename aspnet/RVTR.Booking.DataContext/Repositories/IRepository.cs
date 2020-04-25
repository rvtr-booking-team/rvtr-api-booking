using System.Collections.Generic;

namespace RVTR.Booking.DataContext.Repositories
{
  public interface IRepository<TEntity> where TEntity : class
  {
    bool Delete(int id);
    bool Insert(TEntity entity);
    IEnumerable<TEntity> Select();
    TEntity Select(int id);
    bool Update(TEntity entity);
  }
}
