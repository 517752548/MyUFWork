SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr_${server_id}`;
update t_db_version set version='1.0.0.17',updateTime=now();

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_user_info' and column_name = 'qqData') then  
        alter table tr_${server_id}.t_user_info drop column qqData;
end if; 
alter table tr_${server_id}.t_user_info add column qqData TEXT;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_user_snap' and column_name = 'qqData') then  
        alter table tr_${server_id}.t_user_snap drop column qqData;
end if; 
alter table tr_${server_id}.t_user_snap add column qqData TEXT;
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_user_snap' and column_name = 'passportId') then  
        alter table tr_${server_id}.t_user_snap drop column passportId;
end if; 
alter table tr_${server_id}.t_user_snap add column passportId varchar(255);
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;


-- ----------------------------
-- Table structure for t_qq_charge_order
-- ----------------------------
DROP TABLE IF EXISTS `t_qq_charge_order`;
CREATE TABLE `t_qq_charge_order` (
  `id` varchar(255) NOT NULL,
  `billno` varchar(255) DEFAULT NULL,
  `charId` bigint(20) NOT NULL DEFAULT '0',
  `chargeTplId` int(11) NOT NULL DEFAULT '0',
  `chargeTplNum` int(11) NOT NULL DEFAULT '0',
  `createTime` bigint(20) NOT NULL DEFAULT '0',
  `deleteDate` datetime DEFAULT NULL,
  `deleted` int(11) NOT NULL DEFAULT '0',
  `openId` varchar(255) DEFAULT NULL,
  `params` text,
  PRIMARY KEY (`id`),
  KEY `charId` (`charId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

