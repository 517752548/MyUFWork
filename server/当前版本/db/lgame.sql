/*
SQLyog v10.2 
MySQL - 5.5.41-MariaDB : Database - lgame
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`lgame` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `lgame`;

/*Table structure for table `t_asyn_challange` */

DROP TABLE IF EXISTS `t_asyn_challange`;

CREATE TABLE `t_asyn_challange` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` varchar(1000) DEFAULT NULL,
  `lastActiveTime` int(11) DEFAULT NULL,
  `player1Delete` int(11) DEFAULT NULL,
  `player2Delete` int(11) DEFAULT NULL,
  `playerId1` varchar(255) DEFAULT NULL,
  `playerId2` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_asyn_challange` */

/*Table structure for table `t_db_version` */

DROP TABLE IF EXISTS `t_db_version`;

CREATE TABLE `t_db_version` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mergeTime` datetime DEFAULT NULL,
  `openTime` datetime NOT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `serverNames` varchar(255) DEFAULT NULL,
  `updateTime` datetime NOT NULL,
  `version` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `t_db_version` */

insert  into `t_db_version`(`id`,`mergeTime`,`openTime`,`serverIds`,`serverNames`,`updateTime`,`version`) values (1,'1970-01-01 08:00:00','1970-01-01 08:00:00','1001,1002','s1,s2','1970-01-01 08:00:00','1.0.0.1');

/*Table structure for table `t_mail` */

DROP TABLE IF EXISTS `t_mail`;

CREATE TABLE `t_mail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `attach` varchar(255) DEFAULT NULL,
  `content` varchar(255) DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `receiverId` varchar(255) DEFAULT NULL,
  `sendDay` int(11) DEFAULT NULL,
  `sendTime` int(11) NOT NULL DEFAULT '0',
  `senderId` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `type` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_mail` */

/*Table structure for table `t_question` */

DROP TABLE IF EXISTS `t_question`;

CREATE TABLE `t_question` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accuracyMum` int(11) DEFAULT '0',
  `accuracySon` int(11) DEFAULT '0',
  `answer` int(11) DEFAULT NULL,
  `author` varchar(255) DEFAULT NULL,
  `authorName` varchar(255) DEFAULT NULL,
  `excelIndex` int(11) DEFAULT NULL,
  `imagePath` varchar(255) NOT NULL,
  `option1` varchar(255) NOT NULL,
  `option2` varchar(255) NOT NULL,
  `option3` varchar(255) NOT NULL,
  `option4` varchar(255) NOT NULL,
  `passCount` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  `submitDate` datetime DEFAULT NULL,
  `tag` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `unPassCount` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_question` */

/*Table structure for table `t_recept` */

DROP TABLE IF EXISTS `t_recept`;

CREATE TABLE `t_recept` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createTime` varchar(255) DEFAULT NULL,
  `lastModifyTime` varchar(255) DEFAULT NULL,
  `money` int(11) NOT NULL DEFAULT '0',
  `platform` varchar(255) DEFAULT NULL,
  `receiptUId` varchar(255) DEFAULT NULL,
  `reception` text,
  `statues` varchar(255) DEFAULT NULL,
  `userId` varchar(255) DEFAULT NULL,
  `userName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_recept` */

/*Table structure for table `t_relation` */

DROP TABLE IF EXISTS `t_relation`;

