namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCards", "quantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCards", "quantity");
        }
    }
}
