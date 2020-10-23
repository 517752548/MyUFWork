/*
SQLyog v10.2 
MySQL - 5.5.41-MariaDB : Database - tr_gm
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`tr_gm` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `tr_gm`;

/*Table structure for table `t_sys_user` */

DROP TABLE IF EXISTS `t_sys_user`;

CREATE TABLE `t_sys_user` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `regionId` varchar(255) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `lastLogonDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `t_sys_user` */

insert  into `t_sys_user`(`id`,`username`,`password`,`regionId`,`role`,`serverIds`,`lastLogonDate`) values (1,'admin','czeDtjPHIhdaQBBkmh3ZoQ==','ALL','super_admin','1,2,3','2014-03-14 11:07:19'),(2,'gm','ISMvKXpXpadDiUoOSoAfww==','ALL','admin','1,2,3','2014-03-14 11:42:26'),(3,'kaiying','ISMvKXpXpadDiUoOSoAfww==','ALL','admin','','2014-03-14 11:42:26'),(5,'haiying.yao','XwwmggZTdsUxtNSqbVguxA==','1','super_admin','1','2015-11-02 16:03:09'),(7,'yunlong.wang','4QrcOUm6Wau+VuBX8g+IPg==','1','developer','1,2,3','2015-11-02 16:33:19'),(8,'yongliang.yang','4QrcOUm6Wau+VuBX8g+IPg==','1','developer','1','2015-11-02 16:33:46'),(9,'ying.wang','EoU4Td+wV4FLrXgSe8eJvg==','ALL','super_admin','1','2015-12-17 18:03:19');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
