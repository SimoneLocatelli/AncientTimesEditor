using FluentChecker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Editor.WpfCommonLibrary.Dependencies
{
    /// <summary>
    /// Extensions methods related to the <see cref="ObservableCollection{T}"/> class
    /// </summary>
    public static class ObservableExtensions
    {
        /// <summary>
        /// Copy the elements inside the collection to the observable collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="observableCollection">The observable collection.</param>
        /// <param name="collection">The collection that contains the elements to copy.</param>
        public static void AddRange<TSource>(this ObservableCollection<TSource> observableCollection,
            IEnumerable<TSource> collection)
        {
            Check.IfIsNull(collection).Throw<ArgumentNullException>(() => collection);

            foreach (var item in collection)
            {
                observableCollection.Add(item);
            }
        }
    }
}