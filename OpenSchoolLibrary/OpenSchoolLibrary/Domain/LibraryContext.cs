using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using OpenSchoolLibrary.Models;

namespace OpenSchoolLibrary.Domain
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("OpenSchoolLibrary")
        {
            Database.SetInitializer<LibraryContext>(new CreateDatabaseIfNotExists<LibraryContext>());
        }

        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}