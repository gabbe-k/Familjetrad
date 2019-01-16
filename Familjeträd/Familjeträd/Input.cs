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
        public static Person RequestPerson(string request)
        {

            bool inputValid = false;
            Person returnPerson;
            string name;
            string surname;
            int birthyear;
            bool sex;

            while (!inputValid)
            {
                Console.WriteLine(request);


                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || Regex.Replace(input, "[^0-9A-z,]", "") != input || Convert.ToInt32(input) < 0)
                {
                    Console.WriteLine("Please follow the syntax: name,surname,birthyear,sex");
                }
                else
                {
                    string[] inputArr = input.Split(',');

                    if (Validator.AllStringValid(inputArr))
                    {
                        inputValid = true;

                        
                    }
                    else
                    {
                        Console.WriteLine("Please use A-z and 0-9 only");
                    }

                }

            }

            //returnPerson = new Person(name, surname, birthyear, sex);

            return returnPerson;

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
