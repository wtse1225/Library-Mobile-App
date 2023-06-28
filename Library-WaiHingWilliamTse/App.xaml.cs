using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library_WaiHingWilliamTse
{
    public partial class App : Application
    {
        // create an instance of the MyDatabase class
        // implement it as a singleton
        private static Database db;
        public static Database MyDb
        {
            get
            {
                if (db == null)
                {
                    db = new Database();
                }
                return db;
            }
        }

        // Entry point
        public App()
        {
            InitializeComponent();

            // init books and DB if not already
            Task task = InitDbAndBooks();
            
            // change to NavigationPage as root
            MainPage = new NavigationPage(new MainPage()); 
        }

        private async Task InitDbAndBooks()
        {
            await MyDb.initBooks();
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
