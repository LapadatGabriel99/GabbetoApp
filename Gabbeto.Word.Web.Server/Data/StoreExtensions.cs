using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Extension methods for various stores that will be included 
    /// as services inside the service collection
    /// </summary>
    public static class StoreExtensions
    {
        /// <summary>
        /// Adds a data store to the service collection
        /// </summary>
        /// <typeparam name="T">The type of data store</typeparam>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddConversationalStore<T>(this IServiceCollection services)
            where T : class, IConversationalRepository, new()
        {
            // Add a scoped reference of the passed store service
            services.AddScoped<IConversationalRepository, T>();

            // Chain the return
            return services;
        }

        /// <summary>
        /// Adds a data store to the service collection
        /// </summary>
        /// <typeparam name="T">The type of data store</typeparam>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddFriendshipRelationsStore<T>(this IServiceCollection services)
            where T : class, IFriendshipRelationsRepository, new()
        {
            // Add a scoped reference of the passed store service
            services.AddScoped<IFriendshipRelationsRepository, T>();

            // Chain the return
            return services;
        }

        /// <summary>
        /// Adds a collection of data stores to the service collection
        /// </summary>
        /// <remarks>This adds a specific implementation of each store</remarks>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGabbetoStores(this IServiceCollection services)
        {
            // Add the conversational data store
            services.AddScoped<IConversationalRepository, MockConversationalRepository>();

            // Add the friendship relations data store
            services.AddScoped<IFriendshipRelationsRepository, MockFriendshipRelationsRepository>();

            // Chain the return
            return services;
        }
    }
}
