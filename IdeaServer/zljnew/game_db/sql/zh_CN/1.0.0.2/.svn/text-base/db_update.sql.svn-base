SET CHARACTER_SET_CLIENT=utf8;
SET CHARACTER_SET_CONNECTION=utf8;

USE `tr`;
update t_db_version set version='1.0.0.2',updateTime=now();

alter table t_user_info modify name varchar(255);

use `tr_log`;
truncate reason_list;
-- --init reason_list table----
-- --arena_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (501,'arena_log','竞技场','reason',1,'竞技场挑战');
-- --arena_log end----

-- --army_title_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'army_title_log','军衔log','reason',1,'军衔升级升级记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'army_title_log','军衔log','reason',2,'军衔天赋升级记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (538,'army_title_log','军衔log','reason',3,'军衔天赋升级记录');
-- --army_title_log end----

-- --battle_result_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (542,'battle_result_log','战斗结果日志','reason',1,'记录战斗结果');
-- --battle_result_log end----

-- --behavior_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',0,'用户执行操作');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (502,'behavior_log','行为日志','reason',1,'增加附加操作次数');
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
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',1,'服务器启动时，初始化军团仓库');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',2,'服务器启动时，加载军团成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',3,'服务器启动时，加载军团失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',4,'忽略所有申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',5,'军团申请,军团人数已满');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',6,'军团申请,本人申请数已达上限');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',7,'军团申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',8,'军团申请撤销');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',9,'创建军团,军团名称存在');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',10,'创建军团,军团名称含有屏蔽字');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',11,'创建军团,金币不够');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',12,'创建军团,扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',13,'创建军团成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',14,'军团事件');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',15,'军团捐献');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',16,'修改军团公告');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',17,'退出军团');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',18,'退出解散');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',19,'申请团长');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',20,'待分配物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',21,'分配前物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',22,'分配后物品列表');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',23,'通过申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',24,'拒绝申请');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',25,'开除成员');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (521,'corps_log','军团','reason',26,'转让团长');
-- --corps_log end----

-- --drill_ground_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',1,'校场购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',2,'领取完胜奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',3,'武将招募');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',4,'普通挑战');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',5,'高级挑战');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',6,'一键高级挑战');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',7,'一键必胜高级挑战');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (516,'drill_ground_log','校场','reason',8,'��行游戏');
-- --drill_ground_log end----

-- --drop_item_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (505,'drop_item_log','掉落','reason',0,'掉落道具');
-- --drop_item_log end----

-- --equip_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',1,'清除强化CD');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',2,'强化装备扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',3,'强化装备成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',4,'普通单次洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',5,'定向单次洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',6,'武器技能洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',7,'单次洗练替换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',8,'单次洗练保持');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',9,'普通批量洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',10,'定向批量洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',11,'批量洗练替换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',12,'装备被继承');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',13,'装备继承');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',14,'装备打孔扣除物品失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',15,'装备打孔扣除货币失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',16,'打孔成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',17,'宝石合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',18,'自动 宝石合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',19,'宝石镶嵌');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',20,'宝石移除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',21,'装备附魔失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',22,'装备附魔成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',23,'批量装备附魔');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',24,'装备打造扣钱失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',25,'装备打造扣材料失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',26,'装备打造成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',27,'装备升阶扣材料失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',28,'装备升阶成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (525,'equip_log','装备日志','reason',29,'一键交换');
-- --equip_log end----

-- --formation_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'formation_log','布阵','reason',1,'武将下阵');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'formation_log','布阵','reason',2,'武将上阵');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'formation_log','布阵','reason',3,'阵内交换');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (517,'formation_log','布阵','reason',3,'阵内交换');
-- --formation_log end----

-- --gm_command_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (506,'gm_command_log','使用GM命令','reason',0,'非法使用GM命令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (506,'gm_command_log','使用GM命令','reason',1,'合法使用GM命令');
-- --gm_command_log end----

-- --god_hero_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',1,'神将移动');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',2,'吞噬');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',3,'吞噬');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',4,'点将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',5,'收将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',6,'元宝培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (531,'god_hero_log','内政任务日志','reason',7,'购买神将');
-- --god_hero_log end----

