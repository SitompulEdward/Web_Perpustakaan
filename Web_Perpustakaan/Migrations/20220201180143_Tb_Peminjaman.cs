using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Perpustakaan.Migrations
{
    public partial class Tb_Peminjaman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Buku",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Judul_Buku = table.Column<string>(type: "text", nullable: true),
                    Pengarang = table.Column<string>(type: "text", nullable: true),
                    Penerbit = table.Column<string>(type: "text", nullable: true),
                    Tahun_Terbit = table.Column<string>(type: "text", nullable: true),
                    Gambar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Buku", x => x.Id);
                });

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
                    Username = table.Column<string>(type: "varchar(767)", nullable: true),
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
                        name: "FK_Tb_Peminjaman_Tb_User_Username",
                        column: x => x.Username,
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
                name: "IX_Tb_Peminjaman_BukuId",
                table: "Tb_Peminjaman",
                column: "BukuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Peminjaman_Username",
                table: "Tb_Peminjaman",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pengembalian_PeminjamanId",
                table: "Tb_Pengembalian",
                column: "PeminjamanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Pengembalian");

            migrationBuilder.DropTable(
                name: "Tb_Peminjaman");

            migrationBuilder.DropTable(
                name: "Tb_Buku");
        }
    }
}
