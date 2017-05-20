using OpenSchoolLibrary.Domain;
using OpenSchoolLibrary.Models.BooksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Stubs
{
    public class StubBookSaver : ISaveBook
    {
        public int TimesCalled = 0;
        public async Task<int> Create(BookCreationCommand cmd)
        {
            TimesCalled++;
            return 1;
        }
    }
}
