using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Familjeträd
{
    class Validator
    {
        public static bool AllStringValid(string[] input)
        {
            bool valid = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Any(char.IsDigit))
                {
                    if (Regex.Replace(input[i], "[^0-9]", "") == input[i])
                    {
                        valid = true;
                    }

                }
                else
                {
                    if (Regex.Replace(input[i], "[^A-z]", "") == input[i])
                    {
                        valid = true;
                    }
                }
            }

            return valid;
        }
    }
}
