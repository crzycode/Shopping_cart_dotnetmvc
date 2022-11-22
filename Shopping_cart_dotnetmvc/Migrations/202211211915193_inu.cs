namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_id = c.Int(nullable: false, identity: true),
                        Order_cart_id = c.Int(nullable: false),
                        Order_no = c.Int(nullable: false),
                        Order_total_price = c.Int(nullable: false),
                        Order_user_id = c.Int(nullable: false),
                        Order_created_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.Order_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
