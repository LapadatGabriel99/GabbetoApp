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
    }
}
