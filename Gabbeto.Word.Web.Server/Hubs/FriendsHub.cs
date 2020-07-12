using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The friends hub of this application
    /// </summary>
    public class FriendsHub : Hub
    {
        #region Private members

        IConnectionManager _connectionManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="connectionManager">The connection manager</param>
        public FriendsHub(IConnectionManager connectionManager)
        {
            // Set the manager
            _connectionManager = connectionManager;
        }

        #endregion

        /// <summary>
        /// The method that is called when a client connects to the this hub
        /// </summary>
        /// <returns></returns>
        public async override Task OnConnectedAsync()
        {
            // Create a web socket client object
            var client = new WebSocketClient
            {
                User = Context.User.Identity.Name
            };

            // Create a web socket connection object
            var connection = new WebSocketConnection
            {
                ConnectionId = Context.ConnectionId,
                WebSocketClient = client
            };

            // Add the connection
            await _connectionManager.AddConnetion(client, connection);

            // Call the base method
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// The method that is called when a client disconnects from this hub
        /// </summary>
        /// <returns></returns>
        public async override Task OnDisconnectedAsync(Exception exception)
        {       
            // Remove the specified connection
            await _connectionManager.RemoveConnetion(Context.ConnectionId);

            // Call the base method
            await base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Sends a friend request notification to the specified user
        /// </summary>
        /// <param name="user">The specified user</param>        
        /// <returns></returns>
        public async Task SendFriendRequest(string receiverUsername, string senderFirstName, string senderLastName)
        {
            // Get the current users name
            var username = Context.User.Identity.Name;            

            // Get the client to whom we want to send a request
            var client = await _connectionManager.GetClient(receiverUsername);

            // Check if the client exists
            if (client == null)
            {
                // Return
                return;
            }

            // Get the clients existing connections
            var clientConnections = await _connectionManager.GetConnections(client);

            // If there aren't any
            if(clientConnections == null)
            {
                // Return
                return;
            }

            // Make the list read only
            var readOnlyList = clientConnections.Select(c => c.ConnectionId) as ReadOnlyCollection<string>;

            // Notify the subscribers
            await Clients.Clients(readOnlyList).SendAsync("ReceiveFriendRequest", username, senderFirstName, senderLastName);
        }

        /// <summary>
        /// Sends a friend request response notification to the specified user
        /// </summary>
        /// <param name="user">The specified user</param>        
        /// <param name="response">The friend request response</param>
        /// <returns></returns>
        public async Task SendFriendRequestResponse(string receiverUsername, string senderFirstName, string senderLastName,string response)
        {
            // Get the current users name
            var username = Context.User.Identity.Name;

            // Get the client to whom we want to send a request
            var client = await _connectionManager.GetClient(receiverUsername);

            // Check if the client exists
            if (client == null)
            {
                // Return
                return;
            }

            // Get the clients existing connections
            var clientConnections = await _connectionManager.GetConnections(client);

            // If there aren't any
            if (clientConnections == null)
            {
                // Return
                return;
            }

            // Make the list read only
            var readOnlyList = clientConnections.Select(c => c.ConnectionId) as ReadOnlyCollection<string>;

            // Notify the subscribers
            await Clients.Clients(readOnlyList).SendAsync("ReceiveFriendRequestResponse", username, senderFirstName, senderLastName, response);
        }
    }
}
