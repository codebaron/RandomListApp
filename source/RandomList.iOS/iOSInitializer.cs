// -----------------------------------------------------------------------
// <copyright file="iOSInitializer.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.iOS
{
    using Autofac;
    using Prism.Autofac;

#pragma warning disable SA1300
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
        }
    }
#pragma warning restore SA1300
}