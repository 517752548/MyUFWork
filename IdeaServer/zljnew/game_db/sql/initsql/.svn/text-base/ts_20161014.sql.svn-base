set names utf8;
use `ts002`;

-- ----------------------------
-- Table structure for `t_activity_allocate`
-- ----------------------------
DROP TABLE IF EXISTS `t_activity_allocate`;
CREATE TABLE `t_activity_allocate` (
  `id` bigint(20) NOT NULL,
  `activityType` int(11) NOT NULL DEFAULT '0',
  `allocateInfo` longtext,
  `corpsId` bigint(20) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_activity_allocate
-- ----------------------------

-- ----------------------------
-- Table structure for `t_arena_snap`
-- ----------------------------
DROP TABLE IF EXISTS `t_arena_snap`;
CREATE TABLE `t_arena_snap` (
  `id` bigint(20) NOT NULL,
  `attackCdTime` bigint(20) NOT NULL DEFAULT '0',
  `attackTotalTimes` int(11) NOT NULL DEFAULT '0',
  `conWinTimes` int(11) NOT NULL DEFAULT '0',
  `fightLog` text,
  `lossTimes` int(11) NOT NULL DEFAULT '0',
  `opList` text,
  `rank` int(11) NOT NULL DEFAULT '0',
  `rankMax` int(11) NOT NULL DEFAULT '0',
  `snapLevel` int(11) NOT NULL DEFAULT '0',
  `snapRank` int(11) NOT NULL DEFAULT '0',
  `winTimes` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_arena_snap
-- ----------------------------

-- ----------------------------
-- Table structure for `t_cdkey`
-- ----------------------------
DROP TABLE IF EXISTS `t_cdkey`;
CREATE TABLE `t_cdkey` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `charName` varchar(255) DEFAULT '',
  `chartServerId` varchar(255) DEFAULT '',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `giftId` int(11) NOT NULL DEFAULT '0',
  `gmId` varchar(255) DEFAULT '',
  `groupId` int(11) NOT NULL DEFAULT '0',
  `isDel` int(11) NOT NULL DEFAULT '0',
  `openId` varchar(255) DEFAULT '',
  `plansId` int(11) NOT NULL DEFAULT '0',
  `state` int(11) NOT NULL DEFAULT '0',
  `takeTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_cdkey
-- ----------------------------

-- ----------------------------
-- Table structure for `t_cdkey_plans`
-- ----------------------------
DROP TABLE IF EXISTS `t_cdkey_plans`;
CREATE TABLE `t_cdkey_plans` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cdkeyPlansId` int(11) NOT NULL DEFAULT '0',
  `cdkeyPlansName` varchar(255) NOT NULL DEFAULT '',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `endTime` bigint(20) NOT NULL DEFAULT '0',
  `gmId` int(11) NOT NULL DEFAULT '0',
  `isDel` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_cdkey_plans
-- ----------------------------

-- ----------------------------
-- Table structure for `t_character_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_character_info`;
CREATE TABLE `t_character_info` (
  `id` bigint(20) NOT NULL,
  `autoFightAction` int(11) NOT NULL DEFAULT '0',
  `backMapId` int(11) NOT NULL DEFAULT '0',
  `backX` int(11) NOT NULL DEFAULT '0',
  `backY` int(11) NOT NULL DEFAULT '0',
  `bond` bigint(20) NOT NULL DEFAULT '0',
  `buyMonthCardTime` bigint(20) NOT NULL DEFAULT '0',
  `canRename` int(11) NOT NULL DEFAULT '0',
  `cdQueuePack` longtext,
  `country` int(11) NOT NULL DEFAULT '0',
  `createTime` datetime DEFAULT NULL,
  `deleteTime` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `energy` int(11) NOT NULL DEFAULT '0',
  `eternalCostMoney` bigint(20) NOT NULL DEFAULT '0',
  `exp` bigint(20) NOT NULL DEFAULT '0',
  `giftBond` bigint(20) NOT NULL DEFAULT '0',
  `gold` bigint(20) NOT NULL DEFAULT '0',
  `gold2` bigint(20) NOT NULL DEFAULT '0',
  `guaJiPoint` bigint(20) NOT NULL DEFAULT '0',
  `guaJiPoint2` bigint(20) NOT NULL DEFAULT '0',
  `hadOpenPrimBagNum` int(11) NOT NULL DEFAULT '0',
  `honor` int(11) NOT NULL DEFAULT '0',
  `idleTime` int(11) NOT NULL DEFAULT '0',
  `invalidBattleNum` int(11) NOT NULL DEFAULT '0',
  `lastBattleEndTime` bigint(20) NOT NULL DEFAULT '0',
  `lastBattleId` int(11) NOT NULL DEFAULT '0',
  `lastBattleTime` bigint(20) NOT NULL DEFAULT '0',
  `lastChargeTime` datetime DEFAULT NULL,
  `lastCitySceneId` int(11) NOT NULL DEFAULT '0',
  `lastGiveDoublePointTime` bigint(20) NOT NULL DEFAULT '0',
  `lastGivePowerTime` bigint(20) NOT NULL DEFAULT '0',
  `lastGiveSkillPointTime` bigint(20) NOT NULL DEFAULT '0',
  `lastLoginIp` varchar(255) DEFAULT NULL,
  `lastLoginTime` datetime DEFAULT NULL,
  `lastLogoutTime` datetime DEFAULT NULL,
  `lastVipTime` datetime DEFAULT NULL,
  `level` int(11) NOT NULL DEFAULT '0',
  `levelUpTimeStamp` bigint(20) NOT NULL DEFAULT '0',
  `mainSkillPack` text,
  `mapId` int(11) NOT NULL DEFAULT '0',
  `mineLevel` int(11) NOT NULL DEFAULT '1',
  `missionPack` text,
  `monthCharge` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) DEFAULT NULL,
  `onlineStatus` int(11) NOT NULL DEFAULT '0',
  `passportId` varchar(255) DEFAULT NULL,
  `petAutoFightAction` int(11) NOT NULL DEFAULT '0',
  `photo` int(11) NOT NULL DEFAULT '0',
  `power` int(11) NOT NULL DEFAULT '0',
  `props` longtext,
  `pubExp` bigint(20) NOT NULL DEFAULT '0',
  `pubLevel` int(11) NOT NULL DEFAULT '0',
  `redEnvelope` int(11) NOT NULL DEFAULT '0',
  `sceneId` int(11) NOT NULL DEFAULT '0',
  `serverId` int(11) NOT NULL DEFAULT '0',
  `skillPoint` int(11) NOT NULL DEFAULT '0',
  `sysBond` bigint(20) NOT NULL DEFAULT '0',
  `todayCharge` int(11) NOT NULL DEFAULT '0',
  `tokenParam1` bigint(20) NOT NULL DEFAULT '0',
  `tokenParam2` varchar(64) DEFAULT '',
  `totalCharge` int(11) NOT NULL DEFAULT '0',
  `totalMinute` int(11) NOT NULL DEFAULT '0',
  `weekCharge` int(11) NOT NULL DEFAULT '0',
  `x` int(11) NOT NULL DEFAULT '0',
  `y` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_character_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_corps`
-- ----------------------------
DROP TABLE IF EXISTS `t_corps`;
CREATE TABLE `t_corps` (
  `id` bigint(20) NOT NULL,
  `buildInfo` longtext,
  `canRename` int(11) NOT NULL DEFAULT '0',
  `createDate` bigint(20) DEFAULT NULL,
  `creater` bigint(20) DEFAULT NULL,
  `currExp` bigint(20) NOT NULL DEFAULT '0',
  `currFund` bigint(20) NOT NULL DEFAULT '0',
  `currMemNum` int(11) NOT NULL DEFAULT '0',
  `delinquentNum` int(11) NOT NULL DEFAULT '0',
  `disbandConfrimDate` bigint(20) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) DEFAULT NULL,
  `notice` varchar(255) DEFAULT NULL,
  `president` bigint(20) DEFAULT NULL,
  `presidentName` varchar(255) DEFAULT NULL,
  `storagePack` varchar(255) DEFAULT NULL,
  `weekBossCount` int(11) NOT NULL DEFAULT '0',
  `weekBossLevel` int(11) NOT NULL DEFAULT '0',
  `weekBossLevelReplay` varchar(255) DEFAULT NULL,
  `weekBossRound` int(11) NOT NULL DEFAULT '0',
  `weekBossUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_corps
-- ----------------------------

-- ----------------------------
-- Table structure for `t_corpsboss_count_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_corpsboss_count_rank`;
CREATE TABLE `t_corpsboss_count_rank` (
  `id` bigint(20) NOT NULL,
  `bossKillCount` int(11) NOT NULL DEFAULT '0',
  `corpsId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_corpsboss_count_rank
-- ----------------------------

-- ----------------------------
-- Table structure for `t_corpsboss_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_corpsboss_rank`;
CREATE TABLE `t_corpsboss_rank` (
  `id` bigint(20) NOT NULL,
  `bossBestKiller` varchar(255) DEFAULT NULL,
  `bossBestLevel` int(11) NOT NULL DEFAULT '0',
  `bossKillLevelSum` int(11) NOT NULL DEFAULT '0',
  `bossKillMemberNum` int(11) NOT NULL DEFAULT '0',
  `bossKillPowerSum` int(11) NOT NULL DEFAULT '0',
  `bossKillRound` int(11) NOT NULL DEFAULT '0',
  `corpsId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_corpsboss_rank
-- ----------------------------

-- ----------------------------
-- Table structure for `t_corpswar_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_corpswar_rank`;
CREATE TABLE `t_corpswar_rank` (
  `id` bigint(20) NOT NULL,
  `corpsId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0',
  `score` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_corpswar_rank
-- ----------------------------

-- ----------------------------
-- Table structure for `t_corps_member`
-- ----------------------------
DROP TABLE IF EXISTS `t_corps_member`;
CREATE TABLE `t_corps_member` (
  `id` bigint(20) NOT NULL,
  `benifitDate` bigint(20) NOT NULL DEFAULT '0',
  `contributeDate` bigint(20) DEFAULT NULL,
  `corpsId` bigint(20) DEFAULT NULL,
  `corpsMemState` int(11) NOT NULL DEFAULT '0',
  `donateDate` bigint(20) DEFAULT NULL,
  `joinDate` bigint(20) DEFAULT NULL,
  `lastWeekContribution` int(11) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `logoutTime` bigint(20) DEFAULT NULL,
  `memJob` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) DEFAULT NULL,
  `petJob` int(11) NOT NULL DEFAULT '0',
  `roleId` bigint(20) DEFAULT NULL,
  `sex` int(11) NOT NULL DEFAULT '0',
  `toCorpsExp` bigint(20) DEFAULT NULL,
  `todayDonate` bigint(20) DEFAULT NULL,
  `totalContribution` int(11) DEFAULT NULL,
  `totalDonate` bigint(20) DEFAULT NULL,
  `weekyContribution` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_corps_member
-- ----------------------------

-- ----------------------------
-- Table structure for `t_db_version`
-- ----------------------------
DROP TABLE IF EXISTS `t_db_version`;
CREATE TABLE `t_db_version` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mergeTime` datetime DEFAULT NULL,
  `openTime` datetime NOT NULL,
  `updateTime` datetime NOT NULL,
  `version` varchar(255) NOT NULL,
  `serverIds` text,
  `serverNames` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `t_dirtywords`
-- ----------------------------
DROP TABLE IF EXISTS `t_dirtywords`;
CREATE TABLE `t_dirtywords` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dirtyWordsType` int(11) NOT NULL DEFAULT '0',
  `updateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `t_good_activity`
-- ----------------------------
DROP TABLE IF EXISTS `t_good_activity`;
CREATE TABLE `t_good_activity` (
  `id` bigint(20) NOT NULL,
  `activityDesc` text,
  `activityName` text,
  `activityTplId` int(11) NOT NULL DEFAULT '0',
  `activityType` int(11) NOT NULL DEFAULT '0',
  `closeTime` bigint(20) NOT NULL DEFAULT '0',
  `endTime` bigint(20) NOT NULL DEFAULT '0',
  `isAvailable` int(11) NOT NULL DEFAULT '0',
  `isClosed` int(11) NOT NULL DEFAULT '0',
  `isForceEnd` int(11) NOT NULL DEFAULT '0',
  `isStarted` int(11) NOT NULL DEFAULT '0',
  `lastRefreshTime` bigint(20) NOT NULL DEFAULT '0',
  `logStr` text,
  `nameIcon` int(11) NOT NULL DEFAULT '0',
  `serverIds` varchar(255) DEFAULT NULL,
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `titleIcon` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_good_activity
-- ----------------------------

-- ----------------------------
-- Table structure for `t_good_activity_user`
-- ----------------------------
DROP TABLE IF EXISTS `t_good_activity_user`;
CREATE TABLE `t_good_activity_user` (
  `id` bigint(20) NOT NULL,
  `activityData` longtext,
  `activityId` bigint(20) DEFAULT '0',
  `charId` bigint(20) DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_good_activity_user
-- ----------------------------

-- ----------------------------
-- Table structure for `t_item_cost`
-- ----------------------------
DROP TABLE IF EXISTS `t_item_cost`;
CREATE TABLE `t_item_cost` (
  `id` bigint(20) NOT NULL,
  `actualCost` bigint(20) NOT NULL DEFAULT '0',
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `freeNum` int(11) NOT NULL DEFAULT '0',
  `itemNum` int(11) NOT NULL DEFAULT '0',
  `templateId` int(11) NOT NULL DEFAULT '0',
  `totalCost` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_item_cost
-- ----------------------------

-- ----------------------------
-- Table structure for `t_item_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_item_info`;
CREATE TABLE `t_item_info` (
  `id` varchar(36) NOT NULL,
  `bagId` int(11) DEFAULT NULL,
  `bagIndex` int(11) DEFAULT NULL,
  `bindFlag` int(11) NOT NULL DEFAULT '0',
  `charId` bigint(20) DEFAULT NULL,
  `createTime` datetime DEFAULT NULL,
  `deadline` datetime DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `intoTempBagTime` datetime DEFAULT NULL,
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `overlap` int(11) DEFAULT NULL,
  `properties` text,
  `templateId` int(11) DEFAULT NULL,
  `wearerId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_item_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_mail_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_mail_info`;
CREATE TABLE `t_mail_info` (
  `id` varchar(36) NOT NULL,
  `attachmentProps` longtext,
  `charId` bigint(20) DEFAULT '0',
  `content` text,
  `createTime` datetime DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `mailStatus` int(11) DEFAULT '0',
  `mailType` int(11) DEFAULT '0',
  `recId` bigint(20) DEFAULT '0',
  `recName` varchar(255) DEFAULT NULL,
  `sendId` bigint(20) DEFAULT '0',
  `sendName` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `updateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_mail_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_mall_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_mall_info`;
CREATE TABLE `t_mall_info` (
  `id` bigint(20) NOT NULL,
  `currQueueConfig` text,
  `currQueueId` int(11) DEFAULT NULL,
  `currQueueUUID` varchar(36) DEFAULT NULL,
  `currStartTime` bigint(20) DEFAULT NULL,
  `queueConfig` text,
  `startConfigTime` bigint(20) DEFAULT NULL,
  `stockPack` text,
  `updateTime` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_mall_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_marry_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_marry_info`;
CREATE TABLE `t_marry_info` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) DEFAULT NULL,
  `maritalStatus` int(11) NOT NULL,
  `marryProps` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_marry_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_module_data`
-- ----------------------------
DROP TABLE IF EXISTS `t_module_data`;
CREATE TABLE `t_module_data` (
  `id` int(11) NOT NULL,
  `json` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_module_data
-- ----------------------------

-- ----------------------------
-- Table structure for `t_nvn_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_nvn_rank`;
CREATE TABLE `t_nvn_rank` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `conWin` int(11) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `loss` int(11) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0',
  `score` int(11) NOT NULL DEFAULT '0',
  `win` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_nvn_rank
-- ----------------------------

-- ----------------------------
-- Table structure for `t_offline_reward`
-- ----------------------------
DROP TABLE IF EXISTS `t_offline_reward`;
CREATE TABLE `t_offline_reward` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `props` text,
  `rewardType` int(11) NOT NULL DEFAULT '0',
  `rewards` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_offline_reward
-- ----------------------------

-- ----------------------------
-- Table structure for `t_overman_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_overman_info`;
CREATE TABLE `t_overman_info` (
  `id` bigint(20) NOT NULL,
  `overmanProps` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_overman_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_pet_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_pet_info`;
CREATE TABLE `t_pet_info` (
  `id` bigint(20) NOT NULL,
  `aPropAddPoint` varchar(1024) NOT NULL DEFAULT '',
  `bindFlag` int(11) NOT NULL DEFAULT '0',
  `charId` bigint(20) DEFAULT NULL,
  `colorId` int(11) NOT NULL DEFAULT '1',
  `createDate` datetime DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `equipStars` varchar(512) NOT NULL DEFAULT '',
  `exp` bigint(20) DEFAULT NULL,
  `geneType` int(11) NOT NULL DEFAULT '0',
  `growthColor` int(11) NOT NULL DEFAULT '0',
  `isFight` int(11) NOT NULL DEFAULT '0',
  `itemAddProp` varchar(128) NOT NULL DEFAULT '',
  `lastFireDate` datetime DEFAULT NULL,
  `lastHireDate` datetime DEFAULT NULL,
  `leftPoint` int(11) NOT NULL DEFAULT '0',
  `level` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `perceptExp` bigint(20) NOT NULL DEFAULT '0',
  `perceptLevel` int(11) NOT NULL DEFAULT '0',
  `petAffinationNum` int(11) NOT NULL DEFAULT '0',
  `petScore` int(11) NOT NULL DEFAULT '0',
  `petSenseRate` int(11) NOT NULL DEFAULT '0',
  `petSkillBarNum` int(11) NOT NULL DEFAULT '0',
  `petState` int(11) NOT NULL DEFAULT '0',
  `petType` int(11) DEFAULT NULL,
  `skillProp` varchar(2048) NOT NULL DEFAULT '',
  `skillShortcutProp` varchar(2048) NOT NULL DEFAULT '',
  `starId` int(11) NOT NULL DEFAULT '1',
  `templateId` int(11) DEFAULT NULL,
  `trainAddProp` varchar(128) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_pet_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_prize`
-- ----------------------------
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_prize
-- ----------------------------

-- ----------------------------
-- Table structure for `t_red_envelope`
-- ----------------------------
DROP TABLE IF EXISTS `t_red_envelope`;
CREATE TABLE `t_red_envelope` (
  `id` varchar(36) NOT NULL,
  `bonusAmount` int(11) NOT NULL DEFAULT '0',
  `content` longtext,
  `corpsId` bigint(20) DEFAULT '0',
  `createTime` bigint(20) DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `openRedEnveloperInfo` longtext,
  `randomRedEnveloperUnit` longtext,
  `redEnvelopeStatus` int(2) NOT NULL DEFAULT '0',
  `redEnvelopeType` int(2) NOT NULL DEFAULT '0',
  `remainingBonus` int(11) NOT NULL DEFAULT '0',
  `remainingNum` int(11) NOT NULL DEFAULT '0',
  `sendId` bigint(20) DEFAULT '0',
  `sendName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_red_envelope
-- ----------------------------

-- ----------------------------
-- Table structure for `t_relation_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_relation_info`;
CREATE TABLE `t_relation_info` (
  `id` varchar(255) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `relationType` int(11) NOT NULL DEFAULT '0',
  `targetCharId` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_relation_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_scene_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_scene_info`;
CREATE TABLE `t_scene_info` (
  `id` bigint(20) NOT NULL DEFAULT '0',
  `properties` text NOT NULL,
  `templateId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`) USING BTREE,
  KEY `templateId` (`templateId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `t_sys_mail`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_mail`;
CREATE TABLE `t_sys_mail` (
  `id` bigint(20) NOT NULL,
  `attachmentProps` text,
  `content` text,
  `createTime` bigint(20) DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `expiredTime` bigint(20) DEFAULT '0',
  `sendUsers` longtext,
  `title` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_sys_mail
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_common`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_common`;
CREATE TABLE `t_task_common` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questTypeId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_common
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_corps`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_corps`;
CREATE TABLE `t_task_corps` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_corps
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_dayseven`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_dayseven`;
CREATE TABLE `t_task_dayseven` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_dayseven
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_forage`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_forage`;
CREATE TABLE `t_task_forage` (
  `id` varchar(36) NOT NULL,
  `battleFailCount` int(11) NOT NULL DEFAULT '0',
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questStar` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_forage
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_pub`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_pub`;
CREATE TABLE `t_task_pub` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questStar` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_pub
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_ring`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_ring`;
CREATE TABLE `t_task_ring` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_ring
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_siegedemon`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_siegedemon`;
CREATE TABLE `t_task_siegedemon` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questTypeId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_siegedemon
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_thesweeney`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_thesweeney`;
CREATE TABLE `t_task_thesweeney` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questTypeId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_thesweeney
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task_treasure`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_treasure`;
CREATE TABLE `t_task_treasure` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `questTypeId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task_treasure
-- ----------------------------

-- ----------------------------
-- Table structure for `t_timelimit_monster`
-- ----------------------------
DROP TABLE IF EXISTS `t_timelimit_monster`;
CREATE TABLE `t_timelimit_monster` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_timelimit_monster
-- ----------------------------

-- ----------------------------
-- Table structure for `t_timelimit_npc`
-- ----------------------------
DROP TABLE IF EXISTS `t_timelimit_npc`;
CREATE TABLE `t_timelimit_npc` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `props` varchar(512) NOT NULL DEFAULT '',
  `questId` int(11) NOT NULL DEFAULT '0',
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_timelimit_npc
-- ----------------------------

-- ----------------------------
-- Table structure for `t_title_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_title_info`;
CREATE TABLE `t_title_info` (
  `id` bigint(20) NOT NULL,
  `disTitle` int(11) NOT NULL,
  `inUseTplid` int(11) NOT NULL,
  `titleInfoProps` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_title_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_tower_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_tower_info`;
CREATE TABLE `t_tower_info` (
  `id` varchar(36) NOT NULL,
  `bCharId` bigint(20) NOT NULL DEFAULT '0',
  `bLevel` int(11) NOT NULL DEFAULT '0',
  `bRound` int(11) NOT NULL DEFAULT '0',
  `battleDuration` bigint(20) NOT NULL DEFAULT '0',
  `battleEndTime` bigint(20) NOT NULL DEFAULT '0',
  `bestKiller` varchar(255) DEFAULT NULL,
  `fCharId` bigint(20) NOT NULL DEFAULT '0',
  `fLevel` int(11) NOT NULL DEFAULT '0',
  `fRound` int(11) NOT NULL DEFAULT '0',
  `firstKiller` varchar(255) DEFAULT NULL,
  `towerLevel` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_tower_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_trade_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_trade_info`;
CREATE TABLE `t_trade_info` (
  `id` bigint(20) NOT NULL,
  `boothIndex` int(11) DEFAULT NULL,
  `buyerCharId` bigint(20) DEFAULT NULL,
  `commodityInfo` varchar(4096) DEFAULT '',
  `commodityNum` int(11) DEFAULT NULL,
  `currencyNum` int(11) DEFAULT NULL,
  `currencyType` int(11) DEFAULT NULL,
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) DEFAULT NULL,
  `lastUpdateTime` datetime DEFAULT NULL,
  `overDueTime` datetime DEFAULT NULL,
  `sellerCharId` bigint(20) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `tradeStatus` int(11) DEFAULT NULL,
  `type` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_trade_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_user_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_info`;
CREATE TABLE `t_user_info` (
  `id` varchar(255) NOT NULL,
  `activity` int(11) NOT NULL DEFAULT '0',
  `answer` varchar(50) DEFAULT NULL,
  `cookieValue` varchar(255) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `failedLogins` int(11) NOT NULL DEFAULT '0',
  `foribedTalkTime` bigint(20) NOT NULL DEFAULT '0',
  `joinTime` datetime DEFAULT NULL,
  `lastLoginIp` varchar(50) DEFAULT NULL,
  `lastLoginTime` datetime DEFAULT NULL,
  `lastLogoutTime` datetime DEFAULT NULL,
  `locale` varchar(50) DEFAULT NULL,
  `lockStatus` int(11) NOT NULL DEFAULT '0',
  `muteTime` int(11) NOT NULL DEFAULT '0',
  `name` varchar(255) NOT NULL,
  `password` varchar(50) DEFAULT NULL,
  `props` varchar(256) DEFAULT NULL,
  `qqData` text,
  `question` varchar(50) DEFAULT NULL,
  `role` int(11) NOT NULL DEFAULT '0',
  `source` varchar(255) DEFAULT NULL,
  `todayOnlineTime` int(11) NOT NULL DEFAULT '0',
  `todayOnlineUpdateTime` datetime DEFAULT NULL,
  `version` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_user_offline`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_offline`;
CREATE TABLE `t_user_offline` (
  `id` bigint(20) NOT NULL,
  `corpsBossPack` text,
  `curArrayIndex` int(11) NOT NULL DEFAULT '0',
  `curCorpsBossLevel` int(11) NOT NULL DEFAULT '0',
  `fightPetHorseId` bigint(20) NOT NULL DEFAULT '0',
  `fightPetId` bigint(20) NOT NULL DEFAULT '0',
  `friendArray` varchar(1024) NOT NULL DEFAULT '',
  `hpPool` bigint(20) NOT NULL DEFAULT '0',
  `lifePool` bigint(20) NOT NULL DEFAULT '0',
  `mpPool` bigint(20) NOT NULL DEFAULT '0',
  `passportId` varchar(255) DEFAULT NULL,
  `petHorsePack` text,
  `petPack` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_offline
-- ----------------------------

-- ----------------------------
-- Table structure for `t_user_prize`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_prize`;
CREATE TABLE `t_user_prize` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `coin` text,
  `createTime` datetime DEFAULT NULL,
  `expireTime` datetime DEFAULT NULL,
  `item` text,
  `itemParams` text,
  `params` text,
  `passportId` text NOT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  `type` int(11) NOT NULL DEFAULT '0',
  `updateTime` datetime DEFAULT NULL,
  `userPrizeName` varchar(32) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_prize
-- ----------------------------

-- ----------------------------
-- Table structure for `t_user_snap`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_snap`;
CREATE TABLE `t_user_snap` (
  `id` bigint(20) NOT NULL,
  `armies` text,
  `autoActionId` int(11) NOT NULL DEFAULT '0',
  `autoSkillLayer` int(11) NOT NULL DEFAULT '0',
  `autoSkillLevel` int(11) NOT NULL DEFAULT '0',
  `equipPack` text,
  `fightPower` int(11) NOT NULL DEFAULT '0',
  `formation` text,
  `funcPack` text,
  `level` int(11) NOT NULL DEFAULT '0',
  `mainSkillPack` text,
  `name` varchar(255) DEFAULT NULL,
  `passportId` varchar(255) DEFAULT NULL,
  `petAutoActionId` int(11) NOT NULL DEFAULT '0',
  `petAutoSkillLevel` int(11) NOT NULL DEFAULT '0',
  `propsPack` text,
  `serverId` int(11) NOT NULL DEFAULT '0',
  `towerLevel` int(11) NOT NULL DEFAULT '0',
  `wingId` int(11) NOT NULL DEFAULT '0',
  `wingLevel` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user_snap
-- ----------------------------

-- ----------------------------
-- Table structure for `t_vip`
-- ----------------------------
DROP TABLE IF EXISTS `t_vip`;
CREATE TABLE `t_vip` (
  `id` bigint(20) NOT NULL,
  `exp` bigint(20) NOT NULL DEFAULT '0',
  `expireTime` bigint(20) NOT NULL DEFAULT '0',
  `lastUpdateTime` bigint(20) NOT NULL DEFAULT '0',
  `level` int(11) NOT NULL DEFAULT '0',
  `roleId` bigint(20) NOT NULL,
  `tmpLevel` int(11) NOT NULL DEFAULT '0',
  `vType` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_vip
-- ----------------------------

-- ----------------------------
-- Table structure for `t_wing_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_wing_info`;
CREATE TABLE `t_wing_info` (
  `id` varchar(36) NOT NULL,
  `charId` bigint(20) NOT NULL,
  `createDate` datetime DEFAULT NULL,
  `equipped` int(1) NOT NULL DEFAULT '0',
  `templateId` int(11) NOT NULL DEFAULT '0',
  `wingBless` int(5) NOT NULL DEFAULT '0',
  `wingLevel` int(2) NOT NULL DEFAULT '0',
  `wingPower` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_wing_info
-- ----------------------------

-- ----------------------------
-- Table structure for `t_world_gift`
-- ----------------------------
DROP TABLE IF EXISTS `t_world_gift`;
CREATE TABLE `t_world_gift` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `giftId` int(11) NOT NULL DEFAULT '0',
  `giftName` varchar(255) NOT NULL DEFAULT '',
  `giftParams` varchar(255) NOT NULL DEFAULT '',
  `isDel` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_world_gift
-- ----------------------------

-- ----------------------------
-- Table structure for `t_xianhu`
-- ----------------------------
DROP TABLE IF EXISTS `t_xianhu`;
CREATE TABLE `t_xianhu` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lingxiDayCount` int(11) NOT NULL DEFAULT '0',
  `lingxiDayLastTime` bigint(20) NOT NULL DEFAULT '0',
  `lingxiWeekCount` int(11) NOT NULL DEFAULT '0',
  `lingxiWeekLastTime` bigint(20) NOT NULL DEFAULT '0',
  `normalCount` int(11) NOT NULL DEFAULT '0',
  `normalLastTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_xianhu
-- ----------------------------

-- ----------------------------
-- Table structure for `t_xianhu_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_xianhu_rank`;
CREATE TABLE `t_xianhu_rank` (
  `id` bigint(20) NOT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `lastTime` bigint(20) NOT NULL DEFAULT '0',
  `rank` int(11) NOT NULL DEFAULT '0',
  `rankType` int(11) NOT NULL DEFAULT '0',
  `rewardFlag` int(11) NOT NULL DEFAULT '0',
  `rewardTime` bigint(20) NOT NULL DEFAULT '0',
  `targetCount` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_xianhu_rank
-- ----------------------------

-- ----------------------------
-- Records of t_db_version
-- ----------------------------
INSERT INTO `t_db_version` VALUES ('1', '2016-10-14 16:56:33', '2016-10-14 14:00:00', '2016-10-14 19:39:36', '1.0.0.1', '[1002]', '[\"ts002\"]');

use `ts002_log`;
-- ----------------------------
-- Table structure for `reason_list`
-- ----------------------------
DROP TABLE IF EXISTS `reason_list`;
CREATE TABLE `reason_list` (
  `log_uid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `log_type` int(10) unsigned NOT NULL,
  `log_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `log_table` varchar(255) NOT NULL,
  `log_desc` varchar(255) NOT NULL,
  `log_field` varchar(255) NOT NULL,
  `reason` int(10) NOT NULL,
  `reason_name` varchar(255) NOT NULL,
  PRIMARY KEY (`log_uid`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;
