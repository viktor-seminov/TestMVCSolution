namespace TestMVCSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembeshipTypes", "MembershipType", c => c.String());
            Sql("UPDATE MembeshipTypes SET MembershipType = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembeshipTypes SET MembershipType = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembeshipTypes SET MembershipType = 'I dont know' WHERE Id = 3");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembeshipTypes", "MembershipType");
        }
    }
}
