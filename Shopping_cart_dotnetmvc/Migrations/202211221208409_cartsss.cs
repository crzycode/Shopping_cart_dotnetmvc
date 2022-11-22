namespace Shopping_cart_dotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartsss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_info",
                c => new
                    {
                        uiid = c.Int(nullable: false, identity: true),
                        firsname = c.String(),
                        middlename = c.String(),
                        lastname = c.String(),
                        gender = c.String(),
                        age = c.Int(nullable: false),
                        phonenumber = c.Long(nullable: false),
                        landline = c.Long(nullable: false),
                        country = c.String(),
                        province = c.String(),
                        city = c.String(),
                        town = c.String(),
                        street = c.String(),
                        houseno = c.String(),
                    })
                .PrimaryKey(t => t.uiid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User_info");
        }
    }
}
