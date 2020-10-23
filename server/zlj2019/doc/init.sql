use `ts001`;

-- ----------------------------
-- Table structure for `t_arena_snap`
-- ----------------------------
DROP TABLE IF EXISTS `t_arena_snap`;
CREATE TABLE `t_arena_snap` (
`id`  bigint(20) NOT NULL ,
`attackTotalTimes`  int(11) NOT NULL DEFAULT 0 ,
`conWinTimes`  int(11) NOT NULL DEFAULT 0 ,
`fightLog`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`lastGetAwardTime`  bigint(20) NOT NULL DEFAULT 0 ,
`lastReward`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`lastRewardTime`  bigint(20) NOT NULL DEFAULT 0 ,
`lossTimes`  int(11) NOT NULL DEFAULT 0 ,
`rank`  int(11) NOT NULL DEFAULT 0 ,
`rankMax`  int(11) NOT NULL DEFAULT 0 ,
`snapLevel`  int(11) NOT NULL DEFAULT 0 ,
`snapRank`  int(11) NOT NULL DEFAULT 0 ,
`winTimes`  int(11) NOT NULL DEFAULT 0 ,
`attackCdTime`  bigint(20) NULL DEFAULT 0 ,
`opList`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_cdkey`
-- ----------------------------
DROP TABLE IF EXISTS `t_cdkey`;
CREATE TABLE `t_cdkey` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`charName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`chartServerId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`giftId`  int(11) NOT NULL DEFAULT 0 ,
`gmId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`groupId`  int(11) NOT NULL DEFAULT 0 ,
`isDel`  int(11) NOT NULL DEFAULT 0 ,
`openId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`plansId`  int(11) NOT NULL DEFAULT 0 ,
`state`  int(11) NOT NULL DEFAULT 0 ,
`takeTime`  bigint(20) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_cdkey_plans`
-- ----------------------------
DROP TABLE IF EXISTS `t_cdkey_plans`;
CREATE TABLE `t_cdkey_plans` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`cdkeyPlansId`  int(11) NOT NULL DEFAULT 0 ,
`cdkeyPlansName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`endTime`  bigint(20) NOT NULL DEFAULT 0 ,
`gmId`  int(11) NOT NULL DEFAULT 0 ,
`isDel`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Table structure for `t_character_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_character_info`;
CREATE TABLE `t_character_info` (
`id`  bigint(20) NOT NULL ,
`bond`  bigint(20) NOT NULL DEFAULT 0 ,
`canRename`  int(11) NOT NULL DEFAULT 0 ,
`cdQueuePack`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`country`  int(11) NOT NULL DEFAULT 0 ,
`createTime`  datetime NULL DEFAULT NULL ,
`deleteTime`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NOT NULL DEFAULT 0 ,
`eternalCostMoney`  bigint(20) NOT NULL DEFAULT 0 ,
`giftBond`  bigint(20) NOT NULL DEFAULT 0 ,
`gold`  bigint(20) NOT NULL DEFAULT 0 ,
`hadOpenPrimBagNum`  int(11) NOT NULL DEFAULT 0 ,
`honor`  int(11) NOT NULL DEFAULT 0 ,
`idleTime`  int(11) NOT NULL DEFAULT 0 ,
`lastChargeTime`  datetime NULL DEFAULT NULL ,
`lastCitySceneId`  int(11) NOT NULL DEFAULT 0 ,
`lastGivePowerTime`  bigint(20) NOT NULL DEFAULT 0 ,
`lastLoginIp`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`lastLoginTime`  datetime NULL DEFAULT NULL ,
`lastLogoutTime`  datetime NULL DEFAULT NULL ,
`lastVipTime`  datetime NULL DEFAULT NULL ,
`level`  int(11) NOT NULL DEFAULT 0 ,
`missionPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`monthCharge`  int(11) NOT NULL DEFAULT 0 ,
`name`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`onlineStatus`  int(11) NOT NULL DEFAULT 0 ,
`passportId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`photo`  int(11) NOT NULL DEFAULT 0 ,
`power`  int(11) NOT NULL DEFAULT 0 ,
`props`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`sceneId`  int(11) NOT NULL DEFAULT 0 ,
`serverId`  int(11) NOT NULL DEFAULT 0 ,
`sysBond`  bigint(20) NOT NULL DEFAULT 0 ,
`todayCharge`  int(11) NOT NULL DEFAULT 0 ,
`tokenParam1`  bigint(20) NOT NULL DEFAULT 0 ,
`tokenParam2`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`totalCharge`  int(11) NOT NULL DEFAULT 0 ,
`totalMinute`  int(11) NOT NULL DEFAULT 0 ,
`weekCharge`  int(11) NOT NULL DEFAULT 0 ,
`exp`  bigint(20) NULL DEFAULT 0 ,
`lastGiveSkillPointTime`  bigint(20) NULL DEFAULT 0 ,
`skillPoint`  int(11) NULL DEFAULT 0 ,
`mapId`  int(11) NULL DEFAULT 0 ,
`x`  int(11) NULL DEFAULT 0 ,
`y`  int(11) NULL DEFAULT 0 ,
`lastBattleId`  int(11) NULL DEFAULT 0 ,
`lastBattleTime`  bigint(20) NULL DEFAULT 0 ,
`lastBattleEndTime`  bigint(20) NULL DEFAULT 0 ,
`autoFightAction`  int(11) NULL DEFAULT 0 ,
`petAutoFightAction`  int(11) NULL DEFAULT 0 ,
`pubExp`  bigint(20) NULL DEFAULT 0 ,
`pubLevel`  int(11) NULL DEFAULT 0 ,
`mainSkillLevel`  int(11) NULL DEFAULT 1 ,
`mainSkillType`  int(11) NULL DEFAULT 0 ,
`levelUpTimeStamp`  bigint(20) NULL DEFAULT 0 ,
`energy`  int(11) NULL DEFAULT 0 ,
`mineLevel`  int(11) NULL DEFAULT 1 ,
`gold2`  bigint(20) NULL DEFAULT 0 ,
`backMapId`  int(11) NULL DEFAULT 0 ,
`backX`  int(11) NULL DEFAULT 0 ,
`backY`  int(11) NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_corps`
-- ----------------------------
DROP TABLE IF EXISTS `t_corps`;
CREATE TABLE `t_corps` (
`id`  bigint(20) NOT NULL ,
`canRename`  int(11) NOT NULL DEFAULT 0 ,
`corpsExp`  bigint(20) NULL DEFAULT NULL ,
`country`  int(11) NULL DEFAULT NULL ,
`createDate`  bigint(20) NULL DEFAULT NULL ,
`creater`  bigint(20) NULL DEFAULT NULL ,
`currLevelExp`  bigint(20) NULL DEFAULT NULL ,
`disbandConfrimDate`  bigint(20) NOT NULL DEFAULT 0 ,
`level`  int(11) NOT NULL DEFAULT 0 ,
`memberExp`  bigint(20) NULL DEFAULT NULL ,
`name`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`notice`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`president`  bigint(20) NULL DEFAULT NULL ,
`presidentName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`qq`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`storagePack`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_corps_member`
-- ----------------------------
DROP TABLE IF EXISTS `t_corps_member`;
CREATE TABLE `t_corps_member` (
`id`  bigint(20) NOT NULL ,
`contributeDate`  bigint(20) NULL DEFAULT NULL ,
`corpsId`  bigint(20) NULL DEFAULT NULL ,
`corpsMemState`  int(11) NOT NULL DEFAULT 0 ,
`donateDate`  bigint(20) NULL DEFAULT NULL ,
`joinDate`  bigint(20) NULL DEFAULT NULL ,
`level`  int(11) NOT NULL DEFAULT 0 ,
`logoutTime`  bigint(20) NULL DEFAULT NULL ,
`memJob`  int(11) NOT NULL DEFAULT 0 ,
`name`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`petJob`  int(11) NOT NULL DEFAULT 0 ,
`roleId`  bigint(20) NULL DEFAULT NULL ,
`sex`  int(11) NOT NULL DEFAULT 0 ,
`toCorpsExp`  bigint(20) NULL DEFAULT NULL ,
`todayDonate`  bigint(20) NULL DEFAULT NULL ,
`totalContribution`  int(11) NULL DEFAULT NULL ,
`totalDonate`  bigint(20) NULL DEFAULT NULL ,
`weekyContribution`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_corpswar_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_corpswar_rank`;
CREATE TABLE `t_corpswar_rank` (
`id`  bigint(20) NOT NULL ,
`corpsId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`rank`  int(11) NOT NULL DEFAULT 0 ,
`score`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_db_version`
-- ----------------------------
DROP TABLE IF EXISTS `t_db_version`;
CREATE TABLE `t_db_version` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`mergeTime`  datetime NULL DEFAULT NULL ,
`openTime`  datetime NOT NULL ,
`updateTime`  datetime NOT NULL ,
`version`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`serverIds`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`serverNames`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=2

;

-- ----------------------------
-- Table structure for `t_dirtywords`
-- ----------------------------
DROP TABLE IF EXISTS `t_dirtywords`;
CREATE TABLE `t_dirtywords` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`dirtyWordsType`  int(11) NOT NULL DEFAULT 0 ,
`updateTime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=2

;

-- ----------------------------
-- Table structure for `t_doing_task`
-- ----------------------------
DROP TABLE IF EXISTS `t_doing_task`;
CREATE TABLE `t_doing_task` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NULL DEFAULT NULL ,
`props`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`questId`  int(11) NULL DEFAULT NULL ,
`startTime`  datetime NULL DEFAULT NULL ,
`trace`  tinyint(4) NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_finished_quest`
-- ----------------------------
DROP TABLE IF EXISTS `t_finished_quest`;
CREATE TABLE `t_finished_quest` (
`id`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NULL DEFAULT NULL ,
`dailyTimes`  int(11) NULL DEFAULT NULL ,
`endTime`  datetime NULL DEFAULT NULL ,
`questId`  int(11) NULL DEFAULT NULL ,
`startTime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_good_activity`
-- ----------------------------
DROP TABLE IF EXISTS `t_good_activity`;
CREATE TABLE `t_good_activity` (
`id`  bigint(20) NOT NULL ,
`activityDesc`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`activityName`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`activityTplId`  int(11) NOT NULL DEFAULT 0 ,
`activityType`  int(11) NOT NULL DEFAULT 0 ,
`closeTime`  bigint(20) NOT NULL DEFAULT 0 ,
`endTime`  bigint(20) NOT NULL DEFAULT 0 ,
`isAvailable`  int(11) NOT NULL DEFAULT 0 ,
`isClosed`  int(11) NOT NULL DEFAULT 0 ,
`isForceEnd`  int(11) NOT NULL DEFAULT 0 ,
`isStarted`  int(11) NOT NULL DEFAULT 0 ,
`lastRefreshTime`  bigint(20) NOT NULL DEFAULT 0 ,
`nameIcon`  int(11) NOT NULL DEFAULT 0 ,
`serverIds`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`titleIcon`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_good_activity_user`
-- ----------------------------
DROP TABLE IF EXISTS `t_good_activity_user`;
CREATE TABLE `t_good_activity_user` (
`id`  bigint(20) NOT NULL ,
`activityData`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`activityId`  bigint(20) NULL DEFAULT 0 ,
`charId`  bigint(20) NULL DEFAULT 0 ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_item_cost`
-- ----------------------------
DROP TABLE IF EXISTS `t_item_cost`;
CREATE TABLE `t_item_cost` (
`id`  bigint(20) NOT NULL ,
`actualCost`  bigint(20) NOT NULL DEFAULT 0 ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`freeNum`  int(11) NOT NULL DEFAULT 0 ,
`itemNum`  int(11) NOT NULL DEFAULT 0 ,
`templateId`  int(11) NOT NULL DEFAULT 0 ,
`totalCost`  bigint(20) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_item_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_item_info`;
CREATE TABLE `t_item_info` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`bagId`  int(11) NULL DEFAULT NULL ,
`bagIndex`  int(11) NULL DEFAULT NULL ,
`charId`  bigint(20) NULL DEFAULT NULL ,
`createTime`  datetime NULL DEFAULT NULL ,
`deadline`  datetime NULL DEFAULT NULL ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`intoTempBagTime`  datetime NULL DEFAULT NULL ,
`overlap`  int(11) NULL DEFAULT NULL ,
`properties`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`templateId`  int(11) NULL DEFAULT NULL ,
`wearerId`  bigint(20) NULL DEFAULT NULL ,
`lastUpdateTime`  bigint(20) NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_mail_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_mail_info`;
CREATE TABLE `t_mail_info` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`attachmentProps`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`charId`  bigint(20) NULL DEFAULT 0 ,
`content`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`createTime`  datetime NULL DEFAULT NULL ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`mailStatus`  int(11) NULL DEFAULT 0 ,
`mailType`  int(11) NULL DEFAULT 0 ,
`recId`  bigint(20) NULL DEFAULT 0 ,
`recName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`sendId`  bigint(20) NULL DEFAULT 0 ,
`sendName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`title`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`updateTime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_mall_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_mall_info`;
CREATE TABLE `t_mall_info` (
`id`  bigint(20) NOT NULL ,
`currQueueConfig`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`currQueueId`  int(11) NULL DEFAULT NULL ,
`currQueueUUID`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`currStartTime`  bigint(20) NULL DEFAULT NULL ,
`queueConfig`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`startConfigTime`  bigint(20) NULL DEFAULT NULL ,
`stockPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`updateTime`  bigint(20) NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_marry_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_marry_info`;
CREATE TABLE `t_marry_info` (
`id`  bigint(20) NOT NULL ,
`charId`  bigint(20) NULL DEFAULT NULL ,
`maritalStatus`  int(11) NOT NULL ,
`marryProps`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_module_data`
-- ----------------------------
DROP TABLE IF EXISTS `t_module_data`;
CREATE TABLE `t_module_data` (
`id`  int(11) NOT NULL ,
`json`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_nvn_rank`
-- ----------------------------
DROP TABLE IF EXISTS `t_nvn_rank`;
CREATE TABLE `t_nvn_rank` (
`id`  bigint(20) NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`conWin`  int(11) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`loss`  int(11) NOT NULL DEFAULT 0 ,
`rank`  int(11) NOT NULL DEFAULT 0 ,
`score`  int(11) NOT NULL DEFAULT 0 ,
`win`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_offline_reward`
-- ----------------------------
DROP TABLE IF EXISTS `t_offline_reward`;
CREATE TABLE `t_offline_reward` (
`id`  bigint(20) NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`props`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`rewardType`  int(11) NOT NULL DEFAULT 0 ,
`rewards`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_overman_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_overman_info`;
CREATE TABLE `t_overman_info` (
`id`  bigint(20) NOT NULL ,
`overmanProps`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_pet_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_pet_info`;
CREATE TABLE `t_pet_info` (
`id`  bigint(20) NOT NULL ,
`charId`  bigint(20) NULL DEFAULT NULL ,
`createDate`  datetime NULL DEFAULT NULL ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`exp`  bigint(20) NULL DEFAULT NULL ,
`lastFireDate`  datetime NULL DEFAULT NULL ,
`lastHireDate`  datetime NULL DEFAULT NULL ,
`level`  int(11) NULL DEFAULT NULL ,
`petState`  int(11) NOT NULL DEFAULT 0 ,
`petType`  int(11) NULL DEFAULT NULL ,
`skillId`  int(11) NULL DEFAULT NULL ,
`templateId`  int(11) NULL DEFAULT NULL ,
`colorId`  int(11) NULL DEFAULT 1 ,
`starId`  int(11) NULL DEFAULT 1 ,
`skillProp`  varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`aPropAddPoint`  varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`leftPoint`  int(11) NULL DEFAULT 0 ,
`geneType`  int(11) NULL DEFAULT 0 ,
`growthColor`  int(11) NULL DEFAULT 0 ,
`isFight`  int(11) NULL DEFAULT 0 ,
`life`  int(11) NULL DEFAULT 0 ,
`name`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`equipStars`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`trainAddProp`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`perceptExp`  bigint(20) NULL DEFAULT 0 ,
`perceptLevel`  int(11) NULL DEFAULT 0 ,
`petScore`  int(11) NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_prize`
-- ----------------------------
DROP TABLE IF EXISTS `t_prize`;
CREATE TABLE `t_prize` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`coin`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`createTime`  datetime NULL DEFAULT NULL ,
`item`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`pet`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`prizeId`  int(11) NULL DEFAULT NULL ,
`prizeName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Table structure for `t_relation_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_relation_info`;
CREATE TABLE `t_relation_info` (
`id`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`relationType`  int(11) NOT NULL DEFAULT 0 ,
`targetCharId`  bigint(20) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_scene_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_scene_info`;
CREATE TABLE `t_scene_info` (
`id`  bigint(20) NOT NULL DEFAULT 0 ,
`properties`  text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`templateId`  int(11) NOT NULL ,
PRIMARY KEY (`id`),
UNIQUE INDEX `id` (`id`) USING BTREE ,
INDEX `templateId` (`templateId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_sys_mail`
-- ----------------------------
DROP TABLE IF EXISTS `t_sys_mail`;
CREATE TABLE `t_sys_mail` (
`id`  bigint(20) NOT NULL ,
`attachmentProps`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`content`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`createTime`  bigint(20) NULL DEFAULT 0 ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`expiredTime`  bigint(20) NULL DEFAULT 0 ,
`sendUsers`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`title`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_common`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_common`;
CREATE TABLE `t_task_common` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questTypeId`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_forage`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_forage`;
CREATE TABLE `t_task_forage` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`battleFailCount`  int(11) NOT NULL DEFAULT 0 ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questStar`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_pub`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_pub`;
CREATE TABLE `t_task_pub` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questStar`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_thesweeney`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_thesweeney`;
CREATE TABLE `t_task_thesweeney` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questTypeId`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_thesweeney_treasure`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_thesweeney_treasure`;
CREATE TABLE `t_task_thesweeney_treasure` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questTypeId`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_task_treasure`
-- ----------------------------
DROP TABLE IF EXISTS `t_task_treasure`;
CREATE TABLE `t_task_treasure` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`lastUpdateTime`  bigint(20) NOT NULL DEFAULT 0 ,
`props`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`questId`  int(11) NOT NULL DEFAULT 0 ,
`questTypeId`  int(11) NOT NULL DEFAULT 0 ,
`startTime`  bigint(20) NOT NULL DEFAULT 0 ,
`status`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_time_notice`
-- ----------------------------
DROP TABLE IF EXISTS `t_time_notice`;
CREATE TABLE `t_time_notice` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`intervalTime`  int(11) UNSIGNED ZEROFILL NULL DEFAULT NULL ,
`serverIds`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`operator`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`content`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`startTime`  timestamp NULL DEFAULT NULL ,
`endTime`  timestamp NULL DEFAULT NULL ,
`openType`  tinyint(4) NOT NULL DEFAULT 0 ,
`type`  tinyint(4) NOT NULL DEFAULT 0 ,
`subType`  tinyint(4) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`),
UNIQUE INDEX `id` (`id`) USING BTREE ,
INDEX `serverIds` (`serverIds`) USING BTREE ,
INDEX `type` (`type`) USING BTREE ,
INDEX `subType` (`subType`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Table structure for `t_title_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_title_info`;
CREATE TABLE `t_title_info` (
`id`  bigint(20) NOT NULL ,
`disTitle`  int(11) NOT NULL ,
`inUseTplid`  int(11) NOT NULL ,
`titleInfoProps`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_trade_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_trade_info`;
CREATE TABLE `t_trade_info` (
`id`  bigint(20) NOT NULL ,
`boothIndex`  int(11) NULL DEFAULT NULL ,
`buyerCharId`  bigint(20) NULL DEFAULT NULL ,
`commodityInfo`  varchar(4096) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' ,
`commodityNum`  int(11) NULL DEFAULT NULL ,
`currencyNum`  int(11) NULL DEFAULT NULL ,
`currencyType`  int(11) NULL DEFAULT NULL ,
`deleteDate`  datetime NULL DEFAULT NULL ,
`deleted`  int(11) NULL DEFAULT NULL ,
`lastUpdateTime`  datetime NULL DEFAULT NULL ,
`overDueTime`  datetime NULL DEFAULT NULL ,
`sellerCharId`  bigint(20) NULL DEFAULT NULL ,
`startTime`  datetime NULL DEFAULT NULL ,
`tradeStatus`  int(11) NULL DEFAULT NULL ,
`type`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_user_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_info`;
CREATE TABLE `t_user_info` (
`id`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`activity`  int(11) NOT NULL DEFAULT 0 ,
`answer`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`cookieValue`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`email`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`failedLogins`  int(11) NOT NULL DEFAULT 0 ,
`foribedTalkTime`  bigint(20) NOT NULL DEFAULT 0 ,
`joinTime`  datetime NULL DEFAULT NULL ,
`lastLoginIp`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`lastLoginTime`  datetime NULL DEFAULT NULL ,
`lastLogoutTime`  datetime NULL DEFAULT NULL ,
`locale`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`lockStatus`  int(11) NOT NULL DEFAULT 0 ,
`muteTime`  int(11) NOT NULL DEFAULT 0 ,
`name`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`password`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`props`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`qqData`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`question`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`role`  int(11) NOT NULL DEFAULT 0 ,
`source`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`todayOnlineTime`  int(11) NOT NULL DEFAULT 0 ,
`todayOnlineUpdateTime`  datetime NULL DEFAULT NULL ,
`version`  varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`),
UNIQUE INDEX `name` (`name`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_user_offline`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_offline`;
CREATE TABLE `t_user_offline` (
`id`  bigint(20) NOT NULL ,
`curArrayIndex`  int(11) NOT NULL DEFAULT 0 ,
`friendArray`  varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`friendPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`hpPool`  bigint(20) NOT NULL DEFAULT 0 ,
`mpPool`  bigint(20) NOT NULL DEFAULT 0 ,
`passportId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`petPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`lifePool`  bigint(20) NULL DEFAULT 0 ,
`fightPetId`  bigint(20) NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_user_prize`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_prize`;
CREATE TABLE `t_user_prize` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`charId`  bigint(20) NOT NULL DEFAULT 0 ,
`coin`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`createTime`  datetime NULL DEFAULT NULL ,
`expireTime`  datetime NULL DEFAULT NULL ,
`item`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`itemParams`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`params`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`passportId`  text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`status`  int(11) NOT NULL DEFAULT 0 ,
`type`  int(11) NOT NULL DEFAULT 0 ,
`updateTime`  datetime NULL DEFAULT NULL ,
`userPrizeName`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Table structure for `t_user_snap`
-- ----------------------------
DROP TABLE IF EXISTS `t_user_snap`;
CREATE TABLE `t_user_snap` (
`id`  bigint(20) NOT NULL ,
`armies`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`country`  int(11) NOT NULL DEFAULT 0 ,
`fightPower`  int(11) NOT NULL DEFAULT 0 ,
`formation`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`funcPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`godHeroPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`horsePack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`lastOpenedMindId`  int(11) NOT NULL DEFAULT 0 ,
`level`  int(11) NOT NULL DEFAULT 0 ,
`militaryRank`  int(11) NOT NULL DEFAULT 0 ,
`name`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`passportId`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`propsPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`qqData`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`serverId`  int(11) NOT NULL DEFAULT 0 ,
`vipLevel`  int(11) NOT NULL DEFAULT 0 ,
`autoActionId`  int(11) NULL DEFAULT 0 ,
`autoSkillLevel`  int(11) NULL DEFAULT 0 ,
`mindId`  int(11) NULL DEFAULT 0 ,
`mindLevel`  int(11) NULL DEFAULT 0 ,
`petAutoActionId`  int(11) NULL DEFAULT 0 ,
`petAutoSkillLevel`  int(11) NULL DEFAULT 0 ,
`equipPack`  text CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`wingId`  int(11) NULL DEFAULT 0 ,
`wingLevel`  int(11) NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_wing_info`
-- ----------------------------
DROP TABLE IF EXISTS `t_wing_info`;
CREATE TABLE `t_wing_info` (
`id`  varchar(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`charId`  bigint(20) NOT NULL ,
`createDate`  bigint(20) NOT NULL DEFAULT 0 ,
`equipped`  int(1) NOT NULL DEFAULT 0 ,
`templateId`  int(11) NOT NULL DEFAULT 0 ,
`wingBless`  int(5) NOT NULL DEFAULT 0 ,
`wingLevel`  int(2) NOT NULL DEFAULT 0 ,
`wingPower`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Table structure for `t_world_gift`
-- ----------------------------
DROP TABLE IF EXISTS `t_world_gift`;
CREATE TABLE `t_world_gift` (
`id`  int(11) NOT NULL AUTO_INCREMENT ,
`createTime`  bigint(20) NOT NULL DEFAULT 0 ,
`giftId`  int(11) NOT NULL DEFAULT 0 ,
`giftName`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`giftParams`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' ,
`isDel`  int(11) NOT NULL DEFAULT 0 ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Auto increment value for `t_cdkey_plans`
-- ----------------------------
ALTER TABLE `t_cdkey_plans` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for `t_db_version`
-- ----------------------------
ALTER TABLE `t_db_version` AUTO_INCREMENT=2;

-- ----------------------------
-- Auto increment value for `t_dirtywords`
-- ----------------------------
ALTER TABLE `t_dirtywords` AUTO_INCREMENT=2;

-- ----------------------------
-- Auto increment value for `t_prize`
-- ----------------------------
ALTER TABLE `t_prize` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for `t_time_notice`
-- ----------------------------
ALTER TABLE `t_time_notice` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for `t_user_prize`
-- ----------------------------
ALTER TABLE `t_user_prize` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for `t_world_gift`
-- ----------------------------
ALTER TABLE `t_world_gift` AUTO_INCREMENT=1;

use `ts001`;
INSERT INTO `t_db_version` VALUES (1,'2015-01-23 16:56:33','2015-01-23 14:00:00','2015-01-23 19:39:36','1.0.0.1','[1001]','[\"ts1\"]');
INSERT INTO `t_dirtywords` VALUES (1,0,'2015-01-23 16:56:33');

insert into t_user_info (id,name,password) values ('1',concat('test',id),'1');
insert into t_user_info (id,name,password) values ('2',concat('test',id),'1');
insert into t_user_info (id,name,password) values ('3',concat('test',id),'');
insert into t_user_info (id,name,password) values ('4',concat('test',id),'');
insert into t_user_info (id,name,password) values ('5',concat('test',id),'');
insert into t_user_info (id,name,password) values ('6',concat('test',id),'');
insert into t_user_info (id,name,password) values ('7',concat('test',id),'');
insert into t_user_info (id,name,password) values ('8',concat('test',id),'');
insert into t_user_info (id,name,password) values ('9',concat('test',id),'');
insert into t_user_info (id,name,password) values ('10',concat('test',id),'');
insert into t_user_info (id,name,password) values ('11',concat('test',id),'');
insert into t_user_info (id,name,password) values ('12',concat('test',id),'');
insert into t_user_info (id,name,password) values ('13',concat('test',id),'');
insert into t_user_info (id,name,password) values ('14',concat('test',id),'');
insert into t_user_info (id,name,password) values ('15',concat('test',id),'');
insert into t_user_info (id,name,password) values ('16',concat('test',id),'');
insert into t_user_info (id,name,password) values ('17',concat('test',id),'');
insert into t_user_info (id,name,password) values ('18',concat('test',id),'');
insert into t_user_info (id,name,password) values ('19',concat('test',id),'');
insert into t_user_info (id,name,password) values ('20',concat('test',id),'');
insert into t_user_info (id,name,password) values ('21',concat('test',id),'');
insert into t_user_info (id,name,password) values ('22',concat('test',id),'');
insert into t_user_info (id,name,password) values ('23',concat('test',id),'');
insert into t_user_info (id,name,password) values ('24',concat('test',id),'');
insert into t_user_info (id,name,password) values ('25',concat('test',id),'');
insert into t_user_info (id,name,password) values ('26',concat('test',id),'');
insert into t_user_info (id,name,password) values ('27',concat('test',id),'');
insert into t_user_info (id,name,password) values ('28',concat('test',id),'');
insert into t_user_info (id,name,password) values ('29',concat('test',id),'');
insert into t_user_info (id,name,password) values ('30',concat('test',id),'');
insert into t_user_info (id,name,password) values ('31',concat('test',id),'');
insert into t_user_info (id,name,password) values ('32',concat('test',id),'');
insert into t_user_info (id,name,password) values ('33',concat('test',id),'');
insert into t_user_info (id,name,password) values ('34',concat('test',id),'');
insert into t_user_info (id,name,password) values ('35',concat('test',id),'');
insert into t_user_info (id,name,password) values ('36',concat('test',id),'');
insert into t_user_info (id,name,password) values ('37',concat('test',id),'');
insert into t_user_info (id,name,password) values ('38',concat('test',id),'');
insert into t_user_info (id,name,password) values ('39',concat('test',id),'');
insert into t_user_info (id,name,password) values ('40',concat('test',id),'');
insert into t_user_info (id,name,password) values ('41',concat('test',id),'');
insert into t_user_info (id,name,password) values ('42',concat('test',id),'');
insert into t_user_info (id,name,password) values ('43',concat('test',id),'');
insert into t_user_info (id,name,password) values ('44',concat('test',id),'');
insert into t_user_info (id,name,password) values ('45',concat('test',id),'');
insert into t_user_info (id,name,password) values ('46',concat('test',id),'');
insert into t_user_info (id,name,password) values ('47',concat('test',id),'');
insert into t_user_info (id,name,password) values ('48',concat('test',id),'');
insert into t_user_info (id,name,password) values ('49',concat('test',id),'');
insert into t_user_info (id,name,password) values ('50',concat('test',id),'');
insert into t_user_info (id,name,password) values ('51',concat('test',id),'');
insert into t_user_info (id,name,password) values ('52',concat('test',id),'');
insert into t_user_info (id,name,password) values ('53',concat('test',id),'');
insert into t_user_info (id,name,password) values ('54',concat('test',id),'');
insert into t_user_info (id,name,password) values ('55',concat('test',id),'');
insert into t_user_info (id,name,password) values ('56',concat('test',id),'');
insert into t_user_info (id,name,password) values ('57',concat('test',id),'');
insert into t_user_info (id,name,password) values ('58',concat('test',id),'');
insert into t_user_info (id,name,password) values ('59',concat('test',id),'');
insert into t_user_info (id,name,password) values ('60',concat('test',id),'');
insert into t_user_info (id,name,password) values ('61',concat('test',id),'');
insert into t_user_info (id,name,password) values ('62',concat('test',id),'');
insert into t_user_info (id,name,password) values ('63',concat('test',id),'');
insert into t_user_info (id,name,password) values ('64',concat('test',id),'');
insert into t_user_info (id,name,password) values ('65',concat('test',id),'');
insert into t_user_info (id,name,password) values ('66',concat('test',id),'');
insert into t_user_info (id,name,password) values ('67',concat('test',id),'');
insert into t_user_info (id,name,password) values ('68',concat('test',id),'');
insert into t_user_info (id,name,password) values ('69',concat('test',id),'');
insert into t_user_info (id,name,password) values ('70',concat('test',id),'');
insert into t_user_info (id,name,password) values ('71',concat('test',id),'');
insert into t_user_info (id,name,password) values ('72',concat('test',id),'');
insert into t_user_info (id,name,password) values ('73',concat('test',id),'');
insert into t_user_info (id,name,password) values ('74',concat('test',id),'');
insert into t_user_info (id,name,password) values ('75',concat('test',id),'');
insert into t_user_info (id,name,password) values ('76',concat('test',id),'');
insert into t_user_info (id,name,password) values ('77',concat('test',id),'');
insert into t_user_info (id,name,password) values ('78',concat('test',id),'');
insert into t_user_info (id,name,password) values ('79',concat('test',id),'');
insert into t_user_info (id,name,password) values ('80',concat('test',id),'');
insert into t_user_info (id,name,password) values ('81',concat('test',id),'');
insert into t_user_info (id,name,password) values ('82',concat('test',id),'');
insert into t_user_info (id,name,password) values ('83',concat('test',id),'');
insert into t_user_info (id,name,password) values ('84',concat('test',id),'');
insert into t_user_info (id,name,password) values ('85',concat('test',id),'');
insert into t_user_info (id,name,password) values ('86',concat('test',id),'');
insert into t_user_info (id,name,password) values ('87',concat('test',id),'');
insert into t_user_info (id,name,password) values ('88',concat('test',id),'');
insert into t_user_info (id,name,password) values ('89',concat('test',id),'');
insert into t_user_info (id,name,password) values ('90',concat('test',id),'');
insert into t_user_info (id,name,password) values ('91',concat('test',id),'');
insert into t_user_info (id,name,password) values ('92',concat('test',id),'');
insert into t_user_info (id,name,password) values ('93',concat('test',id),'');
insert into t_user_info (id,name,password) values ('94',concat('test',id),'');
insert into t_user_info (id,name,password) values ('95',concat('test',id),'');
insert into t_user_info (id,name,password) values ('96',concat('test',id),'');
insert into t_user_info (id,name,password) values ('97',concat('test',id),'');
insert into t_user_info (id,name,password) values ('98',concat('test',id),'');
insert into t_user_info (id,name,password) values ('99',concat('test',id),'');
insert into t_user_info (id,name,password) values ('100',concat('test',id),'');
insert into t_user_info (id,name,password) values ('101',concat('test',id),'');
insert into t_user_info (id,name,password) values ('102',concat('test',id),'');
insert into t_user_info (id,name,password) values ('103',concat('test',id),'');
insert into t_user_info (id,name,password) values ('104',concat('test',id),'');
insert into t_user_info (id,name,password) values ('105',concat('test',id),'');
insert into t_user_info (id,name,password) values ('106',concat('test',id),'');
insert into t_user_info (id,name,password) values ('107',concat('test',id),'');
insert into t_user_info (id,name,password) values ('108',concat('test',id),'');
insert into t_user_info (id,name,password) values ('109',concat('test',id),'');
insert into t_user_info (id,name,password) values ('110',concat('test',id),'');
insert into t_user_info (id,name,password) values ('111',concat('test',id),'');
insert into t_user_info (id,name,password) values ('112',concat('test',id),'');
insert into t_user_info (id,name,password) values ('113',concat('test',id),'');
insert into t_user_info (id,name,password) values ('114',concat('test',id),'');
insert into t_user_info (id,name,password) values ('115',concat('test',id),'');
insert into t_user_info (id,name,password) values ('116',concat('test',id),'');
insert into t_user_info (id,name,password) values ('117',concat('test',id),'');
insert into t_user_info (id,name,password) values ('118',concat('test',id),'');
insert into t_user_info (id,name,password) values ('119',concat('test',id),'');
insert into t_user_info (id,name,password) values ('120',concat('test',id),'');
insert into t_user_info (id,name,password) values ('121',concat('test',id),'');
insert into t_user_info (id,name,password) values ('122',concat('test',id),'');
insert into t_user_info (id,name,password) values ('123',concat('test',id),'');
insert into t_user_info (id,name,password) values ('124',concat('test',id),'');
insert into t_user_info (id,name,password) values ('125',concat('test',id),'');
insert into t_user_info (id,name,password) values ('126',concat('test',id),'');
insert into t_user_info (id,name,password) values ('127',concat('test',id),'');
insert into t_user_info (id,name,password) values ('128',concat('test',id),'');
insert into t_user_info (id,name,password) values ('129',concat('test',id),'');
insert into t_user_info (id,name,password) values ('130',concat('test',id),'');
insert into t_user_info (id,name,password) values ('131',concat('test',id),'');
insert into t_user_info (id,name,password) values ('132',concat('test',id),'');
insert into t_user_info (id,name,password) values ('133',concat('test',id),'');
insert into t_user_info (id,name,password) values ('134',concat('test',id),'');
insert into t_user_info (id,name,password) values ('135',concat('test',id),'');
insert into t_user_info (id,name,password) values ('136',concat('test',id),'');
insert into t_user_info (id,name,password) values ('137',concat('test',id),'');
insert into t_user_info (id,name,password) values ('138',concat('test',id),'');
insert into t_user_info (id,name,password) values ('139',concat('test',id),'');
insert into t_user_info (id,name,password) values ('140',concat('test',id),'');
insert into t_user_info (id,name,password) values ('141',concat('test',id),'');
insert into t_user_info (id,name,password) values ('142',concat('test',id),'');
insert into t_user_info (id,name,password) values ('143',concat('test',id),'');
insert into t_user_info (id,name,password) values ('144',concat('test',id),'');
insert into t_user_info (id,name,password) values ('145',concat('test',id),'');
insert into t_user_info (id,name,password) values ('146',concat('test',id),'');
insert into t_user_info (id,name,password) values ('147',concat('test',id),'');
insert into t_user_info (id,name,password) values ('148',concat('test',id),'');
insert into t_user_info (id,name,password) values ('149',concat('test',id),'');
insert into t_user_info (id,name,password) values ('150',concat('test',id),'');
insert into t_user_info (id,name,password) values ('151',concat('test',id),'');
insert into t_user_info (id,name,password) values ('152',concat('test',id),'');
insert into t_user_info (id,name,password) values ('153',concat('test',id),'');
insert into t_user_info (id,name,password) values ('154',concat('test',id),'');
insert into t_user_info (id,name,password) values ('155',concat('test',id),'');
insert into t_user_info (id,name,password) values ('156',concat('test',id),'');
insert into t_user_info (id,name,password) values ('157',concat('test',id),'');
insert into t_user_info (id,name,password) values ('158',concat('test',id),'');
insert into t_user_info (id,name,password) values ('159',concat('test',id),'');
insert into t_user_info (id,name,password) values ('160',concat('test',id),'');
insert into t_user_info (id,name,password) values ('161',concat('test',id),'');
insert into t_user_info (id,name,password) values ('162',concat('test',id),'');
insert into t_user_info (id,name,password) values ('163',concat('test',id),'');
insert into t_user_info (id,name,password) values ('164',concat('test',id),'');
insert into t_user_info (id,name,password) values ('165',concat('test',id),'');
insert into t_user_info (id,name,password) values ('166',concat('test',id),'');
insert into t_user_info (id,name,password) values ('167',concat('test',id),'');
insert into t_user_info (id,name,password) values ('168',concat('test',id),'');
insert into t_user_info (id,name,password) values ('169',concat('test',id),'');
insert into t_user_info (id,name,password) values ('170',concat('test',id),'');
insert into t_user_info (id,name,password) values ('171',concat('test',id),'');
insert into t_user_info (id,name,password) values ('172',concat('test',id),'');
insert into t_user_info (id,name,password) values ('173',concat('test',id),'');
insert into t_user_info (id,name,password) values ('174',concat('test',id),'');
insert into t_user_info (id,name,password) values ('175',concat('test',id),'');
insert into t_user_info (id,name,password) values ('176',concat('test',id),'');
insert into t_user_info (id,name,password) values ('177',concat('test',id),'');
insert into t_user_info (id,name,password) values ('178',concat('test',id),'');
insert into t_user_info (id,name,password) values ('179',concat('test',id),'');
insert into t_user_info (id,name,password) values ('180',concat('test',id),'');
insert into t_user_info (id,name,password) values ('181',concat('test',id),'');
insert into t_user_info (id,name,password) values ('182',concat('test',id),'');
insert into t_user_info (id,name,password) values ('183',concat('test',id),'');
insert into t_user_info (id,name,password) values ('184',concat('test',id),'');
insert into t_user_info (id,name,password) values ('185',concat('test',id),'');
insert into t_user_info (id,name,password) values ('186',concat('test',id),'');
insert into t_user_info (id,name,password) values ('187',concat('test',id),'');
insert into t_user_info (id,name,password) values ('188',concat('test',id),'');
insert into t_user_info (id,name,password) values ('189',concat('test',id),'');
insert into t_user_info (id,name,password) values ('190',concat('test',id),'');
insert into t_user_info (id,name,password) values ('191',concat('test',id),'');
insert into t_user_info (id,name,password) values ('192',concat('test',id),'');
insert into t_user_info (id,name,password) values ('193',concat('test',id),'');
insert into t_user_info (id,name,password) values ('194',concat('test',id),'');
insert into t_user_info (id,name,password) values ('195',concat('test',id),'');
insert into t_user_info (id,name,password) values ('196',concat('test',id),'');
insert into t_user_info (id,name,password) values ('197',concat('test',id),'');
insert into t_user_info (id,name,password) values ('198',concat('test',id),'');
insert into t_user_info (id,name,password) values ('199',concat('test',id),'');
insert into t_user_info (id,name,password) values ('200',concat('test',id),'');
insert into t_user_info (id,name,password) values ('201',concat('test',id),'');
insert into t_user_info (id,name,password) values ('202',concat('test',id),'');
insert into t_user_info (id,name,password) values ('203',concat('test',id),'');
insert into t_user_info (id,name,password) values ('204',concat('test',id),'');
insert into t_user_info (id,name,password) values ('205',concat('test',id),'');
insert into t_user_info (id,name,password) values ('206',concat('test',id),'');
insert into t_user_info (id,name,password) values ('207',concat('test',id),'');
insert into t_user_info (id,name,password) values ('208',concat('test',id),'');
insert into t_user_info (id,name,password) values ('209',concat('test',id),'');
insert into t_user_info (id,name,password) values ('210',concat('test',id),'');
insert into t_user_info (id,name,password) values ('211',concat('test',id),'');
insert into t_user_info (id,name,password) values ('212',concat('test',id),'');
insert into t_user_info (id,name,password) values ('213',concat('test',id),'');
insert into t_user_info (id,name,password) values ('214',concat('test',id),'');
insert into t_user_info (id,name,password) values ('215',concat('test',id),'');
insert into t_user_info (id,name,password) values ('216',concat('test',id),'');
insert into t_user_info (id,name,password) values ('217',concat('test',id),'');
insert into t_user_info (id,name,password) values ('218',concat('test',id),'');
insert into t_user_info (id,name,password) values ('219',concat('test',id),'');
insert into t_user_info (id,name,password) values ('220',concat('test',id),'');
insert into t_user_info (id,name,password) values ('221',concat('test',id),'');
insert into t_user_info (id,name,password) values ('222',concat('test',id),'');
insert into t_user_info (id,name,password) values ('223',concat('test',id),'');
insert into t_user_info (id,name,password) values ('224',concat('test',id),'');
insert into t_user_info (id,name,password) values ('225',concat('test',id),'');
insert into t_user_info (id,name,password) values ('226',concat('test',id),'');
insert into t_user_info (id,name,password) values ('227',concat('test',id),'');
insert into t_user_info (id,name,password) values ('228',concat('test',id),'');
insert into t_user_info (id,name,password) values ('229',concat('test',id),'');
insert into t_user_info (id,name,password) values ('230',concat('test',id),'');
insert into t_user_info (id,name,password) values ('231',concat('test',id),'');
insert into t_user_info (id,name,password) values ('232',concat('test',id),'');
insert into t_user_info (id,name,password) values ('233',concat('test',id),'');
insert into t_user_info (id,name,password) values ('234',concat('test',id),'');
insert into t_user_info (id,name,password) values ('235',concat('test',id),'');
insert into t_user_info (id,name,password) values ('236',concat('test',id),'');
insert into t_user_info (id,name,password) values ('237',concat('test',id),'');
insert into t_user_info (id,name,password) values ('238',concat('test',id),'');
insert into t_user_info (id,name,password) values ('239',concat('test',id),'');
insert into t_user_info (id,name,password) values ('240',concat('test',id),'');
insert into t_user_info (id,name,password) values ('241',concat('test',id),'');
insert into t_user_info (id,name,password) values ('242',concat('test',id),'');
insert into t_user_info (id,name,password) values ('243',concat('test',id),'');
insert into t_user_info (id,name,password) values ('244',concat('test',id),'');
insert into t_user_info (id,name,password) values ('245',concat('test',id),'');
insert into t_user_info (id,name,password) values ('246',concat('test',id),'');
insert into t_user_info (id,name,password) values ('247',concat('test',id),'');
insert into t_user_info (id,name,password) values ('248',concat('test',id),'');
insert into t_user_info (id,name,password) values ('249',concat('test',id),'');
insert into t_user_info (id,name,password) values ('250',concat('test',id),'');
insert into t_user_info (id,name,password) values ('251',concat('test',id),'');
insert into t_user_info (id,name,password) values ('252',concat('test',id),'');
insert into t_user_info (id,name,password) values ('253',concat('test',id),'');
insert into t_user_info (id,name,password) values ('254',concat('test',id),'');
insert into t_user_info (id,name,password) values ('255',concat('test',id),'');
insert into t_user_info (id,name,password) values ('256',concat('test',id),'');
insert into t_user_info (id,name,password) values ('257',concat('test',id),'');
insert into t_user_info (id,name,password) values ('258',concat('test',id),'');
insert into t_user_info (id,name,password) values ('259',concat('test',id),'');
insert into t_user_info (id,name,password) values ('260',concat('test',id),'');
insert into t_user_info (id,name,password) values ('261',concat('test',id),'');
insert into t_user_info (id,name,password) values ('262',concat('test',id),'');
insert into t_user_info (id,name,password) values ('263',concat('test',id),'');
insert into t_user_info (id,name,password) values ('264',concat('test',id),'');
insert into t_user_info (id,name,password) values ('265',concat('test',id),'');
insert into t_user_info (id,name,password) values ('266',concat('test',id),'');
insert into t_user_info (id,name,password) values ('267',concat('test',id),'');
insert into t_user_info (id,name,password) values ('268',concat('test',id),'');
insert into t_user_info (id,name,password) values ('269',concat('test',id),'');
insert into t_user_info (id,name,password) values ('270',concat('test',id),'');
insert into t_user_info (id,name,password) values ('271',concat('test',id),'');
insert into t_user_info (id,name,password) values ('272',concat('test',id),'');
insert into t_user_info (id,name,password) values ('273',concat('test',id),'');
insert into t_user_info (id,name,password) values ('274',concat('test',id),'');
insert into t_user_info (id,name,password) values ('275',concat('test',id),'');
insert into t_user_info (id,name,password) values ('276',concat('test',id),'');
insert into t_user_info (id,name,password) values ('277',concat('test',id),'');
insert into t_user_info (id,name,password) values ('278',concat('test',id),'');
insert into t_user_info (id,name,password) values ('279',concat('test',id),'');
insert into t_user_info (id,name,password) values ('280',concat('test',id),'');
insert into t_user_info (id,name,password) values ('281',concat('test',id),'');
insert into t_user_info (id,name,password) values ('282',concat('test',id),'');
insert into t_user_info (id,name,password) values ('283',concat('test',id),'');
insert into t_user_info (id,name,password) values ('284',concat('test',id),'');
insert into t_user_info (id,name,password) values ('285',concat('test',id),'');
insert into t_user_info (id,name,password) values ('286',concat('test',id),'');
insert into t_user_info (id,name,password) values ('287',concat('test',id),'');
insert into t_user_info (id,name,password) values ('288',concat('test',id),'');
insert into t_user_info (id,name,password) values ('289',concat('test',id),'');
insert into t_user_info (id,name,password) values ('290',concat('test',id),'');
insert into t_user_info (id,name,password) values ('291',concat('test',id),'');
insert into t_user_info (id,name,password) values ('292',concat('test',id),'');
insert into t_user_info (id,name,password) values ('293',concat('test',id),'');
insert into t_user_info (id,name,password) values ('294',concat('test',id),'');
insert into t_user_info (id,name,password) values ('295',concat('test',id),'');
insert into t_user_info (id,name,password) values ('296',concat('test',id),'');
insert into t_user_info (id,name,password) values ('297',concat('test',id),'');
insert into t_user_info (id,name,password) values ('298',concat('test',id),'');
insert into t_user_info (id,name,password) values ('299',concat('test',id),'');
insert into t_user_info (id,name,password) values ('300',concat('test',id),'');
insert into t_user_info (id,name,password) values ('301',concat('test',id),'');
insert into t_user_info (id,name,password) values ('302',concat('test',id),'');
insert into t_user_info (id,name,password) values ('303',concat('test',id),'');
insert into t_user_info (id,name,password) values ('304',concat('test',id),'');
insert into t_user_info (id,name,password) values ('305',concat('test',id),'');
insert into t_user_info (id,name,password) values ('306',concat('test',id),'');
insert into t_user_info (id,name,password) values ('307',concat('test',id),'');
insert into t_user_info (id,name,password) values ('308',concat('test',id),'');
insert into t_user_info (id,name,password) values ('309',concat('test',id),'');
insert into t_user_info (id,name,password) values ('310',concat('test',id),'');
insert into t_user_info (id,name,password) values ('311',concat('test',id),'');
insert into t_user_info (id,name,password) values ('312',concat('test',id),'');
insert into t_user_info (id,name,password) values ('313',concat('test',id),'');
insert into t_user_info (id,name,password) values ('314',concat('test',id),'');
insert into t_user_info (id,name,password) values ('315',concat('test',id),'');
insert into t_user_info (id,name,password) values ('316',concat('test',id),'');
insert into t_user_info (id,name,password) values ('317',concat('test',id),'');
insert into t_user_info (id,name,password) values ('318',concat('test',id),'');
insert into t_user_info (id,name,password) values ('319',concat('test',id),'');
insert into t_user_info (id,name,password) values ('320',concat('test',id),'');
insert into t_user_info (id,name,password) values ('321',concat('test',id),'');
insert into t_user_info (id,name,password) values ('322',concat('test',id),'');
insert into t_user_info (id,name,password) values ('323',concat('test',id),'');
insert into t_user_info (id,name,password) values ('324',concat('test',id),'');
insert into t_user_info (id,name,password) values ('325',concat('test',id),'');
insert into t_user_info (id,name,password) values ('326',concat('test',id),'');
insert into t_user_info (id,name,password) values ('327',concat('test',id),'');
insert into t_user_info (id,name,password) values ('328',concat('test',id),'');
insert into t_user_info (id,name,password) values ('329',concat('test',id),'');
insert into t_user_info (id,name,password) values ('330',concat('test',id),'');
insert into t_user_info (id,name,password) values ('331',concat('test',id),'');
insert into t_user_info (id,name,password) values ('332',concat('test',id),'');
insert into t_user_info (id,name,password) values ('333',concat('test',id),'');
insert into t_user_info (id,name,password) values ('334',concat('test',id),'');
insert into t_user_info (id,name,password) values ('335',concat('test',id),'');
insert into t_user_info (id,name,password) values ('336',concat('test',id),'');
insert into t_user_info (id,name,password) values ('337',concat('test',id),'');
insert into t_user_info (id,name,password) values ('338',concat('test',id),'');
insert into t_user_info (id,name,password) values ('339',concat('test',id),'');
insert into t_user_info (id,name,password) values ('340',concat('test',id),'');
insert into t_user_info (id,name,password) values ('341',concat('test',id),'');
insert into t_user_info (id,name,password) values ('342',concat('test',id),'');
insert into t_user_info (id,name,password) values ('343',concat('test',id),'');
insert into t_user_info (id,name,password) values ('344',concat('test',id),'');
insert into t_user_info (id,name,password) values ('345',concat('test',id),'');
insert into t_user_info (id,name,password) values ('346',concat('test',id),'');
insert into t_user_info (id,name,password) values ('347',concat('test',id),'');
insert into t_user_info (id,name,password) values ('348',concat('test',id),'');
insert into t_user_info (id,name,password) values ('349',concat('test',id),'');
insert into t_user_info (id,name,password) values ('350',concat('test',id),'');
insert into t_user_info (id,name,password) values ('351',concat('test',id),'');
insert into t_user_info (id,name,password) values ('352',concat('test',id),'');
insert into t_user_info (id,name,password) values ('353',concat('test',id),'');
insert into t_user_info (id,name,password) values ('354',concat('test',id),'');
insert into t_user_info (id,name,password) values ('355',concat('test',id),'');
insert into t_user_info (id,name,password) values ('356',concat('test',id),'');
insert into t_user_info (id,name,password) values ('357',concat('test',id),'');
insert into t_user_info (id,name,password) values ('358',concat('test',id),'');
insert into t_user_info (id,name,password) values ('359',concat('test',id),'');
insert into t_user_info (id,name,password) values ('360',concat('test',id),'');
insert into t_user_info (id,name,password) values ('361',concat('test',id),'');
insert into t_user_info (id,name,password) values ('362',concat('test',id),'');
insert into t_user_info (id,name,password) values ('363',concat('test',id),'');
insert into t_user_info (id,name,password) values ('364',concat('test',id),'');
insert into t_user_info (id,name,password) values ('365',concat('test',id),'');
insert into t_user_info (id,name,password) values ('366',concat('test',id),'');
insert into t_user_info (id,name,password) values ('367',concat('test',id),'');
insert into t_user_info (id,name,password) values ('368',concat('test',id),'');
insert into t_user_info (id,name,password) values ('369',concat('test',id),'');
insert into t_user_info (id,name,password) values ('370',concat('test',id),'');
insert into t_user_info (id,name,password) values ('371',concat('test',id),'');
insert into t_user_info (id,name,password) values ('372',concat('test',id),'');
insert into t_user_info (id,name,password) values ('373',concat('test',id),'');
insert into t_user_info (id,name,password) values ('374',concat('test',id),'');
insert into t_user_info (id,name,password) values ('375',concat('test',id),'');
insert into t_user_info (id,name,password) values ('376',concat('test',id),'');
insert into t_user_info (id,name,password) values ('377',concat('test',id),'');
insert into t_user_info (id,name,password) values ('378',concat('test',id),'');
insert into t_user_info (id,name,password) values ('379',concat('test',id),'');
insert into t_user_info (id,name,password) values ('380',concat('test',id),'');
insert into t_user_info (id,name,password) values ('381',concat('test',id),'');
insert into t_user_info (id,name,password) values ('382',concat('test',id),'');
insert into t_user_info (id,name,password) values ('383',concat('test',id),'');
insert into t_user_info (id,name,password) values ('384',concat('test',id),'');
insert into t_user_info (id,name,password) values ('385',concat('test',id),'');
insert into t_user_info (id,name,password) values ('386',concat('test',id),'');
insert into t_user_info (id,name,password) values ('387',concat('test',id),'');
insert into t_user_info (id,name,password) values ('388',concat('test',id),'');
insert into t_user_info (id,name,password) values ('389',concat('test',id),'');
insert into t_user_info (id,name,password) values ('390',concat('test',id),'');
insert into t_user_info (id,name,password) values ('391',concat('test',id),'');
insert into t_user_info (id,name,password) values ('392',concat('test',id),'');
insert into t_user_info (id,name,password) values ('393',concat('test',id),'');
insert into t_user_info (id,name,password) values ('394',concat('test',id),'');
insert into t_user_info (id,name,password) values ('395',concat('test',id),'');
insert into t_user_info (id,name,password) values ('396',concat('test',id),'');
insert into t_user_info (id,name,password) values ('397',concat('test',id),'');
insert into t_user_info (id,name,password) values ('398',concat('test',id),'');
insert into t_user_info (id,name,password) values ('399',concat('test',id),'');
insert into t_user_info (id,name,password) values ('400',concat('test',id),'');
insert into t_user_info (id,name,password) values ('401',concat('test',id),'');
insert into t_user_info (id,name,password) values ('402',concat('test',id),'');
insert into t_user_info (id,name,password) values ('403',concat('test',id),'');
insert into t_user_info (id,name,password) values ('404',concat('test',id),'');
insert into t_user_info (id,name,password) values ('405',concat('test',id),'');
insert into t_user_info (id,name,password) values ('406',concat('test',id),'');
insert into t_user_info (id,name,password) values ('407',concat('test',id),'');
insert into t_user_info (id,name,password) values ('408',concat('test',id),'');
insert into t_user_info (id,name,password) values ('409',concat('test',id),'');
insert into t_user_info (id,name,password) values ('410',concat('test',id),'');
insert into t_user_info (id,name,password) values ('411',concat('test',id),'');
insert into t_user_info (id,name,password) values ('412',concat('test',id),'');
insert into t_user_info (id,name,password) values ('413',concat('test',id),'');
insert into t_user_info (id,name,password) values ('414',concat('test',id),'');
insert into t_user_info (id,name,password) values ('415',concat('test',id),'');
insert into t_user_info (id,name,password) values ('416',concat('test',id),'');
insert into t_user_info (id,name,password) values ('417',concat('test',id),'');
insert into t_user_info (id,name,password) values ('418',concat('test',id),'');
insert into t_user_info (id,name,password) values ('419',concat('test',id),'');
insert into t_user_info (id,name,password) values ('420',concat('test',id),'');
insert into t_user_info (id,name,password) values ('421',concat('test',id),'');
insert into t_user_info (id,name,password) values ('422',concat('test',id),'');
insert into t_user_info (id,name,password) values ('423',concat('test',id),'');
insert into t_user_info (id,name,password) values ('424',concat('test',id),'');
insert into t_user_info (id,name,password) values ('425',concat('test',id),'');
insert into t_user_info (id,name,password) values ('426',concat('test',id),'');
insert into t_user_info (id,name,password) values ('427',concat('test',id),'');
insert into t_user_info (id,name,password) values ('428',concat('test',id),'');
insert into t_user_info (id,name,password) values ('429',concat('test',id),'');
insert into t_user_info (id,name,password) values ('430',concat('test',id),'');
insert into t_user_info (id,name,password) values ('431',concat('test',id),'');
insert into t_user_info (id,name,password) values ('432',concat('test',id),'');
insert into t_user_info (id,name,password) values ('433',concat('test',id),'');
insert into t_user_info (id,name,password) values ('434',concat('test',id),'');
insert into t_user_info (id,name,password) values ('435',concat('test',id),'');
insert into t_user_info (id,name,password) values ('436',concat('test',id),'');
insert into t_user_info (id,name,password) values ('437',concat('test',id),'');
insert into t_user_info (id,name,password) values ('438',concat('test',id),'');
insert into t_user_info (id,name,password) values ('439',concat('test',id),'');
insert into t_user_info (id,name,password) values ('440',concat('test',id),'');
insert into t_user_info (id,name,password) values ('441',concat('test',id),'');
insert into t_user_info (id,name,password) values ('442',concat('test',id),'');
insert into t_user_info (id,name,password) values ('443',concat('test',id),'');
insert into t_user_info (id,name,password) values ('444',concat('test',id),'');
insert into t_user_info (id,name,password) values ('445',concat('test',id),'');
insert into t_user_info (id,name,password) values ('446',concat('test',id),'');
insert into t_user_info (id,name,password) values ('447',concat('test',id),'');
insert into t_user_info (id,name,password) values ('448',concat('test',id),'');
insert into t_user_info (id,name,password) values ('449',concat('test',id),'');
insert into t_user_info (id,name,password) values ('450',concat('test',id),'');
insert into t_user_info (id,name,password) values ('451',concat('test',id),'');
insert into t_user_info (id,name,password) values ('452',concat('test',id),'');
insert into t_user_info (id,name,password) values ('453',concat('test',id),'');
insert into t_user_info (id,name,password) values ('454',concat('test',id),'');
insert into t_user_info (id,name,password) values ('455',concat('test',id),'');
insert into t_user_info (id,name,password) values ('456',concat('test',id),'');
insert into t_user_info (id,name,password) values ('457',concat('test',id),'');
insert into t_user_info (id,name,password) values ('458',concat('test',id),'');
insert into t_user_info (id,name,password) values ('459',concat('test',id),'');
insert into t_user_info (id,name,password) values ('460',concat('test',id),'');
insert into t_user_info (id,name,password) values ('461',concat('test',id),'');
insert into t_user_info (id,name,password) values ('462',concat('test',id),'');
insert into t_user_info (id,name,password) values ('463',concat('test',id),'');
insert into t_user_info (id,name,password) values ('464',concat('test',id),'');
insert into t_user_info (id,name,password) values ('465',concat('test',id),'');
insert into t_user_info (id,name,password) values ('466',concat('test',id),'');
insert into t_user_info (id,name,password) values ('467',concat('test',id),'');
insert into t_user_info (id,name,password) values ('468',concat('test',id),'');
insert into t_user_info (id,name,password) values ('469',concat('test',id),'');
insert into t_user_info (id,name,password) values ('470',concat('test',id),'');
insert into t_user_info (id,name,password) values ('471',concat('test',id),'');
insert into t_user_info (id,name,password) values ('472',concat('test',id),'');
insert into t_user_info (id,name,password) values ('473',concat('test',id),'');
insert into t_user_info (id,name,password) values ('474',concat('test',id),'');
insert into t_user_info (id,name,password) values ('475',concat('test',id),'');
insert into t_user_info (id,name,password) values ('476',concat('test',id),'');
insert into t_user_info (id,name,password) values ('477',concat('test',id),'');
insert into t_user_info (id,name,password) values ('478',concat('test',id),'');
insert into t_user_info (id,name,password) values ('479',concat('test',id),'');
insert into t_user_info (id,name,password) values ('480',concat('test',id),'');
insert into t_user_info (id,name,password) values ('481',concat('test',id),'');
insert into t_user_info (id,name,password) values ('482',concat('test',id),'');
insert into t_user_info (id,name,password) values ('483',concat('test',id),'');
insert into t_user_info (id,name,password) values ('484',concat('test',id),'');
insert into t_user_info (id,name,password) values ('485',concat('test',id),'');
insert into t_user_info (id,name,password) values ('486',concat('test',id),'');
insert into t_user_info (id,name,password) values ('487',concat('test',id),'');
insert into t_user_info (id,name,password) values ('488',concat('test',id),'');
insert into t_user_info (id,name,password) values ('489',concat('test',id),'');
insert into t_user_info (id,name,password) values ('490',concat('test',id),'');
insert into t_user_info (id,name,password) values ('491',concat('test',id),'');
insert into t_user_info (id,name,password) values ('492',concat('test',id),'');
insert into t_user_info (id,name,password) values ('493',concat('test',id),'');
insert into t_user_info (id,name,password) values ('494',concat('test',id),'');
insert into t_user_info (id,name,password) values ('495',concat('test',id),'');
insert into t_user_info (id,name,password) values ('496',concat('test',id),'');
insert into t_user_info (id,name,password) values ('497',concat('test',id),'');
insert into t_user_info (id,name,password) values ('498',concat('test',id),'');
insert into t_user_info (id,name,password) values ('499',concat('test',id),'');
insert into t_user_info (id,name,password) values ('500',concat('test',id),'');
insert into t_user_info (id,name,password) values ('501',concat('test',id),'');
insert into t_user_info (id,name,password) values ('502',concat('test',id),'');
insert into t_user_info (id,name,password) values ('503',concat('test',id),'');
insert into t_user_info (id,name,password) values ('504',concat('test',id),'');
insert into t_user_info (id,name,password) values ('505',concat('test',id),'');
insert into t_user_info (id,name,password) values ('506',concat('test',id),'');
insert into t_user_info (id,name,password) values ('507',concat('test',id),'');
insert into t_user_info (id,name,password) values ('508',concat('test',id),'');
insert into t_user_info (id,name,password) values ('509',concat('test',id),'');
insert into t_user_info (id,name,password) values ('510',concat('test',id),'');
insert into t_user_info (id,name,password) values ('511',concat('test',id),'');
insert into t_user_info (id,name,password) values ('512',concat('test',id),'');
insert into t_user_info (id,name,password) values ('513',concat('test',id),'');
insert into t_user_info (id,name,password) values ('514',concat('test',id),'');
insert into t_user_info (id,name,password) values ('515',concat('test',id),'');
insert into t_user_info (id,name,password) values ('516',concat('test',id),'');
insert into t_user_info (id,name,password) values ('517',concat('test',id),'');
insert into t_user_info (id,name,password) values ('518',concat('test',id),'');
insert into t_user_info (id,name,password) values ('519',concat('test',id),'');
insert into t_user_info (id,name,password) values ('520',concat('test',id),'');
insert into t_user_info (id,name,password) values ('521',concat('test',id),'');
insert into t_user_info (id,name,password) values ('522',concat('test',id),'');
insert into t_user_info (id,name,password) values ('523',concat('test',id),'');
insert into t_user_info (id,name,password) values ('524',concat('test',id),'');
insert into t_user_info (id,name,password) values ('525',concat('test',id),'');
insert into t_user_info (id,name,password) values ('526',concat('test',id),'');
insert into t_user_info (id,name,password) values ('527',concat('test',id),'');
insert into t_user_info (id,name,password) values ('528',concat('test',id),'');
insert into t_user_info (id,name,password) values ('529',concat('test',id),'');
insert into t_user_info (id,name,password) values ('530',concat('test',id),'');
insert into t_user_info (id,name,password) values ('531',concat('test',id),'');
insert into t_user_info (id,name,password) values ('532',concat('test',id),'');
insert into t_user_info (id,name,password) values ('533',concat('test',id),'');
insert into t_user_info (id,name,password) values ('534',concat('test',id),'');
insert into t_user_info (id,name,password) values ('535',concat('test',id),'');
insert into t_user_info (id,name,password) values ('536',concat('test',id),'');
insert into t_user_info (id,name,password) values ('537',concat('test',id),'');
insert into t_user_info (id,name,password) values ('538',concat('test',id),'');
insert into t_user_info (id,name,password) values ('539',concat('test',id),'');
insert into t_user_info (id,name,password) values ('540',concat('test',id),'');
insert into t_user_info (id,name,password) values ('541',concat('test',id),'');
insert into t_user_info (id,name,password) values ('542',concat('test',id),'');
insert into t_user_info (id,name,password) values ('543',concat('test',id),'');
insert into t_user_info (id,name,password) values ('544',concat('test',id),'');
insert into t_user_info (id,name,password) values ('545',concat('test',id),'');
insert into t_user_info (id,name,password) values ('546',concat('test',id),'');
insert into t_user_info (id,name,password) values ('547',concat('test',id),'');
insert into t_user_info (id,name,password) values ('548',concat('test',id),'');
insert into t_user_info (id,name,password) values ('549',concat('test',id),'');
insert into t_user_info (id,name,password) values ('550',concat('test',id),'');
insert into t_user_info (id,name,password) values ('551',concat('test',id),'');
insert into t_user_info (id,name,password) values ('552',concat('test',id),'');
insert into t_user_info (id,name,password) values ('553',concat('test',id),'');
insert into t_user_info (id,name,password) values ('554',concat('test',id),'');
insert into t_user_info (id,name,password) values ('555',concat('test',id),'');
insert into t_user_info (id,name,password) values ('556',concat('test',id),'');
insert into t_user_info (id,name,password) values ('557',concat('test',id),'');
insert into t_user_info (id,name,password) values ('558',concat('test',id),'');
insert into t_user_info (id,name,password) values ('559',concat('test',id),'');
insert into t_user_info (id,name,password) values ('560',concat('test',id),'');
insert into t_user_info (id,name,password) values ('561',concat('test',id),'');
insert into t_user_info (id,name,password) values ('562',concat('test',id),'');
insert into t_user_info (id,name,password) values ('563',concat('test',id),'');
insert into t_user_info (id,name,password) values ('564',concat('test',id),'');
insert into t_user_info (id,name,password) values ('565',concat('test',id),'');
insert into t_user_info (id,name,password) values ('566',concat('test',id),'');
insert into t_user_info (id,name,password) values ('567',concat('test',id),'');
insert into t_user_info (id,name,password) values ('568',concat('test',id),'');
insert into t_user_info (id,name,password) values ('569',concat('test',id),'');
insert into t_user_info (id,name,password) values ('570',concat('test',id),'');
insert into t_user_info (id,name,password) values ('571',concat('test',id),'');
insert into t_user_info (id,name,password) values ('572',concat('test',id),'');
insert into t_user_info (id,name,password) values ('573',concat('test',id),'');
insert into t_user_info (id,name,password) values ('574',concat('test',id),'');
insert into t_user_info (id,name,password) values ('575',concat('test',id),'');
insert into t_user_info (id,name,password) values ('576',concat('test',id),'');
insert into t_user_info (id,name,password) values ('577',concat('test',id),'');
insert into t_user_info (id,name,password) values ('578',concat('test',id),'');
insert into t_user_info (id,name,password) values ('579',concat('test',id),'');
insert into t_user_info (id,name,password) values ('580',concat('test',id),'');
insert into t_user_info (id,name,password) values ('581',concat('test',id),'');
insert into t_user_info (id,name,password) values ('582',concat('test',id),'');
insert into t_user_info (id,name,password) values ('583',concat('test',id),'');
insert into t_user_info (id,name,password) values ('584',concat('test',id),'');
insert into t_user_info (id,name,password) values ('585',concat('test',id),'');
insert into t_user_info (id,name,password) values ('586',concat('test',id),'');
insert into t_user_info (id,name,password) values ('587',concat('test',id),'');
insert into t_user_info (id,name,password) values ('588',concat('test',id),'');
insert into t_user_info (id,name,password) values ('589',concat('test',id),'');
insert into t_user_info (id,name,password) values ('590',concat('test',id),'');
insert into t_user_info (id,name,password) values ('591',concat('test',id),'');
insert into t_user_info (id,name,password) values ('592',concat('test',id),'');
insert into t_user_info (id,name,password) values ('593',concat('test',id),'');
insert into t_user_info (id,name,password) values ('594',concat('test',id),'');
insert into t_user_info (id,name,password) values ('595',concat('test',id),'');
insert into t_user_info (id,name,password) values ('596',concat('test',id),'');
insert into t_user_info (id,name,password) values ('597',concat('test',id),'');
insert into t_user_info (id,name,password) values ('598',concat('test',id),'');
insert into t_user_info (id,name,password) values ('599',concat('test',id),'');
insert into t_user_info (id,name,password) values ('600',concat('test',id),'');
insert into t_user_info (id,name,password) values ('601',concat('test',id),'');
insert into t_user_info (id,name,password) values ('602',concat('test',id),'');
insert into t_user_info (id,name,password) values ('603',concat('test',id),'');
insert into t_user_info (id,name,password) values ('604',concat('test',id),'');
insert into t_user_info (id,name,password) values ('605',concat('test',id),'');
insert into t_user_info (id,name,password) values ('606',concat('test',id),'');
insert into t_user_info (id,name,password) values ('607',concat('test',id),'');
insert into t_user_info (id,name,password) values ('608',concat('test',id),'');
insert into t_user_info (id,name,password) values ('609',concat('test',id),'');
insert into t_user_info (id,name,password) values ('610',concat('test',id),'');
insert into t_user_info (id,name,password) values ('611',concat('test',id),'');
insert into t_user_info (id,name,password) values ('612',concat('test',id),'');
insert into t_user_info (id,name,password) values ('613',concat('test',id),'');
insert into t_user_info (id,name,password) values ('614',concat('test',id),'');
insert into t_user_info (id,name,password) values ('615',concat('test',id),'');
insert into t_user_info (id,name,password) values ('616',concat('test',id),'');
insert into t_user_info (id,name,password) values ('617',concat('test',id),'');
insert into t_user_info (id,name,password) values ('618',concat('test',id),'');
insert into t_user_info (id,name,password) values ('619',concat('test',id),'');
insert into t_user_info (id,name,password) values ('620',concat('test',id),'');
insert into t_user_info (id,name,password) values ('621',concat('test',id),'');
insert into t_user_info (id,name,password) values ('622',concat('test',id),'');
insert into t_user_info (id,name,password) values ('623',concat('test',id),'');
insert into t_user_info (id,name,password) values ('624',concat('test',id),'');
insert into t_user_info (id,name,password) values ('625',concat('test',id),'');
insert into t_user_info (id,name,password) values ('626',concat('test',id),'');
insert into t_user_info (id,name,password) values ('627',concat('test',id),'');
insert into t_user_info (id,name,password) values ('628',concat('test',id),'');
insert into t_user_info (id,name,password) values ('629',concat('test',id),'');
insert into t_user_info (id,name,password) values ('630',concat('test',id),'');
insert into t_user_info (id,name,password) values ('631',concat('test',id),'');
insert into t_user_info (id,name,password) values ('632',concat('test',id),'');
insert into t_user_info (id,name,password) values ('633',concat('test',id),'');
insert into t_user_info (id,name,password) values ('634',concat('test',id),'');
insert into t_user_info (id,name,password) values ('635',concat('test',id),'');
insert into t_user_info (id,name,password) values ('636',concat('test',id),'');
insert into t_user_info (id,name,password) values ('637',concat('test',id),'');
insert into t_user_info (id,name,password) values ('638',concat('test',id),'');
insert into t_user_info (id,name,password) values ('639',concat('test',id),'');
insert into t_user_info (id,name,password) values ('640',concat('test',id),'');
insert into t_user_info (id,name,password) values ('641',concat('test',id),'');
insert into t_user_info (id,name,password) values ('642',concat('test',id),'');
insert into t_user_info (id,name,password) values ('643',concat('test',id),'');
insert into t_user_info (id,name,password) values ('644',concat('test',id),'');
insert into t_user_info (id,name,password) values ('645',concat('test',id),'');
insert into t_user_info (id,name,password) values ('646',concat('test',id),'');
insert into t_user_info (id,name,password) values ('647',concat('test',id),'');
insert into t_user_info (id,name,password) values ('648',concat('test',id),'');
insert into t_user_info (id,name,password) values ('649',concat('test',id),'');
insert into t_user_info (id,name,password) values ('650',concat('test',id),'');
insert into t_user_info (id,name,password) values ('651',concat('test',id),'');
insert into t_user_info (id,name,password) values ('652',concat('test',id),'');
insert into t_user_info (id,name,password) values ('653',concat('test',id),'');
insert into t_user_info (id,name,password) values ('654',concat('test',id),'');
insert into t_user_info (id,name,password) values ('655',concat('test',id),'');
insert into t_user_info (id,name,password) values ('656',concat('test',id),'');
insert into t_user_info (id,name,password) values ('657',concat('test',id),'');
insert into t_user_info (id,name,password) values ('658',concat('test',id),'');
insert into t_user_info (id,name,password) values ('659',concat('test',id),'');
insert into t_user_info (id,name,password) values ('660',concat('test',id),'');
insert into t_user_info (id,name,password) values ('661',concat('test',id),'');
insert into t_user_info (id,name,password) values ('662',concat('test',id),'');
insert into t_user_info (id,name,password) values ('663',concat('test',id),'');
insert into t_user_info (id,name,password) values ('664',concat('test',id),'');
insert into t_user_info (id,name,password) values ('665',concat('test',id),'');
insert into t_user_info (id,name,password) values ('666',concat('test',id),'');
insert into t_user_info (id,name,password) values ('667',concat('test',id),'');
insert into t_user_info (id,name,password) values ('668',concat('test',id),'');
insert into t_user_info (id,name,password) values ('669',concat('test',id),'');
insert into t_user_info (id,name,password) values ('670',concat('test',id),'');
insert into t_user_info (id,name,password) values ('671',concat('test',id),'');
insert into t_user_info (id,name,password) values ('672',concat('test',id),'');
insert into t_user_info (id,name,password) values ('673',concat('test',id),'');
insert into t_user_info (id,name,password) values ('674',concat('test',id),'');
insert into t_user_info (id,name,password) values ('675',concat('test',id),'');
insert into t_user_info (id,name,password) values ('676',concat('test',id),'');
insert into t_user_info (id,name,password) values ('677',concat('test',id),'');
insert into t_user_info (id,name,password) values ('678',concat('test',id),'');
insert into t_user_info (id,name,password) values ('679',concat('test',id),'');
insert into t_user_info (id,name,password) values ('680',concat('test',id),'');
insert into t_user_info (id,name,password) values ('681',concat('test',id),'');
insert into t_user_info (id,name,password) values ('682',concat('test',id),'');
insert into t_user_info (id,name,password) values ('683',concat('test',id),'');
insert into t_user_info (id,name,password) values ('684',concat('test',id),'');
insert into t_user_info (id,name,password) values ('685',concat('test',id),'');
insert into t_user_info (id,name,password) values ('686',concat('test',id),'');
insert into t_user_info (id,name,password) values ('687',concat('test',id),'');
insert into t_user_info (id,name,password) values ('688',concat('test',id),'');
insert into t_user_info (id,name,password) values ('689',concat('test',id),'');
insert into t_user_info (id,name,password) values ('690',concat('test',id),'');
insert into t_user_info (id,name,password) values ('691',concat('test',id),'');
insert into t_user_info (id,name,password) values ('692',concat('test',id),'');
insert into t_user_info (id,name,password) values ('693',concat('test',id),'');
insert into t_user_info (id,name,password) values ('694',concat('test',id),'');
insert into t_user_info (id,name,password) values ('695',concat('test',id),'');
insert into t_user_info (id,name,password) values ('696',concat('test',id),'');
insert into t_user_info (id,name,password) values ('697',concat('test',id),'');
insert into t_user_info (id,name,password) values ('698',concat('test',id),'');
insert into t_user_info (id,name,password) values ('699',concat('test',id),'');
insert into t_user_info (id,name,password) values ('700',concat('test',id),'');
insert into t_user_info (id,name,password) values ('701',concat('test',id),'');
insert into t_user_info (id,name,password) values ('702',concat('test',id),'');
insert into t_user_info (id,name,password) values ('703',concat('test',id),'');
insert into t_user_info (id,name,password) values ('704',concat('test',id),'');
insert into t_user_info (id,name,password) values ('705',concat('test',id),'');
insert into t_user_info (id,name,password) values ('706',concat('test',id),'');
insert into t_user_info (id,name,password) values ('707',concat('test',id),'');
insert into t_user_info (id,name,password) values ('708',concat('test',id),'');
insert into t_user_info (id,name,password) values ('709',concat('test',id),'');
insert into t_user_info (id,name,password) values ('710',concat('test',id),'');
insert into t_user_info (id,name,password) values ('711',concat('test',id),'');
insert into t_user_info (id,name,password) values ('712',concat('test',id),'');
insert into t_user_info (id,name,password) values ('713',concat('test',id),'');
insert into t_user_info (id,name,password) values ('714',concat('test',id),'');
insert into t_user_info (id,name,password) values ('715',concat('test',id),'');
insert into t_user_info (id,name,password) values ('716',concat('test',id),'');
insert into t_user_info (id,name,password) values ('717',concat('test',id),'');
insert into t_user_info (id,name,password) values ('718',concat('test',id),'');
insert into t_user_info (id,name,password) values ('719',concat('test',id),'');
insert into t_user_info (id,name,password) values ('720',concat('test',id),'');
insert into t_user_info (id,name,password) values ('721',concat('test',id),'');
insert into t_user_info (id,name,password) values ('722',concat('test',id),'');
insert into t_user_info (id,name,password) values ('723',concat('test',id),'');
insert into t_user_info (id,name,password) values ('724',concat('test',id),'');
insert into t_user_info (id,name,password) values ('725',concat('test',id),'');
insert into t_user_info (id,name,password) values ('726',concat('test',id),'');
insert into t_user_info (id,name,password) values ('727',concat('test',id),'');
insert into t_user_info (id,name,password) values ('728',concat('test',id),'');
insert into t_user_info (id,name,password) values ('729',concat('test',id),'');
insert into t_user_info (id,name,password) values ('730',concat('test',id),'');
insert into t_user_info (id,name,password) values ('731',concat('test',id),'');
insert into t_user_info (id,name,password) values ('732',concat('test',id),'');
insert into t_user_info (id,name,password) values ('733',concat('test',id),'');
insert into t_user_info (id,name,password) values ('734',concat('test',id),'');
insert into t_user_info (id,name,password) values ('735',concat('test',id),'');
insert into t_user_info (id,name,password) values ('736',concat('test',id),'');
insert into t_user_info (id,name,password) values ('737',concat('test',id),'');
insert into t_user_info (id,name,password) values ('738',concat('test',id),'');
insert into t_user_info (id,name,password) values ('739',concat('test',id),'');
insert into t_user_info (id,name,password) values ('740',concat('test',id),'');
insert into t_user_info (id,name,password) values ('741',concat('test',id),'');
insert into t_user_info (id,name,password) values ('742',concat('test',id),'');
insert into t_user_info (id,name,password) values ('743',concat('test',id),'');
insert into t_user_info (id,name,password) values ('744',concat('test',id),'');
insert into t_user_info (id,name,password) values ('745',concat('test',id),'');
insert into t_user_info (id,name,password) values ('746',concat('test',id),'');
insert into t_user_info (id,name,password) values ('747',concat('test',id),'');
insert into t_user_info (id,name,password) values ('748',concat('test',id),'');
insert into t_user_info (id,name,password) values ('749',concat('test',id),'');
insert into t_user_info (id,name,password) values ('750',concat('test',id),'');
insert into t_user_info (id,name,password) values ('751',concat('test',id),'');
insert into t_user_info (id,name,password) values ('752',concat('test',id),'');
insert into t_user_info (id,name,password) values ('753',concat('test',id),'');
insert into t_user_info (id,name,password) values ('754',concat('test',id),'');
insert into t_user_info (id,name,password) values ('755',concat('test',id),'');
insert into t_user_info (id,name,password) values ('756',concat('test',id),'');
insert into t_user_info (id,name,password) values ('757',concat('test',id),'');
insert into t_user_info (id,name,password) values ('758',concat('test',id),'');
insert into t_user_info (id,name,password) values ('759',concat('test',id),'');
insert into t_user_info (id,name,password) values ('760',concat('test',id),'');
insert into t_user_info (id,name,password) values ('761',concat('test',id),'');
insert into t_user_info (id,name,password) values ('762',concat('test',id),'');
insert into t_user_info (id,name,password) values ('763',concat('test',id),'');
insert into t_user_info (id,name,password) values ('764',concat('test',id),'');
insert into t_user_info (id,name,password) values ('765',concat('test',id),'');
insert into t_user_info (id,name,password) values ('766',concat('test',id),'');
insert into t_user_info (id,name,password) values ('767',concat('test',id),'');
insert into t_user_info (id,name,password) values ('768',concat('test',id),'');
insert into t_user_info (id,name,password) values ('769',concat('test',id),'');
insert into t_user_info (id,name,password) values ('770',concat('test',id),'');
insert into t_user_info (id,name,password) values ('771',concat('test',id),'');
insert into t_user_info (id,name,password) values ('772',concat('test',id),'');
insert into t_user_info (id,name,password) values ('773',concat('test',id),'');
insert into t_user_info (id,name,password) values ('774',concat('test',id),'');
insert into t_user_info (id,name,password) values ('775',concat('test',id),'');
insert into t_user_info (id,name,password) values ('776',concat('test',id),'');
insert into t_user_info (id,name,password) values ('777',concat('test',id),'');
insert into t_user_info (id,name,password) values ('778',concat('test',id),'');
insert into t_user_info (id,name,password) values ('779',concat('test',id),'');
insert into t_user_info (id,name,password) values ('780',concat('test',id),'');
insert into t_user_info (id,name,password) values ('781',concat('test',id),'');
insert into t_user_info (id,name,password) values ('782',concat('test',id),'');
insert into t_user_info (id,name,password) values ('783',concat('test',id),'');
insert into t_user_info (id,name,password) values ('784',concat('test',id),'');
insert into t_user_info (id,name,password) values ('785',concat('test',id),'');
insert into t_user_info (id,name,password) values ('786',concat('test',id),'');
insert into t_user_info (id,name,password) values ('787',concat('test',id),'');
insert into t_user_info (id,name,password) values ('788',concat('test',id),'');
insert into t_user_info (id,name,password) values ('789',concat('test',id),'');
insert into t_user_info (id,name,password) values ('790',concat('test',id),'');
insert into t_user_info (id,name,password) values ('791',concat('test',id),'');
insert into t_user_info (id,name,password) values ('792',concat('test',id),'');
insert into t_user_info (id,name,password) values ('793',concat('test',id),'');
insert into t_user_info (id,name,password) values ('794',concat('test',id),'');
insert into t_user_info (id,name,password) values ('795',concat('test',id),'');
insert into t_user_info (id,name,password) values ('796',concat('test',id),'');
insert into t_user_info (id,name,password) values ('797',concat('test',id),'');
insert into t_user_info (id,name,password) values ('798',concat('test',id),'');
insert into t_user_info (id,name,password) values ('799',concat('test',id),'');
insert into t_user_info (id,name,password) values ('800',concat('test',id),'');
insert into t_user_info (id,name,password) values ('801',concat('test',id),'');
insert into t_user_info (id,name,password) values ('802',concat('test',id),'');
insert into t_user_info (id,name,password) values ('803',concat('test',id),'');
insert into t_user_info (id,name,password) values ('804',concat('test',id),'');
insert into t_user_info (id,name,password) values ('805',concat('test',id),'');
insert into t_user_info (id,name,password) values ('806',concat('test',id),'');
insert into t_user_info (id,name,password) values ('807',concat('test',id),'');
insert into t_user_info (id,name,password) values ('808',concat('test',id),'');
insert into t_user_info (id,name,password) values ('809',concat('test',id),'');
insert into t_user_info (id,name,password) values ('810',concat('test',id),'');
insert into t_user_info (id,name,password) values ('811',concat('test',id),'');
insert into t_user_info (id,name,password) values ('812',concat('test',id),'');
insert into t_user_info (id,name,password) values ('813',concat('test',id),'');
insert into t_user_info (id,name,password) values ('814',concat('test',id),'');
insert into t_user_info (id,name,password) values ('815',concat('test',id),'');
insert into t_user_info (id,name,password) values ('816',concat('test',id),'');
insert into t_user_info (id,name,password) values ('817',concat('test',id),'');
insert into t_user_info (id,name,password) values ('818',concat('test',id),'');
insert into t_user_info (id,name,password) values ('819',concat('test',id),'');
insert into t_user_info (id,name,password) values ('820',concat('test',id),'');
insert into t_user_info (id,name,password) values ('821',concat('test',id),'');
insert into t_user_info (id,name,password) values ('822',concat('test',id),'');
insert into t_user_info (id,name,password) values ('823',concat('test',id),'');
insert into t_user_info (id,name,password) values ('824',concat('test',id),'');
insert into t_user_info (id,name,password) values ('825',concat('test',id),'');
insert into t_user_info (id,name,password) values ('826',concat('test',id),'');
insert into t_user_info (id,name,password) values ('827',concat('test',id),'');
insert into t_user_info (id,name,password) values ('828',concat('test',id),'');
insert into t_user_info (id,name,password) values ('829',concat('test',id),'');
insert into t_user_info (id,name,password) values ('830',concat('test',id),'');
insert into t_user_info (id,name,password) values ('831',concat('test',id),'');
insert into t_user_info (id,name,password) values ('832',concat('test',id),'');
insert into t_user_info (id,name,password) values ('833',concat('test',id),'');
insert into t_user_info (id,name,password) values ('834',concat('test',id),'');
insert into t_user_info (id,name,password) values ('835',concat('test',id),'');
insert into t_user_info (id,name,password) values ('836',concat('test',id),'');
insert into t_user_info (id,name,password) values ('837',concat('test',id),'');
insert into t_user_info (id,name,password) values ('838',concat('test',id),'');
insert into t_user_info (id,name,password) values ('839',concat('test',id),'');
insert into t_user_info (id,name,password) values ('840',concat('test',id),'');
insert into t_user_info (id,name,password) values ('841',concat('test',id),'');
insert into t_user_info (id,name,password) values ('842',concat('test',id),'');
insert into t_user_info (id,name,password) values ('843',concat('test',id),'');
insert into t_user_info (id,name,password) values ('844',concat('test',id),'');
insert into t_user_info (id,name,password) values ('845',concat('test',id),'');
insert into t_user_info (id,name,password) values ('846',concat('test',id),'');
insert into t_user_info (id,name,password) values ('847',concat('test',id),'');
insert into t_user_info (id,name,password) values ('848',concat('test',id),'');
insert into t_user_info (id,name,password) values ('849',concat('test',id),'');
insert into t_user_info (id,name,password) values ('850',concat('test',id),'');
insert into t_user_info (id,name,password) values ('851',concat('test',id),'');
insert into t_user_info (id,name,password) values ('852',concat('test',id),'');
insert into t_user_info (id,name,password) values ('853',concat('test',id),'');
insert into t_user_info (id,name,password) values ('854',concat('test',id),'');
insert into t_user_info (id,name,password) values ('855',concat('test',id),'');
insert into t_user_info (id,name,password) values ('856',concat('test',id),'');
insert into t_user_info (id,name,password) values ('857',concat('test',id),'');
insert into t_user_info (id,name,password) values ('858',concat('test',id),'');
insert into t_user_info (id,name,password) values ('859',concat('test',id),'');
insert into t_user_info (id,name,password) values ('860',concat('test',id),'');
insert into t_user_info (id,name,password) values ('861',concat('test',id),'');
insert into t_user_info (id,name,password) values ('862',concat('test',id),'');
insert into t_user_info (id,name,password) values ('863',concat('test',id),'');
insert into t_user_info (id,name,password) values ('864',concat('test',id),'');
insert into t_user_info (id,name,password) values ('865',concat('test',id),'');
insert into t_user_info (id,name,password) values ('866',concat('test',id),'');
insert into t_user_info (id,name,password) values ('867',concat('test',id),'');
insert into t_user_info (id,name,password) values ('868',concat('test',id),'');
insert into t_user_info (id,name,password) values ('869',concat('test',id),'');
insert into t_user_info (id,name,password) values ('870',concat('test',id),'');
insert into t_user_info (id,name,password) values ('871',concat('test',id),'');
insert into t_user_info (id,name,password) values ('872',concat('test',id),'');
insert into t_user_info (id,name,password) values ('873',concat('test',id),'');
insert into t_user_info (id,name,password) values ('874',concat('test',id),'');
insert into t_user_info (id,name,password) values ('875',concat('test',id),'');
insert into t_user_info (id,name,password) values ('876',concat('test',id),'');
insert into t_user_info (id,name,password) values ('877',concat('test',id),'');
insert into t_user_info (id,name,password) values ('878',concat('test',id),'');
insert into t_user_info (id,name,password) values ('879',concat('test',id),'');
insert into t_user_info (id,name,password) values ('880',concat('test',id),'');
insert into t_user_info (id,name,password) values ('881',concat('test',id),'');
insert into t_user_info (id,name,password) values ('882',concat('test',id),'');
insert into t_user_info (id,name,password) values ('883',concat('test',id),'');
insert into t_user_info (id,name,password) values ('884',concat('test',id),'');
insert into t_user_info (id,name,password) values ('885',concat('test',id),'');
insert into t_user_info (id,name,password) values ('886',concat('test',id),'');
insert into t_user_info (id,name,password) values ('887',concat('test',id),'');
insert into t_user_info (id,name,password) values ('888',concat('test',id),'');
insert into t_user_info (id,name,password) values ('889',concat('test',id),'');
insert into t_user_info (id,name,password) values ('890',concat('test',id),'');
insert into t_user_info (id,name,password) values ('891',concat('test',id),'');
insert into t_user_info (id,name,password) values ('892',concat('test',id),'');
insert into t_user_info (id,name,password) values ('893',concat('test',id),'');
insert into t_user_info (id,name,password) values ('894',concat('test',id),'');
insert into t_user_info (id,name,password) values ('895',concat('test',id),'');
insert into t_user_info (id,name,password) values ('896',concat('test',id),'');
insert into t_user_info (id,name,password) values ('897',concat('test',id),'');
insert into t_user_info (id,name,password) values ('898',concat('test',id),'');
insert into t_user_info (id,name,password) values ('899',concat('test',id),'');
insert into t_user_info (id,name,password) values ('900',concat('test',id),'');
insert into t_user_info (id,name,password) values ('901',concat('test',id),'');
insert into t_user_info (id,name,password) values ('902',concat('test',id),'');
insert into t_user_info (id,name,password) values ('903',concat('test',id),'');
insert into t_user_info (id,name,password) values ('904',concat('test',id),'');
insert into t_user_info (id,name,password) values ('905',concat('test',id),'');
insert into t_user_info (id,name,password) values ('906',concat('test',id),'');
insert into t_user_info (id,name,password) values ('907',concat('test',id),'');
insert into t_user_info (id,name,password) values ('908',concat('test',id),'');
insert into t_user_info (id,name,password) values ('909',concat('test',id),'');
insert into t_user_info (id,name,password) values ('910',concat('test',id),'');
insert into t_user_info (id,name,password) values ('911',concat('test',id),'');
insert into t_user_info (id,name,password) values ('912',concat('test',id),'');
insert into t_user_info (id,name,password) values ('913',concat('test',id),'');
insert into t_user_info (id,name,password) values ('914',concat('test',id),'');
insert into t_user_info (id,name,password) values ('915',concat('test',id),'');
insert into t_user_info (id,name,password) values ('916',concat('test',id),'');
insert into t_user_info (id,name,password) values ('917',concat('test',id),'');
insert into t_user_info (id,name,password) values ('918',concat('test',id),'');
insert into t_user_info (id,name,password) values ('919',concat('test',id),'');
insert into t_user_info (id,name,password) values ('920',concat('test',id),'');
insert into t_user_info (id,name,password) values ('921',concat('test',id),'');
insert into t_user_info (id,name,password) values ('922',concat('test',id),'');
insert into t_user_info (id,name,password) values ('923',concat('test',id),'');
insert into t_user_info (id,name,password) values ('924',concat('test',id),'');
insert into t_user_info (id,name,password) values ('925',concat('test',id),'');
insert into t_user_info (id,name,password) values ('926',concat('test',id),'');
insert into t_user_info (id,name,password) values ('927',concat('test',id),'');
insert into t_user_info (id,name,password) values ('928',concat('test',id),'');
insert into t_user_info (id,name,password) values ('929',concat('test',id),'');
insert into t_user_info (id,name,password) values ('930',concat('test',id),'');
insert into t_user_info (id,name,password) values ('931',concat('test',id),'');
insert into t_user_info (id,name,password) values ('932',concat('test',id),'');
insert into t_user_info (id,name,password) values ('933',concat('test',id),'');
insert into t_user_info (id,name,password) values ('934',concat('test',id),'');
insert into t_user_info (id,name,password) values ('935',concat('test',id),'');
insert into t_user_info (id,name,password) values ('936',concat('test',id),'');
insert into t_user_info (id,name,password) values ('937',concat('test',id),'');
insert into t_user_info (id,name,password) values ('938',concat('test',id),'');
insert into t_user_info (id,name,password) values ('939',concat('test',id),'');
insert into t_user_info (id,name,password) values ('940',concat('test',id),'');
insert into t_user_info (id,name,password) values ('941',concat('test',id),'');
insert into t_user_info (id,name,password) values ('942',concat('test',id),'');
insert into t_user_info (id,name,password) values ('943',concat('test',id),'');
insert into t_user_info (id,name,password) values ('944',concat('test',id),'');
insert into t_user_info (id,name,password) values ('945',concat('test',id),'');
insert into t_user_info (id,name,password) values ('946',concat('test',id),'');
insert into t_user_info (id,name,password) values ('947',concat('test',id),'');
insert into t_user_info (id,name,password) values ('948',concat('test',id),'');
insert into t_user_info (id,name,password) values ('949',concat('test',id),'');
insert into t_user_info (id,name,password) values ('950',concat('test',id),'');
insert into t_user_info (id,name,password) values ('951',concat('test',id),'');
insert into t_user_info (id,name,password) values ('952',concat('test',id),'');
insert into t_user_info (id,name,password) values ('953',concat('test',id),'');
insert into t_user_info (id,name,password) values ('954',concat('test',id),'');
insert into t_user_info (id,name,password) values ('955',concat('test',id),'');
insert into t_user_info (id,name,password) values ('956',concat('test',id),'');
insert into t_user_info (id,name,password) values ('957',concat('test',id),'');
insert into t_user_info (id,name,password) values ('958',concat('test',id),'');
insert into t_user_info (id,name,password) values ('959',concat('test',id),'');
insert into t_user_info (id,name,password) values ('960',concat('test',id),'');
insert into t_user_info (id,name,password) values ('961',concat('test',id),'');
insert into t_user_info (id,name,password) values ('962',concat('test',id),'');
insert into t_user_info (id,name,password) values ('963',concat('test',id),'');
insert into t_user_info (id,name,password) values ('964',concat('test',id),'');
insert into t_user_info (id,name,password) values ('965',concat('test',id),'');
insert into t_user_info (id,name,password) values ('966',concat('test',id),'');
insert into t_user_info (id,name,password) values ('967',concat('test',id),'');
insert into t_user_info (id,name,password) values ('968',concat('test',id),'');
insert into t_user_info (id,name,password) values ('969',concat('test',id),'');
insert into t_user_info (id,name,password) values ('970',concat('test',id),'');
insert into t_user_info (id,name,password) values ('971',concat('test',id),'');
insert into t_user_info (id,name,password) values ('972',concat('test',id),'');
insert into t_user_info (id,name,password) values ('973',concat('test',id),'');
insert into t_user_info (id,name,password) values ('974',concat('test',id),'');
insert into t_user_info (id,name,password) values ('975',concat('test',id),'');
insert into t_user_info (id,name,password) values ('976',concat('test',id),'');
insert into t_user_info (id,name,password) values ('977',concat('test',id),'');
insert into t_user_info (id,name,password) values ('978',concat('test',id),'');
insert into t_user_info (id,name,password) values ('979',concat('test',id),'');
insert into t_user_info (id,name,password) values ('980',concat('test',id),'');
insert into t_user_info (id,name,password) values ('981',concat('test',id),'');
insert into t_user_info (id,name,password) values ('982',concat('test',id),'');
insert into t_user_info (id,name,password) values ('983',concat('test',id),'');
insert into t_user_info (id,name,password) values ('984',concat('test',id),'');
insert into t_user_info (id,name,password) values ('985',concat('test',id),'');
insert into t_user_info (id,name,password) values ('986',concat('test',id),'');
insert into t_user_info (id,name,password) values ('987',concat('test',id),'');
insert into t_user_info (id,name,password) values ('988',concat('test',id),'');
insert into t_user_info (id,name,password) values ('989',concat('test',id),'');
insert into t_user_info (id,name,password) values ('990',concat('test',id),'');
insert into t_user_info (id,name,password) values ('991',concat('test',id),'');
insert into t_user_info (id,name,password) values ('992',concat('test',id),'');
insert into t_user_info (id,name,password) values ('993',concat('test',id),'');
insert into t_user_info (id,name,password) values ('994',concat('test',id),'');
insert into t_user_info (id,name,password) values ('995',concat('test',id),'');
insert into t_user_info (id,name,password) values ('996',concat('test',id),'');
insert into t_user_info (id,name,password) values ('997',concat('test',id),'');
insert into t_user_info (id,name,password) values ('998',concat('test',id),'');
insert into t_user_info (id,name,password) values ('999',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1000',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1001',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1002',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1003',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1004',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1005',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1006',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1007',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1008',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1009',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1010',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1011',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1012',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1013',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1014',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1015',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1016',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1017',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1018',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1019',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1020',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1021',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1022',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1023',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1024',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1025',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1026',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1027',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1028',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1029',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1030',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1031',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1032',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1033',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1034',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1035',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1036',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1037',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1038',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1039',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1040',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1041',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1042',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1043',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1044',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1045',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1046',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1047',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1048',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1049',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1050',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1051',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1052',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1053',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1054',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1055',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1056',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1057',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1058',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1059',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1060',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1061',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1062',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1063',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1064',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1065',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1066',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1067',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1068',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1069',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1070',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1071',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1072',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1073',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1074',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1075',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1076',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1077',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1078',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1079',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1080',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1081',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1082',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1083',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1084',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1085',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1086',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1087',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1088',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1089',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1090',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1091',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1092',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1093',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1094',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1095',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1096',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1097',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1098',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1099',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1100',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1101',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1102',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1103',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1104',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1105',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1106',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1107',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1108',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1109',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1110',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1111',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1112',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1113',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1114',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1115',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1116',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1117',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1118',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1119',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1120',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1121',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1122',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1123',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1124',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1125',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1126',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1127',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1128',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1129',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1130',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1131',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1132',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1133',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1134',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1135',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1136',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1137',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1138',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1139',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1140',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1141',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1142',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1143',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1144',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1145',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1146',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1147',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1148',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1149',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1150',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1151',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1152',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1153',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1154',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1155',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1156',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1157',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1158',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1159',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1160',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1161',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1162',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1163',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1164',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1165',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1166',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1167',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1168',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1169',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1170',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1171',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1172',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1173',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1174',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1175',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1176',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1177',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1178',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1179',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1180',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1181',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1182',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1183',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1184',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1185',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1186',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1187',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1188',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1189',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1190',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1191',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1192',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1193',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1194',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1195',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1196',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1197',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1198',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1199',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1200',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1201',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1202',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1203',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1204',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1205',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1206',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1207',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1208',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1209',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1210',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1211',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1212',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1213',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1214',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1215',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1216',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1217',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1218',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1219',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1220',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1221',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1222',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1223',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1224',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1225',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1226',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1227',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1228',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1229',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1230',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1231',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1232',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1233',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1234',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1235',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1236',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1237',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1238',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1239',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1240',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1241',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1242',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1243',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1244',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1245',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1246',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1247',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1248',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1249',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1250',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1251',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1252',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1253',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1254',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1255',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1256',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1257',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1258',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1259',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1260',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1261',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1262',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1263',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1264',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1265',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1266',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1267',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1268',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1269',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1270',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1271',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1272',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1273',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1274',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1275',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1276',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1277',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1278',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1279',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1280',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1281',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1282',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1283',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1284',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1285',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1286',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1287',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1288',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1289',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1290',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1291',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1292',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1293',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1294',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1295',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1296',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1297',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1298',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1299',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1300',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1301',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1302',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1303',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1304',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1305',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1306',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1307',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1308',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1309',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1310',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1311',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1312',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1313',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1314',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1315',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1316',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1317',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1318',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1319',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1320',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1321',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1322',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1323',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1324',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1325',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1326',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1327',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1328',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1329',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1330',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1331',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1332',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1333',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1334',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1335',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1336',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1337',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1338',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1339',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1340',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1341',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1342',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1343',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1344',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1345',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1346',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1347',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1348',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1349',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1350',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1351',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1352',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1353',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1354',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1355',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1356',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1357',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1358',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1359',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1360',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1361',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1362',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1363',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1364',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1365',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1366',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1367',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1368',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1369',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1370',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1371',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1372',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1373',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1374',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1375',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1376',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1377',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1378',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1379',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1380',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1381',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1382',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1383',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1384',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1385',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1386',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1387',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1388',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1389',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1390',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1391',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1392',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1393',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1394',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1395',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1396',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1397',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1398',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1399',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1400',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1401',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1402',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1403',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1404',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1405',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1406',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1407',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1408',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1409',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1410',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1411',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1412',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1413',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1414',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1415',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1416',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1417',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1418',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1419',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1420',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1421',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1422',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1423',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1424',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1425',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1426',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1427',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1428',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1429',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1430',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1431',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1432',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1433',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1434',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1435',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1436',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1437',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1438',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1439',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1440',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1441',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1442',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1443',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1444',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1445',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1446',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1447',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1448',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1449',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1450',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1451',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1452',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1453',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1454',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1455',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1456',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1457',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1458',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1459',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1460',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1461',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1462',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1463',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1464',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1465',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1466',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1467',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1468',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1469',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1470',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1471',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1472',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1473',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1474',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1475',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1476',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1477',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1478',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1479',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1480',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1481',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1482',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1483',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1484',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1485',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1486',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1487',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1488',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1489',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1490',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1491',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1492',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1493',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1494',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1495',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1496',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1497',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1498',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1499',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1500',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1501',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1502',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1503',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1504',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1505',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1506',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1507',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1508',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1509',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1510',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1511',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1512',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1513',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1514',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1515',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1516',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1517',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1518',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1519',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1520',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1521',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1522',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1523',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1524',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1525',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1526',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1527',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1528',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1529',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1530',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1531',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1532',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1533',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1534',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1535',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1536',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1537',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1538',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1539',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1540',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1541',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1542',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1543',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1544',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1545',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1546',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1547',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1548',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1549',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1550',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1551',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1552',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1553',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1554',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1555',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1556',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1557',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1558',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1559',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1560',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1561',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1562',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1563',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1564',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1565',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1566',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1567',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1568',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1569',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1570',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1571',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1572',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1573',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1574',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1575',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1576',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1577',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1578',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1579',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1580',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1581',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1582',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1583',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1584',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1585',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1586',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1587',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1588',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1589',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1590',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1591',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1592',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1593',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1594',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1595',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1596',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1597',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1598',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1599',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1600',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1601',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1602',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1603',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1604',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1605',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1606',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1607',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1608',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1609',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1610',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1611',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1612',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1613',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1614',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1615',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1616',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1617',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1618',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1619',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1620',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1621',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1622',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1623',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1624',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1625',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1626',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1627',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1628',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1629',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1630',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1631',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1632',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1633',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1634',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1635',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1636',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1637',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1638',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1639',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1640',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1641',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1642',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1643',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1644',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1645',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1646',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1647',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1648',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1649',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1650',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1651',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1652',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1653',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1654',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1655',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1656',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1657',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1658',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1659',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1660',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1661',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1662',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1663',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1664',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1665',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1666',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1667',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1668',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1669',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1670',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1671',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1672',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1673',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1674',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1675',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1676',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1677',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1678',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1679',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1680',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1681',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1682',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1683',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1684',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1685',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1686',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1687',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1688',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1689',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1690',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1691',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1692',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1693',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1694',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1695',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1696',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1697',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1698',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1699',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1700',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1701',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1702',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1703',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1704',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1705',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1706',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1707',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1708',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1709',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1710',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1711',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1712',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1713',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1714',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1715',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1716',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1717',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1718',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1719',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1720',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1721',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1722',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1723',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1724',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1725',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1726',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1727',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1728',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1729',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1730',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1731',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1732',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1733',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1734',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1735',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1736',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1737',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1738',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1739',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1740',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1741',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1742',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1743',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1744',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1745',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1746',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1747',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1748',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1749',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1750',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1751',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1752',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1753',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1754',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1755',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1756',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1757',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1758',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1759',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1760',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1761',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1762',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1763',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1764',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1765',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1766',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1767',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1768',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1769',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1770',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1771',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1772',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1773',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1774',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1775',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1776',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1777',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1778',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1779',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1780',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1781',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1782',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1783',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1784',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1785',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1786',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1787',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1788',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1789',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1790',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1791',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1792',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1793',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1794',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1795',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1796',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1797',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1798',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1799',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1800',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1801',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1802',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1803',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1804',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1805',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1806',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1807',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1808',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1809',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1810',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1811',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1812',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1813',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1814',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1815',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1816',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1817',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1818',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1819',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1820',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1821',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1822',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1823',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1824',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1825',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1826',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1827',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1828',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1829',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1830',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1831',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1832',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1833',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1834',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1835',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1836',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1837',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1838',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1839',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1840',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1841',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1842',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1843',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1844',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1845',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1846',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1847',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1848',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1849',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1850',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1851',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1852',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1853',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1854',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1855',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1856',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1857',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1858',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1859',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1860',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1861',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1862',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1863',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1864',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1865',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1866',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1867',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1868',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1869',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1870',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1871',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1872',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1873',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1874',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1875',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1876',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1877',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1878',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1879',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1880',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1881',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1882',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1883',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1884',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1885',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1886',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1887',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1888',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1889',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1890',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1891',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1892',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1893',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1894',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1895',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1896',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1897',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1898',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1899',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1900',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1901',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1902',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1903',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1904',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1905',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1906',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1907',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1908',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1909',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1910',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1911',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1912',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1913',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1914',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1915',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1916',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1917',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1918',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1919',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1920',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1921',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1922',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1923',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1924',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1925',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1926',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1927',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1928',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1929',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1930',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1931',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1932',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1933',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1934',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1935',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1936',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1937',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1938',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1939',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1940',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1941',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1942',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1943',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1944',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1945',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1946',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1947',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1948',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1949',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1950',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1951',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1952',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1953',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1954',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1955',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1956',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1957',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1958',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1959',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1960',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1961',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1962',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1963',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1964',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1965',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1966',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1967',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1968',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1969',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1970',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1971',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1972',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1973',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1974',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1975',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1976',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1977',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1978',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1979',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1980',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1981',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1982',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1983',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1984',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1985',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1986',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1987',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1988',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1989',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1990',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1991',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1992',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1993',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1994',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1995',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1996',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1997',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1998',concat('test',id),'');
insert into t_user_info (id,name,password) values ('1999',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2000',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2001',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2002',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2003',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2004',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2005',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2006',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2007',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2008',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2009',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2010',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2011',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2012',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2013',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2014',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2015',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2016',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2017',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2018',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2019',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2020',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2021',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2022',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2023',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2024',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2025',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2026',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2027',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2028',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2029',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2030',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2031',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2032',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2033',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2034',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2035',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2036',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2037',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2038',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2039',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2040',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2041',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2042',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2043',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2044',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2045',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2046',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2047',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2048',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2049',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2050',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2051',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2052',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2053',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2054',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2055',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2056',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2057',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2058',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2059',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2060',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2061',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2062',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2063',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2064',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2065',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2066',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2067',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2068',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2069',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2070',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2071',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2072',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2073',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2074',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2075',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2076',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2077',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2078',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2079',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2080',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2081',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2082',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2083',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2084',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2085',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2086',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2087',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2088',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2089',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2090',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2091',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2092',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2093',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2094',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2095',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2096',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2097',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2098',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2099',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2100',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2101',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2102',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2103',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2104',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2105',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2106',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2107',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2108',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2109',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2110',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2111',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2112',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2113',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2114',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2115',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2116',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2117',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2118',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2119',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2120',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2121',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2122',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2123',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2124',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2125',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2126',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2127',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2128',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2129',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2130',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2131',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2132',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2133',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2134',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2135',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2136',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2137',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2138',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2139',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2140',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2141',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2142',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2143',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2144',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2145',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2146',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2147',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2148',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2149',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2150',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2151',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2152',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2153',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2154',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2155',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2156',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2157',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2158',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2159',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2160',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2161',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2162',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2163',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2164',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2165',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2166',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2167',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2168',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2169',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2170',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2171',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2172',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2173',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2174',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2175',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2176',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2177',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2178',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2179',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2180',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2181',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2182',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2183',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2184',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2185',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2186',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2187',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2188',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2189',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2190',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2191',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2192',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2193',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2194',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2195',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2196',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2197',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2198',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2199',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2200',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2201',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2202',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2203',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2204',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2205',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2206',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2207',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2208',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2209',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2210',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2211',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2212',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2213',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2214',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2215',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2216',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2217',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2218',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2219',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2220',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2221',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2222',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2223',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2224',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2225',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2226',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2227',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2228',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2229',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2230',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2231',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2232',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2233',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2234',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2235',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2236',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2237',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2238',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2239',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2240',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2241',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2242',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2243',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2244',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2245',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2246',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2247',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2248',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2249',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2250',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2251',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2252',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2253',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2254',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2255',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2256',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2257',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2258',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2259',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2260',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2261',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2262',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2263',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2264',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2265',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2266',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2267',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2268',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2269',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2270',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2271',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2272',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2273',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2274',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2275',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2276',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2277',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2278',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2279',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2280',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2281',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2282',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2283',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2284',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2285',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2286',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2287',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2288',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2289',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2290',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2291',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2292',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2293',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2294',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2295',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2296',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2297',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2298',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2299',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2300',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2301',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2302',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2303',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2304',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2305',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2306',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2307',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2308',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2309',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2310',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2311',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2312',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2313',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2314',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2315',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2316',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2317',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2318',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2319',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2320',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2321',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2322',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2323',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2324',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2325',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2326',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2327',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2328',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2329',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2330',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2331',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2332',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2333',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2334',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2335',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2336',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2337',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2338',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2339',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2340',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2341',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2342',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2343',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2344',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2345',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2346',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2347',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2348',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2349',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2350',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2351',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2352',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2353',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2354',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2355',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2356',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2357',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2358',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2359',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2360',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2361',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2362',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2363',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2364',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2365',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2366',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2367',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2368',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2369',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2370',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2371',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2372',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2373',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2374',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2375',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2376',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2377',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2378',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2379',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2380',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2381',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2382',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2383',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2384',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2385',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2386',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2387',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2388',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2389',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2390',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2391',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2392',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2393',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2394',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2395',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2396',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2397',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2398',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2399',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2400',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2401',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2402',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2403',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2404',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2405',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2406',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2407',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2408',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2409',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2410',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2411',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2412',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2413',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2414',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2415',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2416',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2417',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2418',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2419',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2420',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2421',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2422',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2423',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2424',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2425',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2426',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2427',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2428',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2429',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2430',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2431',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2432',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2433',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2434',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2435',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2436',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2437',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2438',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2439',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2440',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2441',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2442',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2443',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2444',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2445',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2446',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2447',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2448',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2449',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2450',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2451',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2452',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2453',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2454',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2455',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2456',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2457',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2458',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2459',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2460',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2461',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2462',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2463',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2464',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2465',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2466',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2467',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2468',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2469',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2470',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2471',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2472',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2473',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2474',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2475',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2476',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2477',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2478',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2479',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2480',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2481',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2482',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2483',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2484',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2485',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2486',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2487',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2488',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2489',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2490',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2491',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2492',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2493',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2494',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2495',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2496',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2497',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2498',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2499',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2500',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2501',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2502',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2503',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2504',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2505',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2506',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2507',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2508',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2509',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2510',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2511',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2512',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2513',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2514',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2515',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2516',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2517',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2518',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2519',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2520',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2521',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2522',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2523',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2524',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2525',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2526',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2527',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2528',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2529',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2530',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2531',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2532',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2533',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2534',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2535',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2536',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2537',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2538',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2539',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2540',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2541',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2542',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2543',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2544',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2545',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2546',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2547',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2548',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2549',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2550',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2551',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2552',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2553',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2554',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2555',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2556',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2557',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2558',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2559',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2560',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2561',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2562',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2563',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2564',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2565',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2566',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2567',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2568',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2569',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2570',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2571',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2572',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2573',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2574',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2575',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2576',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2577',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2578',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2579',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2580',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2581',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2582',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2583',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2584',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2585',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2586',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2587',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2588',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2589',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2590',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2591',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2592',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2593',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2594',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2595',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2596',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2597',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2598',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2599',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2600',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2601',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2602',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2603',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2604',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2605',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2606',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2607',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2608',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2609',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2610',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2611',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2612',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2613',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2614',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2615',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2616',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2617',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2618',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2619',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2620',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2621',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2622',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2623',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2624',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2625',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2626',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2627',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2628',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2629',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2630',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2631',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2632',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2633',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2634',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2635',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2636',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2637',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2638',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2639',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2640',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2641',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2642',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2643',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2644',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2645',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2646',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2647',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2648',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2649',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2650',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2651',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2652',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2653',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2654',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2655',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2656',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2657',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2658',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2659',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2660',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2661',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2662',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2663',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2664',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2665',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2666',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2667',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2668',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2669',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2670',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2671',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2672',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2673',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2674',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2675',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2676',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2677',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2678',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2679',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2680',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2681',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2682',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2683',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2684',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2685',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2686',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2687',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2688',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2689',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2690',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2691',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2692',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2693',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2694',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2695',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2696',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2697',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2698',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2699',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2700',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2701',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2702',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2703',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2704',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2705',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2706',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2707',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2708',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2709',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2710',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2711',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2712',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2713',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2714',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2715',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2716',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2717',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2718',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2719',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2720',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2721',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2722',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2723',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2724',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2725',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2726',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2727',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2728',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2729',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2730',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2731',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2732',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2733',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2734',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2735',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2736',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2737',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2738',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2739',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2740',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2741',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2742',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2743',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2744',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2745',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2746',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2747',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2748',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2749',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2750',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2751',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2752',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2753',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2754',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2755',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2756',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2757',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2758',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2759',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2760',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2761',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2762',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2763',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2764',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2765',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2766',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2767',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2768',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2769',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2770',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2771',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2772',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2773',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2774',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2775',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2776',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2777',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2778',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2779',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2780',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2781',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2782',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2783',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2784',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2785',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2786',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2787',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2788',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2789',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2790',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2791',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2792',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2793',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2794',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2795',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2796',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2797',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2798',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2799',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2800',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2801',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2802',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2803',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2804',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2805',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2806',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2807',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2808',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2809',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2810',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2811',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2812',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2813',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2814',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2815',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2816',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2817',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2818',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2819',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2820',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2821',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2822',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2823',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2824',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2825',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2826',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2827',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2828',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2829',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2830',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2831',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2832',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2833',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2834',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2835',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2836',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2837',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2838',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2839',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2840',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2841',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2842',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2843',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2844',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2845',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2846',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2847',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2848',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2849',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2850',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2851',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2852',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2853',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2854',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2855',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2856',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2857',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2858',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2859',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2860',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2861',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2862',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2863',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2864',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2865',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2866',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2867',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2868',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2869',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2870',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2871',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2872',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2873',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2874',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2875',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2876',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2877',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2878',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2879',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2880',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2881',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2882',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2883',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2884',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2885',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2886',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2887',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2888',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2889',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2890',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2891',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2892',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2893',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2894',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2895',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2896',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2897',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2898',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2899',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2900',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2901',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2902',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2903',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2904',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2905',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2906',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2907',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2908',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2909',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2910',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2911',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2912',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2913',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2914',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2915',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2916',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2917',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2918',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2919',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2920',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2921',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2922',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2923',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2924',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2925',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2926',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2927',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2928',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2929',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2930',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2931',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2932',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2933',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2934',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2935',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2936',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2937',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2938',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2939',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2940',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2941',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2942',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2943',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2944',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2945',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2946',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2947',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2948',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2949',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2950',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2951',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2952',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2953',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2954',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2955',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2956',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2957',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2958',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2959',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2960',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2961',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2962',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2963',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2964',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2965',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2966',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2967',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2968',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2969',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2970',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2971',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2972',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2973',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2974',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2975',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2976',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2977',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2978',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2979',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2980',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2981',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2982',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2983',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2984',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2985',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2986',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2987',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2988',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2989',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2990',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2991',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2992',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2993',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2994',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2995',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2996',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2997',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2998',concat('test',id),'');
insert into t_user_info (id,name,password) values ('2999',concat('test',id),'');
insert into t_user_info (id,name,password) values ('3000',concat('test',id),'');

update t_user_info set password='301436' where name='test1';
update t_user_info set password='935005' where name='test2';
update t_user_info set password='349392' where name='test3';
update t_user_info set password='237449' where name='test4';
update t_user_info set password='455313' where name='test5';
update t_user_info set password='272601' where name='test6';
update t_user_info set password='362575' where name='test7';
update t_user_info set password='637333' where name='test8';
update t_user_info set password='884025' where name='test9';
update t_user_info set password='814703' where name='test10';
update t_user_info set password='295832' where name='test11';
update t_user_info set password='295207' where name='test12';
update t_user_info set password='168117' where name='test13';
update t_user_info set password='734714' where name='test14';
update t_user_info set password='197968' where name='test15';
update t_user_info set password='478704' where name='test16';
update t_user_info set password='623404' where name='test17';
update t_user_info set password='512362' where name='test18';
update t_user_info set password='322429' where name='test19';
update t_user_info set password='190396' where name='test20';
update t_user_info set password='452898' where name='test21';
update t_user_info set password='814652' where name='test22';
update t_user_info set password='656276' where name='test23';
update t_user_info set password='589433' where name='test24';
update t_user_info set password='875510' where name='test25';
update t_user_info set password='598309' where name='test26';
update t_user_info set password='859319' where name='test27';
update t_user_info set password='179703' where name='test28';
update t_user_info set password='281397' where name='test29';
update t_user_info set password='873705' where name='test30';
update t_user_info set password='309066' where name='test31';
update t_user_info set password='343685' where name='test32';
update t_user_info set password='429101' where name='test33';
update t_user_info set password='294763' where name='test34';
update t_user_info set password='552201' where name='test35';
update t_user_info set password='764005' where name='test36';
update t_user_info set password='614102' where name='test37';
update t_user_info set password='907171' where name='test38';
update t_user_info set password='454576' where name='test39';
update t_user_info set password='483606' where name='test40';
update t_user_info set password='380632' where name='test41';
update t_user_info set password='717885' where name='test42';
update t_user_info set password='362529' where name='test43';
update t_user_info set password='162516' where name='test44';
update t_user_info set password='288287' where name='test45';
update t_user_info set password='347030' where name='test46';
update t_user_info set password='507061' where name='test47';
update t_user_info set password='445670' where name='test48';
update t_user_info set password='501337' where name='test49';
update t_user_info set password='854971' where name='test50';
update t_user_info set password='426082' where name='test51';
update t_user_info set password='226873' where name='test52';
update t_user_info set password='276403' where name='test53';
update t_user_info set password='660683' where name='test54';
update t_user_info set password='934318' where name='test55';
update t_user_info set password='513706' where name='test56';
update t_user_info set password='456130' where name='test57';
update t_user_info set password='264942' where name='test58';
update t_user_info set password='961764' where name='test59';
update t_user_info set password='183264' where name='test60';
update t_user_info set password='935926' where name='test61';
update t_user_info set password='260386' where name='test62';
update t_user_info set password='546835' where name='test63';
update t_user_info set password='713340' where name='test64';
update t_user_info set password='851379' where name='test65';
update t_user_info set password='580821' where name='test66';
update t_user_info set password='898462' where name='test67';
update t_user_info set password='859358' where name='test68';
update t_user_info set password='421242' where name='test69';
update t_user_info set password='859001' where name='test70';
update t_user_info set password='326307' where name='test71';
update t_user_info set password='187385' where name='test72';
update t_user_info set password='217863' where name='test73';
update t_user_info set password='842105' where name='test74';
update t_user_info set password='358732' where name='test75';
update t_user_info set password='568993' where name='test76';
update t_user_info set password='308015' where name='test77';
update t_user_info set password='134271' where name='test78';
update t_user_info set password='138124' where name='test79';
update t_user_info set password='427379' where name='test80';
update t_user_info set password='505737' where name='test81';
update t_user_info set password='977756' where name='test82';
update t_user_info set password='541604' where name='test83';
update t_user_info set password='242224' where name='test84';
update t_user_info set password='731993' where name='test85';
update t_user_info set password='511803' where name='test86';
update t_user_info set password='318783' where name='test87';
update t_user_info set password='643848' where name='test88';
update t_user_info set password='973713' where name='test89';
update t_user_info set password='589836' where name='test90';
update t_user_info set password='113274' where name='test91';
update t_user_info set password='985535' where name='test92';
update t_user_info set password='594761' where name='test93';
update t_user_info set password='370498' where name='test94';
update t_user_info set password='746871' where name='test95';
update t_user_info set password='650782' where name='test96';
update t_user_info set password='855391' where name='test97';
update t_user_info set password='133246' where name='test98';
update t_user_info set password='380078' where name='test99';
update t_user_info set password='551276' where name='test100';
update t_user_info set password='510799' where name='test101';
update t_user_info set password='379255' where name='test102';
update t_user_info set password='556448' where name='test103';
update t_user_info set password='789429' where name='test104';
update t_user_info set password='810070' where name='test105';
update t_user_info set password='420092' where name='test106';
update t_user_info set password='410695' where name='test107';
update t_user_info set password='913734' where name='test108';
update t_user_info set password='455102' where name='test109';
update t_user_info set password='529510' where name='test110';
update t_user_info set password='938577' where name='test111';
update t_user_info set password='291361' where name='test112';
update t_user_info set password='808766' where name='test113';
update t_user_info set password='567266' where name='test114';
update t_user_info set password='665988' where name='test115';
update t_user_info set password='134010' where name='test116';
update t_user_info set password='789743' where name='test117';
update t_user_info set password='221427' where name='test118';
update t_user_info set password='789332' where name='test119';
update t_user_info set password='800446' where name='test120';
update t_user_info set password='947764' where name='test121';
update t_user_info set password='745949' where name='test122';
update t_user_info set password='970564' where name='test123';
update t_user_info set password='153283' where name='test124';
update t_user_info set password='702108' where name='test125';
update t_user_info set password='140368' where name='test126';
update t_user_info set password='931383' where name='test127';
update t_user_info set password='514809' where name='test128';
update t_user_info set password='216125' where name='test129';
update t_user_info set password='562734' where name='test130';
update t_user_info set password='977656' where name='test131';
update t_user_info set password='241778' where name='test132';
update t_user_info set password='340836' where name='test133';
update t_user_info set password='999489' where name='test134';
update t_user_info set password='931396' where name='test135';
update t_user_info set password='413346' where name='test136';
update t_user_info set password='867195' where name='test137';
update t_user_info set password='189482' where name='test138';
update t_user_info set password='270398' where name='test139';
update t_user_info set password='584283' where name='test140';
update t_user_info set password='901772' where name='test141';
update t_user_info set password='734833' where name='test142';
update t_user_info set password='642607' where name='test143';
update t_user_info set password='938440' where name='test144';
update t_user_info set password='806305' where name='test145';
update t_user_info set password='932259' where name='test146';
update t_user_info set password='884750' where name='test147';
update t_user_info set password='351151' where name='test148';
update t_user_info set password='121346' where name='test149';
update t_user_info set password='744600' where name='test150';
update t_user_info set password='141602' where name='test151';
update t_user_info set password='508312' where name='test152';
update t_user_info set password='988558' where name='test153';
update t_user_info set password='816514' where name='test154';
update t_user_info set password='492875' where name='test155';
update t_user_info set password='366507' where name='test156';
update t_user_info set password='907954' where name='test157';
update t_user_info set password='112533' where name='test158';
update t_user_info set password='252558' where name='test159';
update t_user_info set password='838151' where name='test160';
update t_user_info set password='757502' where name='test161';
update t_user_info set password='990447' where name='test162';
update t_user_info set password='590764' where name='test163';
update t_user_info set password='820066' where name='test164';
update t_user_info set password='563360' where name='test165';
update t_user_info set password='245667' where name='test166';
update t_user_info set password='793455' where name='test167';
update t_user_info set password='565679' where name='test168';
update t_user_info set password='720207' where name='test169';
update t_user_info set password='483117' where name='test170';
update t_user_info set password='927562' where name='test171';
update t_user_info set password='214611' where name='test172';
update t_user_info set password='729291' where name='test173';
update t_user_info set password='855576' where name='test174';
update t_user_info set password='722494' where name='test175';
update t_user_info set password='585868' where name='test176';
update t_user_info set password='494048' where name='test177';
update t_user_info set password='279664' where name='test178';
update t_user_info set password='303797' where name='test179';
update t_user_info set password='449029' where name='test180';
update t_user_info set password='972401' where name='test181';
update t_user_info set password='507775' where name='test182';
update t_user_info set password='201004' where name='test183';
update t_user_info set password='651349' where name='test184';
update t_user_info set password='420385' where name='test185';
update t_user_info set password='106165' where name='test186';
update t_user_info set password='120980' where name='test187';
update t_user_info set password='571577' where name='test188';
update t_user_info set password='821595' where name='test189';
update t_user_info set password='333210' where name='test190';
update t_user_info set password='148567' where name='test191';
update t_user_info set password='782427' where name='test192';
update t_user_info set password='566931' where name='test193';
update t_user_info set password='966818' where name='test194';
update t_user_info set password='915936' where name='test195';
update t_user_info set password='401245' where name='test196';
update t_user_info set password='609945' where name='test197';
update t_user_info set password='259892' where name='test198';
update t_user_info set password='723217' where name='test199';
update t_user_info set password='714052' where name='test200';
update t_user_info set password='685775' where name='test201';
update t_user_info set password='559863' where name='test202';
update t_user_info set password='785373' where name='test203';
update t_user_info set password='854404' where name='test204';
update t_user_info set password='577110' where name='test205';
update t_user_info set password='326044' where name='test206';
update t_user_info set password='320084' where name='test207';
update t_user_info set password='821645' where name='test208';
update t_user_info set password='339546' where name='test209';
update t_user_info set password='645301' where name='test210';
update t_user_info set password='548999' where name='test211';
update t_user_info set password='540781' where name='test212';
update t_user_info set password='936809' where name='test213';
update t_user_info set password='947601' where name='test214';
update t_user_info set password='733433' where name='test215';
update t_user_info set password='466571' where name='test216';
update t_user_info set password='682076' where name='test217';
update t_user_info set password='937721' where name='test218';
update t_user_info set password='822847' where name='test219';
update t_user_info set password='128539' where name='test220';
update t_user_info set password='567340' where name='test221';
update t_user_info set password='982958' where name='test222';
update t_user_info set password='859785' where name='test223';
update t_user_info set password='702327' where name='test224';
update t_user_info set password='141233' where name='test225';
update t_user_info set password='720199' where name='test226';
update t_user_info set password='407124' where name='test227';
update t_user_info set password='808784' where name='test228';
update t_user_info set password='896971' where name='test229';
update t_user_info set password='320193' where name='test230';
update t_user_info set password='996155' where name='test231';
update t_user_info set password='325146' where name='test232';
update t_user_info set password='488161' where name='test233';
update t_user_info set password='235936' where name='test234';
update t_user_info set password='396486' where name='test235';
update t_user_info set password='750679' where name='test236';
update t_user_info set password='661988' where name='test237';
update t_user_info set password='844007' where name='test238';
update t_user_info set password='225962' where name='test239';
update t_user_info set password='867191' where name='test240';
update t_user_info set password='550191' where name='test241';
update t_user_info set password='876192' where name='test242';
update t_user_info set password='342764' where name='test243';
update t_user_info set password='891781' where name='test244';
update t_user_info set password='449199' where name='test245';
update t_user_info set password='328168' where name='test246';
update t_user_info set password='784142' where name='test247';
update t_user_info set password='204667' where name='test248';
update t_user_info set password='477703' where name='test249';
update t_user_info set password='430293' where name='test250';
update t_user_info set password='911042' where name='test251';
update t_user_info set password='559463' where name='test252';
update t_user_info set password='730367' where name='test253';
update t_user_info set password='695354' where name='test254';
update t_user_info set password='242396' where name='test255';
update t_user_info set password='608409' where name='test256';
update t_user_info set password='536132' where name='test257';
update t_user_info set password='597091' where name='test258';
update t_user_info set password='772697' where name='test259';
update t_user_info set password='635634' where name='test260';
update t_user_info set password='542629' where name='test261';
update t_user_info set password='211529' where name='test262';
update t_user_info set password='731122' where name='test263';
update t_user_info set password='877677' where name='test264';
update t_user_info set password='718568' where name='test265';
update t_user_info set password='586096' where name='test266';
update t_user_info set password='587382' where name='test267';
update t_user_info set password='189411' where name='test268';
update t_user_info set password='621884' where name='test269';
update t_user_info set password='785126' where name='test270';
update t_user_info set password='483738' where name='test271';
update t_user_info set password='531384' where name='test272';
update t_user_info set password='704633' where name='test273';
update t_user_info set password='856784' where name='test274';
update t_user_info set password='337395' where name='test275';
update t_user_info set password='788346' where name='test276';
update t_user_info set password='926209' where name='test277';
update t_user_info set password='116318' where name='test278';
update t_user_info set password='981495' where name='test279';
update t_user_info set password='804743' where name='test280';
update t_user_info set password='895224' where name='test281';
update t_user_info set password='356602' where name='test282';
update t_user_info set password='222878' where name='test283';
update t_user_info set password='308776' where name='test284';
update t_user_info set password='859202' where name='test285';
update t_user_info set password='656073' where name='test286';
update t_user_info set password='474749' where name='test287';
update t_user_info set password='132719' where name='test288';
update t_user_info set password='659778' where name='test289';
update t_user_info set password='992230' where name='test290';
update t_user_info set password='962005' where name='test291';
update t_user_info set password='254326' where name='test292';
update t_user_info set password='199993' where name='test293';
update t_user_info set password='953482' where name='test294';
update t_user_info set password='620640' where name='test295';
update t_user_info set password='833277' where name='test296';
update t_user_info set password='667261' where name='test297';
update t_user_info set password='967205' where name='test298';
update t_user_info set password='461758' where name='test299';
update t_user_info set password='969757' where name='test300';
update t_user_info set password='185580' where name='test301';
update t_user_info set password='927372' where name='test302';
update t_user_info set password='967362' where name='test303';
update t_user_info set password='106067' where name='test304';
update t_user_info set password='157698' where name='test305';
update t_user_info set password='230077' where name='test306';
update t_user_info set password='925765' where name='test307';
update t_user_info set password='110238' where name='test308';
update t_user_info set password='646194' where name='test309';
update t_user_info set password='331258' where name='test310';
update t_user_info set password='569312' where name='test311';
update t_user_info set password='543248' where name='test312';
update t_user_info set password='741823' where name='test313';
update t_user_info set password='414892' where name='test314';
update t_user_info set password='751005' where name='test315';
update t_user_info set password='735076' where name='test316';
update t_user_info set password='924180' where name='test317';
update t_user_info set password='428809' where name='test318';
update t_user_info set password='101121' where name='test319';
update t_user_info set password='102500' where name='test320';
update t_user_info set password='693373' where name='test321';
update t_user_info set password='608274' where name='test322';
update t_user_info set password='279722' where name='test323';
update t_user_info set password='489128' where name='test324';
update t_user_info set password='270917' where name='test325';
update t_user_info set password='795122' where name='test326';
update t_user_info set password='353777' where name='test327';
update t_user_info set password='359471' where name='test328';
update t_user_info set password='340010' where name='test329';
update t_user_info set password='565325' where name='test330';
update t_user_info set password='538336' where name='test331';
update t_user_info set password='195525' where name='test332';
update t_user_info set password='414340' where name='test333';
update t_user_info set password='393128' where name='test334';
update t_user_info set password='534760' where name='test335';
update t_user_info set password='398540' where name='test336';
update t_user_info set password='159603' where name='test337';
update t_user_info set password='797881' where name='test338';
update t_user_info set password='337109' where name='test339';
update t_user_info set password='479207' where name='test340';
update t_user_info set password='149878' where name='test341';
update t_user_info set password='797195' where name='test342';
update t_user_info set password='192486' where name='test343';
update t_user_info set password='466772' where name='test344';
update t_user_info set password='740936' where name='test345';
update t_user_info set password='378534' where name='test346';
update t_user_info set password='580900' where name='test347';
update t_user_info set password='456669' where name='test348';
update t_user_info set password='412493' where name='test349';
update t_user_info set password='707869' where name='test350';
update t_user_info set password='350106' where name='test351';
update t_user_info set password='736436' where name='test352';
update t_user_info set password='401857' where name='test353';
update t_user_info set password='899956' where name='test354';
update t_user_info set password='366428' where name='test355';
update t_user_info set password='123879' where name='test356';
update t_user_info set password='172719' where name='test357';
update t_user_info set password='654246' where name='test358';
update t_user_info set password='140056' where name='test359';
update t_user_info set password='216810' where name='test360';
update t_user_info set password='415575' where name='test361';
update t_user_info set password='962159' where name='test362';
update t_user_info set password='522968' where name='test363';
update t_user_info set password='432155' where name='test364';
update t_user_info set password='522031' where name='test365';
update t_user_info set password='517152' where name='test366';
update t_user_info set password='119964' where name='test367';
update t_user_info set password='169845' where name='test368';
update t_user_info set password='640290' where name='test369';
update t_user_info set password='196068' where name='test370';
update t_user_info set password='685122' where name='test371';
update t_user_info set password='387121' where name='test372';
update t_user_info set password='723739' where name='test373';
update t_user_info set password='614741' where name='test374';
update t_user_info set password='549794' where name='test375';
update t_user_info set password='609265' where name='test376';
update t_user_info set password='255988' where name='test377';
update t_user_info set password='740094' where name='test378';
update t_user_info set password='792945' where name='test379';
update t_user_info set password='246117' where name='test380';
update t_user_info set password='158635' where name='test381';
update t_user_info set password='537849' where name='test382';
update t_user_info set password='931250' where name='test383';
update t_user_info set password='490443' where name='test384';
update t_user_info set password='344580' where name='test385';
update t_user_info set password='925797' where name='test386';
update t_user_info set password='654672' where name='test387';
update t_user_info set password='295497' where name='test388';
update t_user_info set password='251204' where name='test389';
update t_user_info set password='540643' where name='test390';
update t_user_info set password='962110' where name='test391';
update t_user_info set password='688960' where name='test392';
update t_user_info set password='615207' where name='test393';
update t_user_info set password='669062' where name='test394';
update t_user_info set password='801196' where name='test395';
update t_user_info set password='180899' where name='test396';
update t_user_info set password='696958' where name='test397';
update t_user_info set password='630956' where name='test398';
update t_user_info set password='195677' where name='test399';
update t_user_info set password='428071' where name='test400';
update t_user_info set password='852525' where name='test401';
update t_user_info set password='907771' where name='test402';
update t_user_info set password='860573' where name='test403';
update t_user_info set password='266489' where name='test404';
update t_user_info set password='501825' where name='test405';
update t_user_info set password='461167' where name='test406';
update t_user_info set password='384912' where name='test407';
update t_user_info set password='921834' where name='test408';
update t_user_info set password='390871' where name='test409';
update t_user_info set password='825789' where name='test410';
update t_user_info set password='604279' where name='test411';
update t_user_info set password='826956' where name='test412';
update t_user_info set password='609094' where name='test413';
update t_user_info set password='776127' where name='test414';
update t_user_info set password='451490' where name='test415';
update t_user_info set password='948263' where name='test416';
update t_user_info set password='856187' where name='test417';
update t_user_info set password='387630' where name='test418';
update t_user_info set password='470060' where name='test419';
update t_user_info set password='506802' where name='test420';
update t_user_info set password='796543' where name='test421';
update t_user_info set password='793016' where name='test422';
update t_user_info set password='272788' where name='test423';
update t_user_info set password='558631' where name='test424';
update t_user_info set password='763487' where name='test425';
update t_user_info set password='599009' where name='test426';
update t_user_info set password='578329' where name='test427';
update t_user_info set password='325717' where name='test428';
update t_user_info set password='845261' where name='test429';
update t_user_info set password='223242' where name='test430';
update t_user_info set password='608625' where name='test431';
update t_user_info set password='588034' where name='test432';
update t_user_info set password='468250' where name='test433';
update t_user_info set password='993691' where name='test434';
update t_user_info set password='700371' where name='test435';
update t_user_info set password='263809' where name='test436';
update t_user_info set password='101062' where name='test437';
update t_user_info set password='876288' where name='test438';
update t_user_info set password='221871' where name='test439';
update t_user_info set password='874331' where name='test440';
update t_user_info set password='427940' where name='test441';
update t_user_info set password='629812' where name='test442';
update t_user_info set password='768175' where name='test443';
update t_user_info set password='936730' where name='test444';
update t_user_info set password='134851' where name='test445';
update t_user_info set password='282654' where name='test446';
update t_user_info set password='428095' where name='test447';
update t_user_info set password='866460' where name='test448';
update t_user_info set password='661248' where name='test449';
update t_user_info set password='397398' where name='test450';
update t_user_info set password='585551' where name='test451';
update t_user_info set password='596813' where name='test452';
update t_user_info set password='422335' where name='test453';
update t_user_info set password='542166' where name='test454';
update t_user_info set password='113135' where name='test455';
update t_user_info set password='175032' where name='test456';
update t_user_info set password='452650' where name='test457';
update t_user_info set password='413185' where name='test458';
update t_user_info set password='183592' where name='test459';
update t_user_info set password='815058' where name='test460';
update t_user_info set password='710244' where name='test461';
update t_user_info set password='319216' where name='test462';
update t_user_info set password='605109' where name='test463';
update t_user_info set password='659772' where name='test464';
update t_user_info set password='326863' where name='test465';
update t_user_info set password='103961' where name='test466';
update t_user_info set password='124927' where name='test467';
update t_user_info set password='288197' where name='test468';
update t_user_info set password='968490' where name='test469';
update t_user_info set password='972034' where name='test470';
update t_user_info set password='916230' where name='test471';
update t_user_info set password='504968' where name='test472';
update t_user_info set password='490910' where name='test473';
update t_user_info set password='307759' where name='test474';
update t_user_info set password='118266' where name='test475';
update t_user_info set password='172694' where name='test476';
update t_user_info set password='573090' where name='test477';
update t_user_info set password='700550' where name='test478';
update t_user_info set password='228603' where name='test479';
update t_user_info set password='222433' where name='test480';
update t_user_info set password='219728' where name='test481';
update t_user_info set password='623481' where name='test482';
update t_user_info set password='238752' where name='test483';
update t_user_info set password='964294' where name='test484';
update t_user_info set password='711392' where name='test485';
update t_user_info set password='917658' where name='test486';
update t_user_info set password='743700' where name='test487';
update t_user_info set password='226081' where name='test488';
update t_user_info set password='637947' where name='test489';
update t_user_info set password='631910' where name='test490';
update t_user_info set password='720385' where name='test491';
update t_user_info set password='803705' where name='test492';
update t_user_info set password='833416' where name='test493';
update t_user_info set password='469211' where name='test494';
update t_user_info set password='497995' where name='test495';
update t_user_info set password='491665' where name='test496';
update t_user_info set password='343825' where name='test497';
update t_user_info set password='246419' where name='test498';
update t_user_info set password='754360' where name='test499';
update t_user_info set password='462923' where name='test500';
update t_user_info set password='757346' where name='test501';
update t_user_info set password='655731' where name='test502';
update t_user_info set password='503276' where name='test503';
update t_user_info set password='480540' where name='test504';
update t_user_info set password='485399' where name='test505';
update t_user_info set password='399628' where name='test506';
update t_user_info set password='449901' where name='test507';
update t_user_info set password='537545' where name='test508';
update t_user_info set password='802806' where name='test509';
update t_user_info set password='896134' where name='test510';
update t_user_info set password='556844' where name='test511';
update t_user_info set password='691136' where name='test512';
update t_user_info set password='728247' where name='test513';
update t_user_info set password='691593' where name='test514';
update t_user_info set password='176789' where name='test515';
update t_user_info set password='913813' where name='test516';
update t_user_info set password='152312' where name='test517';
update t_user_info set password='638700' where name='test518';
update t_user_info set password='818017' where name='test519';
update t_user_info set password='144650' where name='test520';
update t_user_info set password='352759' where name='test521';
update t_user_info set password='883117' where name='test522';
update t_user_info set password='237740' where name='test523';
update t_user_info set password='200242' where name='test524';
update t_user_info set password='455991' where name='test525';
update t_user_info set password='544639' where name='test526';
update t_user_info set password='561508' where name='test527';
update t_user_info set password='948017' where name='test528';
update t_user_info set password='126085' where name='test529';
update t_user_info set password='822647' where name='test530';
update t_user_info set password='289519' where name='test531';
update t_user_info set password='577962' where name='test532';
update t_user_info set password='209856' where name='test533';
update t_user_info set password='465260' where name='test534';
update t_user_info set password='456940' where name='test535';
update t_user_info set password='961800' where name='test536';
update t_user_info set password='207654' where name='test537';
update t_user_info set password='291732' where name='test538';
update t_user_info set password='375635' where name='test539';
update t_user_info set password='487146' where name='test540';
update t_user_info set password='216517' where name='test541';
update t_user_info set password='149422' where name='test542';
update t_user_info set password='967856' where name='test543';
update t_user_info set password='148763' where name='test544';
update t_user_info set password='906646' where name='test545';
update t_user_info set password='393210' where name='test546';
update t_user_info set password='198940' where name='test547';
update t_user_info set password='724099' where name='test548';
update t_user_info set password='805555' where name='test549';
update t_user_info set password='251797' where name='test550';
update t_user_info set password='488918' where name='test551';
update t_user_info set password='957200' where name='test552';
update t_user_info set password='612771' where name='test553';
update t_user_info set password='855296' where name='test554';
update t_user_info set password='248162' where name='test555';
update t_user_info set password='982084' where name='test556';
update t_user_info set password='411777' where name='test557';
update t_user_info set password='441226' where name='test558';
update t_user_info set password='270503' where name='test559';
update t_user_info set password='232018' where name='test560';
update t_user_info set password='644101' where name='test561';
update t_user_info set password='217960' where name='test562';
update t_user_info set password='719844' where name='test563';
update t_user_info set password='337763' where name='test564';
update t_user_info set password='990834' where name='test565';
update t_user_info set password='777944' where name='test566';
update t_user_info set password='229397' where name='test567';
update t_user_info set password='214441' where name='test568';
update t_user_info set password='449458' where name='test569';
update t_user_info set password='199936' where name='test570';
update t_user_info set password='749781' where name='test571';
update t_user_info set password='490506' where name='test572';
update t_user_info set password='734196' where name='test573';
update t_user_info set password='608240' where name='test574';
update t_user_info set password='540904' where name='test575';
update t_user_info set password='938234' where name='test576';
update t_user_info set password='746928' where name='test577';
update t_user_info set password='969073' where name='test578';
update t_user_info set password='400707' where name='test579';
update t_user_info set password='905863' where name='test580';
update t_user_info set password='665377' where name='test581';
update t_user_info set password='723585' where name='test582';
update t_user_info set password='432109' where name='test583';
update t_user_info set password='426553' where name='test584';
update t_user_info set password='444821' where name='test585';
update t_user_info set password='145157' where name='test586';
update t_user_info set password='852772' where name='test587';
update t_user_info set password='973769' where name='test588';
update t_user_info set password='598123' where name='test589';
update t_user_info set password='760989' where name='test590';
update t_user_info set password='764718' where name='test591';
update t_user_info set password='730149' where name='test592';
update t_user_info set password='182435' where name='test593';
update t_user_info set password='852101' where name='test594';
update t_user_info set password='381070' where name='test595';
update t_user_info set password='448183' where name='test596';
update t_user_info set password='587039' where name='test597';
update t_user_info set password='762658' where name='test598';
update t_user_info set password='568979' where name='test599';
update t_user_info set password='640715' where name='test600';
update t_user_info set password='693736' where name='test601';
update t_user_info set password='851826' where name='test602';
update t_user_info set password='716005' where name='test603';
update t_user_info set password='204989' where name='test604';
update t_user_info set password='995102' where name='test605';
update t_user_info set password='265613' where name='test606';
update t_user_info set password='776334' where name='test607';
update t_user_info set password='992573' where name='test608';
update t_user_info set password='371574' where name='test609';
update t_user_info set password='756691' where name='test610';
update t_user_info set password='837368' where name='test611';
update t_user_info set password='857652' where name='test612';
update t_user_info set password='140187' where name='test613';
update t_user_info set password='226221' where name='test614';
update t_user_info set password='807260' where name='test615';
update t_user_info set password='989795' where name='test616';
update t_user_info set password='917809' where name='test617';
update t_user_info set password='885131' where name='test618';
update t_user_info set password='560046' where name='test619';
update t_user_info set password='849029' where name='test620';
update t_user_info set password='318010' where name='test621';
update t_user_info set password='342324' where name='test622';
update t_user_info set password='331789' where name='test623';
update t_user_info set password='655429' where name='test624';
update t_user_info set password='870527' where name='test625';
update t_user_info set password='235825' where name='test626';
update t_user_info set password='643770' where name='test627';
update t_user_info set password='121822' where name='test628';
update t_user_info set password='203039' where name='test629';
update t_user_info set password='273586' where name='test630';
update t_user_info set password='307328' where name='test631';
update t_user_info set password='249838' where name='test632';
update t_user_info set password='679518' where name='test633';
update t_user_info set password='386835' where name='test634';
update t_user_info set password='839642' where name='test635';
update t_user_info set password='574581' where name='test636';
update t_user_info set password='190299' where name='test637';
update t_user_info set password='754232' where name='test638';
update t_user_info set password='778568' where name='test639';
update t_user_info set password='333431' where name='test640';
update t_user_info set password='973618' where name='test641';
update t_user_info set password='578793' where name='test642';
update t_user_info set password='179184' where name='test643';
update t_user_info set password='422865' where name='test644';
update t_user_info set password='607481' where name='test645';
update t_user_info set password='338408' where name='test646';
update t_user_info set password='834554' where name='test647';
update t_user_info set password='428078' where name='test648';
update t_user_info set password='662751' where name='test649';
update t_user_info set password='442484' where name='test650';
update t_user_info set password='909022' where name='test651';
update t_user_info set password='832994' where name='test652';
update t_user_info set password='511400' where name='test653';
update t_user_info set password='817024' where name='test654';
update t_user_info set password='539523' where name='test655';
update t_user_info set password='393945' where name='test656';
update t_user_info set password='159665' where name='test657';
update t_user_info set password='831909' where name='test658';
update t_user_info set password='246363' where name='test659';
update t_user_info set password='735022' where name='test660';
update t_user_info set password='162786' where name='test661';
update t_user_info set password='203146' where name='test662';
update t_user_info set password='502958' where name='test663';
update t_user_info set password='989382' where name='test664';
update t_user_info set password='586396' where name='test665';
update t_user_info set password='930050' where name='test666';
update t_user_info set password='795994' where name='test667';
update t_user_info set password='550137' where name='test668';
update t_user_info set password='672037' where name='test669';
update t_user_info set password='851612' where name='test670';
update t_user_info set password='723590' where name='test671';
update t_user_info set password='440273' where name='test672';
update t_user_info set password='581366' where name='test673';
update t_user_info set password='439752' where name='test674';
update t_user_info set password='424133' where name='test675';
update t_user_info set password='677646' where name='test676';
update t_user_info set password='741086' where name='test677';
update t_user_info set password='174634' where name='test678';
update t_user_info set password='350748' where name='test679';
update t_user_info set password='388284' where name='test680';
update t_user_info set password='949182' where name='test681';
update t_user_info set password='921255' where name='test682';
update t_user_info set password='878451' where name='test683';
update t_user_info set password='687783' where name='test684';
update t_user_info set password='264090' where name='test685';
update t_user_info set password='475837' where name='test686';
update t_user_info set password='200917' where name='test687';
update t_user_info set password='698372' where name='test688';
update t_user_info set password='301091' where name='test689';
update t_user_info set password='420619' where name='test690';
update t_user_info set password='774515' where name='test691';
update t_user_info set password='376707' where name='test692';
update t_user_info set password='730628' where name='test693';
update t_user_info set password='513902' where name='test694';
update t_user_info set password='860079' where name='test695';
update t_user_info set password='310165' where name='test696';
update t_user_info set password='848655' where name='test697';
update t_user_info set password='508566' where name='test698';
update t_user_info set password='884994' where name='test699';
update t_user_info set password='283606' where name='test700';
update t_user_info set password='118084' where name='test701';
update t_user_info set password='430478' where name='test702';
update t_user_info set password='532647' where name='test703';
update t_user_info set password='390924' where name='test704';
update t_user_info set password='543110' where name='test705';
update t_user_info set password='218337' where name='test706';
update t_user_info set password='259848' where name='test707';
update t_user_info set password='229132' where name='test708';
update t_user_info set password='556390' where name='test709';
update t_user_info set password='529777' where name='test710';
update t_user_info set password='515962' where name='test711';
update t_user_info set password='289919' where name='test712';
update t_user_info set password='355686' where name='test713';
update t_user_info set password='160171' where name='test714';
update t_user_info set password='406399' where name='test715';
update t_user_info set password='585659' where name='test716';
update t_user_info set password='837855' where name='test717';
update t_user_info set password='115519' where name='test718';
update t_user_info set password='503244' where name='test719';
update t_user_info set password='798262' where name='test720';
update t_user_info set password='254874' where name='test721';
update t_user_info set password='921068' where name='test722';
update t_user_info set password='368176' where name='test723';
update t_user_info set password='756492' where name='test724';
update t_user_info set password='518187' where name='test725';
update t_user_info set password='973401' where name='test726';
update t_user_info set password='554244' where name='test727';
update t_user_info set password='703163' where name='test728';
update t_user_info set password='888531' where name='test729';
update t_user_info set password='349554' where name='test730';
update t_user_info set password='389408' where name='test731';
update t_user_info set password='198588' where name='test732';
update t_user_info set password='332471' where name='test733';
update t_user_info set password='890956' where name='test734';
update t_user_info set password='928832' where name='test735';
update t_user_info set password='569547' where name='test736';
update t_user_info set password='139559' where name='test737';
update t_user_info set password='761793' where name='test738';
update t_user_info set password='402287' where name='test739';
update t_user_info set password='911459' where name='test740';
update t_user_info set password='300248' where name='test741';
update t_user_info set password='771697' where name='test742';
update t_user_info set password='743348' where name='test743';
update t_user_info set password='748536' where name='test744';
update t_user_info set password='949459' where name='test745';
update t_user_info set password='512896' where name='test746';
update t_user_info set password='639536' where name='test747';
update t_user_info set password='231670' where name='test748';
update t_user_info set password='651578' where name='test749';
update t_user_info set password='337144' where name='test750';
update t_user_info set password='308644' where name='test751';
update t_user_info set password='240608' where name='test752';
update t_user_info set password='644806' where name='test753';
update t_user_info set password='108327' where name='test754';
update t_user_info set password='612942' where name='test755';
update t_user_info set password='977426' where name='test756';
update t_user_info set password='565987' where name='test757';
update t_user_info set password='710843' where name='test758';
update t_user_info set password='441693' where name='test759';
update t_user_info set password='645609' where name='test760';
update t_user_info set password='555889' where name='test761';
update t_user_info set password='893465' where name='test762';
update t_user_info set password='225875' where name='test763';
update t_user_info set password='722552' where name='test764';
update t_user_info set password='986400' where name='test765';
update t_user_info set password='903982' where name='test766';
update t_user_info set password='365167' where name='test767';
update t_user_info set password='533733' where name='test768';
update t_user_info set password='834449' where name='test769';
update t_user_info set password='918317' where name='test770';
update t_user_info set password='142614' where name='test771';
update t_user_info set password='873893' where name='test772';
update t_user_info set password='252946' where name='test773';
update t_user_info set password='668963' where name='test774';
update t_user_info set password='468858' where name='test775';
update t_user_info set password='762731' where name='test776';
update t_user_info set password='922281' where name='test777';
update t_user_info set password='923315' where name='test778';
update t_user_info set password='473245' where name='test779';
update t_user_info set password='518903' where name='test780';
update t_user_info set password='891296' where name='test781';
update t_user_info set password='756467' where name='test782';
update t_user_info set password='441815' where name='test783';
update t_user_info set password='180523' where name='test784';
update t_user_info set password='947692' where name='test785';
update t_user_info set password='377901' where name='test786';
update t_user_info set password='844181' where name='test787';
update t_user_info set password='161956' where name='test788';
update t_user_info set password='191603' where name='test789';
update t_user_info set password='980517' where name='test790';
update t_user_info set password='648715' where name='test791';
update t_user_info set password='703229' where name='test792';
update t_user_info set password='464488' where name='test793';
update t_user_info set password='644922' where name='test794';
update t_user_info set password='941318' where name='test795';
update t_user_info set password='194945' where name='test796';
update t_user_info set password='607352' where name='test797';
update t_user_info set password='558739' where name='test798';
update t_user_info set password='728995' where name='test799';
update t_user_info set password='659941' where name='test800';
update t_user_info set password='431772' where name='test801';
update t_user_info set password='237596' where name='test802';
update t_user_info set password='986166' where name='test803';
update t_user_info set password='638166' where name='test804';
update t_user_info set password='272379' where name='test805';
update t_user_info set password='111057' where name='test806';
update t_user_info set password='617152' where name='test807';
update t_user_info set password='315974' where name='test808';
update t_user_info set password='780856' where name='test809';
update t_user_info set password='237298' where name='test810';
update t_user_info set password='641936' where name='test811';
update t_user_info set password='350338' where name='test812';
update t_user_info set password='724669' where name='test813';
update t_user_info set password='575003' where name='test814';
update t_user_info set password='845973' where name='test815';
update t_user_info set password='113332' where name='test816';
update t_user_info set password='502982' where name='test817';
update t_user_info set password='144031' where name='test818';
update t_user_info set password='897848' where name='test819';
update t_user_info set password='916098' where name='test820';
update t_user_info set password='560027' where name='test821';
update t_user_info set password='757597' where name='test822';
update t_user_info set password='215892' where name='test823';
update t_user_info set password='728997' where name='test824';
update t_user_info set password='972281' where name='test825';
update t_user_info set password='405026' where name='test826';
update t_user_info set password='734913' where name='test827';
update t_user_info set password='110902' where name='test828';
update t_user_info set password='676971' where name='test829';
update t_user_info set password='540092' where name='test830';
update t_user_info set password='685946' where name='test831';
update t_user_info set password='143400' where name='test832';
update t_user_info set password='701927' where name='test833';
update t_user_info set password='714049' where name='test834';
update t_user_info set password='958273' where name='test835';
update t_user_info set password='230432' where name='test836';
update t_user_info set password='493790' where name='test837';
update t_user_info set password='582472' where name='test838';
update t_user_info set password='435407' where name='test839';
update t_user_info set password='956684' where name='test840';
update t_user_info set password='223268' where name='test841';
update t_user_info set password='690129' where name='test842';
update t_user_info set password='982702' where name='test843';
update t_user_info set password='792326' where name='test844';
update t_user_info set password='741471' where name='test845';
update t_user_info set password='481522' where name='test846';
update t_user_info set password='946210' where name='test847';
update t_user_info set password='930182' where name='test848';
update t_user_info set password='139652' where name='test849';
update t_user_info set password='521033' where name='test850';
update t_user_info set password='176912' where name='test851';
update t_user_info set password='111581' where name='test852';
update t_user_info set password='970477' where name='test853';
update t_user_info set password='507044' where name='test854';
update t_user_info set password='555665' where name='test855';
update t_user_info set password='835656' where name='test856';
update t_user_info set password='364125' where name='test857';
update t_user_info set password='518056' where name='test858';
update t_user_info set password='149701' where name='test859';
update t_user_info set password='157480' where name='test860';
update t_user_info set password='250898' where name='test861';
update t_user_info set password='398755' where name='test862';
update t_user_info set password='861746' where name='test863';
update t_user_info set password='130473' where name='test864';
update t_user_info set password='948654' where name='test865';
update t_user_info set password='603863' where name='test866';
update t_user_info set password='150558' where name='test867';
update t_user_info set password='884146' where name='test868';
update t_user_info set password='736902' where name='test869';
update t_user_info set password='320531' where name='test870';
update t_user_info set password='895092' where name='test871';
update t_user_info set password='774905' where name='test872';
update t_user_info set password='356652' where name='test873';
update t_user_info set password='924679' where name='test874';
update t_user_info set password='442992' where name='test875';
update t_user_info set password='233171' where name='test876';
update t_user_info set password='733574' where name='test877';
update t_user_info set password='414521' where name='test878';
update t_user_info set password='387295' where name='test879';
update t_user_info set password='996984' where name='test880';
update t_user_info set password='272733' where name='test881';
update t_user_info set password='921334' where name='test882';
update t_user_info set password='539461' where name='test883';
update t_user_info set password='388472' where name='test884';
update t_user_info set password='659834' where name='test885';
update t_user_info set password='450766' where name='test886';
update t_user_info set password='947418' where name='test887';
update t_user_info set password='663962' where name='test888';
update t_user_info set password='329889' where name='test889';
update t_user_info set password='301020' where name='test890';
update t_user_info set password='400214' where name='test891';
update t_user_info set password='854692' where name='test892';
update t_user_info set password='933521' where name='test893';
update t_user_info set password='938455' where name='test894';
update t_user_info set password='195118' where name='test895';
update t_user_info set password='191727' where name='test896';
update t_user_info set password='974066' where name='test897';
update t_user_info set password='546785' where name='test898';
update t_user_info set password='985467' where name='test899';
update t_user_info set password='212332' where name='test900';
update t_user_info set password='812242' where name='test901';
update t_user_info set password='324636' where name='test902';
update t_user_info set password='448636' where name='test903';
update t_user_info set password='251918' where name='test904';
update t_user_info set password='711871' where name='test905';
update t_user_info set password='328197' where name='test906';
update t_user_info set password='615714' where name='test907';
update t_user_info set password='544120' where name='test908';
update t_user_info set password='228420' where name='test909';
update t_user_info set password='982210' where name='test910';
update t_user_info set password='666440' where name='test911';
update t_user_info set password='163624' where name='test912';
update t_user_info set password='962334' where name='test913';
update t_user_info set password='747076' where name='test914';
update t_user_info set password='764223' where name='test915';
update t_user_info set password='113818' where name='test916';
update t_user_info set password='240669' where name='test917';
update t_user_info set password='249227' where name='test918';
update t_user_info set password='596910' where name='test919';
update t_user_info set password='477667' where name='test920';
update t_user_info set password='230219' where name='test921';
update t_user_info set password='350346' where name='test922';
update t_user_info set password='234571' where name='test923';
update t_user_info set password='679985' where name='test924';
update t_user_info set password='415024' where name='test925';
update t_user_info set password='336555' where name='test926';
update t_user_info set password='111418' where name='test927';
update t_user_info set password='126880' where name='test928';
update t_user_info set password='939712' where name='test929';
update t_user_info set password='949385' where name='test930';
update t_user_info set password='125955' where name='test931';
update t_user_info set password='663191' where name='test932';
update t_user_info set password='589071' where name='test933';
update t_user_info set password='317867' where name='test934';
update t_user_info set password='447182' where name='test935';
update t_user_info set password='890188' where name='test936';
update t_user_info set password='887711' where name='test937';
update t_user_info set password='122427' where name='test938';
update t_user_info set password='743171' where name='test939';
update t_user_info set password='529954' where name='test940';
update t_user_info set password='808916' where name='test941';
update t_user_info set password='364069' where name='test942';
update t_user_info set password='319500' where name='test943';
update t_user_info set password='858393' where name='test944';
update t_user_info set password='504417' where name='test945';
update t_user_info set password='849444' where name='test946';
update t_user_info set password='859632' where name='test947';
update t_user_info set password='634008' where name='test948';
update t_user_info set password='207676' where name='test949';
update t_user_info set password='757458' where name='test950';
update t_user_info set password='615164' where name='test951';
update t_user_info set password='674350' where name='test952';
update t_user_info set password='935527' where name='test953';
update t_user_info set password='674920' where name='test954';
update t_user_info set password='393651' where name='test955';
update t_user_info set password='248480' where name='test956';
update t_user_info set password='210303' where name='test957';
update t_user_info set password='634638' where name='test958';
update t_user_info set password='593679' where name='test959';
update t_user_info set password='504840' where name='test960';
update t_user_info set password='257415' where name='test961';
update t_user_info set password='843776' where name='test962';
update t_user_info set password='709262' where name='test963';
update t_user_info set password='458571' where name='test964';
update t_user_info set password='812674' where name='test965';
update t_user_info set password='733086' where name='test966';
update t_user_info set password='375821' where name='test967';
update t_user_info set password='120205' where name='test968';
update t_user_info set password='871411' where name='test969';
update t_user_info set password='202458' where name='test970';
update t_user_info set password='915486' where name='test971';
update t_user_info set password='993061' where name='test972';
update t_user_info set password='153085' where name='test973';
update t_user_info set password='563823' where name='test974';
update t_user_info set password='895560' where name='test975';
update t_user_info set password='625006' where name='test976';
update t_user_info set password='662318' where name='test977';
update t_user_info set password='700126' where name='test978';
update t_user_info set password='792891' where name='test979';
update t_user_info set password='555888' where name='test980';
update t_user_info set password='737061' where name='test981';
update t_user_info set password='526494' where name='test982';
update t_user_info set password='706520' where name='test983';
update t_user_info set password='211029' where name='test984';
update t_user_info set password='225690' where name='test985';
update t_user_info set password='834981' where name='test986';
update t_user_info set password='988892' where name='test987';
update t_user_info set password='565321' where name='test988';
update t_user_info set password='895549' where name='test989';
update t_user_info set password='925536' where name='test990';
update t_user_info set password='760593' where name='test991';
update t_user_info set password='272563' where name='test992';
update t_user_info set password='601141' where name='test993';
update t_user_info set password='121123' where name='test994';
update t_user_info set password='580193' where name='test995';
update t_user_info set password='420031' where name='test996';
update t_user_info set password='860861' where name='test997';
update t_user_info set password='730998' where name='test998';
update t_user_info set password='904168' where name='test999';
update t_user_info set password='945262' where name='test1000';
update t_user_info set password='775657' where name='test1001';
update t_user_info set password='472358' where name='test1002';
update t_user_info set password='588474' where name='test1003';
update t_user_info set password='849103' where name='test1004';
update t_user_info set password='274386' where name='test1005';
update t_user_info set password='395025' where name='test1006';
update t_user_info set password='406585' where name='test1007';
update t_user_info set password='904008' where name='test1008';
update t_user_info set password='577946' where name='test1009';
update t_user_info set password='621569' where name='test1010';
update t_user_info set password='648459' where name='test1011';
update t_user_info set password='715643' where name='test1012';
update t_user_info set password='831417' where name='test1013';
update t_user_info set password='836411' where name='test1014';
update t_user_info set password='444187' where name='test1015';
update t_user_info set password='494921' where name='test1016';
update t_user_info set password='985967' where name='test1017';
update t_user_info set password='176165' where name='test1018';
update t_user_info set password='930843' where name='test1019';
update t_user_info set password='229157' where name='test1020';
update t_user_info set password='779385' where name='test1021';
update t_user_info set password='787533' where name='test1022';
update t_user_info set password='962921' where name='test1023';
update t_user_info set password='681644' where name='test1024';
update t_user_info set password='275554' where name='test1025';
update t_user_info set password='468113' where name='test1026';
update t_user_info set password='759408' where name='test1027';
update t_user_info set password='522828' where name='test1028';
update t_user_info set password='808172' where name='test1029';
update t_user_info set password='586781' where name='test1030';
update t_user_info set password='893639' where name='test1031';
update t_user_info set password='539006' where name='test1032';
update t_user_info set password='407392' where name='test1033';
update t_user_info set password='328338' where name='test1034';
update t_user_info set password='303512' where name='test1035';
update t_user_info set password='676208' where name='test1036';
update t_user_info set password='113356' where name='test1037';
update t_user_info set password='346558' where name='test1038';
update t_user_info set password='576083' where name='test1039';
update t_user_info set password='909182' where name='test1040';
update t_user_info set password='396876' where name='test1041';
update t_user_info set password='918672' where name='test1042';
update t_user_info set password='321148' where name='test1043';
update t_user_info set password='806895' where name='test1044';
update t_user_info set password='129967' where name='test1045';
update t_user_info set password='834515' where name='test1046';
update t_user_info set password='406717' where name='test1047';
update t_user_info set password='754737' where name='test1048';
update t_user_info set password='276166' where name='test1049';
update t_user_info set password='634846' where name='test1050';
update t_user_info set password='840193' where name='test1051';
update t_user_info set password='922148' where name='test1052';
update t_user_info set password='702058' where name='test1053';
update t_user_info set password='298714' where name='test1054';
update t_user_info set password='751913' where name='test1055';
update t_user_info set password='609773' where name='test1056';
update t_user_info set password='406410' where name='test1057';
update t_user_info set password='458576' where name='test1058';
update t_user_info set password='173787' where name='test1059';
update t_user_info set password='202735' where name='test1060';
update t_user_info set password='816065' where name='test1061';
update t_user_info set password='806815' where name='test1062';
update t_user_info set password='275682' where name='test1063';
update t_user_info set password='596848' where name='test1064';
update t_user_info set password='673101' where name='test1065';
update t_user_info set password='891130' where name='test1066';
update t_user_info set password='391748' where name='test1067';
update t_user_info set password='106949' where name='test1068';
update t_user_info set password='560216' where name='test1069';
update t_user_info set password='595135' where name='test1070';
update t_user_info set password='211946' where name='test1071';
update t_user_info set password='363311' where name='test1072';
update t_user_info set password='963856' where name='test1073';
update t_user_info set password='862224' where name='test1074';
update t_user_info set password='685237' where name='test1075';
update t_user_info set password='112254' where name='test1076';
update t_user_info set password='861640' where name='test1077';
update t_user_info set password='773028' where name='test1078';
update t_user_info set password='856487' where name='test1079';
update t_user_info set password='328990' where name='test1080';
update t_user_info set password='541893' where name='test1081';
update t_user_info set password='400999' where name='test1082';
update t_user_info set password='798791' where name='test1083';
update t_user_info set password='332208' where name='test1084';
update t_user_info set password='825978' where name='test1085';
update t_user_info set password='391790' where name='test1086';
update t_user_info set password='690647' where name='test1087';
update t_user_info set password='557341' where name='test1088';
update t_user_info set password='865136' where name='test1089';
update t_user_info set password='922700' where name='test1090';
update t_user_info set password='582868' where name='test1091';
update t_user_info set password='502904' where name='test1092';
update t_user_info set password='936392' where name='test1093';
update t_user_info set password='187404' where name='test1094';
update t_user_info set password='889878' where name='test1095';
update t_user_info set password='864368' where name='test1096';
update t_user_info set password='977696' where name='test1097';
update t_user_info set password='160818' where name='test1098';
update t_user_info set password='986272' where name='test1099';
update t_user_info set password='161424' where name='test1100';
update t_user_info set password='960757' where name='test1101';
update t_user_info set password='824369' where name='test1102';
update t_user_info set password='785027' where name='test1103';
update t_user_info set password='627949' where name='test1104';
update t_user_info set password='254154' where name='test1105';
update t_user_info set password='282483' where name='test1106';
update t_user_info set password='395528' where name='test1107';
update t_user_info set password='395577' where name='test1108';
update t_user_info set password='152390' where name='test1109';
update t_user_info set password='699393' where name='test1110';
update t_user_info set password='952963' where name='test1111';
update t_user_info set password='650500' where name='test1112';
update t_user_info set password='194327' where name='test1113';
update t_user_info set password='828803' where name='test1114';
update t_user_info set password='935749' where name='test1115';
update t_user_info set password='110653' where name='test1116';
update t_user_info set password='977081' where name='test1117';
update t_user_info set password='527617' where name='test1118';
update t_user_info set password='220330' where name='test1119';
update t_user_info set password='814547' where name='test1120';
update t_user_info set password='389128' where name='test1121';
update t_user_info set password='746478' where name='test1122';
update t_user_info set password='203720' where name='test1123';
update t_user_info set password='112611' where name='test1124';
update t_user_info set password='892441' where name='test1125';
update t_user_info set password='485543' where name='test1126';
update t_user_info set password='839924' where name='test1127';
update t_user_info set password='686014' where name='test1128';
update t_user_info set password='604213' where name='test1129';
update t_user_info set password='685167' where name='test1130';
update t_user_info set password='686168' where name='test1131';
update t_user_info set password='164847' where name='test1132';
update t_user_info set password='280515' where name='test1133';
update t_user_info set password='819840' where name='test1134';
update t_user_info set password='700942' where name='test1135';
update t_user_info set password='518314' where name='test1136';
update t_user_info set password='811991' where name='test1137';
update t_user_info set password='288950' where name='test1138';
update t_user_info set password='141176' where name='test1139';
update t_user_info set password='111009' where name='test1140';
update t_user_info set password='498524' where name='test1141';
update t_user_info set password='976819' where name='test1142';
update t_user_info set password='558423' where name='test1143';
update t_user_info set password='927237' where name='test1144';
update t_user_info set password='318659' where name='test1145';
update t_user_info set password='554322' where name='test1146';
update t_user_info set password='303971' where name='test1147';
update t_user_info set password='324668' where name='test1148';
update t_user_info set password='817863' where name='test1149';
update t_user_info set password='839678' where name='test1150';
update t_user_info set password='824152' where name='test1151';
update t_user_info set password='974478' where name='test1152';
update t_user_info set password='414037' where name='test1153';
update t_user_info set password='798895' where name='test1154';
update t_user_info set password='555322' where name='test1155';
update t_user_info set password='961484' where name='test1156';
update t_user_info set password='603545' where name='test1157';
update t_user_info set password='262257' where name='test1158';
update t_user_info set password='766173' where name='test1159';
update t_user_info set password='408059' where name='test1160';
update t_user_info set password='823842' where name='test1161';
update t_user_info set password='345850' where name='test1162';
update t_user_info set password='435072' where name='test1163';
update t_user_info set password='603689' where name='test1164';
update t_user_info set password='926045' where name='test1165';
update t_user_info set password='612869' where name='test1166';
update t_user_info set password='680483' where name='test1167';
update t_user_info set password='818061' where name='test1168';
update t_user_info set password='224850' where name='test1169';
update t_user_info set password='185332' where name='test1170';
update t_user_info set password='928250' where name='test1171';
update t_user_info set password='930889' where name='test1172';
update t_user_info set password='708789' where name='test1173';
update t_user_info set password='623234' where name='test1174';
update t_user_info set password='987806' where name='test1175';
update t_user_info set password='607416' where name='test1176';
update t_user_info set password='870988' where name='test1177';
update t_user_info set password='385971' where name='test1178';
update t_user_info set password='479029' where name='test1179';
update t_user_info set password='425385' where name='test1180';
update t_user_info set password='530243' where name='test1181';
update t_user_info set password='181706' where name='test1182';
update t_user_info set password='217592' where name='test1183';
update t_user_info set password='203272' where name='test1184';
update t_user_info set password='602739' where name='test1185';
update t_user_info set password='960909' where name='test1186';
update t_user_info set password='286861' where name='test1187';
update t_user_info set password='209780' where name='test1188';
update t_user_info set password='205558' where name='test1189';
update t_user_info set password='650523' where name='test1190';
update t_user_info set password='762068' where name='test1191';
update t_user_info set password='672150' where name='test1192';
update t_user_info set password='227290' where name='test1193';
update t_user_info set password='947253' where name='test1194';
update t_user_info set password='651843' where name='test1195';
update t_user_info set password='143748' where name='test1196';
update t_user_info set password='363306' where name='test1197';
update t_user_info set password='939195' where name='test1198';
update t_user_info set password='167688' where name='test1199';
update t_user_info set password='273438' where name='test1200';
update t_user_info set password='101295' where name='test1201';
update t_user_info set password='440328' where name='test1202';
update t_user_info set password='727186' where name='test1203';
update t_user_info set password='723371' where name='test1204';
update t_user_info set password='721611' where name='test1205';
update t_user_info set password='603675' where name='test1206';
update t_user_info set password='402546' where name='test1207';
update t_user_info set password='892032' where name='test1208';
update t_user_info set password='408112' where name='test1209';
update t_user_info set password='484635' where name='test1210';
update t_user_info set password='755859' where name='test1211';
update t_user_info set password='717358' where name='test1212';
update t_user_info set password='794307' where name='test1213';
update t_user_info set password='582233' where name='test1214';
update t_user_info set password='802290' where name='test1215';
update t_user_info set password='120694' where name='test1216';
update t_user_info set password='571612' where name='test1217';
update t_user_info set password='821607' where name='test1218';
update t_user_info set password='103668' where name='test1219';
update t_user_info set password='658656' where name='test1220';
update t_user_info set password='675992' where name='test1221';
update t_user_info set password='881151' where name='test1222';
update t_user_info set password='527175' where name='test1223';
update t_user_info set password='108051' where name='test1224';
update t_user_info set password='639825' where name='test1225';
update t_user_info set password='907791' where name='test1226';
update t_user_info set password='289621' where name='test1227';
update t_user_info set password='860273' where name='test1228';
update t_user_info set password='401927' where name='test1229';
update t_user_info set password='182672' where name='test1230';
update t_user_info set password='130602' where name='test1231';
update t_user_info set password='873006' where name='test1232';
update t_user_info set password='427488' where name='test1233';
update t_user_info set password='108725' where name='test1234';
update t_user_info set password='672442' where name='test1235';
update t_user_info set password='994295' where name='test1236';
update t_user_info set password='944714' where name='test1237';
update t_user_info set password='979823' where name='test1238';
update t_user_info set password='145890' where name='test1239';
update t_user_info set password='622014' where name='test1240';
update t_user_info set password='967806' where name='test1241';
update t_user_info set password='271442' where name='test1242';
update t_user_info set password='153812' where name='test1243';
update t_user_info set password='135047' where name='test1244';
update t_user_info set password='267865' where name='test1245';
update t_user_info set password='569437' where name='test1246';
update t_user_info set password='732277' where name='test1247';
update t_user_info set password='349965' where name='test1248';
update t_user_info set password='941845' where name='test1249';
update t_user_info set password='689998' where name='test1250';
update t_user_info set password='838207' where name='test1251';
update t_user_info set password='466768' where name='test1252';
update t_user_info set password='278232' where name='test1253';
update t_user_info set password='225650' where name='test1254';
update t_user_info set password='136733' where name='test1255';
update t_user_info set password='512720' where name='test1256';
update t_user_info set password='682847' where name='test1257';
update t_user_info set password='529523' where name='test1258';
update t_user_info set password='271847' where name='test1259';
update t_user_info set password='103652' where name='test1260';
update t_user_info set password='960465' where name='test1261';
update t_user_info set password='997491' where name='test1262';
update t_user_info set password='989755' where name='test1263';
update t_user_info set password='634231' where name='test1264';
update t_user_info set password='916845' where name='test1265';
update t_user_info set password='370194' where name='test1266';
update t_user_info set password='208816' where name='test1267';
update t_user_info set password='578055' where name='test1268';
update t_user_info set password='129286' where name='test1269';
update t_user_info set password='468738' where name='test1270';
update t_user_info set password='927836' where name='test1271';
update t_user_info set password='994558' where name='test1272';
update t_user_info set password='983835' where name='test1273';
update t_user_info set password='137751' where name='test1274';
update t_user_info set password='988527' where name='test1275';
update t_user_info set password='516719' where name='test1276';
update t_user_info set password='493076' where name='test1277';
update t_user_info set password='783138' where name='test1278';
update t_user_info set password='510634' where name='test1279';
update t_user_info set password='667234' where name='test1280';
update t_user_info set password='319799' where name='test1281';
update t_user_info set password='805598' where name='test1282';
update t_user_info set password='626391' where name='test1283';
update t_user_info set password='898163' where name='test1284';
update t_user_info set password='219479' where name='test1285';
update t_user_info set password='976123' where name='test1286';
update t_user_info set password='785446' where name='test1287';
update t_user_info set password='757961' where name='test1288';
update t_user_info set password='682313' where name='test1289';
update t_user_info set password='194626' where name='test1290';
update t_user_info set password='878956' where name='test1291';
update t_user_info set password='730517' where name='test1292';
update t_user_info set password='961831' where name='test1293';
update t_user_info set password='302876' where name='test1294';
update t_user_info set password='406342' where name='test1295';
update t_user_info set password='764407' where name='test1296';
update t_user_info set password='307992' where name='test1297';
update t_user_info set password='562324' where name='test1298';
update t_user_info set password='749439' where name='test1299';
update t_user_info set password='139934' where name='test1300';
update t_user_info set password='787588' where name='test1301';
update t_user_info set password='912347' where name='test1302';
update t_user_info set password='674752' where name='test1303';
update t_user_info set password='378403' where name='test1304';
update t_user_info set password='469205' where name='test1305';
update t_user_info set password='849797' where name='test1306';
update t_user_info set password='626353' where name='test1307';
update t_user_info set password='829128' where name='test1308';
update t_user_info set password='733344' where name='test1309';
update t_user_info set password='175351' where name='test1310';
update t_user_info set password='939468' where name='test1311';
update t_user_info set password='892374' where name='test1312';
update t_user_info set password='789863' where name='test1313';
update t_user_info set password='501732' where name='test1314';
update t_user_info set password='517898' where name='test1315';
update t_user_info set password='740336' where name='test1316';
update t_user_info set password='316073' where name='test1317';
update t_user_info set password='258584' where name='test1318';
update t_user_info set password='531002' where name='test1319';
update t_user_info set password='201551' where name='test1320';
update t_user_info set password='611514' where name='test1321';
update t_user_info set password='784875' where name='test1322';
update t_user_info set password='318670' where name='test1323';
update t_user_info set password='472833' where name='test1324';
update t_user_info set password='717297' where name='test1325';
update t_user_info set password='537426' where name='test1326';
update t_user_info set password='448329' where name='test1327';
update t_user_info set password='423286' where name='test1328';
update t_user_info set password='326823' where name='test1329';
update t_user_info set password='320090' where name='test1330';
update t_user_info set password='496348' where name='test1331';
update t_user_info set password='857210' where name='test1332';
update t_user_info set password='771675' where name='test1333';
update t_user_info set password='950748' where name='test1334';
update t_user_info set password='351025' where name='test1335';
update t_user_info set password='727830' where name='test1336';
update t_user_info set password='435615' where name='test1337';
update t_user_info set password='663701' where name='test1338';
update t_user_info set password='805673' where name='test1339';
update t_user_info set password='313940' where name='test1340';
update t_user_info set password='305412' where name='test1341';
update t_user_info set password='887223' where name='test1342';
update t_user_info set password='466738' where name='test1343';
update t_user_info set password='658549' where name='test1344';
update t_user_info set password='815862' where name='test1345';
update t_user_info set password='452320' where name='test1346';
update t_user_info set password='288376' where name='test1347';
update t_user_info set password='786506' where name='test1348';
update t_user_info set password='733497' where name='test1349';
update t_user_info set password='967794' where name='test1350';
update t_user_info set password='791453' where name='test1351';
update t_user_info set password='360238' where name='test1352';
update t_user_info set password='753198' where name='test1353';
update t_user_info set password='678586' where name='test1354';
update t_user_info set password='180261' where name='test1355';
update t_user_info set password='950124' where name='test1356';
update t_user_info set password='553960' where name='test1357';
update t_user_info set password='472964' where name='test1358';
update t_user_info set password='805919' where name='test1359';
update t_user_info set password='802474' where name='test1360';
update t_user_info set password='255065' where name='test1361';
update t_user_info set password='457248' where name='test1362';
update t_user_info set password='883849' where name='test1363';
update t_user_info set password='891469' where name='test1364';
update t_user_info set password='607170' where name='test1365';
update t_user_info set password='650830' where name='test1366';
update t_user_info set password='554230' where name='test1367';
update t_user_info set password='861409' where name='test1368';
update t_user_info set password='577000' where name='test1369';
update t_user_info set password='354325' where name='test1370';
update t_user_info set password='330041' where name='test1371';
update t_user_info set password='895465' where name='test1372';
update t_user_info set password='640719' where name='test1373';
update t_user_info set password='613446' where name='test1374';
update t_user_info set password='551380' where name='test1375';
update t_user_info set password='418073' where name='test1376';
update t_user_info set password='634654' where name='test1377';
update t_user_info set password='906907' where name='test1378';
update t_user_info set password='331588' where name='test1379';
update t_user_info set password='438414' where name='test1380';
update t_user_info set password='846446' where name='test1381';
update t_user_info set password='597581' where name='test1382';
update t_user_info set password='140231' where name='test1383';
update t_user_info set password='978273' where name='test1384';
update t_user_info set password='137717' where name='test1385';
update t_user_info set password='283638' where name='test1386';
update t_user_info set password='964200' where name='test1387';
update t_user_info set password='837500' where name='test1388';
update t_user_info set password='869584' where name='test1389';
update t_user_info set password='154970' where name='test1390';
update t_user_info set password='450422' where name='test1391';
update t_user_info set password='648765' where name='test1392';
update t_user_info set password='546950' where name='test1393';
update t_user_info set password='525839' where name='test1394';
update t_user_info set password='230150' where name='test1395';
update t_user_info set password='847315' where name='test1396';
update t_user_info set password='653514' where name='test1397';
update t_user_info set password='447567' where name='test1398';
update t_user_info set password='144117' where name='test1399';
update t_user_info set password='143920' where name='test1400';
update t_user_info set password='881762' where name='test1401';
update t_user_info set password='601776' where name='test1402';
update t_user_info set password='783968' where name='test1403';
update t_user_info set password='504324' where name='test1404';
update t_user_info set password='261593' where name='test1405';
update t_user_info set password='824231' where name='test1406';
update t_user_info set password='123612' where name='test1407';
update t_user_info set password='650572' where name='test1408';
update t_user_info set password='153324' where name='test1409';
update t_user_info set password='869133' where name='test1410';
update t_user_info set password='692970' where name='test1411';
update t_user_info set password='583869' where name='test1412';
update t_user_info set password='370468' where name='test1413';
update t_user_info set password='628713' where name='test1414';
update t_user_info set password='616726' where name='test1415';
update t_user_info set password='883859' where name='test1416';
update t_user_info set password='997162' where name='test1417';
update t_user_info set password='250932' where name='test1418';
update t_user_info set password='489468' where name='test1419';
update t_user_info set password='130762' where name='test1420';
update t_user_info set password='722058' where name='test1421';
update t_user_info set password='561221' where name='test1422';
update t_user_info set password='248327' where name='test1423';
update t_user_info set password='811480' where name='test1424';
update t_user_info set password='875309' where name='test1425';
update t_user_info set password='759799' where name='test1426';
update t_user_info set password='709217' where name='test1427';
update t_user_info set password='162436' where name='test1428';
update t_user_info set password='453387' where name='test1429';
update t_user_info set password='179758' where name='test1430';
update t_user_info set password='646504' where name='test1431';
update t_user_info set password='914643' where name='test1432';
update t_user_info set password='753269' where name='test1433';
update t_user_info set password='440320' where name='test1434';
update t_user_info set password='165982' where name='test1435';
update t_user_info set password='111660' where name='test1436';
update t_user_info set password='841241' where name='test1437';
update t_user_info set password='299090' where name='test1438';
update t_user_info set password='483958' where name='test1439';
update t_user_info set password='826219' where name='test1440';
update t_user_info set password='384178' where name='test1441';
update t_user_info set password='214655' where name='test1442';
update t_user_info set password='802195' where name='test1443';
update t_user_info set password='629734' where name='test1444';
update t_user_info set password='679417' where name='test1445';
update t_user_info set password='313675' where name='test1446';
update t_user_info set password='979631' where name='test1447';
update t_user_info set password='932563' where name='test1448';
update t_user_info set password='321310' where name='test1449';
update t_user_info set password='248433' where name='test1450';
update t_user_info set password='185537' where name='test1451';
update t_user_info set password='883947' where name='test1452';
update t_user_info set password='336351' where name='test1453';
update t_user_info set password='542664' where name='test1454';
update t_user_info set password='998729' where name='test1455';
update t_user_info set password='547541' where name='test1456';
update t_user_info set password='249100' where name='test1457';
update t_user_info set password='750585' where name='test1458';
update t_user_info set password='998048' where name='test1459';
update t_user_info set password='559272' where name='test1460';
update t_user_info set password='179802' where name='test1461';
update t_user_info set password='926297' where name='test1462';
update t_user_info set password='140759' where name='test1463';
update t_user_info set password='225659' where name='test1464';
update t_user_info set password='594764' where name='test1465';
update t_user_info set password='887474' where name='test1466';
update t_user_info set password='287495' where name='test1467';
update t_user_info set password='340595' where name='test1468';
update t_user_info set password='293743' where name='test1469';
update t_user_info set password='636014' where name='test1470';
update t_user_info set password='175074' where name='test1471';
update t_user_info set password='870222' where name='test1472';
update t_user_info set password='958039' where name='test1473';
update t_user_info set password='221272' where name='test1474';
update t_user_info set password='624087' where name='test1475';
update t_user_info set password='792080' where name='test1476';
update t_user_info set password='727626' where name='test1477';
update t_user_info set password='993143' where name='test1478';
update t_user_info set password='607636' where name='test1479';
update t_user_info set password='392544' where name='test1480';
update t_user_info set password='539771' where name='test1481';
update t_user_info set password='643974' where name='test1482';
update t_user_info set password='505194' where name='test1483';
update t_user_info set password='899348' where name='test1484';
update t_user_info set password='767987' where name='test1485';
update t_user_info set password='342656' where name='test1486';
update t_user_info set password='763856' where name='test1487';
update t_user_info set password='382452' where name='test1488';
update t_user_info set password='337166' where name='test1489';
update t_user_info set password='796248' where name='test1490';
update t_user_info set password='682109' where name='test1491';
update t_user_info set password='286737' where name='test1492';
update t_user_info set password='777175' where name='test1493';
update t_user_info set password='819989' where name='test1494';
update t_user_info set password='745634' where name='test1495';
update t_user_info set password='977088' where name='test1496';
update t_user_info set password='286348' where name='test1497';
update t_user_info set password='781523' where name='test1498';
update t_user_info set password='565224' where name='test1499';
update t_user_info set password='973174' where name='test1500';
update t_user_info set password='899099' where name='test1501';
update t_user_info set password='435134' where name='test1502';
update t_user_info set password='582168' where name='test1503';
update t_user_info set password='612990' where name='test1504';
update t_user_info set password='214329' where name='test1505';
update t_user_info set password='591483' where name='test1506';
update t_user_info set password='561691' where name='test1507';
update t_user_info set password='340734' where name='test1508';
update t_user_info set password='690673' where name='test1509';
update t_user_info set password='152078' where name='test1510';
update t_user_info set password='448352' where name='test1511';
update t_user_info set password='929400' where name='test1512';
update t_user_info set password='205685' where name='test1513';
update t_user_info set password='562126' where name='test1514';
update t_user_info set password='447987' where name='test1515';
update t_user_info set password='281727' where name='test1516';
update t_user_info set password='533176' where name='test1517';
update t_user_info set password='528853' where name='test1518';
update t_user_info set password='804987' where name='test1519';
update t_user_info set password='578258' where name='test1520';
update t_user_info set password='329283' where name='test1521';
update t_user_info set password='276077' where name='test1522';
update t_user_info set password='744318' where name='test1523';
update t_user_info set password='758062' where name='test1524';
update t_user_info set password='351658' where name='test1525';
update t_user_info set password='274866' where name='test1526';
update t_user_info set password='526883' where name='test1527';
update t_user_info set password='606894' where name='test1528';
update t_user_info set password='998839' where name='test1529';
update t_user_info set password='107691' where name='test1530';
update t_user_info set password='482013' where name='test1531';
update t_user_info set password='840235' where name='test1532';
update t_user_info set password='305417' where name='test1533';
update t_user_info set password='613447' where name='test1534';
update t_user_info set password='117043' where name='test1535';
update t_user_info set password='140467' where name='test1536';
update t_user_info set password='754908' where name='test1537';
update t_user_info set password='730640' where name='test1538';
update t_user_info set password='263907' where name='test1539';
update t_user_info set password='629119' where name='test1540';
update t_user_info set password='951465' where name='test1541';
update t_user_info set password='475373' where name='test1542';
update t_user_info set password='972455' where name='test1543';
update t_user_info set password='597943' where name='test1544';
update t_user_info set password='560118' where name='test1545';
update t_user_info set password='673302' where name='test1546';
update t_user_info set password='998032' where name='test1547';
update t_user_info set password='645440' where name='test1548';
update t_user_info set password='765583' where name='test1549';
update t_user_info set password='700978' where name='test1550';
update t_user_info set password='409906' where name='test1551';
update t_user_info set password='944077' where name='test1552';
update t_user_info set password='630114' where name='test1553';
update t_user_info set password='511723' where name='test1554';
update t_user_info set password='793793' where name='test1555';
update t_user_info set password='255430' where name='test1556';
update t_user_info set password='823407' where name='test1557';
update t_user_info set password='636112' where name='test1558';
update t_user_info set password='122838' where name='test1559';
update t_user_info set password='622529' where name='test1560';
update t_user_info set password='578592' where name='test1561';
update t_user_info set password='866602' where name='test1562';
update t_user_info set password='739966' where name='test1563';
update t_user_info set password='251585' where name='test1564';
update t_user_info set password='221116' where name='test1565';
update t_user_info set password='137114' where name='test1566';
update t_user_info set password='632644' where name='test1567';
update t_user_info set password='938387' where name='test1568';
update t_user_info set password='187924' where name='test1569';
update t_user_info set password='108399' where name='test1570';
update t_user_info set password='861295' where name='test1571';
update t_user_info set password='766563' where name='test1572';
update t_user_info set password='999051' where name='test1573';
update t_user_info set password='411316' where name='test1574';
update t_user_info set password='986958' where name='test1575';
update t_user_info set password='896926' where name='test1576';
update t_user_info set password='974769' where name='test1577';
update t_user_info set password='681057' where name='test1578';
update t_user_info set password='175729' where name='test1579';
update t_user_info set password='753472' where name='test1580';
update t_user_info set password='759820' where name='test1581';
update t_user_info set password='634906' where name='test1582';
update t_user_info set password='735594' where name='test1583';
update t_user_info set password='590928' where name='test1584';
update t_user_info set password='432167' where name='test1585';
update t_user_info set password='943141' where name='test1586';
update t_user_info set password='926420' where name='test1587';
update t_user_info set password='510181' where name='test1588';
update t_user_info set password='166544' where name='test1589';
update t_user_info set password='967145' where name='test1590';
update t_user_info set password='752409' where name='test1591';
update t_user_info set password='409112' where name='test1592';
update t_user_info set password='689287' where name='test1593';
update t_user_info set password='288735' where name='test1594';
update t_user_info set password='566531' where name='test1595';
update t_user_info set password='126056' where name='test1596';
update t_user_info set password='827963' where name='test1597';
update t_user_info set password='199350' where name='test1598';
update t_user_info set password='838843' where name='test1599';
update t_user_info set password='977315' where name='test1600';
update t_user_info set password='674278' where name='test1601';
update t_user_info set password='303290' where name='test1602';
update t_user_info set password='686268' where name='test1603';
update t_user_info set password='734932' where name='test1604';
update t_user_info set password='397479' where name='test1605';
update t_user_info set password='674997' where name='test1606';
update t_user_info set password='853315' where name='test1607';
update t_user_info set password='663130' where name='test1608';
update t_user_info set password='415988' where name='test1609';
update t_user_info set password='223857' where name='test1610';
update t_user_info set password='920367' where name='test1611';
update t_user_info set password='354459' where name='test1612';
update t_user_info set password='330006' where name='test1613';
update t_user_info set password='654583' where name='test1614';
update t_user_info set password='663808' where name='test1615';
update t_user_info set password='891889' where name='test1616';
update t_user_info set password='475380' where name='test1617';
update t_user_info set password='715563' where name='test1618';
update t_user_info set password='609452' where name='test1619';
update t_user_info set password='740953' where name='test1620';
update t_user_info set password='173835' where name='test1621';
update t_user_info set password='287556' where name='test1622';
update t_user_info set password='491477' where name='test1623';
update t_user_info set password='287384' where name='test1624';
update t_user_info set password='388897' where name='test1625';
update t_user_info set password='378805' where name='test1626';
update t_user_info set password='277126' where name='test1627';
update t_user_info set password='662134' where name='test1628';
update t_user_info set password='298612' where name='test1629';
update t_user_info set password='597731' where name='test1630';
update t_user_info set password='924104' where name='test1631';
update t_user_info set password='756822' where name='test1632';
update t_user_info set password='845992' where name='test1633';
update t_user_info set password='697432' where name='test1634';
update t_user_info set password='155115' where name='test1635';
update t_user_info set password='912432' where name='test1636';
update t_user_info set password='554729' where name='test1637';
update t_user_info set password='893816' where name='test1638';
update t_user_info set password='489587' where name='test1639';
update t_user_info set password='643566' where name='test1640';
update t_user_info set password='439426' where name='test1641';
update t_user_info set password='599541' where name='test1642';
update t_user_info set password='824776' where name='test1643';
update t_user_info set password='867554' where name='test1644';
update t_user_info set password='495482' where name='test1645';
update t_user_info set password='112794' where name='test1646';
update t_user_info set password='761263' where name='test1647';
update t_user_info set password='884770' where name='test1648';
update t_user_info set password='851510' where name='test1649';
update t_user_info set password='605886' where name='test1650';
update t_user_info set password='224942' where name='test1651';
update t_user_info set password='974699' where name='test1652';
update t_user_info set password='106825' where name='test1653';
update t_user_info set password='546840' where name='test1654';
update t_user_info set password='563587' where name='test1655';
update t_user_info set password='351027' where name='test1656';
update t_user_info set password='719226' where name='test1657';
update t_user_info set password='805356' where name='test1658';
update t_user_info set password='480899' where name='test1659';
update t_user_info set password='926141' where name='test1660';
update t_user_info set password='929164' where name='test1661';
update t_user_info set password='784236' where name='test1662';
update t_user_info set password='579299' where name='test1663';
update t_user_info set password='184280' where name='test1664';
update t_user_info set password='479676' where name='test1665';
update t_user_info set password='381567' where name='test1666';
update t_user_info set password='580689' where name='test1667';
update t_user_info set password='342478' where name='test1668';
update t_user_info set password='348085' where name='test1669';
update t_user_info set password='410019' where name='test1670';
update t_user_info set password='835434' where name='test1671';
update t_user_info set password='742290' where name='test1672';
update t_user_info set password='444085' where name='test1673';
update t_user_info set password='376690' where name='test1674';
update t_user_info set password='788100' where name='test1675';
update t_user_info set password='180724' where name='test1676';
update t_user_info set password='223793' where name='test1677';
update t_user_info set password='271768' where name='test1678';
update t_user_info set password='118516' where name='test1679';
update t_user_info set password='426991' where name='test1680';
update t_user_info set password='600760' where name='test1681';
update t_user_info set password='912019' where name='test1682';
update t_user_info set password='660387' where name='test1683';
update t_user_info set password='993975' where name='test1684';
update t_user_info set password='351706' where name='test1685';
update t_user_info set password='217707' where name='test1686';
update t_user_info set password='478696' where name='test1687';
update t_user_info set password='855963' where name='test1688';
update t_user_info set password='623550' where name='test1689';
update t_user_info set password='488264' where name='test1690';
update t_user_info set password='842570' where name='test1691';
update t_user_info set password='655827' where name='test1692';
update t_user_info set password='631073' where name='test1693';
update t_user_info set password='830960' where name='test1694';
update t_user_info set password='707279' where name='test1695';
update t_user_info set password='404660' where name='test1696';
update t_user_info set password='169534' where name='test1697';
update t_user_info set password='505340' where name='test1698';
update t_user_info set password='100128' where name='test1699';
update t_user_info set password='539147' where name='test1700';
update t_user_info set password='825350' where name='test1701';
update t_user_info set password='630271' where name='test1702';
update t_user_info set password='613585' where name='test1703';
update t_user_info set password='546045' where name='test1704';
update t_user_info set password='787702' where name='test1705';
update t_user_info set password='489616' where name='test1706';
update t_user_info set password='268322' where name='test1707';
update t_user_info set password='597423' where name='test1708';
update t_user_info set password='198295' where name='test1709';
update t_user_info set password='395283' where name='test1710';
update t_user_info set password='187515' where name='test1711';
update t_user_info set password='636606' where name='test1712';
update t_user_info set password='152338' where name='test1713';
update t_user_info set password='855180' where name='test1714';
update t_user_info set password='261940' where name='test1715';
update t_user_info set password='675398' where name='test1716';
update t_user_info set password='666954' where name='test1717';
update t_user_info set password='977431' where name='test1718';
update t_user_info set password='851022' where name='test1719';
update t_user_info set password='199254' where name='test1720';
update t_user_info set password='621544' where name='test1721';
update t_user_info set password='439574' where name='test1722';
update t_user_info set password='458629' where name='test1723';
update t_user_info set password='644981' where name='test1724';
update t_user_info set password='985614' where name='test1725';
update t_user_info set password='540066' where name='test1726';
update t_user_info set password='722709' where name='test1727';
update t_user_info set password='120496' where name='test1728';
update t_user_info set password='417060' where name='test1729';
update t_user_info set password='373029' where name='test1730';
update t_user_info set password='801958' where name='test1731';
update t_user_info set password='756799' where name='test1732';
update t_user_info set password='662301' where name='test1733';
update t_user_info set password='735535' where name='test1734';
update t_user_info set password='610177' where name='test1735';
update t_user_info set password='762451' where name='test1736';
update t_user_info set password='468505' where name='test1737';
update t_user_info set password='393267' where name='test1738';
update t_user_info set password='917128' where name='test1739';
update t_user_info set password='103230' where name='test1740';
update t_user_info set password='291291' where name='test1741';
update t_user_info set password='206260' where name='test1742';
update t_user_info set password='552621' where name='test1743';
update t_user_info set password='416711' where name='test1744';
update t_user_info set password='665109' where name='test1745';
update t_user_info set password='262743' where name='test1746';
update t_user_info set password='743289' where name='test1747';
update t_user_info set password='138164' where name='test1748';
update t_user_info set password='156117' where name='test1749';
update t_user_info set password='380729' where name='test1750';
update t_user_info set password='916446' where name='test1751';
update t_user_info set password='953324' where name='test1752';
update t_user_info set password='375371' where name='test1753';
update t_user_info set password='600902' where name='test1754';
update t_user_info set password='428691' where name='test1755';
update t_user_info set password='232476' where name='test1756';
update t_user_info set password='796776' where name='test1757';
update t_user_info set password='129348' where name='test1758';
update t_user_info set password='619865' where name='test1759';
update t_user_info set password='553448' where name='test1760';
update t_user_info set password='886644' where name='test1761';
update t_user_info set password='194074' where name='test1762';
update t_user_info set password='260872' where name='test1763';
update t_user_info set password='643838' where name='test1764';
update t_user_info set password='747527' where name='test1765';
update t_user_info set password='836533' where name='test1766';
update t_user_info set password='560487' where name='test1767';
update t_user_info set password='545110' where name='test1768';
update t_user_info set password='500223' where name='test1769';
update t_user_info set password='971104' where name='test1770';
update t_user_info set password='389179' where name='test1771';
update t_user_info set password='663438' where name='test1772';
update t_user_info set password='173771' where name='test1773';
update t_user_info set password='481722' where name='test1774';
update t_user_info set password='165159' where name='test1775';
update t_user_info set password='642270' where name='test1776';
update t_user_info set password='449139' where name='test1777';
update t_user_info set password='586137' where name='test1778';
update t_user_info set password='825431' where name='test1779';
update t_user_info set password='290876' where name='test1780';
update t_user_info set password='456490' where name='test1781';
update t_user_info set password='244538' where name='test1782';
update t_user_info set password='384422' where name='test1783';
update t_user_info set password='971890' where name='test1784';
update t_user_info set password='950411' where name='test1785';
update t_user_info set password='226457' where name='test1786';
update t_user_info set password='911413' where name='test1787';
update t_user_info set password='660971' where name='test1788';
update t_user_info set password='341554' where name='test1789';
update t_user_info set password='516525' where name='test1790';
update t_user_info set password='604422' where name='test1791';
update t_user_info set password='861037' where name='test1792';
update t_user_info set password='307905' where name='test1793';
update t_user_info set password='869687' where name='test1794';
update t_user_info set password='548306' where name='test1795';
update t_user_info set password='206150' where name='test1796';
update t_user_info set password='973632' where name='test1797';
update t_user_info set password='149478' where name='test1798';
update t_user_info set password='367986' where name='test1799';
update t_user_info set password='770980' where name='test1800';
update t_user_info set password='959428' where name='test1801';
update t_user_info set password='998500' where name='test1802';
update t_user_info set password='844616' where name='test1803';
update t_user_info set password='684390' where name='test1804';
update t_user_info set password='940175' where name='test1805';
update t_user_info set password='126165' where name='test1806';
update t_user_info set password='631287' where name='test1807';
update t_user_info set password='148542' where name='test1808';
update t_user_info set password='132023' where name='test1809';
update t_user_info set password='719449' where name='test1810';
update t_user_info set password='830844' where name='test1811';
update t_user_info set password='212448' where name='test1812';
update t_user_info set password='297269' where name='test1813';
update t_user_info set password='280900' where name='test1814';
update t_user_info set password='735845' where name='test1815';
update t_user_info set password='674791' where name='test1816';
update t_user_info set password='874402' where name='test1817';
update t_user_info set password='861112' where name='test1818';
update t_user_info set password='989723' where name='test1819';
update t_user_info set password='145036' where name='test1820';
update t_user_info set password='135342' where name='test1821';
update t_user_info set password='634586' where name='test1822';
update t_user_info set password='569694' where name='test1823';
update t_user_info set password='103687' where name='test1824';
update t_user_info set password='142127' where name='test1825';
update t_user_info set password='390722' where name='test1826';
update t_user_info set password='940932' where name='test1827';
update t_user_info set password='252343' where name='test1828';
update t_user_info set password='249408' where name='test1829';
update t_user_info set password='631450' where name='test1830';
update t_user_info set password='558401' where name='test1831';
update t_user_info set password='705689' where name='test1832';
update t_user_info set password='635340' where name='test1833';
update t_user_info set password='914602' where name='test1834';
update t_user_info set password='559974' where name='test1835';
update t_user_info set password='108781' where name='test1836';
update t_user_info set password='968189' where name='test1837';
update t_user_info set password='867101' where name='test1838';
update t_user_info set password='160012' where name='test1839';
update t_user_info set password='428061' where name='test1840';
update t_user_info set password='714156' where name='test1841';
update t_user_info set password='759644' where name='test1842';
update t_user_info set password='232155' where name='test1843';
update t_user_info set password='991531' where name='test1844';
update t_user_info set password='985858' where name='test1845';
update t_user_info set password='278406' where name='test1846';
update t_user_info set password='591062' where name='test1847';
update t_user_info set password='227111' where name='test1848';
update t_user_info set password='127453' where name='test1849';
update t_user_info set password='221168' where name='test1850';
update t_user_info set password='646169' where name='test1851';
update t_user_info set password='595076' where name='test1852';
update t_user_info set password='771578' where name='test1853';
update t_user_info set password='485629' where name='test1854';
update t_user_info set password='273840' where name='test1855';
update t_user_info set password='505223' where name='test1856';
update t_user_info set password='993709' where name='test1857';
update t_user_info set password='168602' where name='test1858';
update t_user_info set password='621590' where name='test1859';
update t_user_info set password='680975' where name='test1860';
update t_user_info set password='468136' where name='test1861';
update t_user_info set password='963439' where name='test1862';
update t_user_info set password='454474' where name='test1863';
update t_user_info set password='660633' where name='test1864';
update t_user_info set password='234333' where name='test1865';
update t_user_info set password='290343' where name='test1866';
update t_user_info set password='435734' where name='test1867';
update t_user_info set password='714819' where name='test1868';
update t_user_info set password='975179' where name='test1869';
update t_user_info set password='454404' where name='test1870';
update t_user_info set password='458710' where name='test1871';
update t_user_info set password='455574' where name='test1872';
update t_user_info set password='526429' where name='test1873';
update t_user_info set password='473764' where name='test1874';
update t_user_info set password='637483' where name='test1875';
update t_user_info set password='168396' where name='test1876';
update t_user_info set password='473443' where name='test1877';
update t_user_info set password='602192' where name='test1878';
update t_user_info set password='486255' where name='test1879';
update t_user_info set password='361448' where name='test1880';
update t_user_info set password='920615' where name='test1881';
update t_user_info set password='359959' where name='test1882';
update t_user_info set password='437402' where name='test1883';
update t_user_info set password='198504' where name='test1884';
update t_user_info set password='304192' where name='test1885';
update t_user_info set password='957295' where name='test1886';
update t_user_info set password='403756' where name='test1887';
update t_user_info set password='228648' where name='test1888';
update t_user_info set password='729913' where name='test1889';
update t_user_info set password='492690' where name='test1890';
update t_user_info set password='160983' where name='test1891';
update t_user_info set password='788337' where name='test1892';
update t_user_info set password='259336' where name='test1893';
update t_user_info set password='398758' where name='test1894';
update t_user_info set password='362637' where name='test1895';
update t_user_info set password='482185' where name='test1896';
update t_user_info set password='807672' where name='test1897';
update t_user_info set password='355225' where name='test1898';
update t_user_info set password='842755' where name='test1899';
update t_user_info set password='903390' where name='test1900';
update t_user_info set password='982210' where name='test1901';
update t_user_info set password='891063' where name='test1902';
update t_user_info set password='530950' where name='test1903';
update t_user_info set password='930834' where name='test1904';
update t_user_info set password='223813' where name='test1905';
update t_user_info set password='901257' where name='test1906';
update t_user_info set password='278899' where name='test1907';
update t_user_info set password='304400' where name='test1908';
update t_user_info set password='298887' where name='test1909';
update t_user_info set password='248252' where name='test1910';
update t_user_info set password='158178' where name='test1911';
update t_user_info set password='395362' where name='test1912';
update t_user_info set password='170548' where name='test1913';
update t_user_info set password='176961' where name='test1914';
update t_user_info set password='433672' where name='test1915';
update t_user_info set password='185875' where name='test1916';
update t_user_info set password='136612' where name='test1917';
update t_user_info set password='627230' where name='test1918';
update t_user_info set password='205088' where name='test1919';
update t_user_info set password='563958' where name='test1920';
update t_user_info set password='641868' where name='test1921';
update t_user_info set password='564757' where name='test1922';
update t_user_info set password='481800' where name='test1923';
update t_user_info set password='336579' where name='test1924';
update t_user_info set password='589280' where name='test1925';
update t_user_info set password='768128' where name='test1926';
update t_user_info set password='458555' where name='test1927';
update t_user_info set password='330595' where name='test1928';
update t_user_info set password='708388' where name='test1929';
update t_user_info set password='628550' where name='test1930';
update t_user_info set password='902388' where name='test1931';
update t_user_info set password='967116' where name='test1932';
update t_user_info set password='445901' where name='test1933';
update t_user_info set password='674495' where name='test1934';
update t_user_info set password='948051' where name='test1935';
update t_user_info set password='829778' where name='test1936';
update t_user_info set password='327656' where name='test1937';
update t_user_info set password='324114' where name='test1938';
update t_user_info set password='540748' where name='test1939';
update t_user_info set password='380249' where name='test1940';
update t_user_info set password='153727' where name='test1941';
update t_user_info set password='168452' where name='test1942';
update t_user_info set password='718536' where name='test1943';
update t_user_info set password='371123' where name='test1944';
update t_user_info set password='786493' where name='test1945';
update t_user_info set password='911749' where name='test1946';
update t_user_info set password='892189' where name='test1947';
update t_user_info set password='999834' where name='test1948';
update t_user_info set password='687579' where name='test1949';
update t_user_info set password='171059' where name='test1950';
update t_user_info set password='229499' where name='test1951';
update t_user_info set password='838137' where name='test1952';
update t_user_info set password='171372' where name='test1953';
update t_user_info set password='901092' where name='test1954';
update t_user_info set password='995672' where name='test1955';
update t_user_info set password='157222' where name='test1956';
update t_user_info set password='408966' where name='test1957';
update t_user_info set password='382769' where name='test1958';
update t_user_info set password='596673' where name='test1959';
update t_user_info set password='785306' where name='test1960';
update t_user_info set password='538317' where name='test1961';
update t_user_info set password='260002' where name='test1962';
update t_user_info set password='389378' where name='test1963';
update t_user_info set password='843554' where name='test1964';
update t_user_info set password='577456' where name='test1965';
update t_user_info set password='266930' where name='test1966';
update t_user_info set password='812184' where name='test1967';
update t_user_info set password='611976' where name='test1968';
update t_user_info set password='970365' where name='test1969';
update t_user_info set password='515788' where name='test1970';
update t_user_info set password='539757' where name='test1971';
update t_user_info set password='748062' where name='test1972';
update t_user_info set password='354702' where name='test1973';
update t_user_info set password='493060' where name='test1974';
update t_user_info set password='933993' where name='test1975';
update t_user_info set password='623783' where name='test1976';
update t_user_info set password='827375' where name='test1977';
update t_user_info set password='643151' where name='test1978';
update t_user_info set password='753775' where name='test1979';
update t_user_info set password='348042' where name='test1980';
update t_user_info set password='427961' where name='test1981';
update t_user_info set password='637814' where name='test1982';
update t_user_info set password='145497' where name='test1983';
update t_user_info set password='374547' where name='test1984';
update t_user_info set password='897548' where name='test1985';
update t_user_info set password='401396' where name='test1986';
update t_user_info set password='830787' where name='test1987';
update t_user_info set password='327029' where name='test1988';
update t_user_info set password='793402' where name='test1989';
update t_user_info set password='276168' where name='test1990';
update t_user_info set password='488348' where name='test1991';
update t_user_info set password='505896' where name='test1992';
update t_user_info set password='781310' where name='test1993';
update t_user_info set password='378332' where name='test1994';
update t_user_info set password='788177' where name='test1995';
update t_user_info set password='241660' where name='test1996';
update t_user_info set password='558070' where name='test1997';
update t_user_info set password='402453' where name='test1998';
update t_user_info set password='695363' where name='test1999';
update t_user_info set password='322885' where name='test2000';
update t_user_info set password='883319' where name='test2001';
update t_user_info set password='392860' where name='test2002';
update t_user_info set password='646883' where name='test2003';
update t_user_info set password='457291' where name='test2004';
update t_user_info set password='644126' where name='test2005';
update t_user_info set password='372839' where name='test2006';
update t_user_info set password='968680' where name='test2007';
update t_user_info set password='331356' where name='test2008';
update t_user_info set password='870813' where name='test2009';
update t_user_info set password='850993' where name='test2010';
update t_user_info set password='499856' where name='test2011';
update t_user_info set password='343937' where name='test2012';
update t_user_info set password='759342' where name='test2013';
update t_user_info set password='116504' where name='test2014';
update t_user_info set password='740915' where name='test2015';
update t_user_info set password='973996' where name='test2016';
update t_user_info set password='425487' where name='test2017';
update t_user_info set password='230796' where name='test2018';
update t_user_info set password='916492' where name='test2019';
update t_user_info set password='585700' where name='test2020';
update t_user_info set password='321472' where name='test2021';
update t_user_info set password='600303' where name='test2022';
update t_user_info set password='744322' where name='test2023';
update t_user_info set password='987635' where name='test2024';
update t_user_info set password='926893' where name='test2025';
update t_user_info set password='237699' where name='test2026';
update t_user_info set password='826049' where name='test2027';
update t_user_info set password='213931' where name='test2028';
update t_user_info set password='618639' where name='test2029';
update t_user_info set password='846206' where name='test2030';
update t_user_info set password='925922' where name='test2031';
update t_user_info set password='352351' where name='test2032';
update t_user_info set password='684840' where name='test2033';
update t_user_info set password='684954' where name='test2034';
update t_user_info set password='395124' where name='test2035';
update t_user_info set password='260733' where name='test2036';
update t_user_info set password='181164' where name='test2037';
update t_user_info set password='480164' where name='test2038';
update t_user_info set password='381462' where name='test2039';
update t_user_info set password='867369' where name='test2040';
update t_user_info set password='174274' where name='test2041';
update t_user_info set password='337499' where name='test2042';
update t_user_info set password='915568' where name='test2043';
update t_user_info set password='528725' where name='test2044';
update t_user_info set password='847198' where name='test2045';
update t_user_info set password='528099' where name='test2046';
update t_user_info set password='880988' where name='test2047';
update t_user_info set password='331925' where name='test2048';
update t_user_info set password='705963' where name='test2049';
update t_user_info set password='870314' where name='test2050';
update t_user_info set password='764396' where name='test2051';
update t_user_info set password='462468' where name='test2052';
update t_user_info set password='691216' where name='test2053';
update t_user_info set password='581949' where name='test2054';
update t_user_info set password='536994' where name='test2055';
update t_user_info set password='400458' where name='test2056';
update t_user_info set password='875396' where name='test2057';
update t_user_info set password='614256' where name='test2058';
update t_user_info set password='611080' where name='test2059';
update t_user_info set password='103043' where name='test2060';
update t_user_info set password='551443' where name='test2061';
update t_user_info set password='700536' where name='test2062';
update t_user_info set password='586244' where name='test2063';
update t_user_info set password='958188' where name='test2064';
update t_user_info set password='369011' where name='test2065';
update t_user_info set password='334984' where name='test2066';
update t_user_info set password='221020' where name='test2067';
update t_user_info set password='414727' where name='test2068';
update t_user_info set password='982742' where name='test2069';
update t_user_info set password='288737' where name='test2070';
update t_user_info set password='945433' where name='test2071';
update t_user_info set password='151058' where name='test2072';
update t_user_info set password='774476' where name='test2073';
update t_user_info set password='924094' where name='test2074';
update t_user_info set password='283413' where name='test2075';
update t_user_info set password='266070' where name='test2076';
update t_user_info set password='914776' where name='test2077';
update t_user_info set password='153303' where name='test2078';
update t_user_info set password='250867' where name='test2079';
update t_user_info set password='398882' where name='test2080';
update t_user_info set password='691223' where name='test2081';
update t_user_info set password='420791' where name='test2082';
update t_user_info set password='650188' where name='test2083';
update t_user_info set password='798935' where name='test2084';
update t_user_info set password='189826' where name='test2085';
update t_user_info set password='967397' where name='test2086';
update t_user_info set password='296664' where name='test2087';
update t_user_info set password='637347' where name='test2088';
update t_user_info set password='696395' where name='test2089';
update t_user_info set password='918962' where name='test2090';
update t_user_info set password='616003' where name='test2091';
update t_user_info set password='580240' where name='test2092';
update t_user_info set password='239460' where name='test2093';
update t_user_info set password='522716' where name='test2094';
update t_user_info set password='641445' where name='test2095';
update t_user_info set password='369466' where name='test2096';
update t_user_info set password='340793' where name='test2097';
update t_user_info set password='903033' where name='test2098';
update t_user_info set password='493743' where name='test2099';
update t_user_info set password='916940' where name='test2100';
update t_user_info set password='584877' where name='test2101';
update t_user_info set password='448000' where name='test2102';
update t_user_info set password='606638' where name='test2103';
update t_user_info set password='897599' where name='test2104';
update t_user_info set password='497922' where name='test2105';
update t_user_info set password='978987' where name='test2106';
update t_user_info set password='338043' where name='test2107';
update t_user_info set password='780441' where name='test2108';
update t_user_info set password='515396' where name='test2109';
update t_user_info set password='775384' where name='test2110';
update t_user_info set password='118772' where name='test2111';
update t_user_info set password='716859' where name='test2112';
update t_user_info set password='976733' where name='test2113';
update t_user_info set password='839470' where name='test2114';
update t_user_info set password='461347' where name='test2115';
update t_user_info set password='862883' where name='test2116';
update t_user_info set password='567765' where name='test2117';
update t_user_info set password='548167' where name='test2118';
update t_user_info set password='291974' where name='test2119';
update t_user_info set password='997995' where name='test2120';
update t_user_info set password='799408' where name='test2121';
update t_user_info set password='440274' where name='test2122';
update t_user_info set password='908994' where name='test2123';
update t_user_info set password='506558' where name='test2124';
update t_user_info set password='442496' where name='test2125';
update t_user_info set password='131604' where name='test2126';
update t_user_info set password='971005' where name='test2127';
update t_user_info set password='136193' where name='test2128';
update t_user_info set password='223111' where name='test2129';
update t_user_info set password='224434' where name='test2130';
update t_user_info set password='513233' where name='test2131';
update t_user_info set password='677110' where name='test2132';
update t_user_info set password='847654' where name='test2133';
update t_user_info set password='953836' where name='test2134';
update t_user_info set password='217848' where name='test2135';
update t_user_info set password='989391' where name='test2136';
update t_user_info set password='821166' where name='test2137';
update t_user_info set password='654283' where name='test2138';
update t_user_info set password='141332' where name='test2139';
update t_user_info set password='445571' where name='test2140';
update t_user_info set password='786339' where name='test2141';
update t_user_info set password='211771' where name='test2142';
update t_user_info set password='453319' where name='test2143';
update t_user_info set password='177724' where name='test2144';
update t_user_info set password='466446' where name='test2145';
update t_user_info set password='222170' where name='test2146';
update t_user_info set password='877822' where name='test2147';
update t_user_info set password='281337' where name='test2148';
update t_user_info set password='265528' where name='test2149';
update t_user_info set password='785936' where name='test2150';
update t_user_info set password='745620' where name='test2151';
update t_user_info set password='406013' where name='test2152';
update t_user_info set password='597539' where name='test2153';
update t_user_info set password='909998' where name='test2154';
update t_user_info set password='269888' where name='test2155';
update t_user_info set password='643405' where name='test2156';
update t_user_info set password='675660' where name='test2157';
update t_user_info set password='365012' where name='test2158';
update t_user_info set password='977481' where name='test2159';
update t_user_info set password='648910' where name='test2160';
update t_user_info set password='585595' where name='test2161';
update t_user_info set password='774023' where name='test2162';
update t_user_info set password='536754' where name='test2163';
update t_user_info set password='646884' where name='test2164';
update t_user_info set password='657744' where name='test2165';
update t_user_info set password='799007' where name='test2166';
update t_user_info set password='757388' where name='test2167';
update t_user_info set password='891441' where name='test2168';
update t_user_info set password='863135' where name='test2169';
update t_user_info set password='373864' where name='test2170';
update t_user_info set password='547686' where name='test2171';
update t_user_info set password='943523' where name='test2172';
update t_user_info set password='579143' where name='test2173';
update t_user_info set password='442607' where name='test2174';
update t_user_info set password='149351' where name='test2175';
update t_user_info set password='721414' where name='test2176';
update t_user_info set password='577010' where name='test2177';
update t_user_info set password='745403' where name='test2178';
update t_user_info set password='872793' where name='test2179';
update t_user_info set password='619443' where name='test2180';
update t_user_info set password='649812' where name='test2181';
update t_user_info set password='209060' where name='test2182';
update t_user_info set password='205393' where name='test2183';
update t_user_info set password='133821' where name='test2184';
update t_user_info set password='349666' where name='test2185';
update t_user_info set password='311711' where name='test2186';
update t_user_info set password='991755' where name='test2187';
update t_user_info set password='441188' where name='test2188';
update t_user_info set password='693705' where name='test2189';
update t_user_info set password='274618' where name='test2190';
update t_user_info set password='487492' where name='test2191';
update t_user_info set password='896874' where name='test2192';
update t_user_info set password='888088' where name='test2193';
update t_user_info set password='523864' where name='test2194';
update t_user_info set password='882797' where name='test2195';
update t_user_info set password='115512' where name='test2196';
update t_user_info set password='585055' where name='test2197';
update t_user_info set password='811180' where name='test2198';
update t_user_info set password='597937' where name='test2199';
update t_user_info set password='843021' where name='test2200';
update t_user_info set password='283421' where name='test2201';
update t_user_info set password='777215' where name='test2202';
update t_user_info set password='612146' where name='test2203';
update t_user_info set password='793969' where name='test2204';
update t_user_info set password='998669' where name='test2205';
update t_user_info set password='506857' where name='test2206';
update t_user_info set password='907018' where name='test2207';
update t_user_info set password='102995' where name='test2208';
update t_user_info set password='791109' where name='test2209';
update t_user_info set password='596149' where name='test2210';
update t_user_info set password='691581' where name='test2211';
update t_user_info set password='466619' where name='test2212';
update t_user_info set password='847593' where name='test2213';
update t_user_info set password='104293' where name='test2214';
update t_user_info set password='890543' where name='test2215';
update t_user_info set password='827996' where name='test2216';
update t_user_info set password='896014' where name='test2217';
update t_user_info set password='452044' where name='test2218';
update t_user_info set password='723886' where name='test2219';
update t_user_info set password='681904' where name='test2220';
update t_user_info set password='271206' where name='test2221';
update t_user_info set password='865567' where name='test2222';
update t_user_info set password='594639' where name='test2223';
update t_user_info set password='165347' where name='test2224';
update t_user_info set password='106828' where name='test2225';
update t_user_info set password='840769' where name='test2226';
update t_user_info set password='178866' where name='test2227';
update t_user_info set password='358122' where name='test2228';
update t_user_info set password='714998' where name='test2229';
update t_user_info set password='625127' where name='test2230';
update t_user_info set password='299131' where name='test2231';
update t_user_info set password='219350' where name='test2232';
update t_user_info set password='273364' where name='test2233';
update t_user_info set password='926040' where name='test2234';
update t_user_info set password='655708' where name='test2235';
update t_user_info set password='999138' where name='test2236';
update t_user_info set password='191103' where name='test2237';
update t_user_info set password='145098' where name='test2238';
update t_user_info set password='438733' where name='test2239';
update t_user_info set password='578547' where name='test2240';
update t_user_info set password='645646' where name='test2241';
update t_user_info set password='561439' where name='test2242';
update t_user_info set password='295796' where name='test2243';
update t_user_info set password='852375' where name='test2244';
update t_user_info set password='653679' where name='test2245';
update t_user_info set password='253372' where name='test2246';
update t_user_info set password='810820' where name='test2247';
update t_user_info set password='642606' where name='test2248';
update t_user_info set password='654620' where name='test2249';
update t_user_info set password='132193' where name='test2250';
update t_user_info set password='325636' where name='test2251';
update t_user_info set password='368986' where name='test2252';
update t_user_info set password='488907' where name='test2253';
update t_user_info set password='758212' where name='test2254';
update t_user_info set password='233544' where name='test2255';
update t_user_info set password='690996' where name='test2256';
update t_user_info set password='249460' where name='test2257';
update t_user_info set password='346456' where name='test2258';
update t_user_info set password='924530' where name='test2259';
update t_user_info set password='373960' where name='test2260';
update t_user_info set password='890011' where name='test2261';
update t_user_info set password='386611' where name='test2262';
update t_user_info set password='459572' where name='test2263';
update t_user_info set password='875169' where name='test2264';
update t_user_info set password='182118' where name='test2265';
update t_user_info set password='558915' where name='test2266';
update t_user_info set password='580828' where name='test2267';
update t_user_info set password='721813' where name='test2268';
update t_user_info set password='667387' where name='test2269';
update t_user_info set password='532374' where name='test2270';
update t_user_info set password='418093' where name='test2271';
update t_user_info set password='630956' where name='test2272';
update t_user_info set password='933752' where name='test2273';
update t_user_info set password='603467' where name='test2274';
update t_user_info set password='230560' where name='test2275';
update t_user_info set password='775473' where name='test2276';
update t_user_info set password='772843' where name='test2277';
update t_user_info set password='368363' where name='test2278';
update t_user_info set password='744097' where name='test2279';
update t_user_info set password='697641' where name='test2280';
update t_user_info set password='203650' where name='test2281';
update t_user_info set password='103654' where name='test2282';
update t_user_info set password='109291' where name='test2283';
update t_user_info set password='335735' where name='test2284';
update t_user_info set password='679217' where name='test2285';
update t_user_info set password='662764' where name='test2286';
update t_user_info set password='968197' where name='test2287';
update t_user_info set password='650227' where name='test2288';
update t_user_info set password='694504' where name='test2289';
update t_user_info set password='929866' where name='test2290';
update t_user_info set password='729643' where name='test2291';
update t_user_info set password='605404' where name='test2292';
update t_user_info set password='869559' where name='test2293';
update t_user_info set password='298104' where name='test2294';
update t_user_info set password='395373' where name='test2295';
update t_user_info set password='128641' where name='test2296';
update t_user_info set password='460813' where name='test2297';
update t_user_info set password='134407' where name='test2298';
update t_user_info set password='615036' where name='test2299';
update t_user_info set password='965161' where name='test2300';
update t_user_info set password='872556' where name='test2301';
update t_user_info set password='419378' where name='test2302';
update t_user_info set password='815759' where name='test2303';
update t_user_info set password='692660' where name='test2304';
update t_user_info set password='613044' where name='test2305';
update t_user_info set password='964644' where name='test2306';
update t_user_info set password='452347' where name='test2307';
update t_user_info set password='423953' where name='test2308';
update t_user_info set password='801362' where name='test2309';
update t_user_info set password='318124' where name='test2310';
update t_user_info set password='210648' where name='test2311';
update t_user_info set password='115779' where name='test2312';
update t_user_info set password='520608' where name='test2313';
update t_user_info set password='542682' where name='test2314';
update t_user_info set password='943735' where name='test2315';
update t_user_info set password='181606' where name='test2316';
update t_user_info set password='164730' where name='test2317';
update t_user_info set password='598079' where name='test2318';
update t_user_info set password='703272' where name='test2319';
update t_user_info set password='763040' where name='test2320';
update t_user_info set password='330225' where name='test2321';
update t_user_info set password='523351' where name='test2322';
update t_user_info set password='463006' where name='test2323';
update t_user_info set password='335946' where name='test2324';
update t_user_info set password='219717' where name='test2325';
update t_user_info set password='993335' where name='test2326';
update t_user_info set password='932932' where name='test2327';
update t_user_info set password='428923' where name='test2328';
update t_user_info set password='252043' where name='test2329';
update t_user_info set password='320531' where name='test2330';
update t_user_info set password='520831' where name='test2331';
update t_user_info set password='712872' where name='test2332';
update t_user_info set password='560828' where name='test2333';
update t_user_info set password='648090' where name='test2334';
update t_user_info set password='885300' where name='test2335';
update t_user_info set password='226772' where name='test2336';
update t_user_info set password='851780' where name='test2337';
update t_user_info set password='738639' where name='test2338';
update t_user_info set password='395733' where name='test2339';
update t_user_info set password='307685' where name='test2340';
update t_user_info set password='376660' where name='test2341';
update t_user_info set password='122082' where name='test2342';
update t_user_info set password='718127' where name='test2343';
update t_user_info set password='255946' where name='test2344';
update t_user_info set password='533060' where name='test2345';
update t_user_info set password='775589' where name='test2346';
update t_user_info set password='374735' where name='test2347';
update t_user_info set password='334338' where name='test2348';
update t_user_info set password='166149' where name='test2349';
update t_user_info set password='556248' where name='test2350';
update t_user_info set password='777732' where name='test2351';
update t_user_info set password='359640' where name='test2352';
update t_user_info set password='676258' where name='test2353';
update t_user_info set password='201033' where name='test2354';
update t_user_info set password='593784' where name='test2355';
update t_user_info set password='215590' where name='test2356';
update t_user_info set password='869666' where name='test2357';
update t_user_info set password='768383' where name='test2358';
update t_user_info set password='911062' where name='test2359';
update t_user_info set password='619694' where name='test2360';
update t_user_info set password='604133' where name='test2361';
update t_user_info set password='750854' where name='test2362';
update t_user_info set password='420676' where name='test2363';
update t_user_info set password='778162' where name='test2364';
update t_user_info set password='345890' where name='test2365';
update t_user_info set password='407552' where name='test2366';
update t_user_info set password='956115' where name='test2367';
update t_user_info set password='983599' where name='test2368';
update t_user_info set password='608027' where name='test2369';
update t_user_info set password='955201' where name='test2370';
update t_user_info set password='881983' where name='test2371';
update t_user_info set password='610307' where name='test2372';
update t_user_info set password='138939' where name='test2373';
update t_user_info set password='202076' where name='test2374';
update t_user_info set password='199309' where name='test2375';
update t_user_info set password='168570' where name='test2376';
update t_user_info set password='393452' where name='test2377';
update t_user_info set password='554477' where name='test2378';
update t_user_info set password='579995' where name='test2379';
update t_user_info set password='328851' where name='test2380';
update t_user_info set password='825403' where name='test2381';
update t_user_info set password='455074' where name='test2382';
update t_user_info set password='726791' where name='test2383';
update t_user_info set password='348539' where name='test2384';
update t_user_info set password='154695' where name='test2385';
update t_user_info set password='170124' where name='test2386';
update t_user_info set password='887091' where name='test2387';
update t_user_info set password='602653' where name='test2388';
update t_user_info set password='608956' where name='test2389';
update t_user_info set password='291169' where name='test2390';
update t_user_info set password='532372' where name='test2391';
update t_user_info set password='585415' where name='test2392';
update t_user_info set password='213591' where name='test2393';
update t_user_info set password='336153' where name='test2394';
update t_user_info set password='689760' where name='test2395';
update t_user_info set password='953492' where name='test2396';
update t_user_info set password='312590' where name='test2397';
update t_user_info set password='369274' where name='test2398';
update t_user_info set password='925791' where name='test2399';
update t_user_info set password='735528' where name='test2400';
update t_user_info set password='976410' where name='test2401';
update t_user_info set password='155909' where name='test2402';
update t_user_info set password='104702' where name='test2403';
update t_user_info set password='206456' where name='test2404';
update t_user_info set password='297203' where name='test2405';
update t_user_info set password='661164' where name='test2406';
update t_user_info set password='590175' where name='test2407';
update t_user_info set password='825831' where name='test2408';
update t_user_info set password='757788' where name='test2409';
update t_user_info set password='277334' where name='test2410';
update t_user_info set password='602560' where name='test2411';
update t_user_info set password='693602' where name='test2412';
update t_user_info set password='782817' where name='test2413';
update t_user_info set password='169778' where name='test2414';
update t_user_info set password='271843' where name='test2415';
update t_user_info set password='341022' where name='test2416';
update t_user_info set password='650536' where name='test2417';
update t_user_info set password='392184' where name='test2418';
update t_user_info set password='750711' where name='test2419';
update t_user_info set password='116920' where name='test2420';
update t_user_info set password='541509' where name='test2421';
update t_user_info set password='725298' where name='test2422';
update t_user_info set password='251317' where name='test2423';
update t_user_info set password='583405' where name='test2424';
update t_user_info set password='452575' where name='test2425';
update t_user_info set password='156020' where name='test2426';
update t_user_info set password='284577' where name='test2427';
update t_user_info set password='129153' where name='test2428';
update t_user_info set password='939174' where name='test2429';
update t_user_info set password='763874' where name='test2430';
update t_user_info set password='256339' where name='test2431';
update t_user_info set password='466760' where name='test2432';
update t_user_info set password='747276' where name='test2433';
update t_user_info set password='966246' where name='test2434';
update t_user_info set password='717128' where name='test2435';
update t_user_info set password='173455' where name='test2436';
update t_user_info set password='173999' where name='test2437';
update t_user_info set password='601320' where name='test2438';
update t_user_info set password='279453' where name='test2439';
update t_user_info set password='705954' where name='test2440';
update t_user_info set password='931581' where name='test2441';
update t_user_info set password='903879' where name='test2442';
update t_user_info set password='954895' where name='test2443';
update t_user_info set password='582064' where name='test2444';
update t_user_info set password='706706' where name='test2445';
update t_user_info set password='423504' where name='test2446';
update t_user_info set password='356573' where name='test2447';
update t_user_info set password='380981' where name='test2448';
update t_user_info set password='970111' where name='test2449';
update t_user_info set password='439674' where name='test2450';
update t_user_info set password='994703' where name='test2451';
update t_user_info set password='735022' where name='test2452';
update t_user_info set password='632495' where name='test2453';
update t_user_info set password='243665' where name='test2454';
update t_user_info set password='832198' where name='test2455';
update t_user_info set password='853013' where name='test2456';
update t_user_info set password='975357' where name='test2457';
update t_user_info set password='971679' where name='test2458';
update t_user_info set password='260898' where name='test2459';
update t_user_info set password='696231' where name='test2460';
update t_user_info set password='957511' where name='test2461';
update t_user_info set password='381092' where name='test2462';
update t_user_info set password='986579' where name='test2463';
update t_user_info set password='610747' where name='test2464';
update t_user_info set password='591310' where name='test2465';
update t_user_info set password='945568' where name='test2466';
update t_user_info set password='125469' where name='test2467';
update t_user_info set password='540970' where name='test2468';
update t_user_info set password='278718' where name='test2469';
update t_user_info set password='663740' where name='test2470';
update t_user_info set password='294091' where name='test2471';
update t_user_info set password='755621' where name='test2472';
update t_user_info set password='316982' where name='test2473';
update t_user_info set password='395413' where name='test2474';
update t_user_info set password='540293' where name='test2475';
update t_user_info set password='812689' where name='test2476';
update t_user_info set password='914021' where name='test2477';
update t_user_info set password='212832' where name='test2478';
update t_user_info set password='619981' where name='test2479';
update t_user_info set password='803242' where name='test2480';
update t_user_info set password='990734' where name='test2481';
update t_user_info set password='632110' where name='test2482';
update t_user_info set password='410768' where name='test2483';
update t_user_info set password='227025' where name='test2484';
update t_user_info set password='309469' where name='test2485';
update t_user_info set password='133309' where name='test2486';
update t_user_info set password='225486' where name='test2487';
update t_user_info set password='464834' where name='test2488';
update t_user_info set password='926178' where name='test2489';
update t_user_info set password='549112' where name='test2490';
update t_user_info set password='287956' where name='test2491';
update t_user_info set password='802464' where name='test2492';
update t_user_info set password='349525' where name='test2493';
update t_user_info set password='690343' where name='test2494';
update t_user_info set password='987565' where name='test2495';
update t_user_info set password='765408' where name='test2496';
update t_user_info set password='974285' where name='test2497';
update t_user_info set password='810467' where name='test2498';
update t_user_info set password='272330' where name='test2499';
update t_user_info set password='169203' where name='test2500';
update t_user_info set password='608143' where name='test2501';
update t_user_info set password='453992' where name='test2502';
update t_user_info set password='935283' where name='test2503';
update t_user_info set password='802794' where name='test2504';
update t_user_info set password='370525' where name='test2505';
update t_user_info set password='202873' where name='test2506';
update t_user_info set password='986703' where name='test2507';
update t_user_info set password='687489' where name='test2508';
update t_user_info set password='104719' where name='test2509';
update t_user_info set password='101454' where name='test2510';
update t_user_info set password='143635' where name='test2511';
update t_user_info set password='488594' where name='test2512';
update t_user_info set password='234160' where name='test2513';
update t_user_info set password='703434' where name='test2514';
update t_user_info set password='806383' where name='test2515';
update t_user_info set password='373113' where name='test2516';
update t_user_info set password='786792' where name='test2517';
update t_user_info set password='990969' where name='test2518';
update t_user_info set password='196630' where name='test2519';
update t_user_info set password='207284' where name='test2520';
update t_user_info set password='186441' where name='test2521';
update t_user_info set password='680585' where name='test2522';
update t_user_info set password='534454' where name='test2523';
update t_user_info set password='879721' where name='test2524';
update t_user_info set password='735964' where name='test2525';
update t_user_info set password='506995' where name='test2526';
update t_user_info set password='166408' where name='test2527';
update t_user_info set password='952061' where name='test2528';
update t_user_info set password='122268' where name='test2529';
update t_user_info set password='223767' where name='test2530';
update t_user_info set password='348581' where name='test2531';
update t_user_info set password='742801' where name='test2532';
update t_user_info set password='234486' where name='test2533';
update t_user_info set password='688222' where name='test2534';
update t_user_info set password='971240' where name='test2535';
update t_user_info set password='730961' where name='test2536';
update t_user_info set password='660363' where name='test2537';
update t_user_info set password='802706' where name='test2538';
update t_user_info set password='674686' where name='test2539';
update t_user_info set password='639903' where name='test2540';
update t_user_info set password='519061' where name='test2541';
update t_user_info set password='435122' where name='test2542';
update t_user_info set password='610037' where name='test2543';
update t_user_info set password='602641' where name='test2544';
update t_user_info set password='945486' where name='test2545';
update t_user_info set password='148531' where name='test2546';
update t_user_info set password='433529' where name='test2547';
update t_user_info set password='477225' where name='test2548';
update t_user_info set password='531366' where name='test2549';
update t_user_info set password='403653' where name='test2550';
update t_user_info set password='556899' where name='test2551';
update t_user_info set password='158724' where name='test2552';
update t_user_info set password='864059' where name='test2553';
update t_user_info set password='745196' where name='test2554';
update t_user_info set password='864644' where name='test2555';
update t_user_info set password='424924' where name='test2556';
update t_user_info set password='341625' where name='test2557';
update t_user_info set password='835760' where name='test2558';
update t_user_info set password='300812' where name='test2559';
update t_user_info set password='127090' where name='test2560';
update t_user_info set password='337018' where name='test2561';
update t_user_info set password='354943' where name='test2562';
update t_user_info set password='176224' where name='test2563';
update t_user_info set password='965516' where name='test2564';
update t_user_info set password='959212' where name='test2565';
update t_user_info set password='456447' where name='test2566';
update t_user_info set password='372805' where name='test2567';
update t_user_info set password='758724' where name='test2568';
update t_user_info set password='793847' where name='test2569';
update t_user_info set password='605129' where name='test2570';
update t_user_info set password='769354' where name='test2571';
update t_user_info set password='841397' where name='test2572';
update t_user_info set password='542770' where name='test2573';
update t_user_info set password='610687' where name='test2574';
update t_user_info set password='547357' where name='test2575';
update t_user_info set password='447036' where name='test2576';
update t_user_info set password='430189' where name='test2577';
update t_user_info set password='106443' where name='test2578';
update t_user_info set password='885632' where name='test2579';
update t_user_info set password='216962' where name='test2580';
update t_user_info set password='797087' where name='test2581';
update t_user_info set password='466336' where name='test2582';
update t_user_info set password='607244' where name='test2583';
update t_user_info set password='102818' where name='test2584';
update t_user_info set password='451968' where name='test2585';
update t_user_info set password='572198' where name='test2586';
update t_user_info set password='712217' where name='test2587';
update t_user_info set password='106139' where name='test2588';
update t_user_info set password='607317' where name='test2589';
update t_user_info set password='904651' where name='test2590';
update t_user_info set password='811905' where name='test2591';
update t_user_info set password='401147' where name='test2592';
update t_user_info set password='513665' where name='test2593';
update t_user_info set password='419528' where name='test2594';
update t_user_info set password='469232' where name='test2595';
update t_user_info set password='285166' where name='test2596';
update t_user_info set password='121786' where name='test2597';
update t_user_info set password='335648' where name='test2598';
update t_user_info set password='420185' where name='test2599';
update t_user_info set password='324537' where name='test2600';
update t_user_info set password='745977' where name='test2601';
update t_user_info set password='555063' where name='test2602';
update t_user_info set password='121591' where name='test2603';
update t_user_info set password='854028' where name='test2604';
update t_user_info set password='169110' where name='test2605';
update t_user_info set password='621626' where name='test2606';
update t_user_info set password='107367' where name='test2607';
update t_user_info set password='190683' where name='test2608';
update t_user_info set password='686128' where name='test2609';
update t_user_info set password='930889' where name='test2610';
update t_user_info set password='951884' where name='test2611';
update t_user_info set password='764120' where name='test2612';
update t_user_info set password='502735' where name='test2613';
update t_user_info set password='487400' where name='test2614';
update t_user_info set password='273938' where name='test2615';
update t_user_info set password='918932' where name='test2616';
update t_user_info set password='928287' where name='test2617';
update t_user_info set password='276283' where name='test2618';
update t_user_info set password='520070' where name='test2619';
update t_user_info set password='930816' where name='test2620';
update t_user_info set password='342331' where name='test2621';
update t_user_info set password='776308' where name='test2622';
update t_user_info set password='847460' where name='test2623';
update t_user_info set password='735995' where name='test2624';
update t_user_info set password='661078' where name='test2625';
update t_user_info set password='433603' where name='test2626';
update t_user_info set password='228161' where name='test2627';
update t_user_info set password='933382' where name='test2628';
update t_user_info set password='887828' where name='test2629';
update t_user_info set password='499558' where name='test2630';
update t_user_info set password='932910' where name='test2631';
update t_user_info set password='903961' where name='test2632';
update t_user_info set password='192564' where name='test2633';
update t_user_info set password='453875' where name='test2634';
update t_user_info set password='364457' where name='test2635';
update t_user_info set password='520026' where name='test2636';
update t_user_info set password='729125' where name='test2637';
update t_user_info set password='272519' where name='test2638';
update t_user_info set password='940325' where name='test2639';
update t_user_info set password='326296' where name='test2640';
update t_user_info set password='555342' where name='test2641';
update t_user_info set password='293748' where name='test2642';
update t_user_info set password='660593' where name='test2643';
update t_user_info set password='819117' where name='test2644';
update t_user_info set password='355488' where name='test2645';
update t_user_info set password='481521' where name='test2646';
update t_user_info set password='870141' where name='test2647';
update t_user_info set password='384307' where name='test2648';
update t_user_info set password='723768' where name='test2649';
update t_user_info set password='551182' where name='test2650';
update t_user_info set password='959310' where name='test2651';
update t_user_info set password='934303' where name='test2652';
update t_user_info set password='510315' where name='test2653';
update t_user_info set password='792922' where name='test2654';
update t_user_info set password='318426' where name='test2655';
update t_user_info set password='293648' where name='test2656';
update t_user_info set password='441839' where name='test2657';
update t_user_info set password='375016' where name='test2658';
update t_user_info set password='190671' where name='test2659';
update t_user_info set password='723665' where name='test2660';
update t_user_info set password='619229' where name='test2661';
update t_user_info set password='149391' where name='test2662';
update t_user_info set password='184657' where name='test2663';
update t_user_info set password='326087' where name='test2664';
update t_user_info set password='442858' where name='test2665';
update t_user_info set password='580537' where name='test2666';
update t_user_info set password='481555' where name='test2667';
update t_user_info set password='681742' where name='test2668';
update t_user_info set password='407514' where name='test2669';
update t_user_info set password='170968' where name='test2670';
update t_user_info set password='996030' where name='test2671';
update t_user_info set password='989086' where name='test2672';
update t_user_info set password='620112' where name='test2673';
update t_user_info set password='778313' where name='test2674';
update t_user_info set password='250985' where name='test2675';
update t_user_info set password='868141' where name='test2676';
update t_user_info set password='260180' where name='test2677';
update t_user_info set password='842571' where name='test2678';
update t_user_info set password='796218' where name='test2679';
update t_user_info set password='434554' where name='test2680';
update t_user_info set password='423815' where name='test2681';
update t_user_info set password='824925' where name='test2682';
update t_user_info set password='985507' where name='test2683';
update t_user_info set password='672694' where name='test2684';
update t_user_info set password='831274' where name='test2685';
update t_user_info set password='490286' where name='test2686';
update t_user_info set password='711888' where name='test2687';
update t_user_info set password='937147' where name='test2688';
update t_user_info set password='637861' where name='test2689';
update t_user_info set password='262409' where name='test2690';
update t_user_info set password='578914' where name='test2691';
update t_user_info set password='479914' where name='test2692';
update t_user_info set password='636787' where name='test2693';
update t_user_info set password='176105' where name='test2694';
update t_user_info set password='137077' where name='test2695';
update t_user_info set password='314787' where name='test2696';
update t_user_info set password='648279' where name='test2697';
update t_user_info set password='525770' where name='test2698';
update t_user_info set password='979040' where name='test2699';
update t_user_info set password='993065' where name='test2700';
update t_user_info set password='750653' where name='test2701';
update t_user_info set password='402618' where name='test2702';
update t_user_info set password='438487' where name='test2703';
update t_user_info set password='187546' where name='test2704';
update t_user_info set password='664613' where name='test2705';
update t_user_info set password='776769' where name='test2706';
update t_user_info set password='494553' where name='test2707';
update t_user_info set password='178367' where name='test2708';
update t_user_info set password='491399' where name='test2709';
update t_user_info set password='844164' where name='test2710';
update t_user_info set password='908666' where name='test2711';
update t_user_info set password='616219' where name='test2712';
update t_user_info set password='294599' where name='test2713';
update t_user_info set password='113533' where name='test2714';
update t_user_info set password='892520' where name='test2715';
update t_user_info set password='710658' where name='test2716';
update t_user_info set password='979008' where name='test2717';
update t_user_info set password='717103' where name='test2718';
update t_user_info set password='294780' where name='test2719';
update t_user_info set password='549316' where name='test2720';
update t_user_info set password='196852' where name='test2721';
update t_user_info set password='214570' where name='test2722';
update t_user_info set password='820204' where name='test2723';
update t_user_info set password='714941' where name='test2724';
update t_user_info set password='502095' where name='test2725';
update t_user_info set password='424198' where name='test2726';
update t_user_info set password='356333' where name='test2727';
update t_user_info set password='419131' where name='test2728';
update t_user_info set password='381237' where name='test2729';
update t_user_info set password='371814' where name='test2730';
update t_user_info set password='220115' where name='test2731';
update t_user_info set password='721326' where name='test2732';
update t_user_info set password='696396' where name='test2733';
update t_user_info set password='104099' where name='test2734';
update t_user_info set password='488405' where name='test2735';
update t_user_info set password='978255' where name='test2736';
update t_user_info set password='189003' where name='test2737';
update t_user_info set password='291241' where name='test2738';
update t_user_info set password='904472' where name='test2739';
update t_user_info set password='794381' where name='test2740';
update t_user_info set password='937576' where name='test2741';
update t_user_info set password='777712' where name='test2742';
update t_user_info set password='833072' where name='test2743';
update t_user_info set password='756644' where name='test2744';
update t_user_info set password='893294' where name='test2745';
update t_user_info set password='964188' where name='test2746';
update t_user_info set password='816586' where name='test2747';
update t_user_info set password='576770' where name='test2748';
update t_user_info set password='306407' where name='test2749';
update t_user_info set password='443434' where name='test2750';
update t_user_info set password='960713' where name='test2751';
update t_user_info set password='466527' where name='test2752';
update t_user_info set password='342104' where name='test2753';
update t_user_info set password='433631' where name='test2754';
update t_user_info set password='974337' where name='test2755';
update t_user_info set password='470574' where name='test2756';
update t_user_info set password='753431' where name='test2757';
update t_user_info set password='920387' where name='test2758';
update t_user_info set password='538443' where name='test2759';
update t_user_info set password='830272' where name='test2760';
update t_user_info set password='895635' where name='test2761';
update t_user_info set password='857009' where name='test2762';
update t_user_info set password='537664' where name='test2763';
update t_user_info set password='834309' where name='test2764';
update t_user_info set password='166870' where name='test2765';
update t_user_info set password='633507' where name='test2766';
update t_user_info set password='357953' where name='test2767';
update t_user_info set password='633699' where name='test2768';
update t_user_info set password='328052' where name='test2769';
update t_user_info set password='377465' where name='test2770';
update t_user_info set password='752727' where name='test2771';
update t_user_info set password='116857' where name='test2772';
update t_user_info set password='528137' where name='test2773';
update t_user_info set password='742397' where name='test2774';
update t_user_info set password='847027' where name='test2775';
update t_user_info set password='886064' where name='test2776';
update t_user_info set password='604031' where name='test2777';
update t_user_info set password='952605' where name='test2778';
update t_user_info set password='250038' where name='test2779';
update t_user_info set password='461208' where name='test2780';
update t_user_info set password='852848' where name='test2781';
update t_user_info set password='583860' where name='test2782';
update t_user_info set password='752713' where name='test2783';
update t_user_info set password='706958' where name='test2784';
update t_user_info set password='233482' where name='test2785';
update t_user_info set password='412042' where name='test2786';
update t_user_info set password='502876' where name='test2787';
update t_user_info set password='762927' where name='test2788';
update t_user_info set password='711846' where name='test2789';
update t_user_info set password='808588' where name='test2790';
update t_user_info set password='357785' where name='test2791';
update t_user_info set password='477759' where name='test2792';
update t_user_info set password='471573' where name='test2793';
update t_user_info set password='201616' where name='test2794';
update t_user_info set password='386306' where name='test2795';
update t_user_info set password='981112' where name='test2796';
update t_user_info set password='158971' where name='test2797';
update t_user_info set password='954716' where name='test2798';
update t_user_info set password='100410' where name='test2799';
update t_user_info set password='835645' where name='test2800';
update t_user_info set password='802206' where name='test2801';
update t_user_info set password='251032' where name='test2802';
update t_user_info set password='604999' where name='test2803';
update t_user_info set password='171457' where name='test2804';
update t_user_info set password='971750' where name='test2805';
update t_user_info set password='500931' where name='test2806';
update t_user_info set password='154298' where name='test2807';
update t_user_info set password='252407' where name='test2808';
update t_user_info set password='703859' where name='test2809';
update t_user_info set password='329242' where name='test2810';
update t_user_info set password='691274' where name='test2811';
update t_user_info set password='857359' where name='test2812';
update t_user_info set password='742534' where name='test2813';
update t_user_info set password='514049' where name='test2814';
update t_user_info set password='843621' where name='test2815';
update t_user_info set password='367217' where name='test2816';
update t_user_info set password='443558' where name='test2817';
update t_user_info set password='223697' where name='test2818';
update t_user_info set password='635185' where name='test2819';
update t_user_info set password='623919' where name='test2820';
update t_user_info set password='491753' where name='test2821';
update t_user_info set password='118855' where name='test2822';
update t_user_info set password='607616' where name='test2823';
update t_user_info set password='679834' where name='test2824';
update t_user_info set password='645157' where name='test2825';
update t_user_info set password='208076' where name='test2826';
update t_user_info set password='582515' where name='test2827';
update t_user_info set password='219189' where name='test2828';
update t_user_info set password='871160' where name='test2829';
update t_user_info set password='990837' where name='test2830';
update t_user_info set password='771590' where name='test2831';
update t_user_info set password='336136' where name='test2832';
update t_user_info set password='409846' where name='test2833';
update t_user_info set password='662620' where name='test2834';
update t_user_info set password='201771' where name='test2835';
update t_user_info set password='807152' where name='test2836';
update t_user_info set password='506666' where name='test2837';
update t_user_info set password='215773' where name='test2838';
update t_user_info set password='331816' where name='test2839';
update t_user_info set password='110963' where name='test2840';
update t_user_info set password='736160' where name='test2841';
update t_user_info set password='289068' where name='test2842';
update t_user_info set password='687062' where name='test2843';
update t_user_info set password='543624' where name='test2844';
update t_user_info set password='324549' where name='test2845';
update t_user_info set password='966960' where name='test2846';
update t_user_info set password='144343' where name='test2847';
update t_user_info set password='876327' where name='test2848';
update t_user_info set password='874873' where name='test2849';
update t_user_info set password='949728' where name='test2850';
update t_user_info set password='313443' where name='test2851';
update t_user_info set password='300470' where name='test2852';
update t_user_info set password='822142' where name='test2853';
update t_user_info set password='855021' where name='test2854';
update t_user_info set password='752037' where name='test2855';
update t_user_info set password='661049' where name='test2856';
update t_user_info set password='450026' where name='test2857';
update t_user_info set password='707392' where name='test2858';
update t_user_info set password='652061' where name='test2859';
update t_user_info set password='985731' where name='test2860';
update t_user_info set password='867119' where name='test2861';
update t_user_info set password='275280' where name='test2862';
update t_user_info set password='520413' where name='test2863';
update t_user_info set password='948885' where name='test2864';
update t_user_info set password='832912' where name='test2865';
update t_user_info set password='499524' where name='test2866';
update t_user_info set password='280027' where name='test2867';
update t_user_info set password='517059' where name='test2868';
update t_user_info set password='456603' where name='test2869';
update t_user_info set password='782647' where name='test2870';
update t_user_info set password='787288' where name='test2871';
update t_user_info set password='291426' where name='test2872';
update t_user_info set password='349898' where name='test2873';
update t_user_info set password='933148' where name='test2874';
update t_user_info set password='746254' where name='test2875';
update t_user_info set password='876132' where name='test2876';
update t_user_info set password='817408' where name='test2877';
update t_user_info set password='110381' where name='test2878';
update t_user_info set password='961721' where name='test2879';
update t_user_info set password='444109' where name='test2880';
update t_user_info set password='668973' where name='test2881';
update t_user_info set password='998138' where name='test2882';
update t_user_info set password='256553' where name='test2883';
update t_user_info set password='289955' where name='test2884';
update t_user_info set password='787836' where name='test2885';
update t_user_info set password='876340' where name='test2886';
update t_user_info set password='639644' where name='test2887';
update t_user_info set password='864741' where name='test2888';
update t_user_info set password='863443' where name='test2889';
update t_user_info set password='553643' where name='test2890';
update t_user_info set password='520349' where name='test2891';
update t_user_info set password='996610' where name='test2892';
update t_user_info set password='182787' where name='test2893';
update t_user_info set password='730972' where name='test2894';
update t_user_info set password='665379' where name='test2895';
update t_user_info set password='513592' where name='test2896';
update t_user_info set password='620867' where name='test2897';
update t_user_info set password='205616' where name='test2898';
update t_user_info set password='619770' where name='test2899';
update t_user_info set password='943781' where name='test2900';
update t_user_info set password='232149' where name='test2901';
update t_user_info set password='683424' where name='test2902';
update t_user_info set password='642364' where name='test2903';
update t_user_info set password='320812' where name='test2904';
update t_user_info set password='389003' where name='test2905';
update t_user_info set password='930496' where name='test2906';
update t_user_info set password='476197' where name='test2907';
update t_user_info set password='620184' where name='test2908';
update t_user_info set password='584386' where name='test2909';
update t_user_info set password='118131' where name='test2910';
update t_user_info set password='362716' where name='test2911';
update t_user_info set password='734540' where name='test2912';
update t_user_info set password='151225' where name='test2913';
update t_user_info set password='167403' where name='test2914';
update t_user_info set password='998048' where name='test2915';
update t_user_info set password='902510' where name='test2916';
update t_user_info set password='256008' where name='test2917';
update t_user_info set password='152254' where name='test2918';
update t_user_info set password='703596' where name='test2919';
update t_user_info set password='320892' where name='test2920';
update t_user_info set password='560713' where name='test2921';
update t_user_info set password='633795' where name='test2922';
update t_user_info set password='779686' where name='test2923';
update t_user_info set password='811386' where name='test2924';
update t_user_info set password='861950' where name='test2925';
update t_user_info set password='230014' where name='test2926';
update t_user_info set password='937008' where name='test2927';
update t_user_info set password='655857' where name='test2928';
update t_user_info set password='296199' where name='test2929';
update t_user_info set password='915086' where name='test2930';
update t_user_info set password='120942' where name='test2931';
update t_user_info set password='815967' where name='test2932';
update t_user_info set password='754092' where name='test2933';
update t_user_info set password='507291' where name='test2934';
update t_user_info set password='850628' where name='test2935';
update t_user_info set password='618863' where name='test2936';
update t_user_info set password='602376' where name='test2937';
update t_user_info set password='403593' where name='test2938';
update t_user_info set password='419561' where name='test2939';
update t_user_info set password='825280' where name='test2940';
update t_user_info set password='990439' where name='test2941';
update t_user_info set password='962953' where name='test2942';
update t_user_info set password='564334' where name='test2943';
update t_user_info set password='751753' where name='test2944';
update t_user_info set password='643959' where name='test2945';
update t_user_info set password='831559' where name='test2946';
update t_user_info set password='820899' where name='test2947';
update t_user_info set password='325916' where name='test2948';
update t_user_info set password='787785' where name='test2949';
update t_user_info set password='354146' where name='test2950';
update t_user_info set password='534389' where name='test2951';
update t_user_info set password='387919' where name='test2952';
update t_user_info set password='846890' where name='test2953';
update t_user_info set password='399464' where name='test2954';
update t_user_info set password='663403' where name='test2955';
update t_user_info set password='584617' where name='test2956';
update t_user_info set password='331339' where name='test2957';
update t_user_info set password='277301' where name='test2958';
update t_user_info set password='317382' where name='test2959';
update t_user_info set password='988682' where name='test2960';
update t_user_info set password='898869' where name='test2961';
update t_user_info set password='622623' where name='test2962';
update t_user_info set password='345544' where name='test2963';
update t_user_info set password='471745' where name='test2964';
update t_user_info set password='527957' where name='test2965';
update t_user_info set password='619063' where name='test2966';
update t_user_info set password='174694' where name='test2967';
update t_user_info set password='641974' where name='test2968';
update t_user_info set password='443784' where name='test2969';
update t_user_info set password='475546' where name='test2970';
update t_user_info set password='328061' where name='test2971';
update t_user_info set password='244098' where name='test2972';
update t_user_info set password='333614' where name='test2973';
update t_user_info set password='990154' where name='test2974';
update t_user_info set password='683839' where name='test2975';
update t_user_info set password='707334' where name='test2976';
update t_user_info set password='965102' where name='test2977';
update t_user_info set password='412204' where name='test2978';
update t_user_info set password='524937' where name='test2979';
update t_user_info set password='978180' where name='test2980';
update t_user_info set password='229650' where name='test2981';
update t_user_info set password='559454' where name='test2982';
update t_user_info set password='686586' where name='test2983';
update t_user_info set password='879477' where name='test2984';
update t_user_info set password='848247' where name='test2985';
update t_user_info set password='211058' where name='test2986';
update t_user_info set password='865046' where name='test2987';
update t_user_info set password='774153' where name='test2988';
update t_user_info set password='669520' where name='test2989';
update t_user_info set password='488241' where name='test2990';
update t_user_info set password='379434' where name='test2991';
update t_user_info set password='123360' where name='test2992';
update t_user_info set password='261327' where name='test2993';
update t_user_info set password='154032' where name='test2994';
update t_user_info set password='780022' where name='test2995';
update t_user_info set password='769334' where name='test2996';
update t_user_info set password='603308' where name='test2997';
update t_user_info set password='931016' where name='test2998';
update t_user_info set password='363116' where name='test2999';
update t_user_info set password='951927' where name='test3000';

use `ts001_log`;

-- ----------------------------
DROP TABLE IF EXISTS `reason_list`;
-- ----------------------------
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --init reason_list table----
-- --arena_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (501,'arena_log','竞技场','reason',1,'竞技场挑战');
-- --arena_log end----

-- --battle_result_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (529,'battle_result_log','战斗结果日志','reason',1,'记录战斗结果');
-- --battle_result_log end----

-- --behavior_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',0,'用户执行操作');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',1,'增加附加操作次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',2,'qq数据变更');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',3,'被邀请登录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',4,'用户执行操作');
-- --behavior_log end----

-- --charge_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',1,'充值成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',2,'IPHONE直冲成功,使用直冲接口');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',3,'IPAD直冲成功,使用直冲接口');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',4,'Android直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',5,'IOS直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',6,'PC直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (503,'charge_log','充值','reason',7,'其他直冲');
-- --charge_log end----

-- --chat_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (504,'chat_log','聊天','reason',0,'包含不良信息');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (504,'chat_log','聊天','reason',1,'普通聊天信息');
-- --chat_log end----

-- --corps_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',1,'服务器启动时，初始化军团仓库');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',2,'服务器启动时，加载军团成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',3,'服务器启动时，加载军团失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',4,'忽略所有申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',5,'军团申请,军团人数已满');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',6,'军团申请,本人申请数已达上限');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',7,'军团申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',8,'军团申请撤销');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',9,'创建军团,军团名称存在');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',10,'创建军团,军团名称含有屏蔽字');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',11,'创建军团,金币不够');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',12,'创建军团,扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',13,'创建军团成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',14,'军团事件');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',15,'军团捐献');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',16,'修改军团公告');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',17,'退出军团');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',18,'退出解散');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',19,'申请团长');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',20,'待分配物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',21,'分配前物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',22,'分配后物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',23,'通过申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',24,'拒绝申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',25,'开除成员');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',26,'转让团长');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',27,'GM解散');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'corps_log','军团','reason',28,'弹劾解散');
-- --corps_log end----

-- --drop_item_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (505,'drop_item_log','掉落','reason',0,'掉落道具');
-- --drop_item_log end----

-- --equip_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',1,'清除强化CD');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',2,'强化装备扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',3,'强化装备成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',4,'普通单次洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',5,'定向单次洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',6,'武器技能洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',7,'单次洗练替换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',8,'单次洗练保持');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',9,'普通批量洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',10,'定向批量洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',11,'批量洗练替换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',12,'装备被继承');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',13,'装备继承');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',14,'装备打孔扣除物品失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',15,'装备打孔扣除货币失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',16,'打孔成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',17,'宝石合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',18,'自动 宝石合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',19,'宝石镶嵌');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',20,'宝石移除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',21,'装备附魔失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',22,'装备附魔成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',23,'批量装备附魔');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',24,'装备打造扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',25,'装备打造扣材料失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',26,'装备打造成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',27,'装备升阶扣材料失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',28,'装备升阶成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'equip_log','装备日志','reason',29,'一键交换');
-- --equip_log end----

