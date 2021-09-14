namespace TrafiCarSharingAPI.Core.Entities
{
    public sealed class Car
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Seats { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public bool ChildSeat { get; set; }
        public Engine Engine { get; set; }
        public Tracker Tracker { get; set; }
        public int RangeFullKm { get; set; }
        public DeviceState DeviceState { get; set; }
    }
}
