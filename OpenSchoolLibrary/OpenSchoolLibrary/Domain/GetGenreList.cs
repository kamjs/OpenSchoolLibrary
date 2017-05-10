using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Domain
{
    public class GetGenreList : IGetGenreList
    {
        readonly LibraryContext libraryContext;

        public GetGenreList(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public IQueryable<Genre> GenreList() => libraryContext.Generes;
    }
}