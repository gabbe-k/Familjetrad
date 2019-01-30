using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Print
    {
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
                Console.WriteLine();
                CenterText("Number " + Convert.ToString(i+1));
                CenterText("--------------");
                CenterText(printList[i].Name);
                CenterText(printList[i].Surname);
                CenterText(Convert.ToString(printList[i].Id));
                CenterText(Convert.ToString(printList[i].Birthyear));
                CenterText(Convert.ToString(printList[i].PartnerId));
                CenterText(Convert.ToString(printList[i].ParentId[0]));
                CenterText(Convert.ToString(printList[i].ParentId[1]));
                CenterText("--------------");
                Console.WriteLine();
            }

        }

        private static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

    }
}
