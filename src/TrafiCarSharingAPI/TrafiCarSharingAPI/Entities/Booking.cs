using System;

namespace TrafiCarSharingAPI.Core.Entities
{
    public class Booking
    {
        public string CarId { get; set; }
        public Guid BookingId { get; set; }
        public bool IsCarBooked { get; set; }
    }
}