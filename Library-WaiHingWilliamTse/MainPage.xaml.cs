using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Library_WaiHingWilliamTse
{
    public partial class MainPage : ContentPage
    {
        // Declare a User list for access within the MainPage
        private List<User> userList;

        public MainPage()
        {   
            InitializeComponent();
            
            // Call User class to create the default users
            userList = User.InitUsers();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nameFromUI = name.Text;
            string passwordFromUI = password.Text;

            // Login validation
            foreach (User user in userList) 
            {
                // error msg clean up
                error.IsVisible = false;
                error.Text = string.Empty;

                if (string.IsNullOrEmpty(nameFromUI) || string.IsNullOrEmpty(passwordFromUI))
                {
                    error.Text = "User name and password cannot be empty";
                    error.IsVisible = true;
                }
                else if (!(nameFromUI == user.UserName && passwordFromUI == user.Password))
                {
                    error.Text = "Incorrect user name or password. Try again";
                    error.IsVisible = true;
                }
                else 
                {
                    await Navigation.PushAsync(new BookList(user));

                    // Self-reminder: don't forget to set the main page to navigation page in App.xaml.cs
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            name.Text = string.Empty;
            password.Text = string.Empty;
            error.Text = string.Empty;
        }
    }
}
