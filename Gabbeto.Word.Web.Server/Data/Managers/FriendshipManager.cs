using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        /// <summary>
        /// Adds a friendship between the specified users
        /// </summary>
        /// <typeparam name="TUser">The type of specified user</typeparam>
        /// <param name="user">The current first user</param>
        /// <param name="otherUser">The second user</param>
        /// <returns></returns>
        public async Task AddFriendshipBetween<TUser>(TUser user, TUser otherUser) where TUser: ApplicationUser
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.AddFriend(user, otherUser));            
        }

        /// <summary>
        /// Removes a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        public async Task RemoveFriendship(Friendship friendship)
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.RemoveFriendship(friendship));
        }

        /// <summary>
        /// Updates a friendship relation
        /// </summary>
        /// <param name="friendship">The specified friendship</param>
        /// <returns></returns>
        public async Task UpdateFriendship(Friendship friendship)
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.UpdateFriendship(friendship));
        }

        /// <summary>
        /// Adds a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        public async Task AddFriendshipStatus(FriendshipStatus status)
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.AddFriendshipStatus(status));
        }

        /// <summary>
        /// Removes a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        public async Task RemoveFriendshipStatus(FriendshipStatus status)
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.RemoveFriendshipStatus(status));
        }

        /// <summary>
        /// Updates a friendship status
        /// </summary>
        /// <param name="status">The specified status</param>
        /// <returns></returns>
        public async Task UpdateFriendshipStatus(FriendshipStatus status)
        {
            // Wait for this task to do it's job
            await Task.Factory.StartNew(() => _friendshipRelationsRepository.UpdateFriendshipStatus(status));
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
