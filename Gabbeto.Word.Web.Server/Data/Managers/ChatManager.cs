using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The class that manages the applications user-chat system
    /// </summary>
    public class ChatManager : IChatManager        
    {
        #region Interface Implementation

        /// <summary>
        /// Finds the conversation by it's name
        /// </summary>
        /// <typeparam name="TUser">The type of user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="name">The name of the conversation</param>
        /// <returns>Returns a conversation object after completion</returns>
        public async Task<Conversation> FindConversationByNameAsync<TUser>(TUser user, string name) where TUser : ApplicationUser
        {
            // Returns a result from a completed task
            return await Task.FromResult(_conversationalRepository.GetUserConversationByName(user, name));
        }

        /// <summary>
        /// Finds the conversation by it's id
        /// </summary>
        /// <typeparam name="TUser">The type of user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="id">The id of the conversation</param>
        /// <returns>Returns a conversation object after completion</returns>
        public async Task<Conversation> FindConversationByIdAsync<TUser>(TUser user, string id) where TUser : ApplicationUser
        {
            // Returns a result from a completed task
            return await Task.FromResult(_conversationalRepository.GetUserConversationById(user, id));
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The conversational repository needed to retrieve/update/remove/add data
        /// </summary>
        private IConversationalRepository _conversationalRepository;

        /// <summary>
        /// The service provided needed for other services
        /// </summary>
        private IServiceProvider _serviceProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatManager(IConversationalRepository conversationalRepository, IServiceProvider serviceProvider)
        {

            // Set private members
            _conversationalRepository = conversationalRepository;

            _serviceProvider = serviceProvider;
        }
        
        #endregion
    }
}
