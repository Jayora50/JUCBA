namespace JUCBA.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALL_CONTEXT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountConfigurations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsBusinessOpen = c.Boolean(nullable: false),
                        FinancialDate = c.DateTime(nullable: false),
                        SavingsCreditInterestRate = c.Double(nullable: false),
                        SavingsMinimumBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SavingsInterestExpenseGlID = c.Int(),
                        SavingsInterestPayableGlID = c.Int(),
                        CurrentCreditInterestRate = c.Double(nullable: false),
                        CurrentMinimumBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentCot = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentInterestExpenseGlID = c.Int(),
                        CurrentCotIncomeGlID = c.Int(),
                        LoanDebitInterestRate = c.Double(nullable: false),
                        LoanInterestIncomeGlID = c.Int(),
                        LoanInterestExpenseGLID = c.Int(),
                        LoanInterestReceivableGlID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GlAccounts", t => t.CurrentCotIncomeGlID)
                .ForeignKey("dbo.GlAccounts", t => t.CurrentInterestExpenseGlID)
                .ForeignKey("dbo.GlAccounts", t => t.LoanInterestExpenseGLID)
                .ForeignKey("dbo.GlAccounts", t => t.LoanInterestIncomeGlID)
                .ForeignKey("dbo.GlAccounts", t => t.LoanInterestReceivableGlID)
                .ForeignKey("dbo.GlAccounts", t => t.SavingsInterestExpenseGlID)
                .ForeignKey("dbo.GlAccounts", t => t.SavingsInterestPayableGlID)
                .Index(t => t.SavingsInterestExpenseGlID)
                .Index(t => t.SavingsInterestPayableGlID)
                .Index(t => t.CurrentInterestExpenseGlID)
                .Index(t => t.CurrentCotIncomeGlID)
                .Index(t => t.LoanInterestIncomeGlID)
                .Index(t => t.LoanInterestExpenseGLID)
                .Index(t => t.LoanInterestReceivableGlID);
            
            CreateTable(
                "dbo.GlAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(nullable: false, maxLength: 40),
                        CodeNumber = c.Long(nullable: false),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GlCategoryID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.GlCategories", t => t.GlCategoryID, cascadeDelete: true)
                .Index(t => t.GlCategoryID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        SortCode = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GlCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 150),
                        MainCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Long(nullable: false),
                        AccountName = c.String(nullable: false, maxLength: 40),
                        BranchID = c.Int(nullable: false),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        DaysCount = c.Int(nullable: false),
                        dailyInterestAccrued = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanInterestRatePerMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountType = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                        SavingsWithdrawalCount = c.Int(nullable: false),
                        CurrentLien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                        LoanAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanMonthlyRepay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanMonthlyInterestRepay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanMonthlyPrincipalRepay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanPrincipalRemaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TermsOfLoan = c.Int(),
                        ServicingAccountID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.CustomerAccounts", t => t.ServicingAccountID)
                .Index(t => t.BranchID)
                .Index(t => t.CustomerID)
                .Index(t => t.ServicingAccountID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustId = c.String(),
                        FullName = c.String(nullable: false, maxLength: 40),
                        Address = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 16),
                        Gender = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExpenseIncomeEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountName = c.String(),
                        EntryType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GlPostings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Narration = c.String(),
                        Date = c.DateTime(nullable: false),
                        DrGlAccountID = c.Int(),
                        CrGlAccountID = c.Int(),
                        PostInitiatorId = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GlAccounts", t => t.CrGlAccountID)
                .ForeignKey("dbo.GlAccounts", t => t.DrGlAccountID)
                .Index(t => t.DrGlAccountID)
                .Index(t => t.CrGlAccountID);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TellerPostings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Narration = c.String(),
                        Date = c.DateTime(nullable: false),
                        PostingType = c.Int(nullable: false),
                        CustomerAccountID = c.Int(nullable: false),
                        PostInitiatorId = c.String(),
                        TillAccountID = c.Int(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerAccountID, cascadeDelete: true)
                .ForeignKey("dbo.GlAccounts", t => t.TillAccountID)
                .Index(t => t.CustomerAccountID)
                .Index(t => t.TillAccountID);
            
            CreateTable(
                "dbo.TillToUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        GlAccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GlAccounts", t => t.GlAccountID, cascadeDelete: true)
                .Index(t => t.GlAccountID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountName = c.String(),
                        SubCategory = c.String(),
                        MainCategory = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TillToUsers", "GlAccountID", "dbo.GlAccounts");
            DropForeignKey("dbo.TellerPostings", "TillAccountID", "dbo.GlAccounts");
            DropForeignKey("dbo.TellerPostings", "CustomerAccountID", "dbo.CustomerAccounts");
            DropForeignKey("dbo.RoleClaims", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.GlPostings", "DrGlAccountID", "dbo.GlAccounts");
            DropForeignKey("dbo.GlPostings", "CrGlAccountID", "dbo.GlAccounts");
            DropForeignKey("dbo.CustomerAccounts", "ServicingAccountID", "dbo.CustomerAccounts");
            DropForeignKey("dbo.CustomerAccounts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerAccounts", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.AccountConfigurations", "SavingsInterestPayableGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "SavingsInterestExpenseGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "LoanInterestReceivableGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "LoanInterestIncomeGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "LoanInterestExpenseGLID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "CurrentInterestExpenseGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.AccountConfigurations", "CurrentCotIncomeGlID", "dbo.GlAccounts");
            DropForeignKey("dbo.GlAccounts", "GlCategoryID", "dbo.GlCategories");
            DropForeignKey("dbo.GlAccounts", "BranchID", "dbo.Branches");
            DropIndex("dbo.TillToUsers", new[] { "GlAccountID" });
            DropIndex("dbo.TellerPostings", new[] { "TillAccountID" });
            DropIndex("dbo.TellerPostings", new[] { "CustomerAccountID" });
            DropIndex("dbo.RoleClaims", new[] { "RoleID" });
            DropIndex("dbo.GlPostings", new[] { "CrGlAccountID" });
            DropIndex("dbo.GlPostings", new[] { "DrGlAccountID" });
            DropIndex("dbo.CustomerAccounts", new[] { "ServicingAccountID" });
            DropIndex("dbo.CustomerAccounts", new[] { "CustomerID" });
            DropIndex("dbo.CustomerAccounts", new[] { "BranchID" });
            DropIndex("dbo.GlAccounts", new[] { "BranchID" });
            DropIndex("dbo.GlAccounts", new[] { "GlCategoryID" });
            DropIndex("dbo.AccountConfigurations", new[] { "LoanInterestReceivableGlID" });
            DropIndex("dbo.AccountConfigurations", new[] { "LoanInterestExpenseGLID" });
            DropIndex("dbo.AccountConfigurations", new[] { "LoanInterestIncomeGlID" });
            DropIndex("dbo.AccountConfigurations", new[] { "CurrentCotIncomeGlID" });
            DropIndex("dbo.AccountConfigurations", new[] { "CurrentInterestExpenseGlID" });
            DropIndex("dbo.AccountConfigurations", new[] { "SavingsInterestPayableGlID" });
            DropIndex("dbo.AccountConfigurations", new[] { "SavingsInterestExpenseGlID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TillToUsers");
            DropTable("dbo.TellerPostings");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.GlPostings");
            DropTable("dbo.ExpenseIncomeEntries");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAccounts");
            DropTable("dbo.GlCategories");
            DropTable("dbo.Branches");
            DropTable("dbo.GlAccounts");
            DropTable("dbo.AccountConfigurations");
        }
    }
}
