using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Represents a conversation between two users
    /// </summary>
    public class Conversation
    {
        #region Public Properties

        /// <summary>
        /// The id of this model
        /// </summary>
        [Key]
        public string Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// The foreign key to the user table
        /// </summary>       
        public string UserId { get; set; }

        /// <summary>
        /// The navigation property to the user table
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// The first user participating in this conversation
        /// </summary>
        [Required]
        public string User1 { get; set; }

        /// <summary>
        /// The second user participating in this conversation
        /// </summary>
        [Required]
        public string User2 { get; set; }

        /// <summary>
        /// The messages between the users
        /// </summary>
        public ICollection<Message> Messages { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Conversation()
        {
            // Set the properties

            Messages = new List<Message>();
        }

        #endregion
    }
}
