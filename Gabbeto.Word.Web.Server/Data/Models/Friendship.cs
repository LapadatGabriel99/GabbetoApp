using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The data model that represents the friendship 
    /// relations between two users
    /// </summary>
    public class Friendship
    {
        #region Private Members

        private DateTime _acceptedDate;

        #endregion

        #region Public Properties

        /// <summary>
        /// The id, a primary key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The foreign key to the user table
        /// </summary>        
        public string UserId { get; set; }

        /// <summary>
        /// The navigation property to the User table
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// The user that requested this relationship
        /// </summary>
        [Required]
        public string RequestedBy { get; set; }

        /// <summary>
        /// The date at which the friendship request was made
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// The date at which the friendship status was confirmed
        /// </summary>
        public DateTime AcceptDate
        {
            get => _acceptedDate;

            set
            {
                // If it's the same...
                if (_acceptedDate == value)
                {
                    // Return
                    return;
                }

                // If the friend request isn't
                // confirmed yet
                if (!Status.IsConfirmed)
                {
                    // Return
                    return;
                }

                // Set the new date
                _acceptedDate = value;
            }
        }

        /// <summary>
        /// The user that will receive the request
        /// </summary>
        [Required]
        public string RequestedTo { get; set; }

        /// <summary>
        /// The status id, a foreign key
        /// </summary>        
        public string StatusId { get; set; }

        /// <summary>
        /// The friendship status navigation property
        /// </summary>       
        public virtual FriendshipStatus Status { get; set; } 

        #endregion
    }
}
