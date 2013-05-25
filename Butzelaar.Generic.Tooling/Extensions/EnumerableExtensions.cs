using System;
using System.Collections.Generic;

namespace Butzelaar.Generic.Tooling.Extensions
{
    /// <summary>
    /// Contains extension methods
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes the action on each item in the list
        /// </summary>
        /// <typeparam name="T">Type that the list contains</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
        }
    }
}
