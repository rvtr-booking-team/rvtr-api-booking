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

    [HttpGet]
    public async Task<Duration> GetOne(int id)
    {
      return await Task.FromResult<Duration>(_unitOfWork.DurationRepository.Select(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(Duration duration)
    {
      await Task.FromResult(_unitOfWork.DurationRepository.Insert(duration));
      return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Duration duration)
    {
      await Task.FromResult(_unitOfWork.DurationRepository.Update(duration));
      return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      await Task.FromResult(_unitOfWork.DurationRepository.Delete(id));
      return Ok();
    }
  }
}
