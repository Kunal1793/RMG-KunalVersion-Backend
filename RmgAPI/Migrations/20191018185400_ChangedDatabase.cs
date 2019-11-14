using Microsoft.EntityFrameworkCore.Migrations;

namespace RmgAPI.Migrations
{
    public partial class ChangedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfRequests_Accounts_AccountID",
                table: "ListOfRequests");

            migrationBuilder.DropIndex(
                name: "IX_ListOfRequests_AccountID",
                table: "ListOfRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ListOfRequests_AccountID",
                table: "ListOfRequests",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfRequests_Accounts_AccountID",
                table: "ListOfRequests",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
