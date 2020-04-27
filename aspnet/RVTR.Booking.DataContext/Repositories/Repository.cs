using System.Collections.Generic;
using RVTR.Booking.DataContext.Database;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RVTR.Booking.DataContext.Repositories
{
  /// <summary>
  /// Generic Repository Class to handle database interaction for all booking models
  /// </summary>
  /// <typeparam name="TEntity">Model type parameter for the repository</typeparam>
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {

    private readonly BookingDbContext _dbc;

    public Repository() {}

    /// <summary>
    /// Constructor that injects the dbContext
    /// </summary>
    /// <param name="context">BookingDbContext from startup injection</param>

    public Repository(BookingDbContext context)
    {
      _dbc = context;
    }

    /// <summary>
    /// Delete an entity from the database
    /// </summary>
    /// <param name="id">Entity id that represents the record primary key</param>
    /// <returns>Returns true if sucessful, false if unsuccessful</returns>
    public bool Delete(int id)
    {
      var entity = _dbc.Set<TEntity>().Find(id);
      if(entity != null) {
        _dbc.Set<TEntity>().Remove(entity);
        return true;
      }
      return false;
    }
    /// <summary>
    /// Insert an entity into the database
    /// </summary>
    /// <param name="entity">The entity to insert into the database</param>
    /// <returns>Returns true when completed</returns>
    public bool Insert(TEntity entity)
    {
      _dbc.Set<TEntity>().Add(entity);
      return true;
    }

    /// <summary>
    /// Select all entities from the database
    /// </summary>
    /// <returns>Returns list of all entities</returns>
    public IEnumerable<TEntity> Select()
    {
      return _dbc.Set<TEntity>().ToList();
    }

    /// <summary>
    /// Select one entity from the database
    /// </summary>
    /// <param name="id">Primary key of entity to select</param>
    /// <returns>Returns entity if valid, null if entity does not exist</returns>
    public TEntity Select(int id)
    {
      var entity = _dbc.Set<TEntity>().Find(id);
      if(entity != null)
      {
        return entity;
      }
      return null;
    }

    /// <summary>
    /// Update an entity in the database
    /// </summary>
    /// <param name="entity">Updated entity to add</param>
    /// <returns>Returns true if successful, false if unsuccessful</returns>
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
