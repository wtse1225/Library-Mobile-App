# Library-WaiHingWilliamTse
Technologies used: Xamarin.Forms, SQLite, C#\
This library mobile app leverages Xamarin.Forms and SQLite to provide a user-friendly interface for managing book interactions, ensuring a seamless experience for library users.<br><br>
• Developed a cross-platform mobile application that enables users to interact with a library's book collection. The app features two screens: a Login Screen and a Books List Screen. The Login Screen allows users to sign in or create a new account, with validation on form fields and static user credentials. Upon successful login, users are navigated to the Books List Screen.<br><br>
• The Books List Screen displays a welcome message to the logged-in user and a dynamically loaded list of books from a SQLite database. Each book's borrowing status is shown, indicating availability, checked-out status with the borrower's name, or if the user has borrowed the book. Context actions enable users to check out or return books, with pop-up messages indicating the success or failure of the operation.<br><br>
• Book details are modeled using a custom class with properties such as ISBN-10 number, title, author, borrowing status, and borrower. Data persistence is implemented using SQLite, utilizing the sqlite-net-pcl library. The database is prepopulated with a minimum of 4 books, and its creation and population occur before the login screen is displayed.
• The app employs hierarchical navigation for seamless movement between screens. Pressing "back" on the Books List Screen returns users to the Login Screen, clearing any prior content, including form fields and error messages.<br><br>

![image](https://github.com/wtse1225/Library-Mobile-App/assets/105259859/9dc53f80-e467-463b-bcaa-a8f860695e28) 
![image](https://github.com/wtse1225/Library-Mobile-App/assets/105259859/ddae1fc5-60fc-426a-acab-5b1cd8b2db50)
