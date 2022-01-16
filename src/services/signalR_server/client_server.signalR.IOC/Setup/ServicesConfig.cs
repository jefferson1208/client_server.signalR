using client_server.signalR.Application.Interfaces;
using client_server.signalR.Application.Services;
using client_server.signalR.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace client_server.signalR.IOC.Setup
{
    public static class ServicesConfig
    {
        public static void DependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IAppNotificationService, AppNotificationService>();
            services.AddScoped<INotify, Notify>();
        }
    }
}