-- --exam_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (532,'exam_log','科举日志','reason',1,'科举答题记录');
-- --exam_log end----

-- --forage_task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'forage_task_log','护送粮草任务日志','reason',1,'接受任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'forage_task_log','护送粮草任务日志','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'forage_task_log','护送粮草任务日志','reason',3,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'forage_task_log','护送粮草任务日志','reason',4,'刷新任务');
-- --forage_task_log end----

-- --formation_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (515,'formation_log','布阵','reason',1,'武将下阵');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (515,'formation_log','布阵','reason',2,'武将上阵');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (515,'formation_log','布阵','reason',3,'阵内交换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (515,'formation_log','布阵','reason',4,'阵内交换');
-- --formation_log end----

-- --gm_command_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (506,'gm_command_log','使用GM命令','reason',0,'非法使用GM命令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (506,'gm_command_log','使用GM命令','reason',1,'合法使用GM命令');
-- --gm_command_log end----

-- --good_activity_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'good_activity_log','精彩活动日志','reason',1,'玩家领取奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'good_activity_log','精彩活动日志','reason',2,'玩家活动数据删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'good_activity_log','精彩活动日志','reason',3,'活动结束，从map中删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'good_activity_log','精彩活动日志','reason',4,'给奖励');
-- --good_activity_log end----

-- --horse_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',1,'单次培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',2,'批量培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',3,'清除摇动技能室盒CD');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',4,'普通拉杆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',5,'幸运连珠');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',6,'技能升级按钮状态刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',7,'骑乘');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',8,'休息');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'horse_log','坐骑日志','reason',9,'获取活动马');
-- --horse_log end----

