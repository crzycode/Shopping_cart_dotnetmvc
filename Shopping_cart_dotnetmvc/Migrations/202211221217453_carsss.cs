namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_info", "userinfo_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_info", "userinfo_id");
        }
    }
}
