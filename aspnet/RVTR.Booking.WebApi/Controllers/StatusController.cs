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
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class StatusController : ControllerBase
  {
    private readonly ILogger<StatusController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public StatusController(ILogger<StatusController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<Status>> Get()
    {
      return await Task.FromResult<IEnumerable<Status>>(_unitOfWork.StatusRepository.Select());
    }

    [HttpGet("{id}")]
    public async Task<Status> GetOne(int id)
    {
      return await Task.FromResult<Status>(_unitOfWork.StatusRepository.Select(id));
    }

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
