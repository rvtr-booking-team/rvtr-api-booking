using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;

namespace RVTR.Booking.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class DurationController : ControllerBase
  {
    private readonly ILogger<DurationController> _logger;
    private readonly UnitOfWork _unitOfWork;

    public DurationController(ILogger<DurationController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<Duration>> Get()
    {
      return await Task.FromResult<IEnumerable<Duration>>(_unitOfWork.DurationRepository.Select());
    }

    [HttpGet("{id}")]
    public async Task<Duration> GetOne(int id)
    {
      return await Task.FromResult<Duration>(_unitOfWork.DurationRepository.Select(id));
    }

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
