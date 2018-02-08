using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANC.Sales.Commom.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // TODO: add reference to core
        public static IServiceCollection AddSingletonConfiguration<TConfig, TImplementation>(this IServiceCollection services, IConfigurationSection section)
            where TConfig : class
            where TImplementation : class
        {
            // Ensure TImplementation is valid to create a instance of TConfig
            var typeOfConfig = typeof(TConfig);
            var typeOfImplmentation = typeof(TImplementation);
            var isValid = !typeOfImplmentation.IsAbstract && !typeOfImplmentation.IsInterface && typeOfConfig.IsAssignableFrom(typeOfImplmentation);
            if (!isValid)
            {
                throw new ApplicationException($"Implementation ({typeOfImplmentation.FullName}) must implement Interface ({typeOfConfig.FullName})");
            }
            try
            {
                var implementationInstance = (TConfig)Activator.CreateInstance(typeOfImplmentation, section);
                
                services.AddSingleton(implementationInstance);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Cannot add singleton configuration for implementation ({typeOfImplmentation.FullName}). Details: {ex.ToString()}");
            }
            return services;
        }
    }
}