CREATE TABLE `t_relation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `charId` varchar(255) DEFAULT NULL,
  `relationType` int(11) DEFAULT NULL,
  `targetCharId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_relation` */

/*Table structure for table `t_text` */

DROP TABLE IF EXISTS `t_text`;

CREATE TABLE `t_text` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createTime` varchar(255) DEFAULT NULL,
  `gameId` varchar(255) DEFAULT NULL,
  `msgContent` varchar(255) DEFAULT NULL,
  `orderId` varchar(255) DEFAULT NULL,
  `phoneNum` varchar(255) DEFAULT NULL,
  `statues` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_text` */

/*Table structure for table `t_ticket` */

DROP TABLE IF EXISTS `t_ticket`;

CREATE TABLE `t_ticket` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createTime` varchar(255) DEFAULT NULL,
  `lastModifyTime` varchar(255) DEFAULT NULL,
  `money` int(11) NOT NULL DEFAULT '0',
  `orderId` varchar(255) DEFAULT NULL,
  `phoneNum` varchar(255) DEFAULT NULL,
  `platform` varchar(255) DEFAULT NULL,
  `productId` varchar(255) DEFAULT NULL,
  `statues` varchar(255) DEFAULT NULL,
  `ticketNum` int(11) NOT NULL DEFAULT '0',
  `userId` varchar(255) DEFAULT NULL,
  `userName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `t_ticket` */

/*Table structure for table `t_user_info` */

DROP TABLE IF EXISTS `t_user_info`;

CREATE TABLE `t_user_info` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `GM` int(11) NOT NULL DEFAULT '0',
  `appToken` varchar(255) DEFAULT NULL,
  `asynCount` int(11) NOT NULL DEFAULT '3',
  `asynRooms` varchar(255) DEFAULT NULL,
  `bgmOff` int(11) NOT NULL DEFAULT '0',
  `cataCorrect` varchar(255) DEFAULT NULL,
  `cataExp` varchar(255) DEFAULT NULL,
  `cataLevel` varchar(255) DEFAULT NULL,
  `cataTotal` varchar(255) DEFAULT NULL,
  `collection` varchar(255) DEFAULT NULL,
  `dailyMatchPara` varchar(255) DEFAULT NULL,
  `dailyQuest` varchar(255) DEFAULT NULL,
  `effectOff` int(11) NOT NULL DEFAULT '0',
  `equipment` varchar(255) DEFAULT NULL,
  `exp` int(11) DEFAULT '0',
  `firstPlace` int(11) NOT NULL DEFAULT '0',
  `headPath` varchar(255) DEFAULT NULL,
  `heartFromFriend` int(11) NOT NULL DEFAULT '0',
  `infoOff` int(11) NOT NULL DEFAULT '0',
  `lastActiveTime` datetime DEFAULT NULL,
  `lastAsynUpdateTime` int(11) DEFAULT NULL,
  `lastScholarDay` int(11) NOT NULL DEFAULT '0',
  `level` int(11) DEFAULT '1',
  `lockStep` int(11) NOT NULL DEFAULT '0',
  `loginGift` varchar(255) DEFAULT NULL,
  `mail` varchar(255) DEFAULT NULL,
  `mainQuest` int(11) NOT NULL DEFAULT '0',
  `mallPara` varchar(255) DEFAULT NULL,
  `money1` int(11) NOT NULL DEFAULT '0',
  `money2` int(11) NOT NULL DEFAULT '0',
  `money3` int(11) NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `notice` varchar(255) DEFAULT NULL,
  `noticeOff` int(11) NOT NULL DEFAULT '0',
  `pwd` varchar(50) DEFAULT NULL,
  `questCountCorrect` int(11) NOT NULL DEFAULT '0',
  `questCountCorrect3` int(11) NOT NULL DEFAULT '0',
  `questCountTotal` int(11) NOT NULL DEFAULT '0',
  `questCountTotal3` int(11) NOT NULL DEFAULT '0',
  `recentCata` varchar(255) DEFAULT NULL,
  `recentMatch` varchar(255) DEFAULT NULL,
  `record` varchar(255) DEFAULT NULL,
  `region` varchar(255) DEFAULT NULL,
  `registerTime` datetime DEFAULT NULL,
  `scholarCount` int(11) NOT NULL DEFAULT '0',
  `scores` varchar(255) DEFAULT NULL,
  `scoresMax` varchar(255) DEFAULT NULL,
  `scoresWeek` varchar(255) DEFAULT NULL,
  `secondPlace` int(11) NOT NULL DEFAULT '0',
  `sex` int(11) NOT NULL DEFAULT '0',
  `task` varchar(1000) DEFAULT NULL,
  `ticket` int(11) NOT NULL DEFAULT '0',
  `usingCollection` varchar(255) DEFAULT NULL,
  `winContin` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `t_user_info` */

insert  into `t_user_info`(`id`,`GM`,`appToken`,`asynCount`,`asynRooms`,`bgmOff`,`cataCorrect`,`cataExp`,`cataLevel`,`cataTotal`,`collection`,`dailyMatchPara`,`dailyQuest`,`effectOff`,`equipment`,`exp`,`firstPlace`,`headPath`,`heartFromFriend`,`infoOff`,`lastActiveTime`,`lastAsynUpdateTime`,`lastScholarDay`,`level`,`lockStep`,`loginGift`,`mail`,`mainQuest`,`mallPara`,`money1`,`money2`,`money3`,`name`,`notice`,`noticeOff`,`pwd`,`questCountCorrect`,`questCountCorrect3`,`questCountTotal`,`questCountTotal3`,`recentCata`,`recentMatch`,`record`,`region`,`registerTime`,`scholarCount`,`scores`,`scoresMax`,`scoresWeek`,`secondPlace`,`sex`,`task`,`ticket`,`usingCollection`,`winContin`) values (1,0,NULL,3,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,0,0,'',0,0,NULL,NULL,0,1,0,NULL,NULL,0,NULL,0,0,0,'test1',NULL,0,'1',0,0,0,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,0,0,NULL,0,NULL,0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
