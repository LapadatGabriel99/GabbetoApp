using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The user data and profile for this application
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        #region Public Properties

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents a list of conversations that this user has
        /// </summary>
        public ICollection<Conversation> Conversations { get; set; }

        /// <summary>
        /// The list of friends that the current user has
        /// </summary>
        public ICollection<Friendship> Friends { get; set; }

        /// <summary>
        /// The list of pending friend requests that the current user has
        /// </summary>
        public IEnumerable<Friendship> PendingFriends
        {
            get => Friends.Where(friend => friend.Status.IsConfirmed == false);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationUser()
        {
            // Set the properties

            Friends = new List<Friendship>();

            Conversations = new List<Conversation>();
        }

        #endregion
    }
}
