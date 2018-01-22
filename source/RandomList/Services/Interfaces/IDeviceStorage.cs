// -----------------------------------------------------------------------
// <copyright file="IDeviceStorage.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Services.Interfaces
{
    using System.Collections.Generic;
    using RandomList.Infrastructure.Models;

    public interface IDeviceStorage
    {
        List<RandomList> GetSavedRandomLists();
    }
}
