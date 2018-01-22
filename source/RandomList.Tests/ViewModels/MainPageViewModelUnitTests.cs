// -----------------------------------------------------------------------
// <copyright file="MainPageViewModelUnitTests.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Tests.ViewModels
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using Prism.Navigation;
    using RandomList.Infrastructure.Models;
    using RandomList.Services.Interfaces;
    using RandomList.ViewModels;

    [TestClass]
    public class MainPageViewModelUnitTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void ShouldConstructMainPageViewModel()
        {
            // arrange
            var navigation = Substitute.For<INavigationService>();
            var deviceStorage = Substitute.For<IDeviceStorage>();
            deviceStorage.GetSavedRandomLists().Returns(new List<RandomList>());

            // act
            var mainPageViewModel = new MainPageViewModel(navigation, deviceStorage);

            // assert
            mainPageViewModel.Should().NotBeNull();
        }
    }
}
