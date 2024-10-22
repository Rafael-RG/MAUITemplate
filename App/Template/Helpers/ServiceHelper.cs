﻿namespace Template.Helpers
{
    /// <summary>
    /// Service helper compiled by platform
    /// </summary>
    public static class ServiceHelper
    {
        public static TService GetService<TService>() => Current.GetService<TService>();

        public static IServiceProvider Current =>
#if WINDOWS
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
#else
            null;
#endif
    }
}
