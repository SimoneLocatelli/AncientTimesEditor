using System.ComponentModel.Composition;

namespace Editor.Settings.Dependencies
{
    [InheritedExport]
    public interface ISettingsSerializer
    {
        IEditorSettings Read();

        void Save();
    }
}