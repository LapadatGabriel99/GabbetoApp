using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The interface for the connection manager that handles web socket related data
    /// </summary>
    public interface IConnectionManager
    {
        /// <summary>
        /// Registers a connection of a client
        /// </summary>
        /// <param name="client">The specified client</param>
        /// <param name="connection">The specified connection</param>
        /// <returns></returns>
        Task AddConnetion(WebSocketClient client, WebSocketConnection connection);

        /// <summary>
        /// Removes a specific connection
        /// </summary>
        /// <param name="connection">The specified connection</param>
        /// <returns></returns>
        Task RemoveConnetion(WebSocketConnection connection);

        /// <summary>
        /// Gets the connections of a specified client
        /// </summary>
        /// <param name="client">The specified client</param>
        /// <returns></returns>
        Task<ICollection<WebSocketConnection>> GetConnections(WebSocketClient client);

        /// <summary>
        /// Gets the current on line users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<WebSocketClient>> OnlineUsers();
    }
}
