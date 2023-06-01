using System;

namespace Silverback.Samples.Kafka.Batch.Consumer
{
    public class UserEvent
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BookingStatus { get; set; }
    }
}
