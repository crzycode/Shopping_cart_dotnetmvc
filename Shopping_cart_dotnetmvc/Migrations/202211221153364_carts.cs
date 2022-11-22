namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carts : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Cart_id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "Cart_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Cart_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "Cart_id");
        }
    }
}
