using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Confluent.Kafka;
using System;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace Silverback.Samples.Kafka.Batch.Consumer
{
    public class Startup
    {
        private System.IServiceProvider _serviceProvider;        
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMassTransitHostedService(true);
                services.AddMassTransit(x =>
                {
                    //x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                    x.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
                    x.AddRider(rider =>
                    {
                        //rider.AddConsumer<LogBatchConsumer>();
                        rider.AddConsumer<UserEventConsumer>(typeof(UserEventConsumerDefinition));

                        rider.UsingKafka((context, k) =>
                        {
                            k.Host("localhost:9092");


                            k.TopicEndpoint<UserEvent>("testdata5", "gid-consumers", e =>

                            {
                                e.AutoOffsetReset = AutoOffsetReset.Earliest;
                                e.ConfigureConsumer<UserEventConsumer>(context);
                            });

                        });
                    });


                });



                _serviceProvider = services.BuildServiceProvider();

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
            }
        }       
        public void Configure(IApplicationBuilder app)
        {
            var address = app.ServerFeatures.Get<IServerAddressesFeature>();
            address.Addresses.Clear();
            address.Addresses.Add("http://*:5556");       
        }
       
    }
}
