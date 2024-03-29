﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;

namespace Sprints.Views
{
    public partial class NewGoalPage : ContentPage
    {
        public GoalItem Goal { get; set; }

        public NewGoalPage()
        {
            InitializeComponent();

            Goal = new GoalItem
            {
                Title = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGoal", Goal);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}