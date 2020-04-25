// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using RVTR.Booking.ObjectModel.Models;
// using RVTR.Booking.DataContext.Repositories;

// namespace RVTR.Booking.WebApi.Controllers
// {
//   [ApiController]
//   [EnableCors()]
//   [Route("[controller]/[action]")]
//   public class ReservationController : ControllerBase
//   {
//     private readonly ILogger<ReservationController> _logger;
//     private readonly Repository<Reservation> _reservationRepo;
//     public ReservationController(ILogger<ReservationController> logger, UnitOfWork unitOfWork)
//     {
//       _logger = logger;
//       _reservationRepo = unitOfWork.ReservationRepository;
//     }

//     [HttpGet]
//     public async Task<IEnumerable<Reservation>> Get()
//     {
//       var reservation = _reservationRepo.Select();
//       return await Task.FromResult<IEnumerable<Reservation>>(reservation);
//     }

//     [HttpGet]
//     public async Task<Reservation> GetOne(int id)
//     {
//       var reservation = _reservationRepo.Select(id);
//       return await Task.FromResult<Reservation>(reservation);
//     }

//     [HttpPost]
//     public async Task<IActionResult> Post(Reservation reservation) {
//       var success = await Task.FromResult<bool>(_reservationRepo.Insert(reservation));
//       if(success)
//       {
//         return  Ok();
//       }
//       return BadRequest();
//     }

//     [HttpDelete]
//     // [ProducesResponseType(StatusCodes.Status201Created)]
//     // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<IActionResult> Delete(int id){
//       var success = await Task.FromResult<bool>(_reservationRepo.Delete(id));
//       if(success)
//       {
//         return  Ok();
//       }
//       return BadRequest();
//     }

//     [HttpPut]
//     public async Task<IActionResult> Put(Reservation reservation)
//     {
//       await Task.FromResult(_reservationRepo.Update(reservation));
//       return Ok();
//     }
//   }
// }
