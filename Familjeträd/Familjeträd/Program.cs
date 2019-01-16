using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Initial Person


            Input.RequestAction();

            for (int i = 0; i < PersonDB.personList.Count; i++)
            {
                Console.WriteLine(PersonDB.personList[i].name);
                Console.WriteLine(PersonDB.personList[i].surname);
                Console.WriteLine(PersonDB.personList[i].birthyear);
                Console.WriteLine(PersonDB.personList[i].sex);
            }

            //Add.Children(2)
            //Add.Parents
            //Add.Siblings
            //Create.Person
            //Create.Parents.Child(2).Siblings(2).Parents(2)
            //Create.


            Console.ReadLine();
        }
    }
}
