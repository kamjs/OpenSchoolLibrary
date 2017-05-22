using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Stubs
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> ToStubQueryable<T>(this IEnumerable<T> collection) where T : class =>
   new TestDbAsyncEnumerable<T>(collection);
    }
}
