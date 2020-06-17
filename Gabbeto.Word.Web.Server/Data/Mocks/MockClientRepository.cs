using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The repository that handles the web socket clients
    /// </summary>
    public class MockClientRepository : IClientRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Adds a client to the database
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(WebSocketClient client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a client from the database
        /// </summary>
        /// <returns></returns>
        public WebSocketClient GetClient()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a client from the database
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(WebSocketClient client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a client in the database
        /// </summary>
        /// <param name="client"></param>
        public void UpdateClient(WebSocketClient client)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}
