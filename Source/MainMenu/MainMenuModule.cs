using Editor.WindowShell.Dependencies;
using MainMenu;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace MainMenu
{
    /// <summary>
    ///     Prism Module associated to the MainMenu plugin
    /// </summary>
    [ModuleExport(typeof(MainMenuModule))]
    public class MainMenuModule : IModule
    {
        private readonly IDefaultContentsTemplate contentsTemplate;
        private readonly MainMenuView mainMenuView;
        private readonly IRegionManager regionViewRegistry;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuModule" /> class.
        /// </summary>
        /// <param name="mainMenuView">The main menu view.</param>
        /// <param name="contentsTemplate">The contents template.</param>
        /// <param name="regionViewRegistry">The region view registry.</param>
        [ImportingConstructor]
        public MainMenuModule(MainMenuView mainMenuView, IDefaultContentsTemplate contentsTemplate,
            IRegionManager regionViewRegistry)
        {
            this.mainMenuView = mainMenuView;
            this.contentsTemplate = contentsTemplate;
            this.regionViewRegistry = regionViewRegistry;
        }

        /// <summary>
        ///     Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion(contentsTemplate.TopSection, () => mainMenuView);
        }
    }
}