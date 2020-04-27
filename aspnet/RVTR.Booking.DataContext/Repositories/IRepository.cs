using System.Collections.Generic;

namespace RVTR.Booking.DataContext.Repositories
{
  /// <summary>
  /// Represents interface of a generic booking repository.
  /// </summary>
  /// <typeparam name="TEntity">A Generic Entity</typeparam>
  public interface IRepository<TEntity> where TEntity : class
  {
    bool Delete(int id);
    bool Insert(TEntity entity);
    IEnumerable<TEntity> Select();
    TEntity Select(int id);
    bool Update(TEntity entity);
  }
}
