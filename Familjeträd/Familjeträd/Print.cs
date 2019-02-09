using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    /// <summary>
    /// Prints info 
    /// </summary>
    class Print
    {
        /// <summary>
        /// Prints a box of text containing information about a person
        /// </summary>
        /// <param name="person">Contains an instance of the class 'Person', is used to fetch information about the current person</param>
        /// <param name="number">Represents the number of the person needed to be written for a selection</param>
        public static void PrintBox(Person person, int number)
        {
            Console.WriteLine();
            CenterText("Number " + Convert.ToString(number + 1));
            CenterText("--------------");
            CenterText(person.Name);
            CenterText(person.Surname);
            CenterText("Id: " + Convert.ToString(person.Id));
            CenterText("Birthyear: " + Convert.ToString(person.Birthyear));
            if (person.Sex == true)
            {
                CenterText("Sex: Female");
            }
            else
            {
                CenterText("Sex: Male");
            }

            CenterText("Partner: " + PersonDB.GetName(person.PartnerId));
            CenterText("Parent 1: " + PersonDB.GetName(person.ParentId[0]));
            CenterText("Parent 2: " + PersonDB.GetName(person.ParentId[1]));
            for (int j = 0; j < person.SiblingIdList.Count; j++)
            {
                CenterText("Sibling" + j + ": " + PersonDB.GetName(person.SiblingIdList[j]));
            }
            CenterText("--------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a message contained within 2 lines of '------'
        /// </summary>
        /// <param name="input">The message to be printed</param>
        public static void PrMsg(params string[] input)
        {
            Console.WriteLine();
            CenterText("--------------------------------------------------------------");
            foreach (var t in input)
            {
                CenterText(t);
            }
            CenterText("--------------------------------------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the entire database of people
        /// </summary>
        /// <param name="parentMatch">Id of parent if you want to print out a family</param>
        /// <param name="partnerMatch">Id of partner if you want to print out the partner</param>
        public static void PrDb(int parentMatch = -1, int partnerMatch = -1)
        {
            List<Person> printList = PersonDB.personList;

            if (parentMatch != -1)
            {
                for (int i = 0; i < printList.Count; i++)
                {
                    if (parentMatch == printList[i].ParentId[0] || parentMatch == printList[i].ParentId[1] || printList[i].Id == parentMatch)
                    {
                        PrintBox(printList[i], i);
                    }
                }
            }
            else if(partnerMatch != -1)
            {
                for (int i = 0; i < printList.Count; i++)
                {
                    if (printList[i].Id == partnerMatch)
                    {
                        PrintBox(printList[i], i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Everyone in database");

                for (int i = 0; i < printList.Count; i++)
                {
                    PrintBox(printList[i], i);
                }

            }

        }

   /*     public static void PrCol()
        {
            int X = 0;
            int Y = 0;

            for (int y = 0; y < 10; y++)
            {

                for (int x = 0; x < 10; x++)
                {
                    Console.Write('*');
                }

                for (int x = 0; x < 5; x++)
                {
                    Console.Write(' ');
                }

                if (y == 9)
                {
                    Y += 20;
                    Console.SetCursorPosition(0, Y);
                    y = 0;
                }

                Console.WriteLine();
            }
        } */

       /// <summary>
       /// Prints a text in the console, but centered
       /// </summary>
       /// <param name="text">The message to be printed</param>
        private static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

    }
}
