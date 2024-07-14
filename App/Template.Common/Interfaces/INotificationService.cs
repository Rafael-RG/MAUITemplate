using System;
using System.Threading.Tasks;

namespace Template.Common.Interfaces
{
    /// <summary>
    /// Notification service.
    /// </summary>
    public interface INotificationService
    {

        /// <summary>
        /// Shows a pop up to the user (Xamarin.Forms DisplayAlert)
        /// </summary>
        /// <returns></returns>
        Task<bool> NotifyAsync(string title, string message, string buttonText = "");


        /// <summary>
        /// Shows a pop up to the user with confirmation of receipt (Xamarin.Forms DisplayAlert)
        /// </summary>
        Task<bool> NotifyAsync(string title, string message, string buttonText, Action<bool> callback);


        /// <summary>
        ///  Shows a pop up to the user with an error message (the message is not translated)
        /// </summary>
        Task<bool> NotifyErrorAsync(string title, string message);


        ///// <summary>
        ///// Shows a pop up to the user with confirmation (Xamarin.Forms DisplayAlert)
        ///// </summary>   
        //Task<bool> ConfirmAsync(string title, string message, Action<bool> callback);


        ///// <summary>
        /////  To display an action sheet to the user with deleted button (Xamarin.Forms DisplayAlert)
        ///// </summary>   

        //Task<bool> ActionSheetAsync(string title, bool deleteButton, Action<string> callback, params string[] buttons);


        /// <summary>
        ///  To display an action sheet to the user with cancelation (Xamarin.Forms DisplayAlert)
        /// </summary>   

        Task<bool> DisplayPrompAsync(string title, string subTitle, Action<string> callback);


    }    
}
