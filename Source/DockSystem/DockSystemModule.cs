using Editor.WindowShell.Dependencies;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace Editor.DockSystem
{
    [ModuleExport(typeof(DockSystemModule))]
    public class DockSystemModule : IModule
    {
        private readonly IDefaultContentsTemplate contentsTemplate;
        private readonly DockSystemView dockSystemView;
        private readonly IRegionManager regionViewRegistry;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuModule" /> class.
        /// </summary>
        /// <param name="dockSystemView">The dock system view.</param>
        /// <param name="contentsTemplate">The contents template.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        [ImportingConstructor]
        public DockSystemModule(DockSystemView dockSystemView, IDefaultContentsTemplate contentsTemplate,
            IRegionManager regionViewRegistry)
        {
            this.dockSystemView = dockSystemView;
            this.contentsTemplate = contentsTemplate;
            this.regionViewRegistry = regionViewRegistry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion(contentsTemplate.MainContents, () => dockSystemView);
        }
    }
}