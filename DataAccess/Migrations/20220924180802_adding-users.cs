using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addingusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO Users (Username,EmailAddress,Password,GivenName,Surname,Role) " +
               $"VALUES ('fotieno', 'felix.otieno@ngamia.africa','Hacking','Felix','Otieno','standard')");

            migrationBuilder.Sql($"INSERT INTO Users (Username,EmailAddress,Password,GivenName,Surname,Role) " +
               $"VALUES ('watieno', 'winnie.atieno@gmail.com','Hacking','Mandela','Winnie','standard')");

            migrationBuilder.Sql($"INSERT INTO Users (Username,EmailAddress,Password,GivenName,Surname,Role) " +
               $"VALUES ('dotieno', 'derick.otieno@ngamia.africa','Hacking','Derick','Otieno','standard')");

            migrationBuilder.Sql($"INSERT INTO Users (Username,EmailAddress,Password,GivenName,Surname,Role) " +
               $"VALUES ('botiende', 'babu.otiende@ngamia.africa','Hacking','Babu','Otiende','standard')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
