// -----------------------------------------------------------------------
// <copyright file="RandomListDetailPageViewModel.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using Prism.Commands;
    using Prism.Navigation;
    using RandomList.Infrastructure.Models;

    public class RandomListDetailPageViewModel : ViewModelBase, INavigatingAware
    {
        private readonly INavigationService navigationService;

        private RandomList randomList;

        public RandomListDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.navigationService = navigationService;

            this.RandomizeCommand = new DelegateCommand(this.OnRandomizeCommandExecuted);
        }

        public DelegateCommand RandomizeCommand { get; }

        public RandomList RandomList
        {
            get
            {
                return this.randomList;
            }

            set
            {
                this.SetProperty(ref this.randomList, value);
            }
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("randomlist"))
            {
                this.RandomList = (RandomList)parameters["randomlist"];
                this.Title = this.RandomList.Name;
            }
        }

        private void OnRandomizeCommandExecuted()
        {
            this.RandomList.RandomizeList();

            this.RaisePropertyChanged("RandomList");
        }
    }
}
