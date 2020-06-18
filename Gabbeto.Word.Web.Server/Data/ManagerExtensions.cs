using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Extensions methods for different kinds of data managers
    /// that will be included inside the service collection
    /// </summary>
    public static class ManagerExtensions
    {
        /// <summary>
        /// Injects a chat manager into the service collection
        /// </summary>
        /// <typeparam name="T">The type of chat manager</typeparam>
        /// <param name="services">The services collection</param>
        /// <returns></returns>
        public static IServiceCollection AddChatManager<T>(this IServiceCollection services)
            where T : class, IChatManager
        {
            // Add a scoped reference to the passed service
            services.AddScoped<IChatManager, T>();

            // Chain the call
            return services;
        }

        /// <summary>
        /// Injects a friendship manager into the service collection
        /// </summary>
        /// <typeparam name="T">The type of friendship manager</typeparam>
        /// <param name="services">The services collection</param>
        /// <returns></returns>
        public static IServiceCollection AddFriendshipManager<T>(this IServiceCollection services)
            where T : class, IFriendshipManager
        {
            // Add a scoped reference to the passed service
            services.AddScoped<IFriendshipManager, T>();

            // Chain the call
            return services;
        }

        /// <summary>
        /// Injects a connection manager into the service collection
        /// </summary>
        /// <typeparam name="T">The type of connection manager</typeparam>
        /// <param name="services">The services collection</param>
        /// <returns></returns>
        public static IServiceCollection AddConnectionManager<T>(this IServiceCollection services)
            where T : class, IConnectionManager
        {
            // Add a scoped reference to the passed service
            services.AddScoped<IConnectionManager, T>();

            // Chain the call
            return services;
        }
    }
}
