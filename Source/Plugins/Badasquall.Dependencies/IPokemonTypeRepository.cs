using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     Repository class to manage the information about the
    ///     Pokemon type entities.
    /// </summary>
    [InheritedExport]
    public interface IPokemonTypeRepository
    {
        /// <summary>
        ///     Selects all the pokemon types available.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPokemonType> SelectAll();
    }
}