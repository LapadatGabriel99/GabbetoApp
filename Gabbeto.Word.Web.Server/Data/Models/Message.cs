using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// Represents the message that a user has
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The id of the message data model
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The foreign key to the conversation table
        /// </summary>        
        public string ConversationId { get; set; }

        /// <summary>
        /// The navigation property to the Conversation table
        /// </summary>
        public virtual Conversation Conversation { get; set; }

        /// <summary>
        /// The user that send the message
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string From { get; set; }

        /// <summary>
        /// The user that should receive the message
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string To { get; set; }

        /// <summary>
        /// The message itself that was sent
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string Content { get; set; }

        /// <summary>
        /// Indicates if the message was sent by the user that made the request
        /// </summary>
        [Required]
        public bool SentByMe { get; set; }

        /// <summary>
        /// The date at which the message was sent
        /// </summary>
        [Required]        
        public DateTime SentDate { get; set; }

        /// <summary>
        /// The date at which the "to" user read the message
        /// </summary>
        public DateTime ReadTime { get; set; }
    }
}
