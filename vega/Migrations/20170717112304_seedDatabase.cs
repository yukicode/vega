using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO Makers (Name) VALUES ('Maker1')");
            migrationBuilder.Sql("Insert INTO Makers (Name) VALUES ('Maker2')");
            migrationBuilder.Sql("Insert INTO Makers (Name) VALUES ('Maker3')");

            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker1_ModelA', (SELECT ID FROM Makers WHERE Name = 'Maker1'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker1_ModelB', (SELECT ID FROM Makers WHERE Name = 'Maker1'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker1_ModelC', (SELECT ID FROM Makers WHERE Name = 'Maker1'))");

            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker2_ModelA', (SELECT ID FROM Makers WHERE Name = 'Maker2'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker2_ModelB', (SELECT ID FROM Makers WHERE Name = 'Maker2'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker2_ModelC', (SELECT ID FROM Makers WHERE Name = 'Maker2'))");

            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker3_ModelA', (SELECT ID FROM Makers WHERE Name = 'Maker3'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker3_ModelB', (SELECT ID FROM Makers WHERE Name = 'Maker3'))");
            migrationBuilder.Sql("Insert INTO Models (Name, MakerId) VALUES ('Maker3_ModelC', (SELECT ID FROM Makers WHERE Name = 'Maker3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makers WHERE Name IN ('Maker1', 'Maker2', 'Maker3')");
            //migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
