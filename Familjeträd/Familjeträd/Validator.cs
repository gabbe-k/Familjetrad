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
        public static List<string> PersonSyntaxValidator(string input, string Prefix)
        {
            //Removes whitespace
            input = Regex.Replace(input, @"\s+", "");

            List<string> outList = new List<string>();

            if (Regex.IsMatch(input, "[A-z]+[,][A-z]+[,][0-9]+[,](Male|Female)"))
            {
                string[] inputArr = input.Split(',');

                outList.Add(Prefix);

                for (int i = 0; i < inputArr.Length; i++)
                {
                    outList.Add(inputArr[i]);
                }

                return outList;
            }
            else
            {
                return outList = null;
            }
        }





        public static List<string> SyntaxValidator(string input)
        {
            //Removes whitespace
            input = Regex.Replace(input, @"\s+", "");

            List<string> outList = new List<string>();
            bool validList = true;

            if (input.IndexOf(';') == input.Length - 1 && (!string.IsNullOrEmpty(input) || Regex.Replace(input, "[^0-9A-z.()]", "") == input))
            {

                string[] inputArr = input.Split('.');

                if (Regex.IsMatch(inputArr[0], "Add|Create"))
                {
                    outList.Add(inputArr[0]);

                    for (int i = 1; i < inputArr.Length; i++)
                    {

                        string validPrefix = "Children[(][0-9][)]|Siblings[(][0-9][)]|Person[(][0-9][)]|Person[(][A-z]+[,][A-z]+[,][0-9]+[,](Male|Female)[)]";

                        if (Regex.IsMatch(inputArr[i], "Parents|Partner") && !inputArr[i].Contains('(') && !inputArr[i].Contains(')'))
                        {
                            outList.Add(inputArr[i]);
                        }
                        else if (Regex.IsMatch(inputArr[i], validPrefix))
                        {
                            Console.WriteLine(inputArr[i]);

                            if ((i == inputArr.Length - 1 && Validator.HasKnownChars(inputArr[i], "0-9A-z();,") || (i < inputArr.Length && Validator.HasKnownChars(inputArr[i], "0-9A-z(),"))))
                            {
                                string tmp = inputArr[i].Substring(inputArr[i].IndexOf('(') + 1, inputArr[i].IndexOf(')') - 1 - inputArr[i].IndexOf('('));

                                if (Validator.HasKnownChars(tmp, "0-9"))
                                {
                                    string prefix = inputArr[i].Substring(0, inputArr[i].IndexOf('('));

                                    if (prefix == "Person" && inputArr[0] == "Add")
                                    {
                                        Console.WriteLine("Syntax error: Cannot 'Add' 'Person' to another 'Person");

                                        validList = false;
                                    }
                                    else
                                    {
                                        outList.Add(prefix + "*" + tmp);
                                    }

                                }
                                else if(Validator.HasKnownChars(tmp, "[A-z]+[,][A-z]+[,][0-9]+[,](Male|Female)") && inputArr[0] == "Create")
                                {
                                    outList.AddRange(PersonSyntaxValidator(tmp ,"PersonStruct"));
                                }
                                else
                                {
                                    Console.WriteLine("Syntax error: Cannot 'Add' 'Person' to another 'Person");

                                    validList = false;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Unknown characters detected, write !help for help");

                                validList = false;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Please use a valid operation prefix: Parents, Partner, Children(0-9), Siblings(0-9), Person(0-9), Person(name, surname, birthyear, 'Male' / 'Female')");
                            Console.WriteLine("You used: " + inputArr[i]);

                            validList = false;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Please start line with 'Add' or 'Create' (Case sensitive)");

                    validList = false;
                }

            }
            else if (!input.Contains(';'))
            {
                Console.WriteLine("Please end the line with a ;");

                validList = false;
            }
            else
            {
                Console.WriteLine("Unknown characters detected, write !help for help");

                validList = false;
            }

            if (validList)
            {
                return outList;
            }
            else
            {
                return outList = null;
            }

        }





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





        public static bool HasKnownChars(string input, string knownChars)
        {
            if (Regex.Replace(input, "[^" + knownChars+ "]", "") == input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
