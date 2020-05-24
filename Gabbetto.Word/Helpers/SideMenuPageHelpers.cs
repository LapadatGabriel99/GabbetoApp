using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Fasetto.Word.Core;
using Fasseto.Word.Core;

namespace Fasseto.Word
{
    /// <summary>
    /// Helper methods for <see cref="SideMenuPage"/>
    /// </summary>
    public static class SideMenuPageHelpers
    {
        /// <summary>
        /// Converts a <see cref="SideMenuPage"/> into a <see cref="SideMenuBasePage"/>
        /// according to the view model
        /// </summary>
        /// <param name="sideMenuPage"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static SideMenuBasePage ToSideMenuBasePage(this SideMenuPage sideMenuPage, object viewModel = null)
        {
            switch (sideMenuPage)
            {
                case SideMenuPage.ChatList:
                    return null;

                case SideMenuPage.AddSearch:
                    return null;

                case SideMenuPage.FriendshipRequest:
                    return null;

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="SideMenuBasePage"/> into a <see cref="SideMenuPage"/>
        /// </summary>
        /// <param name="sideMenuBasePage"></param>
        /// <returns></returns>
        public static SideMenuPage ToSideMenuPage(this SideMenuBasePage sideMenuBasePage)
        {
            Debugger.Break();
            return default(SideMenuPage);
        }
    }
}
