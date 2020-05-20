using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// An interface that exposes methods for a chat manager
    /// </summary>
    public interface IChatManager        
    {
        /// <summary>
        /// Finds the conversation by it's name
        /// </summary>
        /// <typeparam name="TUser">The type of user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="name">The name of the conversation</param>
        /// <returns>Returns a conversation object after completion</returns>
        Task<Conversation> FindConversationByNameAsync<TUser>(TUser user, string name) where TUser : ApplicationUser;

        /// <summary>
        /// Finds the conversation by it's id
        /// </summary>
        /// <typeparam name="TUser">The type of user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="id">The id of the conversation</param>
        /// <returns>Returns a conversation object after completion</returns>
        Task<Conversation> FindConversationByIdAsync<TUser>(TUser user, string id) where TUser : ApplicationUser;
    }
}
