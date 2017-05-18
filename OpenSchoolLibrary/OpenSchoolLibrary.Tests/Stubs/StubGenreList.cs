using OpenSchoolLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Stubs
{
    class StubGenreList : IGetGenreList
    {
        public List<Genre> StubGenres = new List<Genre>();

        public IQueryable<Genre> GenreList()
        {
            return StubGenres.AsQueryable();
        }
    }
}
