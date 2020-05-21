using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Fasseto.Word.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjectUniversal;

namespace Fasseto.Word
{
    /// <summary>
    /// Extension methods for <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Adds the signalR client service to our services collection from Project Universal
        /// </summary>
        /// <param name="frameworkConstruction">The chained builder object</param>
        /// <returns></returns>
        public static FrameworkConstruction UseSignalRClient(this FrameworkConstruction frameworkConstruction)
        {
            // Add a transient signalR chat service to our service collection
            frameworkConstruction.Services.AddTransient<IChatManager, SignalRClientChatManager>();

            // Add a transient signalR friends service to our service collection
            frameworkConstruction.Services.AddTransient<IFriendsManager, SignalRClientFriendsManager>();

            // Add a transient signalR notification service to our service collection
            frameworkConstruction.Services.AddTransient<INotificationManager, SignalRClientNotificationManager>();

            // Chain the call
            return frameworkConstruction;
        }
    }
}
