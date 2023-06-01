using MassTransit;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace Silverback.Samples.Kafka.Batch.Consumer
{
    public class UserEventConsumer : IConsumer<Batch<UserEvent>>
    {


        public UserEventConsumer()
        { }

        public async Task Consume(ConsumeContext<Batch<UserEvent>> context)
        {
            var batch = context.Message;

            foreach (var message in batch)
            {
                // Process individual message
                string abcd = message.Message.CarName;
                Console.WriteLine($"Received message: {message}");
            }

            //var message = JsonConvert.SerializeObject(context.Message.First().Message);
            //Console.WriteLine(message);
            Console.WriteLine(context.Message.Length);
        }
    }
}
