USE `tr_${server_id}`;
update t_db_version set version='1.0.0.25',updateTime=now();
delete from t_item_info where deleted=1;