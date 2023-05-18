using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Admin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteExistingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"TRUNCATE TABLE AdminUsers");
            migrationBuilder.Sql(@"TRUNCATE TABLE Buyers");
            migrationBuilder.Sql(@"TRUNCATE TABLE LogisticsStaff");
            migrationBuilder.Sql(@"TRUNCATE TABLE Sellers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
