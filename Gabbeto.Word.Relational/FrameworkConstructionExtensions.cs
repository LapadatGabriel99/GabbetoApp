using System;
using Fasseto.Word.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectUniversal;

namespace Gabbeto.Word.Relational
{
    ///<sumary>
    /// Extension Methods for <see cref="FrameworkConstruction"/>
    ///</sumary>
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction UseDataClientStore(this FrameworkConstruction frameworkConstruction)
        {
            // Inject SQLite EF data store into our services
            frameworkConstruction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                // Setup connection string
                options.UseSqlite(frameworkConstruction.Configuration.GetConnectionString("ClientDataStoreConnection"));
            }, ServiceLifetime.Transient);

            // Add client data store for easy access use of the backing data store
            // Make it scoped so we can inject the inject the scoped db context

            frameworkConstruction.Services.AddTransient<IClientDataStore>(
                options => new ClientDataStore(options.GetService<ClientDataStoreDbContext>()));

            // Chain the construction
            return frameworkConstruction;
        }
    }
}
