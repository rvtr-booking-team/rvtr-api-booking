using System.Collections.Generic;
using RVTR.Booking.DataContext.Database;

using System.Linq;
using System.Linq.Expressions;
using System;

namespace RVTR.Booking.DataContext.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : IModelValidator
  {

    private readonly BookingDbContext _dbc;

    public Repository() {}
    public Repository(BookingDbContext context)
    {
      _dbc = context;
    }

    public void Delete(int id)
    {
      _dbc.Set<TEntity>().Remove().Where(entity => entity.id == id);

    }

    public bool Insert(TEntity entity)
    {
      if (ModelState.Isvalid)
      {
        _dbc.Set<TEntity>().Add(entity);
        return true;
      }
      return false;
    }

    public IEnumerable<TEntity> Select()
    {
      return _dbc.Set<TEntity>().ToList();
    }

    public TEntity Select(int id)
    {
      var entity = _dbc.Set<TEntity>().Find(id);
      if(entity != null)
      {
        return entity;
      }
      return null;
    }

    public bool Update(TEntity entity)
    {
      if (/* If there is no way to check for id, then how do we do this? */)
      {
        _dbc.Set<TEntity>().Update(entity);
        return true;
      }
      return false;
    }
  }
}
