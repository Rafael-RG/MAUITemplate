using Template.Common.Interfaces;
using Template.Common.ViewModels;


namespace Template.ViewModels
{
    /// <summary>
    /// Synchronization UI logic
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
      
        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public SettingsViewModel(IServiceProvider provider) : base(provider)
        {
        }
    }
}
