using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class datainsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
                $"VALUES ('Into the Badlands', 'Movies is full of action',5.0)");

            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
               $"VALUES ('Kiss and Kill', 'Almost pornographic',4.5)");

            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
               $"VALUES ('Terminator', 'Futuristic Robotic Movie',3.7)");

            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
               $"VALUES ('Friends', 'Comic home movie',4.2)");

            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
               $"VALUES ('Presidents Man', 'Movies is full of action',4.5)");

            migrationBuilder.Sql($"INSERT INTO Movies (Title,Description,Rating) " +
               $"VALUES ('Winter Solder', 'Si-Fi avengers Movie',5.0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
