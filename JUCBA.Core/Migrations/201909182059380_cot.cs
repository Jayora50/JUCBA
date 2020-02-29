namespace JUCBA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAccounts", "dailyCOTAccrued", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAccounts", "dailyCOTAccrued");
        }
    }
}
