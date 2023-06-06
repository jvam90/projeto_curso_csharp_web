using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projeto.Migrations
{
    /// <inheritdoc />
    public partial class ajustando_classes_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "CursoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "CursoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professor",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "ID", "Bairro", "Cidade", "Complemento", "Cpf", "Logradouro", "Nome", "Numero", "Pais", "UF" },
                values: new object[,]
                {
                    { 1, "Bairro 1", "Cidade 1", "Complemento 1", "11111111111", "Logradouro 1", "Professor 1", "1", "Pais 1", "PE" },
                    { 2, "Bairro 2", "Cidade 2", "Complemento 2", "22222222222", "Logradouro 2", "Professor 2", "2", "Pais 2", "BA" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "CursoID", "Ementa", "Nome", "ProfessorID" },
                values: new object[,]
                {
                    { 1, "Ementa 1", "Curso 1", 1 },
                    { 2, "Ementa 1", "Curso 2", 2 }
                });
        }
    }
}
