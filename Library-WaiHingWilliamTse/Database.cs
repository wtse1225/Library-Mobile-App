using System;
using System.Collections.Generic; // make sure it's here when dealing with templates
using SQLite;
using System.IO; // enable path
using System.Threading.Tasks;

namespace Library_WaiHingWilliamTse
{
    public class Database
    {
        // Define the connection to the local database, need to mention "Async"
        readonly SQLiteAsyncConnection dbConnection;

        public Database()
        {
            // Connection configuration
            // Name the db file and get the path
            string dbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "BookDatabase.db");

            // Create connection using the path          
            dbConnection = new SQLiteAsyncConnection(dbPath);

            // Create the table
            dbConnection.DropTableAsync<Book>(); // reset to a new session if needed
            dbConnection.CreateTableAsync<Book>().Wait();
            Console.WriteLine($"++++++ Database table created!"); 
        }

        public async Task initBooks()
        {            
            // Only populate books when there is no books in the DB
            int bookCount = await dbConnection.Table<Book>().CountAsync();
            if (bookCount == 0)
            {
                int numOfBookAdded = 0;

                Book[] books = new Book[]
                {
                    new Book(9781593279509, "Eloquent JavaScript, Third Edition",   "Marijn Haverbeke", false, string.Empty),
                    new Book(9781491943533, "Practical Modern JavaScript", "Nicolás Bevacqua", false, string.Empty),
                    new Book(9781593277574, "Understanding ECMAScript 6", "Nicholas C. Zakas", false, string.Empty),
                    new Book(9781484200766, "Everything you neeed to know about Git", "Scott Chacon and Ben Straub", false, string.Empty),
                    new Book(9781484242216, "Rethinking Productivity in Software Engineering", "Caitlin Sadowski, Thomas Zimmermann", false, string.Empty),
                    new Book(1604561149, "Paraxial Light Beams with Angular Momentum", "A. Bekshaev, Marat Samuilovich Soskin, M. Vasnetsov", false, string.Empty),
                    new Book(0881325937, "Avoiding the Apocalypse: The Future of the Two Koreas", "Noland, Marcus", false, string.Empty)
                };
                
                foreach (Book book in books)
                {
                    int updated = await AddBook(book);
                    numOfBookAdded += updated;
                }
                Console.WriteLine($"++++++ {numOfBookAdded} books are added.");
                Console.WriteLine("++++++ Books are initialized!");
            }
        }

        // Get all
        public async Task<List<Book>> GetAllBooks()
        {            
            List<Book> resultList = await dbConnection.Table<Book>().ToListAsync();
            Console.WriteLine("++++++ All books are fetched from DB");

            return resultList;
        }
        
        // Get one
        public async Task<Book> GetItemById(int id)
        {            
            Book result = await dbConnection.GetAsync<Book>(id);
            
            return result;
        }

        // Add
        public async Task<int> AddBook(Book book)
        {
            int rowsAdded = await dbConnection.InsertAsync(book);
            
            return rowsAdded;
        }

        // Update
        public async Task<int> UpdateItem(Book book)
        {
            int result = await dbConnection.UpdateAsync(book);
            Console.WriteLine("++++++ Book has been updated in DB");

            return result;
        }

    }
}
