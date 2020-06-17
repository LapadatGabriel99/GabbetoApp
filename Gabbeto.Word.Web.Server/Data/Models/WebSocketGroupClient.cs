using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// A model that represents a composite table of the group and client ones
    /// </summary>
    public class WebSocketGroupClient
    {
        /// <summary>
        /// A foreign key to the web socket client table
        /// </summary>        
        public string WebSocketClientId { get; set; }

        /// <summary>
        /// Navigation property to the <see cref="WebSocketClient"/> table
        /// </summary>
        public WebSocketClient WebSocketClient { get; set; }

        /// <summary>
        /// A foreign key to the web socket group table
        /// </summary>
        public string WebSocketGroupId { get; set; }

        /// <summary>
        /// Navigation property to the <see cref="WebSocketGroup"/> table
        /// </summary>
        public WebSocketGroup WebSocketGroup { get; set; }
    }
}
