using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServicesEmpresaX.Migrations
{
    /// <inheritdoc />
    public partial class EmpresaXInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionID = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sector = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__68906D44A44D629B", x => x.DireccionID);
                    table.ForeignKey(
                        name: "FK__Direccion__Clien__29572725",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ClienteID",
                table: "Direcciones",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
