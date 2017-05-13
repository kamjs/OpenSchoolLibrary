using OpenSchoolLibrary.Models.BooksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain.Validations
{
    public class BookValidations
    {
        private string errorMessage;

        public string ValidateBook(AddNewBookPostViewModel book)
        {
            if (!TitleIsValid(book))
                return errorMessage = "Title is missing.";

            if (!AuthorIsValid(book))
                return errorMessage = "Title is missing.";

            if (book.ISBN !="" && !ISBNValidation.ValidateISBN10(book.ISBN))
                return errorMessage = "ISBN 10 is not valid.";

            if (book.ISBN13 != "" && !ISBNValidation.ValidateISBN13(book.ISBN13))
                return errorMessage = "ISBN 13 is not valid.";

            return errorMessage = String.Empty;
        }

        private bool TitleIsValid(AddNewBookPostViewModel book) => book.Title != "";

        private bool AuthorIsValid(AddNewBookPostViewModel book) => book.Author != "";

        
    }
}