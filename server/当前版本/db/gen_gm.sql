/*
SQLyog v10.2 
MySQL - 5.5.41-MariaDB : Database - gen_gm
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`gen_gm` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `gen_gm`;

/*Table structure for table `t_activeid_info` */

DROP TABLE IF EXISTS `t_activeid_info`;

CREATE TABLE `t_activeid_info` (
  `id` int(20) NOT NULL,
  `activename` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `activetype` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `createday` date DEFAULT NULL,
  `description` varchar(1024) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `t_activeid_info` */

insert  into `t_activeid_info`(`id`,`activename`,`activetype`,`createday`,`description`) values (1001,'充值','3000','2016-04-17','充值活动'),(1002,'消费返利','3001','2016-04-17','消费返利消费返利消费返利消费返利消费返利消费返利'),(1003,'chongzhi','3000','2016-04-17','121212121'),(1004,'消费返利','3001','2016-04-18','消费返利----一句话'),(1005,'消费返利','3001','2016-04-18','消费返利-----一句话'),(1006,'当日登陆','3002','2016-04-18','当日登陆'),(1007,'消费返利','3001','2016-04-18','消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利'),(1008,'登陆','3002','2016-04-20','的呢轮毂的呢轮毂的呢轮毂的呢轮毂的呢轮毂的呢轮毂的呢轮毂'),(1009,'消费返利','3001','2016-04-21','活动介消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利消费返利'),(1010,'双倍活动','3005','2016-04-22','双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动双倍活动'),(1011,'累计登陆','3003','2016-04-22','累计登陆奖励');

/*Table structure for table `t_data_fetch` */

DROP TABLE IF EXISTS `t_data_fetch`;

CREATE TABLE `t_data_fetch` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(512) NOT NULL,
  `tables` varchar(50) NOT NULL,
  `fields` varchar(1024) NOT NULL,
  `extraCondition` varchar(2048) DEFAULT NULL,
  `reason` int(11) DEFAULT NULL,
  `servers` varchar(1024) NOT NULL,
  `schd` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_data_fetch` */

/*Table structure for table `t_opt_activityid_info` */

DROP TABLE IF EXISTS `t_opt_activityid_info`;

CREATE TABLE `t_opt_activityid_info` (
  `id` int(11) NOT NULL,
  `activename` varchar(400) COLLATE utf8_bin DEFAULT NULL,
  `createday` datetime DEFAULT NULL,
  `description` varchar(400) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `t_opt_activityid_info` */

/*Table structure for table `t_reward_stastics` */

DROP TABLE IF EXISTS `t_reward_stastics`;

CREATE TABLE `t_reward_stastics` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `serverId` int(11) DEFAULT NULL,
  `props` text,
  `createTime` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_reward_stastics` */

/*Table structure for table `t_server_stastics` */

DROP TABLE IF EXISTS `t_server_stastics`;

CREATE TABLE `t_server_stastics` (
  `id` int(11) NOT NULL,
  `provinceInfo` varchar(1204) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_server_stastics` */

insert  into `t_server_stastics`(`id`,`provinceInfo`) values (1,'[1032788]');

/*Table structure for table `t_server_template` */

DROP TABLE IF EXISTS `t_server_template`;

CREATE TABLE `t_server_template` (
  `regionId` int(11) NOT NULL,
  `serverId` int(11) NOT NULL,
  PRIMARY KEY (`regionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `t_server_template` */

insert  into `t_server_template`(`regionId`,`serverId`) values (1,1);

/*Table structure for table `t_sys_user` */

DROP TABLE IF EXISTS `t_sys_user`;

CREATE TABLE `t_sys_user` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `lastLogonDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `t_sys_user` */

insert  into `t_sys_user`(`id`,`username`,`password`,`role`,`serverIds`,`lastLogonDate`) values (1,'admin','ISMvKXpXpadDiUoOSoAfww==','super_admin','1,888,999','2009-11-18 11:07:19'),(4,'gm','ISMvKXpXpadDiUoOSoAfww==','admin','1,2','2010-08-19 11:42:26'),(5,'max','4QrcOUm6Wau+VuBX8g+IPg==','super_admin','1','2016-04-17 14:22:58');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
