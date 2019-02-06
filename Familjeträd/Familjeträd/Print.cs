using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Print
    {
        public static void PrintBox(Person person, int number)
        {
            Console.WriteLine();
            CenterText("Number " + Convert.ToString(number + 1));
            CenterText("--------------");
            CenterText(person.Name);
            CenterText(person.Surname);
            CenterText(Convert.ToString(person.Id));
            CenterText(Convert.ToString(person.Birthyear));
            CenterText(Convert.ToString(person.PartnerId));
            CenterText(Convert.ToString(person.ParentId[0]));
            CenterText(Convert.ToString(person.ParentId[1]));
            for (int j = 0; j < person.SiblingIdList.Count; j++)
            {
                CenterText("Sibling" + j + ": " + Convert.ToString(person.SiblingIdList[j]));
            }
            CenterText("--------------");
            Console.WriteLine();
        }

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

        public static void PrDb()
        {
            List<Person> printList = PersonDB.personList;

            CenterText("Every person in the database");

            for (int i = 0; i < printList.Count; i++)
            {
                PrintBox(printList[i], i);
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

        private static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

    }
}
