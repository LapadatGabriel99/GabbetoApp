using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    public class FriendshipStatus
    {
        /// <summary>
        /// The id, a primary key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// A flag indicating whether the friendship
        /// was accepted by the receiving user or not
        /// </summary>
        [Required]
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// The name of the status
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the status
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; }        

        /// <summary>
        /// The navigation property to the friendship table
        /// </summary>       
        public virtual Friendship Friendship { get; set; }
    }
}
