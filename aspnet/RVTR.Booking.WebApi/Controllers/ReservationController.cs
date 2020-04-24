using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Booking.DataContext.Repositories;
using RVTR.Booking.ObjectModel.Models;
using Microsoft.AspNetCore.Http;

namespace RVTR.Booking.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("[controller]/Action")]
  public class BookingController : ControllerBase
  {
    private readonly ILogger<BookingController> _logger;
    private readonly UnitOfWork _unitOfWork;
    private readonly Repository<Reservation> _reservationRepo;
    private HttpClient _httpclient;
    public BookingController(ILogger<BookingController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
      _reservationRepo = _unitOfWork.ReservationRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Reservation>> Get()
    {
      var reservation = _unitOfWork.ReservationRepository.Select();
      return await Task.FromResult<IEnumerable<Reservation>>(reservation);
    }

    [HttpGet]
    public async Task<Reservation> GetOne(int id)
    {
      var reservation = _reservationRepo.Select(id);
      return await Task.FromResult<Reservation>(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Reservation reservation) {
      var success = await Task.FromResult<bool>(_reservationRepo.Insert(reservation));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    [HttpDelete]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id){
      var success = await Task.FromResult<bool>(_reservationRepo.Delete(id));
      if(success)
      {
        return  Ok();
      }
      return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Reservation reservation)
    {
      await Task.FromResult(_reservationRepo.Update(reservation));
      return Ok();
    }
  }
}
