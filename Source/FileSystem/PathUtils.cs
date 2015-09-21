using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.Utils;
using FluentChecker;
using System;
using System.ComponentModel.Composition;

namespace Editor.FileSystem
{
    /// <summary>
    ///     Collections of utils method related to the File paths.
    /// </summary>
    public class PathUtils : IPathUtils
    {
        private IPathFacade pathFacade;

        public IPathFacade PathFacade
        {
            get { return pathFacade; }
            set
            {
                Check.IfIsNull(value).Throw<ArgumentNullException>(() => PathFacade);
                pathFacade = value;
            }
        }

        [ImportingConstructor]
        public PathUtils(IPathFacade pathFacade)
        {
            PathFacade = pathFacade;
        }

        /// <summary>
        ///     Gets the extension removing the dot if it's the first character.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public string GetExtensionWithoutStartingDot(string filePath)
        {
            Check.IfIsNullOrWhiteSpace(filePath).Throw<ArgumentException>(() => filePath);

            var extension = PathFacade.GetExtension(filePath) ?? string.Empty;

            return extension.StartsWith(".", StringComparison.CurrentCulture) ? extension.Substring(1) : extension;
        }
    }
}