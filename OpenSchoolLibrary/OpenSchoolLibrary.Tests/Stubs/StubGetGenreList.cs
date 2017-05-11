using System.Collections.Generic;
using System.Linq;
using OpenSchoolLibrary.Domain;

namespace OpenSchoolLibrary.Tests.Stubs
{
    public class StubGetGenreList : IGetGenreList
    {
        public IQueryable<Genre> GenreList() => Genres.AsQueryable();

        private List<Genre> Genres = new List<Genre>{
            new Genre { ID = 1, Name = "Horror" },
            new Genre { ID = 564 , Name = "Science Fiction" },
            new Genre { ID = 84, Name = "Romance" }
        };
    }
}
