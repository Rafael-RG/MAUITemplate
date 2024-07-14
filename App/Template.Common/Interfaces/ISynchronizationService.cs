using Template.Models;

namespace Template.Common.Interfaces
{
    /// <summary>
    /// Synchronization service interface
    /// </summary>
    public interface ISynchronizationService
    {

        /// <summary>
        /// Starts the synchronization process
        /// Receives an action to report process (message, amount of elements, % progress)
        /// </summary>
        /// <returns></returns>
        Task<bool> StartSynchronization(Action<string, int, Exception> progress);



        /// <summary>
        /// Finish the process
        /// </summary>
        Task<bool> FinishSynchronizationAsync();


        /// <summary>
        /// Retry the synchronization process
        /// Receives an action to report process (message, amount of elements, % progress)
        /// Receive a list of items to synchronize
        /// </summary>
        /// <returns></returns>
        Task<bool> RetrySynchronization(Action<string, int, Exception> progress, List<SynchronizationItem> synchronizationItems);


        /// <summary>
        /// Returns the itemssynchronize
        /// </summary>
        List<SynchronizationItem> GetSynchronizationItems();
    }
}
