using Fasseto.Word.Core;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word
{
    /// <summary>
    /// The friends hub manager class
    /// </summary>
    public class SignalRClientFriendsManager : SignalRClientBaseHubManager, IFriendsManager
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="hubRoute"></param>
        public SignalRClientFriendsManager(string hubRoute) : base(hubRoute: hubRoute)
        {

        }

        #endregion

        #region Public Methods



        #endregion
    }
}
