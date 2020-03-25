using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="specificViewModel"></param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        public override void OnViewModelChanged()
        {
            //Make sure UI exists first
            if (ChatMessageList == null)
                return;

            //Fade in chat message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(0.5f);
            storyboard.Begin(ChatMessageList);

            //Make the message box focused
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// Preview the input into the message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Get the text box
            var textbox = sender as TextBox;

            //Check if we have pressed enter key
            if (e.Key == Key.Enter)
            {
                //And if control key is pressed
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    //Add the new line at the point where the cursor is
                    var index = textbox.CaretIndex;

                    //Insert a new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //Shift the caret according to the index
                    textbox.CaretIndex += index + Environment.NewLine.Length;
                }
                else
                {
                    ViewModel.SendMessage();
                }

                //Handled
                e.Handled = true;
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //Create storyboard
            var storyboard = new Storyboard();

            //Add change color animation
            storyboard.AddChangeColorTo(0.3f, ColorType.WordDarkBlue.ToStringRGB());

            //Begin storyboard
            storyboard.Begin(sender as FrameworkElement);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //Create storyboard
            var storyboard = new Storyboard();

            //Add change color animation
            storyboard.AddChangeColorTo(0.3f, ColorType.ForegroundLight.ToStringRGB());

            //Begin storyboard
            storyboard.Begin(sender as FrameworkElement);
        }
    }
}
