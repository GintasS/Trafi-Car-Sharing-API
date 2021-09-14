namespace TrafiCarSharingAPI.Core.Configuration
{
    public static class Constants
    {
        public static string DeviceStateQueue = "https://sqs.eu-west-1.amazonaws.com/577284730396/go-sharing-ruptela-states.fifo";
        public static string DeviceCommandQueue = "https://sqs.eu-west-1.amazonaws.com/577284730396/go-sharing-ruptela-commands.fifo";

        public static int WaitTime = 2;
    }
}
