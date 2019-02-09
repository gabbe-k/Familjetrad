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
    /// <summary>
    /// Generates different people for different uses
    /// </summary>
    class Generate
    {
        /// <summary>
        /// Generates a person
        /// </summary>
        /// <param name="request">Specifies which situation the person is generated for</param>
        /// <returns>A person newly generated</returns>
        public static Person GenPerson(string request)
        {
            bool inputGood = false;
            Person returnPerson = new Person("", "", 0, false);

            while (!inputGood)
            {
                Print.PrMsg(request, "Please follow the syntax: name,surname,birthyear,sex");

                string input = Console.ReadLine();

                List<string> personList = Validator.PersonSyntaxValidator(input, "Person");

                if (personList != null)
                {

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
                    Print.PrMsg("Syntax error");
                }

            }

            return returnPerson;

        }




        /// <summary>
        /// Generates a child for a couple
        /// </summary>
        /// <param name="request">Specifies the situation the child is created for</param>
        /// <param name="parentSurname">Surname of the parent that the child will inherit</param>
        /// <param name="parentBirthyear">Birthyear of the parent, used to check that the child isn't older than the parent</param>
        /// <param name="parentName">The name of the parent, used for interface purposes only</param>
        /// <returns>The child generated</returns>
        public static Person GenChildPerson(string request, string parentSurname, int parentBirthyear, string parentName)
        {
            Print.PrMsg("Creating child of " + parentName);
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
                        Print.PrMsg("Surname has been adjusted to match parents");
                    }

                }
                else
                {
                    Print.PrMsg("Error: Birthyear difference relative to parents needs to be atleast 18, and surname needs to match");
                }

            }

            return returnChild;

        }


        /// <summary>
        /// Generates a sibling for a person
        /// </summary>
        /// <param name="request">Specifies the situation the person is created for</param>
        /// <param name="siblingSurname">Surname of the parent that the person will inherit</param>
        /// <param name="parentId">Id for the parents of the siblings, used to check that the child isn't older than the parent</param>
        /// <param name="siblingName">The name of the sibling, used for interface purposes only</param>
        /// <returns>The sibling generated</returns>
        public static Person GenSiblingPerson(string request, string siblingSurname, int[] parentId, string siblingName)
        {
            Print.PrMsg("Creating sibling of " + siblingName);
            bool validChild = false;
            Person returnSibling = null;

            while (!validChild)
            {

                Person tmpSibling = GenPerson(request);

                if (parentId[0] == -1)
                {
                    returnSibling = tmpSibling;
                    validChild = true;
                }
                else
                {
                    for (int i = 0; i < PersonDB.personList.Count; i++)
                    {
                        if (parentId[0] == PersonDB.personList[i].Id && tmpSibling.Birthyear - PersonDB.personList[i].Birthyear > 17)
                        {
                            tmpSibling.ParentId = parentId;
                            returnSibling = tmpSibling;

                            validChild = true;
                        }
                        else
                        {
                            Print.PrMsg("Age difference between sibling and parent needs to be atleast 18");
                        }
                    }
                }

                if (tmpSibling.Surname != siblingSurname)
                {
                    tmpSibling.Surname = siblingSurname;
                    Print.PrMsg("Surname has been adjusted to match sibling");
                }


            }

            return returnSibling;

        }


        /// <summary>
        /// Generates parents for a person
        /// </summary>
        /// <param name="request">Specifies the situation the parents are created for</param>
        /// <param name="personSurname">Surname of the child, is to be inherited by the parents</param>
        /// <param name="personName">Name of the child, used for interface purposes only</param>
        /// <param name="personBirthyear">Birthyear of the parent, used to check that the child isn't older than the parent</param>
        /// <param name="id">Id of the child, used to set the parentId:s for the child</param>
        /// <param name="siblingIdList">List of siblings, used to assign other children to the parents</param>
        /// <returns></returns>
        public static Person[] GenParents(string request, string personSurname, string personName, int personBirthyear, int id, List<int> siblingIdList)
        {
            Person[] returnParent = new Person[2];
            returnParent[0] = null;
            returnParent[1] = null;

            Print.PrMsg("Creating parents of " + personName);
            bool validParents = false;

            while (!validParents)
            {
                Person[] tmpParent = new Person[2];

                for (int i = 0; i < 2;)
                {

                    tmpParent[i] = GenPerson(request);

                    if (personBirthyear - tmpParent[i].Birthyear > 17)
                    {
                        returnParent[i] = tmpParent[i];

                        validParents = true;

                        for (int j = 0; j < PersonDB.personList.Count; j++)
                        {
                            for (int k = 0; k < siblingIdList.Count; k++)
                            {
                                if (siblingIdList[k] == PersonDB.personList[j].Id)
                                {
                                    PersonDB.personList[j].ParentId[i] = tmpParent[i].Id;
                                }
                            }

                            if (id == PersonDB.personList[j].Id)
                            {
                                PersonDB.personList[j].ParentId[i] = tmpParent[i].Id;
                            }
                        }

                        if (tmpParent[i].Surname != personSurname)
                        {
                            tmpParent[i].Surname = personSurname;
                            Print.PrMsg("Surname has been adjusted to match child");
                        }

                        i++;

                    }
                    else
                    {
                        Print.PrMsg("Age difference between child and parent needs to be atleast 18");
                    }

                }

                tmpParent[0].PartnerId = tmpParent[1].Id;
                tmpParent[1].PartnerId = tmpParent[0].Id;

            }

            return returnParent;


        }
    }
}
