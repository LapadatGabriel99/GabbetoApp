using System;
using System.Linq;
using System.Threading.Tasks;
using Fasetto.Word.Core;
using Fasseto.Word.Core;
using System.IO;
using System.Reflection;
using System.Collections.Concurrent;

namespace Gabbeto.Word.Relational
{
    /// <summary>
    /// Stores and retrieves information about the client application
    /// such as login credentials, messages, settings etc...
    /// in an SqLite database
    /// </summary>
    public class ClientDataStore : IClientDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext _dbContext;

        #endregion

        #region Private Members        

        /// <summary>
        /// A list of object locks
        /// </summary>
        private ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        /// <returns>Returns a task result to determine whether the user has credentials or not</returns>
        public async Task<bool> HasCredentialsAsync()
        {
            return await GetLoginCredentialsAsync() != null;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public ClientDataStore(ClientDataStoreDbContext dbContext)
        {
            // Set the member
            _dbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Make sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish when setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Lock this action asynchronously so that
            // a limited number of threads may access it concurrently
            await AsyncAwaiter.AwaitAsync(Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location) + nameof(ClientDataStore) + nameof(EnsureDataStoreAsync), async () =>             
                // Make sure the database exists
                await _dbContext.Database.EnsureCreatedAsync()
            );                       
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public async Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Lock this action asynchronously so that
            // a limited number of threads may access it concurrently

            // Get the first row in the login credentials table, or null if none exits
            return await AsyncAwaiter.AwaitResultAsync<LoginCredentialsDataModel>(Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location) + nameof(ClientDataStore) + nameof(EnsureDataStoreAsync), async () => 
            {
                return await Task.FromResult(_dbContext.LoginCredentials.FirstOrDefault()); 
            });
        }

        /// <summary>
        /// Stores the given login credentials to the given backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Get a specific object lock
            var objectLock = _locks.GetOrAdd(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).
                GetUniqueKey(nameof(ClientDataStore), nameof(UpdateUserOptionalCredentialsAsync)), key => new object());

            // Lock these line of codes
            lock (objectLock)
            {
                // Clear all entries
                _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);

                // Add a new one
                _dbContext.LoginCredentials.Add(loginCredentials);

            }

            // Lock this action asynchronously so that
            // a limited number of threads may access it concurrently

            await AsyncAwaiter.AwaitResultAsync(Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location) + nameof(ClientDataStore) + nameof(EnsureDataStoreAsync), async () =>                
                    // Save changes to the database
                    await _dbContext.SaveChangesAsync()
                );
        }

        /// <summary>
        /// Updates the users optional credentials to the given backing data store
        /// </summary>
        /// <param name="optionalCredentials">The optional credentials to update</param>
        /// <returns>Returns a task that will finish once the changes are made</returns>
        public async Task UpdateUserOptionalCredentialsAsync(OptionalCredentialsDataModel optionalCredentials)
        {            
            // Get a specific object lock
            var objectLock = _locks.GetOrAdd(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).
                GetUniqueKey(nameof(ClientDataStore), nameof(UpdateUserOptionalCredentialsAsync)), key => new object());

            lock (objectLock)
            {
                // Get the current user
                var user = _dbContext.LoginCredentials.FirstOrDefault();

                // Update the first and last name
                user.FirstName = optionalCredentials.FirstName;
                user.LastName = optionalCredentials.LastName;

                _dbContext.LoginCredentials.Attach(user);
                _dbContext.Entry(user).Property(p => p.FirstName).IsModified = true;
                _dbContext.Entry(user).Property(p => p.LastName).IsModified = true;
            }

            // Save the changes to the local database
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all login credentials stored in the local database store
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllLoginCredentialsAsync()
        {
            // Clear all entries
            _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);

            // Save the changes to the local database
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
