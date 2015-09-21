using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.CommonControls.Dependencies
{
    [InheritedExport]
    public interface IImageImporterView
    {
        UIElement Control { get; }
    }
}