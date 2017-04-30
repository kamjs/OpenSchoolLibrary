using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain.Validations
{
    public class ISBNValidation
    {
        public static bool ValidateISBN10(string isbn)
        {
            if (String.IsNullOrEmpty(isbn) ||
                isbn.Contains("-") ||
                isbn.Contains(" ") ||
                isbn.Length < 10)
                return false;

            isbn = isbn.Replace("X", "10");

            int[] sequence = isbn.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            var sum = sequence[0] * 10 + sequence[1] * 9 + sequence[2] * 8 +
                sequence[3] * 7 + sequence[4] * 6 + sequence[5] * 5 +
                sequence[6] * 4 + sequence[7] * 3 + sequence[8] * 2;

            int remainder = sum % 11;

            int checkdigit = 11 - remainder;

            if(sequence.Length == 11)
            {
                if (checkdigit == 10)
                    return true;
            }


            if (sequence[9] == checkdigit)
                return true;
            

            return false;
        }
    }
}