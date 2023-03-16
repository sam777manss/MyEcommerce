namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deatilsInCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCards", "details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCards", "details");
        }
    }
}
