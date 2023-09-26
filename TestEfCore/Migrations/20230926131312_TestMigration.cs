using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testEfCore.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERIOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANAACCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENACCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENVIRO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FOLDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PROJECT = table.Column<int>(type: "int", nullable: true),
                    PERSON = table.Column<int>(type: "int", nullable: true),
                    REALIZED = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ACCDS1AC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetData");

            migrationBuilder.DropTable(
                name: "FinData");
        }
    }
}
