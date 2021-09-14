using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrafiCarSharingAPI.Core.Entities;

namespace TrafiCarSharingAPI.Core.Interfaces
{
    public interface ICarService
    {
        public Task<IEnumerable<Car>> GetAllCars();
        public Task<IEnumerable<Car>> GetAllCarsWithDeviceState();
        public Task<DeviceState> GetSingleCarDeviceState();
        public Task<Guid> StartCarBooking(Car car);
        public Task<Guid> FinishCarBooking(Booking booking);
        public Task<Car> FindCarById(string carId);
        public Task<Booking> FindBookingByCarId(string carId);
        public Task<Booking> FindBookingByBookingId(string bookingId);
        public Task<Car> FindCarByBookingId(string bookingId);
        public Task<bool> UnlockCar(DeviceState device);
    }
}
