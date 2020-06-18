using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The interface for the repository that handles web socket connections
    /// </summary>
    public interface IConnectionRepository
    {
        /// <summary>
        /// Adds a connection to the database
        /// </summary>
        /// <param name="client"></param>
        void AddConnection(WebSocketConnection connection);

        /// <summary>
        /// Updates a connection in the database
        /// </summary>
        /// <param name="client"></param>
        void UpdateConnection(WebSocketConnection connection);

        /// <summary>
        /// Removes a connection from the database
        /// </summary>
        /// <param name="client"></param>
        void RemoveConnection(WebSocketConnection connection);

        /// <summary>
        /// Gets a connection from the database
        /// </summary>
        /// <returns></returns>
        WebSocketClient GetConnection(string connection);
    }
}
