using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Stores and retrieves information about the client application
    /// such as login credentials, messages, settings etc...
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// Determines if the current user has logged in credentials
        /// </summary>
        Task<bool> HasCredentialsAsync();

        /// <summary>
        /// Make sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish when setup is complete</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets the stored login credentials for this client
        /// </summary>
        /// <returns>Returns the login credentials if they exist, or null if none exist</returns>
        Task<LoginCredentialsDataModel> GetLoginCredentialsAsync();

        /// <summary>
        /// Stores the given login credentials to the given backing data store
        /// </summary>
        /// <param name="loginCredentials">The login credentials to save</param>
        /// <returns>Returns a task that will finish once the save is complete</returns>
        Task SaveLoginCredentialsAsync(LoginCredentialsDataModel loginCredentials);

        /// <summary>
        /// Updates the users optional credentials to the given backing data store
        /// </summary>
        /// <param name="optionalCredentials">The optional credentials to update</param>
        /// <returns>Returns a task that will finish once the changes are made</returns>
        Task UpdateUserOptionalCredentialsAsync(OptionalCredentialsDataModel optionalCredentials);
    }
}
