// -----------------------------------------------------------------------
// <copyright file="MockDeviceStorage.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Services
{
    using System.Collections.Generic;
    using RandomList.Infrastructure.Models;
    using RandomList.Services.Interfaces;

    public class MockDeviceStorage : IDeviceStorage
    {
        private static List<RandomList> randomList = new List<RandomList>
        {
            new RandomList("Chores", new List<string> { "Clean fridge", "Sweep floor", "Wipe counter", "Take out trash" }),
            new RandomList("Spelling Words", new List<string> { "Agog", "Capricious", "Interstellar", "Tomorrow" })
        };

        public List<RandomList> GetSavedRandomLists()
        {
            return randomList;
        }
    }
}
