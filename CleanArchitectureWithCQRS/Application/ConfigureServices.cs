using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

                // sự kiện được publish song song nếu sự kiện đó gọi nhiều lần
                //options.NotificationPublisher = new TaskWhenAllPublisher();

                // sự kiện được publish tuần tự nếu sự kiện đó gọi nhiều lần
                //options.NotificationPublisher = new ForeachAwaitPublisher();
            });

            return services;
        }
    }
}
