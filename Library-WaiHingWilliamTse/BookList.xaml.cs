using System;
using Xamarin.Forms;

namespace Library_WaiHingWilliamTse
{
    public partial class BookList : ContentPage
    {
        // User credential for access within this module
        User loginUser;

        public BookList(User user)
        {
            InitializeComponent();

            loginUser = user;

            welcomeMsg.Text = $"Welcome {user.UserName}!";

            // reload the books from the DB to the UI
            LoadBooks();
        }

        // This fn refreshes the book list in the DB when being called
        async void LoadBooks()
        {
            lvBooks.ItemsSource = await App.MyDb.GetAllBooks();
        }

        private void lvBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Cast object to Book type for properties access
            Book book = (Book) e.SelectedItem;

            clearStatusMsg();

            if (!book.Status)
            {
                statusMsg.Text = $"<{book.Title}> is available for borrowing.";
                statusMsg.IsVisible = true;
            }
            else if (book.Borrower == loginUser.UserName)
            {
                statusMsg.Text = "You have this book checked out!";
                statusMsg.IsVisible = true;
            }
            else
            {
                statusMsg.Text = $"The book is checked out by {book.Borrower}.";
                statusMsg.IsVisible = true;
            }
        }

        private async void CheckOut_Clicked(object sender, EventArgs e)
        {            
            // Cast sender object to MenuItem, then cast menuItem to Book type, gosh
            MenuItem menuItem = (MenuItem)sender;
            Book selectedbook = (Book)menuItem.BindingContext;

            // Get the book object from DB
            Book book = await App.MyDb.GetItemById(selectedbook.Id);

            if (!book.Status)
            {
                book.Status = true;
                book.Borrower = loginUser.UserName;

                int updated = await App.MyDb.UpdateItem(book);

                if (updated == 1)
                {
                    await DisplayAlert("Success", "Done!", "OK");
                    clearStatusMsg();
                }
            }
            else if (book.Borrower == loginUser.UserName)
            {
                await DisplayAlert("ERROR", $"You already have this book checked out!", "OK");         
            }
            else
            {
                await DisplayAlert("ERROR", $"<{book.Title}> is already checked out by {book.Borrower}", "OK");
            }
            LoadBooks();
        }

        private async void Return_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Book selectedbook = (Book)menuItem.BindingContext;

            Book book = await App.MyDb.GetItemById(selectedbook.Id);

            if (!book.Status || (book.Borrower != loginUser.UserName)) 
            {
                await DisplayAlert("ERROR", "This book cannot be returned.", "OK");
            }
            else if (book.Borrower == loginUser.UserName)
            {
                book.Status = false;
                book.Borrower = loginUser.UserName;

                int updated = await App.MyDb.UpdateItem(book);

                if (updated == 1)
                {
                    await DisplayAlert("SUCCESS", "Book returned.", "OK");
                    clearStatusMsg();
                }
            }
            LoadBooks();
        }

        private void clearStatusMsg()
        {
            statusMsg.Text = string.Empty;
            statusMsg.IsVisible = false;
        }
    }
}