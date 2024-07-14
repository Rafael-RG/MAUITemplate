using Template.Common.Interfaces;
using Template.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Template.DataAccess
{
    /// <summary>
    /// Synchronization service interface
    /// </summary>
    public class SynchronizationService : ISynchronizationService
    {
        private IHttpService httpService;
        private IDataService dataService;


        /// <summary>
        /// Initialization
        /// </summary>
        public SynchronizationService(IHttpService httpService, IDataService dataService)
        {
            this.httpService = httpService;
            this.dataService = dataService;
        }


        /// <summary>
        /// Starts the synchronization process
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StartSynchronization(Action<string, int, Exception> progress)
        {
            try
            {
                var tasks = new List<Task>
                {
                   // SynchronizeItemsAsync(progress),                  
                };
                await Task.WhenAll(tasks);
                return true;
            }
            catch (Exception ex)
            {
                progress("ErrorSynchronization", 0, ex);
            }
            return false;
        }


        /// <inhertidoc/>
        public List<SynchronizationItem> GetSynchronizationItems()
        {
            return new List<SynchronizationItem>(new[] {
                new SynchronizationItem{ Item = "Items" },
            });
        }




        /// <summary>
        /// Retry the synchronization process
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RetrySynchronization(Action<string, int, Exception> progress, List<SynchronizationItem> synchronizationItems)
        {
            try
            {
                var tasks = new List<Task>();
                //Type thisType = this.GetType();
                //object[] parameters = { progress };

                //foreach (var item in synchronizationItems)
                //{
                //    MethodInfo method = thisType.GetMethod($"Synchronize{item.Item}Async", BindingFlags.NonPublic | BindingFlags.Instance);
                //    tasks.Add((Task)method.Invoke(this, parameters));
                //}
                await Task.WhenAll(tasks);
                return true;
            }
            catch (Exception ex)
            {
                progress("ErrorSynchronization", 0, ex);
            }
            return false;
        }


        /// <inheritdoc/>    
        public Task<bool> FinishSynchronizationAsync()
        {
            return Task.FromResult(true);
        }


        ///// <inhertidoc/>
        //private async Task<int> SynchronizeItemsAsync(Action<string, int, Exception> progress)
        //{
        //    try
        //    {
        //        var items = new List<Item>()
        //        {
        //            new Item {ItemId = "1", Description = "item 1", Title = "item 1"},
        //            new Item {ItemId = "2", Description = "item 2", Title = "item 2"},
        //            new Item {ItemId = "3", Description = "item 3", Title = "item 3"},
        //            new Item {ItemId = "4", Description = "item 4", Title = "item 4"},
        //            new Item {ItemId = "5", Description = "item 5", Title = "item 5"},
        //            new Item {ItemId = "6", Description = "item 6", Title = "item 6"},
        //            new Item {ItemId = "7", Description = "item 7", Title = "item 7"},
        //            new Item {ItemId = "8", Description = "item 8", Title = "item 8"},
        //            new Item {ItemId = "9", Description = "item 9", Title = "item 9"},
        //            new Item {ItemId = "10", Description = "item 10", Title = "item 10"},
        //            new Item {ItemId = "11", Description = "item 11", Title = "item 11"},
        //            new Item {ItemId = "12", Description = "item 12", Title = "item 12"},
        //        };


        //        // When obtaining data from an API, it can be deserialized like this:

        //                //var uri = Constants.GetItemssUri;
        //                //var items = await this.httpService.GetJsonArrayAsync(uri);
        //                //var items = items.Select(x => new Item
        //                //{
        //                //    ItemId = x.GetValue<int>("ItemId"),
        //                //    Description = x.GetValue<string>("Description"),
        //                //    Title = x.GetValue<int>("Title"),
        //                //}).ToArray();


        //        /// Simulate a delay
        //        await Task.Delay(1000);

        //        // Saves the new collection
        //        var count = await this.dataService.SaveItemsAsync<Item>(items, "Items");
        //        if (progress != null) progress("Items", count, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (progress != null) progress("Items", 0, ex);
        //    }
        //    return 0;
        //}    
    }
}