-- --item_cost_record_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'item_cost_record_log','财务汇报record修改log','reason',1,'财务汇报record增加记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'item_cost_record_log','财务汇报record修改log','reason',2,'财务汇报record减少记录');
-- --item_cost_record_log end----

-- --item_gen_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',1,'debug测试');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',2,'拆分物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',3,'临时背包放入主背包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',4,'通过校场系统购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',5,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',6,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',7,'礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',9,'金券套餐直购道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',201,'关卡产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',202,'关卡宝箱产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',300,'任务奖励产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',301,'推荐国家奖励产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',302,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',303,'军团战玩家报名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',304,'军团战玩家战斗奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',305,'军团战军团奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',306,'世界boss战攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',307,'世界boss战击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',308,'世界boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',309,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',350,'装备打造生成 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',351,'装备宝石移除添加 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',352,'宝石合成生成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',353,'批量宝石合成生成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',354,'宝物转换生成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',355,'宝物升阶生成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',401,'过关斩将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',411,'领地生产获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',450,'技能书移除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',451,'技能书合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',460,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',461,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',462,'目标系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',463,'目标系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',464,'内政系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',465,'内政系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',480,'收将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',481,'神将商店购买');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',490,'女神宝藏兑换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',500,'女神宝藏显示奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',501,'女神宝藏实际奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',510,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',520,'在线礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',521,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',530,'神秘商店购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',531,'商城购买');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',535,'快捷购买');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',540,'领取平台奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',550,'军团分配物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',560,'军衔激活奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',561,'军衔俸禄奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',562,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',563,'领地献计奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',564,'领地献计奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',565,'手机验证奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',566,'GM奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',567,'游戏内产生带参数奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',570,'南蛮入侵攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',571,'南蛮入侵击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',572,'南蛮入侵boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',573,'南蛮入侵下注奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',580,'卡牌购买 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',581,'卡牌-抽卡奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',582,'卡牌-日排名普通奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',583,'卡牌-日排名超级奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',584,'卡牌-累计排名普通奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',585,'卡牌-累计排名超级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',586,'卡牌-奖励兑换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',587,'幸运转盘抽奖奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',588,'宝石迷阵奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',589,'兑换商城奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',590,'兑换商城奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',600,'qq-黄钻新手奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',601,'qq-黄钻每日奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',602,'qq-豪华黄钻每日额外奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',603,'qq-年费黄钻每日额外奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',604,'qq-黄钻升级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',605,'qq-充值赠送奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',606,'环任务单环奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',607,'环任务总奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',610,'qq-被邀请者n天奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',611,'qq-充值返利奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',612,'qq-邀请好友次数奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',613,'qq-历程分享奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',614,'qq-每日邀请好友奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',615,'qq-app评分奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',616,'qq-集市任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',617,'每日首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',618,'渡江单次攻击');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',619,'渡江完成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',620,'借东风开启奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',621,'借东风结束奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',622,'抢夺收益排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',623,'抢夺收益排名超级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',624,'渡江护送完成 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',625,'领取CDKEY礼包 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',626,'试剑塔关卡敌人奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',627,'经典战役通关奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',628,'经典战役事件奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',629,'经典战役自动通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',630,'特殊在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',631,'演武离线打坐获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',635,'累积消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',640,'消耗钥匙使用礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',650,'装备打造给装备');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',660,'宝石卸下时，给朱背包添加一块宝石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',661,'宝石镶嵌时，在宝石包中添加一块宝石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',662,'在交易行购买商品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',663,'交易行卖出获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',664,'在交易行下架商品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',665,'合成宝石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',670,'接受任务给道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',671,'藏宝图任务完成后生成道具');
-- --item_gen_log end----

