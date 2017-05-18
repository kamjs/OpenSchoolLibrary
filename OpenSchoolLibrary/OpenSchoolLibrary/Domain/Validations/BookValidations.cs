﻿using OpenSchoolLibrary.Models.BooksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain.Validations
{
    public class BookValidations
    {
        readonly ICheckForExistingISBN checkForISBN;

        public BookValidations(ICheckForExistingISBN checkforISBN)
        {
            this.checkForISBN = checkforISBN;
        }

        public async System.Threading.Tasks.Task<IEnumerable<string>> ValidateBook(AddNewBookPostViewModel book)
        {
            var errors = new List<string>();

            if (!TitleIsValid(book))
                errors.Add("Title is missing.");

            if (!AuthorIsValid(book))
                errors.Add("Title is missing.");

            if (await checkForISBN.Exists(book.ISBN, book.ISBN13))
                errors.Add("ISBN already exists.");

            if (!ISBNValidation.ValidateISBN10(book.ISBN))
                errors.Add("ISBN 10 is not valid.");

            if (!ISBNValidation.ValidateISBN13(book.ISBN13))
                errors.Add("ISBN 13 is not valid.");

            return errors;
        }

        private bool TitleIsValid(AddNewBookPostViewModel book) => String.IsNullOrWhiteSpace(book.Title);

        private bool AuthorIsValid(AddNewBookPostViewModel book) => String.IsNullOrWhiteSpace(book.Author);


    }
}