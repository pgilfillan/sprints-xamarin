using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;

namespace Sprints.Views
{
    public partial class NewTaskPage : ContentPage
    {
        public TaskItem Task { get; set; }

        public NewTaskPage()
        {
            InitializeComponent();

            Task = new TaskItem
            {
                Title = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTask", Task);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}