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


            Person gab = new Person("gab", "kal", 2000, false);

            gab.AssignChild(2);

            for (int i = 0; i < PersonDB.personList.Count; i++)
            {
                Console.WriteLine(PersonDB.personList[i].Name);
                Console.WriteLine(PersonDB.personList[i].Surname);
                Console.WriteLine(PersonDB.personList[i].Birthyear);
                Console.WriteLine(PersonDB.personList[i].Sex);
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
