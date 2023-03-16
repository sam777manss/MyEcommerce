namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductAdds", "categories", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductAdds", "categories");
        }
    }
}
