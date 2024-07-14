using CommunityToolkit.Mvvm.ComponentModel;
using Template.Common.Interfaces;
using Template.Common.ViewModels;
using Template.Models;

namespace Template.ViewModels
{  
    /// <summary>
    /// Settings UI logic
    /// </summary>
    public partial class SynchronizationViewModel : BaseViewModel
    {
        private DateTime startTime;
        private ISynchronizationService synchronizationService;

        /// <summary>
        /// Current synchronization process
        /// </summary>
        [ObservableProperty]
        private double progress;


        /// <summary>
        /// Total sync time
        /// </summary>
        [ObservableProperty]
        private string synchronizationTime;


        /// <summary>
        /// Synchronization items
        /// </summary>
        public List<SynchronizationItem> SynchronizationItems { get; set; }


        /// <summary>
        /// True if completed
        /// </summary>
        [ObservableProperty]
        public bool synchronizationCompleted;


        /// <summary>
        /// True if completed
        /// </summary>
        [ObservableProperty]
        public bool finishingSynchronization;


        ///// <summary>
        ///// Command to login
        ///// </summary>
        //public IMvxCommand LogoutCommand
        //{
        //    get
        //    {
        //        return logoutCommand ?? (logoutCommand = new MvxCommand(async () =>
        //        {
        //            await NotificationService.ConfirmAsync("Confirmation", "LogoutQuestion", async confirmed =>
        //            {
        //                if (!confirmed) return;
        //                await this.AuthenticationService.LogOutAsync();
        //            });
        //        }));
        //    }
        //}


        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public SynchronizationViewModel(IServiceProvider provider) : base(provider)
        {
            this.synchronizationService = provider.GetService<ISynchronizationService>();
        }


        /// <summary>
        /// Initializes data
        /// </summary>
        public override Task Initialize()
        {
            return Task.Run(async () =>
            {
                try
                {
                    var items = this.synchronizationService.GetSynchronizationItems();
                    this.SynchronizationItems = new List<SynchronizationItem>(items);
                    //foreach (var item in this.SynchronizationItems)
                    //{
                    //    item.Text = GetText(item.Text);
                    //}
                    //await RaisePropertyChanged(() => this.SynchronizationItems);


                    // Do the sync
                    this.startTime = DateTime.Now;
                    await synchronizationService.StartSynchronization(UpdateProcess);
                }
                catch (Exception ex)
                {
                    await ShowErrorErrorMessageAsyc(ex);
                }
            });
        }




        /// <summary>
        /// Updates the progress ui
        /// </summary>
        public async void UpdateProcess(string item, int quantity, Exception ex)
        {
            //var synchronizationItem = this.SynchronizationItems.FirstOrDefault(x => x.Item == item);
            //if (synchronizationItem != null)
            {
                //if (ex == null)
                //{
                //    synchronizationItem.ItemsCount = quantity;
                //    synchronizationItem.Text = $"{quantity} {GetText(item)} {GetText("Synchronized")}";
                //    synchronizationItem.Completed = true;
                //    synchronizationItem.HasError = false;
                //}
                //else
                //{
                //    this.errors.Add(item, ex);
                //    synchronizationItem.ItemsCount = 0;
                //    synchronizationItem.Text = $"{GetText("ErrorSynchronizing")} {GetText(item)}";
                //    synchronizationItem.Completed = true;
                //    synchronizationItem.HasError = true;
                //}
            }

            //this.Progress = ((double)this.SynchronizationItems.Count(x => x.Completed)) / this.SynchronizationItems.Count();
       
            //if (this.Progress == 1)
            //{

            //    var synchronizationTime = DateTime.Now - this.startTime;
            //    this.SynchronizationTime = $"{GetText("SynchronizationTime")}  {synchronizationTime.Minutes} {GetText("Minutes")}, {synchronizationTime.Seconds} {GetText("Seconds")}";
            
            //    await Task.Delay(250);

            //    if (this.SynchronizationItems.Any(x => x.HasError))
            //    {
            //        var message = string.Empty;
            //        foreach (var error in this.errors)
            //        {
            //            var errorMessage = $"{GetText(error.Key)}: {error.Value.Message}";
            //            message += $"{errorMessage}\n";
            //            LogInformation(LogEvents.SynchronizationError, errorMessage);
            //        }

            //        await this.NotificationService.ConfirmWithMessageAsync("ErrorsDuringSynchronization", message, "Retry", "Cancel", async confirmed =>
            //        {
            //            if (confirmed)
            //            {
            //                var itemsToRetry = this.SynchronizationItems.Where(x => x.HasError).ToList();
            //                await RetrySynchronizationAsync(itemsToRetry);
            //            }
            //            else
            //            {
            //                this.SynchronizationCompleted = true;
            //                await RaisePropertyChanged(() => this.SynchronizationCompleted);
            //            }
            //        });
            //    }
            //    else
            //    {
            //        this.FinishingSynchronization = true;
            //        await this.synchronizationService.FinishSynchronizationAsync();                                
            //        this.SynchronizationCompleted = true;
            //        this.FinishingSynchronization = false;
            //    }
            //}
        }
    }
}
