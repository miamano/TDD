using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegativeNumbersNotAllowedException : Exception
    {
        public NegativeNumbersNotAllowedException(string message) : base(message)
        { }
    }
}
