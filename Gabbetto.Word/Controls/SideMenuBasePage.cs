using System.Windows.Controls;
using System.ComponentModel;
using Fasseto.Word.Core;

namespace Fasseto.Word
{
    /// <summary>
    /// The base page for all side menu controls to gain basic functionality
    /// </summary>
    public class SideMenuBasePage : UserControl
    {
        #region Private Members

        /// <summary>
        /// The view model associated with a page
        /// </summary>
        private object _viewModel;

        /// <summary>
        /// A boolean value that indicates if we should animate or not
        /// </summary>
        private static bool _shouldNotAnimate = true;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model associated with a page
        /// </summary>
        public object ViewModelObject
        {
            get => _viewModel;
            set
            {
                // If nothing changes...
                if (_viewModel == value)
                {
                    // Return
                    return;
                }

                // Set the new value
                _viewModel = value;

                // If we shouldn't animate...
                if(_shouldNotAnimate)
                {
                    // Set this member to false
                    _shouldNotAnimate = false;                    
                }
                else
                {
                    // Fire off the view model changed method
                    OnViewModelChanged();
                }

                // Set the data context for the page
                DataContext = _viewModel;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuBasePage()
        {
            //Don't animate in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// A method to call when the view model is changed
        /// </summary>
        public virtual void OnViewModelChanged()
        {

        }

        #endregion
    }

    public class SideMenuBasePage<TViewModel> : SideMenuBasePage
        where TViewModel : BaseViewModel, new()
    {
        #region Public Properties

        /// <summary>
        /// The view model associated to a page
        /// </summary>
        public TViewModel ViewModel
        {
            get => (TViewModel)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuBasePage() : base()
        {
            // Create a default view model
            ViewModel = IoC.Get<TViewModel>();

            // Set the data context
            DataContext = ViewModel;
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="specificViewModel"></param>
        public SideMenuBasePage(TViewModel specificViewModel = null) : base()
        {
            // If it's not equal to null
            if (specificViewModel != null)
            {
                // Set the view model
                ViewModel = specificViewModel;
            }
            else
            {
                // Create a default view model
                ViewModel = IoC.Get<TViewModel>();
            }
        }

        #endregion
    }
}
