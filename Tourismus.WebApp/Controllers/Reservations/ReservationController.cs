using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Controllers.Offers {
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase {

        public ReservationController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CancelReservation([FromBody] int reservationId) {
            var reservation = context.Reservations.First(o => o.Id == reservationId);
            if (reservation == null) {
                throw new Exception("Reservation does not exist.");
            }


            context.Reservations.Remove(reservation);
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Reservation_ListDto[]> GetListReservations(int userId) {
            var resp = new Reservation_ListMapperHandler().Handle(context.Reservations.Where(r => r.User.Id == userId), CancellationToken.None);
            return resp.Result.ToArray();
        }
    }
}
