using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    internal class Telephoto
    {
        public static double CalculateExposureValue(string expString)
        {
            double value = 0.0;
            // Deal with Integers
            if (!expString.Contains("/"))
            {
                value = Double.Parse(expString);
            }
            else
            { 
                var fraction = expString.Split('/');
                value = (Double)1 / int.Parse(fraction[1]);
            }

            return value;
        }

    }
}
