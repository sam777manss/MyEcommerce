namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCards", "userId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCards", "userId");
        }
    }
}
