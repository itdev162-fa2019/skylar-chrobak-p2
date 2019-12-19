using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations {

    public partial class CreateDb : Migration {
        protected override void Up(MigrationBuilder migrationBuilder)(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new {
                    Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Values", x => x.Id);
                }
            );
        }

        protected overrode void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Values"
            );
        }
    }
}