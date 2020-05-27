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
        /// <param name="sideMenuPage">The type of side menu page</param>
        /// <param name="viewModel">The type of view model</param>
        /// <returns></returns>
        public static SideMenuBasePage ToSideMenuBasePage(this SideMenuPage sideMenuPage, object viewModel = null)
        {
            switch (sideMenuPage)
            {
                case SideMenuPage.ChatList:
                    return new ChatListControl(viewModel as ChatListViewModel);

                case SideMenuPage.AddSearch:
                    return new AddSearchListControl(viewModel as SearchAddListViewModel);

                case SideMenuPage.FriendshipRequest:
                    return new FriendRequestListControl(viewModel as FriendRequestListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="SideMenuBasePage"/> into a <see cref="SideMenuPage"/>
        /// </summary>
        /// <param name="sideMenuBasePage">The type of side menu page</param>
        /// <returns></returns>
        public static SideMenuPage ToSideMenuPage(this SideMenuBasePage sideMenuBasePage)
        {
            if (sideMenuBasePage is ChatListControl)
            {
                return SideMenuPage.ChatList;
            }

            if (sideMenuBasePage is AddSearchListControl)
            {
                return SideMenuPage.AddSearch;
            }

            if (sideMenuBasePage is FriendRequestListControl)
            {
                return SideMenuPage.FriendshipRequest;
            }

            Debugger.Break();
            return default(SideMenuPage);
        }
    }
}
