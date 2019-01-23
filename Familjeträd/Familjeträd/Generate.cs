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
                    Console.WriteLine(personList[0]);
                    string name = personList[1];
                    string surname = personList[2];
                    int birthyear = Convert.ToInt32(personList[3]);
                    bool sex;

                    sex = personList[4] != "Male";

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




        public static Person GenChildPerson(string request, string parentSurname, int parentBirthyear, string parentName)
        {
            Console.WriteLine("Creating sibling of " + parentName);
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



        public static Person GenSiblingPerson(string request, string siblingSurname, int parentId, string siblingName)
        {
            Console.WriteLine("Creating sibling of " + siblingName);
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



        public static Person[] GenParents(string request, string personSurname, string personName, int personBirthyear)
        {
            Person[] returnParent = new Person[2];
            returnParent[0] = null;
            returnParent[1] = null;

            Console.WriteLine("Creating parents of " + personName);
            bool validParents = false;


            while (!validParents)
            {
                Person[] tmpParent = new Person[2];

                for (int i = 0; i < 2; i++)
                {

                    tmpParent[i] = GenPerson(request);

                    if (tmpParent[i].Birthyear - personBirthyear > 17)
                    {
                        returnParent[i] = tmpParent[i];

                        validParents = true;

                        if (tmpParent[i].Surname != personSurname)
                        {
                            tmpParent[i].Surname = personSurname;
                            Console.WriteLine("Surname has been adjusted to match child");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Age difference between child and parent needs to be atleast 18");
                    }

                }

            }

            return returnParent;


        }
    }
}
