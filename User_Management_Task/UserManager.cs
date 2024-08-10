using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Task
{
    internal class UserManager
    {
        private static List<User> users = new List<User>();

        public static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("============================Add User============================");

            string userName = InputValidation.CheckEmptyString("Enter Name: ");
            string userEmail = InputValidation.CheckEmptyString("Enter Email: ");
            string userPhone = InputValidation.CheckEmptyString("Enter Phone: ");

            User newUser = new User(userName, userEmail, userPhone);

            users.Add(newUser);

            Console.WriteLine($"======================Information you Entered======================");
            Console.WriteLine(newUser);
        }

        public static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("============================Delete User============================");

            string userPhone = InputValidation.CheckEmptyString("Enter User Phone That You Want To Delete: ");

            bool removed = users.Remove(users.FirstOrDefault(u => u.PhoneNumber == userPhone));

            Console.WriteLine(removed ? "\nUser Removed." : "\nNo User Like That!!");
        }

        public static void UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("============================Update Date Of User============================");

            string userPhone = InputValidation.CheckEmptyString("Enter User Phone That You Want To Edit: ");

            User user = users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user != null)
            {
                int userInput = InputValidation.CheckIntInput("1-Edit Name\n2-Edit Email\n3-Edit Phone", "Invalid Choose Number", 1, 3);

                switch (userInput)
                {
                    case 1:
                        user.Name = InputValidation.CheckEmptyString("New Name: ");
                        break;
                    case 2:
                        user.Email = InputValidation.CheckEmptyString("New Email: ");
                        break;
                    case 3:
                        user.PhoneNumber = InputValidation.CheckEmptyString("New Phone: ");
                        break;
                }

                Console.WriteLine($"======================Information you Edited======================");
                Console.WriteLine(user);
            }
            else
                Console.WriteLine("\nNo User Like That!!");
        }

        public static void PrintAllUsers()
        {
            if (users.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("============================Print All Users============================");

                foreach (var user in users)
                {
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"Phone: {user.PhoneNumber}");
                    Console.WriteLine("-------------------------");
                }
            }
            else
                Console.WriteLine("\nNo Users Yet...");
        }

    }
}
