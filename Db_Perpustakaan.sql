/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 10.4.14-MariaDB : Database - perpustakaan
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`perpustakaan` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `perpustakaan`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20220131082218_Tb_Roles','5.0.13'),
('20220201161237_Tb_User','5.0.13'),
('20220201180143_Tb_Peminjaman','5.0.13'),
('20220203190618_Tb_Peminjaman','5.0.13'),
('20220203192552_Tb_peminjaman','5.0.13'),
('20220203195653_Tb_User','5.0.13'),
('20220203203353_Tb_User','5.0.13'),
('20220204023021_Tb_Pengembalian','5.0.13');

/*Table structure for table `tb_buku` */

DROP TABLE IF EXISTS `tb_buku`;

CREATE TABLE `tb_buku` (
  `Id` varchar(767) NOT NULL,
  `Judul_Buku` text DEFAULT NULL,
  `Pengarang` text DEFAULT NULL,
  `Penerbit` text DEFAULT NULL,
  `Tahun_Terbit` text DEFAULT NULL,
  `Gambar` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_buku` */

insert  into `tb_buku`(`Id`,`Judul_Buku`,`Pengarang`,`Penerbit`,`Tahun_Terbit`,`Gambar`) values 
('BK-1','Rindu','Tere Liye','Gramedia Pustaka','2016','f4820d86b1945f695a35426400ec48a7.jfif'),
('BK-2','Negeri Para Bedebah','Tere Liye','Gramedia Pustaka Indonesia','2012','662a5365b1d3c0e209b65f7dbe402e18.jfif');

/*Table structure for table `tb_peminjaman` */

DROP TABLE IF EXISTS `tb_peminjaman`;

CREATE TABLE `tb_peminjaman` (
  `Id` varchar(767) NOT NULL,
  `Nama_Lengkap` text DEFAULT NULL,
  `No_Handphone` text DEFAULT NULL,
  `Alamat` text DEFAULT NULL,
  `Tgl_Peminjaman` datetime NOT NULL,
  `Tgl_Pengembalian` datetime NOT NULL,
  `BukuId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Tb_Peminjaman_BukuId` (`BukuId`),
  CONSTRAINT `FK_Tb_Peminjaman_Tb_Buku_BukuId` FOREIGN KEY (`BukuId`) REFERENCES `tb_buku` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_peminjaman` */

insert  into `tb_peminjaman`(`Id`,`Nama_Lengkap`,`No_Handphone`,`Alamat`,`Tgl_Peminjaman`,`Tgl_Pengembalian`,`BukuId`) values 
('PJ-1','Sitompul Edward','085253261827','Jl.Dakota No.8A','2022-02-04 03:39:49','2022-02-07 03:39:00','BK-1');

/*Table structure for table `tb_pengembalian` */

DROP TABLE IF EXISTS `tb_pengembalian`;

CREATE TABLE `tb_pengembalian` (
  `Id` varchar(767) NOT NULL,
  `Nama_Lengkap` text DEFAULT NULL,
  `Tgl_Kembali_Seharusnya` datetime NOT NULL,
  `Tgl_Kembali` datetime NOT NULL,
  `PeminjamanId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Tb_Pengembalian_PeminjamanId` (`PeminjamanId`),
  CONSTRAINT `FK_Tb_Pengembalian_Tb_Peminjaman_PeminjamanId` FOREIGN KEY (`PeminjamanId`) REFERENCES `tb_peminjaman` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_pengembalian` */

insert  into `tb_pengembalian`(`Id`,`Nama_Lengkap`,`Tgl_Kembali_Seharusnya`,`Tgl_Kembali`,`PeminjamanId`) values 
('PG-1','Sitompul Edward','2022-02-04 03:39:49','2022-02-07 14:37:00','PJ-1'),
('PG-2','Sitompul','2022-02-04 03:39:49','2022-02-04 18:07:00','PJ-1');

/*Table structure for table `tb_roles` */

DROP TABLE IF EXISTS `tb_roles`;

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Name` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_roles` */

insert  into `tb_roles`(`Id`,`Name`) values 
('1','Admin'),
('2','User');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `RolesId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Username`),
  KEY `IX_Tb_User_RolesId` (`RolesId`),
  CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_user` */

insert  into `tb_user`(`Username`,`Password`,`Name`,`Email`,`RolesId`) values 
('Edward','edwar18','Edward Sitompul','sitompuledward060@gmail.com\r\n','1'),
('kuntiii','kuntianak','Kuntilanak','kuntipunyaanak@gmail.com','2'),
('sitompul','sitompul','Sitompul Edward','edwardsitompul10@gmail.com','2');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
