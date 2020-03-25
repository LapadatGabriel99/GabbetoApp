using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design time data for a <see cref="ChatMessageListItemViewModel"/>
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A singleton instance of this class
        /// </summary>
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            SenderName = "Gabi";
            Initials = "GM";
            Message = "Sa traiesti, Boss Baros!!!";
            ProfilePictureRGB = "3099c5";
            MessageSentTime = DateTimeOffset.UtcNow;
            SentByMe = true;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }

        #endregion
    }
}
