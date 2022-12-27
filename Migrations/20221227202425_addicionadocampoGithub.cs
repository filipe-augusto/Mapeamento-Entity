using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEntityMapeamento.Migrations
{
    /// <inheritdoc />
    public partial class addicionadocampoGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 20, 24, 25, 483, DateTimeKind.Utc).AddTicks(8991),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 12, 27, 17, 45, 13, 920, DateTimeKind.Utc).AddTicks(8051));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 17, 45, 13, 920, DateTimeKind.Utc).AddTicks(8051),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 12, 27, 20, 24, 25, 483, DateTimeKind.Utc).AddTicks(8991));
        }
    }
}
