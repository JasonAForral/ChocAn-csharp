using System;
using System.Collections.Generic;
using System.Text;

namespace ChocAn.IOAuth
{
    public class IOAuthentication
    {
        public bool IsCurrency(string candidate, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(candidate))
            {
                throw new ArgumentException("Missing candidate", nameof(candidate));
            }

            if (candidate.Length > maxLength)
                return false;

            if (double.TryParse(candidate, out double result))
            {
                double upperBound = Math.Pow(10, maxLength - 3);
                return result >= 0 && result < upperBound;

                throw new NotImplementedException("Not fully implemented.");
            }

            return false;
        }
    }
}
