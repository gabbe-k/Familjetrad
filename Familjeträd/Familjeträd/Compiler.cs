using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Compiler
    {
        public static List<int> CompileRequest(List<string> commandList)
        {

            //system där alla platser i listan = 0 om inte högre, där varje plats representerar en call av en funktion
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

                        if (commandList[i + 3] == "Male")
                        {
                            sex = false;
                        }
                        else
                        {
                            sex = true;
                        }

                        PersonDB.Add(new Person(commandList[i], commandList[i + 1], Convert.ToInt32(commandList[i + 2]), sex));
                    }
                    else
                    {

                    }
                }

            }
        }
    }
}
