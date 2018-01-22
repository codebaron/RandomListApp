// -----------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Prism.Commands;
    using Prism.Navigation;
    using RandomList.Infrastructure.Models;
    using RandomList.Services.Interfaces;

    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        private DelegateCommand<RandomList> randomListSelectedCommand;

        private ObservableCollection<RandomList> randomLists;

        public MainPageViewModel(
            INavigationService navigationService,
            IDeviceStorage deviceStorage)
            : base(navigationService)
        {
            this.Title = "My Lists";
            this.navigationService = navigationService;

            this.randomLists = new ObservableCollection<RandomList>(deviceStorage.GetSavedRandomLists());
        }

        public DelegateCommand<RandomList> RandomListSelectedCommand =>
            this.randomListSelectedCommand != null ? this.randomListSelectedCommand : (this.randomListSelectedCommand = new DelegateCommand<RandomList>(this.RandomListSelected));

        public ObservableCollection<RandomList> Lists
        {
            get
            {
                return this.randomLists;
            }
        }

        internal async Task NavigateToDetailPage(RandomList randomList)
        {
            var parameters = new NavigationParameters
            {
                { "randomlist", randomList }
            };

            await this.navigationService.NavigateAsync("NavigationPage/RandomListDetailPage", parameters);
        }

        private async void RandomListSelected(RandomList randomList)
        {
            await this.NavigateToDetailPage(randomList);
        }
    }
}