-- --item_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',1,'物品数量增加');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',2,'使用后减少');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',3,'玩家丢弃');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',4,'卖出道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',5,'背包中移动');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',6,'加载角色物品时数据错误');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',7,'拆分后减少');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',8,'整理背包改变数量');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',9,'超过使用期限');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',10,'临时背包放入主背包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11,'开格工具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',12,'临时背包物品失效');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13,'领取平台奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',14,'军团分配物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',15,'任务奖励物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',16,'完成任务扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',32,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',33,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',37,'宝物升阶扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',38,'礼盒消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',39,'主将经验卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',40,'副将经验卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',41,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',42,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',43,'加池子数值');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',44,'翅膀卡卡扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',130,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',131,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',200,'在线礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',201,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',232,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',235,'手机验证奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',236,'GM命令奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',237,'游戏内带参数奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',253,'GM命令删除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',347,'特殊在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',350,'累积消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',355,'消耗钥匙使用物品扣除【物品】');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',356,'消耗钥匙使用礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',357,'消耗钥匙使用礼包扣除自己');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',9999,'GM命令删除所有道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',10001,'武将升星消耗灵魂石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',10002,'召唤武将消耗灵魂石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',10003,'武将穿装备-主背包扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',10004,'武将进阶清除装备');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11001,'打造装备扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11002,'装备打造给装备');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11003,'装备升星扣除基本材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11004,'装备升星扣除附加材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11005,'还童扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11006,'变异扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11007,'炼化或提升扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11008,'悟性提升扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11009,'重铸装备扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',11010,'装备分解，删除装备');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',12001,'宠物洗天赋技能扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',12002,'宠物学习普通技能扣技能书');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',12003,'洗点消耗道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13001,'科举特殊道具使用消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13501,'镶嵌宝石时，消耗一块在主背包内的相应宝石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13502,'卸下宝石时，将宝石包内的宝石删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13503,'合成宝石时，扣除材料');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13401,'将物品放入交易行');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13402,'交易行卖出获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',14001,'捕捉宠物扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',14002,'战斗内嗑药扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',15001,'酒馆任务刷新扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',15002,'装备洗炼扣除洗练石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',15003,'打造装备材料不足时扣除金票');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',16001,'绿野仙踪单人进入扣道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',16002,'藏宝图任务完成后生成道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',17001,'护送粮草任务刷新扣除道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',18001,'升阶翅膀扣除道具');
-- --item_log end----

