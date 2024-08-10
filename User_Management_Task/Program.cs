namespace User_Management_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = false;
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
                        UserManager.AddUser();
                        break;
                    case 2:
                        UserManager.UpdateUser();
                        break;
                    case 3:
                        UserManager.DeleteUser();
                        break;
                    case 4:
                        UserManager.PrintAllUsers();
                        break;
                }

                Console.WriteLine($"===================================================================");

                continueProgram = ContinueProgram();

            } while (continueProgram);

            Console.Clear();
            Console.WriteLine("GoodBay...");
        }

        public static bool ContinueProgram()
        {
            while (true)
            {
                string tryAgain = InputValidation.CheckEmptyString("Anything Else? (Y/N) \n");

                if (tryAgain == "Y" || tryAgain == "y") return true;
                else if (tryAgain == "N" || tryAgain == "n") return false;

                Console.WriteLine("Invalid Choose...\n");
            }
        }
    }
}
