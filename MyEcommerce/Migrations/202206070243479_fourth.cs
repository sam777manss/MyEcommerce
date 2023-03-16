namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductAdds", "address", c => c.String());
            AddColumn("dbo.UserCards", "address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCards", "address");
            DropColumn("dbo.ProductAdds", "address");
        }
    }
}
