using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The class that manages the applications user-friend system
    /// </summary>
    public class FriendshipManager : IFriendshipManager
    {
        #region Interface Implementation

        /// <summary>
        /// Finds a friendship by it's id
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="id">The id</param>
        /// <returns>It returns a friendship object after completion</returns>
        public async Task<Friendship> FindFriendshipById<TUser>(TUser user, string id) where TUser : ApplicationUser
        {
            // Returns a result from a completed task
            return await Task.FromResult(_friendshipRelationsRepository.GetUserFriendById(user, id));
        }

        /// <summary>
        /// Finds a friendship by it's request date
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="requestDate">The request date</param>
        /// <returns>It returns a friendship object after completion</returns>
        public async Task<Friendship> FindFriendshipByRequestDate<TUser>(TUser user, DateTime requestDate) where TUser : ApplicationUser
        {
            // Returns a result from a completed task
            return await Task.FromResult(_friendshipRelationsRepository.GetUserFriendByRequestDate(user, requestDate));
        }

        /// <summary>
        /// Finds a friendship by it's accept date
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <remarks>The type of user can only be of <see cref="ApplicationUser"/></remarks>
        /// <param name="user">The specified user</param>
        /// <param name="acceptDate">The accept date</param>
        /// <returns>It returns a friendship object after completion</returns>
        public async Task<Friendship> FindFriendshipByAcceptDate<TUser>(TUser user, DateTime acceptDate) where TUser : ApplicationUser
        {
            // Returns a result from a completed task
            return await Task.FromResult(_friendshipRelationsRepository.GetUserFriendByAcceptDate(user, acceptDate));
        }

        #endregion

        #region Private Members

        /// <summary>
        /// The friendship repository needed to retrieve/update/remove/add data 
        /// </summary>
        private IFriendshipRelationsRepository _friendshipRelationsRepository;

        /// <summary>
        /// The service provided needed for other services
        /// </summary>
        private IServiceProvider _serviceProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="friendshipRelationsRepository"></param>
        /// <param name="serviceProvider"></param>
        public FriendshipManager(IFriendshipRelationsRepository friendshipRelationsRepository, IServiceProvider serviceProvider)
        {
            // Set private members

            _friendshipRelationsRepository = friendshipRelationsRepository;

            _serviceProvider = serviceProvider;
        }

        #endregion
    }
}
