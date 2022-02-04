using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Perpustakaan.Migrations
{
    public partial class Tb_Pengembalian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Pengembalian",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    Tgl_Kembali_Seharusnya = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tgl_Kembali = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeminjamanId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pengembalian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Pengembalian_Tb_Peminjaman_PeminjamanId",
                        column: x => x.PeminjamanId,
                        principalTable: "Tb_Peminjaman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pengembalian_PeminjamanId",
                table: "Tb_Pengembalian",
                column: "PeminjamanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Pengembalian");
        }
    }
}
