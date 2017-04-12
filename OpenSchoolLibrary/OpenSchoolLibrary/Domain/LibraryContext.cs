using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("ConnectionString")
        {
            Database.SetInitializer<LibraryContext>(new CreateDatabaseIfNotExists<LibraryContext>());
        }

        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

    }
}