    internal abstract class InputValidation
    {
        #region Methods
        public static int CheckIntInput(string message, string messageIfCastingFails, int minCheck, int? maxCheck = null)
        {
            int userInput;
            bool flag, loopFlag;
            do
            {
                Console.WriteLine(message);
                flag = int.TryParse(Console.ReadLine(), out userInput);

                if (maxCheck is not null)
                {
                    loopFlag = !flag || userInput < minCheck || userInput > maxCheck;

                    if (loopFlag)
                        Console.WriteLine($"{messageIfCastingFails}...\n");
                }
                else
                {
                    loopFlag = !flag || userInput <= minCheck;

                    if (loopFlag)
                        Console.WriteLine($"{messageIfCastingFails}...\n");
                }

            } while (loopFlag);

            return userInput;
        }

        public static string CheckEmptyString(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("\nInput cannot be empty. Please try again.\n");

            } while (string.IsNullOrEmpty(input));

            return input;
        }
        #endregion
    }


    internal class User
    {
        #region Properites 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        #endregion

        #region Constructors
        public User(string _Phone)
        {
            Phone = _Phone;
        }
        public User(string _Name, string _Email, string _Phone) : this(_Phone)
        {
            Name = _Name;
            Email = _Email;
        }
        #endregion

        #region Methods
        public static void AddUser(List<User> users)
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

        public static void DeleteUser(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("============================Delete User============================");

            string userPhone = InputValidation.CheckEmptyString("Enter User Phone That You Want To Delete: ");

            bool removed = users.Remove(users.FirstOrDefault(u => u.Phone == userPhone));

            Console.WriteLine(removed ? "\nUser Removed." : "\nNo User Like That!!");
        }

        public static void UpdateUser(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("============================Update Date Of User============================");

            string userPhone = InputValidation.CheckEmptyString("Enter User Phone That You Want To Edit: ");

            User user = users.FirstOrDefault(u => u.Phone == userPhone);

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
                        user.Phone = InputValidation.CheckEmptyString("New Phone: ");
                        break;
                }

                Console.WriteLine($"======================Information you Edited======================");
                Console.WriteLine(user);
            }
            else
                Console.WriteLine("\nNo User Like That!!");
        }

        public static void PrintAllUsers(List<User> users)
        {
            if (users.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("============================Print All Users============================");

                foreach (var user in users)
                {
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"Phone: {user.Phone}");
                    Console.WriteLine("-------------------------");
                }
            }
            else
                Console.WriteLine("\nNo Users Yet...");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
        }
        #endregion
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            bool loopFlag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("====================Welcome In CRUD Operations Task====================");
                Console.WriteLine("1-Add User");
                Console.WriteLine("2-Update Date Of User");
                Console.WriteLine("3-Delete User");
                Console.WriteLine("4-Print All Users\n");

                int userInput = InputValidation.CheckIntInput("What You Want To Do?", "Invalid Choose Number", 1, 4);

                switch (userInput)
                {
                    case 1:
                        User.AddUser(users);
                        break;
                    case 2:
                        User.UpdateUser(users);
                        break;
                    case 3:
                        User.DeleteUser(users);
                        break;
                    case 4:
                        User.PrintAllUsers(users);
                        break;
                }

                Console.WriteLine($"===================================================================");

                while (true)
                {
                    string tryAgain = InputValidation.CheckEmptyString("Do You Want To Try Anything Else? \nY For Yes || N For No\n");
                    if (tryAgain == "Y" || tryAgain == "y")
                    {
                        loopFlag = true;
                        Console.WriteLine($"===================================================================");
                        break;
                    }
                    else if (tryAgain == "N" || tryAgain == "n")
                    {
                        loopFlag = false;
                        break;
                    }
                    else
                        Console.WriteLine("Invalid Choose...\n");
                }

            } while (loopFlag);

            Console.WriteLine("GoodBay...");
        }
    }