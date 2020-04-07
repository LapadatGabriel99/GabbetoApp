﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Fasseto.Word.Core;

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
            // Make sure the database exists
            await _dbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        public Task<LoginCredentialsDataModel> GetLoginCredentialsAsync()
        {
            // Get the first row in the login credentials table, or null if none exits
            return Task.FromResult(_dbContext.LoginCredentials.FirstOrDefault());
        }

        /// <summary>
        /// Stores the given login credentials to the given backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        public async Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials)
        {
            // Clear all entries
            _dbContext.LoginCredentials.RemoveRange(_dbContext.LoginCredentials);

            // Add a new one
            _dbContext.LoginCredentials.Add(loginCredentials);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}