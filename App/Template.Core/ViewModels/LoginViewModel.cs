using Rincon.Common.Interfaces;
using Rincon.Common.ViewModels;

namespace Rincon.Core.ViewModels
{
    /// <summary>
    /// Simple username / password login logic
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        //private IMvxCommand loginCommand;
        //private IMvxCommand loginWithActiveDirectoryCommand;
        //private bool viewAppeared;


        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = string.Empty;


        /// <summary>
        /// Password 
        /// </summary>
        public string Password { get; set; } = string.Empty;



        ///// <summary>
        ///// Command to login
        ///// </summary>
        //public IMvxCommand LoginCommand
        //{
        //    get
        //    {
        //        return loginCommand ?? (loginCommand = new MvxCommand(async () =>
        //        {
        //            if (AreCredentialComplete())
        //            {
        //                await LoginAsync();
        //            }
        //            else
        //            {
        //                await NotificationService.NotifyAsync("Error", "MustIndicateCredentials", "Close");
        //            }
        //        }));
        //    }
        //}



        ///// <summary>
        ///// Command to login
        ///// </summary>
        //public IMvxCommand LoginWithActiveDirectoryCommand
        //{
        //    get
        //    {
        //        return loginWithActiveDirectoryCommand ?? (loginWithActiveDirectoryCommand = new MvxCommand(async () =>
        //        {
        //            await this.NavigationService.Navigate<MainViewModel>();
        //        }));
        //    }
        //}




        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }



        ///// <summary>
        ///// Initialize
        ///// </summary>
        ///// <returns></returns>
        //public override Task Initialize()
        //{
        //    //MvxNotifyTask.Create(LoadDataAsync);
        //    return base.Initialize();
        //}


        ///// <summary>
        ///// Valides if the users has logged before
        ///// </summary>
        //public override async void ViewAppeared()
        //{
        //    base.ViewAppeared();
        //    if (!this.viewAppeared)
        //    {
        //        try
        //        {
        //            this.viewAppeared = true;
        //            await this.AuthenticationService.LoadCredentialsAsync();
        //            if (this.AuthenticationService.IsAuthenticated())
        //            {
        //                // shows the last username and 
        //                // add a small delay to allow the UI to update itself before continuing
        //                this.IsBusy = true;
        //                this.Username = this.AuthenticationService.User.Name;
        //                this.Password = "*******";
        //                await RaisePropertyChanged(() => this.Username);
        //                await RaisePropertyChanged(() => this.Password);
        //                await Task.Delay(250);
        //                await this.NavigationService.Navigate<MainViewModel>();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.IsBusy = false;
        //            await NotificationService.NotifyAsync(GetText("Error"), (ex.Message), GetText("Close"));
        //            await LogExceptionAsync(ex);
        //        }
        //    }
        //}


        ///// <summary>
        ///// Do the login
        ///// </summary>
        ///// <returns></returns>
        //private async Task LoginAsync()
        //{
        //    if (this.IsBusy) return;         
        //    try
        //    {
        //        this.IsBusy = true;
        //        var result = await this.AuthenticationService.AuthenticateAsync(this.Username, this.Password);
        //        if (!result)
        //        {
        //            await NotificationService.NotifyAsync("LoginErrorTitle", "LoginError", "Close");
        //            return;
        //        }

        //        if (await this.DataService.MustSynchronizeAsync())
        //        {
        //            await this.NavigationService.Navigate<SynchronizationViewModel>();
        //        }
        //        else
        //        {
        //            await this.NavigationService.Navigate<MainViewModel>();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //await NotificationService.NotifyAsync(GetText("Error"), (ex.Message), GetText("Close"));
        //        await LogExceptionAsync(ex);
        //    }         
        //}



        /// <summary>
        /// Validates if the user submitted the credentials
        /// </summary>
        /// <returns></returns>
        private bool AreCredentialComplete()
        {
            return this.Username.Length > 0 || this.Password.Length > 0;
        }
    }
}
