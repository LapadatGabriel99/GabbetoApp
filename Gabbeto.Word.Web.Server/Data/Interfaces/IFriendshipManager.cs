using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// An interface that exposes methods for an friendship manager
    /// </summary>
    public interface IFriendshipManager
    {
        /// <summary>
        /// Finds a friendship by it's id
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="id">The id</param>
        /// <returns>It returns a friendship object after completion</returns>
        Task<Friendship> FindFriendshipById<TUser>(TUser user, string id) where TUser : ApplicationUser;

        /// <summary>
        /// Finds a friendship by it's request date
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="requestDate">The request date</param>
        /// <returns>It returns a friendship object after completion</returns>
        Task<Friendship> FindFriendshipByRequestDate<TUser>(TUser user, DateTime requestDate) where TUser : ApplicationUser;

        /// <summary>
        /// Finds a friendship by it's accept date
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="acceptDate">The accept date</param>
        /// <returns>It returns a friendship object after completion</returns>
        Task<Friendship> FindFriendshipByAcceptDate<TUser>(TUser user, DateTime acceptDate) where TUser : ApplicationUser;

        /// <summary>
        /// Adds a friendship between the specified users
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <param name="user">The current first user</param>
        /// <param name="otherUser">The second user</param>
        /// <returns></returns>
        Task AddFriendshipBetween<TUser>(TUser user, TUser otherUser) where TUser : ApplicationUser;        

        /// <summary>
        /// Removes a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        Task RemoveFriendship(Friendship friendship);        

        /// <summary>
        /// Updates a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        Task UpdateFriendship(Friendship friendship);        

        /// <summary>
        /// Adds a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        Task AddFriendshipStatus(FriendshipStatus status);        

        /// <summary>
        /// Removes a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        Task RemoveFriendshipStatus(FriendshipStatus status);
       
        /// <summary>
        /// Updates a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        Task UpdateFriendshipStatus(FriendshipStatus status);        
    }
}
