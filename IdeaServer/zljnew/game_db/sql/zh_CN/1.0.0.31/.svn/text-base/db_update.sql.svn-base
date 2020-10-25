SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr_${server_id}`;
update t_db_version set version='1.0.0.31',updateTime=now();
delete from t_item_info where deleted=1;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'canRename') then  
        alter table tr_${server_id}.t_character_info drop column canRename;
end if; 
alter table tr_${server_id}.t_character_info add column canRename int(11) not null default 0;
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'serverId') then  
        alter table tr_${server_id}.t_character_info drop column serverId;
end if; 
alter table tr_${server_id}.t_character_info add column serverId int(11) not null default 0;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_corps' and column_name = 'canRename') then  
        alter table tr_${server_id}.t_corps drop column canRename;
end if; 
alter table tr_${server_id}.t_corps add column canRename int(11) not null default 0;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_db_version' and column_name = 'serverIds') then  
        alter table tr_${server_id}.t_db_version drop column serverIds;
end if; 
alter table tr_${server_id}.t_db_version add column serverIds text;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

update t_db_version set serverIds='[${deployConfig.localHostId}]';
update t_character_info set serverId='${deployConfig.localHostId}';

delete from t_qq_markettask_target;
INSERT INTO `t_qq_markettask_target` VALUES ('1', '1403105795800', '{\"step2\":{\"step\":\"2\",\"target\":\"1\",\"param1\":\"38\",\"param2\":\"\",\"param3\":\"\"},\"step3\":{\"step\":\"3\",\"target\":\"1\",\"param1\":\"50\",\"param2\":\"\",\"param3\":\"\"}}');
