namespace OpenSchoolLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Librarians",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patrons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Grade = c.Int(nullable: false),
                        HomeRoomTeacher = c.String(),
                        LibraryCard = c.String(),
                        OptionalSecret = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patrons");
            DropTable("dbo.Librarians");
        }
    }
}
