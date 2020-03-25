using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design time data for a chat list item view model
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance { get { return new ChatListItemDesignModel(); } }

        #endregion

        #region Construtor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "GM";
            Name = "Gabi";
            Message = "Heeeey maaaan!!!";
            ProfilePictureRGB = "3099c5";
        }

        #endregion
    }
}
