namespace TestMVCSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembeshipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembeshipTypeId");
            AddForeignKey("dbo.Customers", "MembeshipTypeId", "dbo.MembeshipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembeshipTypeId", "dbo.MembeshipTypes");
            DropIndex("dbo.Customers", new[] { "MembeshipTypeId" });
            DropColumn("dbo.Customers", "MembeshipTypeId");
        }
    }
}
