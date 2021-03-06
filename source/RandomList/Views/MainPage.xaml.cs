﻿// -----------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="Corey Baron">
// Copyright (c) Corey Baron. All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace RandomList.Views
{
    using RandomList.Infrastructure.Models;
    using RandomList.ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MainPageViewModel)this.BindingContext).RandomListSelectedCommand.Execute((RandomList)args.Item);
        }
    }
}