-- --mail_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',1,'收件箱邮件到期删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',2,'发件箱邮件到期删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',3,'收件箱已满时删除最早的没有附件的邮件');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',4,'收件箱全都有附件时本封邮件没有附件被删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',5,'收件箱全都有附件时删除最早的一封');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',6,'发件箱已满时删除最早的一封');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (509,'mail_log','发送邮件','reason',7,'保存箱已满时删除最早的一封');
-- --mail_log end----

-- --mall_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',1,'GM 修改初始数据');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',2,'GM 修改，刷新后数据');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',3,'购买普通物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',4,'购买限时物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',5,'商城状态刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'mall_log','商城日志','reason',6,'服务器启动后');
-- --mall_log end----

-- --mission_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',1,'进入关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',2,'离开关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',3,'攻击关卡敌人');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',4,'领取关卡通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',5,'攻击关卡敌人结果');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',10,'关卡开始挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',11,'关卡立即完成挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',12,'关卡停止挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'mission_log','关卡','reason',13,'检查需要完成的挂机');
-- --mission_log end----

-- --money_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1,'玩家充值获得钻石');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',2,'IOS直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',3,'Android直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',4,'PC直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',5,'其他直冲');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',6,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',7,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',8,'礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',9,'金券套餐直购道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10,'背包卖出道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',12,'使用金银卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',15,'每日充值奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',21,'增加冷却队列');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',22,'清除冷却队列');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',34,'系统恢复军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',35,'打关卡扣除军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',36,'用餐获得体力');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',101,'关卡获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',102,'关卡宝箱获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',201,'关卡挂机消耗军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',202,'关卡挂机立即完成消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',203,'副本挂机立即完成消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',204,'副本购买次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',205,'竞技场购买次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',206,'竞技场清除冷却时间');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',300,'任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',306,'推荐国家奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',307,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',373,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',820,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',821,'购买VIP卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',831,'在线礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',841,'领取平台奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',850,'神秘商店元宝刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',851,'神秘商店高级刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',852,'神秘商店购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',861,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',871,'购买体力扣钱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',872,'购买体力给体力');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',881,'商城购买消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',882,'快捷购买物品消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',883,'快捷购买消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',893,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',997,'每日首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1016,'领取CDKEY礼包 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1215,'特殊在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1216,'演武离线打坐获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1220,'累积消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1221,'购买累积消耗活动物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',1225,'消耗钥匙使用物品扣除【货币】');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',92,'消耗钥匙使用礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10001,'武将技能升级消耗技能点');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10002,'武将技能升级消耗金币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10003,'武将升星消耗金币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10004,'系统恢复技能点');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10005,'购买技能点扣钱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10006,'购买技能点给技能点');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11001,'装备打造消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11002,'装备位升星消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11003,'还童消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11004,'变异消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11005,'炼化或提升消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11006,'宠物悟性提升消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11010,'宠物培养消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11011,'伙伴解锁消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11020,'提升心法等级消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11030,'装备位镶嵌宝石消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11031,'宝石合成消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11040,'交易行扣除手续费');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11041,'交易行扣除手续费');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11042,'交易行卖出物品获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11043,'装备重铸消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11044,'装备分解消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11045,'装备洗炼消耗银票');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',11046,'装备打造消耗游戏币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',12000,'创建军团');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',12001,'军团捐献');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',13000,'采矿扣除货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',13100,'酒馆任务刷新扣钱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',14000,'护送粮草任务押金扣钱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',14100,'护送粮草任务完成获得奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',15000,'强制解除师徒关系');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',15001,'结婚扣除费用');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',15002,'强制解除夫妻关系');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',16000,'升阶翅膀');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',9999,'通过debug命令给金钱');
-- --money_log end----

