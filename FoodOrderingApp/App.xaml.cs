﻿using FoodOrderingApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new LoginViewPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
