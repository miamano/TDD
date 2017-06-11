using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
                return sum;

            char[] delimiters; 
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Remove(0, 2);
                var delimitersRow = numbers.Split('\n');
                delimitersRow[0] = delimitersRow[0].Insert(0, "\n");
                delimiters = delimitersRow[0].ToCharArray();
            }
            else
            {
               delimiters = new char[]{ ',', '\n' };
            }
             
            var splitNumbers = numbers.Split(delimiters);

            foreach (var strNbr in splitNumbers)
            {
                if (string.IsNullOrEmpty(strNbr))
                    continue;
                else
                { 
                    int nbr = Convert.ToInt32(strNbr);
                    if (nbr < 0)
                        throw new NegativeNumbersNotAllowedException("Negatives not allowed");
                    else if (nbr > 1000)
                        continue;
                    else
                        sum += nbr;
                }
            }
            return sum;
        }
    }
}

//if (splitNumbers.Length == 1)
//    return Convert.ToInt32(splitNumbers[0]);
//else
//    return Convert.ToInt32(splitNumbers[0]) + Convert.ToInt32(splitNumbers[1]);

//sum += Convert.ToInt32(strNbr);