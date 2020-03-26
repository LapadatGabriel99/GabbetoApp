using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design time data for a <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            DisplayTitle = "Boss Baros";

            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
               new ChatMessageListItemViewModel
               {
                   SenderName = "BossBaros",
                   Initials = "BB",
                   Message = "Aolo patroane!!!!",
                   ProfilePictureRGB = "3099c5",
                   MessageSentTime = DateTimeOffset.UtcNow,
                   SentByMe = false
               },

               new ChatMessageListItemViewModel
               {
                   SenderName = "Gabi",
                   Initials = "GM",
                   Message = "Sa traiesti, Boss Baros!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                   ProfilePictureRGB = "3099c5",
                   MessageSentTime = DateTimeOffset.UtcNow,
                   MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                   SentByMe = true
               },

               new ChatMessageListItemViewModel
               {
                   SenderName = "BossBaros",
                   Initials = "BB",
                   Message = "Sa moara familia mea si dusmanii mei!!!!!!!!\r\n Tanananana TARARARARa!",
                   ProfilePictureRGB = "3099c5",
                   MessageSentTime = DateTimeOffset.UtcNow,
                   SentByMe = false
               },
            };
        }

        #endregion
    }
}
