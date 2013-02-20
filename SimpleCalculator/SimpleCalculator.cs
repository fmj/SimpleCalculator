using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class SimpleCalculator
    {
        private List<string> seperators = new List<string>() { ",", "\n" };

        private const string CDefSeperator = "//";

        private string NormalizeInput(string calculation)
        {
            //noramlize input
            if (calculation.StartsWith("//"))
            {
                //"//test\n1test2test3"
                string newSep = calculation.Substring(CDefSeperator.Length,
                                                      calculation.IndexOf('\n') - CDefSeperator.Length);
                if (newSep.Contains("]["))
                {
                    string[] newSeps =
                        newSep.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' }).Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                    seperators.AddRange(newSeps.ToList());
                }
                else
                    seperators.Add(newSep);
                calculation = calculation.Substring(calculation.IndexOf('\n') + 1);
            }
            return calculation;
        }

        public int Add(string calculation)
        {
            calculation = NormalizeInput(calculation);
            //do calculation
            if (seperators.Count(c => calculation.IndexOf(c) >= 0) == 0)
            {
                return SafeParseInt(calculation);
            }
            else
            {

                string[] split = calculation.Split(seperators.ToArray(), StringSplitOptions.None);
                if (split.Count(m => m.Trim().Length == 0) > 0)
                    throw new Exception("Life sux");
                else if (split.Count(m => SafeParseInt(m) < 0) > 0)
                {
                    throw new Exception("Negative numbers detected, danger danger. The numbers are: " +
                                        split.Where(m => SafeParseInt(m) < 0)
                                             .Aggregate((current, result) => current + "," + result));
                                        //ReturnElems());
                }
                else
                    return split.Where(m => SafeParseInt(m) <= 1000).Sum(m => SafeParseInt(m));
            }

        }

        public string ReturnElems(List<string> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array) sb.Append(s);
            return sb.ToString();
        }


        private int SafeParseInt(string input)
        {
            int value;

            if (int.TryParse(input, out value))
            {
                return value;
            }
            return 0;
        }
    }
}
