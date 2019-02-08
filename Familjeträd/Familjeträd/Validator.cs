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





        public static List<string>[] SyntaxValidator(string inputFull)
        {
            //Removes whitespace
            inputFull = Regex.Replace(inputFull, @"\s+", "");
            string[] inputLines = inputFull.Split('&');

            List<string>[] outList = new List<string>[inputLines.Length];
            for (int i = 0; i < outList.Length; i++)
            {
                outList[i] = new List<string>();
            }

            bool validList = true;

            for (var k = 0; k < inputLines.Length; k++)
            {
                var input = inputLines[k];

                if (input == "printdb")
                {
                    Print.PrDb();
                }
                else if (input.IndexOf(';') == input.Length - 1 && (!string.IsNullOrEmpty(input) || Regex.Replace(input, "[^0-9A-z.()]", "") == input))
                {
                    string[] inputArr = input.Split('.');

                    if (Regex.IsMatch(inputArr[0], "Add|Create"))
                    {
                        outList[k].Add(inputArr[0]);
                        bool hasPerson = false;

                        for (int i = 1; i < inputArr.Length; i++)
                        {
                            string validPrefix =
                                "Children[(][0-9]+[)]|Siblings[(][0-9]+[)]|Person[(][0-9]+[)]|Person[(][A-z]+[,][A-z]+[,][0-9]+[,](Male|Female|male|female)[)]";

                            if (Regex.IsMatch(inputArr[i], "Parents|Partner") && !inputArr[i].Contains('(') &&
                                !inputArr[i].Contains(')'))
                            {
                                outList[k].Add(inputArr[i]);
                            }
                            else if (Regex.IsMatch(inputArr[i], validPrefix))
                            {
                                Console.WriteLine(inputArr[i]);

                                if ((i == inputArr.Length - 1 && Validator.HasKnownChars(inputArr[i], "0-9A-z();,") ||
                                     (i < inputArr.Length && Validator.HasKnownChars(inputArr[i], "0-9A-z(),"))))
                                {
                                    string tmp = inputArr[i].Substring(inputArr[i].IndexOf('(') + 1,
                                        inputArr[i].IndexOf(')') - 1 - inputArr[i].IndexOf('('));

                                    if (inputArr[i].Contains("Person"))
                                    {
                                        if (hasPerson)
                                        {
                                            validList = false;
                                            Print.PrMsg(
                                                "Separate 2 lines with '&'. You can not use more than one Person() command in a line");
                                        }
                                        else
                                        {
                                            hasPerson = true;
                                        }
                                    }

                                    if (Validator.HasKnownChars(tmp, "0-9"))
                                    {
                                        string prefix = inputArr[i].Substring(0, inputArr[i].IndexOf('('));

                                        if (prefix == "Person" && inputArr[0] == "Add")
                                        {
                                            Print.PrMsg("Syntax error: Cannot 'Add' 'Person' to another 'Person'");

                                            validList = false;
                                        }
                                        else
                                        {
                                            outList[k].Add(prefix + "*" + tmp);
                                        }
                                    }
                                    else if (Validator.HasKnownChars(tmp, "[A-z]+[,][A-z]+[,][0-9]+[,](Male|Female)") &&
                                             inputArr[0] == "Create")
                                    {
                                        outList[k].AddRange(PersonSyntaxValidator(tmp, "PersonStruct"));
                                    }
                                    else
                                    {
                                        Print.PrMsg("Syntax error: Cannot 'Add' 'Person' to another 'Person'");

                                        validList = false;
                                    }
                                }
                                else
                                {
                                    Print.PrMsg("Unknown characters detected, write !help for help");

                                    validList = false;
                                }
                            }
                            else
                            {
                                Print.PrMsg(
                                    "Please use a valid operation prefix: Parents, Partner, Children(0-9), Siblings(0-9), Person(0-9), Person(name, surname, birthyear, 'Male' / 'Female')",
                                    "You used: " + inputArr[i]);

                                validList = false;
                            }
                        }
                    }
                    else
                    {
                        Print.PrMsg("Please start line with 'Add' or 'Create' (Case sensitive)");

                        validList = false;
                    }
                }
                else if (!input.Contains(';'))
                {
                    Print.PrMsg("Please end the line with a ';'");

                    validList = false;
                }
                else
                {
                    Print.PrMsg("Unknown characters detected, write !help for help");

                    validList = false;
                }

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
