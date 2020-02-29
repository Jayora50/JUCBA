namespace JUCBA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountConfigurations", "CurrentInterestPayableGlID", c => c.Int());
            CreateIndex("dbo.AccountConfigurations", "CurrentInterestPayableGlID");
            AddForeignKey("dbo.AccountConfigurations", "CurrentInterestPayableGlID", "dbo.GlAccounts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountConfigurations", "CurrentInterestPayableGlID", "dbo.GlAccounts");
            DropIndex("dbo.AccountConfigurations", new[] { "CurrentInterestPayableGlID" });
            DropColumn("dbo.AccountConfigurations", "CurrentInterestPayableGlID");
        }
    }
}
