using Template.Common.Interfaces;
using Template.Common.ViewModels;


namespace Template.ViewModels
{
    /// <summary>
    /// Sample entry form
    /// </summary>
    public class EntryFormViewModel : BaseViewModel
    {
      
        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public EntryFormViewModel(IServiceProvider provider) : base(provider)
        {
        }
    }
}
