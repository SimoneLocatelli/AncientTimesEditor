using System;
using System.Windows;

namespace Editor.Bootstrapper
{
    /// <summary>
    ///     Enter point of the application.
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.OnUnhandledException;

            new AppBootstrapper().Run();
            base.OnStartup(e);
        }
    }
}