-- --mystery_shop_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',1,'神秘商店功能开启');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',2,'免费刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',3,'珍宝票刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',4,'元宝刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',5,'VIP刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',6,'购买神秘商店物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'mystery_shop_log','神秘商店日志','reason',7,'过时刷新');
-- --mystery_shop_log end----

-- --online_time_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (511,'online_time_log','玩家在线时长','reason',0,'无意义');
-- --online_time_log end----

-- --overman_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',1,'申请拜师');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',2,'拜师');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',3,'师傅强制解除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',4,'徒弟强制解除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',5,'组队解除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'overman_log','师徒日志','reason',6,'出师');
-- --overman_log end----

-- --pet_exp_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',1,'关卡获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',2,'任务获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',3,'关卡获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',4,'推荐国家获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',5,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',6,'军团战玩家报名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',7,'军团战玩家战斗奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',8,'世界boss战攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',9,'世界boss战击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',10,'世界boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',11,'斗地主互动增加经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',12,'斗地主从苦工获取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',13,'斗地主玩家离线时从苦工获取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',14,'GM命令增加经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',15,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',16,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',17,'过关斩将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',18,'主将经验卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',45,'副将经验卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',19,'礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',20,'领地给主将经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',21,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',22,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',23,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',24,'目标系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',25,'目标系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',26,'内政系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',27,'内政系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',28,'女神宝藏显示奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',29,'女神宝藏实际奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',30,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',46,'在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',31,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',32,'军衔激活奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',33,'军衔俸禄奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',34,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',35,'领地献计奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',36,'用餐御射奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',37,'手机验证奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',38,'每日活跃奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',39,'南蛮入侵攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',40,'南蛮入侵击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',41,'南蛮入侵排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',42,'南蛮入侵下注奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',50,'卡牌-抽卡奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',51,'卡牌-日排名普通奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',52,'卡牌-日排名超级奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',53,'卡牌-累计排名普通奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',54,'卡牌-累计排名超级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',55,'卡牌-奖励兑换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',56,'幸运转盘抽奖奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',57,'宝石迷阵奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',58,'兑换商城奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',60,'qq-黄钻新手奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',61,'qq-黄钻每日奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',62,'qq-豪华黄钻每日额外奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',63,'qq-年费黄钻每日额外奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',64,'qq-黄钻升级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',65,'qq-充值赠送奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',66,'环任务单环奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',67,'环任务总奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',68,'qq-被邀请者n天奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',69,'qq-充值返利奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',70,'qq-邀请好友次数奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',71,'qq-历程分享奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',72,'qq-每日邀请好友奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',73,'qq-app评分奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',74,'qq-集市任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',75,'每日首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',76,'渡江单次攻击');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',77,'渡江完成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',78,'借东风开启奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',79,'借东风结束奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',80,'抢夺收益排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',81,'抢夺收益排名超级奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',82,'渡江护送完成 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',83,'领取CDKEY礼包 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',84,'试剑塔关卡敌人奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',85,'经典战役通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',86,'经典战役事件奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',87,'经典战役自动通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',88,'特殊在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',89,'演武在线打坐获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',90,'演武离线打坐获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',91,'累积消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',92,'消耗钥匙使用礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'pet_exp_log','经验','reason',93,'交易行卖出物品获得');
-- --pet_exp_log end----

