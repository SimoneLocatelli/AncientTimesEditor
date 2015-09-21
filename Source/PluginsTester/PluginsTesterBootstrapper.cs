using Microsoft.Practices.Prism.MefExtensions;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Editor.PluginsTester
{
    /// <summary>
    ///     Bootstrapper for the PluginTester tool.
    /// </summary>
    public class PluginsTesterBootstrapper : MefBootstrapper
    {
        /// <summary>
        ///     Configures the <see cref="P:Microsoft.Practices.Prism.MefExtensions.MefBootstrapper.AggregateCatalog" /> used by
        ///     MEF.
        /// </summary>
        /// <remarks>
        ///     The base implementation does nothing.
        /// </remarks>
        protected override void ConfigureAggregateCatalog()
        {
            RegisterThisAssembly();

            LoadPluginsAndDependencies().ForEach(AddAssemblyToCatalog);

            base.ConfigureAggregateCatalog();
        }

        /// <summary>
        ///     Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        ///     The shell of the application.
        /// </returns>
        /// <remarks>
        ///     If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        ///     <see cref="T:Microsoft.Practices.Prism.Bootstrapper" /> will attach the default
        ///     <see cref="T:Microsoft.Practices.Prism.Regions.IRegionManager" /> of
        ///     the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty" />
        ///     attached property
        ///     in order to be able to add regions by using the
        ///     <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty" />
        ///     attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            //var value = Container.GetExportedValue<IProjectExplorerView>();

            return Container.GetExportedValue<PluginsTesterMainWindow>();
        }

        /// <summary>
        ///     Initializes the shell.
        /// </summary>
        /// <remarks>
        ///     The base implementation ensures the shell is composed in the container.
        /// </remarks>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        private static List<Assembly> LoadPluginsAndDependencies()
        {
            var assemblies = AssemblyLoader.LoadFromExecutingAssemblyFolder();

            return assemblies.Where(NameDoesntContainBootstrapper).ToList();
        }

        private static bool NameDoesntContainBootstrapper(Assembly assembly)
        {
            var fullname = assembly.FullName;

            return !(fullname.Contains("Bootstrapper") || fullname.Contains("WindowShell"));
        }

        private void AddAssemblyToCatalog(Assembly a)
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(a));
        }

        private void RegisterThisAssembly()
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(GetType().Assembly));
        }
    }
}