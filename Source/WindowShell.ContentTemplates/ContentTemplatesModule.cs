using Editor.WindowShell.Dependencies;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace Editor.WindowShell.ContentTemplates
{
    /// <summary>
    ///     The module incorporates the Contents Template to load
    ///     inside the Window Body.
    /// </summary>
    [ModuleExport(typeof(ContentTemplatesModule))]
    public class ContentTemplatesModule : IModule
    {
        private readonly IMainWindow mainWindow;
        private readonly IRegionManager regionViewRegistry;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContentTemplatesModule" /> class.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        [ImportingConstructor]
        public ContentTemplatesModule(IMainWindow mainWindow, IRegionManager regionViewRegistry)
        {
            this.mainWindow = mainWindow;
            this.regionViewRegistry = regionViewRegistry;
        }

        /// <summary>
        ///     Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion(mainWindow.ContentsRegionName, () => new DefaultContentsTemplate());
        }
    }
}