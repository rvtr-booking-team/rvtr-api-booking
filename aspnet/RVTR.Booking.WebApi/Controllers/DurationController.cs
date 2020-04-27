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
  /// api controller that guides reservation http requests
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class DurationController : ControllerBase
  {
    private readonly ILogger<DurationController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Dependency Injection
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public DurationController(ILogger<DurationController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get method for all all durations
    /// </summary>
    /// <returns>List of Durations</returns>
    [HttpGet]
    public async Task<IEnumerable<Duration>> Get()
    {
      return await Task.FromResult<IEnumerable<Duration>>(_unitOfWork.DurationRepository.Select());
    }

    /// <summary>
    /// Get method for specific duration
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Duration</returns>
    [HttpGet("{id}")]
    public async Task<Duration> GetOne(int id)
    {
      return await Task.FromResult<Duration>(_unitOfWork.DurationRepository.Select(id));
    }

    /// <summary>
    /// Post method for durations
    /// </summary>
    /// <param name="duration"></param>
    /// <returns>Request success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Duration duration)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.DurationRepository.Insert(duration));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Put method for durations
    /// </summary>
    /// <param name="duration"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put(Duration duration)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.DurationRepository.Update(duration));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete method for durations
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.DurationRepository.Delete(id));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
