// -----------------------------------------------------------------------
// <copyright file="AndroidInitializer.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Droid
{
    using Autofac;
    using Prism.Autofac;

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            // Register any platform specific implementations
        }
    }
}