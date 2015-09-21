using System;
using System.ComponentModel.Composition;

namespace Tests.Common
{
    /// <summary>
    ///     Collection of helper methods to create custom <see cref="ExportFactory{T}" /> instances.
    /// </summary>
    public static class ExportFactoryHelper
    {
        /// <summary>
        /// Used when there is no need to dispose the value exported.
        /// </summary>
        private static readonly Action NoDisposeRequiredAction = () => { };

        /// <summary>
        /// Builds the export factory.
        /// </summary>
        /// <typeparam name="TExported">The type of the exported.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ExportFactory<TExported> BuildExportFactory<TExported>(TExported value)
        {
            return new ExportFactory<TExported>(() => BuildExportTuple(value));
        }

        private static Tuple<TExported, Action> BuildExportTuple<TExported>(TExported value)
        {
            return new Tuple<TExported, Action>(value,
                NoDisposeRequiredAction);
        }
    }
}