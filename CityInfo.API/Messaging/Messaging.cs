using CityInfo.API.Messages;
using CityInfo.API.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CityInfo.API.Messaging
{
    public class Messaging : IMessaging
    {
        public void Start()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "mypass",
                VirtualHost = "/",
                RequestedHeartbeat = TimeSpan.FromSeconds(30)
            };


            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);

            channel.QueueDeclare("ticketSold", durable: true, exclusive: false, autoDelete: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, EventArgs) =>
            {
                var body = EventArgs.Body.ToArray();
                var message = JsonConvert.DeserializeObject<TicketMessage>(Encoding.UTF8.GetString(body));

                //await _cityInfoRepository.UpdateTicketForPointOfInterest(message.CityId, message.PointOfInterestId);
                //await _cityInfoRepository.SaveChangesAsync();
                
            };
            channel.BasicConsume("ticketSold", true, consumer);
        }

        public void Stop()
        {
            
        }
    }
}
