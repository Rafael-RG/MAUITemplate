using Template.Common.Interfaces;
using Template.Common.ViewModels;


namespace Template.ViewModels
{
    /// <summary>
    /// Sample viewmodel to show a collection of items
    /// </summary>
    public class ItemCollectionViewModel : BaseViewModel
    {
      
        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public ItemCollectionViewModel(IServiceProvider provider) : base(provider)
        {
        }
    }
}
