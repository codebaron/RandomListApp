// -----------------------------------------------------------------------
// <copyright file="ThreadSafeRandom.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Infrastructure.Support
{
    using System;
    using System.Threading;

    // credit implementation from: https://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random local;

        public static Random ThisThreadsRandom
        {
            get
            {
                return local ?? (local = new Random(unchecked((Environment.TickCount * 31) + Thread.CurrentThread.ManagedThreadId)));
            }
        }
    }
}
