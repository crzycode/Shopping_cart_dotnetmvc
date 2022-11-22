namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiald : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(),
                        Product_price = c.Int(nullable: false),
                        Product_image = c.String(),
                        Product_category = c.String(),
                    })
                .PrimaryKey(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
