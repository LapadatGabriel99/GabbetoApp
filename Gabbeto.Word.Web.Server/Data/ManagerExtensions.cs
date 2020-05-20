using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server.Data
{
    /// <summary>
    /// Extensions methods for different kinds of data managers
    /// that will be included inside the service collection
    /// </summary>
    public static class ManagerExtensions
    {
        public static IServiceCollection AddChatManager<T>(this IServiceCollection services)
            where T : class, IChatManager, new()
        {
            // Add a scoped reference to the passed service
            services.AddScoped<IChatManager, T>();

            // Chain the call
            return services;
        }

        public static IServiceCollection AddFriendshipManager<T>(this IServiceCollection services)
            where T : class, IFriendshipManager, new()
        {
            // Add a scoped reference to the passed service
            services.AddScoped<IFriendshipManager, T>();

            // Chain the call
            return services;
        }
    }
}
