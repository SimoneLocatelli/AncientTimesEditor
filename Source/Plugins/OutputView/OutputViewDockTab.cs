using Editor.DockSystem.Dependencies;
using OutputView.Properties;
using System.ComponentModel.Composition;

namespace OutputView
{
    /// <summary>
    ///     Wraps the OutputView inside a Dock tab, to be displayed inside the Dock system
    /// </summary>
    [Export(ImportsConstants.DockSystemTools, typeof(IDockTab))]
    public class OutputViewDockTab : BaseDockTab
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OutputViewDockTab" /> class.
        /// </summary>
        [ImportingConstructor]
        public OutputViewDockTab(OutputViewControl outputViewControl)
        {
            Control = outputViewControl;
            Title = Resources.OutputViewControlHeader;
        }
    }
}