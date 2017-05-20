using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using OpenSchoolLibrary.Models.BooksViewModels;

namespace OpenSchoolLibrary.Domain
{
    public class SaveBook : ISaveBook
    {
        readonly LibraryContext db;

        public SaveBook(LibraryContext db)
        {
            this.db = db;

        }

        public async Task<int> Create(BookCreationCommand cmd)
        {
            Book book = new Book()
            {
                ISBN = cmd.ISBN,
                ISBN13 = cmd.ISBN13
            };
            
            db.Books.Add(book);
            await db.SaveChangesAsync();

            return book.ID;
        }
    }
}