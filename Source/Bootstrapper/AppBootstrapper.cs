using Editor.WindowShell.Dependencies;
using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace Editor.Bootstrapper
{
    /// <summary>
    ///     Bootstrapper for the Editor application
    /// </summary>
    public class AppBootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            var catalog = new DirectoryCatalog("./");

            AggregateCatalog.Catalogs.Add(catalog);

            base.ConfigureAggregateCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            return (DependencyObject)Container.GetExportedValue<IMainWindow>();
        }

        protected override void InitializeShell()
        {
            System.Windows.Application.Current.MainWindow = (Window)Shell;
            System.Windows.Application.Current.MainWindow.Show();
        }
    }
}