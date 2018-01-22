// -----------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using System.Collections.ObjectModel;
    using Prism.Navigation;
    using RandomList.Infrastructure.Models;
    using RandomList.Services.Interfaces;

    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<RandomList> randomLists;

        public MainPageViewModel(
            INavigationService navigationService,
            IDeviceStorage deviceStorage)
            : base(navigationService)
        {
            this.Title = "My Lists";

            this.randomLists = new ObservableCollection<RandomList>(deviceStorage.GetSavedRandomLists());
        }

        public ObservableCollection<RandomList> Lists
        {
            get
            {
                return this.randomLists;
            }
        }
    }
}