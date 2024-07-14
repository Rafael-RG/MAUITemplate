using Microsoft.Extensions.Logging;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using Template.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Template.Common.Services;

namespace Template.Common.ViewModels
{
    /// <summary>
    /// Base class for all our ViewModels
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEnabled))]
        private bool isBusy;
        //private readonly IMvxTextProviderBuilder textProviderBuilder;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string version;


        /////// <summary>
        /////// Current messenger service
        /////// </summary>
        ////protected IMvxMessenger MessengerService { get; }

        ///// <summary>
        ///// The App Current Version
        ///// </summary>
        //public string Version { get; set; }

        ///// <summary>
        ///// Get's if the viewModel is busy doing something
        ///// </summary>
        //public bool IsBusy
        //{
        //    get => this.isBusy;
        //    set
        //    {
        //        this.isBusy = value;
        //        RaisePropertyChanged(() => IsBusy);
        //        RaisePropertyChanged(() => IsEnabled);
        //    }
        //}


        /// <summary>
        /// Gets if the ViewModel is enabled.
        /// It's the inverse of IsBusy for easier binding. (If IsBusy = true them IsEnabled = false)
        /// </summary>
        public bool IsEnabled { get => !this.isBusy; }
        //{
        //    get => !this.isBusy;
        //    set
        //    {
        //        this.isBusy = !value;
        //        RaisePropertyChanged(() => IsEnabled);
        //    }
        //}

        ///// <summary>
        ///// Indicates if the ViewModel is executing on
        ///// tablet device with landscape orientation
        ///// </summary>
        public bool IsTabletLandscape { get; set; }
        //{
        //    get => this.isTabletLandscape;
        //    set
        //    {
        //        this.isTabletLandscape = value;
        //        RaisePropertyChanged(() => IsTabletLandscape);
        //    }
        //}

        /// <summary>
        /// Authentication service
        /// </summary>
        protected IDataService DataService { get; }


        ///// <summary>
        ///// Platform service
        ///// </summary>
        //protected IPlatformService PlatformService { get; }


        /// <summary>
        /// Notification service
        /// </summary>
        protected INotificationService NotificationService { get; }


        /// <summary>
        /// Notification service
        /// </summary>
        protected INavigationService NavigationService { get; }


        /// <summary>
        /// Authentication service
        /// </summary>
        protected IAuthenticationService AuthenticationService { get; }


        /// <summary>
        /// Localization service
        /// </summary>
        protected ILocalizationService LocalizationService { get; }


        ///// <summary>
        ///// Source for localized texts
        ///// </summary>
        //public IMvxLanguageBinder TextSource =>
        //    new MvxLanguageBinder(TextProviderConstants.GeneralNamespace, TextProviderConstants.ClassName);



        /// <summary>
        /// Constructor
        /// </summary>
        public BaseViewModel(IServiceProvider provider)
        { 
            this.NavigationService = provider.GetService<INavigationService>();     
            this.AuthenticationService = provider.GetService<IAuthenticationService>();
            this.DataService = provider.GetService<IDataService>();
            this.NotificationService = provider.GetService<INotificationService>();
            this.LocalizationService = provider.GetRequiredService<ILocalizationService>();
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
            this.Version = VersionTracking.CurrentVersion;          
        }



        /// <summary>
        /// Helper method for getting a localized text
        /// </summary>
        /// <param name="text">Text to get</param>
        /// <returns>Localized text</returns>
        public string GetText(string text)
        {
            return this.LocalizationService.GetText(text);
        }


        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="logProvider"></param>
        ///// <param name="navigationService"></param>
        //protected BaseViewModel(ILoggerFactory logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        //{
        //    this.isBusy = false;
        //    this.DataService = Mvx.IoCProvider.GetSingleton<IDataService>();
        //    this.textProviderBuilder = Mvx.IoCProvider.GetSingleton<IMvxTextProviderBuilder>();
        //    this.MessengerService = Mvx.IoCProvider.GetSingleton<IMvxMessenger>();
        //    this.PlatformService = Mvx.IoCProvider.GetSingleton<IPlatformService>();
        //    DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
        //    this.Version = VersionTracking.CurrentVersion;
        //    this.NotificationService = Mvx.IoCProvider.GetSingleton<INotificationService>();
        //    this.AuthenticationService = Mvx.IoCProvider.GetSingleton<IAuthenticationService>();
        //}


        /// <summary>
        /// Handler to DeviceDisplay.MainDisplayInfoChanged event
        /// that is triggered whenever any screen metrics changes
        /// </summary>
        private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            var displayInfo = e.DisplayInfo;
            this.IsTabletLandscape = DeviceInfo.Idiom == DeviceIdiom.Tablet && displayInfo.Orientation == DisplayOrientation.Landscape;
            OnOrientationChangedAsync();
        }


        /// <summary>
        /// Called when the orientation changes
        /// </summary>
        /// <returns></returns>
        public virtual Task OnOrientationChangedAsync() { return Task.FromResult(true); }


        /// <summary>
        /// Returns if the devices is tablet and landscape
        /// </summary>
        protected void CheckIfTabletIsLandscape()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            this.IsTabletLandscape = DeviceInfo.Idiom == DeviceIdiom.Tablet && displayInfo.Orientation == DisplayOrientation.Landscape;
        }




        /// <summary>
        /// Show an error message and logs an exception message
        /// </summary>
        public async Task ShowErrorErrorMessageAsyc(Exception ex)
        {
            //await InvokeOnMainThreadAsync(async () =>
            //{
            //    await LogExceptionAsync(ex);
            //    await this.NotificationService.NotifyErrorAsync("Attention", ex.Message);
            //});
        }


        /// <summary>
        /// Logs an exception message
        /// </summary>
        public Task LogExceptionAsync(Exception ex)
        {
            return Task.FromResult(true);
        }


        /// <summary>
        /// Setups the ViewModel
        /// </summary>
        public virtual void Prepare()
        {
        }


        /// <summary>
        /// Background data initialization
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.FromResult(true);
        }


        /// <summary>
        /// Called when the view starts appearing
        /// </summary>
        public virtual void OnAppearing()
        {

        }


        /// <summary>
        /// Called when the view starts disappearing
        /// </summary>
        public virtual void OnDisappearing()
        {

        }
    }
}
