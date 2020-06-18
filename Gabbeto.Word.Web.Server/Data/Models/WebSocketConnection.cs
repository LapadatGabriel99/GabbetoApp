using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The data model that holds info related to the web socket connection
    /// </summary>
    public class WebSocketConnection
    {
        /// <summary>
        /// The primary key of this table
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The connection id
        /// </summary>
        [Required]
        public string ConnectionId { get; set; }

        /// <summary>
        /// A foreign key to the client table
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The navigation property to the web socket client table
        /// </summary>
        public WebSocketClient WebSocketClient { get; set; }

        /// <summary>
        /// A flag indicating if the connection is still on
        /// </summary>
        [Required]
        public bool Connected { get; set; }
    }
}
