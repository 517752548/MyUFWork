SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr`;
update t_db_version set version='1.0.0.4',updateTime=now();

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_name = 't_good_activity_user' and column_name = 'deleteDate') then  
        alter table t_good_activity_user drop column deleteDate;
end if; 
alter table t_good_activity_user add column deleteDate datetime DEFAULT NULL;
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_name = 't_good_activity_user' and column_name = 'deleted') then  
        alter table t_good_activity_user drop column deleted;
end if; 
alter table t_good_activity_user add column deleted int(11) DEFAULT '0';
alter table t_good_activity_user add index deleted(deleted);
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;
