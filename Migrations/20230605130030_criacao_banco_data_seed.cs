using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projeto.Migrations
{
    /// <inheritdoc />
    public partial class criacao_banco_data_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ementa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                    table.ForeignKey(
                        name: "FK_Curso_Professor_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Curso_ProfessorID",
                table: "Curso",
                column: "ProfessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
