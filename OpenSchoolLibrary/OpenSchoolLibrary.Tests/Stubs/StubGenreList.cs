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
            return StubGenres.ToStubQueryable();
            /* ToStubQueryable is an Extention Method made to get around
            how IQuerayble and ToListAsync interact with Entity Framework.
            https://stackoverflow.com/questions/27483709/testing-ef-async-methods-with-sync-methods-with-moq
            https://msdn.microsoft.com/en-us/data/dn314429#async */
        }
    }
}
