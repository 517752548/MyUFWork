SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

CREATE DATABASE `api` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `api`;

DROP TABLE IF EXISTS `t_qqorder_basic_info`;
-- ----------------------------
-- Table structure for t_qqorder_basic_info
-- ----------------------------
CREATE TABLE `t_qqorder_basic_info` (
  `id` varchar(255) NOT NULL,
  `appid` varchar(255) DEFAULT NULL,
  `billToken` varchar(255) DEFAULT NULL,
  `charId` bigint(20) NOT NULL,
  `createDate` bigint(20) NOT NULL,
  `openid` varchar(255) DEFAULT NULL,
  `openkey` varchar(255) DEFAULT NULL,
  `pf` varchar(255) DEFAULT NULL,
  `pfkey` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `t_qqorder_info`;
-- ----------------------------
-- Table structure for t_qqorder_info
-- ----------------------------
CREATE TABLE `t_qqorder_info` (
  `id` varchar(255) NOT NULL,
  `appid` varchar(255) DEFAULT NULL,
  `charId` bigint(20) NOT NULL,
  `chargeDate` datetime DEFAULT '0000-00-00 00:00:00',
  `charged` int(11) NOT NULL DEFAULT '0',
  `createDate` bigint(20) NOT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `openid` varchar(255) DEFAULT NULL,
  `params` text,
  `platform` varchar(255) DEFAULT NULL,
  `serverName` varchar(255) DEFAULT NULL,
  KEY `appid_charId_charged` (`appid`,`charId`,`charged`),
  KEY `appid` (`appid`),
  KEY `charId` (`charId`),
  KEY `appid_charId` (`appid`,`charId`),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `t_qquser_info`;
-- ----------------------------
-- Table structure for t_qquser_info
-- ----------------------------
CREATE TABLE `t_qquser_info` (
  `id` varchar(255) NOT NULL,
  `appid` varchar(255) DEFAULT NULL,
  `createDate` bigint(20) NOT NULL DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `forbidTalkReason` varchar(255) DEFAULT NULL,
  `forbidTalkTime` bigint(20) NOT NULL,
  `forbidTalked` int(11) NOT NULL DEFAULT '0',
  `lastLoginDate` bigint(20) NOT NULL,
  `lockEndTime` bigint(20) NOT NULL DEFAULT '0',
  `lockReason` varchar(255) DEFAULT NULL,
  `locked` int(11) NOT NULL DEFAULT '0',
  `params` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `t_qqtaskmarket_info`;
-- ----------------------------
-- Table structure for t_qqtaskmarket_info
-- ----------------------------
CREATE TABLE `t_qqtaskmarket_info` (
  `id` varchar(255) NOT NULL,
  `appid` varchar(255) DEFAULT NULL,
  `contractid` varchar(255) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `openid` varchar(255) DEFAULT NULL,
  `step1Billno` varchar(255) DEFAULT NULL,
  `step1PayItem` varchar(255) DEFAULT NULL,
  `step1Status` int(11) NOT NULL DEFAULT '0',
  `step1UpdateTime` datetime DEFAULT NULL,
  `step2Billno` varchar(255) DEFAULT NULL,
  `step2PayItem` varchar(255) DEFAULT NULL,
  `step2Status` int(11) NOT NULL DEFAULT '0',
  `step2UpdateTime` datetime DEFAULT NULL,
  `step3Billno` varchar(255) DEFAULT NULL,
  `step3PayItem` varchar(255) DEFAULT NULL,
  `step3Status` int(11) NOT NULL DEFAULT '0',
  `step3UpdateTime` datetime DEFAULT NULL,
  `step4Billno` varchar(255) DEFAULT NULL,
  `step4PayItem` varchar(255) DEFAULT NULL,
  `step4Status` int(11) NOT NULL DEFAULT '0',
  `step4UpdateTime` datetime DEFAULT NULL,
  KEY `appid_openid` (`appid`,`openid`),
  KEY `appid_openid_createTime` (`appid`,`openid`,`createTime`),
  KEY `appid_openid_contractid` (`appid`,`openid`,`contractid`),
  KEY `appid` (`appid`),
  KEY `openid` (`openid`),
  KEY `contractid` (`contractid`),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;