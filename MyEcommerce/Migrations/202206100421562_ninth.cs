namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ninth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemToBeShippeds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        totalprize = c.String(),
                        flag = c.String(),
                        imgcardUrl = c.String(),
                        description = c.String(),
                        userId = c.String(),
                        details = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemToBeShippeds");
        }
    }
}
