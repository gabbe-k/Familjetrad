using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Initial Person

            string personName = Input.RequestString("Please input the name, surname, birthyear and sex of the first person separated with ',' ");


            Console.WriteLine(personName);

            Console.ReadLine();
        }
    }
}
