namespace TrafiCarSharingAPI.Core.Entities
{
    public sealed class DeviceCommand
    {
        public string Imei { get; set; }
        public CommandType Command { get; set; }
    }
}
