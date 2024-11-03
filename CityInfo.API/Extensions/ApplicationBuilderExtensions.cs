using CityInfo.API.Messaging;

namespace CityInfo.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static IMessaging messaging { get; set; }
 
        public static IApplicationBuilder UseRabbitMqConsumer(this IApplicationBuilder app)
        {
            messaging = app.ApplicationServices.GetService<IMessaging>();
            var hostApplicationLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            hostApplicationLifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            messaging.Start();
        }

        private static void OnStopping()
        {
            messaging.Stop();
        }
    }
}
