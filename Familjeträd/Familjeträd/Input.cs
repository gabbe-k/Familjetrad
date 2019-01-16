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

                    if (input.IndexOf(';') == input.Length - 1 && (!string.IsNullOrEmpty(input) || Regex.Replace(input, "[^0-9A-z.()]", "") == input))
                    {
                        string[] inputArr = input.Split('.');

                        if (Regex.IsMatch(inputArr[0], "Add|Create"))
                        {
                            for (int i = 1; i < inputArr.Length; i++)
                            {
                                string validPrefix = "Children[(][0-9][)]|Siblings[(][0-9][)]|Person[(][0-9][)]";

                                if (Regex.IsMatch(inputArr[i], "Parents|Partner"))
                                {
                                    Console.WriteLine("Command for add parent");
                                }
                                else if (Regex.IsMatch(inputArr[i], validPrefix))
                                {
                                    if ((i == inputArr.Length - 1 && Validator.HasKnownChars(inputArr[i], "0-9A-z();") || (i < inputArr.Length && Validator.HasKnownChars(inputArr[i], "0-9A-z()"))))
                                    {
                                        string tmp = inputArr[i].Substring(inputArr[i].IndexOf('(') + 1, inputArr[i].IndexOf(')') - 1 - inputArr[i].IndexOf('('));

                                        if (Validator.HasKnownChars(tmp, "0-9A-z"))
                                        {
                                            if (Regex.Match(inputArr[i], validPrefix))
                                            {

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unknown characters detected, write !help for help");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Unknown characters detected, write !help for help");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Please use a valid operation prefix: Parents, Partner, Children([number]), Siblings([number]), Person([number]) etc");
                                    Console.WriteLine("You used: " + inputArr[i]);
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Please start line with 'Add' or 'Create'");
                        }

                    }
                    else if (!input.Contains(';'))
                    {
                        Console.WriteLine("Please end the line with a ;");
                    }
                    else
                    {
                        Console.WriteLine("Unknown characters detected, write !help for help");
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
