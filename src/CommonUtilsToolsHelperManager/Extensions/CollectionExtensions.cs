using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonUtilsToolsHelperManager.Extensions
{
    public static class CollectionExtensions
    {
        private static Random random = new Random();

        public static T Random<T>(this IEnumerable<T> elements)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            int collectionSize = elements.Count();
            int randomIndex = random.Next(collectionSize);
            T element = elements.ToArray()[randomIndex];

            return element;
        }
    }
}
