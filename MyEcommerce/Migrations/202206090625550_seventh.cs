namespace MyEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductAdds", "name", c => c.String(nullable: false));
            AlterColumn("dbo.ProductAdds", "prize", c => c.String(nullable: false));
            AlterColumn("dbo.ProductAdds", "availability", c => c.String(nullable: false));
            AlterColumn("dbo.ProductAdds", "description", c => c.String(nullable: false));
            AlterColumn("dbo.ProductAdds", "details", c => c.String(nullable: false));
            AlterColumn("dbo.ProductAdds", "flag", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductAdds", "flag", c => c.String());
            AlterColumn("dbo.ProductAdds", "details", c => c.String());
            AlterColumn("dbo.ProductAdds", "description", c => c.String());
            AlterColumn("dbo.ProductAdds", "availability", c => c.String());
            AlterColumn("dbo.ProductAdds", "prize", c => c.String());
            AlterColumn("dbo.ProductAdds", "name", c => c.String());
        }
    }
}
