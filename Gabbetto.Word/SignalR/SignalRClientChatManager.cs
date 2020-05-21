using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fasseto.Word
{
    /// <summary>
    /// The chat hub manager class
    /// </summary>
    public class SignalRClientChatManager : SignalRClientBaseHubManager, IChatManager
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignalRClientChatManager(string hubRoute) : base(hubRoute: hubRoute)
        {

        }

        #endregion

        #region Public Methods



        #endregion
    }
}
