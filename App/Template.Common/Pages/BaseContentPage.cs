using Template.Common.ViewModels;

namespace Template.Common.Pages
{
    /// <summary>
    /// Base content page, used to tie the ViewModel
    /// with the page life cycle
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel
    {
        private bool viewmodelInitialized;


        /// <summary>
        /// ViewModel
        /// </summary>
        protected T ViewModel { get; }

        /// <summary>
        /// ViewModel
        /// </summary>
        protected bool ViewAppeared { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public BaseContentPage(T viewmodel, string pageTitle)
        {
            BindingContext = ViewModel = viewmodel;
            Title = pageTitle;
            SetupPageEvents();
        }     


        /// <summary>
        /// Binds the page event to the viewmodel
        /// </summary>
        private void SetupPageEvents()
        {
            this.Appearing += (sender, e)=> {
                if (!viewmodelInitialized)
                {
                    this.viewmodelInitialized = true;
                    this.ViewModel.Initialize();
                }
                if (!this.ViewAppeared)
                {
                    this.ViewAppeared = true;
                    this.ViewModel.OnAppearing();
                }
            };
            this.Disappearing += (sender, e) => { 
                this.ViewModel.OnDisappearing(); 
            };
        }
    }
}
