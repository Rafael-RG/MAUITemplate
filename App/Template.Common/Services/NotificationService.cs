using Microsoft.Extensions.Localization;
using Template.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Template.Common.Services
{

    /// <inheritdoc />
    public class NotificationService : INotificationService
    {
        /// <summary>
        /// Initializes the service
        /// </summary>
        public NotificationService(IServiceProvider provider)
        {
      
        }


        /// <inheritdoc />
        public Task<bool> NotifyAsync(string title, string message, string buttonText = "")
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (Application.Current.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert(GetText(title), GetText(message), GetText(buttonText));
                }
            });
           return Task.FromResult(true);
        }


        ///// <inheritdoc />
        //public async Task<bool> NotifyMessageAsync(string title, string message, string buttonText = "")
        //{
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        if (Application.Current.MainPage != null)
        //        {
        //            await Application.Current.MainPage.DisplayAlert(GetText(title), message, GetText(buttonText));
        //        }
        //    });

        //    return true;
        //}


        /// <inheritdoc />
        public Task<bool> NotifyErrorAsync(string title, string message)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (Application.Current.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert(GetText(title), message, GetText("Ok"));
                }
            });
            return Task.FromResult(true);
        }



        ///// <inheritdoc />
        //public Task<bool> NotifyErrorAsync(string title, string message, Action<bool> callback)
        //{
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        if (Application.Current.MainPage != null)
        //        {
        //            await Application.Current.MainPage.DisplayAlert(GetText(title), message, GetText("Ok"));
        //            callback(true);
        //        }
        //    });
        //    return Task.FromResult(true);
        //}


        /// <inheritdoc />
        public Task<bool> NotifyAsync(string title, string message, string buttonText, Action<bool> callback)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (Application.Current.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert(GetText(title), GetText(message), GetText(buttonText));
                    callback(true);
                }
            });
            return Task.FromResult(true);
        }


        ///// <inheritdoc />
        //public Task<bool> ConfirmAsync(string title, string message, string buttonOk, string buttonCancel, Action<bool> callback)
        //{
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        if (Application.Current.MainPage != null)
        //        {
        //            var result = await Application.Current.MainPage.DisplayAlert(GetText(title), GetText(message), GetText(buttonOk), GetText(buttonCancel));
        //            callback(result);
        //        }
        //    });
        //    return Task.FromResult(true);
        //}

        ///// <inheritdoc />
        //public Task<bool> ConfirmWithMessageAsync(string title, string message, string buttonOk, string buttonCancel, Action<bool> callback)
        //{
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        if (Application.Current.MainPage != null)
        //        {
        //            var result = await Application.Current.MainPage.DisplayAlert(GetText(title), message, GetText(buttonOk), GetText(buttonCancel));
        //            callback(result);
        //        }
        //    });
        //    return Task.FromResult(true);
        //}


        ///// <inheritdoc />
        //public Task<bool> ActionSheetAsync(string title, bool deleteButton, Action<string> callback, params string[] buttons)
        //{
        //    if (Application.Current.MainPage != null)
        //    {
        //        string deleteVisible = null;
        //        if (deleteButton)
        //        {
        //            deleteVisible = GetText("Delete");
        //        }

        //        var result = await Application.Current.MainPage.DisplayActionSheet(title, GetText("Cancel"), deleteVisible, buttons);
        //        callback(result);
        //    }
        //    return Task.FromResult(true);
        //}


        /// <inheritdoc />
        public async Task<bool> DisplayPrompAsync(string title, string subTitle, Action<string> callback)
        {
            if (Application.Current.MainPage != null)
            {
                var result = await Application.Current.MainPage.DisplayPromptAsync(title, subTitle);
                callback(result);
            }
            return true;
        }



        /// <summary>
        /// Helper method for getting a localized text
        /// </summary>
        /// <param name="text">Text to get</param>
        /// <returns>Localized text</returns>
        public string GetText(string text)
        {
            //return this.textProviderBuilder.TextProvider.GetText(
            //    TextProviderConstants.GeneralNamespace, TextProviderConstants.ClassName, text);
            return text;
        }
    }
}
