using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SalesWebMVC.Migrations
{
    public partial class NewSequencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SEQ_Department",
                startValue: 5L);

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_SaleRecord",
                startValue: 7L);

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_Seller",
                startValue: 7L);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seller",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"SEQ_Seller\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SalesRecord",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"SEQ_SaleRecord\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Department",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"SEQ_Department\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SEQ_Department");

            migrationBuilder.DropSequence(
                name: "SEQ_SaleRecord");

            migrationBuilder.DropSequence(
                name: "SEQ_Seller");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seller",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"SEQ_Seller\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SalesRecord",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"SEQ_SaleRecord\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Department",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"SEQ_Department\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
