using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using ProjectUniversal;

namespace Fasseto.Word.SignalR
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

            // Chain the call
            return frameworkConstruction;
        }
    }
}
