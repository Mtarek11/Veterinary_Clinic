using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var mediatRConfig = new MediatRServiceConfiguration();

            mediatRConfig.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

            services.AddMediatR(mediatRConfig);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
