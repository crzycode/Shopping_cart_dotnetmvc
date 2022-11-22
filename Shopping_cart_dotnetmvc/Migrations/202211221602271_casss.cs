namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class casss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Order_cart_id", c => c.Long(nullable: false));
            AlterColumn("dbo.Orders", "Order_no", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Order_no", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Order_cart_id", c => c.Int(nullable: false));
        }
    }
}
