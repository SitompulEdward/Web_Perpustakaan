using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Perpustakaan.Migrations
{
    public partial class Tb_peminjaman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Peminjaman",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    No_Handphone = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    Tgl_Peminjaman = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tgl_Pengembalian = table.Column<DateTime>(type: "datetime", nullable: false),
                    User = table.Column<string>(type: "varchar(767)", nullable: true),
                    BukuId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Peminjaman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Peminjaman_Tb_Buku_BukuId",
                        column: x => x.BukuId,
                        principalTable: "Tb_Buku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Peminjaman_Tb_User_User",
                        column: x => x.User,
                        principalTable: "Tb_User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pengembalian",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: true),
                    Tgl_Kembali_Seharusnya = table.Column<string>(type: "text", nullable: true),
                    Tgl_Kembali = table.Column<string>(type: "text", nullable: true),
                    Peminjaman = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pengembalian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Pengembalian_Tb_Peminjaman_Peminjaman",
                        column: x => x.Peminjaman,
                        principalTable: "Tb_Peminjaman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Peminjaman_BukuId",
                table: "Tb_Peminjaman",
                column: "BukuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Peminjaman_User",
                table: "Tb_Peminjaman",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pengembalian_Peminjaman",
                table: "Tb_Pengembalian",
                column: "Peminjaman");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Pengembalian");

            migrationBuilder.DropTable(
                name: "Tb_Peminjaman");
        }
    }
}