-- --good_activity_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (540,'good_activity_log','精彩活动日志','reason',1,'玩家领取奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (540,'good_activity_log','精彩活动日志','reason',2,'玩家活动数据删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (540,'good_activity_log','精彩活动日志','reason',3,'活动结束，从map中删除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (540,'good_activity_log','精彩活动日志','reason',4,'给奖励');
-- --good_activity_log end----

-- --hero_mission_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',1,'进入关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',2,'离开关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',3,'攻击关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',5,'攻击关卡结果');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',6,'重置关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (524,'hero_mission_log','过关斩将','reason',7,'重置章节');
-- --hero_mission_log end----

-- --horse_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',1,'单次培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',2,'批量培养');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',3,'清除摇动技能室盒CD');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',4,'普通拉杆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',5,'幸运连珠');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',6,'技能升级按钮状态刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',7,'骑乘');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',8,'休息');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (535,'horse_log','坐骑日志','reason',9,'获取活动马');
-- --horse_log end----

-- --item_cost_record_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'item_cost_record_log','财务汇报record修改log','reason',1,'财务汇报record增加记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (537,'item_cost_record_log','财务汇报record修改log','reason',2,'财务汇报record减少记录');
-- --item_cost_record_log end----

-- --item_gen_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',1,'debug测试');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',2,'拆分物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',3,'临时背包放入主背包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',4,'通过校场系统购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',5,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',6,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',7,'礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',201,'关卡产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',202,'关卡宝箱产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (507,'item_gen_log','物品产生','reason',301,'任务奖励产生物品');
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
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',12,'关卡产生物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',13,'关卡宝箱物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',14,'军团分配物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',15,'任务奖励物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',16,'任务奖励物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',17,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',18,'军团战玩家报名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',19,'军团战玩家战斗奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',20,'军团战军团奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',21,'世界boss战攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',22,'世界boss战击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',23,'世界boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',24,'装备打孔消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',25,'装备附魔消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',26,'装备批量附魔消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',26,'装备打造扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',27,'装备升阶扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',28,'装备宝石镶嵌扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',29,'宝石合成扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',30,'批量宝石合成扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',31,'装备升阶添加');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',32,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',33,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',34,'宝物升星扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',35,'宝物转换扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',36,'宝物升阶扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',37,'宝物升阶扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',38,'礼盒消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',39,'主将经验卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',40,'副将经验卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',41,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',42,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',101,'过关斩将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',120,'坐骑单次培养消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',121,'坐骑批量培养消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',122,'技能书镶嵌');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',122,'技能书合成');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',130,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',131,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',132,'目标系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',133,'目标系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',134,'内政系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',135,'内政系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',140,'女神宝藏抽奖消耗道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',160,'神将吞噬');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',161,'神将批量吞噬');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',170,'女神宝藏显示奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',171,'女神宝藏实际奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',180,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',181,'使用VIP卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',190,'临时背包物品失效');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',200,'在线礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',201,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',210,'神秘商店元宝刷新扣除');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',220,'活动马');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',230,'军衔激活奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',231,'军衔俸禄奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',232,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',233,'领地献计奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (508,'item_log','物品更新','reason',9999,'GM命令删除所有道具');
-- --item_log end----

-- --land_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (528,'land_log','领地日志','reason',1,'开始生产');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (528,'land_log','领地日志','reason',2,'领取生产奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (528,'land_log','领地日志','reason',3,'刷新品阶');
-- --land_log end----

-- --landlord_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',1,'斗地主抓捕进行战斗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',2,'斗地主抓捕战斗结束');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',3,'地主奴隶被抢');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',4,'解救奴隶');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',5,'解救奴隶战斗结束');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',6,'互动');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',7,'压榨');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',8,'玩家主动提取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',9,'提取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',10,'奴隶反抗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',11,'奴隶反抗战斗结束');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',12,'奴隶求救');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',13,'奴隶求救战斗结束');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',14,'释放奴隶');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',15,'到时间自动释放奴隶');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (523,'landlord_log','斗地主日志','reason',16,'失去奴隶');
-- --landlord_log end----

-- --land_offer_advice_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (541,'land_offer_advice_log','献计日志','reason',1,'玩家献计');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (541,'land_offer_advice_log','献计日志','reason',2,'主人领取献计奖励');
-- --land_offer_advice_log end----

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
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',1,'GM 修改初始数据');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',2,'GM 修改，刷新后数据');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',3,'购买普通物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',4,'购买限时物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',5,'商城状态刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (536,'mall_log','商城日志','reason',6,'服务器启动后');
-- --mall_log end----

