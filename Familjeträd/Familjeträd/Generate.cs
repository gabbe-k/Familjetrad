using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Generate
    {
        public static Person RequestPerson(string request)
        {

            bool inputValid = false;
            Person returnPerson = new Person("", "", 0, false);

            while (!inputValid)
            {

                Console.WriteLine(request);
                Console.WriteLine("Please follow the syntax: name,surname,birthyear,sex");
                string name = "";
                string surname = "";
                int birthyear = 0;
                bool sex = false;

                string input = Console.ReadLine();

                if (Validator.HasAmount(',', input) == 3 && (string.IsNullOrEmpty(input) || !Validator.HasKnownChars(input, "A-z0-9,")))
                {
                    continue;
                }
                else
                {
                    string[] inputArr = input.Split(',');

                    if (Validator.AllStringValid(inputArr))
                    {

                        name = inputArr[0];
                        surname = inputArr[1];
                        birthyear = Convert.ToInt32(inputArr[2]);
                        string sexString = inputArr[3].ToLower();

                        if (sexString == "male")
                        {
                            sex = false;
                        }
                        else
                        {
                            sex = true;
                        }

                        inputValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please use A-z and 0-9 only");
                    }

                }

                returnPerson = new Person(name, surname, birthyear, sex);

            }

            return returnPerson;

        }
    }
}
