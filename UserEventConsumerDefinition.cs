using MassTransit;

namespace Silverback.Samples.Kafka.Batch.Consumer
{
    public class UserEventConsumerDefinition : ConsumerDefinition<UserEventConsumer>
    {
        public UserEventConsumerDefinition()
            => Endpoint(x => x.PrefetchCount = 500);

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<UserEventConsumer> consumerConfigurator)
        {
            consumerConfigurator.Options<BatchOptions>(options => options
                .SetMessageLimit(10)
                .SetConcurrencyLimit(2));
        }
    }
}
