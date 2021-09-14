using TrafiCarSharingAPI.Core.Models;

namespace TrafiCarSharingAPI.Core.Entities
{
    public sealed class DeviceState
    {
        public string CarId { get; set; }
        public string Imei { get; set; }
        public int MileageTotalKm { get; set; }
        public decimal FuelRemainingFraction { get; set; }
        public bool Ignition { get; set; }
        public bool Locked { get; set; }
        public LatLng Position { get; set; }
    }
}
