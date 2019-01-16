using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    static class PersonDB
    {
        public static List<Person> personList = new List<Person>();

        public static void Add(Person person)
        {
            personList.Add(person);
        }

        static void CheckParent(int[] parentId)
        {

        }

        static void CheckSiblings(int[] parentId)
        {

        }

    }
}
