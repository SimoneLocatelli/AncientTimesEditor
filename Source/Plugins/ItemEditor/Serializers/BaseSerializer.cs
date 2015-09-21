using Editor.FileSystem.Dependencies.Facades;
using Editor.FileSystem.Dependencies.FileManagers;
using Editor.Logging.Dependencies;
using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Editor.ItemEditor.Serializers
{
    /// <summary>
    ///     Base class for the serializers used in this module.
    /// </summary>
    public abstract class BaseSerializer
    {
        /// <summary>
        ///     The name of the file where the items will be serialized
        /// </summary>
        protected const string ItemsSerializedFileName = "Items.xml";

        private readonly IEditorLogger logger;
        private readonly IPathFacade pathFacade;
        private readonly IProjectLoader projectLoader;

        /// <summary>
        ///     Gets a value indicating whether a project has been loaded loaded.
        /// </summary>
        /// <value>
        ///     <c>true</c> if a project has been loaded loaded; otherwise, <c>false</c>.
        /// </value>
        public bool IsProjectLoaded
        {
            get { return projectLoader.CurrentProject != null; }
        }

        /// <summary>
        ///     Gets the logger reference.
        /// </summary>
        /// <value>
        ///     The logger.
        /// </value>
        protected IEditorLogger Logger
        {
            get { return logger; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseSerializer" /> class.
        /// </summary>
        /// <param name="pathFacade">The path facade.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="projectLoader">The project loader.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected BaseSerializer(IPathFacade pathFacade, IEditorLogger logger, IProjectLoader projectLoader)
        {
            Check.IfIsNull(pathFacade).Throw<ArgumentNullException>(() => pathFacade);
            Check.IfIsNull(logger).Throw<ArgumentNullException>(() => logger);
            Check.IfIsNull(projectLoader).Throw<ArgumentNullException>(() => projectLoader);

            this.pathFacade = pathFacade;
            this.logger = logger;
            this.projectLoader = projectLoader;
        }

        /// <summary>
        ///     Gets the default location ofthe items collection serialized.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        protected string GetDefaultLocation()
        {
            if (projectLoader.CurrentProject != null)
            {
                return pathFacade.Combine(projectLoader.CurrentProject.Path, ItemsSerializedFileName);
            }

            throw new InvalidOperationException("Operation not allowed. No project has been loaded.");
        }
    }
}