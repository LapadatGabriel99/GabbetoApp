using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in the list
        /// </summary>
        protected string _lastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string _searchText;

        /// <summary>
        ///  The chat thread items for the list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> _items;

        /// <summary>
        /// A flag indicating that the search overlay is open
        /// </summary>
        protected bool _searchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// The chat thread items for the list
        /// NOTE: Do not call Items.Add to add messages to this list
        ///       as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => _items;
            set
            {
                //Check if list has changed
                if (_items == value)
                    return;

                //Update the value
                _items = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(_items);
                //Do not do this FilteredItems = Items, because this will create a reference between them and as a consequence 
                // Items will be changed when FilteredItems changes
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// A flag indicating the visibility of the popup menu
        /// True for it being visible, false otherwise
        /// </summary>
        public bool AttachementMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menus are visible
        /// </summary>
        public bool AnyPopupMenuVisible  => AttachementMenuVisible;

        /// <summary>
        /// The view model for the attchement menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachementMenu { get; set; }

        /// <summary>
        /// The text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// The text to search when we do a search
        /// </summary>
        public string SearchText
        {
            get => _searchText;
            set
            {
                //Check if property has changed
                if (_searchText == value)
                    return;

                //Update the value
                _searchText = value;

                //If the search test is empty
                if (string.IsNullOrEmpty(_searchText))
                    // Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// A flag indicating if the search bar is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => _searchIsOpen;
            set
            {
                //Check if value has changed
                if (_searchIsOpen == value)
                    return;

                //Update the value
                _searchIsOpen = value;

                //If dialog closes
                if (!_searchIsOpen)
                    SearchText = string.Empty;
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the are outside any popup is clicked
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when the user clicks the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user opens the search bar
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        ///  The command for when the user closes the search bar
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user clears the search bar
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            //Set commands
            AttachmentButtonCommand = new RelayCommand(() => AttachemntButton());
            PopupClickAwayCommand = new RelayCommand(() => PopupClickAway());
            SendCommand = new RelayCommand(() => SendMessage());
            SearchCommand = new RelayCommand(() => Search());
            OpenSearchCommand = new RelayCommand(() => OpenSearch());
            CloseSearchCommand = new RelayCommand(() => CloseSearch());
            ClearSearchCommand = new RelayCommand(() => ClearSearch());

            //Make a default menu
            AttachementMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup menu
        /// </summary>
        public void AttachemntButton()
        {
            //Toggle menu visible value
            if (AttachementMenuVisible == true)

                AttachementMenuVisible = false;
            else

                AttachementMenuVisible = true;
        }

        /// <summary>
        /// When the attachment popup clickAway area is clicked hide any popups
        /// </summary>
        public void PopupClickAway()
        {
            //Hide attachment menu
            AttachementMenuVisible = false;
        }

        /// <summary>
        /// When the user clicks the button, send the message
        /// </summary>
        public void SendMessage()
        {
            if (string.IsNullOrEmpty(PendingMessageText) || string.IsNullOrWhiteSpace(PendingMessageText))
                return;

            //Check to see if Items is null
            if (Items == null)
                return;

            //Check to see if FilteredItems is null
            if (FilteredItems == null)
                return;

            //Fake send a message
            var message = new ChatMessageListItemViewModel
            {
                Initials = "GM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Gabi Lapadat",
                NewItem = true,
            };

            //Add message to both lists
            Items.Add(message);
            FilteredItems.Add(message);

            //After we add the message to the chat message item
            //we have to clear the PendingMessageText so it updates to the UI and clears it aswell
            PendingMessageText = string.Empty;
        }

        /// <summary>
        /// Searches the chat for the desired text
        /// </summary>
        public void Search()
        {
            //Make sure we don't research the same text twice
            if((string.IsNullOrEmpty(_lastSearchText) && string.IsNullOrEmpty(_searchText)) || string.Equals(_lastSearchText, _searchText))
            {
                return;
            }

            //If we have no search text, or no items
            if(string.IsNullOrEmpty(_searchText) || Items == null || Items.Count <= 0)
            {
                //Make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                //Set last search
                _lastSearchText = SearchText;

                return;
            }

            //Find all items that contain the given text
            //TODO: Make more efficent search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(chatMessageItem => chatMessageItem.Message.ToLower().Contains(SearchText)));

            //Set last search
            _lastSearchText = SearchText;
        }

        /// <summary>
        /// Opens the chat search bar
        /// </summary>
        public void OpenSearch()
        {
            SearchIsOpen = true;
        }

        /// <summary>
        /// Closes the chat search bar
        /// </summary>
        public void CloseSearch()
        {
            SearchIsOpen = false;            
        }

        /// <summary>
        /// Clears the chat search bar
        /// NOTE: If escape is pressed twice in a row it will not only clear the search bar, 
        ///       but also it will close the seach bar
        /// </summary>
        public void ClearSearch()
        {
            //If there is any text in the search bar
            if(!string.IsNullOrEmpty(SearchText))
                //Clear the search bar
                SearchText = string.Empty;
            //Else..
            else            
                //Close the search bar
                CloseSearch();            
        }
        #endregion
    }

    ///NOTE!!! Might want to make a sepparate view model for chat page!!
}
