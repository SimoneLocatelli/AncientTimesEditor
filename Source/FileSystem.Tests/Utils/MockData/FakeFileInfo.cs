﻿using Editor.FileSystem.Dependencies;

namespace Editor.FileSystem.Tests.Utils.MockData
{
    public class FakeFileInfo : IFileInfo
    {
        /// <summary>
        ///     Gets the default name of the file to use when a new item of this type is being created.
        /// </summary>
        /// <value> The default name of the file. </value>
        public string DefaultFileName { get; private set; }

        /// <summary>
        ///     Gets the description of the file type.
        /// </summary>
        /// <value> The description. </value>
        public string Description { get; private set; }

        /// <summary>
        ///     Gets the file extension.
        /// </summary>
        /// <value> The extension. </value>
        public string Extension
        {
            get { return "fake"; }
        }
    }
}