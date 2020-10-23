/*
SQLyog v10.2 
MySQL - 5.5.41-MariaDB : Database - llz
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`llz` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `llz`;

/*Table structure for table `t_achieve_base` */

DROP TABLE IF EXISTS `t_achieve_base`;

CREATE TABLE `t_achieve_base` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `achieveId` int(11) DEFAULT NULL,
  `status` tinyint(4) DEFAULT NULL,
  `finishCount` int(11) DEFAULT NULL,
  `achieveParams` varchar(1024) DEFAULT NULL,
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_achieve_base` */

/*Table structure for table `t_achieve_info` */

DROP TABLE IF EXISTS `t_achieve_info`;

CREATE TABLE `t_achieve_info` (
  `id` bigint(20) NOT NULL,
  `achieveChaId` int(11) DEFAULT NULL,
  `achieveStatus` int(11) DEFAULT NULL,
  `modifyTime` bigint(20) DEFAULT NULL,
  `finishList` varbinary(512) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_achieve_info` */

/*Table structure for table `t_achieve_log` */

DROP TABLE IF EXISTS `t_achieve_log`;

CREATE TABLE `t_achieve_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) DEFAULT NULL,
  `achieveId` int(11) DEFAULT NULL,
  `achieveStatus` tinyint(4) DEFAULT NULL,
  `achieveFinishType` tinyint(4) DEFAULT NULL,
  `finishTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_achieve_log` */

/*Table structure for table `t_active_qqmanager` */

DROP TABLE IF EXISTS `t_active_qqmanager`;

CREATE TABLE `t_active_qqmanager` (
  `human_uuid` bigint(20) NOT NULL,
  `login1` tinyint(4) DEFAULT NULL,
  `reward1` tinyint(4) DEFAULT NULL,
  `login2` tinyint(4) DEFAULT NULL,
  `reward2` tinyint(4) DEFAULT NULL,
  `login3` tinyint(4) DEFAULT NULL,
  `reward3` tinyint(4) DEFAULT NULL,
  `login4` tinyint(4) DEFAULT NULL,
  `reward4` tinyint(4) DEFAULT NULL,
  `login5` tinyint(4) DEFAULT NULL,
  `reward5` tinyint(4) DEFAULT NULL,
  `login6` tinyint(4) DEFAULT NULL,
  `reward6` tinyint(4) DEFAULT NULL,
  `login7` tinyint(4) DEFAULT NULL,
  `reward7` tinyint(4) DEFAULT NULL,
  `addRewardtime` bigint(20) DEFAULT NULL,
  `qqmanagerState` int(11) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_active_qqmanager` */

/*Table structure for table `t_active_sevenday` */

DROP TABLE IF EXISTS `t_active_sevenday`;

