using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Silverback.Samples.Kafka.Batch.Consumer
{
    public class SampleMessageBatchSubscriber1
    {
       

        public SampleMessageBatchSubscriber1( )
        {
            
        }

      

        public async Task OnBatchReceivedAsync(IAsyncEnumerable<SampleMessage> batch)
        {
            int sum = 0;
            int count = 0;

            await foreach (var message in batch)
            {
               
                count++;
            }


            Console.WriteLine("Received batch of  " +  count.ToString());
            Console.ReadKey();

            Task.Delay(10000);
        }
    }
}
