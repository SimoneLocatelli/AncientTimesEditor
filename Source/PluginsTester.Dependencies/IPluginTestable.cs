using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.PluginsTester.Dependencies
{
    /// <summary>
    ///     Describes a plugin that is compatible
    ///     with the PluginTester tool, providing the necessary information
    /// </summary>
    [InheritedExport]
    public interface IPluginTestable
    {
        /// <summary>
        ///     Gets the content to display in the Details view.
        /// </summary>
        /// <value>
        ///     The content.
        /// </value>
        UIElement Content { get; }

        /// <summary>
        ///     Gets the name of the plugin (or of the feature to test).
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; }
    }
}