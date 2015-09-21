using System.ComponentModel.Composition;

namespace Editor.Logging.Dependencies
{
    /// <summary>
    ///     Object dumper used to analyze the current state of an object.
    /// </summary>
    [InheritedExport]
    public interface IObjectDumper
    {
        /// <summary>
        ///     Dumps the input object retrieving al the properties and
        ///     the current value.
        /// </summary>
        /// <param name="value">The object to dump.</param>
        /// <returns></returns>
        string Dump(object value);
    }
}