using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Input
    {
        public static void RequestAction()
        {
            bool inputValid = false;

            while (!inputValid)
            {
                Console.WriteLine("Write a command or a chain of commands, separating them with '.' input '!help' help");

                string input = Console.ReadLine();

                if (input == "!help")
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("");
                    Console.WriteLine("-------------------------------");
                }

                else
                {
                    List<string> commandList = Validator.SyntaxValidator(input);

                    if (commandList == null)
                    {
                        Console.WriteLine("Invalid result my man");
                    }
                    else
                    {
                        for (int i = 0; i < commandList.Count; i++)
                        {
                            Console.WriteLine(commandList[i]);
                        }
                    }

                }

            }

        }

        public static string RequestString(string request)
        {

            bool inputValid = false;
            string returnInput = "";

            while (!inputValid)
            {
                Console.WriteLine(request);

                string input = Console.ReadLine();

                if (input.Length == 0 || Regex.Replace(input, "[^A-z]", "") != input)
                {
                    Console.WriteLine("Please use A-z only");
                }
                else
                {
                    returnInput = input;
                    inputValid = true;
                }

            }

            return returnInput;

        }
    }
}
