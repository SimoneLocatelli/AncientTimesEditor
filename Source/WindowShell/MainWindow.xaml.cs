using Editor.Logging.Dependencies;
using Editor.WindowShell.Dependencies;
using Editor.WpfCommonLibrary.Dependencies;
using FluentChecker;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace Editor.WindowShell
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainWindow
    {
        public const string ContentsRegionNameConst = "Contents";
        private readonly IStartupWindow startupWindow;
        private bool hasBeenShown;

        public string ContentsRegionName
        {
            get { return ContentsRegionNameConst; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <param name="mainWindowViewModel">The main window view model.</param>
        /// <param name="bindingErrorListener">The binding error listener.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="startupWindow">The startup window.</param>
        [ImportingConstructor]
        public MainWindow(IBindingErrorListener bindingErrorListener,
            IEditorLogger logger,
            IStartupWindow startupWindow)
        {
            Check.IfIsNull(bindingErrorListener).Throw<ArgumentNullException>(() => bindingErrorListener);
            Check.IfIsNull(logger).Throw<ArgumentNullException>(() => logger);
            Check.IfIsNull(startupWindow).Throw<ArgumentNullException>(() => startupWindow);

            InitializeComponent();

            this.startupWindow = startupWindow;

            Closed += OnWindowClose;
        }

        [ExcludeFromCodeCoverage]
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (hasBeenShown)
                return;

            hasBeenShown = true;

            startupWindow.ShowDialog();
        }

        [ExcludeFromCodeCoverage]
        private static void OnWindowClose(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}