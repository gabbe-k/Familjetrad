using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    /// <summary>
    /// Runs functions depending on the users command inputs
    /// </summary>
    class Compiler
    {
        /// <summary>
        /// Runs functions for the specified commands in the list 'commandList'
        /// </summary>
        /// <param name="commandList">The current list of commands returned from the validator</param>
        public static void CompileRequest(List<string> commandList)
        {

            List<Person> tmpPersonList = new List<Person>();
            bool hasPerson = false;
            bool picked = false;

            for (int i = 0; i < commandList.Count; i++)
            {

                if (commandList[0] == "Add" && !picked)
                {
                    tmpPersonList.Add(Input.PickPerson("Pick a person to execute your commands on"));
                    if (tmpPersonList[0] == null)
                    {
                        break;
                    }

                    hasPerson = true;
                    picked = true;

                }
                else
                {
                    if (commandList[i] == "PersonStruct")
                    {
                        bool sex;

                        if (commandList[i + 4] == "Male")
                        {
                            sex = false;
                        }
                        else
                        {
                            sex = true;
                        }

                        Person tmpPerson = new Person(commandList[i+1], commandList[i + 2], Convert.ToInt32(commandList[i + 3]), sex);

                        tmpPersonList.Add(tmpPerson);
                        PersonDB.Add(tmpPerson);

                        hasPerson = true;
                    }
                    else if(commandList[i].Contains("Person"))
                    {
                        int tmpCount = Convert.ToInt32(commandList[i].Substring(commandList[i].IndexOf('*') + 1));

                        for (int j = 0; j < tmpCount; j++)
                        {
                            Person tmpPerson =  Generate.GenPerson("Type in the details for person #" + j + 1);
                            tmpPersonList.Add(tmpPerson);
                            PersonDB.Add(tmpPerson);
                        }

                        hasPerson = true;
                    }
                }

                for (int j = 0; j < tmpPersonList.Count; j++)
                {

                    if (commandList[i].Contains("Siblings"))
                    {
                        //Print.PrMsg("Assigning siblings for person " + j + 1 + ", Name: " + tmpPersonList[j].Name);

                        int tmpCount = Convert.ToInt32(commandList[i].Substring(commandList[i].IndexOf('*') + 1));

                        tmpPersonList[j].AssignSibling(tmpCount);
                    }

                    if (commandList[i].Contains("Partner"))
                    {
                        //Print.PrMsg("Assigning partner for person " + j + 1 + ", Name: " + tmpPersonList[j].Name);

                        if (Input.YesOrNo("Do you want to pick a partner? (Yes/No)"))
                        {
                            Person pickedPartner = Input.PickPerson("Pick a partner for" + tmpPersonList[j].Name);

                            tmpPersonList[j].AssignPartner(tmpPersonList[j].Id, pickedPartner);
                        }
                        else
                        {
                            tmpPersonList[j].AssignPartner(tmpPersonList[j].Id);
                        }

                    }

                    if (commandList[i].Contains("Children"))
                    {
                        //Print.PrMsg("Assigning children for person " + j + 1 + ", Name: " + tmpPersonList[j].Name);

                        int tmpCount = Convert.ToInt32(commandList[i].Substring(commandList[i].IndexOf('*') + 1));

                        tmpPersonList[j].AssignChild(tmpCount);
                    }

                    if (commandList[i].Contains("Parents") && hasPerson)
                    {
                        //Print.PrMsg("Assigning parents for person " + j+1 + ", Name: "+ tmpPersonList[j].Name);
                        tmpPersonList[j].AssignParents();
                    }

                }

                if (tmpPersonList.Count == 0)
                {
                    Print.PrMsg("You did not add any people prior to assigning other family members, did you mean to use 'Add'?");
                }

            }
        }
    }
}
