using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__API.Migrations
{
    public partial class UsuarioAtl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "dataNacimento",
                table: "Usuarios",
                newName: "data_nascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Usuarios",
                newName: "dataNacimento");
        }
    }
}
