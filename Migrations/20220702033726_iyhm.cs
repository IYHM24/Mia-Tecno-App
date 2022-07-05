using Microsoft.EntityFrameworkCore.Migrations;

namespace Mia_Tecno_Store_App.Migrations
{
    public partial class iyhm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    id_archivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tamanio = table.Column<double>(type: "float", nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.id_archivo);
                });

            migrationBuilder.CreateTable(
                name: "Forros",
                columns: table => new
                {
                    id_forro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    referencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    colores = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    marca = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    variante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    variante_2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forros", x => x.id_forro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "Forros");
        }
    }
}
