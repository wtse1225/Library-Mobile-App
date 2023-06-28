using SQLite;

namespace Library_WaiHingWilliamTse
{
    public class Book
    {
        // define a property as the primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Every property needs be initialized with { get; set; } or SQLite won't persist the changes!! No hints no nothing!! sucks!!
        public long Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public string Borrower { get; set; }

        // Note: Default constructor is required for SQLite
        public Book() { }

        // custom constructor
        public Book(long isbn, string title, string author, bool status=false, string borrower="")
        {
            this.Isbn = isbn;
            this.Title = title;
            this.Author = author;
            this.Status = status;
            this.Borrower = borrower;            
        }

        public override string ToString()
        {            
            //return base.ToString();
            return $"Isbn: {this.Isbn}, Title: {this.Title}, Author: {this.Author}, Status: {this.Status}, Borrower: {this.Borrower}";
        }
    }
}
