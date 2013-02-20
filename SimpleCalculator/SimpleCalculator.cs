using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class SimpleCalculator
    {
        private char[] seperators = new char[] {',', '\n'};

        public int Add(string calculation)
        {

            if (seperators.Count(c => calculation.IndexOf(c) >= 0) == 0)
            {
                return SafeParseInt(calculation);
            }
            else
            {
                string[] split = calculation.Split(seperators);
                if(split.Count(m => m.Trim().Length == 0) > 0)
                    throw new Exception("Life sux");
                else
                    return split.Sum(m => SafeParseInt(m));
            }
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
