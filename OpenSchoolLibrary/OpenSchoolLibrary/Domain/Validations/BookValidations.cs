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

            return errorMessage = String.Empty;
        }

        private bool TitleIsValid(AddNewBookPostViewModel book) => book.Title != "";
    }
}