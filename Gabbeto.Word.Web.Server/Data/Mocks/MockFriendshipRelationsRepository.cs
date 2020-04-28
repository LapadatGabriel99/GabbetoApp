using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The repository that manages transactions with a users friends
    /// </summary>
    public class MockFriendshipRelationsRepository : IFriendshipRelationsRepository
    {
        #region Interface Implementation

        /// <summary>
        /// Gets the users current friends list
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        public ICollection<Friendship> GetUserFriends(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users current pending friends list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<Friendship> GetUserPendingFriends(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get users friend by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="Id">The id of the friend we are looking for</param>
        /// <returns></returns>
        public Friendship GetUserFriendById(ApplicationUser user, string Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get users friend by request date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="requestDate">The request date</param>
        /// <returns></returns>
        public Friendship GetUserFriendByRequestDate(ApplicationUser user, DateTime requestDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get users friend by accept date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="acceptDate">The accept date</param>
        /// <returns></returns>
        public Friendship GetUserFriendByAcceptDate(ApplicationUser user, DateTime acceptDate)
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
        public MockFriendshipRelationsRepository(ApplicationDbContext dbContext)
        {
            // Set members

            _context = dbContext;
        } 

        #endregion
    }
}
