using System.Threading.Tasks;

namespace Template.Common.Interfaces
{

    /// <summary>
    /// Interface for platform especific functionality
    /// </summary>
    public interface IPlatformService
    {
        /// <summary>
        /// Shows a native notification
        /// </summary>
        Task ShowNotificationAsync(string message);
    }
}
