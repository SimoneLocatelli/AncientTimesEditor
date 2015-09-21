using System.Globalization;

namespace Utils
{
    /// <summary>
    ///     Generates standardized messages for the ArgumentException.
    /// </summary>
    public static class ArgumentExceptionMessagesFactory
    {
        /// <summary>
        ///     Generate the message for the ArgumentException thrown when an instance is not the
        ///     expected type.
        /// </summary>
        /// <typeparam name="TExpected"> The type of the expected. </typeparam>
        /// <returns></returns>
        public static string InstanceIsNotExpectedType<TExpected>()
        {
            return string.Format(CultureInfo.CurrentCulture,
                CommonResources.ArgumentExceptionInstanceIsNotExpectedType,
                typeof(TExpected).FullName);
        }
    }
}