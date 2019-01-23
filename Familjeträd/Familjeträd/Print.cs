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
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            foreach (var t in input)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
        }

        public static void PrDb()
        {
            List<Person> printList = PersonDB.personList;
            int rowCount = 10;
            int colCount = 10;

            for (int j = 0; j < rowCount; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (j == 0)
                    {
                        switch (i)
                        {
                            case 0:
                                Console.Write("|Name     ");
                                break;
                            case 1:
                                Console.Write("|Surname  ");
                                break;
                            case 2:
                                Console.Write("|Birthday ");
                                break;
                            case 3:
                                Console.Write("|Id ");
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                Console.Write("|DataName     ");
                                break;
                            case 1:
                                Console.Write("|DataSurname  ");
                                break;
                            case 2:
                                Console.Write("|DataBirthday ");
                                break;
                            case 3:
                                Console.Write("|DataId ");
                                break;
                        }
                    }

                }

                Console.WriteLine();
            }

        }
    }
}
