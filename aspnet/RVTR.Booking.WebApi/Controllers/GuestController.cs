using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.WebApi.Controllers
{
  /// <summary>
  /// Guest controller that allows CRUD operations on
  /// the Guest Repository.
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class GuestController : ControllerBase
  {
    private readonly ILogger<GuestController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Dependency Injection
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public GuestController(ILogger<GuestController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Returns every Guest from the repository.
    /// </summary>
    /// <returns>List of Guest</returns>
    [HttpGet]
    public async Task<IEnumerable<Guest>> Get()
    {
      return await Task.FromResult<IEnumerable<Guest>>(_unitOfWork.GuestRepository.Select());
    }

    /// <summary>
    /// Returns a Guest that matches the ID
    /// that was given.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Guest</returns>
    [HttpGet("{id}")]
    public async Task<Guest> GetOne(int id)
    {
      return await Task.FromResult<Guest>(_unitOfWork.GuestRepository.Select(id));
    }

    /// <summary>
    /// Will add a Guest to the repository.
    /// </summary>
    /// <param name="guest"></param>
    /// <returns>Request success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Guest guest)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Insert(guest));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Will add a Guest to the repository or updating
    /// it if it already exists.
    /// </summary>
    /// <param name="guest"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Guest guest)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Update(guest));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Deletes a Guest from the repository that
    /// matches the given ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.GuestRepository.Delete(id));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
