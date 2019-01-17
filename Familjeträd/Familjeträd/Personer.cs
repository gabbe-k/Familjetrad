using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Person
    {
        public readonly string name;
        public readonly string surname;
        private int id;
        public readonly int birthyear;
        public readonly bool sex;
        private int[] childId;
        private int[] parentId;
        private int partnerId;

        public Person(string name, string surname, int birthyear, bool sex)
        {
            this.name = name;
            this.surname = surname;
            this.birthyear = birthyear;
            this.sex = sex;
        }

        static void AssignChild(int count)
        {

        }

        static void AssignSibling(int count)
        {

        }

        static void AssignPartner()
        {

        }


    }
}
