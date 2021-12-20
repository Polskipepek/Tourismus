using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tourismus.Model.Models;
using Tourismus.WebApp.ReadModels.Dtos.ControllerBase;
using Tourismus.WebApp.ReadModels.Dtos.List;

namespace Tourismus.WebApp.Controllers.Offers {
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase {

        public OfferController(TourismusDbContext context) {
            this.context = context;
        }

        private readonly TourismusDbContext context;

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> AddNewOfferAction([FromBody][Required] AddNewOfferParameters parameters) {
            if (parameters == null) {
                throw new System.Exception("Add new offer without parameters?!?");
            }

            var hotel = context.Hotels.FirstOrDefault(h => h.Id == parameters.HotelId);
            if (hotel == null) {
                throw new System.Exception("Add new offer without a hotel?!?");
            }

            var city = context.Cities.FirstOrDefault(c => c.Id == parameters.CityId);
            if (city == null) {
                throw new System.Exception("Add new offer without a city?!?");
            }
            var meal = context.Meals.FirstOrDefault(c => c.Id == parameters.MealsId);
            if (meal == null) {
                throw new System.Exception("Add new offer without a meal?!?");
            }

            Offer offer = new() {
                Name = parameters.Name,
                City = city,
                DateFrom = parameters.DateFrom,
                DateTo = parameters.DateTo,
                Description = parameters.Description,
                Hotel = hotel,
                Meal = meal,
                NumberOfPeople = parameters.NumberOfPeople,
                Price = parameters.Price,
            };

            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult BookOffer([FromBody] BookOfferParameters parameters) {
            var offer = context.Offers.First(o => o.Id ==parameters.OfferId);
            if (offer == null) {
                throw new Exception("Offer does not exist.");
            }

            Reservation reservation = new() { 
                Offer = offer,
                ReservationDate= DateTime.Now,
                User = context.Users.First(u=>u.Id==parameters.UserId),
            };

            context.Reservations.Add(reservation);
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<OfferList_Dto[]> GetListOffers() {
            return OfferList_DtoFactory.BuildDtos(context, context.Offers);
        }
    }
}
