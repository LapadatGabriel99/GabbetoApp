using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// An interface for a repos that handles data transactions
    /// for user messages
    /// </summary>
    public interface IConversationalRepository
    {
        /// <summary>
        /// Gets the users messages
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        ICollection<Message> GetUserMessages(ApplicationUser user);

        /// <summary>
        /// Gets the users message by id
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        Message GetUserMessageById(ApplicationUser user,string messageId);

        /// <summary>
        /// Gets the user message by sent date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="sentDate">The date at which the message was sent</param>
        /// <returns></returns>
        Message GetUserMessageBySentDate(ApplicationUser user, DateTime sentDate);

        /// <summary>
        /// Gets the users conversations;        
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        ICollection<Conversation> GetUserConversations(ApplicationUser user);

        /// <summary>
        /// Gets the users conversation by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="coversationId">The conversation id</param>
        /// <returns></returns>
        Conversation GetUserConversationById(ApplicationUser user, string coversationId);

        /// <summary>
        /// Gets the users conversation by name
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Conversation GetUserConversationByName(ApplicationUser user, string name);                
    }
}
