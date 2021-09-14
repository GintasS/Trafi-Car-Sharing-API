using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrafiCarSharingAPI.Core.Entities;
using TrafiCarSharingAPI.Core.Helpers;
using TrafiCarSharingAPI.Core.Interfaces;
using TrafiCarSharingAPI.Core.Models.Requests;
using TrafiCarSharingAPI.Core.Models.Responses;

namespace TrafiCarSharingAPI.Core.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GetCarsResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllCars()
        {
            var newCars = await _carService.GetAllCarsWithDeviceState();

            if (newCars.Any() == false)
            {
                return NotFound("No cars were found in Database.");
            }

            return Ok(new GetCarsResponse
            {
                Cars = newCars
            });

            // 500 here?
        }

        [HttpPatch]
        [Route("states")]
        [ProducesResponseType(200, Type = typeof(GetCarsResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDeviceStateForAllCars()
        {
            var newCars = await _carService.GetAllCarsWithDeviceState();

            if (newCars.Any() == false)
            {
                return NotFound("No cars were found in Database.");
            }

            foreach (var car in Database.Cars)
            {
                car.DeviceState = newCars.FirstOrDefault(z => z.Id == car.Id).DeviceState;
            }


            return Ok(newCars);

            // 500 here?
        }


        [HttpPost("booking/start")]
        [ProducesResponseType(200, Type = typeof(BookCarResponse))]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> StartCarBooking(BookCarRequest request)
        {
            var car = await _carService.FindCarById(request.CarId);

            if (car == null)
            {
                return NotFound("Car by the provided CarId does not exist.");
            }

            var booking = await _carService.FindBookingByCarId(car.Id);

            if (booking != null && booking.IsCarBooked)
            {
                return Conflict("Booking process for car with provided CarId is not available, car is already booked.");
            }

            var bookingId = await _carService.StartCarBooking(car);

            return Ok(new BookCarResponse
            {
                BookingId = bookingId.ToString()
            });

            // 500 here?
        }

        [HttpPost("booking/finish")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> FinishCarBooking(FinishBookingRequest request)
        {
            var booking = await _carService.FindBookingByBookingId(request.BookingId);

            if (booking == null)
            {
                return NotFound("Booking by the provided BookingId does not exist.");
            }

            await _carService.FinishCarBooking(booking);

            var car = await _carService.FindCarByBookingId(booking.BookingId.ToString());

            var tempGuid = new Guid(request.BookingId);
            await _carService.UnlockCar(car.DeviceState);

            return Ok(tempGuid);
            // 500 here?
        }
    }
}
