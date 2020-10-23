USE `tr_${server_id}`;
update t_db_version set version='1.0.0.26',updateTime=now();
delete from t_item_info where deleted=1;

-- ----------------------------
-- Table structure for t_qq_invite_world
-- ----------------------------
DROP TABLE IF EXISTS `t_qq_invite_world`;
CREATE TABLE `t_qq_invite_world` (
  `id` bigint(20) NOT NULL,
  `fromCharId` bigint(20) NOT NULL DEFAULT '0',
  `fromCharName` varchar(256) DEFAULT NULL,
  `fromOpenId` varchar(256) DEFAULT NULL,
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `openId` varchar(256) DEFAULT NULL,
  `gbrCharId` bigint(20) DEFAULT '0',
  `gbrTime` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_qq_charge_return_world
-- ----------------------------
DROP TABLE IF EXISTS `t_qq_charge_return_world`;
CREATE TABLE `t_qq_charge_return_world` (
  `id` bigint(20) NOT NULL,
  `charName` varchar(256) DEFAULT NULL,
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `fromCharId` bigint(20) NOT NULL DEFAULT '0',
  `fromOpenId` varchar(256) DEFAULT NULL,
  `lastServerId` int(11) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `openId` varchar(256) DEFAULT NULL,
  `returnFlag` int(11) NOT NULL DEFAULT '0',
  `returnTplId` int(11) NOT NULL DEFAULT '0',
  `roleId` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_loop_task
-- ----------------------------
DROP TABLE IF EXISTS `t_loop_task`;
CREATE TABLE `t_loop_task` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL default '0',
  `lastUpdateTime` bigint(20) NOT NULL default '0',
  `loopTaskType` int(11) NOT NULL default '0',
  `props` varchar(512) NOT NULL default '',
  `questId` int(11) NOT NULL default '0',
  `startTime` bigint(20) NOT NULL default '0',
  `status` int(11) NOT NULL default '0',
  PRIMARY KEY  (`charId`),
  KEY `charId` (`charId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
