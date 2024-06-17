using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Owl.Domain;
using Owl.Infrastructure;

namespace Owl.CoreApplication.Integration;

public static class OwlCoreAppIntegration
{
    public static IHostBuilder AddOwlCoreApp(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.AddScoped<IWordFactory, DefaultWordFactory>();
            services.AddScoped<IWordListFactory, DefaultWordListFactory>();

            services.AddScoped<IWordRepository, MemoryWordRepository>();
            services.AddScoped<IWordListRepository, MemoryWordListRepository>();

            services.AddScoped<OwlCoreAppApi>();
        });

        return builder;
    }
}
