﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sprints.Services;
using Sprints.Views;

namespace Sprints
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<GoalDataStore>();
            DependencyService.Register<TaskDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