-- --pet_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',1,'召唤武将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',2,'武将招募卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',3,'武将解雇');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',4,'武将解雇转换装备失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',5,'特殊任务完成后直接给武将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',9,'gm命令给');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',100,'武将加点');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',101,'抓捕宠物');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',102,'宠物改变出战状态');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',103,'武将改名');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',104,'宠物战斗后扣除寿命');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',105,'宠物学习普通技能');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',106,'宠物战斗后状态更新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',107,'武将洗点');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',110,'GM给宠物');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',111,'交易行下架宠物');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',112,'交易行交易宠物');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',113,'骑宠改变骑乘状态');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',120,'宠物培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'pet_log','武将更新','reason',121,'宠物培养替换');
-- --pet_log end----

-- --player_login_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',0,'用户登陆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',1,'用户登出');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',2,'强制踢出下线');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',3,'用户主动登出');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',4,'重复登录踢出下线');
-- --player_login_log end----

-- --pop_tips_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'pop_tips_log','小助手log','reason',1,'武将技能记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'pop_tips_log','小助手log','reason',2,'武将上阵记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'pop_tips_log','小助手log','reason',3,'心法升级记录');
-- --pop_tips_log end----

-- --prize_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'prize_log','奖励','reason',0,'奖励成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'prize_log','奖励','reason',1,'奖励失败,取平台后奖励条件不满足');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'prize_log','奖励','reason',2,'补偿失败,奖励条件不满足,已扣取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'prize_log','奖励','reason',3,'奖励失败,状态被打断');
-- --prize_log end----

