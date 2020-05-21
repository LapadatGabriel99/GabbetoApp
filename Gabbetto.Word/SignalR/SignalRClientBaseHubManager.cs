using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word
{
    /// <summary>
    /// A base hub manager class that can be derived by other hub manager classes
    /// </summary>
    public class SignalRClientBaseHubManager
    {
        #region Private Members

        /// <summary>
        /// The hub connection
        /// </summary>
        private HubConnection _connection;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="hubRoute"></param>
        public SignalRClientBaseHubManager(string hubRoute)
        {
            // Create a connection to a specific hub
            _connection = new HubConnectionBuilder()
                .WithUrl(hubRoute)
                .Build();
        }

        #endregion
    }
}
