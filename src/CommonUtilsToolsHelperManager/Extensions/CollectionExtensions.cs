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

        public static bool AnyElementInBothCollections<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            if(collection1 is null)
            {
                throw new ArgumentNullException(nameof(collection1));
            }

            if (collection2 is null)
            {
                throw new ArgumentNullException(nameof(collection2));
            }

            if(!collection1.Any() || !collection2.Any())
            {
                return false;
            }

            return collection1.Intersect(collection2).Any();
        }
    }
}
