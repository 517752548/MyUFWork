SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr_${server_id}`;
update t_db_version set version='1.0.0.36',updateTime=now();
delete from t_item_info where deleted=1;

drop procedure if exists schema_change;
delimiter ';;';
create procedure schema_change() begin  

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul1') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul1;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul1 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul2') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul2;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul2 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul3') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul3;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul3 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul4') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul4;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul4 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul5') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul5;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul5 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul6') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul6;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul6 bigint(20) NOT NULL DEFAULT '0';

if exists (select * from information_schema.columns where table_schema='tr_${server_id}' and table_name = 't_character_info' and column_name = 'swordSoul7') then  
        alter table tr_${server_id}.t_character_info drop column swordSoul7;
end if; 
alter table tr_${server_id}.t_character_info add column swordSoul7 bigint(20) NOT NULL DEFAULT '0';

end;;
delimiter ';';
call schema_change();
drop procedure if exists schema_change;

