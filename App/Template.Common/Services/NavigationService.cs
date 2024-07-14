using Template.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Common.Services
{
    /// <inheritdoc/>
    public class NavigationService : INavigationService
    {

        /// <inheritdoc/>
        public Task Navigate<TViewModel>(CancellationToken cancellationToken = default)
        {
            try
            {
                var route = typeof(TViewModel).ToString();
                return Shell.Current.GoToAsync(route);
            }
            catch
            {
               // Log this
            }
            return null;
        }

        /// <inheritdoc/>
        public Task Close<TViewModel>(TViewModel viewModel)
        {
            try
            {
                return Shell.Current.GoToAsync("..");
            }
            catch
            {
                // Log this
            }
            return null;
        }
    }
}
