// -----------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using Prism.Navigation;

    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.Title = "Main Page";
        }
    }
}