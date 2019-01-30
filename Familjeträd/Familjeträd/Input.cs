using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

            while (true)
            {
                Print.PrMsg("Write a command or a chain of commands, separating them with '.' input '!help' help", "To execute several commands in a row, separate them with &. Whitespace does not matter.");

                string input = Console.ReadLine();

                if (input == "!help")
                {
                    Console.Clear();
                    Print.PrMsg("Placeholder guide");
                }

                else
                {
                    List<string>[] commandList = Validator.SyntaxValidator(input);

                    if (commandList == null)
                    {
                        Print.PrMsg("Input not valid");
                    }
                    else
                    {
                        foreach (var list in commandList)
                        {
                            Compiler.CompileRequest(list);
                        }

                    }

                }

            }

        }

        public static Person PickPerson()
        {
            if (PersonDB.personList.Count == 0)
            {
                Print.PrMsg("No people have been added, please use 'Create' command to add some!");
            }
            else
            {
                Print.PrDb();
                Print.PrMsg("Please pick a person by inputting the associated number of the person");
                bool validNumber = false;
                Person returnPerson = new Person("", "", 0, false);

                while (!validNumber)
                {
                    string input = Console.ReadLine();

                    if (Regex.IsMatch(input, "[0-9]+"))
                    {
                        int personNum = Convert.ToInt32(input);

                        returnPerson = PersonDB.personList[personNum-1];

                        validNumber = true;
                    }
                    else
                    {
                        Print.PrMsg("Input invalid, use numbers only");
                    }
                }

                return returnPerson;

            }

            return null;

        }






    }
}
