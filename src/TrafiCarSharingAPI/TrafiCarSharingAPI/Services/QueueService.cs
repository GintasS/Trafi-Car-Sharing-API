using System;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using TrafiCarSharingAPI.Core.Interfaces;

namespace TrafiCarSharingAPI.Core.Services
{
    public class QueueService : IQueueService
    {
        private const int MaxMessages = 1;
        private const int WaitTime = 2;

        private readonly IAmazonSQS _sqsClient = new AmazonSQSClient();

        public async Task<ReceiveMessageResponse> GetMessage(string qUrl, int waitTime = 0)
        {
            return await _sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                QueueUrl = qUrl,
                MaxNumberOfMessages = MaxMessages,
                WaitTimeSeconds = waitTime
                // (Could also request attributes, set visibility timeout, etc.)
            });
        }

        //
        // Method to delete a message from a queue
        public async Task DeleteMessage(Message message, string qUrl)
        {
            Console.WriteLine($"\nDeleting message {message.MessageId} from queue...");
            await _sqsClient.DeleteMessageAsync(qUrl, message.ReceiptHandle);
        }

        //
        // Method to process a message
        // In this example, it simply prints the message
        public bool ProcessMessage(Message message)
        {
            Console.WriteLine($"\nMessage body of {message.MessageId}:");
            Console.WriteLine($"{message.Body}");
            return true;
        }

        // Method to put a message on a queue
        // Could be expanded to include message attributes, etc., in a SendMessageRequest
        public async Task SendMessage(SendMessageRequest messageRequest)
        {
            SendMessageResponse responseSendMsg = await _sqsClient.SendMessageAsync(messageRequest);
            Console.WriteLine($"HttpStatusCode: {responseSendMsg.HttpStatusCode}");
        }
    }
}
