namespace CIPSA.M_XI.Infrastructure.Migrations.Exercise.Agenda
{
    using System.Data.Entity.Migrations;
    
    public partial class initial_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DNI = c.String(nullable: false, maxLength: 9),
                        Name = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false, maxLength: 12),
                        Birthday = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
        }
    }
}
