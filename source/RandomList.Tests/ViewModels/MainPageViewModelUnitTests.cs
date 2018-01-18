using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Prism.Navigation;
using RandomList.ViewModels;

namespace RandomList.Tests.ViewModels
{
    [TestClass]
    public class MainPageViewModelUnitTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void ShouldConstructMainPageViewModel()
        {
            // arrange
            var navigation = Substitute.For<INavigationService>();

            // act
            var mainPageViewModel = new MainPageViewModel(navigation);

            // assert
            mainPageViewModel.Should().NotBeNull();
        }
    }
}
