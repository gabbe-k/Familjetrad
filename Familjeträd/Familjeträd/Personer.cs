using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Person
    {
        public readonly string Name;
        public readonly string Surname;
        private int id;
        public readonly int Birthyear;
        public readonly bool Sex;
        private int[] childId;
        private int[] parentId;
        private int partnerId;

        public Person(string name, string surname, int birthyear, bool sex)
        {
            Name = name;
            Surname = surname;
            Birthyear = birthyear;
            Sex = sex;
        }

        public void AssignChild(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Person child = Generate.GenChildPerson(("Input the details for the child of " + Name), Surname, Birthyear);

                PersonDB.Add(child);
            }

        }

        static void AssignSibling(int count)
        {

        }

        static void AssignPartner()
        {

        }


    }
}
