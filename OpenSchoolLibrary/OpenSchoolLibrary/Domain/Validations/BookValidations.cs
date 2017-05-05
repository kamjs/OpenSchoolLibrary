using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain.Validations
{
    public class BookValidations
    {
        private static LibraryContext db = new LibraryContext();

        public static bool BookAlreadyExists(string isbn, string isbn13)
        {
            var isISBNValid = CheckForExistingISBN(isbn);
            var isISBN13Valid = CheckForExistingISBN13(isbn13);

            if (isISBNValid || isISBN13Valid)
                return true;

            return false;
        }

        private static bool CheckForExistingISBN(string isbn) => db.Books.Any(b => b.ISBN == isbn);

        private static bool CheckForExistingISBN13(string isbn13) => db.Books.Any(b => b.ISBN13 == isbn13);
    }
}