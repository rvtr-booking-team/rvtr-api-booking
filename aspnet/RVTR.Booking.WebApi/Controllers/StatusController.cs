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
  /// Status controller that allows CRUD operations on
  /// the Status repository
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class StatusController : ControllerBase
  {
    private readonly ILogger<StatusController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Dependency Injection
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public StatusController(ILogger<StatusController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Returns every Status.
    /// </summary>
    /// <returns>List of Status</returns>
    [HttpGet]
    public async Task<IEnumerable<Status>> Get()
    {
      return await Task.FromResult<IEnumerable<Status>>(_unitOfWork.StatusRepository.Select());
    }

    /// <summary>
    /// Returns a Status that matches the id given.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status<returns>
    [HttpGet("{id}")]
    public async Task<Status> GetOne(int id)
    {
      return await Task.FromResult<Status>(_unitOfWork.StatusRepository.Select(id));
    }

    /// <summary>
    /// Will add a Status to the repository.
    /// </summary>
    /// <param name="status"></param>
    /// <returns>Request success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Status status)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.StatusRepository.Insert(status));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Will add a Status to the repository or updating
    /// it if it already exists.
    /// </summary>
    /// <param name="status"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Status status)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.StatusRepository.Update(status));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Deletes a Status from the repository that
    /// matches the given ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.StatusRepository.Delete(id));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
