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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users message by id
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public Message GetUserMessageById(ApplicationUser user, string messageId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users message by sent date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="sentDate">The date at which the message was sent</param>
        /// <returns></returns>
        public Message GetUserMessageBySentDate(ApplicationUser user, DateTime sentDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users conversations;        
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public ICollection<Conversation> GetUserConversations(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users conversation by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="coversationId">The conversation id</param>
        /// <returns></returns>
        public Conversation GetUserConversationById(ApplicationUser user, string coversationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users conversation by name
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Conversation GetUserConversationByName(ApplicationUser user, string name)
        {
            throw new NotImplementedException();
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