-- --mission_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',1,'进入关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',2,'离开关卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',3,'攻击关卡敌人');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',4,'领取关卡通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',5,'攻击关卡敌人结果');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',10,'关卡开始挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',11,'关卡立即完成挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',12,'关卡停止挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (518,'mission_log','关卡','reason',13,'检查需要完成的挂机');
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
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',10,'背包卖出道具');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',12,'使用金银卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',15,'每日充值奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',21,'增加冷却队列');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',22,'清除冷却队列');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',24,'武将解雇返还');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',25,'校场购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',26,'校场首次完胜奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',27,'必胜消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',28,'一键高级消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',29,'一键必胜消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',30,'失败返还');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',31,'胜利奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',32,'挑战消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',33,'一键挑战奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',33,'招募武将消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',33,'解雇武将返还');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',34,'系统恢复军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',35,'打关卡扣除军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',101,'关卡获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',102,'关卡宝箱获得');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',201,'关卡挂机消耗军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',202,'关卡挂机立即完成消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',203,'副本挂机立即完成消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',204,'副本购买次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',205,'竞技场购买次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',304,'创建军团');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',305,'军团捐献');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',306,'任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',306,'推荐国家奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',307,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',308,'军团战玩家报名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',309,'军团战玩家战斗奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',310,'军团战军团奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',311,'世界boss战攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',312,'世界boss战击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',313,'世界boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',314,'世界boss战激励扣钱 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',353,'摇钱树给自己浇水增加金币 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',354,'摇钱树给好友浇水增加金币 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',355,'摇钱树一键浇水增加金币 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',356,'摇钱树摇钱消耗元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',357,'摇钱树摇钱获得金币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',358,'摇钱树金钱果奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',370,'斗地主压榨或抽干苦工干活经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',371,'斗地主购买抓捕次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',372,'斗地主购买反抗次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',373,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',400,'清除强化CD ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',401,'清除强化CD ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',402,'普通单次装备洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',403,'定向单次装备洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',404,'武器技能洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',405,'普通批量装备洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',406,'定向批量装备洗练');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',407,'装备打孔消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',408,'装备打造消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',409,'宝物升星消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',410,'宝物升阶消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',501,'过关斩将扣除军令');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',502,'过关斩将重置关卡扣元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',503,'过关斩将重置章节扣元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',601,'世界boss战清除cd扣元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',701,'过关斩将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',711,'开启心法扣将魂');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',721,'领地生产获得金币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',722,'领地刷新花费元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',723,'领地立即完成花费元宝');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',730,'坐骑单次培养消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',731,'坐骑批量培养消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',732,'清除摇动技能宝盒CD');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',733,'幸运连珠');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',734,'拉杆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',740,'内政任务立即完成花费');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',750,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',751,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',752,'目标系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',753,'目标系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',754,'内政系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',755,'内政系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',760,'女神宝藏抽奖消耗货币');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',761,'女神宝藏兑换道具消耗碎片');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',762,'女神宝藏抽奖给碎片');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',800,'点将消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',801,'点将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',802,'元宝培养消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',803,'购买神将消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',810,'女神宝藏显示奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',811,'女神宝藏实际奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',820,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',821,'购买VIP卡消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',831,'在线礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',841,'领取平台奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',850,'神秘商店元宝刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',851,'神秘商店高级刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',851,'神秘商店购买物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',861,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',871,'购买体力扣钱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',872,'购买体力给体力');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',881,'商城购买消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',882,'快捷购买物品消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',883,'快捷购买消耗');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',891,'军衔激活奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',892,'军衔俸禄奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',893,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',894,'领地献计奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (510,'money_log','金钱改变','reason',9999,'通过debug命令给金钱');
-- --money_log end----

-- --money_tree_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',1,'给自己浇水');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',2,'给好友浇水');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',3,'批量给好友浇水');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',4,'摇钱树增加经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',5,'摇钱树增加金钱果');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (522,'money_tree_log','摇钱树日志','reason',6,'摇钱树拾取金钱果');
-- --money_tree_log end----

-- --mystery_shop_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',1,'神秘商店功能开启');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',2,'免费刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',3,'珍宝票刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',4,'元宝刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',5,'VIP刷新');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',6,'购买神秘商店物品');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (533,'mystery_shop_log','神秘商店日志','reason',7,'过时刷新');
-- --mystery_shop_log end----

-- --online_time_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (511,'online_time_log','玩家在线时长','reason',0,'无意义');
-- --online_time_log end----

-- --pass_task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pass_task_log','内政任务日志','reason',1,'接受任务-旧任务数据记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pass_task_log','内政任务日志','reason',2,'投掷骰子');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pass_task_log','内政任务日志','reason',3,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (530,'pass_task_log','内政任务日志','reason',4,'完成任务');
-- --pass_task_log end----

