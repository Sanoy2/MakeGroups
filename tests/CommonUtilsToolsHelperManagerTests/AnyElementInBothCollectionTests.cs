using System.Collections.Generic;
using Xunit;
using FluentAssertions;

using CommonUtilsToolsHelperManager.Extensions;
using System;

namespace CommonUtilsToolsHelperManagerTests
{
    public class AnyElementInBothCollectionTests
    {
        [Fact]
        public void LeftCollectionNull_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> col1 = null;
            IEnumerable<int> col2 = new List<int>();

            Action act = () =>
            {
                col1.AnyElementInBothCollections(col2);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RightCollectionNull_ShouldThrowArgumentNullException()
        {
            IEnumerable<int> col1 = new List<int>();
            IEnumerable<int> col2 = null;

            Action act = () =>
            {
                col1.AnyElementInBothCollections(col2);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void BothCollectionsEmpty_ShouldBeFalse()
        {
            var col1 = new List<int>();
            var col2 = new List<int>();

            bool result = col1.AnyElementInBothCollections(col2);

            result.Should().BeFalse();
        }

        [Fact]
        public void LeftCollectionEmpty_ShouldBeFalse()
        {
            var col1 = new List<int>();
            var col2 = new List<int>();
            col2.Add(5);

            bool result = col1.AnyElementInBothCollections(col2);

            result.Should().BeFalse();
        }

        [Fact]
        public void RightCollectionEmpty_ShouldBeFalse()
        {
            var col1 = new List<int>();
            var col2 = new List<int>();
            col1.Add(5);

            bool result = col1.AnyElementInBothCollections(col2);

            result.Should().BeFalse();
        }

        [Fact]
        public void BothCollectionsUniqueElements_ShouldBeFalse()
        {
            var col1 = new List<int>();
            var col2 = new List<int>();

            col1.Add(5);
            col1.Add(42);

            col2.Add(-2);
            col2.Add(129);

            bool result = col1.AnyElementInBothCollections(col2);

            result.Should().BeFalse();
        }

        [Fact]
        public void CollectionHave1SameElement_ShouldBeFalse()
        {
            var col1 = new List<int>();
            var col2 = new List<int>();

            col1.Add(5);
            col1.Add(42);
            col1.Add(129);

            col2.Add(-2);
            col2.Add(129);

            bool result = col1.AnyElementInBothCollections(col2);

            result.Should().BeTrue();
        }
    }
}
