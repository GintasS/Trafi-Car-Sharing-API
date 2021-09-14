using System.Collections.Generic;
using TrafiCarSharingAPI.Core.Entities;

namespace TrafiCarSharingAPI.Core.Helpers
{
    public static class Database
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
        public static List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
