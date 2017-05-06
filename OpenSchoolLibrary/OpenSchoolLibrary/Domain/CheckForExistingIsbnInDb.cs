using System;
using System.Threading.Tasks;
using OpenSchoolLibrary.Domain;
using System.Data.Entity;

namespace OpenSchoolLibrary.Domain
{
    public class CheckForExistingIsbnInDb : ICheckForExistingISBN
    {
        readonly LibraryContext libraryContext;

        public CheckForExistingIsbnInDb(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<bool> Exists(string isbn, string isbn13) => await libraryContext.Books.AnyAsync(b => b.ISBN == isbn || b.ISBN13 == isbn13);
    }
}   