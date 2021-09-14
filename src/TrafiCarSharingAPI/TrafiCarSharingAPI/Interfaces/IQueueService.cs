using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace TrafiCarSharingAPI.Core.Interfaces
{
    public interface IQueueService
    {
        Task<ReceiveMessageResponse> GetMessage(string qUrl, int waitTime = 0);
        Task DeleteMessage(Message message, string qUrl);
        bool ProcessMessage(Message message);
        Task SendMessage(SendMessageRequest messageRequest);
    }
}