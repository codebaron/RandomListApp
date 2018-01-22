// -----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;

    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string title;

        public ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        protected INavigationService NavigationService { get; private set; }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
