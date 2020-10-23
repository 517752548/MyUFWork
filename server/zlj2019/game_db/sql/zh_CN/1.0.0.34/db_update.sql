SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr_${server_id}`;
update t_db_version set version='1.0.0.34',updateTime=now();
delete from t_item_info where deleted=1;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
	
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'orangeHufu') then  
        alter table tr_${server_id}.t_character_info drop column orangeHufu;
end if; 
alter table tr_${server_id}.t_character_info add column orangeHufu bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_user_prize' and column_name = 'params') then  
        alter table tr_${server_id}.t_user_prize drop column params;
end if; 
alter table tr_${server_id}.t_user_prize add column params text;

end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

DROP TABLE IF EXISTS `t_cdkey`;
CREATE TABLE `t_cdkey` (
  `id` int(11) NOT NULL auto_increment,
  `cdkey` varchar(100) NOT NULL,
  `plansId` int(11) NOT NULL,
  `giftId` int(11) NOT NULL,
  `groupId` int(11) NOT NULL,
  `gmId` varchar(255) NOT NULL,
  `state` int(11) NOT NULL default '0',
  `createTime` bigint(20) NOT NULL default '0',
  `openId` varchar(255) default NULL,
  `charId` bigint(20) default NULL,
  `charName` varchar(100) default NULL,
  `chartServerId` varchar(255) default NULL,
  `takeTime` bigint(20) default '0',
  PRIMARY KEY  (`id`),
  UNIQUE KEY `cdkey` (`cdkey`)
) ENGINE=InnoDB AUTO_INCREMENT=10032 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `t_cdkey_plans`;
CREATE TABLE `t_cdkey_plans` (
  `id` int(11) NOT NULL auto_increment,
  `cdkeyPlansId` int(11) NOT NULL,
  `cdkeyPlansName` varchar(11) NOT NULL,
  `startTime` bigint(20) NOT NULL,
  `endTime` bigint(20) NOT NULL,
  `createTime` bigint(20) NOT NULL,
  `gmId` int(11) NOT NULL,
  PRIMARY KEY  (`id`),
  UNIQUE KEY `cdkeyPlansId` (`cdkeyPlansId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `t_world_gift`;
CREATE TABLE `t_world_gift` (
  `id` int(11) NOT NULL auto_increment,
  `giftId` int(11) NOT NULL,
  `giftName` varchar(255) NOT NULL default '',
  `giftParams` varchar(255) NOT NULL default '',
  `createTime` bigint(20) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  UNIQUE KEY `giftid` (`giftId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

