using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// A model that represents a web socket group
    /// </summary>
    public class WebSocketGroup
    {
        /// <summary>
        /// The id of this table
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The name of the group
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// A list of group clients that represents a many to many relation
        /// between the client and group tables
        /// </summary>
        public ICollection<WebSocketGroupClient> GroupClients { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WebSocketGroup()
        {
            GroupClients = new List<WebSocketGroupClient>();
        }
    }
}
