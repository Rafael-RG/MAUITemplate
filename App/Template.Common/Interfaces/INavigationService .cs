using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Common.Interfaces
{
    /// <summary>
    /// ViewModel based navigation
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to a ViewModel
        /// </summary>
        Task Navigate<TViewModel>(CancellationToken cancellationToken = default);

        /// <summary>
        /// Closes the viewmodel
        /// </summary>
        Task Close<TViewModel>(TViewModel viewModel);
    }
}
