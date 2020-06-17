using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The friends hub of this application
    /// </summary>
    public class FriendsHub : Hub
    {
        /// <summary>
        /// The method that is called when a client connects to the this hub
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {            
            // Call the base method
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// The method that is called when a client disconnects from this hub
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {

            // Call the base method
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Sends a friend request notification to the specified user
        /// </summary>
        /// <param name="user">The specified user</param>        
        /// <returns></returns>
        public Task SendFriendRequest(string user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a friend request response notification to the specified user
        /// </summary>
        /// <param name="user">The specified user</param>        
        /// <param name="response">The friend request response</param>
        /// <returns></returns>
        public Task SendFriendRequestResponse(string user, string response)
        {
            throw new NotImplementedException();
        }
    }
}
