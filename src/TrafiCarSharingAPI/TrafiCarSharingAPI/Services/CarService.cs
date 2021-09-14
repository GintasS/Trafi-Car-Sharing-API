using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS.Model;
using TrafiCarSharingAPI.Core.Configuration;
using TrafiCarSharingAPI.Core.Entities;
using TrafiCarSharingAPI.Core.Helpers;
using TrafiCarSharingAPI.Core.Interfaces;

namespace TrafiCarSharingAPI.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IQueueService _queueService;

        public CarService(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task<Car> FindCarById(string carId)
        {
            var result = Database.Cars.FirstOrDefault(x => x.Id == carId);

            return result;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var cars = Database.Cars;

            return cars;
        }

        public async Task<DeviceState> GetSingleCarDeviceState()
        {
            var message = await _queueService.GetMessage(Constants.DeviceStateQueue, Constants.WaitTime);

            if (message.Messages.Count != 0)
            {
                await _queueService.DeleteMessage(message.Messages[0], Constants.DeviceStateQueue);
                return JsonSerializer.Deserialize<DeviceState>(message.Messages[0].Body);
            }

            return null;
        }

        public async Task<Guid> StartCarBooking(Car car)
        {
            var bookingId = Guid.NewGuid();

            Database.Bookings.Add(new Booking
            {
                BookingId = bookingId,
                CarId = car.Id,
                IsCarBooked = true
            });

            return bookingId;
        }

        public async Task<Guid> FinishCarBooking(Booking booking)
        {
            var bookingId = booking.BookingId;
            booking.IsCarBooked = false;
            booking.BookingId = Guid.Empty;

            return bookingId;
        }

        public async Task<bool> UnlockCar(DeviceState device)
        {
            var msgBody = JsonSerializer.Serialize<DeviceCommand>(new DeviceCommand()
            {
                Imei = device.Imei,
                Command = CommandType.Unlock
            });

            var sendMessageRequest = new SendMessageRequest(Constants.DeviceCommandQueue, msgBody);
            sendMessageRequest.MessageGroupId = "foo345";
            sendMessageRequest.MessageDeduplicationId = "footest";
            await _queueService.SendMessage(sendMessageRequest);

            return true;
        }

        public async Task<Booking> FindBookingByCarId(string carId)
        {
            var result = Database.Bookings.FirstOrDefault(x => x.CarId == carId);

            return result;
        }

        public async Task<Booking> FindBookingByBookingId(string bookingId)
        {
            var result = Database.Bookings.FirstOrDefault(x => x.BookingId.ToString() == bookingId);

            return result;
        }

        public async Task<Car> FindCarByBookingId(string bookingId)
        {
            var booking = await FindBookingByBookingId(bookingId);
            var carId = booking.CarId;

            return await FindCarById(carId);
        }

        public async Task<IEnumerable<Car>> GetAllCarsWithDeviceState()
        {
            var cars = await GetAllCars();
            var newCars = new List<Car>();

            var carsCount = cars.Count();
            for (var i = 0; i < carsCount; i++)
            {
                var carsDeviceState = await GetSingleCarDeviceState();

                if (carsDeviceState == null)
                {
                    continue;
                }

                var foundCar = cars.FirstOrDefault(x => x.Tracker.Imei == carsDeviceState.Imei);
                if (foundCar != null)
                {
                    foundCar.DeviceState = carsDeviceState;
                }
                newCars.Add(foundCar);
            }

            return newCars;
        }
    }
}
