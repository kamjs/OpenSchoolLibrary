namespace OpenSchoolLibrary.Migrations
{
    using OpenSchoolLibrary.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OpenSchoolLibrary.Domain.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryContext context)
        {
            context.Librarians.AddOrUpdate(new Librarian { FirstName = "Jane", LastName = "Elliot" });
            context.SaveChanges();

            context.Patrons.AddOrUpdate(
            new Patron { FirstName = "John", LastName = "Jones", Grade = 6, HomeRoomTeacher = "Mrs. Kensworth", LibraryCard = "012345", OptionalSecret = "Ghosts" },
            new Patron { FirstName = "Kim", LastName = "Elliot", Grade = 8, HomeRoomTeacher = "Mr. Johanson", LibraryCard = "014545B", OptionalSecret = "" }
            );
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
