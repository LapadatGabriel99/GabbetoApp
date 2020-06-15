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
            // Returns the user's list of friends
            return _context.Users.SingleOrDefault(u => u.Id == user.Id).Friends;
        }

        /// <summary>
        /// Gets the users current pending friends list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<Friendship> GetUserPendingFriends(ApplicationUser user)
        {
            // Returns the user's list of pending friends
            return _context.Users.SingleOrDefault(u => u.Id == user.Id).PendingFriends;
        }

        /// <summary>
        /// Get users friend by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="Id">The id of the friend we are looking for</param>
        /// <returns></returns>
        public Friendship GetUserFriendById(ApplicationUser user, string id)
        {
            // Returns a user friend by id
            return GetUserFriends(user).SingleOrDefault(f => f.Id == id);
        }

        /// <summary>
        /// Get users friend by request date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="requestDate">The request date</param>
        /// <returns></returns>
        public Friendship GetUserFriendByRequestDate(ApplicationUser user, DateTime requestDate)
        {
            // Returns a user friend by request date
            return GetUserFriends(user).SingleOrDefault(f => f.RequestDate == requestDate);
        }

        /// <summary>
        /// Get users friend by accept date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="acceptDate">The accept date</param>
        /// <returns></returns>
        public Friendship GetUserFriendByAcceptDate(ApplicationUser user, DateTime acceptDate)
        {
            // Returns a user friend by sent date
            return GetUserFriends(user).SingleOrDefault(f => f.AcceptDate == acceptDate);
        }

        /// <summary>
        /// Get the status of the specified friendship
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        public FriendshipStatus GetFriendshipStatus(Friendship friendship)
        {
            // Returns a the status of the given friendship object
            return _context.Friendships.SingleOrDefault(f => f.Id == friendship.Id).Status;
        }

        /// <summary>
        /// Creates a friendship and adds an user to the current users friendship list
        /// </summary>
        /// <param name="currentUser">The user that made the friend request</param>
        /// <param name="user">The user that should receive the request</param>
        public void AddFriend(ApplicationUser currentUser, ApplicationUser user)
        {
            var newFriendshipStatus = new FriendshipStatus
            {
                IsConfirmed = false,

                // TODO: Serialize strings
                Name = $"{ currentUser.UserName }&{ user.UserName }",

                // TODO: Serialize strings
                Description = $"Friendship between { currentUser.UserName } and { user.UserName }"
            };

            _context.FriendshipStatuses.Add(newFriendshipStatus);

            _context.SaveChanges();

            var status = _context.FriendshipStatuses.FirstOrDefault(f => f.Name == newFriendshipStatus.Name);

            var newFriendship = new Friendship
            {
                UserId = currentUser.Id,
                User = currentUser,
                RequestedBy = currentUser.UserName,
                RequestedTo = user.UserName,
                RequestDate = DateTime.UtcNow,   
                Status = status,
                StatusId = status.Id
            };

            _context.Friendships.Add(newFriendship);

            _context.SaveChanges();

            status.Friendship = newFriendship;

            _context.FriendshipStatuses.Update(status);

            _context.SaveChanges();
        }

        /// <summary>
        /// Removes a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship relation</param>
        public void RemoveFriendship(Friendship friendship)
        {
            _context.Friendships.Remove(friendship);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship relation</param>
        public void UpdateFriendship(Friendship friendship)
        {
            _context.Friendships.Update(friendship);

            _context.SaveChanges();
        }

        /// <summary>
        /// Adds a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        public void AddFriendshipStatus(FriendshipStatus status)
        {
            _context.FriendshipStatuses.Add(status);

            _context.SaveChanges();
        }

        /// <summary>
        /// Removes a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        public void RemoveFriendshipStatus(FriendshipStatus status)
        {
            _context.FriendshipStatuses.Remove(status);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        public void UpdateFriendshipStatus(FriendshipStatus status)
        {
            _context.FriendshipStatuses.Update(status);

            _context.SaveChanges();
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
