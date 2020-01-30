using Microsoft.EntityFrameworkCore.Migrations;

namespace FutureAPIv1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolygonPoints",
                columns: table => new
                {
                    PolyPointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objectID = table.Column<int>(nullable: false),
                    lat = table.Column<decimal>(nullable: false),
                    lng = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonPoints", x => x.PolyPointID);
                });

            migrationBuilder.CreateTable(
                name: "Polygons",
                columns: table => new
                {
                    objectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Post_Code = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    ShapeArea = table.Column<decimal>(nullable: false),
                    ShapeLen = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygons", x => x.objectID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolygonPoints");

            migrationBuilder.DropTable(
                name: "Polygons");
        }
    }
}
