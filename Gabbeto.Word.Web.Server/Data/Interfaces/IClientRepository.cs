using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The interface for the repository that handles web socket clients
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Adds a client to the database
        /// </summary>
        /// <param name="client"></param>
        void AddClient(WebSocketClient client);

        /// <summary>
        /// Updates a client in the database
        /// </summary>
        /// <param name="client"></param>
        void UpdateClient(WebSocketClient client);

        /// <summary>
        /// Removes a client from the database
        /// </summary>
        /// <param name="client"></param>
        void RemoveClient(WebSocketClient client);

        /// <summary>
        /// Gets a client from the database
        /// </summary>
        /// <returns></returns>
        WebSocketClient GetClient();
    }
}
