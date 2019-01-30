using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Familjeträd.Input;

namespace Familjeträd
{
    class PersonDB
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

        public static bool CheckPartner(int partnerId)
        {
            for (int i = 0; i < personList.Count; i++)
            {
                if (partnerId == personList[i].PartnerId)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckDupe(int id)
        {
            for (int i = 0; i < personList.Count; i++)
            {
                if (id == personList[i].Id)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Person> filterDb(string valuesNeeded, string peopleNeeded)
        {
            return null;
        }

    }
}
