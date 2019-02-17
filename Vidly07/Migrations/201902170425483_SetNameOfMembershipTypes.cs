namespace Vidly07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
			Sql("update MembershipTypes set Name='Pay as You Go' where DurationInMonths='0'");
			Sql("update MembershipTypes set Name='Monthly' where DurationInMonths='1'");
			Sql("update MembershipTypes set Name='Quartly' where DurationInMonths='3'");
			Sql("update MembershipTypes set Name='Annual' where DurationInMonths='12'");
        }
        
        public override void Down()
        {
        }
    }
}
