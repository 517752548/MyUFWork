SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr`;
update t_db_version set version='1.0.0.16',updateTime=now();

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr' and table_name = 't_character_info' and column_name = 'monsterWarChip') then  
        alter table t_character_info drop column monsterWarChip;
end if; 
alter table t_character_info add column monsterWarChip bigint(20) NOT NULL DEFAULT '0';
if exists (select * from information_schema.columns where table_schema='tr' and table_name = 't_character_info' and column_name = 'armour') then  
        alter table t_character_info drop column armour;
end if; 
alter table t_character_info add column armour int(11) NOT NULL DEFAULT '0';
if exists (select * from information_schema.columns where table_schema='tr' and table_name = 't_character_info' and column_name = 'gemMazeEnergy') then  
        alter table t_character_info drop column gemMazeEnergy;
end if; 
alter table t_character_info add column gemMazeEnergy int(11) NOT NULL DEFAULT '0';
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr' and table_name = 't_character_info' and column_name = 'cardPoint') then  
        alter table t_character_info drop column cardPoint;
end if; 
alter table t_character_info add column cardPoint int(11) not null default 0;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

-- ----------------------------
-- Table structure for t_card_activity
-- ----------------------------
DROP TABLE IF EXISTS `t_card_activity`;
CREATE TABLE `t_card_activity` (
  `id` bigint(20) NOT NULL,
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `endTime` bigint(20) NOT NULL DEFAULT '0',
  `closeTime` bigint(20) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `forceCloseTime` bigint(20) NOT NULL DEFAULT '0',
  `isClosed` int(11) NOT NULL DEFAULT '0',
  `isStarted` int(11) NOT NULL DEFAULT '0',
  `rankRecord` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_card_user
-- ----------------------------
DROP TABLE IF EXISTS `t_card_user`;
CREATE TABLE `t_card_user` (
  `id` bigint(20) NOT NULL,
  `cardActivityId` bigint(20) NOT NULL DEFAULT '0',
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `exchangeRecord` text,
  `gotDayReward` int(11) NOT NULL DEFAULT '0',
  `gotTotalReward` int(11) NOT NULL DEFAULT '0',
  `lastScoreTime` bigint(20) NOT NULL DEFAULT '0',
  `todayScore` int(11) NOT NULL DEFAULT '0',
  `totalScore` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `cardActivityId` (`cardActivityId`),
  KEY `charId` (`charId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_turntable_activity
-- ----------------------------
DROP TABLE IF EXISTS `t_turntable_activity`;
CREATE TABLE `t_turntable_activity` (
  `id` bigint(20) NOT NULL,
  `startTime` bigint(20) NOT NULL DEFAULT '0',
  `endTime` bigint(20) NOT NULL DEFAULT '0',
  `forceCloseTime` bigint(20) NOT NULL DEFAULT '0',
  `isClosed` int(11) NOT NULL DEFAULT '0',
  `isStarted` int(11) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
