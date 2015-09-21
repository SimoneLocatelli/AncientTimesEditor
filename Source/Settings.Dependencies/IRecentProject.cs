namespace Editor.Settings.Dependencies
{
    public interface IRecentProject
    {
        string FullPath { get; }

        string Name { get; }
    }
}