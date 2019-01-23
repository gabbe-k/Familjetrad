using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Compiler
    {
        public static void CompileRequest(List<string> commandList)
        {

            //system där alla platser i listan = 0 om inte högre, där varje plats representerar en call av en funktion
            List<Person> tmpPersonList = new List<Person>();
            bool hasPerson = false;
            bool hasPartner = false;

            for (int i = 0; i < commandList.Count; i++)
            {

                if (commandList[0] == "Add")
                {

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
                            Person tmpPerson =  Generate.GenPerson("Type in the details for person #" + j);
                            tmpPersonList.Add(tmpPerson);
                            PersonDB.Add(tmpPerson);
                        }

                        hasPerson = true;
                    }

                    if(commandList[i].Contains("Siblings"))
                    {
                        int tmpCount = Convert.ToInt32(commandList[i].Substring(commandList[i].IndexOf('*') + 1));

                        Console.WriteLine(tmpPersonList.Count);

                        for (int j = 0; j < tmpPersonList.Count; j++)
                        {
                            Console.WriteLine("IN HER");
                            tmpPersonList[j].AssignSibling(tmpCount);
                        }
                    }

                    if (commandList[i].Contains("Partner"))
                    {
                        tmpPersonList[0].AssignPartner(tmpPersonList[0], false);

                        hasPartner = true;
                    }

                    if (commandList[i].Contains("Children") && hasPartner)
                    {
                        int tmpCount = Convert.ToInt32(commandList[i].Substring(commandList[i].IndexOf('*') + 1));

                        for (int j = 0; j < tmpPersonList.Count; j++)
                        {
                            tmpPersonList[j].AssignChild(tmpCount);
                        }
                    }

                    if (commandList[i].Contains("Parents") && hasPerson)
                    {
                        tmpPersonList[0].AssignParents();
                    }


                }

            }
        }
    }
}
