using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Generate
    {
        public static Person GenPerson(string request)
        {

            bool inputGood = false;
            Person returnPerson = new Person("", "", 0, false);

            while (!inputGood)
            {

                Console.WriteLine(request);
                Console.WriteLine("Please follow the syntax: name,surname,birthyear,sex");

                string input = Console.ReadLine();

                List<string> personList = Validator.PersonSyntaxValidator(input, "Person");

                if (personList != null)
                {
                    string name = personList[0];
                    string surname = personList[1];
                    int birthyear = Convert.ToInt32(personList[2]);
                    bool sex;

                    sex = personList[3] != "Male";

                    returnPerson = new Person(name, surname, birthyear, sex);

                    inputGood = true;
                }
                else
                {
                    Console.WriteLine("Syntax error");
                }

            }

            return returnPerson;

        }




        public static Person GenChildPerson(string request, string parentSurname, int parentBirthyear)
        {

            bool validChild = false;
            Person returnChild = null;

            while (!validChild)
            {

                Person tmpChild = GenPerson(request);

                if ((parentBirthyear - tmpChild.Birthyear) < 18)
                {
                    returnChild = tmpChild;

                    validChild = true;

                    if (tmpChild.Surname != parentSurname)
                    {
                        tmpChild.Surname = parentSurname;
                        Console.WriteLine("Surname has been adjusted to match parents");
                    }

                }
                else
                {
                    Console.WriteLine("Error: Birthyear difference relative to parents needs to be atleast 18, and surname needs to match");
                }

            }

            return returnChild;

        }



        public static Person GenSiblingPerson(string request, string siblingSurname, int parentId)
        {

            bool validChild = false;
            Person returnChild = null;

            while (!validChild)
            {

                Person tmpChild = GenPerson(request);

                for (int i = 0; i < PersonDB.personList.Count; i++)
                {
                    if (parentId == PersonDB.personList[i].Id && PersonDB.personList[i].Birthyear - tmpChild.Birthyear > 17)
                    {
                        returnChild = tmpChild;

                        validChild = true;

                        if (tmpChild.Surname != siblingSurname)
                        {
                            tmpChild.Surname = siblingSurname;
                            Console.WriteLine("Surname has been adjusted to match sibling");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Age difference between sibling and parent needs to be atleast 18");
                    }
                }

            }

            return returnChild;

        }
    }
}
