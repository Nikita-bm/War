using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Extensions
{
    public static class IntegerExtensions
    {
        public static int RoundNumbertotheRight(this int number)
        {
            if (number % 2 == 0)
                return number ;

            return number  + 1;
        }
    }
}
