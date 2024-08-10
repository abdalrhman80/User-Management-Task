using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Management_Task
{
    internal abstract class InputValidation
    {
        public static int CheckIntInput(string message, string messageIfCastingFails, int minCheck, int maxCheck)
        {
            int userInput;
            bool flag, loopFlag;
            do
            {
                Console.WriteLine(message);
                flag = int.TryParse(Console.ReadLine(), out userInput);

                loopFlag = !flag || userInput < minCheck || userInput > maxCheck;

                if (loopFlag)
                    Console.WriteLine($"{messageIfCastingFails}...\n");

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
    }
}
