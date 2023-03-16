namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        totalprize = c.String(),
                        flag = c.String(),
                        imgcardUrl = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCards");
        }
    }
}
