// -----------------------------------------------------------------------
// <copyright file="RandomListUnitTests.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Tests.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RandomList.Infrastructure.Models;

    [TestClass]
    public class RandomListUnitTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void ShouldConstructRandomList()
        {
            // arrange

            // act
            var randomList = new RandomList("Characters", new List<string> { "Bert", "Ernie" });

            // assert
            randomList.Name.Should().BeEquivalentTo("Characters");
            randomList.Items.Should().HaveCount(2);
            randomList.Items[0].Should().BeEquivalentTo("Bert");
            randomList.Items[1].Should().BeEquivalentTo("Ernie");
            randomList.ItemsRandomized.Should().HaveCount(2);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void ShouldRandomizeListForRandomList()
        {
            // arrange
            var randomList = new RandomList("Characters", new List<string> { "Bert", "Ernie", "Romeo", "Juliet" });
            var listCollection = new List<List<string>> { randomList.ItemsRandomized };

            // act
            for (var randomizations = 1; randomizations < 11; randomizations++)
            {
                randomList.RandomizeList();
                listCollection.Add(randomList.ItemsRandomized);
            }

            // assert
            var testItemPositions = listCollection.Select(l => l.IndexOf("Bert")).ToList();

            // assumes multiple randomizes are highly unlikely to be the same every time
            testItemPositions.Sort();
            testItemPositions[0].Should().NotBe(testItemPositions[testItemPositions.Count - 1]);
        }
    }
}
