using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    /// <summary>
    /// Saves and loads commands
    /// </summary>
    class ReadWrite
    {
        public static List<List<string>> mainList = new List<List<string>>();
        private static string dir = @"C:\save.txt";

        public static void SaveLine(List<string> commandList)
        {
            mainList.Add(commandList);
        }

        public static void SaveSession()
        {
            if (mainList.Count == 0)
            {
                Print.PrMsg("Session empty");   
            }
            else
            {
                List<string> tmpList = new List<string>();

                for (int i = 0; i < mainList.Count; i++)
                {
                    for (int j = 0; j < mainList[i].Count; j++)
                    {
                        tmpList.Add(mainList[i][j]);
                    }

                    tmpList.Add("&");

                }

                File.WriteAllLines(dir, tmpList);
            }

        }

        public static void LoadSession()
        {
            Console.Clear();

            string[] fullList = File.ReadAllLines(dir);
            int listCount = 0;
            mainList = new List<List<string>>();
            List<string> tmpList = new List<string>();

            for (int i = 0; i < fullList.Length; i++)
            {

                if (fullList[i] == "&")
                {
                    mainList.Add(tmpList);
                    tmpList = new List<string>();
                    i++;
                }
                else
                {
                    tmpList.Add(fullList[i]);
                }

            }

            Print.PrMsg("Commands executed:");

            foreach (var t in mainList)
            {
                foreach (var s in t)
                {
                    Console.WriteLine(s);
                }

                Print.PrMsg("New command");

                Compiler.CompileRequest(t);
            }

        }

    }
}
