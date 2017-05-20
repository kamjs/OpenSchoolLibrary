using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Controllers;
using OpenSchoolLibrary.Models.BooksViewModels;
using System.Web.Mvc;
using OpenSchoolLibrary.Tests.Stubs;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class Return_Error_When_Adding_A_New_Book_With
    {
        private AddNewBookController addNewBookController = new AddNewBookController(new StubGenreList(), new Domain.Validations.BookValidations(new StubCheckForExistingISBN()), new StubBookSaver());
        private string isbnThatExistsAlready = "0198526636";

        [Fact]
        public async Task Missing_A_Title()
        {
            var book = new BookCreationCommand()
            {
                Title = "",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "1885167776",
                ISBN13 = "9781885167774",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };

            ViewResult saveBook = await AddNewBook(book);

            AssertIsViewResult(saveBook);

            var model = GetErrorsList(saveBook);

            Assert.True(model.Contains("Title is missing."));
        }

        [Fact]
        public async Task Missing_An_Author()
        {
            var book = new BookCreationCommand()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "",
                ISBN = "1885167776",
                ISBN13 = "9781885167774",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };

            ViewResult saveBook = await AddNewBook(book);

            AssertIsViewResult(saveBook);

            var model = GetErrorsList(saveBook);

            Assert.True(model.Contains("Author is missing."));
        }

        [Fact]
        public async Task Invalid_ISBN()
        {
            var book = new BookCreationCommand()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "0671020034",
                ISBN13 = "9780671027032",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };

            ViewResult saveBook = await AddNewBook(book);

            AssertIsViewResult(saveBook);

            var model = GetErrorsList(saveBook);

            Assert.True(model.Contains("ISBN 10 is not valid."));
        }

        [Fact]
        public async Task Invalid_ISBN13()
        {
            var book = new BookCreationCommand()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "0671027034",
                ISBN13 = "9780071027032",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };

            ViewResult saveBook = await AddNewBook(book);

            AssertIsViewResult(saveBook);

            var model = GetErrorsList(saveBook);

            Assert.True(model.Contains("ISBN 13 is not valid."));
        }

        [Fact]
        public async Task An_ISBN_That_Already_Exists_In_The_System()
        {
            var stubIsbns = new StubCheckForExistingISBN();
            stubIsbns.ExistingIsbns.Add(isbnThatExistsAlready);

            var book = new BookCreationCommand()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = isbnThatExistsAlready,
                ISBN13 = "9783161484100",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };

            ViewResult saveBook = await AddNewBook(book);

            AssertIsViewResult(saveBook);

            var model = GetErrorsList(saveBook);

            Assert.True(model.Contains("ISBN already exists."));
        }

        private async Task<ViewResult> AddNewBook(BookCreationCommand book)
        {
            return await addNewBookController.AddNewBook(book) as ViewResult;
        }

        private static void AssertIsViewResult(ViewResult saveBook)
        {
            Assert.True(saveBook != null);
        }

        private static IEnumerable<string> GetErrorsList(ViewResult saveBook)
        {
            var model = saveBook.Model as AddNewBookViewModel;
            return model.Errors;
        }
    }
}
