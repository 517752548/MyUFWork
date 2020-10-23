SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr`;
update t_db_version set version='1.0.0.6',updateTime=now();

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  
if exists (select * from information_schema.columns where table_name = 't_user_info' and column_name = 'activity') then  
        alter table t_user_info drop column activity;
end if; 
alter table t_user_info add column activity int(11) NOT NULL DEFAULT '0';
end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;