using Fasseto.Word.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Extension methods for any SendGrid
    /// </summary>
    public static class SendGridExtension
    {
        /// <summary>
        /// Adds an email sender as part of the DI services
        /// </summary>
        /// <typeparam name="T">The type of email sender</typeparam>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddEmailSender<T>(this IServiceCollection services)
            where T : class, IEmailSender, new()
        {
            // Ad the email sender to our services
            services.AddTransient<IEmailSender, T>();

            // Chain the builder
            return services;
        }
    }
}
