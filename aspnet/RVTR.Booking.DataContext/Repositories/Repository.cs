using System.Collections.Generic;
using RVTR.Booking.DataContext.Database;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RVTR.Booking.DataContext.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {

    private readonly BookingDbContext _dbc;

    public Repository() {}
    public Repository(BookingDbContext context)
    {
      _dbc = context;
    }

    public bool Delete(int id)
    {
      var entity = _dbc.Set<TEntity>().Find(id);
      if(entity != null) {
        _dbc.Set<TEntity>().Remove(entity);
        return true;
      }
      return false;
    }

    public bool Insert(TEntity entity)
    {
      _dbc.Set<TEntity>().Add(entity);
      return true;
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
      var context = new ValidationContext(entity, null, null);
      var results = new List<ValidationResult>();
      if (Validator.TryValidateObject(entity, context, results, true))
      {
        _dbc.Set<TEntity>().Update(entity);
        return true;
      }

      return false;
    }
  }
}
