using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class featureEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO Features (Name) VALUES ('Feature1')");
            migrationBuilder.Sql("Insert INTO Features (Name) VALUES ('Feature2')");
            migrationBuilder.Sql("Insert INTO Features (Name) VALUES ('Feature3')");
            migrationBuilder.Sql("Insert INTO Features (Name) VALUES ('Feature4')");
            migrationBuilder.Sql("Insert INTO Features (Name) VALUES ('Feature5')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3', 'Feature4', 'Feature5')");
        }
    }
}
