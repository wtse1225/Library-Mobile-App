using System.Collections.Generic;

namespace Library_WaiHingWilliamTse
{
    public class User
    {        
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string name, string pw)
        {
            this.UserName = name;
            this.Password = pw;
        }

        public static List<User> InitUsers()
        {
            // Hard coded user profiles for testing     
            List<User> userList = new List<User>(); // create list

            User user1 = new User("peter", "1234"); // create users
            User user2 = new User("mary", "0000");

            userList.Add(user1); // add users to the list
            userList.Add(user2);

            return userList;
        }
    }

    

}
