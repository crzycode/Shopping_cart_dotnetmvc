namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Cart_id = c.Int(nullable: false, identity: true),
                        Cart_user_id = c.Int(nullable: false),
                        Cart_product_id = c.Int(nullable: false),
                        Cart_quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cart_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
