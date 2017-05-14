using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Controllers;
using OpenSchoolLibrary.Models.BooksViewModels;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class Return_Error_When_Adding_A_New_Book_With
    {
        //Valid ISBN 1885167776
        //Valid ISBN13 9781885167774

        [Fact]
        public void Missing_A_Title()
        {
            var book = new AddNewBookPostViewModel()
            { 
                Title = "",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "1885167776",
                ISBN13 = "9781885167774",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() {1,2,3 }
            };
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);
        }

        [Fact]
        public void Missing_An_Author()
        {
            var book = new AddNewBookPostViewModel()
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
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);
        }

        [Fact]
        public void Invalid_ISBN_Or_ISBN13()
        {
            var book = new AddNewBookPostViewModel()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "0671027034",
                ISBN13 = "9780671027032",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);
        }

        [Fact]
        public void An_ISBN_That_Already_Exists_In_The_System()
        {
            var book = new AddNewBookPostViewModel()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "0671027034",
                ISBN13 = "9780671027032",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);
        }

        [Fact]
        public void An_ISBN13_That_Already_Exists_In_The_System()
        {
            var book = new AddNewBookPostViewModel()
            {
                Title = "A Title",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "1885167776",
                ISBN13 = "9783161484100",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() { 1, 2, 3 }
            };
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);
        }
    }
}
