using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word
{
    /// <summary>
    /// The notification hub manager class
    /// </summary>
    public class SignalRClientNotificationManager : SignalRClientBaseHubManager, INotificationManager
    {
        #region Constructors

        /// <summary>
        /// Default Constuctor
        /// </summary>
        public SignalRClientNotificationManager(string hubRoute) : base(hubRoute: hubRoute)
        {

        }

        #endregion

        #region Public Methods



        #endregion
    }
}
