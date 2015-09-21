using Editor.Badasquall.Dependencies;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.PokemonEditor.Dependencies;
using FluentChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

namespace Editor.PokemonEditor.Serializers
{
    /// <summary>
    ///     The pokemons list serializer
    /// </summary>
    public class PokemonSerializer : IPokemonSerializer
    {
        private readonly IProjectLoader projectLoader;
        private readonly IXmlSerializer writer;

        /// <summary>
        ///     PokemonSerializer constructor
        /// </summary>
        /// <param name="writer">       </param>
        /// <param name="projectLoader"></param>
        [ImportingConstructor]
        public PokemonSerializer(IXmlSerializer writer, IProjectLoader projectLoader)
        {
            this.writer = writer;
            this.projectLoader = projectLoader;
        }

        /// <summary>
        ///     The serialize method
        /// </summary>
        /// <param name="pokemons"></param>
        public void Serialize(IEnumerable<IPokemon> pokemons)
        {
            Check.IfIsNull(pokemons).Throw<ArgumentNullException>(() => pokemons);

            pokemons = pokemons.Select(pokemon => new PokemonSerializable(pokemon)).ToList();

            var project = projectLoader.CurrentProject;

            if (project != null)
                File.WriteAllText(project.Path + "\\Pokemons.pkmns", writer.Serialize(pokemons));
        }
    }
}