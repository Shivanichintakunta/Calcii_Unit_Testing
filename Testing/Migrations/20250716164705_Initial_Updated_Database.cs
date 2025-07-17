using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testing.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Updated_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "CalculatorEntitiys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "CalculatorEntitiys");
        }
    }
}
