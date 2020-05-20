using Ninject.Infrastructure.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The repository that manages transactions with a users messages
    /// </summary>
    public class MockConversationalRepository : IConversationalRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Gets the users messages
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public ICollection<Message> GetUserMessages(ApplicationUser user)
        {
            // Get the specified user's conversations
            var specifiedUserConversations = GetUserConversations(user);

            // Return all specified user's messages aggregated into one list
            return specifiedUserConversations.Select(c => c.Messages.ToEnumerable()).Aggregate((a, b) => a.Concat(b)).ToList();
        }

        /// <summary>
        /// Gets the users message by id
        /// </summary>
        /// <param name="messageId">The message id</param>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public Message GetUserMessageById(ApplicationUser user, string messageId)
        {
            // Get all the users messages
            var specifiedUserMessages = GetUserMessages(user);

            // Return the message that satisfies the condition
            return specifiedUserMessages.SingleOrDefault(m => m.Id == messageId);
        }

        /// <summary>
        /// Gets the users message by sent date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="sentDate">The date at which the message was sent</param>
        /// <returns></returns>
        public Message GetUserMessageBySentDate(ApplicationUser user, DateTime sentDate)
        {
            // Get all the users messages
            var specifiedUserMessages = GetUserMessages(user);

            // Return the message that satisfies the condition
            return specifiedUserMessages.SingleOrDefault(m => m.SentDate == sentDate);
        }

        /// <summary>
        /// Gets the users conversations;        
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public ICollection<Conversation> GetUserConversations(ApplicationUser user)
        {
            //return _context.Users.Where(u => u.Id == user.Id).FirstOrDefault().Conversations;

            // Return the list of conversations that the specified user has
            return _context.Users.Find(user.Id).Conversations;
        }

        /// <summary>
        /// Gets the users conversation by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="conversationId">The conversation id</param>
        /// <returns></returns>
        public Conversation GetUserConversationById(ApplicationUser user, string conversationId)
        {
            // Get the user
            var specifiedUser = _context.Users.Find(user.Id);

            // Return user's conversation which satisfies the condition
            return specifiedUser.Conversations.SingleOrDefault(c => c.Id == conversationId);    
        }

        /// <summary>
        /// Gets the users conversation by name
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="name">The conversation name</param>
        /// <returns></returns>
        public Conversation GetUserConversationByName(ApplicationUser user, string name)
        {
            // Get the user
            var specifiedUser = _context.Users.Find(user.Id);

            // Return user's conversation which satisfies the condition
            return specifiedUser.Conversations.SingleOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// Gets the user's messages by the specified conversation name
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="conversationName">The conversation name</param>
        /// <returns></returns>
        public ICollection<Message> GetUserMessagesByConversationName(ApplicationUser user, string conversationName)
        {
            // Gets the user's conversations by name
            var specifiedUserConversation = GetUserConversationByName(user, conversationName);

            // Returns the messages that this conversation has
            return _context.Conversations.SingleOrDefault(c => c.Id == specifiedUserConversation.Id).Messages;
        }

        /// <summary>
        /// Gets the user's messages by the specified conversation id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="conversationId">The conversation id</param>
        /// <returns></returns>
        public ICollection<Message> GetUserMessagesByConversationId(ApplicationUser user, string conversationId)
        {
            // Gets the user's conversations by name
            var specifiedUserConversation = GetUserConversationById(user, conversationId);

            // Returns the messages that this conversation has
            return _context.Conversations.SingleOrDefault(c => c.Id == specifiedUserConversation.Id).Messages;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The application db context
        /// </summary>
        private ApplicationDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext">The injected dbContext</param>
        public MockConversationalRepository(ApplicationDbContext dbContext)
        {
            // Set members

            _context = dbContext;
        }

        #endregion
    }
}
