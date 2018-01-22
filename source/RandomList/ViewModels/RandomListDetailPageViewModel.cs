// -----------------------------------------------------------------------
// <copyright file="RandomListDetailPageViewModel.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;
    using RandomList.Infrastructure.Models;

    public class RandomListDetailPageViewModel : BindableBase, INavigatingAware
    {
        private RandomList randomList;

        public RandomListDetailPageViewModel()
        {
        }

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

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("randomlist"))
            {
                this.RandomList = (RandomList)parameters["randomlist"];
            }
        }
    }
}
