using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// An interface for a repos that handles data transactions
    /// for friendships between two users, friendship statuses etc...
    /// </summary>
    public interface IFriendshipRelationsRepository
    {
        /// <summary>
        /// Gets the users current friends list
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <returns></returns>
        ICollection<Friendship> GetUserFriends(ApplicationUser user);

        /// <summary>
        /// Gets the users current pending friends list
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IEnumerable<Friendship> GetUserPendingFriends(ApplicationUser user);

        /// <summary>
        /// Get users friend by id
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="Id">The id of the friend we are looking for</param>
        /// <returns></returns>
        Friendship GetUserFriendById(ApplicationUser user, string Id);

        /// <summary>
        /// Get users friend by request date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="requestDate">The request date</param>
        /// <returns></returns>
        Friendship GetUserFriendByRequestDate(ApplicationUser user, DateTime requestDate);

        /// <summary>
        /// Get users friend by accept date
        /// </summary>
        /// <param name="user">The specified user</param>
        /// <param name="acceptDate">The accept date</param>
        /// <returns></returns>
        Friendship GetUserFriendByAcceptDate(ApplicationUser user, DateTime acceptDate);

        /// <summary>
        /// Get the status of the specified friendship
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        FriendshipStatus GetFriendshipStatus(Friendship friendship);

        /// <summary>
        /// Creates a friendship and adds an user to the current users friendship list
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="user"></param>
        void AddFriend(ApplicationUser currentUser, ApplicationUser user);

        /// <summary>
        /// Removes a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship relation</param>
        
        void RemoveFriendship(Friendship friendship);
       
        /// <summary>
        /// Updates a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship relation</param>
        void UpdateFriendship(Friendship friendship);        

        /// <summary>
        /// Adds a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        void AddFriendshipStatus(FriendshipStatus status);
        
        /// <summary>
        /// Removes a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        void RemoveFriendshipStatus(FriendshipStatus status);        

        /// <summary>
        /// Updates a friendship status to the database
        /// </summary>
        /// <param name="status">The specified status</param>
        void UpdateFriendshipStatus(FriendshipStatus status);       
    }
}
