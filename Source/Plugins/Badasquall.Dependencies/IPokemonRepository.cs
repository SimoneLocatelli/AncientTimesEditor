using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Editor.Badasquall.Dependencies
{
    /// <summary>
    ///     Repository class to manage the information about the
    ///     Pokemon entities.
    /// </summary>
    [InheritedExport]
    public interface IPokemonRepository
    {
        /// <summary>
        ///     Selects all the pokemon entities currently stored.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPokemon> SelectAll();
    }
}