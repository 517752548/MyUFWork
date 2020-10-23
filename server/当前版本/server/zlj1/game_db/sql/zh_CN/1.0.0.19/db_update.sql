USE `tr_${server_id}`;
update t_db_version set version='1.0.0.19',updateTime=now();

update t_user_info set name=id;