-- --pet_exp_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',1,'关卡获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',2,'任务获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',3,'关卡获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',4,'推荐国家获得经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',5,'竞技场排名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',6,'军团战玩家报名奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',7,'军团战玩家战斗奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',8,'世界boss战攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',9,'世界boss战击杀奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',10,'世界boss战排名奖励 ');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',11,'斗地主互动增加经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',12,'斗地主从苦工获取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',13,'斗地主玩家离线时从苦工获取经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',14,'GM命令增加经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',15,'副本奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',16,'副本通关宝箱奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',17,'过关斩将奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',18,'主将经验卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',19,'副将经验卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',19,'礼包奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',20,'领地给主将经验');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',21,'竞技场攻击奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',22,'首充奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',23,'七日签到奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',24,'目标系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',25,'目标系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',26,'内政系统任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',27,'内政系统阶段奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',28,'女神宝藏显示奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',29,'女神宝藏实际奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',30,'VIP每日领取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',31,'在线礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',31,'等级礼包');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',32,'军衔激活奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',33,'军衔俸禄奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',34,'精彩活动奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (534,'pet_exp_log','经验','reason',35,'领地献计奖励');
-- --pet_exp_log end----

-- --pet_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',1,'校场招募');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',2,'武将招募卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',3,'武将解雇');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',4,'武将解雇转换装备失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',5,'特殊任务完成后直接给武将');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (527,'pet_log','武将更新','reason',9,'gm命令给');
-- --pet_log end----

-- --player_login_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (512,'player_login_log','发送用户登陆日志','reason',0,'用户登陆');
-- --player_login_log end----

-- --pop_tips_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (539,'pop_tips_log','小助手log','reason',1,'武将技能记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (539,'pop_tips_log','小助手log','reason',2,'武将上阵记录');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (539,'pop_tips_log','小助手log','reason',3,'心法升级记录');
-- --pop_tips_log end----

-- --prize_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (532,'prize_log','奖励','reason',0,'奖励成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (532,'prize_log','奖励','reason',1,'奖励失败,取平台后奖励条件不满足');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (532,'prize_log','奖励','reason',2,'补偿失败,奖励条件不满足,已扣取');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (532,'prize_log','奖励','reason',3,'奖励失败,状态被打断');
-- --prize_log end----

-- --raid_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',1,'进入副本');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',2,'离开副本');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',3,'攻击副本敌人');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',4,'领取副本通关奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',5,'攻击副本敌人结果');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',6,'重置副本增加次数');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',7,'查看副本宝箱');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',8,'击败副本中的敌人');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',10,'副本开始挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',11,'副本立即完成挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',12,'副本停止挂机');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (519,'raid_log','副本','reason',13,'检查需要完成的挂机');
-- --raid_log end----

-- --reward_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'reward_log','奖励日志','reason',1,'通过rewardId生成的奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'reward_log','奖励日志','reason',2,'通过合并奖励生成的奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (520,'reward_log','奖励日志','reason',2,'通过军团分配生成的奖励');
-- --reward_log end----

-- --step_task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (529,'step_task_log','目标任务日志','reason',1,'领取任务奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (529,'step_task_log','目标任务日志','reason',2,'领取阶段奖励');
-- --step_task_log end----

-- --task_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',0,'领取任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',1,'放弃任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',2,'完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',3,'删除已完成任务');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (514,'task_log','任务','reason',4,'删除正执行任务');
-- --task_log end----

-- --treasure_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',1,'宝物升星扣除物品失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',2,'宝物升星扣除升星符失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',3,'宝物升星扣除货币失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',4,'普通宝物升星成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',5,'普通升星成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',6,'宝物转换扣除原始物品失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',7,'宝物转换成功');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',8,'宝物升阶扣除原始物品失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',9,'宝物升阶扣除货币失败');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',10,'宝物升阶后物品不为宝物');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (526,'treasure_log','宝物日志','reason',11,'宝物升阶成功');
-- --treasure_log end----

-- --vip_log begin----
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',0,'玩家登陆');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',1,'玩家充值');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',2,'心跳检测状态改变');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',3,'零点刷新状态改变');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',4,'领取每日奖励');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',5,'使用或购买VIP卡');
insert into reason_list(log_type,log_table,log_desc,log_field,reason,reason_name) values (513,'vip_log','vip','reason',6,'首次领取');
-- --vip_log end----