-- --pub_exp_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'pub_exp_log','酒馆经验日志','reason',1,'酒馆任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'pub_exp_log','酒馆经验日志','reason',2,'GM给奖励');
-- --pub_exp_log end----

-- --pub_task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pub_task_log','酒馆任务日志','reason',1,'接受任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pub_task_log','酒馆任务日志','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pub_task_log','酒馆任务日志','reason',3,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pub_task_log','酒馆任务日志','reason',4,'刷新任务');
-- --pub_task_log end----

-- --reward_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'reward_log','奖励日志','reason',1,'通过rewardId生成的奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'reward_log','奖励日志','reason',2,'通过合并奖励生成的奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'reward_log','奖励日志','reason',3,'通过军团分配生成的奖励');
-- --reward_log end----

-- --task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',0,'领取任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',1,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',3,'删除已完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',4,'删除正执行任务');
-- --task_log end----

-- --the_sweeney_task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'the_sweeney_task_log','除暴安良任务日志','reason',1,'接受任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'the_sweeney_task_log','除暴安良任务日志','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'the_sweeney_task_log','除暴安良任务日志','reason',3,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'the_sweeney_task_log','除暴安良任务日志','reason',4,'刷新任务');
-- --the_sweeney_task_log end----

-- --title_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'title_log','称号日志','reason',1,'修改称号');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'title_log','称号日志','reason',2,'增加称号使用时间');
-- --title_log end----

-- --treasure_map_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'treasure_map_log','藏宝图任务日志','reason',1,'接受任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'treasure_map_log','藏宝图任务日志','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'treasure_map_log','藏宝图任务日志','reason',3,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'treasure_map_log','藏宝图任务日志','reason',4,'刷新任务');
-- --treasure_map_log end----

-- --vip_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',0,'玩家登陆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',1,'玩家充值');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',2,'心跳检测状态改变');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',3,'零点刷新状态改变');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',4,'领取每日奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',5,'使用或购买VIP卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',6,'首次领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',7,'GM增加经验');
-- --vip_log end----

