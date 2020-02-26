using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeWatcher.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(nullable: true),
                    pole = table.Column<string>(nullable: true),
                    available_bikes = table.Column<string>(nullable: true),
                    code_insee = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    availability = table.Column<string>(nullable: true),
                    availabilitycode = table.Column<string>(nullable: true),
                    etat = table.Column<string>(nullable: true),
                    startdate = table.Column<string>(nullable: true),
                    langue = table.Column<string>(nullable: true),
                    bike_stands = table.Column<string>(nullable: true),
                    last_update = table.Column<string>(nullable: true),
                    available_bike_stands = table.Column<string>(nullable: true),
                    gid = table.Column<string>(nullable: true),
                    titre = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    commune = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    bonus = table.Column<string>(nullable: true),
                    address2 = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    last_update_fme = table.Column<string>(nullable: true),
                    enddate = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    banking = table.Column<string>(nullable: true),
                    nmarrond = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
