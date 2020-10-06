using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRepositoryPattern.Migrations
{
    public partial class InitialCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeVerifiers",
                columns: table => new
                {
                    RequestId = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeVerifiers", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "ReferralStates",
                columns: table => new
                {
                    ReferralId = table.Column<string>(maxLength: 200, nullable: false),
                    FinishedOnboarding = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralStates", x => x.ReferralId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeVerifiers");

            migrationBuilder.DropTable(
                name: "ReferralStates");
        }
    }
}
