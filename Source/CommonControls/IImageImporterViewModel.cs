using System.ComponentModel.Composition;

namespace Editor.CommonControls
{
    [InheritedExport]
    public interface IImageImporterViewModel
    {
        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        string ImagePath { get; set; }
    }
}