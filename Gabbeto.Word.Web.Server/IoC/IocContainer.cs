using Fasseto.Word.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// A shorthand access class to get DI services
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// A shortcut to get the <see cref="ServiceProvider"/> of this application
        /// </summary>
        public static ServiceProvider Provider => IocContainer.Provider;

        /// <summary>
        /// A shortcut to get a <see cref="Server.ApplicationDbContext"/> scoped reference
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IocContainer.Provider.GetService<ApplicationDbContext>();

        /// <summary>
        /// A shortcut to get a <see cref="IConfiguration"/> singleton reference
        /// </summary>
        public static IConfiguration Configuration => IocContainer.Provider.GetService<IConfiguration>();

        /// <summary>
        /// A shortcut to get a <see cref="SendGridEmailSender"/> transient reference
        /// </summary>
        public static IEmailSender EmailSender => IocContainer.Provider.GetService<IEmailSender>();

        #endregion

        #region Helper Methods

        public static T Get<T>()
        {
            return Provider.GetService<T>();
        }

        #endregion
    }

    /// <summary>
    /// The dependency injection container making use of the build in .Net Core service provider
    /// </summary>
    public static class IocContainer
    {
        private static bool _firstSet = false;

        private static ServiceProvider _provider;       

        /// <summary>
        /// The service provider of this application
        /// </summary>
        public static ServiceProvider Provider 
        { 
            get => _provider;
            set
            {
                if (_firstSet)
                    return;

                _provider = value as ServiceProvider;

                _firstSet = true;
            }
        }

        /// <summary>
        /// The configuration manager for this application
        /// </summary>
        public static IConfiguration Configuration { get; set; }
    }
}
