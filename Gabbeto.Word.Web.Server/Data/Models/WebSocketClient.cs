﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// This model holds data related to the web socket connection
    /// Such as the connectionId, the user's name, the user's groups
    /// </summary>
    public class WebSocketClient
    {
        /// <summary>
        /// The primary key of this table
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The user, in this case he is associated with a client
        /// </summary>
        [Required]
        public string User { get; set; }

        /// <summary>
        /// The client's connection id
        /// </summary>
        [Required]
        public string ConnectionId { get; set; }

        /// <summary>
        /// A list of group clients that represents a many to many relation
        /// between the client and group tables
        /// </summary>
        public ICollection<WebSocketGroupClient> GroupClients { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WebSocketClient()
        {
            GroupClients = new List<WebSocketGroupClient>();
        }
    }
}