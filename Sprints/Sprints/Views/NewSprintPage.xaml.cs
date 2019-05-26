using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;

namespace Sprints.Views
{
    public partial class NewSprintPage : ContentPage
    {
        public SprintItem Sprint { get; set; }

        public NewSprintPage()
        {
            InitializeComponent();

            Sprint = new SprintItem
            {
                Title = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddSprint", Sprint);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}