using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Familjeträd.Input;

namespace Familjeträd
{
    /// <summary>
    /// Contains a list of all people and has functions related to the database
    /// </summary>
    class PersonDB
    {
        public static List<Person> personList = new List<Person>();

        public static void Add(Person person)
        {
            personList.Add(person);
        }

        /*static void CheckParent(int[] parentId)
        {

        }

        static void CheckSiblings(int[] parentId)
        {

        }*/





        /// <summary>
        /// Gets name of person from an id of a person
        /// </summary>
        /// <param name="Id">Id of the person</param>
        /// <returns>Name of the person</returns>
        public static string GetName(int Id)
        {
            string returnName = "No person assigned";

            for (int i = 0; i < personList.Count; i++)
            {
                if (Id == personList[i].Id)
                {
                    returnName = personList[i].Name + " " + personList[i].Surname;
                    
                }
            }

            return returnName;
        }




        /// <summary>
        /// Checks if the person has a partner
        /// </summary>
        /// <param name="partnerId">Id of partner</param>
        /// <returns>True if the person has partner</returns>
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




        /// <summary>
        /// Checks if an id is used
        /// </summary>
        /// <param name="id">Id that is checked</param>
        /// <returns>True if id is dupe</returns>
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




        /// <summary>
        /// Work in progress function for filtering database
        /// </summary>
        /// <param name="valuesNeeded"></param>
        /// <param name="peopleNeeded"></param>
        /// <returns></returns>
        public static List<Person> filterDb(string valuesNeeded, string peopleNeeded)
        {
            return null;
        }

    }
}
