using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM2.Migrations
{
    public partial class nh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    namHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    chuyennghanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HocViens_KhoaHocs_CourseID",
                        column: x => x.CourseID,
                        principalTable: "KhoaHocs",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "HocViens",
                columns: new[] { "ID", "CourseID", "HoTen", "MaKhoa", "Tuoi", "chuyennghanh" },
                values: new object[] { new Guid("efb065a2-1a52-40db-8cf4-cfa4327c9157"), null, "Nguyen Hong Minh", null, 20, "CNTT" });

            migrationBuilder.InsertData(
                table: "KhoaHocs",
                columns: new[] { "ID", "TenKhoa", "namHoc" },
                values: new object[] { "SD18401", "PTPM98", 2022 });

            migrationBuilder.CreateIndex(
                name: "IX_HocViens_CourseID",
                table: "HocViens",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");
        }
    }
}
