using System.ComponentModel.Composition;
using System.Windows;

namespace Editor.CommonControls.Dependencies
{
    [InheritedExport]
    public interface IImageFinderView
    {
        UIElement Control { get; }

        string ImagePath { get; }
    }
}