CREATE TABLE `t_active_sevenday` (
  `human_uuid` bigint(20) NOT NULL,
  `login1` tinyint(4) DEFAULT NULL,
  `reward1` tinyint(4) DEFAULT NULL,
  `login2` tinyint(4) DEFAULT NULL,
  `reward2` tinyint(4) DEFAULT NULL,
  `login3` tinyint(4) DEFAULT NULL,
  `reward3` tinyint(4) DEFAULT NULL,
  `login4` tinyint(4) DEFAULT NULL,
  `reward4` tinyint(4) DEFAULT NULL,
  `login5` tinyint(4) DEFAULT NULL,
  `reward5` tinyint(4) DEFAULT NULL,
  `login6` tinyint(4) DEFAULT NULL,
  `reward6` tinyint(4) DEFAULT NULL,
  `login7` tinyint(4) DEFAULT NULL,
  `reward7` tinyint(4) DEFAULT NULL,
  `addRewardtime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_active_sevenday` */

/*Table structure for table `t_activeity_signin` */

DROP TABLE IF EXISTS `t_activeity_signin`;

CREATE TABLE `t_activeity_signin` (
  `id` bigint(20) NOT NULL,
  `lasttime` bigint(20) NOT NULL DEFAULT '0',
  `signinInfo` varchar(256) NOT NULL DEFAULT '{}',
  `patchtime` bigint(20) DEFAULT '0',
  `sigtime` bigint(20) DEFAULT '0',
  `rewardInfo` varchar(128) DEFAULT '{}',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_activeity_signin` */

/*Table structure for table `t_activity_info` */

DROP TABLE IF EXISTS `t_activity_info`;

CREATE TABLE `t_activity_info` (
  `id` int(20) NOT NULL,
  `activityId` int(11) DEFAULT NULL,
  `currActivityStartTime` datetime DEFAULT NULL,
  `currActivityStopTime` datetime DEFAULT NULL,
  `nextActivityStartTime` datetime DEFAULT NULL,
  `nextActivityStopTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_activity_info` */

/*Table structure for table `t_activity_rank_info` */

DROP TABLE IF EXISTS `t_activity_rank_info`;

CREATE TABLE `t_activity_rank_info` (
  `id` bigint(20) NOT NULL,
  `activityId` int(11) DEFAULT NULL,
  `score` int(11) DEFAULT NULL,
  `activityStartTime` datetime DEFAULT NULL,
  `activityStopTime` datetime DEFAULT NULL,
  `lastUpdateTime` datetime DEFAULT NULL,
  `hasTakePrize` int(11) DEFAULT '0',
  `lastTakePrizeTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_activity_rank_info` */

/*Table structure for table `t_activity_record_info` */

DROP TABLE IF EXISTS `t_activity_record_info`;

CREATE TABLE `t_activity_record_info` (
  `id` bigint(20) NOT NULL,
  `activityId` int(11) DEFAULT '0',
  `activityStartTime` datetime DEFAULT NULL,
  `activityStopTime` datetime DEFAULT NULL,
  `lastUpdateScoreTime` datetime DEFAULT NULL,
  `score` int(11) DEFAULT '0',
  `hasTakePrize` int(11) DEFAULT '0',
  `lastTakePrizeTime` datetime DEFAULT NULL,
  `lastUpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_activity_record_info` */

/*Table structure for table `t_activity_reward` */

DROP TABLE IF EXISTS `t_activity_reward`;

CREATE TABLE `t_activity_reward` (
  `id` int(20) NOT NULL,
  `startTime` bigint(20) NOT NULL,
  `endTime` bigint(20) NOT NULL,
  `prizeAndRule` varchar(2000) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_activity_reward` */

/*Table structure for table `t_arena_log` */

DROP TABLE IF EXISTS `t_arena_log`;

CREATE TABLE `t_arena_log` (
  `id` bigint(20) NOT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `roleName` varchar(255) DEFAULT NULL,
  `logType` int(11) DEFAULT NULL,
  `opponentId` bigint(20) DEFAULT NULL,
  `opponentName` varchar(255) DEFAULT NULL,
  `rankAfter` int(11) DEFAULT NULL,
  `awardStr` varchar(255) DEFAULT NULL,
  `reportId` bigint(20) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `roleId` (`roleId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_arena_log` */

/*Table structure for table `t_arena_rank` */

DROP TABLE IF EXISTS `t_arena_rank`;

CREATE TABLE `t_arena_rank` (
  `id` bigint(20) NOT NULL,
  `roleName` varchar(255) DEFAULT NULL,
  `arenaLevel` int(11) DEFAULT NULL,
  `arenaRank` int(11) DEFAULT NULL,
  `lastUpdateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_arena_rank` */

/*Table structure for table `t_arena_refresh_flag` */

DROP TABLE IF EXISTS `t_arena_refresh_flag`;

CREATE TABLE `t_arena_refresh_flag` (
  `id` int(11) NOT NULL,
  `lastCompletedTime` bigint(20) DEFAULT NULL,
  `lastBusyTime` bigint(20) DEFAULT NULL,
  `currRetry` int(11) DEFAULT NULL,
  `lastUpdateRetryTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_arena_refresh_flag` */

/*Table structure for table `t_arena_snap` */

DROP TABLE IF EXISTS `t_arena_snap`;

CREATE TABLE `t_arena_snap` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `snapLevel` int(11) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `reputation` int(11) DEFAULT NULL,
  `honor` int(11) DEFAULT NULL,
  `arenaLevel` int(11) DEFAULT NULL,
  `arenaRank` int(11) DEFAULT NULL,
  `arenaSnapLevel` int(11) DEFAULT NULL,
  `arenaSnapRank` int(11) DEFAULT NULL,
  `cwinGainHonor` int(11) DEFAULT NULL,
  `cwinTimes` int(11) DEFAULT NULL,
  `winTimes` int(11) DEFAULT NULL,
  `totalTimes` int(11) DEFAULT NULL,
  `challengeTimes` int(11) DEFAULT NULL,
  `maxChallengeTimes` int(11) DEFAULT NULL,
  `totalAmount` int(11) DEFAULT NULL,
  `arrayId` int(11) DEFAULT NULL,
  `commanderAbility` int(11) DEFAULT NULL,
  `commanderAvatar` varchar(255) DEFAULT NULL,
  `armies` text NOT NULL,
  `createTime` datetime DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  `attackFirstAttr` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_arena_snap` */

/*Table structure for table `t_army_fairyland` */

DROP TABLE IF EXISTS `t_army_fairyland`;

CREATE TABLE `t_army_fairyland` (
  `id` bigint(20) NOT NULL,
  `eliteId` int(11) DEFAULT '0',
  `roleName` varchar(64) NOT NULL,
  `battleTime` bigint(20) DEFAULT '0',
  `armyName` varchar(64) NOT NULL,
  `gender` int(11) NOT NULL DEFAULT '0',
  `pass` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_army_fairyland` */

/*Table structure for table `t_army_shop` */

DROP TABLE IF EXISTS `t_army_shop`;

CREATE TABLE `t_army_shop` (
  `human_id` bigint(22) NOT NULL,
  `shop_inf` text,
  PRIMARY KEY (`human_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_army_shop` */

/*Table structure for table `t_armyapplylog` */

DROP TABLE IF EXISTS `t_armyapplylog`;

CREATE TABLE `t_armyapplylog` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `roleId` bigint(20) NOT NULL,
  `armyGroupName` varchar(32) NOT NULL,
  `applyTime` bigint(20) NOT NULL,
  `applyType` int(11) DEFAULT '0',
  `doRoleId` bigint(20) DEFAULT '0',
  `vipLevel` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `roleId` (`roleId`,`armyGroupName`)
) ENGINE=MyISAM AUTO_INCREMENT=28731 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_armyapplylog` */

/*Table structure for table `t_armygroup` */

DROP TABLE IF EXISTS `t_armygroup`;

CREATE TABLE `t_armygroup` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(32) NOT NULL,
  `title` varchar(32) DEFAULT NULL,
  `creatorRoleId` bigint(20) DEFAULT NULL,
  `creatorRoleName` varchar(64) NOT NULL,
  `leaderRoleId` bigint(20) DEFAULT NULL,
  `leaderRoleName` varchar(64) NOT NULL,
  `createTime` bigint(20) DEFAULT NULL,
  `armylevel` int(11) DEFAULT '1',
  `money` bigint(11) DEFAULT '0',
  `totalMoney` bigint(20) DEFAULT '0',
  `armyDesc` varchar(256) DEFAULT NULL,
  `upLevelCDTime` bigint(11) DEFAULT '0',
  `server_name` varchar(64) DEFAULT NULL,
  `orig_name` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `server_name` (`server_name`),
  KEY `orig_name` (`orig_name`)
) ENGINE=MyISAM AUTO_INCREMENT=464521947380712426 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_armygroup` */

/*Table structure for table `t_armygroupmember` */

DROP TABLE IF EXISTS `t_armygroupmember`;

CREATE TABLE `t_armygroupmember` (
  `id` bigint(20) NOT NULL,
  `RoleId` bigint(20) NOT NULL,
  `RoleName` varchar(64) DEFAULT NULL,
  `armyGroupName` varchar(32) NOT NULL,
  `jobName` varchar(16) NOT NULL,
  `JoinArmyTime` bigint(20) DEFAULT NULL,
  `PrestigeMoney` int(11) DEFAULT NULL,
  `totalPrestige` bigint(20) DEFAULT NULL,
  `totalContribute` bigint(20) DEFAULT NULL,
  `willChange` int(11) DEFAULT '0' COMMENT '是否被弹劾1 是    0 否',
  `willChangeTime` bigint(20) DEFAULT '0' COMMENT '团员点弹劾时候的时间戳',
  PRIMARY KEY (`id`),
  UNIQUE KEY `RoleId` (`RoleId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_armygroupmember` */

/*Table structure for table `t_armygroupwar` */

DROP TABLE IF EXISTS `t_armygroupwar`;

CREATE TABLE `t_armygroupwar` (
  `id` bigint(30) NOT NULL,
  `warId` bigint(20) NOT NULL DEFAULT '0' COMMENT '军团战ID',
  `armyGroups` varchar(100) NOT NULL DEFAULT '0' COMMENT '军团集合',
  `defenseNum` int(10) NOT NULL DEFAULT '0' COMMENT '成功防守次数',
  `score` int(10) NOT NULL DEFAULT '0' COMMENT '得分',
  `camp` tinyint(1) NOT NULL DEFAULT '0' COMMENT '阵营 1:功 , 2:防',
  `winStatus` tinyint(1) NOT NULL DEFAULT '0' COMMENT '上次军团战胜负',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armygroupwar` */

/*Table structure for table `t_armygroupwar_role` */

DROP TABLE IF EXISTS `t_armygroupwar_role`;

CREATE TABLE `t_armygroupwar_role` (
  `id` bigint(30) NOT NULL DEFAULT '0' COMMENT '参战人员id',
  `score` int(5) NOT NULL DEFAULT '0' COMMENT '得分',
  `winContinue` int(5) NOT NULL DEFAULT '0' COMMENT '连胜纪录',
  `historyScore` int(10) NOT NULL DEFAULT '0' COMMENT '历史总积分',
  `nowScore` int(10) NOT NULL DEFAULT '0' COMMENT '现存有积分',
  `warId` bigint(20) NOT NULL DEFAULT '0' COMMENT '军团战id',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armygroupwar_role` */

/*Table structure for table `t_armygroupwar_status` */

DROP TABLE IF EXISTS `t_armygroupwar_status`;

CREATE TABLE `t_armygroupwar_status` (
  `warId` bigint(30) NOT NULL DEFAULT '0' COMMENT '军团战ID',
  `openStatus` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0:未操作，1：筛选队伍，2：发出通知，3：开始军团战，4：军团战结束',
  `time` bigint(20) NOT NULL COMMENT '军团战开启时间',
  `endTime` bigint(20) NOT NULL COMMENT '结束时间',
  PRIMARY KEY (`warId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armygroupwar_status` */

/*Table structure for table `t_armywar_bag` */

DROP TABLE IF EXISTS `t_armywar_bag`;

CREATE TABLE `t_armywar_bag` (
  `id` bigint(30) NOT NULL DEFAULT '0' COMMENT '道具id',
  `groupName` varchar(20) NOT NULL DEFAULT '""' COMMENT '军团名字',
  `num` int(10) NOT NULL DEFAULT '0' COMMENT '道具数量',
  `itemId` int(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armywar_bag` */

/*Table structure for table `t_armywar_baglog` */

DROP TABLE IF EXISTS `t_armywar_baglog`;

CREATE TABLE `t_armywar_baglog` (
  `id` bigint(30) NOT NULL,
  `warId` bigint(20) NOT NULL COMMENT '军团战ID',
  `groupName` varchar(20) NOT NULL COMMENT '军团名',
  `itemId` int(20) NOT NULL DEFAULT '0' COMMENT '道具编号',
  `num` int(10) NOT NULL DEFAULT '0' COMMENT '道具数量',
  `createtime` bigint(20) NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armywar_baglog` */

/*Table structure for table `t_armywar_share` */

DROP TABLE IF EXISTS `t_armywar_share`;

CREATE TABLE `t_armywar_share` (
  `id` bigint(30) NOT NULL,
  `groupName` varchar(20) NOT NULL DEFAULT '""' COMMENT '军团名',
  `fromName` varchar(20) NOT NULL COMMENT '分配者',
  `toName` varchar(20) NOT NULL COMMENT '获得者',
  `itemId` int(20) NOT NULL COMMENT '物品',
  `itemNumber` int(10) NOT NULL COMMENT '数量',
  `createTime` bigint(20) NOT NULL COMMENT '时间',
  `warId` bigint(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_armywar_share` */

/*Table structure for table `t_bank_conf` */

DROP TABLE IF EXISTS `t_bank_conf`;

CREATE TABLE `t_bank_conf` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `startTime` bigint(20) DEFAULT '0',
  `endTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4;

/*Data for the table `t_bank_conf` */

/*Table structure for table `t_bank_info` */

DROP TABLE IF EXISTS `t_bank_info`;

CREATE TABLE `t_bank_info` (
  `id` bigint(20) NOT NULL,
  `monthMoney` int(11) NOT NULL DEFAULT '0',
  `monthTime` bigint(11) NOT NULL DEFAULT '0',
  `monthlastGetTime` bigint(20) NOT NULL DEFAULT '0',
  `monthGetMoney` int(11) NOT NULL DEFAULT '0',
  `monthGetMoneyGift` int(11) NOT NULL DEFAULT '0',
  `totalMoney` int(11) NOT NULL DEFAULT '0',
  `totalGetStatus` varchar(512) NOT NULL DEFAULT '{}',
  `totalGetMoney` int(11) NOT NULL DEFAULT '0',
  `totalGetMoneyGift` int(11) NOT NULL DEFAULT '0',
  `updateTime` bigint(20) NOT NULL DEFAULT '0',
  `monthGetTime` bigint(20) DEFAULT '0',
  `investCount` int(11) DEFAULT '0',
  `activityIds` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_bank_info` */

/*Table structure for table `t_bank_msg` */

DROP TABLE IF EXISTS `t_bank_msg`;

CREATE TABLE `t_bank_msg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) NOT NULL,
  `charName` varchar(256) NOT NULL,
  `createTime` bigint(20) NOT NULL,
  `type` int(11) NOT NULL,
  `money` int(11) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM AUTO_INCREMENT=343 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_bank_msg` */

/*Table structure for table `t_banksuper` */

DROP TABLE IF EXISTS `t_banksuper`;

CREATE TABLE `t_banksuper` (
  `id` bigint(20) NOT NULL,
  `gradeId` int(11) NOT NULL DEFAULT '0',
  `investMoney` int(11) NOT NULL DEFAULT '0',
  `investNum` int(11) NOT NULL DEFAULT '0',
  `investLastTime` bigint(20) NOT NULL DEFAULT '0',
  `rewardParam` text,
  `freeRewardParam` text,
  `isEnd` int(11) DEFAULT NULL,
  `updateTime` bigint(20) NOT NULL DEFAULT '0',
  `createTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_banksuper` */

/*Table structure for table `t_banksuper_msg` */

DROP TABLE IF EXISTS `t_banksuper_msg`;

CREATE TABLE `t_banksuper_msg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uuid` bigint(20) NOT NULL,
  `name` varchar(36) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  `rewardNum` int(11) NOT NULL DEFAULT '0',
  `rewards` varchar(1024) DEFAULT NULL,
  `createTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_banksuper_msg` */

/*Table structure for table `t_behavior` */

DROP TABLE IF EXISTS `t_behavior`;

CREATE TABLE `t_behavior` (
  `id` bigint(20) NOT NULL,
  `records` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_behavior` */

/*Table structure for table `t_black_market` */

DROP TABLE IF EXISTS `t_black_market`;

CREATE TABLE `t_black_market` (
  `id` bigint(20) NOT NULL,
  `flush_time` bigint(20) DEFAULT NULL,
  `flush_times` int(10) DEFAULT NULL,
  `hand_flush_time` bigint(20) DEFAULT NULL,
  `saleList` varchar(1024) DEFAULT NULL,
  `open_time` bigint(20) DEFAULT NULL,
  `haveBuy` int(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_black_market` */

/*Table structure for table `t_black_market_item` */

DROP TABLE IF EXISTS `t_black_market_item`;

CREATE TABLE `t_black_market_item` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `activityId` int(10) NOT NULL,
  `itemId` int(10) DEFAULT NULL,
  `cardId` int(10) DEFAULT NULL,
  `num` int(10) DEFAULT NULL,
  `pro` int(10) DEFAULT NULL,
  `type` int(10) DEFAULT NULL,
  `price` int(10) DEFAULT NULL,
  `effect` tinyint(1) DEFAULT NULL,
  `message` tinyint(1) DEFAULT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  `endTime` bigint(20) DEFAULT NULL,
  `startStr` text,
  `startInterval` int(10) DEFAULT NULL,
  `endStr` text,
  `endInterval` int(10) DEFAULT NULL,
  `endStartTime` int(10) DEFAULT NULL,
  `alwaysStr` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=138 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_black_market_item` */

/*Table structure for table `t_black_market_message` */

DROP TABLE IF EXISTS `t_black_market_message`;

CREATE TABLE `t_black_market_message` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `roleName` varchar(50) DEFAULT NULL,
  `itemName` varchar(50) DEFAULT NULL,
  `itemStar` int(10) DEFAULT NULL,
  `itemNum` int(10) DEFAULT NULL,
  `getTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=80 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_black_market_message` */

/*Table structure for table `t_block_user` */

DROP TABLE IF EXISTS `t_block_user`;

CREATE TABLE `t_block_user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `platform_uuid` varchar(64) DEFAULT NULL,
  `human_uuid` bigint(20) DEFAULT NULL,
  `client_ip_addr` varchar(128) DEFAULT NULL,
  `start_time` bigint(20) DEFAULT '0',
  `end_time` bigint(20) DEFAULT '0',
  `memo` text,
  PRIMARY KEY (`id`),
  KEY `IX_passportId` (`platform_uuid`),
  KEY `IX_humanUUId` (`human_uuid`),
  KEY `IX_clientIpAddr` (`client_ip_addr`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_block_user` */

/*Table structure for table `t_blue_number` */

DROP TABLE IF EXISTS `t_blue_number`;

CREATE TABLE `t_blue_number` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `roleId` bigint(20) NOT NULL,
  `blueNumVersionId` int(11) NOT NULL,
  `blueNumCout` int(11) NOT NULL,
  `grade1` smallint(6) NOT NULL,
  `grade2` smallint(6) NOT NULL,
  `grade3` smallint(6) NOT NULL,
  `grade4` smallint(6) NOT NULL,
  `grade5` smallint(6) NOT NULL,
  `grade6` smallint(6) NOT NULL,
  `grade7` smallint(6) NOT NULL,
  `grade8` smallint(6) NOT NULL,
  `grade9` smallint(6) NOT NULL,
  `grade10` smallint(6) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `newIndex1` (`roleId`,`blueNumVersionId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_blue_number` */

/*Table structure for table `t_blue_number_gm` */

DROP TABLE IF EXISTS `t_blue_number_gm`;

CREATE TABLE `t_blue_number_gm` (
  `id` int(11) NOT NULL,
  `startTime` bigint(20) NOT NULL,
  `endTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_blue_number_gm` */

/*Table structure for table `t_bluediamond_info` */

DROP TABLE IF EXISTS `t_bluediamond_info`;

CREATE TABLE `t_bluediamond_info` (
  `uuid` bigint(64) NOT NULL,
  `reward_top_level` int(4) DEFAULT NULL,
  `reward_top_blue` int(4) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_bluediamond_info` */

/*Table structure for table `t_building` */

DROP TABLE IF EXISTS `t_building`;

CREATE TABLE `t_building` (
  `id` bigint(32) NOT NULL,
  `home` int(11) NOT NULL DEFAULT '0',
  `grandCouncil` int(11) NOT NULL DEFAULT '0',
  `observatory` int(11) NOT NULL DEFAULT '0',
  `tavern` int(11) NOT NULL DEFAULT '0',
  `shogunSoulPaviliong` int(11) NOT NULL DEFAULT '0',
  `barracks` int(11) NOT NULL DEFAULT '0',
  `smithy` int(11) NOT NULL DEFAULT '0',
  `store` int(11) NOT NULL DEFAULT '0',
  `colleage` int(11) NOT NULL DEFAULT '0',
  `cleanSoulPaviliong` int(11) NOT NULL DEFAULT '0',
  `commercial` int(11) DEFAULT '0',
  `folkhouse` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_building` */

/*Table structure for table `t_bulevip_info` */

DROP TABLE IF EXISTS `t_bulevip_info`;

CREATE TABLE `t_bulevip_info` (
  `id` bigint(20) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '0',
  `yearVipLevel` int(11) NOT NULL DEFAULT '0',
  `highVip` int(11) NOT NULL DEFAULT '0',
  `recordTime` bigint(20) NOT NULL DEFAULT '0',
  `newType` int(11) NOT NULL DEFAULT '0',
  `newRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `firstType` int(11) NOT NULL DEFAULT '0',
  `firstRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `everyDayJson` varchar(512) DEFAULT NULL,
  `everyRecordTime` bigint(20) DEFAULT '0',
  `charge_times` int(11) DEFAULT '0',
  `everyHighRecordTime` bigint(20) DEFAULT '0',
  `endTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_bulevip_info` */

/*Table structure for table `t_card` */

DROP TABLE IF EXISTS `t_card`;

CREATE TABLE `t_card` (
  `uuid` varchar(128) NOT NULL,
  `template_id` int(11) DEFAULT NULL,
  `owner_id` bigint(20) DEFAULT NULL,
  `card_level` int(11) DEFAULT NULL,
  `at_bag_type_id` int(11) DEFAULT NULL,
  `at_index` int(11) DEFAULT NULL,
  `at_array_index` int(11) DEFAULT NULL,
  `at_bag_index` int(11) DEFAULT NULL,
  `card_star` int(11) DEFAULT NULL,
  `attkPow` int(11) DEFAULT NULL,
  `defence` int(11) DEFAULT NULL,
  `maxHP` int(11) DEFAULT NULL,
  `skillID` int(11) DEFAULT NULL,
  `currEvo` int(11) DEFAULT NULL,
  `currExp` int(11) DEFAULT NULL,
  `fightPower` int(11) DEFAULT '0',
  `arrayIndex` int(11) NOT NULL DEFAULT '0',
  `guardIndex` int(11) NOT NULL DEFAULT '0',
  `soulBattleIndex` int(11) NOT NULL DEFAULT '0',
  `cardStatus` int(11) DEFAULT '0',
  `isLocked` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`uuid`),
  KEY `fightePower` (`fightPower`),
  KEY `card_owner` (`owner_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_card` */

/*Table structure for table `t_card2_hire` */

DROP TABLE IF EXISTS `t_card2_hire`;

CREATE TABLE `t_card2_hire` (
  `human_uuid` bigint(20) NOT NULL,
  `rank1_hire_times` int(11) DEFAULT NULL,
  `rank2_hire_times` int(11) DEFAULT NULL,
  `rank3_hire_times` int(11) DEFAULT NULL,
  `rank1_next_hire_time_and_free` bigint(20) DEFAULT NULL,
  `rank2_next_hire_time_and_free` bigint(20) DEFAULT NULL,
  `rank3_next_hire_time_and_free` bigint(20) DEFAULT NULL,
  `rank1_hire_times_and_free` int(11) DEFAULT NULL,
  `rank2_hire_times_and_free` int(11) DEFAULT NULL,
  `rank3_hire_times_and_free` int(11) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_card2_hire` */

/*Table structure for table `t_card_baptize` */

DROP TABLE IF EXISTS `t_card_baptize`;

CREATE TABLE `t_card_baptize` (
  `card_uuid` varchar(64) COLLATE utf8_bin NOT NULL,
  `human_uuid` bigint(20) DEFAULT NULL,
  `times` int(11) DEFAULT NULL,
  `used_points` int(11) DEFAULT NULL,
  `add_p_attk` int(11) DEFAULT NULL,
  `add_p_defn` int(11) DEFAULT NULL,
  `add_m_attk` int(11) DEFAULT NULL,
  `add_m_defn` int(11) DEFAULT NULL,
  `add_max_hp` int(11) DEFAULT NULL,
  `baptize_type_str` varchar(64) COLLATE utf8_bin DEFAULT NULL,
  `up_prop_id` int(11) DEFAULT NULL,
  `up_val` int(11) DEFAULT NULL,
  `down_prop_id` int(11) DEFAULT NULL,
  `down_val` int(11) DEFAULT NULL,
  `sub_points` int(11) DEFAULT NULL,
  `add_times` int(11) DEFAULT '0',
  PRIMARY KEY (`card_uuid`),
  KEY `human_uuid` (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin ROW_FORMAT=DYNAMIC;

/*Data for the table `t_card_baptize` */

/*Table structure for table `t_card_record` */

DROP TABLE IF EXISTS `t_card_record`;

CREATE TABLE `t_card_record` (
  `id` bigint(64) NOT NULL,
  `hireRecord` varchar(254) DEFAULT NULL,
  `boxRecord` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_card_record` */

/*Table structure for table `t_cd` */

DROP TABLE IF EXISTS `t_cd`;

CREATE TABLE `t_cd` (
  `human_uuid` bigint(11) NOT NULL,
  `json_str` text NOT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cd` */

/*Table structure for table `t_cd_rate` */

DROP TABLE IF EXISTS `t_cd_rate`;

CREATE TABLE `t_cd_rate` (
  `id` int(11) NOT NULL,
  `rate` float NOT NULL,
  `descstr` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cd_rate` */

/*Table structure for table `t_cdkey_activity` */

DROP TABLE IF EXISTS `t_cdkey_activity`;

CREATE TABLE `t_cdkey_activity` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kname` varchar(256) DEFAULT NULL,
  `kdesc` varchar(1024) DEFAULT NULL,
  `openflag` int(11) DEFAULT NULL,
  `opentime` bigint(20) NOT NULL,
  `closetime` bigint(20) NOT NULL,
  `url` varchar(512) DEFAULT NULL,
  `rewards` varchar(512) DEFAULT NULL,
  `cdtype` int(11) NOT NULL DEFAULT '0',
  `queryFromQQ` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cdkey_activity` */

/*Table structure for table `t_cdkeylist` */

DROP TABLE IF EXISTS `t_cdkeylist`;

CREATE TABLE `t_cdkeylist` (
  `uuid` varchar(32) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `cdkeyid` int(11) NOT NULL,
  `isuse` smallint(6) NOT NULL DEFAULT '0',
  `ownercharid` bigint(20) DEFAULT NULL,
  `gettime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cdkeylist` */

/*Table structure for table `t_challenge_info` */

DROP TABLE IF EXISTS `t_challenge_info`;

CREATE TABLE `t_challenge_info` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `challengecId` int(11) NOT NULL,
  `updateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `challengeContent` varchar(4000) DEFAULT NULL,
  `rewardStatus` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_challenge_info` */

/*Table structure for table `t_challenge_rank` */

DROP TABLE IF EXISTS `t_challenge_rank`;

CREATE TABLE `t_challenge_rank` (
  `id` varchar(32) NOT NULL,
  `challengecId` int(11) NOT NULL,
  `challengeEliteId` int(11) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `charName` varchar(100) NOT NULL,
  `type` tinyint(4) NOT NULL DEFAULT '0',
  `batScores` int(11) NOT NULL,
  `batTime` int(11) DEFAULT NULL,
  `batReportId` varchar(100) DEFAULT NULL,
  `creatTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_challenge_rank` */

/*Table structure for table `t_champion_info` */

DROP TABLE IF EXISTS `t_champion_info`;

CREATE TABLE `t_champion_info` (
  `id` bigint(64) NOT NULL,
  `persionFame` int(11) DEFAULT '0',
  `lastWeekFame` int(11) DEFAULT '0',
  `updateTime` bigint(11) DEFAULT '0',
  `weekResetTime` bigint(11) DEFAULT '0',
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_champion_info` */

/*Table structure for table `t_charge` */

DROP TABLE IF EXISTS `t_charge`;

CREATE TABLE `t_charge` (
  `id` bigint(20) NOT NULL,
  `userId` bigint(20) DEFAULT NULL,
  `money` int(11) NOT NULL DEFAULT '0',
  `diamond` int(11) NOT NULL DEFAULT '0',
  `time` datetime DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userId` (`userId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_charge` */

/*Table structure for table `t_cimelia_info` */

DROP TABLE IF EXISTS `t_cimelia_info`;

CREATE TABLE `t_cimelia_info` (
  `id` varchar(64) NOT NULL,
  `bagId` int(11) DEFAULT '0',
  `bagSlot` int(11) DEFAULT '0',
  `bind` int(11) DEFAULT NULL,
  `xilian` int(11) DEFAULT NULL,
  `embedStones` varchar(512) DEFAULT NULL,
  `embedslot` int(11) DEFAULT NULL,
  `charId` bigint(20) NOT NULL,
  `wearerId` varchar(64) NOT NULL,
  `coolDownTimePoint` bigint(20) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `curEndure` int(11) DEFAULT NULL,
  `deadline` datetime DEFAULT '2099-01-01 00:00:01',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `overlap` int(11) DEFAULT NULL,
  `properties` varchar(1024) DEFAULT NULL,
  `star` int(11) DEFAULT NULL,
  `templateId` int(11) DEFAULT NULL,
  `upStarCount` int(11) DEFAULT '0',
  `upXilianCount` int(11) DEFAULT '0',
  `exp` int(11) DEFAULT '0',
  `isLocked` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `charId` (`charId`),
  KEY `charId_bagId` (`charId`,`bagId`),
  KEY `wearerId` (`wearerId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cimelia_info` */

/*Table structure for table `t_city_war` */

DROP TABLE IF EXISTS `t_city_war`;

CREATE TABLE `t_city_war` (
  `human_uuid` bigint(20) NOT NULL DEFAULT '0',
  `last_seize_time` bigint(20) DEFAULT '0',
  `seize_times` int(11) DEFAULT '0',
  `enemyIdList` text,
  `cityWarRecordList` text,
  `seizeCityId` int(11) DEFAULT '-1',
  `seizeSenceId` int(11) DEFAULT '-1',
  `humanName` varchar(100) DEFAULT NULL,
  `lastAttackTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_city_war` */

/*Table structure for table `t_classic_info` */

DROP TABLE IF EXISTS `t_classic_info`;

CREATE TABLE `t_classic_info` (
  `id` varchar(64) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `chapterId` int(11) NOT NULL,
  `chapterContent` varchar(512) NOT NULL,
  `rewardStatus1` smallint(6) NOT NULL DEFAULT '0',
  `rewardStatus2` smallint(6) DEFAULT '0',
  `rewardStatus3` smallint(6) DEFAULT '0',
  `updateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `totalStar` int(11) DEFAULT '0',
  `starUpdateTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `classicindex` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_classic_info` */

/*Table structure for table `t_continuously_prize` */

DROP TABLE IF EXISTS `t_continuously_prize`;

CREATE TABLE `t_continuously_prize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prizeId` bigint(20) DEFAULT NULL,
  `prizeName` varchar(255) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `prizePackage` text,
  `prizeOpen` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  UNIQUE KEY `prizeId` (`prizeId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_continuously_prize` */

/*Table structure for table `t_country_candidate` */

DROP TABLE IF EXISTS `t_country_candidate`;

CREATE TABLE `t_country_candidate` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `candidateHair` int(11) DEFAULT NULL,
  `candidateHead` int(11) DEFAULT NULL,
  `candidateFeature` int(11) DEFAULT NULL,
  `candidateAvatar` int(11) DEFAULT NULL,
  `candidateCap` int(11) DEFAULT NULL,
  `guildName` varchar(255) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `allianceId` int(11) DEFAULT NULL,
  `pollNum` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_country_candidate` */

/*Table structure for table `t_country_info` */

DROP TABLE IF EXISTS `t_country_info`;

CREATE TABLE `t_country_info` (
  `id` bigint(20) NOT NULL,
  `humanNum` int(11) DEFAULT NULL,
  `guildNum` int(11) DEFAULT NULL,
  `cityNum` int(11) DEFAULT NULL,
  `unionCountryId` int(11) DEFAULT NULL,
  `leaderUUID` bigint(20) DEFAULT NULL,
  `leaderName` varchar(255) DEFAULT NULL,
  `leaderHair` int(11) DEFAULT NULL,
  `leaderHead` int(11) DEFAULT NULL,
  `leaderFeature` int(11) DEFAULT NULL,
  `leaderAvatar` int(11) DEFAULT NULL,
  `leaderCap` int(11) DEFAULT NULL,
  `countryBulletin` varchar(255) DEFAULT NULL,
  `royaltyPack` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_country_info` */

/*Table structure for table `t_countryelect_time` */

DROP TABLE IF EXISTS `t_countryelect_time`;

CREATE TABLE `t_countryelect_time` (
  `id` int(11) NOT NULL,
  `timeType` int(11) DEFAULT NULL,
  `electTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_countryelect_time` */

/*Table structure for table `t_cross_epic` */

DROP TABLE IF EXISTS `t_cross_epic`;

CREATE TABLE `t_cross_epic` (
  `uuid` bigint(20) NOT NULL,
  `supportUuid` bigint(20) DEFAULT NULL,
  `name` varchar(36) DEFAULT NULL,
  `supportLeftMoney` int(11) DEFAULT NULL,
  `supportRightMoney` int(11) DEFAULT NULL,
  `supportRound` int(11) DEFAULT NULL,
  `reward16` tinyint(1) DEFAULT NULL,
  `reward8` tinyint(1) DEFAULT NULL,
  `reward4` tinyint(1) DEFAULT NULL,
  `reward2` tinyint(1) DEFAULT NULL,
  `reward1` tinyint(1) DEFAULT NULL,
  `final1` tinyint(1) DEFAULT NULL,
  `finalReward` tinyint(1) DEFAULT NULL,
  `eliminateReward` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cross_epic` */

/*Table structure for table `t_cross_match` */

DROP TABLE IF EXISTS `t_cross_match`;

CREATE TABLE `t_cross_match` (
  `id` bigint(64) NOT NULL AUTO_INCREMENT,
  `status` int(2) DEFAULT NULL,
  `battleJson` text,
  `name` varchar(100) DEFAULT NULL,
  `server` int(4) DEFAULT NULL,
  `level` int(4) DEFAULT NULL,
  `gender` int(4) DEFAULT NULL,
  `wingId` bigint(20) DEFAULT NULL,
  `smallPetId` bigint(20) DEFAULT NULL,
  `uuid` bigint(64) DEFAULT NULL,
  `postion` int(11) DEFAULT NULL,
  `owerUuid` bigint(64) DEFAULT NULL,
  `needFresh` int(4) DEFAULT '0',
  `fightPower` int(8) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `owerid_index` (`owerUuid`)
) ENGINE=MyISAM AUTO_INCREMENT=8760 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cross_match` */

/*Table structure for table `t_cross_shop` */

DROP TABLE IF EXISTS `t_cross_shop`;

CREATE TABLE `t_cross_shop` (
  `human_id` bigint(22) NOT NULL,
  `shop_inf` text,
  PRIMARY KEY (`human_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_cross_shop` */

/*Table structure for table `t_crossepic_info` */

DROP TABLE IF EXISTS `t_crossepic_info`;

CREATE TABLE `t_crossepic_info` (
  `id` bigint(20) NOT NULL,
  `round` int(11) DEFAULT NULL,
  `battleTimes` int(11) DEFAULT NULL,
  `supportLeftNum` int(11) DEFAULT NULL,
  `supportRightNum` int(11) DEFAULT NULL,
  `supportLeftMoney` bigint(20) DEFAULT NULL,
  `supportRightMoney` bigint(20) DEFAULT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  `groupId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crossepic_info` */

/*Table structure for table `t_crossepic_knockout` */

DROP TABLE IF EXISTS `t_crossepic_knockout`;

CREATE TABLE `t_crossepic_knockout` (
  `id` bigint(20) NOT NULL,
  `bfOrder` int(11) DEFAULT '0',
  `hcOrder` int(11) DEFAULT '0',
  `koOrder` int(11) DEFAULT '0',
  `leftPkId` varchar(36) DEFAULT '""',
  `rightPkId` varchar(36) DEFAULT '""',
  `status` varchar(100) DEFAULT '""',
  `leftName` varchar(36) DEFAULT '""',
  `rightName` varchar(36) DEFAULT '""',
  `groupId` int(11) DEFAULT '0',
  `leftKoOrder` int(11) DEFAULT '0',
  `rightKoOrder` int(11) DEFAULT '0',
  `leftServerId` int(11) DEFAULT '0',
  `rightServerId` int(11) DEFAULT '0',
  `reports` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crossepic_knockout` */

/*Table structure for table `t_crossepic_pkhuman` */

DROP TABLE IF EXISTS `t_crossepic_pkhuman`;

CREATE TABLE `t_crossepic_pkhuman` (
  `uuid` bigint(20) NOT NULL,
  `name` varchar(36) NOT NULL,
  `status` int(11) DEFAULT NULL,
  `bfOrder` int(11) DEFAULT NULL,
  `hcOrder` int(11) DEFAULT NULL,
  `pkOrder` int(11) DEFAULT NULL,
  `serverId` int(11) DEFAULT NULL,
  `wingId` int(11) DEFAULT NULL,
  `smallPetId` int(11) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `battlePower` int(11) DEFAULT NULL,
  `groupId` int(11) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crossepic_pkhuman` */

/*Table structure for table `t_crossepic_top` */

DROP TABLE IF EXISTS `t_crossepic_top`;

CREATE TABLE `t_crossepic_top` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `addTime` bigint(20) NOT NULL,
  `uuid` bigint(20) NOT NULL,
  `name` varchar(36) NOT NULL,
  `status` int(11) DEFAULT NULL,
  `bfOrder` int(11) DEFAULT NULL,
  `hcOrder` int(11) DEFAULT NULL,
  `pkOrder` int(11) DEFAULT NULL,
  `serverId` int(11) DEFAULT NULL,
  `wingId` int(11) DEFAULT NULL,
  `smallPetId` int(11) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `battlePower` int(11) DEFAULT NULL,
  `groupId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crossepic_top` */

/*Table structure for table `t_crosswar_audition` */

DROP TABLE IF EXISTS `t_crosswar_audition`;

CREATE TABLE `t_crosswar_audition` (
  `id` bigint(64) NOT NULL,
  `uuid` bigint(64) DEFAULT NULL,
  `serverGroupId` int(4) DEFAULT NULL,
  `groupId` int(4) DEFAULT NULL,
  `score` int(4) DEFAULT NULL,
  `battleJson` text,
  `level` int(4) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `vipLeve` int(4) DEFAULT NULL,
  `server` int(4) DEFAULT NULL,
  `gender` int(4) DEFAULT NULL,
  `wingId` bigint(20) DEFAULT NULL,
  `smallPetId` bigint(20) DEFAULT NULL,
  `continuousWin` int(4) DEFAULT NULL,
  `battlePower` int(4) DEFAULT '0',
  `updateScoreTime` bigint(8) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uuidIndex` (`uuid`),
  KEY `serverIdIndex` (`serverGroupId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crosswar_audition` */

/*Table structure for table `t_crosswar_cluster_setting` */

DROP TABLE IF EXISTS `t_crosswar_cluster_setting`;

CREATE TABLE `t_crosswar_cluster_setting` (
  `id` bigint(64) NOT NULL,
  `beginTime` bigint(64) DEFAULT NULL,
  `serverIds` text,
  `isDelete` int(2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crosswar_cluster_setting` */

/*Table structure for table `t_crosswar_person_score` */

DROP TABLE IF EXISTS `t_crosswar_person_score`;

CREATE TABLE `t_crosswar_person_score` (
  `id` bigint(64) NOT NULL,
  `serverGroupId` int(4) DEFAULT NULL,
  `groupId` int(4) DEFAULT NULL,
  `score` int(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crosswar_person_score` */

/*Table structure for table `t_crosswar_setting` */

DROP TABLE IF EXISTS `t_crosswar_setting`;

CREATE TABLE `t_crosswar_setting` (
  `id` int(4) NOT NULL,
  `serverGroupId` int(4) DEFAULT NULL,
  `beginTime` bigint(20) DEFAULT NULL,
  `isDelete` int(2) DEFAULT NULL,
  `freshUpdateTime` bigint(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_crosswar_setting` */

/*Table structure for table `t_daily_task` */

DROP TABLE IF EXISTS `t_daily_task`;

CREATE TABLE `t_daily_task` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `props` varchar(255) DEFAULT NULL,
  `questId` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_daily_task` */

/*Table structure for table `t_day_reward` */

DROP TABLE IF EXISTS `t_day_reward`;

CREATE TABLE `t_day_reward` (
  `uuid` bigint(20) NOT NULL,
  `dayTime` bigint(20) DEFAULT '0',
  `contDayTime` bigint(20) DEFAULT '0',
  `lxdlRewardState` int(11) DEFAULT '0',
  `loginTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_day_reward` */

/*Table structure for table `t_db_version` */

DROP TABLE IF EXISTS `t_db_version`;

CREATE TABLE `t_db_version` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `updateTime` datetime NOT NULL,
  `version` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  UNIQUE KEY `version` (`version`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_db_version` */

/*Table structure for table `t_device` */

DROP TABLE IF EXISTS `t_device`;

CREATE TABLE `t_device` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `deviceType` int(11) DEFAULT NULL,
  `deviceVersion` varchar(255) DEFAULT NULL,
  `regionid` varchar(255) DEFAULT NULL,
  `serverid` varchar(255) DEFAULT NULL,
  `updatetime` datetime NOT NULL,
  `userid` bigint(20) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `clientVersion` varchar(255) DEFAULT NULL,
  `deviceID` varchar(255) DEFAULT NULL,
  `localeType` varchar(255) DEFAULT NULL,
  `deviceDetail` varchar(4096) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=46402 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_device` */

/*Table structure for table `t_doing_task` */

DROP TABLE IF EXISTS `t_doing_task`;

CREATE TABLE `t_doing_task` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `props` varchar(255) DEFAULT NULL,
  `questId` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `trace` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_doing_task` */

/*Table structure for table `t_doing_taskguide` */

DROP TABLE IF EXISTS `t_doing_taskguide`;

CREATE TABLE `t_doing_taskguide` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `props` varchar(255) DEFAULT NULL,
  `taskGuideId` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_doing_taskguide` */

/*Table structure for table `t_equip_info` */

DROP TABLE IF EXISTS `t_equip_info`;

CREATE TABLE `t_equip_info` (
  `id` varchar(64) NOT NULL,
  `bagId` int(11) DEFAULT '0',
  `bagSlot` int(11) DEFAULT '0',
  `bind` int(11) DEFAULT NULL,
  `xilian` int(11) DEFAULT NULL,
  `embedStones` varchar(512) DEFAULT NULL,
  `embedslot` int(11) DEFAULT NULL,
  `charId` bigint(20) NOT NULL,
  `wearerId` varchar(64) NOT NULL,
  `coolDownTimePoint` bigint(20) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `curEndure` int(11) DEFAULT NULL,
  `deadline` datetime DEFAULT '2099-01-01 00:00:01',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `overlap` int(11) DEFAULT NULL,
  `properties` varchar(1024) DEFAULT NULL,
  `star` int(11) DEFAULT NULL,
  `templateId` int(11) DEFAULT NULL,
  `upStarCount` int(11) DEFAULT '0',
  `upXilianCount` int(11) DEFAULT '0',
  `enchant` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `charId` (`charId`),
  KEY `charId_bagId` (`charId`,`bagId`),
  KEY `wearerId` (`wearerId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_equip_info` */

/*Table structure for table `t_escort_ship` */

DROP TABLE IF EXISTS `t_escort_ship`;

CREATE TABLE `t_escort_ship` (
  `uuid` bigint(64) NOT NULL,
  `begin_time` bigint(20) DEFAULT '0',
  `rob_time` bigint(20) DEFAULT '0',
  `save_time` bigint(20) DEFAULT '0',
  `ship_quality` int(4) DEFAULT '0',
  `ship_status` int(4) DEFAULT '0',
  `rob_name` varchar(36) DEFAULT NULL,
  `rob_uuid` bigint(64) DEFAULT '0',
  `escort_name` varchar(36) DEFAULT NULL,
  `rob_rewarded` int(4) DEFAULT '0',
  `other_duration` int(4) DEFAULT NULL,
  `rob_uuid_str` text,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_escort_ship` */

/*Table structure for table `t_escort_times` */

DROP TABLE IF EXISTS `t_escort_times`;

CREATE TABLE `t_escort_times` (
  `uuid` bigint(64) NOT NULL,
  `cur_times` int(11) DEFAULT NULL,
  `update_time` bigint(20) DEFAULT NULL,
  `buy_curTimes` int(11) DEFAULT '0',
  `buy_essortTimes` int(11) DEFAULT '0',
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_escort_times` */

/*Table structure for table `t_expedition_puplet_info` */

DROP TABLE IF EXISTS `t_expedition_puplet_info`;

CREATE TABLE `t_expedition_puplet_info` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `cardId` varchar(128) DEFAULT NULL,
  `arrayIndex` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `humanidindex` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_expedition_puplet_info` */

/*Table structure for table `t_fate` */

DROP TABLE IF EXISTS `t_fate`;

CREATE TABLE `t_fate` (
  `id` varchar(128) NOT NULL,
  `templateID` int(11) DEFAULT NULL,
  `ownerID` bigint(64) DEFAULT NULL,
  `bagType` int(11) DEFAULT NULL,
  `bagIndex` int(11) DEFAULT NULL,
  `currExp` int(11) DEFAULT NULL,
  `lockState` smallint(2) DEFAULT NULL,
  `wearId` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `NewIndex1` (`ownerID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_fate` */

/*Table structure for table `t_favorites_info` */

DROP TABLE IF EXISTS `t_favorites_info`;

CREATE TABLE `t_favorites_info` (
  `humanId` bigint(20) NOT NULL,
  `favoritesStatue` smallint(6) NOT NULL DEFAULT '0',
  `favoritesReward` smallint(6) NOT NULL DEFAULT '0',
  `addPlantStatue` smallint(6) NOT NULL DEFAULT '0',
  `addPlantReward` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`humanId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_favorites_info` */

/*Table structure for table `t_ferrum_tree` */

DROP TABLE IF EXISTS `t_ferrum_tree`;

CREATE TABLE `t_ferrum_tree` (
  `human_uuid` bigint(20) NOT NULL,
  `bless_times` int(11) DEFAULT NULL,
  `last_bless_time` bigint(20) DEFAULT NULL,
  `bless_json_str` text,
  `blessed_times` int(11) DEFAULT NULL,
  `blessed_json_str` text,
  `already_harvest` tinyint(4) DEFAULT NULL,
  `last_harvest_time` bigint(20) DEFAULT NULL,
  `pray_times` int(11) DEFAULT NULL,
  `last_pray_time` bigint(20) DEFAULT NULL,
  `shake_times` int(11) DEFAULT NULL,
  `last_shake_time` bigint(20) DEFAULT NULL,
  `last_reset_time_system` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_ferrum_tree` */

/*Table structure for table `t_festival_info` */

DROP TABLE IF EXISTS `t_festival_info`;

CREATE TABLE `t_festival_info` (
  `id` int(11) NOT NULL,
  `stopped` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_festival_info` */

/*Table structure for table `t_finished_quest` */

DROP TABLE IF EXISTS `t_finished_quest`;

CREATE TABLE `t_finished_quest` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `dailyTimes` int(11) DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `questId` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_finished_quest` */

/*Table structure for table `t_finished_taskguide` */

DROP TABLE IF EXISTS `t_finished_taskguide`;

CREATE TABLE `t_finished_taskguide` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `ifEndTaskGuide` int(11) DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `taskGuideId` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_finished_taskguide` */

/*Table structure for table `t_five_recharge` */

DROP TABLE IF EXISTS `t_five_recharge`;

CREATE TABLE `t_five_recharge` (
  `id` bigint(20) NOT NULL,
  `rechargeDate` bigint(20) DEFAULT '0',
  `rechargeTimes` int(11) DEFAULT '0',
  `state` int(11) DEFAULT '0',
  `rechargeMoney` int(11) DEFAULT '0',
  `rewardDate` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_five_recharge` */

/*Table structure for table `t_forbid_iap` */

DROP TABLE IF EXISTS `t_forbid_iap`;

CREATE TABLE `t_forbid_iap` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `isForbid` int(11) DEFAULT '0',
  `forbidKind` int(11) DEFAULT NULL,
  `forbidTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_forbid_iap` */

/*Table structure for table `t_friend_relation` */

DROP TABLE IF EXISTS `t_friend_relation`;

CREATE TABLE `t_friend_relation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `addTime` datetime DEFAULT NULL,
  `friendGroup` int(11) DEFAULT NULL,
  `friendName` varchar(255) DEFAULT NULL,
  `friendUUID` bigint(20) DEFAULT NULL,
  `frindAmity` int(11) DEFAULT NULL,
  `roleUUID` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `roleUUID` (`roleUUID`),
  KEY `roleUUID_friendGroup` (`roleUUID`,`friendGroup`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_friend_relation` */

/*Table structure for table `t_func_switcher` */

DROP TABLE IF EXISTS `t_func_switcher`;

CREATE TABLE `t_func_switcher` (
  `id` int(11) NOT NULL DEFAULT '0',
  `isOpen` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_func_switcher` */

/*Table structure for table `t_funciton` */

DROP TABLE IF EXISTS `t_funciton`;

CREATE TABLE `t_funciton` (
  `id` bigint(20) NOT NULL,
  `content` varchar(512) DEFAULT '[]',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_funciton` */

/*Table structure for table `t_game_notice` */

DROP TABLE IF EXISTS `t_game_notice`;

CREATE TABLE `t_game_notice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `status` int(1) DEFAULT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `content` text,
  PRIMARY KEY (`id`),
  KEY `serverIds` (`serverIds`),
  KEY `serverIds_status` (`serverIds`,`status`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_game_notice` */

/*Table structure for table `t_guild` */

DROP TABLE IF EXISTS `t_guild`;

CREATE TABLE `t_guild` (
  `id` bigint(20) NOT NULL,
  `guildName` varchar(50) NOT NULL,
  `guildLevel` int(11) DEFAULT NULL,
  `guildSymbolLevel` int(11) DEFAULT NULL,
  `guildSymbolName` varchar(50) NOT NULL,
  `messageInfo` varchar(512) DEFAULT NULL,
  `creatorId` bigint(20) DEFAULT NULL,
  `creatorName` varchar(50) NOT NULL,
  `createdTime` datetime NOT NULL,
  `createdYear` int(11) DEFAULT NULL,
  `createdSeason` int(11) DEFAULT NULL,
  `leaderId` bigint(20) DEFAULT NULL,
  `leaderName` varchar(50) NOT NULL,
  `state` int(11) DEFAULT NULL,
  `memberCapacity` int(11) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `props` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `guildName` (`guildName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_guild` */

/*Table structure for table `t_guild_member` */

DROP TABLE IF EXISTS `t_guild_member`;

CREATE TABLE `t_guild_member` (
  `id` bigint(20) NOT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `guildId` bigint(20) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `head` int(11) DEFAULT '0',
  `body` int(11) DEFAULT '0',
  `hair` int(11) DEFAULT '0',
  `feature` int(11) DEFAULT '0',
  `cap` int(11) DEFAULT '0',
  `sceneId` int(11) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `guildRank` int(11) DEFAULT NULL,
  `curContrib` int(11) NOT NULL DEFAULT '0',
  `selfDesc` varchar(255) DEFAULT NULL,
  `state` int(11) DEFAULT NULL,
  `joinTime` datetime DEFAULT NULL,
  `lastOnlineTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `guildId` (`guildId`),
  KEY `roleId` (`roleId`),
  KEY `roleId_guildId` (`roleId`,`guildId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_guild_member` */

/*Table structure for table `t_home_guide` */

DROP TABLE IF EXISTS `t_home_guide`;

CREATE TABLE `t_home_guide` (
  `id` bigint(20) NOT NULL,
  `targetIds` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `t_home_guide` */

/*Table structure for table `t_human_body` */

DROP TABLE IF EXISTS `t_human_body`;

CREATE TABLE `t_human_body` (
  `human_uuid` bigint(20) NOT NULL,
  `curr_body_id` int(11) DEFAULT NULL,
  `unlock_body_1` tinyint(4) DEFAULT NULL,
  `unlock_body_2` tinyint(4) DEFAULT NULL,
  `unlock_body_3` tinyint(4) DEFAULT NULL,
  `unclocked_flag` int(11) DEFAULT '0',
  `json_text` text,
  `pontential_points` int(11) DEFAULT NULL,
  `curr_anger` int(11) DEFAULT NULL,
  `auto_change_body` tinyint(4) DEFAULT '0',
  `auto_draw_cards` int(11) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_human_body` */

/*Table structure for table `t_human_charge` */

DROP TABLE IF EXISTS `t_human_charge`;

CREATE TABLE `t_human_charge` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `open_id` varchar(64) DEFAULT NULL,
  `passport_id` bigint(20) DEFAULT NULL,
  `human_uuid` bigint(20) DEFAULT NULL,
  `sum_money` int(11) DEFAULT NULL,
  `server_name` varchar(8) DEFAULT NULL,
  `take_state` tinyint(1) DEFAULT NULL,
  `last_op_time` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `open_id` (`open_id`),
  KEY `passport_id` (`passport_id`),
  KEY `human_uuid` (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_human_charge` */

/*Table structure for table `t_human_info` */

DROP TABLE IF EXISTS `t_human_info`;

CREATE TABLE `t_human_info` (
  `id` bigint(20) NOT NULL,
  `platform_uuid` varchar(64) DEFAULT NULL,
  `pf` varchar(64) DEFAULT NULL,
  `name` varchar(36) DEFAULT NULL,
  `photo` int(11) NOT NULL DEFAULT '0',
  `createTime` datetime DEFAULT NULL,
  `deleteTime` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `lastLoginIp` varchar(50) DEFAULT NULL,
  `lastLoginTime` datetime DEFAULT NULL,
  `lastLogoutTime` datetime DEFAULT NULL,
  `totalMinute` int(11) NOT NULL DEFAULT '0',
  `onlineStatus` int(11) NOT NULL DEFAULT '0',
  `idleTime` int(11) NOT NULL DEFAULT '0',
  `vipLevel` int(11) NOT NULL DEFAULT '0',
  `lastVipTime` datetime DEFAULT NULL,
  `sceneId` int(11) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '1',
  `alliance_type_id` int(11) NOT NULL DEFAULT '0',
  `gold` int(11) NOT NULL DEFAULT '0',
  `silver` int(11) NOT NULL DEFAULT '0',
  `coupon` int(11) NOT NULL DEFAULT '0',
  `generalMax` int(11) NOT NULL DEFAULT '0',
  `inventoryMax` int(11) NOT NULL DEFAULT '0',
  `townPack` text,
  `heroPack` text,
  `petPack` text,
  `constructionPack` text,
  `technologyPack` text,
  `cdQueuePack` text,
  `guildPack` text,
  `props` text,
  `parentUUId` bigint(20) DEFAULT '0',
  `childUUIds` text,
  `buffPack` text,
  `avatarPack` varchar(256) DEFAULT NULL,
  `lastUpdateTradeTime` datetime DEFAULT NULL,
  `chargeGold` int(11) NOT NULL DEFAULT '0',
  `canHelpCount` int(11) DEFAULT '0',
  `continuouslyPrizePack` text,
  `lastLivenessRefreshTime` bigint(20) DEFAULT '0',
  `reportInfo` text,
  `energy` int(11) NOT NULL,
  `cardArrayNum` int(11) DEFAULT '3',
  `curr_exp` bigint(20) DEFAULT NULL,
  `in_city_id` int(11) DEFAULT NULL,
  `vocation_type` int(11) DEFAULT NULL,
  `girl_flag` int(11) DEFAULT '0',
  `primBagCount` int(11) DEFAULT '18',
  `wuxun` int(11) NOT NULL DEFAULT '0',
  `fightPower` int(11) DEFAULT '0',
  `soul_power` int(11) NOT NULL DEFAULT '0',
  `buyEnergyTimes` int(11) NOT NULL DEFAULT '0',
  `ferrum` int(11) NOT NULL DEFAULT '0',
  `currentGuideId` int(11) DEFAULT '0',
  `pacify` int(11) NOT NULL DEFAULT '0',
  `hunt` int(11) NOT NULL DEFAULT '0',
  `blessing` int(11) DEFAULT '0',
  `yellowYear` int(11) NOT NULL DEFAULT '0',
  `yellowLevel` int(11) DEFAULT '0',
  `command` int(11) NOT NULL DEFAULT '0',
  `charge_total_money` int(11) NOT NULL DEFAULT '0',
  `lastResetEnergyTime` bigint(20) DEFAULT '0',
  `cardExpPool` int(11) DEFAULT '0',
  `cardSoulNum` int(11) DEFAULT '0',
  `goldGift` int(11) DEFAULT '0',
  `groupId` int(11) DEFAULT '0',
  `nameEncodeTag` int(11) DEFAULT '0',
  `alertState` text,
  `storyId` int(11) DEFAULT '0',
  `lastgiveenerytime` bigint(20) DEFAULT '0',
  `lxdl_times` int(11) DEFAULT '0',
  `lxdl_last_time` bigint(20) DEFAULT '0',
  `gemSpiritLev` int(11) DEFAULT '0',
  `gemSpiritNum` int(11) DEFAULT '0',
  `blueYear` int(11) DEFAULT '0',
  `blueSuper` int(11) DEFAULT '0',
  `blueLevel` int(11) DEFAULT '0',
  `l3366level` int(11) DEFAULT '0',
  `wingId` int(11) DEFAULT '0',
  `expedtionExp` int(11) DEFAULT '0',
  `tigerCoin` int(11) DEFAULT '0',
  `dragonCoin` int(11) DEFAULT '0',
  `smallPetId` varchar(255) DEFAULT NULL,
  `petIconId` int(11) DEFAULT '0',
  `hasWeared` int(11) DEFAULT '0',
  `server_name` varchar(48) DEFAULT NULL,
  `orig_name` varchar(96) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `sceneId` (`sceneId`),
  KEY `passportId` (`platform_uuid`),
  KEY `fightPower` (`fightPower`),
  KEY `vocation_type` (`vocation_type`),
  KEY `server_name` (`server_name`),
  KEY `orig_name` (`orig_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_human_info` */

/*Table structure for table `t_human_info_cache` */

DROP TABLE IF EXISTS `t_human_info_cache`;

CREATE TABLE `t_human_info_cache` (
  `id` bigint(20) NOT NULL,
  `alliance` smallint(6) DEFAULT NULL,
  `avatarPack` varchar(255) DEFAULT NULL,
  `buffPack` text,
  `guildName` varchar(255) DEFAULT NULL,
  `job` int(11) DEFAULT NULL,
  `lastLogoutTime` datetime DEFAULT NULL,
  `lastLoginTime` datetime DEFAULT NULL,
  `level` smallint(6) DEFAULT NULL,
  `fightPower` int(11) DEFAULT NULL,
  `name` varchar(36) DEFAULT NULL,
  `openedFuncPack` varchar(255) DEFAULT NULL,
  `photo` smallint(6) DEFAULT NULL,
  `sceneId` int(11) DEFAULT NULL,
  `sex` int(11) DEFAULT NULL,
  `silver` int(11) NOT NULL,
  `silverMax` int(11) NOT NULL,
  `yellowLevel` int(11) DEFAULT '0',
  `yellowYear` int(11) DEFAULT '0',
  `vipLevel` int(11) DEFAULT '0',
  `createTime` datetime DEFAULT NULL,
  `gemSpiritLev` int(11) DEFAULT '0',
  `blueYear` int(11) DEFAULT '0',
  `blueSuper` int(11) DEFAULT '0',
  `blueLevel` int(11) DEFAULT '0',
  `l3366level` int(11) DEFAULT '0',
  `wingId` int(11) DEFAULT '0',
  `smallPetId` varchar(255) DEFAULT NULL,
  `petIconId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_human_info_cache` */

/*Table structure for table `t_human_level` */

DROP TABLE IF EXISTS `t_human_level`;

CREATE TABLE `t_human_level` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `open_id` varchar(64) DEFAULT NULL,
  `passport_id` bigint(20) DEFAULT NULL,
  `human_uuid` bigint(20) DEFAULT NULL,
  `human_level` int(11) DEFAULT NULL,
  `server_name` varchar(8) DEFAULT NULL,
  `take_state` tinyint(1) DEFAULT NULL,
  `last_op_time` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_human_level` */

/*Table structure for table `t_hunt` */

DROP TABLE IF EXISTS `t_hunt`;

CREATE TABLE `t_hunt` (
  `id` bigint(64) NOT NULL,
  `primaryCapcity` int(11) DEFAULT NULL,
  `content` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_hunt` */

/*Table structure for table `t_itemex_info` */

DROP TABLE IF EXISTS `t_itemex_info`;

CREATE TABLE `t_itemex_info` (
  `id` varchar(64) NOT NULL,
  `bagId` int(11) DEFAULT NULL,
  `bagSlot` int(11) DEFAULT NULL,
  `bind` int(11) DEFAULT NULL,
  `charId` bigint(20) NOT NULL,
  `wearerId` varchar(64) NOT NULL,
  `coolDownTimePoint` bigint(20) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `curEndure` int(11) DEFAULT NULL,
  `deadline` datetime DEFAULT '2099-01-01 00:00:01',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `overlap` int(11) DEFAULT NULL,
  `properties` varchar(1024) DEFAULT NULL,
  `templateId` int(11) DEFAULT NULL,
  `curSocket` int(11) DEFAULT '0',
  `itemType` int(11) DEFAULT '0',
  `itemSubType` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`),
  KEY `charId_bagId` (`charId`,`bagId`),
  KEY `wearerId` (`wearerId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_itemex_info` */

/*Table structure for table `t_kfc_eventdata` */

DROP TABLE IF EXISTS `t_kfc_eventdata`;

CREATE TABLE `t_kfc_eventdata` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `scriptName` varchar(64) DEFAULT NULL,
  `excuteTime` bigint(20) DEFAULT '0',
  `finishTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `scriptName` (`scriptName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='开服活动';

/*Data for the table `t_kfc_eventdata` */

/*Table structure for table `t_kfc_opensettings` */

DROP TABLE IF EXISTS `t_kfc_opensettings`;

CREATE TABLE `t_kfc_opensettings` (
  `id` int(11) NOT NULL,
  `openTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='开服设置';

/*Data for the table `t_kfc_opensettings` */

/*Table structure for table `t_kfc_rankdata` */

DROP TABLE IF EXISTS `t_kfc_rankdata`;

CREATE TABLE `t_kfc_rankdata` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `scriptName` varchar(64) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT '0',
  `jobType` int(11) DEFAULT '0',
  `level` int(11) DEFAULT '0',
  `ranktype` int(11) DEFAULT '0',
  `rank` int(11) DEFAULT '0',
  `rankData` int(11) DEFAULT '0',
  `rewardState` int(11) DEFAULT '0',
  `ranktime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `scriptName` (`scriptName`,`roleId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='开服大奖奖励';

/*Data for the table `t_kfc_rankdata` */

/*Table structure for table `t_kfc_rewarddata` */

DROP TABLE IF EXISTS `t_kfc_rewarddata`;

CREATE TABLE `t_kfc_rewarddata` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `scriptName` varchar(64) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT '0',
  `rewardState` int(11) DEFAULT '0',
  `ranktype` int(11) DEFAULT '0',
  `rewardData` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `roleId` (`roleId`,`scriptName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='开服普通奖励(日志)';

/*Data for the table `t_kfc_rewarddata` */

/*Table structure for table `t_knowledge` */

DROP TABLE IF EXISTS `t_knowledge`;

CREATE TABLE `t_knowledge` (
  `id` bigint(20) NOT NULL,
  `question` varchar(512) DEFAULT '[]',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_knowledge` */

/*Table structure for table `t_l3366vip_info` */

DROP TABLE IF EXISTS `t_l3366vip_info`;

CREATE TABLE `t_l3366vip_info` (
  `id` bigint(20) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '0',
  `yearVipLevel` int(11) NOT NULL DEFAULT '0',
  `highVip` int(11) NOT NULL DEFAULT '0',
  `recordTime` bigint(20) NOT NULL DEFAULT '0',
  `newType` int(11) NOT NULL DEFAULT '0',
  `newRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `firstType` int(11) NOT NULL DEFAULT '0',
  `firstRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `everyDayJson` varchar(512) DEFAULT NULL,
  `everyRecordTime` bigint(20) DEFAULT '0',
  `charge_times` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_l3366vip_info` */

/*Table structure for table `t_landlords` */

DROP TABLE IF EXISTS `t_landlords`;

CREATE TABLE `t_landlords` (
  `humanId` bigint(20) NOT NULL,
  `humanName` varchar(50) DEFAULT NULL,
  `captureTimes` int(11) DEFAULT '0',
  `rescueTimes` int(11) DEFAULT '0',
  `slavesInterTimes` int(11) DEFAULT '0',
  `revoltTimes` int(11) DEFAULT '0',
  `protectTimeCd` bigint(20) DEFAULT '0',
  `workTime` bigint(20) DEFAULT '0',
  `landlordsInterTimes` int(11) DEFAULT '0',
  `slaveList` text,
  `defeatedList` text,
  `enemyList` text,
  `masterId` bigint(20) DEFAULT NULL,
  `workExp` int(11) DEFAULT '0',
  `captureTime` bigint(20) DEFAULT '0',
  `obtainExp` int(11) DEFAULT '0',
  `dayUpdateTime` bigint(20) DEFAULT '0',
  `eventList` text,
  PRIMARY KEY (`humanId`),
  KEY `masterId` (`masterId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_landlords` */

/*Table structure for table `t_level_buy` */

DROP TABLE IF EXISTS `t_level_buy`;

CREATE TABLE `t_level_buy` (
  `uuid` bigint(20) NOT NULL DEFAULT '0',
  `level` varchar(200) NOT NULL DEFAULT '[]',
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_level_buy` */

/*Table structure for table `t_levelbuy_activity` */

DROP TABLE IF EXISTS `t_levelbuy_activity`;

CREATE TABLE `t_levelbuy_activity` (
  `id` bigint(20) NOT NULL,
  `start_time` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_levelbuy_activity` */

/*Table structure for table `t_lightstep_activity` */

DROP TABLE IF EXISTS `t_lightstep_activity`;

CREATE TABLE `t_lightstep_activity` (
  `id` bigint(11) NOT NULL,
  `startTime` bigint(20) NOT NULL,
  `endTime` bigint(20) NOT NULL,
  `activityRules` text NOT NULL,
  `activityProp` text NOT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_lightstep_activity` */

/*Table structure for table `t_limited_card` */

DROP TABLE IF EXISTS `t_limited_card`;

CREATE TABLE `t_limited_card` (
  `humanUuid` bigint(20) DEFAULT NULL,
  `humanName` varchar(50) DEFAULT NULL,
  `hireTimes` int(10) DEFAULT NULL,
  `lastFreeHireTime` bigint(20) DEFAULT NULL,
  `score` int(10) DEFAULT NULL,
  `rewardState` tinyint(1) DEFAULT NULL,
  `buyStatus` text,
  `lastScore` int(11) DEFAULT '0',
  `hireTime` bigint(20) DEFAULT '0',
  KEY `humanUuid` (`humanUuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_limited_card` */

/*Table structure for table `t_limited_card2` */

DROP TABLE IF EXISTS `t_limited_card2`;

CREATE TABLE `t_limited_card2` (
  `humanUuid` bigint(20) DEFAULT NULL,
  `humanName` varchar(50) DEFAULT NULL,
  `hireTimes` int(10) DEFAULT NULL,
  `lastFreeHireTime` bigint(20) DEFAULT NULL,
  `score` int(10) DEFAULT NULL,
  `rewardState` tinyint(1) DEFAULT NULL,
  `hireTime` bigint(20) DEFAULT '0',
  KEY `humanUuid` (`humanUuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_limited_card2` */

/*Table structure for table `t_limited_card_config` */

DROP TABLE IF EXISTS `t_limited_card_config`;

CREATE TABLE `t_limited_card_config` (
  `functionId` bigint(20) NOT NULL,
  `addCard` varchar(100) DEFAULT NULL,
  `addProbability` varchar(100) DEFAULT NULL,
  `reward1` varchar(255) DEFAULT NULL,
  `reward2` varchar(255) DEFAULT NULL,
  `reward3` varchar(255) DEFAULT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  `endTime` bigint(20) DEFAULT NULL,
  `rewardScore` int(10) DEFAULT NULL,
  `giftReward` varchar(512) NOT NULL,
  `giftResId` varchar(512) NOT NULL DEFAULT '',
  `giftItemTips` varchar(512) NOT NULL DEFAULT '',
  `shopMsg` text,
  PRIMARY KEY (`functionId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_limited_card_config` */

/*Table structure for table `t_limited_card_config2` */

DROP TABLE IF EXISTS `t_limited_card_config2`;

CREATE TABLE `t_limited_card_config2` (
  `functionId` bigint(20) NOT NULL,
  `addCard` varchar(100) DEFAULT NULL,
  `addProbability` varchar(100) DEFAULT NULL,
  `reward1` varchar(255) DEFAULT NULL,
  `reward2` varchar(255) DEFAULT NULL,
  `reward3` varchar(255) DEFAULT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  `endTime` bigint(20) DEFAULT NULL,
  `rewardScore` int(10) DEFAULT NULL,
  `giftReward` varchar(512) NOT NULL,
  `giftResId` varchar(512) NOT NULL DEFAULT '',
  `giftItemTips` varchar(512) NOT NULL DEFAULT '',
  PRIMARY KEY (`functionId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_limited_card_config2` */

/*Table structure for table `t_liveness` */

DROP TABLE IF EXISTS `t_liveness`;

CREATE TABLE `t_liveness` (
  `human_uuid` bigint(20) NOT NULL,
  `liveness` int(11) DEFAULT NULL,
  `took_reward_id_str` text,
  `last_reset_time` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_liveness` */

/*Table structure for table `t_local_notification` */

DROP TABLE IF EXISTS `t_local_notification`;

CREATE TABLE `t_local_notification` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `notiName` varchar(255) DEFAULT NULL,
  `fireDate` int(11) DEFAULT NULL,
  `repeatInterval` int(11) DEFAULT NULL,
  `alertBody` varchar(255) DEFAULT NULL,
  `alertAction` varchar(255) DEFAULT NULL,
  `messageValue` varchar(255) DEFAULT NULL,
  `repeatCount` int(11) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `currState` int(1) NOT NULL DEFAULT '0',
  `sendTime` datetime DEFAULT NULL,
  `passportIds` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_local_notification` */

/*Table structure for table `t_mail_info` */

DROP TABLE IF EXISTS `t_mail_info`;

CREATE TABLE `t_mail_info` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `sendId` bigint(20) DEFAULT NULL,
  `sendName` varchar(36) DEFAULT NULL,
  `recId` bigint(20) DEFAULT NULL,
  `recName` varchar(36) DEFAULT NULL,
  `title` varchar(36) DEFAULT NULL,
  `content` text,
  `msgType` int(11) NOT NULL,
  `msgStatus` int(11) NOT NULL,
  `createTimeInGame` varchar(36) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `deleteTime` datetime DEFAULT NULL,
  `hasAttachment` bit(1) DEFAULT b'0',
  `attachmentProps` text,
  `attachmentValid` bit(1) DEFAULT b'0',
  `boxType` int(11) NOT NULL,
  `attachment_notice` text,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`),
  KEY `recId` (`recId`),
  KEY `title` (`title`),
  KEY `recId_msgType` (`recId`,`msgType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mail_info` */

/*Table structure for table `t_mentorship_data` */

DROP TABLE IF EXISTS `t_mentorship_data`;

CREATE TABLE `t_mentorship_data` (
  `charid` bigint(20) NOT NULL,
  `cntRewardMax` int(11) NOT NULL DEFAULT '0',
  `cntRewardMsg` varchar(1024) NOT NULL,
  `cntRewardTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `olRewardMax` int(11) DEFAULT '0',
  `olRewardMsg` varchar(1024) NOT NULL,
  `olRewardTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `updateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`charid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mentorship_data` */

/*Table structure for table `t_mentorship_info` */

DROP TABLE IF EXISTS `t_mentorship_info`;

CREATE TABLE `t_mentorship_info` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `targetCharId` bigint(20) DEFAULT NULL,
  `targetCharName` varchar(255) DEFAULT NULL,
  `relationType` int(11) DEFAULT NULL,
  `relationGroup` int(11) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `applyMsg` varchar(255) DEFAULT NULL,
  `friendship` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mentorship_info` */

/*Table structure for table `t_mentorship_login` */

DROP TABLE IF EXISTS `t_mentorship_login`;

CREATE TABLE `t_mentorship_login` (
  `id` varchar(60) NOT NULL,
  `charid` bigint(20) NOT NULL,
  `stucharid` bigint(20) NOT NULL,
  `logintime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `intindex` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charid` (`charid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mentorship_login` */

/*Table structure for table `t_midas_touch` */

DROP TABLE IF EXISTS `t_midas_touch`;

CREATE TABLE `t_midas_touch` (
  `human_uuid` bigint(20) NOT NULL,
  `task_progress` bigint(10) DEFAULT '0',
  `update_time` bigint(20) DEFAULT '0',
  `first_coin` int(4) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_midas_touch` */

/*Table structure for table `t_mission_enemy_info` */

DROP TABLE IF EXISTS `t_mission_enemy_info`;

CREATE TABLE `t_mission_enemy_info` (
  `id` int(11) NOT NULL,
  `countOfTM` int(11) NOT NULL DEFAULT '0',
  `countOfZX` int(11) NOT NULL DEFAULT '0',
  `countOfGCGJ` int(11) NOT NULL DEFAULT '0',
  `reportList` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mission_enemy_info` */

/*Table structure for table `t_modify_shelf` */

DROP TABLE IF EXISTS `t_modify_shelf`;

CREATE TABLE `t_modify_shelf` (
  `id` varchar(32) NOT NULL,
  `shopShelfId` int(11) NOT NULL,
  `params` varchar(1000) NOT NULL,
  `beginTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endTime` timestamp NULL DEFAULT '0000-00-00 00:00:00',
  `modifyUser` varchar(100) DEFAULT NULL,
  `isUse` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_modify_shelf` */

/*Table structure for table `t_modifyitem_price` */

DROP TABLE IF EXISTS `t_modifyitem_price`;

CREATE TABLE `t_modifyitem_price` (
  `id` varchar(32) NOT NULL,
  `itemId` int(11) NOT NULL,
  `params` varchar(1000) NOT NULL,
  `beginTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endTime` timestamp NULL DEFAULT '0000-00-00 00:00:00',
  `modifyUser` varchar(100) DEFAULT NULL,
  `isUse` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_modifyitem_price` */

/*Table structure for table `t_money_bowl` */

DROP TABLE IF EXISTS `t_money_bowl`;

CREATE TABLE `t_money_bowl` (
  `id` bigint(20) NOT NULL,
  `moneyTimes` int(11) DEFAULT '0',
  `moneyTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_money_bowl` */

/*Table structure for table `t_money_tree` */

DROP TABLE IF EXISTS `t_money_tree`;

CREATE TABLE `t_money_tree` (
  `human_uuid` bigint(20) NOT NULL,
  `bless_times` int(11) DEFAULT NULL,
  `last_bless_time` bigint(20) DEFAULT NULL,
  `bless_json_str` text,
  `blessed_times` int(11) DEFAULT NULL,
  `blessed_json_str` text,
  `already_harvest` tinyint(4) DEFAULT NULL,
  `last_harvest_time` bigint(20) DEFAULT NULL,
  `pray_times` int(11) DEFAULT NULL,
  `last_pray_time` bigint(20) DEFAULT NULL,
  `shake_times` int(11) DEFAULT NULL,
  `last_shake_time` bigint(20) DEFAULT NULL,
  `last_reset_time_system` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_money_tree` */

/*Table structure for table `t_mount_advance` */

DROP TABLE IF EXISTS `t_mount_advance`;

CREATE TABLE `t_mount_advance` (
  `uuid` bigint(64) NOT NULL,
  `currMountId` int(4) DEFAULT NULL,
  `currAdvance` int(4) DEFAULT NULL,
  `currStar` int(4) DEFAULT NULL,
  `currSkill` int(4) DEFAULT NULL,
  `currExp` int(4) DEFAULT NULL,
  `currRideAdvance` int(4) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mount_advance` */

/*Table structure for table `t_mount_huanhua` */

DROP TABLE IF EXISTS `t_mount_huanhua`;

CREATE TABLE `t_mount_huanhua` (
  `uuid` bigint(64) NOT NULL,
  `huanhuaJson` text,
  `hasHuanHuaId` int(4) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mount_huanhua` */

/*Table structure for table `t_mount_rank` */

DROP TABLE IF EXISTS `t_mount_rank`;

CREATE TABLE `t_mount_rank` (
  `id` bigint(64) NOT NULL,
  `fightPower` int(11) DEFAULT NULL,
  `advanceLevel` int(11) DEFAULT NULL,
  `modelId` int(11) DEFAULT NULL,
  `star` int(11) DEFAULT NULL,
  `advanceStr` text,
  `huanhuaStr` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mount_rank` */

/*Table structure for table `t_mount_times` */

DROP TABLE IF EXISTS `t_mount_times`;

CREATE TABLE `t_mount_times` (
  `uuid` bigint(64) NOT NULL,
  `hasTimes` int(4) DEFAULT NULL,
  `updateTime` bigint(8) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mount_times` */

/*Table structure for table `t_mystical_store` */

DROP TABLE IF EXISTS `t_mystical_store`;

CREATE TABLE `t_mystical_store` (
  `id` bigint(20) NOT NULL,
  `flush_time` bigint(20) DEFAULT NULL,
  `flush_times` int(11) DEFAULT NULL,
  `id0` int(11) DEFAULT NULL,
  `id1` int(11) DEFAULT NULL,
  `id2` int(11) DEFAULT NULL,
  `id3` int(11) DEFAULT NULL,
  `id4` int(11) DEFAULT NULL,
  `id5` int(11) DEFAULT NULL,
  `id6` int(11) DEFAULT NULL,
  `id7` int(11) DEFAULT NULL,
  `id8` int(11) DEFAULT NULL,
  `id9` int(11) DEFAULT NULL,
  `id10` int(11) DEFAULT NULL,
  `id11` int(11) DEFAULT NULL,
  `state0` tinyint(1) DEFAULT NULL,
  `state1` tinyint(1) DEFAULT NULL,
  `state2` tinyint(1) DEFAULT NULL,
  `state3` tinyint(1) DEFAULT NULL,
  `state4` tinyint(1) DEFAULT NULL,
  `state5` tinyint(1) DEFAULT NULL,
  `state6` tinyint(1) DEFAULT NULL,
  `state7` tinyint(1) DEFAULT NULL,
  `state8` tinyint(1) DEFAULT NULL,
  `state9` tinyint(1) DEFAULT NULL,
  `state10` tinyint(1) DEFAULT NULL,
  `state11` tinyint(1) DEFAULT NULL,
  `hand_flush_time` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_mystical_store` */

/*Table structure for table `t_observatory` */

DROP TABLE IF EXISTS `t_observatory`;

CREATE TABLE `t_observatory` (
  `Id` bigint(20) NOT NULL,
  `lastTimes` int(11) NOT NULL DEFAULT '0',
  `finishTimes` int(11) NOT NULL DEFAULT '0',
  `todayFinishTimes` int(11) NOT NULL DEFAULT '0',
  `statues` int(11) NOT NULL DEFAULT '1',
  `statueParams` varchar(500) DEFAULT NULL,
  `updataTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `todayExps` int(11) NOT NULL DEFAULT '0',
  `getRewardBox` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_observatory` */

/*Table structure for table `t_onlineServer_buy` */

DROP TABLE IF EXISTS `t_onlineServer_buy`;

CREATE TABLE `t_onlineServer_buy` (
  `id` bigint(22) NOT NULL,
  `itemId` int(11) DEFAULT NULL,
  `upTime` bigint(22) DEFAULT NULL,
  `downTime` bigint(22) DEFAULT NULL,
  `count` int(11) DEFAULT NULL,
  `updateTime` bigint(22) DEFAULT NULL,
  `limitCount` int(11) DEFAULT NULL,
  `oldPrice` int(11) DEFAULT NULL,
  `nowPrice` int(11) DEFAULT NULL,
  `quility` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `state` int(11) DEFAULT '0',
  `isResetPlayer` int(11) DEFAULT '0',
  `isResetServer` int(11) DEFAULT '0',
  `lastCount` int(11) DEFAULT '0',
  `showindex` int(11) DEFAULT NULL,
  `currencyType` int(3) DEFAULT '0',
  `gradeId` int(7) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_onlineServer_buy` */

/*Table structure for table `t_online_buy` */

DROP TABLE IF EXISTS `t_online_buy`;

CREATE TABLE `t_online_buy` (
  `id` bigint(22) NOT NULL,
  `recode` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_online_buy` */

/*Table structure for table `t_online_reward` */

DROP TABLE IF EXISTS `t_online_reward`;

CREATE TABLE `t_online_reward` (
  `id` bigint(20) NOT NULL,
  `lastRewardTime` bigint(20) NOT NULL DEFAULT '0',
  `total` bigint(20) NOT NULL,
  `rewardId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_online_reward` */

/*Table structure for table `t_opertions_info` */

DROP TABLE IF EXISTS `t_opertions_info`;

CREATE TABLE `t_opertions_info` (
  `id` int(11) NOT NULL,
  `optName` varchar(100) DEFAULT NULL,
  `optDesc` varchar(2000) DEFAULT NULL,
  `optUrl` varchar(500) DEFAULT NULL,
  `smallIcon` varchar(100) DEFAULT NULL,
  `bigIcon` varchar(100) DEFAULT NULL,
  `begTimes` varchar(100) DEFAULT NULL,
  `endTimes` varchar(100) DEFAULT NULL,
  `sortindex` int(13) NOT NULL DEFAULT '0',
  `isshow` int(13) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_opertions_info` */

/*Table structure for table `t_outline_human_data` */

DROP TABLE IF EXISTS `t_outline_human_data`;

CREATE TABLE `t_outline_human_data` (
  `human_uuid` bigint(20) NOT NULL,
  `curr_attk_hit` int(11) DEFAULT NULL,
  `curr_attk_pow` int(11) DEFAULT NULL,
  `curr_defence` int(11) DEFAULT NULL,
  `curr_max_hp` int(11) DEFAULT NULL,
  `curr_crit` int(11) DEFAULT NULL,
  `curr_crit_defe` int(11) DEFAULT NULL,
  `curr_dodge` int(11) DEFAULT NULL,
  `curr_wreck` int(11) DEFAULT NULL,
  `curr_wreck_defe` int(11) DEFAULT NULL,
  `curr_fight_value` int(11) DEFAULT '10',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_outline_human_data` */

/*Table structure for table `t_pacify` */

DROP TABLE IF EXISTS `t_pacify`;

CREATE TABLE `t_pacify` (
  `id` bigint(64) NOT NULL,
  `content` text,
  `type1Times` int(11) DEFAULT '0',
  `type2Times` int(11) DEFAULT '0',
  `type3Times` int(11) DEFAULT '0',
  `lastType3UsedTime` bigint(64) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_pacify` */

/*Table structure for table `t_pacify_notice` */

DROP TABLE IF EXISTS `t_pacify_notice`;

CREATE TABLE `t_pacify_notice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actionTime` bigint(32) DEFAULT NULL,
  `name` varchar(256) NOT NULL,
  `uuid` bigint(64) DEFAULT NULL,
  `itemId` int(12) DEFAULT NULL,
  `type` int(8) DEFAULT NULL,
  `itemNum` int(6) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_pacify_notice` */

/*Table structure for table `t_pay_order` */

DROP TABLE IF EXISTS `t_pay_order`;

CREATE TABLE `t_pay_order` (
  `order_id` varchar(128) COLLATE utf8_bin NOT NULL,
  `platform_uuid` varchar(64) COLLATE utf8_bin DEFAULT NULL,
  `pf` varchar(64) COLLATE utf8_bin DEFAULT NULL,
  `server_name` varchar(32) COLLATE utf8_bin DEFAULT NULL,
  `role_uuid` bigint(8) DEFAULT NULL,
  `role_name` varchar(32) COLLATE utf8_bin DEFAULT NULL,
  `gold` int(8) DEFAULT NULL,
  `rmb` int(64) DEFAULT NULL,
  `order_time` bigint(11) DEFAULT NULL,
  `curr_state` tinyint(20) DEFAULT '0',
  `state_modify_time` bigint(64) DEFAULT NULL,
  PRIMARY KEY (`order_id`),
  KEY `userId` (`rmb`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_pay_order` */

/*Table structure for table `t_pet_info` */

DROP TABLE IF EXISTS `t_pet_info`;

CREATE TABLE `t_pet_info` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `type` int(11) NOT NULL DEFAULT '0',
  `templateId` int(11) NOT NULL DEFAULT '0',
  `createDate` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `hired` int(11) NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `photo` int(11) NOT NULL DEFAULT '0',
  `description` varchar(250) DEFAULT NULL,
  `avatar` int(11) DEFAULT '0',
  `hair` int(11) DEFAULT '0',
  `feature` int(11) DEFAULT '0',
  `cap` int(11) DEFAULT '0',
  `attrGroup` int(11) NOT NULL DEFAULT '0',
  `soldierId` int(11) NOT NULL DEFAULT '0',
  `skillId` int(11) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `exp` bigint(20) NOT NULL DEFAULT '0',
  `soldierAmount` int(11) NOT NULL DEFAULT '0',
  `basicForceGrade` int(11) NOT NULL DEFAULT '0',
  `leadershipAdded` int(11) NOT NULL DEFAULT '0',
  `mightAdded` int(11) NOT NULL DEFAULT '0',
  `intellectAdded` int(11) NOT NULL DEFAULT '0',
  `trainingType` int(11) NOT NULL DEFAULT '0',
  `trainingEndTime` datetime DEFAULT NULL,
  `trainingGetExpTime` datetime DEFAULT NULL,
  `lastLearnGiftResult` varchar(250) DEFAULT NULL,
  `learnedSoldierInfo` text,
  `learnedSkillInfo` text,
  `huntLevel` int(11) DEFAULT NULL,
  `clearPointCount` int(11) DEFAULT '0',
  `clearSoliderPointCount` int(11) DEFAULT '0',
  `huntBagSize` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `IX_charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_pet_info` */

/*Table structure for table `t_pet_temp_info` */

DROP TABLE IF EXISTS `t_pet_temp_info`;

CREATE TABLE `t_pet_temp_info` (
  `id` int(11) NOT NULL,
  `zl` int(11) DEFAULT NULL,
  `zs` int(11) DEFAULT NULL,
  `zy` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_pet_temp_info` */

/*Table structure for table `t_prize` */

DROP TABLE IF EXISTS `t_prize`;

CREATE TABLE `t_prize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `coin` varchar(255) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `item` varchar(255) DEFAULT NULL,
  `pet` varchar(255) DEFAULT NULL,
  `prizeId` int(11) DEFAULT NULL,
  `prizeName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_prize` */

/*Table structure for table `t_puppet_info` */

DROP TABLE IF EXISTS `t_puppet_info`;

CREATE TABLE `t_puppet_info` (
  `id` varchar(32) NOT NULL,
  `charid` bigint(20) DEFAULT NULL,
  `cardId` varchar(128) DEFAULT NULL,
  `arrayIndex` int(11) DEFAULT NULL,
  `smallPetId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `humanidindex` (`charid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_puppet_info` */

/*Table structure for table `t_puppetcache_info` */

DROP TABLE IF EXISTS `t_puppetcache_info`;

CREATE TABLE `t_puppetcache_info` (
  `id` varchar(64) NOT NULL,
  `charid` bigint(20) NOT NULL,
  `cardId` varchar(64) DEFAULT NULL,
  `arrayIndex` tinyint(4) DEFAULT NULL,
  `templateId` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `exp` int(11) DEFAULT NULL,
  `needsExp` int(11) DEFAULT NULL,
  `addEvo` int(11) DEFAULT NULL,
  `quallity` int(11) DEFAULT NULL,
  `fightPower` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `phySkill` varchar(100) DEFAULT NULL,
  `destinySkill` varchar(100) DEFAULT NULL,
  `rageSkill` varchar(100) DEFAULT NULL,
  `innateSkill` varchar(200) DEFAULT NULL,
  `propsOrigMap` varchar(400) DEFAULT NULL,
  `pofang` int(11) DEFAULT '0',
  `kangpo` int(11) DEFAULT '0',
  `wingId` int(11) DEFAULT '0',
  `petId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charid` (`charid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_puppetcache_info` */

/*Table structure for table `t_qq_invite_reward` */

DROP TABLE IF EXISTS `t_qq_invite_reward`;

CREATE TABLE `t_qq_invite_reward` (
  `human_uuid` bigint(20) NOT NULL,
  `take_reward_0` int(11) DEFAULT NULL,
  `take_reward_1` int(11) DEFAULT NULL,
  `take_reward_2` int(11) DEFAULT NULL,
  `take_reward_3` int(11) DEFAULT NULL,
  `take_reward_4` int(11) DEFAULT NULL,
  `take_reward_5` int(11) DEFAULT NULL,
  `take_reward_6` int(11) DEFAULT NULL,
  `take_reward_7` int(11) DEFAULT NULL,
  `take_reward_8` int(11) DEFAULT NULL,
  `take_reward_9` int(11) DEFAULT NULL,
  `take_reward_a` int(11) DEFAULT NULL,
  `take_reward_b` int(11) DEFAULT NULL,
  `take_reward_c` int(11) DEFAULT NULL,
  `take_reward_d` int(11) DEFAULT NULL,
  `take_reward_e` int(11) DEFAULT NULL,
  `take_reward_f` int(11) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_qq_invite_reward` */

/*Table structure for table `t_qq_invite_who` */

DROP TABLE IF EXISTS `t_qq_invite_who`;

CREATE TABLE `t_qq_invite_who` (
  `be_invited_open_id` varchar(64) NOT NULL,
  `from_open_id` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`be_invited_open_id`),
  KEY `from_open_id` (`from_open_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_qq_invite_who` */

/*Table structure for table `t_recharge_activity` */

DROP TABLE IF EXISTS `t_recharge_activity`;

CREATE TABLE `t_recharge_activity` (
  `human_uuid` bigint(20) NOT NULL,
  `current_id` int(11) NOT NULL DEFAULT '0',
  `first_charge` int(4) NOT NULL DEFAULT '0',
  `rewarded_id` int(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_recharge_activity` */

/*Table structure for table `t_relation_info` */

DROP TABLE IF EXISTS `t_relation_info`;

CREATE TABLE `t_relation_info` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `targetCharId` bigint(20) DEFAULT NULL,
  `targetCharName` varchar(255) DEFAULT NULL,
  `relationType` int(11) DEFAULT NULL,
  `relationGroup` int(11) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `applyMsg` varchar(255) DEFAULT NULL,
  `friendship` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_relation_info` */

/*Table structure for table `t_repeattask_log` */

DROP TABLE IF EXISTS `t_repeattask_log`;

CREATE TABLE `t_repeattask_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) DEFAULT NULL,
  `taskId` int(11) DEFAULT NULL,
  `taskStatus` tinyint(4) DEFAULT NULL,
  `taskFinishType` tinyint(4) DEFAULT NULL,
  `finishTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM AUTO_INCREMENT=1263087 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_repeattask_log` */

/*Table structure for table `t_reward_back` */

DROP TABLE IF EXISTS `t_reward_back`;

CREATE TABLE `t_reward_back` (
  `uuid` bigint(20) NOT NULL,
  `lastTime` bigint(20) DEFAULT NULL,
  `singleWar` text,
  `tower1` text,
  `tower2` text,
  `teamWar` text,
  `challenge` text,
  `singleArena` text,
  `worldBoss` text,
  `moneyTree` text,
  `observatory` text,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_reward_back` */

/*Table structure for table `t_reward_center` */

DROP TABLE IF EXISTS `t_reward_center`;

CREATE TABLE `t_reward_center` (
  `id` varchar(64) NOT NULL,
  `type` int(11) NOT NULL,
  `rewarddate` bigint(20) NOT NULL,
  `rewardvalues` varchar(2048) NOT NULL,
  `rewardparams` varchar(512) NOT NULL,
  `rewardstatus` int(11) NOT NULL DEFAULT '0',
  `charId` bigint(20) NOT NULL,
  PRIMARY KEY (`id`,`rewardstatus`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_reward_center` */

/*Table structure for table `t_rewards_log` */

DROP TABLE IF EXISTS `t_rewards_log`;

CREATE TABLE `t_rewards_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `dispatcher` bigint(20) DEFAULT '0',
  `charid` bigint(20) NOT NULL,
  `rewardId` int(11) NOT NULL,
  `scriptName` varchar(64) NOT NULL,
  `params` varchar(128) NOT NULL,
  `provider` varchar(1024) NOT NULL,
  `receive` int(11) DEFAULT '0',
  `belong_id` int(11) DEFAULT NULL,
  `rewardTime` bigint(20) NOT NULL DEFAULT '0',
  `moduleId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charid` (`charid`),
  KEY `belongID` (`belong_id`),
  KEY `rewardTime` (`rewardTime`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_rewards_log` */

/*Table structure for table `t_role_armygroup` */

DROP TABLE IF EXISTS `t_role_armygroup`;

CREATE TABLE `t_role_armygroup` (
  `uuid` bigint(20) NOT NULL DEFAULT '0',
  `leaveTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_role_armygroup` */

/*Table structure for table `t_role_expedtion` */

DROP TABLE IF EXISTS `t_role_expedtion`;

CREATE TABLE `t_role_expedtion` (
  `id` bigint(64) NOT NULL,
  `guardProps` text,
  `cardsKeepProps` text,
  `challengeTimes` int(11) DEFAULT NULL,
  `lastResetTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_role_expedtion` */

/*Table structure for table `t_role_lightstep` */

DROP TABLE IF EXISTS `t_role_lightstep`;

CREATE TABLE `t_role_lightstep` (
  `id` bigint(20) NOT NULL,
  `humanName` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `stepProps` text COLLATE utf8_unicode_ci,
  `actId` bigint(20) DEFAULT '0',
  `charId` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

/*Data for the table `t_role_lightstep` */

/*Table structure for table `t_rotate_table_config` */

DROP TABLE IF EXISTS `t_rotate_table_config`;

CREATE TABLE `t_rotate_table_config` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `activityId` bigint(20) NOT NULL,
  `actState` int(11) DEFAULT '0',
  `nameStr` varchar(45) DEFAULT NULL,
  `startTime` bigint(20) DEFAULT '0',
  `endTime` bigint(20) DEFAULT '0',
  `descStr` varchar(1024) DEFAULT NULL,
  `oneCost` int(10) unsigned DEFAULT '0',
  `tenCost` int(10) unsigned DEFAULT '0',
  `perPoolMoney` int(10) unsigned DEFAULT '0',
  `initPoolMoney` int(10) DEFAULT '0',
  `maxPoolMoney` int(11) DEFAULT '0',
  `flushTime` bigint(20) DEFAULT '0',
  `perGetPoint` int(11) unsigned DEFAULT '0',
  `useItemId` int(11) unsigned DEFAULT '0',
  `prizesJson` text,
  `goodsJson` text,
  `logsJson` text,
  `serverIds` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_rotate_table_config` */

/*Table structure for table `t_rotate_table_info` */

DROP TABLE IF EXISTS `t_rotate_table_info`;

CREATE TABLE `t_rotate_table_info` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `activityId` bigint(20) NOT NULL,
  `roleUUID` bigint(20) NOT NULL,
  `pointNum` int(10) unsigned DEFAULT '0',
  `lastFreeTime` bigint(20) unsigned DEFAULT '0',
  `exchangeJson` text,
  `personalLogJson` text,
  `cangkuJson` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=60 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_rotate_table_info` */

/*Table structure for table `t_scene_info` */

DROP TABLE IF EXISTS `t_scene_info`;

CREATE TABLE `t_scene_info` (
  `id` bigint(20) NOT NULL,
  `properties` text,
  `templateId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_templateId` (`templateId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_scene_info` */

/*Table structure for table `t_scheduled_war` */

DROP TABLE IF EXISTS `t_scheduled_war`;

CREATE TABLE `t_scheduled_war` (
  `id` varchar(36) NOT NULL,
  `type` int(11) NOT NULL DEFAULT '0',
  `prepareTime` datetime DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `detailInfo` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `type` (`type`),
  KEY `startTime` (`startTime`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_scheduled_war` */

/*Table structure for table `t_shop_limit` */

DROP TABLE IF EXISTS `t_shop_limit`;

CREATE TABLE `t_shop_limit` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `shelfId` int(11) NOT NULL,
  `count` int(11) NOT NULL DEFAULT '0',
  `lastBuyTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_shop_limit` */

/*Table structure for table `t_shopmall_info` */

DROP TABLE IF EXISTS `t_shopmall_info`;

CREATE TABLE `t_shopmall_info` (
  `id` int(11) NOT NULL,
  `count` int(11) DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  `sell` int(11) DEFAULT '1',
  `name` varchar(255) DEFAULT NULL,
  `upTime` varchar(255) DEFAULT NULL,
  `downTime` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_shopmall_info` */

/*Table structure for table `t_shopmallbuy_log` */

DROP TABLE IF EXISTS `t_shopmallbuy_log`;

CREATE TABLE `t_shopmallbuy_log` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `itemId` int(11) NOT NULL,
  `shelfId` int(11) DEFAULT NULL,
  `buyCount` int(11) NOT NULL,
  `buyTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `useMoney` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_shopmallbuy_log` */

/*Table structure for table `t_single_arena` */

DROP TABLE IF EXISTS `t_single_arena`;

CREATE TABLE `t_single_arena` (
  `id` bigint(20) NOT NULL,
  `name` varchar(256) NOT NULL DEFAULT '""',
  `rank` int(11) NOT NULL,
  `templateId` int(11) NOT NULL,
  `declaration` varchar(512) NOT NULL DEFAULT '""',
  `lefttime` int(11) NOT NULL,
  `type` smallint(6) NOT NULL,
  `rewardBoxId` int(11) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL,
  `yesterdayRank` int(11) NOT NULL DEFAULT '0',
  `vocationTypeId` int(11) NOT NULL DEFAULT '1',
  `weaponId` int(11) NOT NULL DEFAULT '0',
  `girl` smallint(6) NOT NULL,
  `record` text,
  `battleInfo` text,
  `wingId` int(11) DEFAULT '0',
  `petId` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `rankIndex` (`rank`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_single_arena` */

insert  into `t_single_arena`(`id`,`name`,`rank`,`templateId`,`declaration`,`lefttime`,`type`,`rewardBoxId`,`level`,`yesterdayRank`,`vocationTypeId`,`weaponId`,`girl`,`record`,`battleInfo`,`wingId`,`petId`) values (100210001,'琴蕴和',1,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210002,'穰建明',2,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210003,'茅季萌',3,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210004,'关德惠',4,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210005,'别嘉木',5,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210006,'冀承载',6,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210007,'熊俊远',7,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210008,'郝秋双',8,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210009,'聂茂才',9,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210010,'璩孟尝',10,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210011,'仲晟睿',11,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210012,'蒙德惠',12,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210013,'充一笑',13,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210014,'西门子石',14,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210015,'解学真',15,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210016,'家阳炎',16,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210017,'卓和志',17,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210018,'叶承泽',18,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210019,'甫凯捷',19,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210020,'满安顺',20,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210021,'褚乐萱',21,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210022,'钮不凡',22,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210023,'东郭一江',23,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210024,'夔阳飙',24,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210025,'阙班',25,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210026,'昝德华',26,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210027,'博正初',27,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210028,'从景澄',28,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210029,'寿英发',29,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210030,'禹伯云',30,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210031,'从永言',31,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210032,'宫嘉誉',32,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210033,'能悲',33,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210034,'殷子平',34,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210035,'骆俊美',35,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210036,'别元勋',36,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210037,'游听芹',37,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210038,'任智志',38,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210039,'酆勇捷',39,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210040,'琦子默',40,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210041,'靳向笛',41,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210042,'拉又菡',42,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210043,'司空高雅',43,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210044,'章友巧',44,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210045,'虞乐章',45,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210046,'强正业',46,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210047,'蒯俊良',47,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210048,'扶凯泽',48,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210049,'庄烨煜',49,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210050,'澹台天睿',50,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210051,'何傲菡',51,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210052,'舜鬼神',52,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210053,'时和安',53,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210054,'梅玉龙',54,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210055,'公冶涵涤',55,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210056,'微生十八',56,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210057,'皇甫兴朝',57,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210058,'戴雅畅',58,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210059,'高波鸿',59,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210060,'甫玉堂',60,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210061,'代祺然',61,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210062,'伏白凝',62,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210063,'别正豪',63,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210064,'支金刚',64,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210065,'单于高飞',65,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210066,'桓承望',66,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210067,'仉凝竹',67,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210068,'甫涵煦',68,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210069,'宰父文曜',69,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210070,'翁博涛',70,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210071,'宦友梅',71,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210072,'梅难摧',72,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210073,'盛涵煦',73,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210074,'塔承志',74,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210075,'冉子轩',75,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210076,'堪泰然',76,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210077,'浦雅畅',77,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210078,'鱼灭绝',78,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210079,'始和泰',79,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210080,'浦高驰',80,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210081,'何寻雁',81,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210082,'叶香帅',82,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210083,'金小萱',83,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210084,'轩辕凯泽',84,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210085,'薛嘉福',85,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210086,'谢天韵',86,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210087,'徐开畅',87,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210088,'蒯天川',88,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210089,'闾鞅',89,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210090,'郜汝燕',90,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210091,'法冰岚',91,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210092,'黄金刚',92,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210093,'汲子实',93,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210094,'梁鸿轩',94,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210095,'阳佟道消',95,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210096,'鲍乐童',96,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210097,'房嘉志',97,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210098,'微生惜海',98,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210099,'颜和豫',99,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210100,'钭清',100,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210101,'乔俊达',101,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210102,'韶坚成',102,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210103,'水志尚',103,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210104,'谷粱丑',104,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210105,'江康复',105,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210106,'韶万天',106,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210107,'易凌萱',107,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210108,'公冶寄琴',108,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210109,'余俊茂',109,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210110,'堵浩浩',110,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210111,'拉飞白',111,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210112,'穰巧荷',112,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210113,'贵百晓生',113,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210114,'熊威',114,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210115,'冀逸明',115,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210116,'程思远',116,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210117,'波谷菱',117,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210118,'朱绿蝶',118,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210119,'党雪旋',119,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210120,'祁良工',120,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210121,'史晟睿',121,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210122,'有昊苍',122,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210123,'蔚俊誉',123,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210124,'詹夜天',124,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210125,'令狐敏叡',125,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210126,'储乐康',126,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210127,'鲜于涵润',127,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210128,'赵三问',128,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210129,'东方浩气',129,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210130,'查晶儿',130,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210131,'瞿冠玉',131,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210132,'宣英卓',132,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210133,'卓光霁',133,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210134,'贯奇伟',134,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210135,'危星辰',135,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210136,'晋奇正',136,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210137,'车兴旺',137,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210138,'广坚成',138,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210139,'象隶',139,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210140,'梅万声',140,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210141,'闪乐逸',141,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210142,'简嵩',142,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210143,'呼延宇荫',143,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210144,'危修文',144,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210145,'巢祺福',145,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210146,'闾建安',146,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210147,'宇文俊能',147,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210148,'容明杰',148,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210149,'杜阳炎',149,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210150,'胡浩旷',150,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210151,'单于阳煦',151,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210152,'卢元武',152,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210153,'幸寇',153,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210154,'葛光临',154,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210155,'雷菁菁',155,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210156,'牧仇血',156,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210157,'扈嘉德',157,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210158,'毕和蔼',158,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210159,'窦星宇',159,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210160,'贵捕',160,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210161,'蒯俊捷',161,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210162,'杭建茗',162,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210163,'求凯捷',163,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210164,'欧阳罗汉',164,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210165,'淳于紫安',165,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210166,'禄星津',166,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210167,'天剑鬼',167,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210168,'曾元良',168,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210169,'乔俊德',169,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210170,'吕广山',170,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210171,'帅高阳',171,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210172,'韦烨伟',172,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210173,'通宇文',173,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210174,'昝浩天',174,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210175,'闪向天',175,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210176,'窦书瑶',176,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210177,'路浩波',177,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210178,'庾良平',178,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210179,'闻人经义',179,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210180,'拉英哲',180,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210181,'贯天抒',181,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210182,'关俊迈',182,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210183,'典波涛',183,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210184,'黎虔纹',184,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210185,'百里翰音',185,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210186,'寇德佑',186,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210187,'樊元武',187,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210188,'溥靖仇',188,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210189,'勾隶',189,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210190,'蔚文滨',190,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210191,'东门炎彬',191,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210192,'黄弘光',192,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210193,'蒯兴庆',193,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210194,'利兴言',194,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210195,'濮阳万言',195,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210196,'东郭宏茂',196,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210197,'卓亿先',197,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210198,'毕涵映',198,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210199,'松健柏',199,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210200,'舒嘉良',200,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210201,'狄振海',201,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210202,'夏浩淼',202,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210203,'焦子昂',203,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210204,'宓茂典',204,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210205,'花安莲',205,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210206,'谭绍元',206,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210207,'栾英耀',207,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210208,'阳涵煦',208,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210209,'向举人',209,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210210,'冀和璧',210,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210211,'竭断缘',211,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210212,'虞志专',212,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210213,'山豪英',213,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210214,'权世立',214,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210215,'姬凡',215,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210216,'实开济',216,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210217,'仲高澹',217,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210218,'金逸明',218,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210219,'法嘉祯',219,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210220,'法尊使',220,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210221,'万俊达',221,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210222,'伏广缘',222,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210223,'梁丘若之',223,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210224,'刘德惠',224,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210225,'钮华彩',225,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210226,'羊尔琴',226,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210227,'乐正孱',227,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210228,'乐晓瑶',228,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210229,'阚修洁',229,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210230,'梁奇略',230,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210231,'满井',231,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210232,'禄芷文',232,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210233,'谷粱浩阑',233,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210234,'呼延咏德',234,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210235,'黄茗茗',235,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210236,'东郭老五',236,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210237,'包子瑜',237,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210238,'夹谷峻',238,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210239,'亓官烨霖',239,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210240,'劳鹏鲸',240,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210241,'都幻嫣',241,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210242,'舒承恩',242,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210243,'顾老四',243,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210244,'实鹏翼',244,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210245,'尉迟温文',245,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210246,'池远望',246,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210247,'温康时',247,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210248,'孙正信',248,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210249,'万俟成威',249,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210250,'张文虹',250,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210251,'滕良朋',251,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210252,'廉厉',252,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210253,'伯欣德',253,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210254,'寸妙菡',254,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210255,'茹敏智',255,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210256,'空俊发',256,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210257,'羊祥',257,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210258,'贲夜安',258,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210259,'东门文曜',259,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210260,'孟嘉庆',260,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210261,'欧阳银狐',261,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210262,'隗高洁',262,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210263,'宗可冥',263,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210264,'温羊青',264,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210265,'蓬阳煦',265,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210266,'松碧灵',266,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210267,'仇元纬',267,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210268,'鲜于鸿信',268,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210269,'袁念芹',269,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210270,'柴蛟王',270,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210271,'蓝兴业',271,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210272,'茹人杰',272,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210273,'代姝',273,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210274,'锺君昊',274,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210275,'雍岩',275,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210276,'端高轩',276,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210277,'蒯宏伟',277,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210278,'督如花',278,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210279,'储冷雁',279,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210280,'谢修杰',280,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210281,'郭无极',281,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210282,'卓锦程',282,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210283,'颛孙博远',283,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210284,'卓才子',284,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210285,'家高朗',285,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210286,'颜若翠',286,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210287,'巩弘毅',287,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210288,'禹绝悟',288,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210289,'全弘毅',289,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210290,'劳夜梅',290,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210291,'束承福',291,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210292,'齐罗汉',292,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210293,'成和昶',293,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210294,'时兴思',294,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210295,'宰俊民',295,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210296,'典翰飞',296,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210297,'易作人',297,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210298,'栾鹏赋',298,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210299,'百里如蓉',299,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210300,'吉浩歌',300,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210301,'史妙海',301,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210302,'席和硕',302,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210303,'康万怨',303,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210304,'管承嗣',304,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210305,'蓝剑身',305,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210306,'申茂才',306,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210307,'始彭越',307,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210308,'詹昊英',308,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210309,'上官嘉颖',309,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210310,'阮焦',310,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210311,'党芝',311,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210312,'杜人雄',312,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210313,'闫妙彤',313,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210314,'汲元甲',314,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210315,'百里成业',315,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210316,'卫代云',316,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210317,'归刚豪',317,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210318,'穰鸿雪',318,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210319,'步忆灵',319,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210320,'空乐贤',320,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210321,'鲍凯安',321,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210322,'支柏柳',322,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210323,'弓黎云',323,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210324,'屈子昂',324,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210325,'实学博',325,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210326,'南宫小珍',326,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210327,'司空志强',327,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210328,'吴道天',328,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210329,'訾山蝶',329,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210330,'东方鹏飞',330,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210331,'阮高峯',331,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210332,'岑靖仇',332,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210333,'孙文康',333,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210334,'石宜年',334,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210335,'速天魔',335,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210336,'纪锐阵',336,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210337,'饶正文',337,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210338,'邱汝燕',338,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210339,'包睿德',339,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210340,'谈伟诚',340,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210341,'司徒卿',341,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210342,'闵承平',342,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210343,'娄浩气',343,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210344,'弓欣然',344,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210345,'郜华翰',345,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210346,'卞雨伯',346,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210347,'贺英韶',347,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210348,'倪祺祥',348,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210349,'黄飞白',349,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210350,'黎新霁',350,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210351,'经寻桃',351,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210352,'元初露',352,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210353,'蓟迎蕾',353,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210354,'房盼山',354,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210355,'溥兴文',355,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210356,'邰梦琪',356,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210357,'红灭龙',357,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210358,'詹欣然',358,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210359,'姬阳德',359,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210360,'璩锐锋',360,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210361,'酆晗昱',361,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210362,'闻人乐成',362,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210363,'牧文轩',363,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210364,'景鸿轩',364,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210365,'经咏歌',365,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210366,'殳英叡',366,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210367,'壤驷乐正',367,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210368,'侯高翰',368,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210369,'祝凡双',369,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210370,'钮和通',370,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210371,'乐德海',371,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210372,'翦冰香',372,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210373,'方高超',373,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210374,'谷小珍',374,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210375,'宗鸿宝',375,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210376,'董不可',376,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210377,'薛薇薇',377,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210378,'辛英叡',378,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210379,'万俟敏叡',379,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210380,'蓟难胜',380,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210381,'沙凯泽',381,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210382,'沃兴怀',382,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210383,'始医仙',383,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210384,'唐安宁',384,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210385,'季鸿文',385,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210386,'巫马浦和',386,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210387,'历小玉',387,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210388,'帅鸿飞',388,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210389,'厍泰初',389,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210390,'訾匕',390,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210391,'真举人',391,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210392,'郝碧蓉',392,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210393,'鲍虎君',393,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210394,'令狐永康',394,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210395,'隆靖易',395,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210396,'缑俊杰',396,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210397,'呼延代玉',397,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210398,'微生似狮',398,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210399,'贾良才',399,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210400,'习安国',400,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210401,'牟岑',401,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210402,'阮文宣',402,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210403,'弘天工',403,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210404,'西门钧',404,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210405,'喻灵竹',405,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210406,'阮友琴',406,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210407,'杨德润',407,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210408,'苍少主',408,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210409,'家阳成',409,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210410,'赫连才捷',410,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210411,'宿温瑜',411,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210412,'宿蹇',412,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210413,'凤宛秋',413,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210414,'晁隶',414,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210415,'蒲俊侠',415,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210416,'堪承宣',416,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210417,'拓跋和尚',417,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210418,'齐思博',418,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210419,'粱疾',419,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210420,'汲幻露',420,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210421,'颜沛容',421,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210422,'尉迟英光',422,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210423,'臧荠',423,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210424,'万俟鸿达',424,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210425,'岳秋',425,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210426,'百里博容',426,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210427,'怀博延',427,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210428,'毕学林',428,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210429,'暨听云',429,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210430,'阎元德',430,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210431,'羊泰清',431,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210432,'倪戎',432,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210433,'童千柔',433,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210434,'贰飞英',434,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210435,'雷绮烟',435,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210436,'薛夏彤',436,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210437,'伍博',437,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210438,'博鸿朗',438,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210439,'申屠沛白',439,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210440,'饶珩',440,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210441,'蓬阳煦',441,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210442,'蓬宏博',442,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210443,'拉乾',443,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210444,'百里朋兴',444,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210445,'冀弘深',445,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210446,'公冶宏茂',446,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210447,'养乐生',447,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210448,'彤修远',448,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210449,'司兴邦',449,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210450,'夏侯青梦',450,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210451,'相元嘉',451,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210452,'沃居士',452,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210453,'柏阳荣',453,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210454,'孔虔',454,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210455,'裴经武',455,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210456,'司徒飞航',456,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210457,'通光辉',457,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210458,'逄鸿羲',458,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210459,'蒙良朋',459,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210460,'钱昊然',460,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210461,'赵俊风',461,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210462,'寿雨信',462,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210463,'贰浩浩',463,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210464,'谷粱千兰',464,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210465,'耿难敌',465,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210466,'银智鑫',466,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210467,'文御史',467,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210468,'宦金鑫',468,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210469,'万俟含桃',469,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210470,'宰父穆',470,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210471,'赵锐达',471,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210472,'崔思源',472,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210473,'粱德惠',473,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210474,'秦鹏天',474,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210475,'扶秋蝶',475,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210476,'魏泰然',476,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210477,'常宏义',477,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210478,'屈康时',478,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210479,'苍蕴涵',479,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210480,'樊康宁',480,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210481,'杜文成',481,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210482,'惠夜山',482,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210483,'从博文',483,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210484,'仰高爽',484,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210485,'刁三德',485,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210486,'博光济',486,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210487,'羽悲',487,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210488,'弘志明',488,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210489,'郭承福',489,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210490,'解武尊',490,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210491,'逮梦菲',491,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210492,'缪子安',492,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210493,'公孙星渊',493,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210494,'符阳成',494,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210495,'邵昂雄',495,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210496,'翦德本',496,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210497,'秦霸',497,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210498,'季阳云',498,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210499,'塔臻',499,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210500,'东郭映天',500,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210501,'皇天宇',501,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210502,'臧浩壤',502,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210503,'仇泰平',503,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210504,'樊斩',504,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210505,'别飞翔',505,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210506,'凌华晖',506,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210507,'訾青寒',507,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210508,'沈伯云',508,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210509,'屠同和',509,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210510,'始岱周',510,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210511,'阚翎',511,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210512,'廉高翰',512,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210513,'暴欣怿',513,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210514,'季康',514,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210515,'严天佑',515,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210516,'诸道天',516,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210517,'巫成济',517,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210518,'古迎彤',518,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210519,'红宾白',519,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210520,'壤驷晓蕾',520,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210521,'席良才',521,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210522,'汤立辉',522,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210523,'博开朗',523,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210524,'闾蛟凤',524,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210525,'终勇军',525,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210526,'糜书雁',526,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210527,'伯君浩',527,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210528,'仲孙阳夏',528,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210529,'仰无施',529,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210530,'芮俊智',530,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210531,'沙安卉',531,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210532,'宗承运',532,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210533,'常难胜',533,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210534,'邵锐意',534,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210535,'赏建本',535,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210536,'景立果',536,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210537,'戚浩宕',537,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210538,'郝德元',538,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210539,'琴阳成',539,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210540,'沙郎君',540,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210541,'安玉泉',541,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210542,'南博艺',542,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210543,'欧阳成协',543,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210544,'伊子明',544,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210545,'浦锐进',545,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210546,'羊从雪',546,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210547,'范觅儿',547,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210548,'郁德地',548,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210549,'尚伟博',549,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210550,'桂元龙',550,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210551,'鞠高兴',551,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210552,'郑德元',552,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210553,'方明俊',553,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210554,'尤芙',554,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210555,'通沅',555,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210556,'巫翰池',556,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210557,'商宏硕',557,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210558,'经不悔',558,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210559,'海奇致',559,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210560,'陈俊能',560,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210561,'漆若风',561,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210562,'蔺高义',562,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210563,'柯永昌',563,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210564,'查博雅',564,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210565,'闾康胜',565,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210566,'蔡依白',566,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210567,'黎天机',567,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210568,'端木承弼',568,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210569,'贝乌',569,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210570,'焦百晓生',570,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210571,'钞彭薄',571,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210572,'燕睿范',572,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210573,'洪剑愁',573,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210574,'裴绍祺',574,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210575,'孟探花',575,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210576,'商毅然',576,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210577,'上官光耀',577,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210578,'冷若冰',578,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210579,'欧飞鸾',579,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210580,'阚浩思',580,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210581,'暨阳焱',581,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210582,'岑永逸',582,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210583,'吴永思',583,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210584,'孙书双',584,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210585,'翠元亮',585,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210586,'宁阳飙',586,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210587,'梁巧手',587,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210588,'嵇元甲',588,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210589,'衣人雄',589,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210590,'梅书白',590,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210591,'明雪巧',591,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210592,'钮和歌',592,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210593,'韩寇',593,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210594,'汲雨信',594,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210595,'酆成败',595,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210596,'禄睿聪',596,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210597,'越子明',597,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210598,'邰乐安',598,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210599,'经正雅',599,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210600,'公西侠士',600,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210601,'单于元纬',601,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210602,'封先生',602,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210603,'曾永春',603,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210604,'历星阑',604,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210605,'林夜柳',605,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210606,'盍天材',606,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210607,'禄国源',607,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210608,'牧小翠',608,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210609,'越良平',609,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210610,'郎嘉志',610,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210611,'单于书桃',611,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210612,'宰皓轩',612,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210613,'查华池',613,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210614,'弓诗双',614,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210615,'咸睿聪',615,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210616,'应良才',616,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210617,'牛玉宇',617,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210618,'佴珩',618,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210619,'暨睿识',619,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210620,'卜乐正',620,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210621,'速坚白',621,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210622,'向力强',622,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210623,'寇英逸',623,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210624,'宰宏浚',624,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210625,'边项禹',625,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210626,'荆世德',626,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210627,'沈寒',627,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210628,'赫寻桃',628,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210629,'始雅彤',629,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210630,'吉阳焱',630,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210631,'蓟承德',631,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210632,'端木不言',632,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210633,'杨逊',633,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210634,'郜食神',634,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210635,'查飞章',635,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210636,'施华皓',636,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210637,'尚乐人',637,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210638,'印乐成',638,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210639,'贝兴昌',639,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210640,'阎乐正',640,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210641,'廖彭彭',641,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210642,'伏天魔',642,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210643,'南宫飞尘',643,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210644,'卫散人',644,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210645,'暨烨磊',645,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210646,'危夜山',646,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210647,'陈铭',647,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210648,'危元恺',648,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210649,'赏宏大',649,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210650,'竭彬炳',650,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210651,'碧承志',651,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210652,'罗子真',652,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210653,'郎寒梅',653,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210654,'闵嘉誉',654,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210655,'缑嘉颖',655,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210656,'于修远',656,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210657,'荣人雄',657,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210658,'司寇宏爽',658,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210659,'凤鹏鹍',659,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210660,'陈乘风',660,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210661,'邰先生',661,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210662,'奚琪睿',662,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210663,'弘嘉熙',663,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210664,'鲍难破',664,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210665,'甫伟晔',665,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210666,'僪兴平',666,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210667,'宋昂然',667,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210668,'谷粱英睿',668,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210669,'严曼寒',669,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210670,'尹老黑',670,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210671,'欧阳成文',671,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210672,'子车名士',672,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210673,'羿宜民',673,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210674,'巴嘉颖',674,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210675,'霍和璧',675,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210676,'凤英悟',676,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210677,'满超',677,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210678,'梁丘靖儿',678,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210679,'毕嘉佑',679,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210680,'冷永春',680,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210681,'水玉龙',681,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210682,'卞童子',682,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210683,'苗向晨',683,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210684,'童乐音',684,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210685,'别俊爽',685,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210686,'闾丘涵衍',686,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210687,'薛兴文',687,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210688,'应涔',688,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210689,'任瑾瑜',689,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210690,'红老头',690,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210691,'汲浦泽',691,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210692,'桓文彬',692,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210693,'缪鹏赋',693,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210694,'夏俊才',694,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210695,'尤志泽',695,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210696,'波元勋',696,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210697,'丰梦菡',697,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210698,'益飞跃',698,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210699,'仉敏智',699,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210700,'周翰池',700,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210701,'蓬华池',701,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210702,'占煞神',702,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210703,'毛闭月',703,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210704,'滕开畅',704,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210705,'柯人雄',705,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210706,'凤姒',706,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210707,'齐阳煦',707,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210708,'秋明煦',708,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210709,'寸雨信',709,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210710,'邬凯凯',710,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210711,'诸誉',711,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210712,'马凛',712,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210713,'郗同甫',713,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210714,'樊明煦',714,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210715,'拓跋隐侠',715,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210716,'姚温文',716,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210717,'栾和悌',717,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210718,'雍嘉颖',718,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210719,'厍学林',719,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210720,'车茂实',720,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210721,'储雅达',721,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210722,'糜萍',722,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210723,'於骁',723,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210724,'弘思山',724,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210725,'暴伯云',725,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210726,'禄元甲',726,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210727,'寇亚男',727,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210728,'东方飞沉',728,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210729,'勾焦',729,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210730,'常海桃',730,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210731,'强鸿雪',731,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210732,'鲁飞沉',732,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210733,'充博容',733,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210734,'解若南',734,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210735,'接天空',735,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210736,'郑修杰',736,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210737,'白华藏',737,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210738,'邴飞英',738,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210739,'邓俊力',739,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210740,'东郭鹏飞',740,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210741,'银斩',741,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210742,'养兴安',742,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210743,'秦映波',743,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210744,'程荣轩',744,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210745,'葛璞瑜',745,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210746,'何英逸',746,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210747,'归俊民',747,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210748,'雍思淼',748,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210749,'琴子实',749,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210750,'劳弘光',750,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210751,'汝伟泽',751,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210752,'贲霆',752,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210753,'常怡',753,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210754,'骆判官',754,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210755,'闪凛',755,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210756,'喻安志',756,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210757,'用仇血',757,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210758,'韩映梦',758,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210759,'郝尔竹',759,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210760,'姜蕴和',760,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210761,'南宫妙芙',761,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210762,'贝承载',762,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210763,'钟离自强',763,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210764,'隗含之',764,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210765,'屠寄文',765,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210766,'夏侯雨石',766,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210767,'聂冰珍',767,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210768,'秋鹏天',768,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210769,'东天魔',769,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210770,'戚致远',770,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210771,'伍建同',771,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210772,'束学博',772,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210773,'管飞航',773,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210774,'印康伯',774,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210775,'晋俊艾',775,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210776,'魏晓兰',776,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210777,'殷笑翠',777,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210778,'巴洁',778,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210779,'伏滨海',779,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210780,'安念云',780,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210781,'元初丹',781,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210782,'尤哲瀚',782,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210783,'阎青柏',783,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210784,'边安然',784,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210785,'籍博涉',785,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210786,'钞自明',786,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210787,'石正卿',787,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210788,'席翰飞',788,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210789,'满道之',789,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210790,'召弘厚',790,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210791,'韦难摧',791,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210792,'龚建安',792,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210793,'袁雅惠',793,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210794,'郝君昊',794,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210795,'融博涉',795,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210796,'西门追命',796,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210797,'冷经纶',797,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210798,'游俊逸',798,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210799,'甄康盛',799,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210800,'乔飞虎',800,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210801,'伍成文',801,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210802,'塔峯',802,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210803,'东门水香',803,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210804,'伯赏潜龙',804,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210805,'朱半鬼',805,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210806,'欧阳德曜',806,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210807,'车和悦',807,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210808,'堵和豫',808,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210809,'黎剑愁',809,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210810,'田忆雪',810,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210811,'贡飞翰',811,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210812,'阮半雪',812,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210813,'宇文弘图',813,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210814,'邴飞',814,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210815,'查宇航',815,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210816,'桓志用',816,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210817,'冀宝莹',817,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210818,'沃璞玉',818,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210819,'茅彭泽',819,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210820,'钱送终',820,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210821,'彤奇伟',821,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210822,'田星渊',822,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210823,'尤弘济',823,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210824,'牧良俊',824,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210825,'芮鸿波',825,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210826,'从弘义',826,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210827,'接药王',827,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210828,'芮逸春',828,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210829,'苏罗汉',829,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210830,'太叔丹云',830,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210831,'经世开',831,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210832,'宫青',832,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210833,'赏宏邈',833,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210834,'郁嘉悦',834,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210835,'康飞章',835,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210836,'嵇修平',836,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210837,'邓高翰',837,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210838,'僪沧海',838,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210839,'凌凯捷',839,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210840,'姬灵珊',840,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210841,'空寇',841,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210842,'辟居士',842,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210843,'阙道之',843,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210844,'印高雅',844,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210845,'巢翰采',845,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210846,'彭瑾瑜',846,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210847,'阎高阳',847,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210848,'冉高达',848,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210849,'蓬元龙',849,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210850,'武亚男',850,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210851,'殷浩波',851,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210852,'天康胜',852,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210853,'郝和悦',853,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210854,'东方冷卉',854,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210855,'海明远',855,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210856,'嵇安寒',856,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210857,'赖绍钧',857,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210858,'长孙奇略',858,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210859,'邹冷梅',859,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210860,'贯煜祺',860,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210861,'郝亦瑶',861,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210862,'沃天材',862,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210863,'莫稀',863,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210864,'韩飞龙',864,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210865,'符嘉赐',865,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210866,'博高谊',866,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210867,'藏星火',867,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210868,'谈华池',868,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210869,'芮乐咏',869,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210870,'於雨灵',870,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210871,'滑茂材',871,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210872,'牛弘扬',872,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210873,'锺南风',873,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210874,'利巧凡',874,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210875,'公良才',875,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210876,'柴和宜',876,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210877,'督僧人',877,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210878,'闻人乐童',878,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210879,'乐正刚捷',879,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210880,'步严青',880,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210881,'冀新儿',881,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210882,'昝薇儿',882,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210883,'储飞兰',883,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210884,'宇文忘幽',884,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210885,'党雨石',885,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210886,'毋俊发',886,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210887,'禄嘉勋',887,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210888,'羽和光',888,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210889,'席弘和',889,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210890,'戎诗翠',890,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210891,'湛金鑫',891,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210892,'钟离嘉玉',892,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210893,'佘修德',893,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210894,'游康',894,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210895,'於成济',895,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210896,'司空博赡',896,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210897,'公孙不凡',897,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210898,'权奇希',898,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210899,'慎大楚',899,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210900,'戈夜天',900,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210901,'季才哲',901,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210902,'湛雨星',902,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210903,'苗力学',903,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210904,'仇俊达',904,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210905,'汪乐邦',905,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210906,'詹飞鸿',906,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210907,'邱初之',907,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210908,'濮乾',908,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210909,'张元化',909,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210910,'喻理全',910,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210911,'尤大楚',911,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210912,'牧乐咏',912,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210913,'秦绿柳',913,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210914,'祁新立',914,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210915,'戈成荫',915,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210916,'晏承德',916,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210917,'皇甫兴庆',917,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210918,'皇甫朋义',918,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210919,'邱文龙',919,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210920,'贡智鑫',920,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210921,'嵇浩旷',921,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210922,'梁紫南',922,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210923,'白明杰',923,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210924,'皮煞神',924,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210925,'郑朗',925,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210926,'金傥',926,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210927,'却念梦',927,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210928,'乜白竹',928,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210929,'南宫经纶',929,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210930,'彭娩',930,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210931,'富元柳',931,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210932,'姜臻',932,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210933,'银高峯',933,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210934,'仇天干',934,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210935,'杨元良',935,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210936,'侨德天',936,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210937,'康茂典',937,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210938,'山乐成',938,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210939,'水成龙',939,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210940,'舜成协',940,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210941,'汝俊德',941,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210942,'农星驰',942,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210943,'宗政莆',943,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210944,'农嘉珍',944,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210945,'海成化',945,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210946,'王碧玉',946,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210947,'毕睿达',947,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210948,'璩香帅',948,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210949,'欧以彤',949,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210950,'钮锦程',950,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210951,'谷飞光',951,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210952,'郑如花',952,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210953,'后季萌',953,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210954,'沃飞扬',954,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210955,'蒲成文',955,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210956,'赏又槐',956,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210957,'尚小萱',957,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210958,'闾丘裘',958,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210959,'始麒麟',959,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210960,'燕展鹏',960,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210961,'米老四',961,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210962,'施国兴',962,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210963,'利诗柳',963,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210964,'庞嘉瑞',964,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210965,'浦元香',965,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210966,'堵浩宕',966,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210967,'邱德惠',967,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210968,'耿浩宕',968,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210969,'用飞雨',969,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210970,'伯赏涵忍',970,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210971,'李明志',971,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210972,'臧酬海',972,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210973,'贝建柏',973,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210974,'璩志诚',974,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210975,'干承志',975,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210976,'庾雅逸',976,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210977,'却波鸿',977,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210978,'弓忆南',978,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210979,'步蛟王',979,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210980,'拓跋安顺',980,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210981,'张浩波',981,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210982,'袁明智',982,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210983,'毕远侵',983,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210984,'姬幻然',984,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210985,'柏煜祺',985,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210986,'单浩初',986,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210987,'归天罡',987,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210988,'艾绝悟',988,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210989,'梁丘香春',989,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210990,'溥康顺',990,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210991,'贡意蕴',991,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210992,'暨玉书',992,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210993,'诸葛经业',993,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210994,'王奄',994,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210995,'戚华翰',995,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210996,'漆雕神匠',996,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210997,'贰文栋',997,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210998,'成建章',998,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100210999,'巢难敌',999,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211000,'班孱',1000,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211001,'师沅',1001,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211002,'山涵阳',1002,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211003,'于井',1003,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211004,'巫马志泽',1004,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211005,'茹小蕾',1005,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211006,'暨温韦',1006,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211007,'劳弼',1007,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211008,'贡鑫',1008,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211009,'齐雪风',1009,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211010,'储才子',1010,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211011,'司寇从菡',1011,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211012,'侨铁身',1012,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211013,'羿英睿',1013,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211014,'单华藏',1014,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211015,'官宏大',1015,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211016,'蒯如花',1016,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211017,'沃弘阔',1017,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211018,'昝天睿',1018,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211019,'钟离波光',1019,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211020,'束俊力',1020,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211021,'钮羊青',1021,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211022,'卢立果',1022,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211023,'戴念露',1023,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211024,'赏问萍',1024,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211025,'沙和煦',1025,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211026,'尹温文',1026,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211027,'农天寿',1027,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211028,'狄宏邈',1028,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211029,'骆娩',1029,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211030,'淳于温文',1030,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211031,'姚樵子',1031,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211032,'殳子默',1032,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211033,'公静槐',1033,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211034,'董瑾瑜',1034,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211035,'夔誉',1035,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211036,'华德佑',1036,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211037,'丰从云',1037,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211038,'蔺不尤',1038,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211039,'贲昊空',1039,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211040,'惠苑博',1040,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211041,'萧酬海',1041,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211042,'侨和豫',1042,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211043,'苍雅逸',1043,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211044,'庄宾白',1044,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211045,'郁志义',1045,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211046,'贯兴思',1046,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211047,'鱼似狮',1047,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211048,'仰茂实',1048,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211049,'都念柏',1049,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211050,'谈傲珊',1050,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211051,'臧星雨',1051,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211052,'汲鸿卓',1052,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211053,'狂洁',1053,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211054,'公孙俊晤',1054,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211055,'管弘大',1055,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211056,'沈一笑',1056,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211057,'夏侯弘盛',1057,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211058,'路妙梦',1058,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211059,'薛修杰',1059,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211060,'汤高兴',1060,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211061,'堵续',1061,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211062,'於德本',1062,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211063,'干翠梅',1063,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211064,'琦星光',1064,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211065,'石华奥',1065,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211066,'仰难摧',1066,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211067,'任建修',1067,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211068,'宗雅昶',1068,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211069,'劳嘉泽',1069,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211070,'茹展鹏',1070,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211071,'厍苑博',1071,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211072,'扶峯',1072,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211073,'籍建白',1073,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211074,'窦英逸',1074,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211075,'聂阳旭',1075,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211076,'别同化',1076,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211077,'司寇成荫',1077,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211078,'裴安和',1078,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211079,'丰无血',1079,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211080,'解俊誉',1080,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211081,'符承教',1081,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211082,'巢难胜',1082,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211083,'红永思',1083,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211084,'安聋五',1084,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211085,'韶信瑞',1085,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211086,'融飞瑶',1086,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211087,'欧阳嘉佑',1087,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211088,'姚世德',1088,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211089,'宦光启',1089,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211090,'星宏阔',1090,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211091,'家儒生',1091,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211092,'师踏歌',1092,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211093,'松欣然',1093,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211094,'浦明珠',1094,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211095,'霍思菱',1095,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211096,'勾臻',1096,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211097,'满伟毅',1097,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211098,'堪雅珺',1098,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211099,'邓文斌',1099,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211100,'舜道之',1100,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211101,'宗政成益',1101,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211102,'戴初露',1102,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211103,'贡黎昕',1103,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211104,'穆欣怡',1104,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211105,'沃天韵',1105,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211106,'穰和安',1106,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211107,'焦弘量',1107,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211108,'富鹏举',1108,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211109,'卞忆雪',1109,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211110,'訾承载',1110,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211111,'石无敌',1111,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211112,'钟离正文',1112,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211113,'溥高轩',1113,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211114,'那狮王',1114,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211115,'奚毅然',1115,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211116,'解修远',1116,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211117,'杨戾',1117,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211118,'翠宏儒',1118,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211119,'濮靖琪',1119,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211120,'谷开朗',1120,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211121,'鲁浩渺',1121,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211122,'闫元正',1122,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211123,'庄文',1123,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211124,'用建义',1124,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211125,'酆光华',1125,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211126,'樊飞沉',1126,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211127,'尚慕晴',1127,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211128,'乜郎君',1128,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211129,'能弘和',1129,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211130,'接老九',1130,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211131,'詹山柏',1131,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211132,'邓彬彬',1132,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211133,'充光霁',1133,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211134,'汲英光',1134,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211135,'申屠兴平',1135,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211136,'乐安筠',1136,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211137,'席承安',1137,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211138,'邹兰',1138,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211139,'佴浩思',1139,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211140,'巩乾',1140,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211141,'傅广缘',1141,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211142,'葛博远',1142,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211143,'堵经略',1143,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211144,'厍兴发',1144,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211145,'彤卿',1145,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211146,'法俊风',1146,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211147,'班兴怀',1147,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211148,'鄂新知',1148,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211149,'奚乘风',1149,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211150,'督正诚',1150,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211151,'官伟茂',1151,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211152,'於景天',1152,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211153,'蒯天与',1153,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211154,'孔咏德',1154,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211155,'诸葛朋义',1155,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211156,'柏子实',1156,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211157,'夏侯灵雁',1157,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211158,'禹阳伯',1158,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211159,'欧阳羽',1159,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211160,'费才俊',1160,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211161,'左丘光誉',1161,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211162,'赵文翰',1162,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211163,'琦博涉',1163,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211164,'禄妙旋',1164,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211165,'淳于光远',1165,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211166,'相万仇',1166,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211167,'薛虎君',1167,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211168,'宰父高旻',1168,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211169,'席飞翼',1169,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211170,'左丘听云',1170,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211171,'任涵容',1171,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211172,'谭星华',1172,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211173,'富志学',1173,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211174,'端木英悟',1174,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211175,'塔康泰',1175,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211176,'刁瑛',1176,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211177,'翁乐咏',1177,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211178,'怀苑杰',1178,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211179,'东开朗',1179,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211180,'有承允',1180,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211181,'僪文康',1181,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211182,'景俊豪',1182,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211183,'仲如冬',1183,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211184,'富德水',1184,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211185,'司马和昶',1185,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211186,'麻嘉许',1186,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211187,'苍弘懿',1187,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211188,'桑听南',1188,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211189,'傅开霁',1189,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211190,'麻无施',1190,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211191,'那绝施',1191,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211192,'臧永长',1192,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211193,'百里庆生',1193,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211194,'齐飞扬',1194,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211195,'东方靖巧',1195,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211196,'扶光耀',1196,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211197,'堪良材',1197,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211198,'张善愁',1198,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211199,'宁茂材',1199,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211200,'松笙',1200,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211201,'禹水风',1201,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211202,'汤惜芹',1202,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211203,'班平彤',1203,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211204,'尤鸿雪',1204,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211205,'帅枫',1205,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211206,'宦浦泽',1206,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211207,'柳雅达',1207,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211208,'齐璞瑜',1208,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211209,'都又菱',1209,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211210,'郑乾',1210,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211211,'支怜梦',1211,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211212,'阮远望',1212,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211213,'卜光霁',1213,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211214,'姜高芬',1214,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211215,'郎鹏天',1215,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211216,'宣凯唱',1216,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211217,'公西博简',1217,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211218,'梁老五',1218,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211219,'集学海',1219,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211220,'班黎明',1220,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211221,'贡思远',1221,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211222,'南宫浩穰',1222,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211223,'夏侯朗',1223,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211224,'邰修谨',1224,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211225,'穰鹏飞',1225,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211226,'束尔风',1226,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211227,'召经亘',1227,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211228,'沙才良',1228,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211229,'钟离国源',1229,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211230,'诸浩波',1230,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211231,'常飞尘',1231,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211232,'明向天',1232,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211233,'锺高邈',1233,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211234,'于烨熠',1234,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211235,'林翠安',1235,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211236,'博靖琪',1236,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211237,'禄伟晔',1237,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211238,'伍阳夏',1238,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211239,'端木俊弼',1239,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211240,'段罗汉',1240,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211241,'胥绝施',1241,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211242,'薛英叡',1242,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211243,'孟涵衍',1243,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211244,'封睿识',1244,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211245,'危俊侠',1245,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211246,'羊子平',1246,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211247,'谈浩初',1247,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211248,'伏景山',1248,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211249,'庾和通',1249,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211250,'岑鸿博',1250,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211251,'单安白',1251,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211252,'郎金鑫',1252,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211253,'容修明',1253,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211254,'狂乐游',1254,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211255,'阙建弼',1255,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211256,'寸俊健',1256,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211257,'岳凝荷',1257,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211258,'衡嘉澍',1258,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211259,'耿明杰',1259,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211260,'安思远',1260,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211261,'皮星宇',1261,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211262,'储华晖',1262,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211263,'廉昊苍',1263,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211264,'董成风',1264,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211265,'东门颤',1265,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211266,'蔺幼荷',1266,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211267,'百里元德',1267,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211268,'昝弘业',1268,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211269,'丰乐安',1269,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211270,'广温文',1270,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211271,'燕元恺',1271,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211272,'漆雕鹏翼',1272,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211273,'陈锐立',1273,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211274,'乜华荣',1274,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211275,'公达',1275,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211276,'公羊宏博',1276,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211277,'轩辕华辉',1277,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211278,'夏明志',1278,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211279,'浦世立',1279,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211280,'星翰飞',1280,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211281,'禄和璧',1281,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211282,'家玉书',1282,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211283,'代一鸣',1283,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211284,'戚波涛',1284,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211285,'于和宜',1285,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211286,'隆高卓',1286,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211287,'那朋兴',1287,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211288,'巫不悔',1288,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211289,'毕俊誉',1289,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211290,'邵昊天',1290,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211291,'伏邑',1291,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211292,'布弘博',1292,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211293,'谷粱咏志',1293,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211294,'钱采枫',1294,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211295,'翁宏扬',1295,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211296,'荣飞跃',1296,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211297,'任自怡',1297,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211298,'许寄真',1298,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211299,'申麒麟',1299,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211300,'巢靖柔',1300,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211301,'乐正奇胜',1301,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211302,'沈和宜',1302,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211303,'芮凝荷',1303,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211304,'空鸿信',1304,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211305,'宗政如花',1305,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211306,'车伟懋',1306,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211307,'却乐心',1307,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211308,'严彬彬',1308,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211309,'赵坚壁',1309,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211310,'向明朗',1310,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211311,'翁雅昶',1311,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211312,'苏水蓉',1312,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211313,'慕兴贤',1313,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211314,'贺悒',1314,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211315,'陈成仁',1315,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211316,'博非笑',1316,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211317,'鱼永新',1317,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211318,'尹光济',1318,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211319,'顾逸明',1319,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211320,'罗安福',1320,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211321,'余代双',1321,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211322,'柯波涛',1322,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211323,'花万声',1323,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211324,'侯文栋',1324,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211325,'牟进士',1325,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211326,'濮阳开朗',1326,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211327,'司寇文星',1327,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211328,'郑凯复',1328,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211329,'靳寇',1329,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211330,'葛才俊',1330,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211331,'庾新荣',1331,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211332,'东英杰',1332,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211333,'汪天德',1333,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211334,'卓靖',1334,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211335,'商断秋',1335,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211336,'谢嘉言',1336,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211337,'沈翔宇',1337,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211338,'蓬亭儿',1338,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211339,'印阳曜',1339,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211340,'宋从南',1340,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211341,'用俊迈',1341,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211342,'公孙秀才',1342,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211343,'召剑客',1343,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211344,'穆元亮',1344,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211345,'司寇阳辉',1345,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211346,'真秋柳',1346,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211347,'从鸿彩',1347,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211348,'逄丰茂',1348,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211349,'广璞玉',1349,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211350,'侯星渊',1350,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211351,'印慕灵',1351,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211352,'闾承恩',1352,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211353,'鞠尊者',1353,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211354,'楚春竹',1354,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211355,'苏将军',1355,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211356,'令狐万怨',1356,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211357,'怀永新',1357,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211358,'钱元风',1358,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211359,'狄绯',1359,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211360,'钮人雄',1360,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211361,'聂泰平',1361,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211362,'孟霆',1362,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211363,'任向笛',1363,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211364,'阮秋',1364,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211365,'邵庆生',1365,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211366,'巫马访梦',1366,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211367,'梅鹤',1367,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211368,'用自中',1368,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211369,'求安歌',1369,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211370,'鱼弘和',1370,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211371,'唐修平',1371,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211372,'苗远航',1372,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211373,'阚飞光',1373,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211374,'轩辕刚豪',1374,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211375,'淳于蛟王',1375,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211376,'钱朝雪',1376,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211377,'邰玉宇',1377,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211378,'籍同化',1378,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211379,'富伟晔',1379,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211380,'石剑成',1380,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211381,'易成弘',1381,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211382,'花文彦',1382,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211383,'姜自中',1383,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211384,'訾乐珍',1384,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211385,'仲孙宜春',1385,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211386,'方元驹',1386,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211387,'代一鸣',1387,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211388,'葛扬',1388,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211389,'塔豪英',1389,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211390,'林波鸿',1390,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211391,'褚一刀',1391,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211392,'闾丘冠宇',1392,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211393,'历捕',1393,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211394,'茹景焕',1394,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211395,'凤正谊',1395,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211396,'诸弘雅',1396,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211397,'仲孙浩初',1397,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211398,'董高阳',1398,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211399,'上官翰采',1399,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211400,'姬宾鸿',1400,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211401,'吴奇玮',1401,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211402,'桓鹏鲲',1402,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211403,'徐浩博',1403,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211404,'池兴学',1404,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211405,'叶醉薇',1405,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211406,'凤阳成',1406,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211407,'岳元青',1407,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211408,'毛文翰',1408,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211409,'古正德',1409,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211410,'强雅逸',1410,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211411,'贯雯',1411,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211412,'苍妙彤',1412,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211413,'段锐泽',1413,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211414,'敖飞文',1414,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211415,'万秋春',1415,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211416,'闪英博',1416,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211417,'伏阳嘉',1417,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211418,'蒋冠玉',1418,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211419,'双明朗',1419,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211420,'闻人博裕',1420,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211421,'牧宾实',1421,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211422,'欧阳烨伟',1422,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211423,'苍明志',1423,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211424,'公白易',1424,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211425,'龙正信',1425,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211426,'鄂丑',1426,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211427,'祁博易',1427,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211428,'越飞章',1428,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211429,'端木开诚',1429,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211430,'国博赡',1430,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211431,'尚同济',1431,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211432,'冉温书',1432,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211433,'甘平露',1433,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211434,'黄海云',1434,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211435,'葛向真',1435,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211436,'弓鹤',1436,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211437,'冷玉轩',1437,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211438,'鞠宏博',1438,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211439,'许鸿宝',1439,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211440,'衡宜民',1440,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211441,'亢弘图',1441,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211442,'麻建本',1442,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211443,'关凌波',1443,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211444,'堪炎彬',1444,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211445,'丛永元',1445,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211446,'端半雪',1446,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211447,'郎飞虎',1447,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211448,'琴先生',1448,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211449,'马阳秋',1449,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211450,'赖兴昌',1450,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211451,'仉弘雅',1451,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211452,'喻千雁',1452,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211453,'艾力学',1453,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211454,'西门博超',1454,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211455,'牟才良',1455,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211456,'康锐志',1456,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211457,'归彬郁',1457,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211458,'南宫德华',1458,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211459,'慕容星文',1459,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211460,'能光启',1460,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211461,'通洁',1461,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211462,'别康健',1462,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211463,'顾乌',1463,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211464,'闾丘德元',1464,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211465,'咸药王',1465,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211466,'狄立人',1466,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211467,'伯匪',1467,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211468,'卫头陀',1468,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211469,'别文乐',1469,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211470,'居泰鸿',1470,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211471,'容勇毅',1471,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211472,'贲老九',1472,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211473,'晋凯安',1473,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211474,'芮弼',1474,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211475,'沃灭绝',1475,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211476,'雷永思',1476,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211477,'苗华清',1477,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211478,'胡元魁',1478,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211479,'汪泽语',1479,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211480,'真峻',1480,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211481,'栾伟茂',1481,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211482,'奚自强',1482,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211483,'封虔纹',1483,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211484,'简宜民',1484,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211485,'燕锐逸',1485,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211486,'堪瑛',1486,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211487,'富翰藻',1487,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211488,'呼延雅珺',1488,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211489,'谢天罡',1489,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211490,'冉康宁',1490,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211491,'马芷珍',1491,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211492,'印锐精',1492,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211493,'左丘宏博',1493,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211494,'史盼波',1494,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211495,'归海储',1495,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211496,'贲宏义',1496,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211497,'屈鸿飞',1497,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211498,'段浩浩',1498,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211499,'戈泰初',1499,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211500,'田飞鸣',1500,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211501,'南虔',1501,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211502,'靳承运',1502,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211503,'狄振国',1503,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211504,'许雨星',1504,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211505,'边恶天',1505,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211506,'东门剑愁',1506,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211507,'林翠安',1507,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211508,'习水蓉',1508,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211509,'汪凝芙',1509,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211510,'蓟宏伟',1510,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211511,'微生兴贤',1511,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211512,'融如凡',1512,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211513,'呼延无血',1513,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211514,'冷弘雅',1514,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211515,'宗涵蕾',1515,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211516,'帅正德',1516,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211517,'章紫槐',1517,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211518,'廖浩天',1518,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211519,'麻曼安',1519,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211520,'莘正奇',1520,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211521,'严判官',1521,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211522,'伯翠梅',1522,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211523,'狄鲂',1523,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211524,'鲁立果',1524,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211525,'贡彬炳',1525,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211526,'欧阳天工',1526,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211527,'查建德',1527,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211528,'归海建华',1528,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211529,'慎正谊',1529,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211530,'辟明辉',1530,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211531,'宓鸿熙',1531,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211532,'杨星剑',1532,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211533,'梁丘听南',1533,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211534,'司空立群',1534,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211535,'郝翰林',1535,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211536,'天德庸',1536,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211537,'令狐承福',1537,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211538,'山凝云',1538,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211539,'佘蛟王',1539,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211540,'景正平',1540,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211541,'司徒嘉石',1541,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211542,'凌一德',1542,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211543,'阚力学',1543,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211544,'琦乐章',1544,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211545,'冯鸿畅',1545,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211546,'廖高洁',1546,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211547,'波康安',1547,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211548,'干虔',1548,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211549,'冷问梅',1549,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211550,'苗乐志',1550,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211551,'裴光耀',1551,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211552,'闾乘云',1552,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211553,'俞弘义',1553,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211554,'红永丰',1554,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211555,'袁涵涤',1555,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211556,'皮成双',1556,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211557,'夹谷文耀',1557,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211558,'徐誉',1558,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211559,'简访枫',1559,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211560,'任妙菡',1560,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211561,'通展鹏',1561,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211562,'公西自怡',1562,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211563,'扈和歌',1563,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211564,'王天寿',1564,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211565,'嵇子涵',1565,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211566,'卜俊力',1566,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211567,'盛阳飇',1567,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211568,'江德惠',1568,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211569,'石飞扬',1569,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211570,'利承弼',1570,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211571,'熊宜民',1571,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211572,'欧阳良哲',1572,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211573,'池英勋',1573,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211574,'养光霁',1574,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211575,'苗宇航',1575,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211576,'管伟懋',1576,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211577,'龚哲彦',1577,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211578,'贡乐志',1578,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211579,'华和惬',1579,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211580,'韶灵萱',1580,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211581,'翁意智',1581,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211582,'帅芹',1582,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211583,'通老四',1583,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211584,'漆岩',1584,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211585,'屈明俊',1585,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211586,'康宇荫',1586,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211587,'司寇祺祥',1587,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211588,'卓弘义',1588,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211589,'琦鹤',1589,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211590,'荆天川',1590,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211591,'强乐康',1591,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211592,'贰学民',1592,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211593,'汤明德',1593,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211594,'璩高远',1594,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211595,'太叔凯旋',1595,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211596,'柴康健',1596,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211597,'隆天川',1597,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211598,'翦雪冥',1598,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211599,'包宏远',1599,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211600,'季阳伯',1600,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211601,'寸景辉',1601,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211602,'酆鸿彩',1602,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211603,'糜正德',1603,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211604,'邵修贤',1604,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211605,'康理全',1605,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211606,'方无极',1606,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211607,'纪擎汉',1607,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211608,'侯星海',1608,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211609,'子车行者',1609,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211610,'水文彬',1610,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211611,'汪黎昕',1611,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211612,'童鹏鲸',1612,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211613,'辛安平',1613,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211614,'万俟龙尊',1614,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211615,'都山河',1615,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211616,'商同甫',1616,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211617,'柴星阑',1617,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211618,'阚浩涆',1618,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211619,'平高达',1619,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211620,'竺伟祺',1620,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211621,'闻人英喆',1621,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211622,'瞿尔柳',1622,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211623,'明信然',1623,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211624,'公羊才俊',1624,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211625,'逄星雨',1625,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211626,'穰白凡',1626,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211627,'星乐欣',1627,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211628,'席承运',1628,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211629,'代浩阑',1629,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211630,'夏侯夜绿',1630,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211631,'山一刀',1631,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211632,'真温纶',1632,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211633,'戴乐家',1633,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211634,'熊瀚玥',1634,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211635,'卜乐逸',1635,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211636,'巫乐章',1636,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211637,'家书生',1637,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211638,'井乐水',1638,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211639,'蒯宾实',1639,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211640,'融涛',1640,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211641,'姚志勇',1641,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211642,'上官翰飞',1642,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211643,'谷成和',1643,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211644,'仰晟睿',1644,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211645,'郝成礼',1645,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211646,'燕之柔',1646,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211647,'盍承弼',1647,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211648,'锺和平',1648,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211649,'朱嘉德',1649,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211650,'赫天寿',1650,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211651,'慎瀚海',1651,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211652,'房振海',1652,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211653,'仲子琪',1653,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211654,'伯赏安卉',1654,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211655,'呼延新烟',1655,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211656,'真康乐',1656,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211657,'汝欧巴',1657,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211658,'和博远',1658,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211659,'闾博达',1659,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211660,'亢俊远',1660,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211661,'酆媚颜',1661,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211662,'皮尔芙',1662,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211663,'鲁凌兰',1663,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211664,'乐德水',1664,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211665,'温汲',1665,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211666,'钮凝丹',1666,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211667,'溥正初',1667,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211668,'史弘和',1668,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211669,'黄兴发',1669,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211670,'冯承德',1670,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211671,'车光明',1671,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211672,'融鹰王',1672,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211673,'乐正雪峰',1673,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211674,'黄弘阔',1674,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211675,'应俊民',1675,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211676,'钮茹嫣',1676,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211677,'莘银狐',1677,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211678,'宣鸿羽',1678,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211679,'平阳秋',1679,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211680,'焦嘉珍',1680,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211681,'滑行天',1681,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211682,'常俊彦',1682,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211683,'碧弘义',1683,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211684,'颛孙和雅',1684,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211685,'巢擎',1685,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211686,'仰冷之',1686,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211687,'奚嘉木',1687,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211688,'潘锐思',1688,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211689,'於将军',1689,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211690,'那安民',1690,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211691,'边绝义',1691,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211692,'厍锐意',1692,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211693,'樊珩',1693,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211694,'苗瀚漠',1694,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211695,'费高昂',1695,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211696,'穆伟博',1696,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211697,'皇甫元嘉',1697,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211698,'杨炎彬',1698,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211699,'田嘉德',1699,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211700,'秋元洲',1700,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211701,'羊修伟',1701,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211702,'东不斜',1702,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211703,'查天禄',1703,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211704,'湛士晋',1704,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211705,'波力言',1705,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211706,'方和安',1706,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211707,'亢遥',1707,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211708,'陆谷冬',1708,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211709,'寿德寿',1709,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211710,'司寇俊迈',1710,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211711,'乌承福',1711,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211712,'唐雪萍',1712,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211713,'元鬼神',1713,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211714,'党子轩',1714,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211715,'党睿好',1715,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211716,'颜宏远',1716,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211717,'宿如天',1717,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211718,'项绮玉',1718,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211719,'郜雪曼',1719,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211720,'杨飞飙',1720,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211721,'丁刚豪',1721,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211722,'夹谷茂勋',1722,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211723,'吴澹',1723,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211724,'凌博实',1724,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211725,'令狐睿好',1725,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211726,'曹元灵',1726,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211727,'银明志',1727,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211728,'严鹤',1728,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211729,'通人英',1729,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211730,'扶筝',1730,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211731,'钭阳冰',1731,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211732,'强寒松',1732,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211733,'江嘉谊',1733,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211734,'乐正雨琴',1734,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211735,'崔香儿',1735,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211736,'章鸿运',1736,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211737,'水中道',1737,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211738,'阮修洁',1738,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211739,'咸修然',1739,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211740,'霍傲晴',1740,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211741,'蔚璞瑜',1741,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211742,'姚杉杉',1742,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211743,'夔乐山',1743,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211744,'祖季同',1744,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211745,'西门建本',1745,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211746,'艾坤',1746,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211747,'都向荣',1747,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211748,'那兴生',1748,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211749,'廖鸿晖',1749,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211750,'后星火',1750,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211751,'暨若血',1751,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211752,'许凯捷',1752,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211753,'支乐邦',1753,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211754,'张承恩',1754,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211755,'桂蓝血',1755,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211756,'雍文星',1756,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211757,'厍德地',1757,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211758,'集同化',1758,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211759,'卫难胜',1759,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211760,'乌涫',1760,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211761,'钱万天',1761,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211762,'闾丘岩',1762,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211763,'戎永新',1763,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211764,'隆雅懿',1764,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211765,'翦逸士',1765,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211766,'贯明旭',1766,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211767,'曹夜香',1767,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211768,'熊臻',1768,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211769,'冉思聪',1769,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211770,'满向天',1770,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211771,'潘若之',1771,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211772,'韩阳朔',1772,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211773,'萧含雁',1773,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211774,'匡峻',1774,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211775,'聂英发',1775,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211776,'潘鬼神',1776,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211777,'孔建柏',1777,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211778,'尤乐圣',1778,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211779,'越光远',1779,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211780,'禄星海',1780,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211781,'蒯无极',1781,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211782,'夏浦和',1782,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211783,'蓟以彤',1783,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211784,'夹谷金鑫',1784,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211785,'翟超',1785,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211786,'訾弘深',1786,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211787,'陶宇达',1787,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211788,'喻华采',1788,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211789,'鞠荧荧',1789,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211790,'方斌蔚',1790,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211791,'贺德华',1791,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211792,'宓孟尝',1792,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211793,'尉迟烨磊',1793,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211794,'颛孙新荣',1794,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211795,'弓自中',1795,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211796,'隗涵',1796,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211797,'满开朗',1797,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211798,'钭依波',1798,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211799,'党高格',1799,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211800,'赫梦松',1800,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211801,'轩辕子昂',1801,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211802,'蒲经艺',1802,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211803,'羿高格',1803,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211804,'羿彬',1804,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211805,'僪天抒',1805,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211806,'古天赋',1806,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211807,'扶睿慈',1807,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211808,'郁英睿',1808,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211809,'匡城',1809,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211810,'时成天',1810,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211811,'银雅达',1811,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211812,'陈不悔',1812,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211813,'王永言',1813,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211814,'鞠高朗',1814,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211815,'宫修能',1815,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211816,'满少主',1816,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211817,'衣浩初',1817,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211818,'诸葛乘风',1818,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211819,'苏星晖',1819,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211820,'贰起眸',1820,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211821,'茹安荷',1821,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211822,'钟离高邈',1822,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211823,'翟千筹',1823,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211824,'訾景胜',1824,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211825,'舜锐锋',1825,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211826,'历元龙',1826,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211827,'呼延英睿',1827,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211828,'赵修能',1828,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211829,'宦成危',1829,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211830,'惠星汉',1830,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211831,'司空康伯',1831,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211832,'房景同',1832,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211833,'贝乐天',1833,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211834,'奚良工',1834,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211835,'翦光远',1835,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211836,'房和泽',1836,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211837,'司空星驰',1837,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211838,'庞飞鹏',1838,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211839,'楚德业',1839,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211840,'茅宜人',1840,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211841,'贵文栋',1841,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211842,'仲孙作人',1842,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211843,'卓代曼',1843,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211844,'堵和风',1844,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211845,'令狐景福',1845,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211846,'明宏伟',1846,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211847,'子车学民',1847,90004,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211848,'孙轻侯',1848,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211849,'漆法王',1849,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211850,'佘光辉',1850,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211851,'子车伟祺',1851,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211852,'富小玉',1852,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211853,'费昊穹',1853,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211854,'沈瀚漠',1854,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211855,'薛风华',1855,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211856,'宝半仙',1856,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211857,'万小菁',1857,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211858,'拓跋杰',1858,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211859,'湛和宜',1859,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211860,'怀平蝶',1860,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211861,'刁怜烟',1861,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211862,'朱成双',1862,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211863,'栾嘉石',1863,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211864,'帅乐志',1864,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211865,'利碧',1865,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211866,'伯力夫',1866,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211867,'邬翰学',1867,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211868,'汲兴修',1868,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211869,'郭世平',1869,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211870,'汲鸿彩',1870,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211871,'宝俊艾',1871,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211872,'宁乞',1872,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211873,'顾道童',1873,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211874,'毋文斌',1874,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211875,'褚承弼',1875,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211876,'印芷蕊',1876,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211877,'平华奥',1877,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211878,'杭弘盛',1878,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211879,'钞俊风',1879,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211880,'强良吉',1880,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211881,'韦翰池',1881,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211882,'缑千雁',1882,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211883,'接老五',1883,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211884,'华嘉庆',1884,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211885,'蓬嘉悦',1885,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211886,'羿子琪',1886,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211887,'窦飞',1887,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211888,'甘阳曜',1888,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211889,'钱谷丝',1889,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211890,'郑玉轩',1890,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211891,'柏星纬',1891,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211892,'韶沛白',1892,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211893,'晁修齐',1893,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211894,'闵康胜',1894,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211895,'石乐生',1895,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211896,'都如柏',1896,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211897,'席俊材',1897,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211898,'贡凛',1898,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211899,'求高逸',1899,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211900,'子车乘风',1900,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211901,'微生书生',1901,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211902,'汪续',1902,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211903,'韶文乐',1903,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211904,'山兴旺',1904,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211905,'戴俊楠',1905,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211906,'安宏逸',1906,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211907,'司马雨星',1907,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211908,'幸子轩',1908,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211909,'暨难破',1909,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211910,'巫文德',1910,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211911,'应越彬',1911,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211912,'奚彬炳',1912,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211913,'充诗槐',1913,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211914,'暴盼儿',1914,90019,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211915,'席德佑',1915,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211916,'党俊德',1916,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211917,'温映真',1917,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211918,'刘鸿彩',1918,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211919,'仲孙博远',1919,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211920,'赏书瑶',1920,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211921,'花嘉石',1921,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211922,'尚高兴',1922,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211923,'闾建义',1923,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211924,'濮阳山河',1924,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211925,'邬秋',1925,90029,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211926,'鞠从阳',1926,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211927,'宗寄柔',1927,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211928,'饶谷菱',1928,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211929,'卜高格',1929,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211930,'符才良',1930,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211931,'蓟成益',1931,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211932,'莫上人',1932,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211933,'申世开',1933,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211934,'百里俊哲',1934,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211935,'翁成危',1935,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211936,'代弘义',1936,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211937,'明宛凝',1937,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211938,'松意远',1938,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211939,'崔芷雪',1939,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211940,'暨玉泉',1940,90005,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211941,'任儒生',1941,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211942,'速水之',1942,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211943,'周涵煦',1943,90020,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211944,'易弘新',1944,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211945,'淳于元魁',1945,90017,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211946,'赫连天奇',1946,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211947,'米老五',1947,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211948,'白晗昱',1948,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211949,'房翰学',1949,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211950,'仲孙玉树',1950,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211951,'屠梦之',1951,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211952,'权仇血',1952,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211953,'速伟才',1953,90014,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211954,'温富',1954,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211955,'桓弘盛',1955,90011,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211956,'通幻儿',1956,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211957,'彤问玉',1957,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211958,'储飞扬',1958,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211959,'鄂伯云',1959,90013,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211960,'归恶天',1960,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211961,'却敏达',1961,90003,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211962,'养涵雁',1962,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211963,'衡天与',1963,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211964,'郎臻',1964,90024,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211965,'郑宏义',1965,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211966,'朱才良',1966,90015,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211967,'空鸿达',1967,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211968,'臧天禄',1968,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211969,'官康裕',1969,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211970,'燕飞飙',1970,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211971,'扈亭儿',1971,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211972,'亢怡',1972,90008,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211973,'席学义',1973,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211974,'隗正豪',1974,90010,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211975,'桓高爽',1975,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211976,'边元柳',1976,90023,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211977,'公睿广',1977,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211978,'邰苑博',1978,90007,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211979,'靳英韶',1979,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211980,'訾嘉德',1980,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211981,'李乐邦',1981,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211982,'司凯旋',1982,90026,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211983,'闵飞章',1983,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211984,'仰涵容',1984,90009,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211985,'速靖琪',1985,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211986,'潘乐志',1986,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211987,'沃惮',1987,90006,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211988,'乐正嘉玉',1988,90025,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211989,'怀逸士',1989,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211990,'宁若颜',1990,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211991,'燕干将',1991,90027,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211992,'巩瀚海',1992,90028,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211993,'国经赋',1993,90001,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211994,'姜子轩',1994,90016,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211995,'顾博实',1995,90021,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211996,'申屠雪风',1996,90030,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211997,'须千万',1997,90022,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211998,'湛惋庭',1998,90012,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100211999,'亢成风',1999,90002,'',0,2,0,0,0,0,0,0,'[]','[]',0,0),(100212000,'辟雨珍',2000,90018,'',0,2,0,0,0,0,0,0,'[]','[]',0,0);

/*Table structure for table `t_single_war` */

DROP TABLE IF EXISTS `t_single_war`;

CREATE TABLE `t_single_war` (
  `id` bigint(20) NOT NULL,
  `content` text NOT NULL,
  `currenChapter` int(11) DEFAULT '0',
  `sweepData` text,
  `lastActionTime` bigint(20) DEFAULT '0',
  `chapterRewards` text,
  `eliteTranScriptCount` int(4) DEFAULT '0',
  `eliteTranscriptLastTime` bigint(8) DEFAULT '0',
  `rewardTranscriptTimes` int(4) DEFAULT '0',
  `rewardTranscriptLastTime` bigint(8) DEFAULT '0',
  `today_sweep_times` int(11) DEFAULT NULL,
  `last_sweep_time` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_single_war` */

/*Table structure for table `t_skill` */

DROP TABLE IF EXISTS `t_skill`;

CREATE TABLE `t_skill` (
  `human_uuid` bigint(20) NOT NULL DEFAULT '0',
  `curr_skill_points` int(11) DEFAULT '0',
  `curr_used_group_index` int(11) DEFAULT '0',
  `group_slot_1` varchar(32) DEFAULT NULL,
  `group_slot_2` varchar(32) DEFAULT NULL,
  `level_skill_1` int(11) DEFAULT '0',
  `level_skill_2` int(11) DEFAULT '0',
  `level_skill_3` int(11) DEFAULT '0',
  `level_skill_4` int(11) DEFAULT '0',
  `level_skill_5` int(11) DEFAULT '0',
  `level_skill_6` int(11) DEFAULT '0',
  `level_skill_7` int(11) DEFAULT '0',
  `level_skill_8` int(11) DEFAULT '0',
  `level_skill_9` int(11) DEFAULT '0',
  `level_skill_10` int(11) DEFAULT '0',
  `extra_skill_points` int(11) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_skill` */

/*Table structure for table `t_small_pet` */

DROP TABLE IF EXISTS `t_small_pet`;

CREATE TABLE `t_small_pet` (
  `id` varchar(64) NOT NULL,
  `humanUUID` bigint(20) DEFAULT NULL,
  `smallPetId` int(11) DEFAULT NULL,
  `star` int(11) DEFAULT NULL,
  `physicAttack` int(11) DEFAULT '0',
  `magicAttack` int(11) DEFAULT '0',
  `physicDefend` int(11) DEFAULT '0',
  `magicDefend` int(11) DEFAULT '0',
  `life` int(11) DEFAULT '0',
  `crit` int(11) DEFAULT '0',
  `countCrit` int(11) DEFAULT '0',
  `parry` int(11) DEFAULT '0',
  `countParry` int(11) DEFAULT '0',
  `fight` int(11) DEFAULT '0',
  `lastUpdateTime` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) DEFAULT NULL,
  `bagType` int(11) DEFAULT '1',
  `wearType` smallint(1) DEFAULT '0',
  `luckProps` varchar(512) DEFAULT NULL,
  `wearId` varchar(64) DEFAULT NULL,
  `itemTmpId` int(11) DEFAULT '0',
  `poFang` int(11) DEFAULT '0',
  `kangPo` int(11) DEFAULT '0',
  `devSucTimes` int(11) DEFAULT '0',
  `isDeleted` int(11) DEFAULT '0',
  `deleteTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `smallpet_index` (`humanUUID`,`smallPetId`),
  KEY `humanUUID` (`humanUUID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_small_pet` */

/*Table structure for table `t_small_pet_skill` */

DROP TABLE IF EXISTS `t_small_pet_skill`;

CREATE TABLE `t_small_pet_skill` (
  `id` varchar(64) NOT NULL,
  `humanUUID` bigint(20) DEFAULT NULL,
  `petSkillTmpId` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `lastUpdateTime` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) DEFAULT NULL,
  `bagType` int(11) DEFAULT '1',
  `wearType` smallint(1) DEFAULT '0',
  `wearId` varchar(512) DEFAULT NULL,
  `isDeleted` int(11) DEFAULT '0',
  `deleteTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `petskill_index` (`humanUUID`,`petSkillTmpId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_small_pet_skill` */

/*Table structure for table `t_smallpet_ach` */

DROP TABLE IF EXISTS `t_smallpet_ach`;

CREATE TABLE `t_smallpet_ach` (
  `uuid` bigint(22) NOT NULL,
  `petAchState` text,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_smallpet_ach` */

/*Table structure for table `t_smallpet_rank` */

DROP TABLE IF EXISTS `t_smallpet_rank`;

CREATE TABLE `t_smallpet_rank` (
  `id` bigint(20) NOT NULL,
  `fightPower` int(11) NOT NULL DEFAULT '0',
  `maxlevel` int(11) NOT NULL DEFAULT '0',
  `count` int(11) NOT NULL DEFAULT '0',
  `maxUpLevel` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_smallpet_rank` */

/*Table structure for table `t_sort_arenalevel` */

DROP TABLE IF EXISTS `t_sort_arenalevel`;

CREATE TABLE `t_sort_arenalevel` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `arenaLevel` int(11) DEFAULT NULL,
  `arenaRank` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_arenalevel` */

/*Table structure for table `t_sort_development` */

DROP TABLE IF EXISTS `t_sort_development`;

CREATE TABLE `t_sort_development` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `development` bigint(20) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_development` */

/*Table structure for table `t_sort_dg_hunt` */

DROP TABLE IF EXISTS `t_sort_dg_hunt`;

CREATE TABLE `t_sort_dg_hunt` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `huntLevel` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_dg_hunt` */

/*Table structure for table `t_sort_dgprestige` */

DROP TABLE IF EXISTS `t_sort_dgprestige`;

CREATE TABLE `t_sort_dgprestige` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `prestige` int(11) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_dgprestige` */

/*Table structure for table `t_sort_hunt` */

DROP TABLE IF EXISTS `t_sort_hunt`;

CREATE TABLE `t_sort_hunt` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `huntLevel` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_hunt` */

/*Table structure for table `t_sort_mg_hunt` */

DROP TABLE IF EXISTS `t_sort_mg_hunt`;

CREATE TABLE `t_sort_mg_hunt` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `huntLevel` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_mg_hunt` */

/*Table structure for table `t_sort_mgprestige` */

DROP TABLE IF EXISTS `t_sort_mgprestige`;

CREATE TABLE `t_sort_mgprestige` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `prestige` int(11) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_mgprestige` */

/*Table structure for table `t_sort_sl_hunt` */

DROP TABLE IF EXISTS `t_sort_sl_hunt`;

CREATE TABLE `t_sort_sl_hunt` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `huntLevel` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_sl_hunt` */

/*Table structure for table `t_sort_slprestige` */

DROP TABLE IF EXISTS `t_sort_slprestige`;

CREATE TABLE `t_sort_slprestige` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `prestige` int(11) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_slprestige` */

/*Table structure for table `t_sort_sw` */

DROP TABLE IF EXISTS `t_sort_sw`;

CREATE TABLE `t_sort_sw` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `petLevel` int(11) DEFAULT NULL,
  `petName` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `sw` int(11) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `zl` int(11) DEFAULT NULL,
  `zs` int(11) DEFAULT NULL,
  `zy` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_sw` */

/*Table structure for table `t_sort_worldprestige` */

DROP TABLE IF EXISTS `t_sort_worldprestige`;

CREATE TABLE `t_sort_worldprestige` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `prestige` int(11) DEFAULT NULL,
  `rank` int(11) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_worldprestige` */

/*Table structure for table `t_sort_zl` */

DROP TABLE IF EXISTS `t_sort_zl`;

CREATE TABLE `t_sort_zl` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `petLevel` int(11) DEFAULT NULL,
  `petName` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `sw` int(11) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `zl` int(11) DEFAULT NULL,
  `zs` int(11) DEFAULT NULL,
  `zy` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_zl` */

/*Table structure for table `t_sort_zs` */

DROP TABLE IF EXISTS `t_sort_zs`;

CREATE TABLE `t_sort_zs` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `petLevel` int(11) DEFAULT NULL,
  `petName` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `sw` int(11) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `zl` int(11) DEFAULT NULL,
  `zs` int(11) DEFAULT NULL,
  `zy` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_zs` */

/*Table structure for table `t_sort_zy` */

DROP TABLE IF EXISTS `t_sort_zy`;

CREATE TABLE `t_sort_zy` (
  `id` bigint(20) NOT NULL,
  `accountId` bigint(20) DEFAULT NULL,
  `alliance` int(11) DEFAULT NULL,
  `guildPack` text,
  `indexSort` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `petLevel` int(11) DEFAULT NULL,
  `petName` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `sw` int(11) DEFAULT NULL,
  `upOrDown` int(11) DEFAULT NULL,
  `zl` int(11) DEFAULT NULL,
  `zs` int(11) DEFAULT NULL,
  `zy` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sort_zy` */

/*Table structure for table `t_soub_battle` */

DROP TABLE IF EXISTS `t_soub_battle`;

CREATE TABLE `t_soub_battle` (
  `name` varchar(128) NOT NULL,
  `id` bigint(128) NOT NULL,
  `rank` int(8) DEFAULT '0',
  `rewardId` int(8) DEFAULT '0',
  `yesterdayRank` int(8) DEFAULT '0',
  `record` text,
  `level` int(8) DEFAULT '0',
  `girl` smallint(1) DEFAULT NULL,
  `jobId` int(11) DEFAULT NULL,
  `buyTimes` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_soub_battle` */

/*Table structure for table `t_specifictimerewardrecord` */

DROP TABLE IF EXISTS `t_specifictimerewardrecord`;

CREATE TABLE `t_specifictimerewardrecord` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `humanUUID` bigint(20) DEFAULT NULL,
  `hasGotReward` tinyint(4) DEFAULT NULL,
  `hasTakePartIn` tinyint(4) DEFAULT NULL,
  `activityId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_specifictimerewardrecord` */

/*Table structure for table `t_spring_activity` */

DROP TABLE IF EXISTS `t_spring_activity`;

CREATE TABLE `t_spring_activity` (
  `id` bigint(20) NOT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_spring_activity` */

/*Table structure for table `t_spring_festival` */

DROP TABLE IF EXISTS `t_spring_festival`;

CREATE TABLE `t_spring_festival` (
  `uuid` bigint(20) NOT NULL,
  `state` int(11) DEFAULT NULL,
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_spring_festival` */

/*Table structure for table `t_story` */

DROP TABLE IF EXISTS `t_story`;

CREATE TABLE `t_story` (
  `id` bigint(20) NOT NULL,
  `state` varchar(512) NOT NULL DEFAULT '"[]"',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_story` */

/*Table structure for table `t_sweep_info` */

DROP TABLE IF EXISTS `t_sweep_info`;

CREATE TABLE `t_sweep_info` (
  `id` bigint(20) NOT NULL,
  `addTime` bigint(20) DEFAULT NULL,
  `endTime` bigint(20) DEFAULT NULL,
  `templateId` int(11) DEFAULT NULL,
  `sweepNum` int(11) DEFAULT NULL,
  `totalNum` int(11) DEFAULT NULL,
  `rewardsStr` text,
  `lastRewardTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sweep_info` */

/*Table structure for table `t_sync_version` */

DROP TABLE IF EXISTS `t_sync_version`;

CREATE TABLE `t_sync_version` (
  `id` int(11) NOT NULL,
  `syncName` varchar(255) DEFAULT NULL,
  `syncCount` int(5) DEFAULT NULL,
  `syncVersion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sync_version` */

/*Table structure for table `t_sys_switch` */

DROP TABLE IF EXISTS `t_sys_switch`;

CREATE TABLE `t_sys_switch` (
  `switch_id` int(11) NOT NULL DEFAULT '0',
  `flag` tinyint(3) unsigned zerofill DEFAULT '000',
  PRIMARY KEY (`switch_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_sys_switch` */

insert  into `t_sys_switch`(`switch_id`,`flag`) values (1301,000);

/*Table structure for table `t_task_base` */

DROP TABLE IF EXISTS `t_task_base`;

CREATE TABLE `t_task_base` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `taskId` int(11) DEFAULT NULL,
  `status` tinyint(4) DEFAULT NULL,
  `finishCount` int(11) DEFAULT NULL,
  `taskParams` varchar(512) DEFAULT NULL,
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `endTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_task_base` */

/*Table structure for table `t_task_log` */

DROP TABLE IF EXISTS `t_task_log`;

CREATE TABLE `t_task_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) DEFAULT NULL,
  `taskId` int(11) DEFAULT NULL,
  `taskStatus` tinyint(4) DEFAULT NULL,
  `taskFinishType` tinyint(4) DEFAULT NULL,
  `finishTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=MyISAM AUTO_INCREMENT=116 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_task_log` */

/*Table structure for table `t_teamwar` */

DROP TABLE IF EXISTS `t_teamwar`;

CREATE TABLE `t_teamwar` (
  `human_uuid` bigint(20) NOT NULL DEFAULT '0',
  `used_gain_times` int(11) DEFAULT '0',
  `last_used_time` bigint(20) DEFAULT '0',
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_teamwar` */

/*Table structure for table `t_time_notice` */

DROP TABLE IF EXISTS `t_time_notice`;

CREATE TABLE `t_time_notice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `intervalTime` int(11) unsigned zerofill DEFAULT NULL,
  `serverIds` varchar(255) DEFAULT NULL,
  `operator` varchar(255) DEFAULT NULL,
  `content` text,
  `startTime` timestamp NULL DEFAULT NULL,
  `endTime` timestamp NULL DEFAULT NULL,
  `openType` tinyint(4) NOT NULL DEFAULT '0',
  `type` tinyint(4) NOT NULL DEFAULT '0',
  `subType` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `serverIds` (`serverIds`),
  KEY `type` (`type`),
  KEY `subType` (`subType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_time_notice` */

/*Table structure for table `t_time_prize` */

DROP TABLE IF EXISTS `t_time_prize`;

CREATE TABLE `t_time_prize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prizeId` bigint(20) DEFAULT NULL,
  `prizeName` varchar(255) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `periodTime` datetime DEFAULT NULL,
  `prizePackage` text,
  `prizeOpen` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `prizeId` (`prizeId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_time_prize` */

/*Table structure for table `t_tomb_challenge` */

DROP TABLE IF EXISTS `t_tomb_challenge`;

CREATE TABLE `t_tomb_challenge` (
  `id` int(20) NOT NULL,
  `roleId` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tomb_challenge` */

/*Table structure for table `t_tomb_eventdata` */

DROP TABLE IF EXISTS `t_tomb_eventdata`;

CREATE TABLE `t_tomb_eventdata` (
  `id` bigint(11) NOT NULL AUTO_INCREMENT,
  `roleId` bigint(20) DEFAULT NULL,
  `layerId` int(11) DEFAULT '0',
  `x` int(11) DEFAULT '0',
  `y` int(11) DEFAULT '0',
  `eventId` int(11) DEFAULT '0',
  `startTime` bigint(20) DEFAULT '0',
  `waitTime` int(11) DEFAULT '0',
  `trigeTick` int(11) DEFAULT '0',
  `eventJson` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `layerid` (`roleId`,`layerId`,`x`,`y`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tomb_eventdata` */

/*Table structure for table `t_tomb_humandata` */

DROP TABLE IF EXISTS `t_tomb_humandata`;

CREATE TABLE `t_tomb_humandata` (
  `id` bigint(11) NOT NULL AUTO_INCREMENT,
  `roleId` bigint(20) DEFAULT '0',
  `layerId` int(11) DEFAULT '1',
  `layerState` int(11) DEFAULT '0',
  `x` int(11) DEFAULT '0',
  `y` int(11) DEFAULT '0',
  `points` bigint(20) DEFAULT '0',
  `challengeCount` int(11) DEFAULT '0',
  `lastchallengeTime` bigint(20) DEFAULT '0',
  `lastResumeMove` bigint(20) DEFAULT '0',
  `layerPoints` int(20) DEFAULT '0',
  `skipCount` int(11) DEFAULT '0',
  `maxSkipCount` int(11) DEFAULT '0',
  `changeCount` int(11) DEFAULT '0',
  `resetCount` int(11) DEFAULT '0',
  `moveCount` int(11) DEFAULT '0',
  `maxMoveCount` int(11) DEFAULT '50',
  `viewLimit` int(11) DEFAULT '1',
  `moveLimit` int(11) DEFAULT '1',
  `bufStateJson` text,
  `mapId` int(11) DEFAULT '0',
  `layerMap` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `roleId` (`roleId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tomb_humandata` */

/*Table structure for table `t_tomb_layerdata` */

DROP TABLE IF EXISTS `t_tomb_layerdata`;

CREATE TABLE `t_tomb_layerdata` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `layerId` int(11) DEFAULT '0',
  `bufJson` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `layerid` (`layerId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tomb_layerdata` */

/*Table structure for table `t_tower` */

DROP TABLE IF EXISTS `t_tower`;

CREATE TABLE `t_tower` (
  `id` bigint(64) NOT NULL,
  `content` text,
  `tower1ReviveTimes` int(11) NOT NULL DEFAULT '0',
  `tower2ReviveTimes` int(11) NOT NULL DEFAULT '0',
  `tower3ReviveTimes` int(11) NOT NULL DEFAULT '0',
  `tower4ReviveTimes` int(11) NOT NULL DEFAULT '0',
  `tower1MaxLayer` int(11) NOT NULL DEFAULT '0',
  `tower2MaxLayer` int(11) NOT NULL DEFAULT '0',
  `tower3MaxLayer` int(11) NOT NULL DEFAULT '0',
  `tower4MaxLayer` int(11) NOT NULL DEFAULT '0',
  `tower1Die` smallint(11) NOT NULL DEFAULT '0',
  `tower2Die` smallint(11) NOT NULL DEFAULT '0',
  `tower3Die` smallint(11) NOT NULL DEFAULT '0',
  `tower4Die` smallint(11) NOT NULL DEFAULT '0',
  `tower1CurrentLayer` int(11) NOT NULL DEFAULT '0',
  `tower2CurrentLayer` int(11) NOT NULL DEFAULT '0',
  `tower3CurrentLayer` int(11) NOT NULL DEFAULT '0',
  `tower4CurrentLayer` int(11) NOT NULL DEFAULT '0',
  `tower1Begin` smallint(11) NOT NULL DEFAULT '0',
  `tower2Begin` smallint(11) NOT NULL DEFAULT '0',
  `tower3Begin` smallint(11) NOT NULL DEFAULT '0',
  `tower4Begin` smallint(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tower` */

/*Table structure for table `t_tower_record` */

DROP TABLE IF EXISTS `t_tower_record`;

CREATE TABLE `t_tower_record` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `arrive_time` bigint(20) NOT NULL,
  `layer` int(11) NOT NULL,
  `uuid` bigint(20) NOT NULL,
  `towerKind` int(11) DEFAULT NULL,
  `name` varchar(1024) NOT NULL DEFAULT '""',
  `vocationType` int(8) DEFAULT NULL,
  `level` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `NewIndex1` (`towerKind`),
  KEY `NewIndex2` (`uuid`)
) ENGINE=MyISAM AUTO_INCREMENT=23173 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_tower_record` */

/*Table structure for table `t_transaction` */

DROP TABLE IF EXISTS `t_transaction`;

CREATE TABLE `t_transaction` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `param` text,
  `productid` varchar(255) DEFAULT NULL,
  `regionid` varchar(255) DEFAULT NULL,
  `roleId` bigint(20) DEFAULT NULL,
  `rolename` varchar(255) DEFAULT NULL,
  `serverid` varchar(255) DEFAULT NULL,
  `transcationid` varchar(255) DEFAULT NULL,
  `updatetime` datetime NOT NULL,
  `userid` bigint(20) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `transcationKind` int(11) DEFAULT '1',
  `deviceID` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_transaction` */

/*Table structure for table `t_troops_soldier` */

DROP TABLE IF EXISTS `t_troops_soldier`;

CREATE TABLE `t_troops_soldier` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `human_uuid` bigint(20) DEFAULT NULL,
  `templete_id` int(11) DEFAULT '0',
  `skill_id` int(11) DEFAULT '0',
  `feature_id` int(11) DEFAULT '0',
  `level` int(11) DEFAULT '0',
  `be_recruit_num` int(11) DEFAULT '0',
  `be_arrange_num` int(11) DEFAULT '0',
  `be_arrange_index` int(11) DEFAULT '0',
  `blessing` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY ```uuid_index``` (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_troops_soldier` */

/*Table structure for table `t_ttuorial` */

DROP TABLE IF EXISTS `t_ttuorial`;

CREATE TABLE `t_ttuorial` (
  `id` varchar(32) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `targetId` int(11) NOT NULL,
  `targetStatus` tinyint(4) NOT NULL,
  `finishTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_ttuorial` */

/*Table structure for table `t_unreward_item_log` */

DROP TABLE IF EXISTS `t_unreward_item_log`;

CREATE TABLE `t_unreward_item_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) NOT NULL,
  `templateId` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `rewardTime` bigint(20) NOT NULL,
  `deadline` bigint(20) NOT NULL,
  `deleted` int(11) DEFAULT '0',
  `deleteDate` timestamp NULL DEFAULT NULL,
  `recordId` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`),
  KEY `recordId` (`recordId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_unreward_item_log` */

/*Table structure for table `t_unrewarditem_log` */

DROP TABLE IF EXISTS `t_unrewarditem_log`;

CREATE TABLE `t_unrewarditem_log` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) NOT NULL,
  `templateId` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `rewardTime` bigint(20) NOT NULL,
  `deadline` bigint(20) NOT NULL,
  `deleted` int(11) DEFAULT '0',
  `deleteDate` timestamp NULL DEFAULT NULL,
  `recordId` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`),
  KEY `recordId` (`recordId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_unrewarditem_log` */

/*Table structure for table `t_user_info` */

DROP TABLE IF EXISTS `t_user_info`;

CREATE TABLE `t_user_info` (
  `platform_uuid` varchar(64) NOT NULL,
  `pf` varchar(64) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `question` varchar(50) DEFAULT NULL,
  `answer` varchar(50) DEFAULT NULL,
  `joinTime` datetime DEFAULT NULL,
  `lastLoginTime` datetime DEFAULT NULL,
  `lastLogoutTime` datetime DEFAULT NULL,
  `failedLogins` int(11) NOT NULL DEFAULT '0',
  `lastLoginIp` varchar(50) DEFAULT NULL,
  `locale` varchar(50) DEFAULT NULL,
  `version` varchar(50) DEFAULT NULL,
  `role` int(11) NOT NULL DEFAULT '0',
  `lockStatus` int(11) NOT NULL DEFAULT '0',
  `muteTime` int(11) NOT NULL DEFAULT '0',
  `props` varchar(256) DEFAULT NULL,
  `todayOnlineTime` int(11) NOT NULL DEFAULT '0',
  `lastLoginTerminalType` int(11) DEFAULT NULL,
  `nameEncodeTag` int(11) DEFAULT '0',
  `passport_create_time` bigint(20) DEFAULT '0',
  PRIMARY KEY (`platform_uuid`),
  KEY `email` (`email`),
  KEY `role` (`role`),
  KEY `name` (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_user_info` */

insert  into `t_user_info`(`platform_uuid`,`pf`,`name`,`password`,`email`,`question`,`answer`,`joinTime`,`lastLoginTime`,`lastLogoutTime`,`failedLogins`,`lastLoginIp`,`locale`,`version`,`role`,`lockStatus`,`muteTime`,`props`,`todayOnlineTime`,`lastLoginTerminalType`,`nameEncodeTag`,`passport_create_time`) values ('1',NULL,'test1','1',NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,0,0,0,NULL,0,NULL,0,0);

/*Table structure for table `t_user_prize` */

DROP TABLE IF EXISTS `t_user_prize`;

CREATE TABLE `t_user_prize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `coin` varchar(255) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `item` varchar(255) DEFAULT NULL,
  `platform_uuid` varchar(64) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  `userPrizeName` varchar(255) DEFAULT NULL,
  `activityId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `passportId` (`platform_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_user_prize` */

/*Table structure for table `t_vip_reward` */

DROP TABLE IF EXISTS `t_vip_reward`;

CREATE TABLE `t_vip_reward` (
  `id` bigint(20) NOT NULL,
  `vipLevelReward` int(12) DEFAULT NULL,
  `dayReward` int(12) DEFAULT NULL,
  `dayRewardTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_vip_reward` */

/*Table structure for table `t_wallow` */

DROP TABLE IF EXISTS `t_wallow`;

CREATE TABLE `t_wallow` (
  `human_uuid` bigint(20) NOT NULL,
  `last_count_time` bigint(20) DEFAULT NULL,
  `online_duration` bigint(20) DEFAULT NULL,
  `have_real_info` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`human_uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_wallow` */

/*Table structure for table `t_warrior_rank` */

DROP TABLE IF EXISTS `t_warrior_rank`;

CREATE TABLE `t_warrior_rank` (
  `id` bigint(20) NOT NULL,
  `totalCard` int(11) NOT NULL DEFAULT '0',
  `wushuangCount` int(11) NOT NULL DEFAULT '0',
  `goldCount` int(11) NOT NULL DEFAULT '0',
  `purpleCount` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_warrior_rank` */

/*Table structure for table `t_warsets_manager` */

DROP TABLE IF EXISTS `t_warsets_manager`;

CREATE TABLE `t_warsets_manager` (
  `id` bigint(20) NOT NULL DEFAULT '0',
  `norWarSetsContent` text,
  `eliWarSetsContent` text,
  `norChapterContent` text,
  `eliChapterContent` text,
  `norCurChapterId` int(10) DEFAULT NULL,
  `eliCurChapterId` int(10) DEFAULT NULL,
  `norCurWarSetId` int(10) DEFAULT NULL,
  `eliCurWarSetId` int(10) DEFAULT NULL,
  `sumChanTimes` int(10) DEFAULT NULL,
  `lastChangeTime` bigint(20) DEFAULT '0',
  `lastEliChanTime` bigint(20) DEFAULT '0',
  `lastNorChanTime` bigint(20) DEFAULT '0',
  `sweepData` text,
  `lastSweepTime` bigint(20) DEFAULT '0',
  `todaySweepTimes` int(10) DEFAULT '0',
  `isSync` int(10) DEFAULT '0',
  `buySumTimes` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_warsets_manager` */

/*Table structure for table `t_white_user` */

DROP TABLE IF EXISTS `t_white_user`;

CREATE TABLE `t_white_user` (
  `id` bigint(20) NOT NULL,
  `openId` varchar(128) NOT NULL,
  `logdate` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_white_user` */

/*Table structure for table `t_wing` */

DROP TABLE IF EXISTS `t_wing`;

CREATE TABLE `t_wing` (
  `id` varchar(64) NOT NULL,
  `humanUUID` bigint(20) DEFAULT NULL,
  `wingId` int(11) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `upgradeQuality` int(11) DEFAULT NULL,
  `exp` int(11) DEFAULT NULL,
  `magicAttack` int(11) DEFAULT '0',
  `physicDefend` int(11) DEFAULT '0',
  `magicDefend` int(11) DEFAULT '0',
  `life` int(11) DEFAULT '0',
  `crit` int(11) DEFAULT '0',
  `countCrit` int(11) DEFAULT '0',
  `fight` int(11) DEFAULT '0',
  `lastUpdateTime` bigint(20) DEFAULT NULL,
  `createTime` bigint(20) DEFAULT NULL,
  `bagType` int(11) DEFAULT '1',
  `wearType` smallint(1) DEFAULT '0',
  `sortindex` int(11) DEFAULT '0',
  `physicAttack` int(11) DEFAULT '0',
  `parry` int(11) DEFAULT '0',
  `countParry` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `wing_index` (`humanUUID`,`wingId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC
/*!50100 PARTITION BY KEY (id)
PARTITIONS 10 */;

/*Data for the table `t_wing` */

/*Table structure for table `t_wing_rank` */

DROP TABLE IF EXISTS `t_wing_rank`;

CREATE TABLE `t_wing_rank` (
  `id` bigint(20) NOT NULL,
  `fightPower` int(11) NOT NULL DEFAULT '0',
  `maxlevel` int(11) NOT NULL DEFAULT '0',
  `count` int(11) NOT NULL DEFAULT '0',
  `maxUpLevel` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_wing_rank` */

/*Table structure for table `t_wonderful_activity` */

DROP TABLE IF EXISTS `t_wonderful_activity`;

CREATE TABLE `t_wonderful_activity` (
  `uuid` bigint(20) NOT NULL DEFAULT '0',
  `humanName` varchar(125) DEFAULT '""',
  `activity` text NOT NULL,
  `rechargeAct` text NOT NULL,
  `costAct` text NOT NULL,
  `gemstoneAct` text NOT NULL,
  `gemstoneValue` text NOT NULL,
  `cardlevelupAct` text NOT NULL,
  `cardlevelupValue` text NOT NULL,
  `towerlevelAct` text NOT NULL,
  `towerlevelValue` text NOT NULL,
  `rechargeValue` text NOT NULL,
  `costValue` text NOT NULL,
  `everydayAct` text NOT NULL,
  `everydayValue` text NOT NULL,
  `lastLoginTime` bigint(20) NOT NULL DEFAULT '0',
  `humanlevelAct` text NOT NULL,
  `humanLevelValue` text NOT NULL,
  `gemStone2Act` text NOT NULL,
  `gemstone2Value` text NOT NULL,
  `recharge2Act` text NOT NULL,
  `recharge2Value` text NOT NULL,
  `cost2Act` text NOT NULL,
  `cost2Value` text NOT NULL,
  `flyHigherAct` text NOT NULL,
  `flyHigherValue` text NOT NULL,
  `flyWithYouAct` text NOT NULL,
  `flyWithYouValue` text NOT NULL,
  `cost_yuanbao_after_combine` int(11) DEFAULT '0',
  PRIMARY KEY (`uuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_wonderful_activity` */

/*Table structure for table `t_wonderful_activity_config` */

DROP TABLE IF EXISTS `t_wonderful_activity_config`;

CREATE TABLE `t_wonderful_activity_config` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `actType` int(11) NOT NULL,
  `actId` int(11) NOT NULL,
  `startTime` bigint(20) DEFAULT NULL,
  `endTime` bigint(20) DEFAULT NULL,
  `actState` int(1) DEFAULT NULL,
  `actRewards` varchar(512) NOT NULL DEFAULT '[]',
  `actTimeId` int(11) DEFAULT NULL,
  `actStr` text NOT NULL,
  `actHot` int(11) NOT NULL DEFAULT '0',
  `actRank` int(11) NOT NULL,
  `actNotice` int(11) NOT NULL DEFAULT '0',
  `actValue` varchar(512) NOT NULL DEFAULT '{}',
  `rank_list_json` text,
  `attachment_notice` text,
  `join_cond` text,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=350 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_wonderful_activity_config` */

/*Table structure for table `t_wonderful_activity_time` */

DROP TABLE IF EXISTS `t_wonderful_activity_time`;

CREATE TABLE `t_wonderful_activity_time` (
  `id` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_wonderful_activity_time` */

/*Table structure for table `t_world_boss` */

DROP TABLE IF EXISTS `t_world_boss`;

CREATE TABLE `t_world_boss` (
  `id` bigint(20) NOT NULL,
  `bossLevel` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_world_boss` */

/*Table structure for table `t_yellow_number` */

DROP TABLE IF EXISTS `t_yellow_number`;

CREATE TABLE `t_yellow_number` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `roleId` bigint(20) NOT NULL,
  `yellowNumVersionId` int(11) NOT NULL,
  `yellowNumCout` int(11) NOT NULL,
  `grade1` smallint(6) NOT NULL,
  `grade2` smallint(6) NOT NULL,
  `grade3` smallint(6) NOT NULL,
  `grade4` smallint(6) NOT NULL,
  `grade5` smallint(6) NOT NULL,
  `grade6` smallint(6) NOT NULL,
  `grade7` smallint(6) NOT NULL,
  `grade8` smallint(6) NOT NULL,
  `grade9` smallint(6) NOT NULL,
  `grade10` smallint(6) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `NewIndex1` (`roleId`,`yellowNumVersionId`)
) ENGINE=MyISAM AUTO_INCREMENT=92 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_yellow_number` */

/*Table structure for table `t_yellow_number_gm` */

DROP TABLE IF EXISTS `t_yellow_number_gm`;

CREATE TABLE `t_yellow_number_gm` (
  `id` int(11) NOT NULL,
  `startTime` bigint(20) NOT NULL,
  `endTime` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_yellow_number_gm` */

/*Table structure for table `t_yellowvip_info` */

DROP TABLE IF EXISTS `t_yellowvip_info`;

CREATE TABLE `t_yellowvip_info` (
  `id` bigint(20) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '0',
  `yearVipLevel` int(11) NOT NULL DEFAULT '0',
  `highVip` int(11) NOT NULL DEFAULT '0',
  `recordTime` bigint(20) NOT NULL DEFAULT '0',
  `newType` int(11) NOT NULL DEFAULT '0',
  `newRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `firstType` int(11) NOT NULL DEFAULT '0',
  `firstRecordTime` bigint(20) NOT NULL DEFAULT '0',
  `everyDayJson` varchar(512) DEFAULT NULL,
  `everyRecordTime` bigint(20) DEFAULT '0',
  `charge_times` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `t_yellowvip_info` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
