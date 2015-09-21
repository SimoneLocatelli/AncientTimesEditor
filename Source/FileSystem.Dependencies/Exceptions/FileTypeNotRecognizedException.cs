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
    ///     Thrown when the specified File Type has not been recognized.
    /// </summary>
    [Serializable]
    public class FileTypeNotRecognizedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FileTypeNotRecognizedException" /> class.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        public FileTypeNotRecognizedException(Type fileType)
            : base(CreateExceptionMessage(fileType))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileTypeNotRecognizedException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        [ExcludeFromCodeCoverage]
        public FileTypeNotRecognizedException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileTypeNotRecognizedException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        [ExcludeFromCodeCoverage]
        public FileTypeNotRecognizedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileTypeNotRecognizedException" /> class.
        /// </summary>
        public FileTypeNotRecognizedException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileTypeNotRecognizedException" /> class.
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
        protected FileTypeNotRecognizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///     Creates the exception message.
        /// </summary>
        /// <param name="fileType">Type of the file.</param>
        /// <returns></returns>
        private static string CreateExceptionMessage(Type fileType)
        {
            Check.IfIsNull(fileType).Throw<ArgumentNullException>(() => fileType);

            return string.Format(CultureInfo.CurrentCulture, Strings.FileTypeNotRecognizedExceptionMessage,
                fileType.FullName);
        }
    }
}