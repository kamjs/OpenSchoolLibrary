﻿using OpenSchoolLibrary.Domain;
using OpenSchoolLibrary.Domain.Validations;
using OpenSchoolLibrary.Models.BooksViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Controllers
{
    public class AddNewBookController: Controller
    {
        readonly IGetGenreList genreList;
        readonly ISaveBook saveBook;
        readonly BookValidations validateBook;

        public AddNewBookController(IGetGenreList genreList, BookValidations validateBook, ISaveBook saveBook)
        {
            this.genreList = genreList;
            this.validateBook = validateBook;
            this.saveBook = saveBook;
        }

        public AddNewBookController() : this( 
            new GetGenreList( new LibraryContext() ),
            new BookValidations( new CheckForExistingIsbnInDb(new LibraryContext())),
            new SaveBook( new LibraryContext() )
            ) { }

        public enum BookConditions
        {
            Excellent,
            Good,
            Fair,
            Used,
            Bad
        }

        [HttpGet, Route("books/addnewbook")]
        public async Task<ViewResult> AddNewBook(string isbn, string isbn13)
        {
            var model = new AddNewBookViewModel()
            {
                Genres = await genreList.GenreList().ToListAsync(),
                Conditions = Enum.GetValues(typeof(BookConditions)).OfType<BookConditions>().ToList(),
                ISBN = isbn,
                ISBN13 = isbn13
            };

            return View("~/Views/Books/AddNewBook.cshtml", model);
        }

        [HttpPost, Route("books/addnewbook")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewBook(BookCreationCommand book)
        {
            var model = new AddNewBookViewModel();

            model.Errors = await validateBook.ValidateBook(book);

            if (model.Errors.Any())
            {
                return View("~/Views/Books/AddNewBook.cshtml", model);
            }
            else
            {
                /*
                 TODO: Genres should be await .ToListAsync() but
                 it's causing issues in the When_adding_a_new_book
                 test class. This comment is only here as a "bookmark"
                 at the end of the night. If you see it in the project
                 feel free to let me know.
                 */

                model.Genres = genreList.GenreList();
                model.Conditions = Enum.GetValues(typeof(BookConditions)).OfType<BookConditions>().ToList();
                model.ISBN = book.ISBN;
                model.ISBN13 = book.ISBN13;

                var bookId = await saveBook.Create(book);

                return Redirect($"/book/details/{bookId}");
            }
        }
    }
}