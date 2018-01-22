// -----------------------------------------------------------------------
// <copyright file="RandomList.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Infrastructure.Models
{
    using System.Collections.Generic;
    using global::RandomList.Infrastructure.Support;

    public class RandomList
    {
        public RandomList(string name, List<string> items)
        {
            this.Name = name;
            this.Items = items;

            this.RandomizeList();
        }

        public string Name { get; }

        public List<string> Items { get; }

        public List<string> ItemsRandomized { get; private set; }

        public void RandomizeList()
        {
            this.ItemsRandomized = new List<string>(this.Items);
            int n = this.ItemsRandomized.Count;

            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = this.ItemsRandomized[k];
                this.ItemsRandomized[k] = this.ItemsRandomized[n];
                this.ItemsRandomized[n] = value;
            }
        }
    }
}
