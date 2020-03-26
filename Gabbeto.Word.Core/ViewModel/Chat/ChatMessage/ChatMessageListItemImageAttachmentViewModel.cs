using System;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    ///<sumary>
    ///A view model for each chat message thread item's attachment (in this case an image) in a chat thread
    ///</sumary>
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The thumbnail URL of this attachement
        /// </summary>
        private string _thumbnailUrl;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title of the image file
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The original file name of this attachement
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The size of the file in bytes of this attachment
        /// </summary>
        public long FileSize { get; set; }

        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set
            {
                //If value hasn't changed, return
                if (value == _thumbnailUrl)
                    return;

                //Update the value
                _thumbnailUrl = value;

                //TODO: Download image from website
                //      Save file to local storage/cache
                //      Set LocalFilePath value
                //
                //      For now we set the file path directly                
                Task.Delay(2000).ContinueWith(t => LocalFilePath = "/Images/Samples/HappySample.jpg");                
            }
        }

        /// <summary>
        /// The local file path on this machine to the download thumbnail
        /// </summary>
        public string LocalFilePath { get; set; }

        /// <summary>
        /// A flag indicating whether the image is loaded or not
        /// </summary>
        public bool ImageLoaded => LocalFilePath != null;

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public ChatMessageListItemImageAttachmentViewModel()
        {

        }

        #endregion
    }
}
