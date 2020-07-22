namespace VidlyMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustomerDetails : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into dbo.Customers(Name,IsSubscribedToNewsLetter,BirthDate,MemberShipTypeId) values('Khaja','true','19/04/1989',3)");
            Sql("Insert into dbo.Customers(Name,IsSubscribedToNewsLetter,BirthDate,MemberShipTypeId) values('Moizuddin','false','15/01/1990',2)");
            Sql("Insert into dbo.Customers(Name,IsSubscribedToNewsLetter,BirthDate,MemberShipTypeId) values('Vijay','true','28/06/2000',1)");
        }
        
        public override void Down()
        {
        }
    }
}
