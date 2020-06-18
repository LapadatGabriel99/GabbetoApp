using Gabbetto.Word.Web.Server.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The connection manager that handles web socket related data
    /// </summary>
    public class ConnectionManager : IConnetionManager
    {
        #region Interface Implementation

        /// <summary>
        /// Registers a connection of a client
        /// </summary>
        /// <param name="client">The specified client</param>
        /// <param name="connection">The specified connection</param>
        /// <returns></returns>
        public async Task AddConnetion(WebSocketClient client, WebSocketConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a specific connection
        /// </summary>
        /// <param name="connection">The specified connection</param>
        /// <returns></returns>
        public async Task RemoveConnetion(WebSocketConnection connection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the connections of a specified client
        /// </summary>
        /// <param name="client">The specified client</param>
        /// <returns></returns>
        public async Task<ICollection<WebSocketConnection>> GetConnections(WebSocketClient client)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the current on line users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WebSocketClient>> OnlineUsers()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Client repository
        /// </summary>
        IClientRepository _client;

        /// <summary>
        /// Connection repository
        /// </summary>
        IConnectionRepository _connection;

        /// <summary>
        /// Group repository
        /// </summary>
        IGroupRepository _group;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="connection"></param>
        /// <param name="group"></param>
        public ConnectionManager(IClientRepository client, IConnectionRepository connection, IGroupRepository group)
        {
            // Set the private members
            
            _client = client;
            _connection = connection;
            _group = group;
        }

        #endregion
    }
}
