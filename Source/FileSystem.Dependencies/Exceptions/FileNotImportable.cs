#region Usings

using FluentChecker;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

#endregion Usings

namespace Editor.FileSystem.Dependencies.Exceptions
{
    /// <summary>
    ///     Thrown when an operation can be completed because the specified file
    ///     can't be imported.
    /// </summary>
    [Serializable]
    public class FileNotImportableException : Exception
    {
        /// <summary>
        ///     Gets the file full path that is cause of the exception.
        /// </summary>
        /// <value>
        ///     The file full path.
        /// </value>
        public string FileFullPath { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileNotImportableException" /> class.
        /// </summary>
        /// <param name="fileFullPath">The file full path.</param>
        public FileNotImportableException(string fileFullPath)
            : base(BuildExceptionMessage(fileFullPath))
        {
            FileFullPath = fileFullPath;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileNotImportableException" /> class.
        /// </summary>
        /// <param name="fileFullPath">The file full path.</param>
        /// <param name="message">The exception message.</param>
        [ExcludeFromCodeCoverage]
        public FileNotImportableException(string fileFullPath, string message)
            : base(message)
        {
            FileFullPath = fileFullPath;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileNotImportableException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        [ExcludeFromCodeCoverage]
        public FileNotImportableException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileNotImportableException" /> class.
        /// </summary>
        public FileNotImportableException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileNotImportableException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        [ExcludeFromCodeCoverage]
        protected FileNotImportableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///     When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with
        ///     information about the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("FileFullPath", FileFullPath);
        }

        /// <summary>
        ///     Builds the exception message.
        /// </summary>
        /// <param name="fileFullPath">The file full path.</param>
        /// <returns></returns>
        private static string BuildExceptionMessage(string fileFullPath)
        {
            Check.IfIsNullOrWhiteSpace(fileFullPath).Throw<ArgumentNullException>(() => fileFullPath);
            return string.Format(CultureInfo.CurrentCulture, Strings.FileNotImportableExceptionMessage, fileFullPath);
        }
    }
}