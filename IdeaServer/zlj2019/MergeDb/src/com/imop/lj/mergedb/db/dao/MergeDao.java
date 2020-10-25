package com.imop.lj.mergedb.db.dao;

import java.util.List;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CardActivityEntity;
import com.imop.lj.db.model.CardUserEntity;
import com.imop.lj.db.model.TurntableActivityEntity;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.db.model.HorseEntity;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.db.model.QQChargeOrderEntity;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.db.model.DbVersion;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.db.model.QQMarketTaskTargetEntity;
import com.imop.lj.db.model.WorldBossEntity;
import com.imop.lj.db.model.ModuleDataEntity;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.db.model.ItemCostRecordEntity;
import com.imop.lj.db.model.LandlordEntity;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.db.model.LandEntity;
import com.imop.lj.db.model.LoopTaskEntity;
import com.imop.lj.db.model.MoneyTreeEntity;
import com.imop.lj.db.model.PassTaskEntity;
import com.imop.lj.db.model.StepTaskEntity;
import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.db.model.VipEntity;
import com.imop.lj.db.model.ShipEntity;
import com.imop.lj.db.model.IncomeEntity;
import com.imop.lj.mergedb.db.MergeDbType;

/**
 * 合服MergeDao
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class MergeDao {
	
	private DBService dbService;
	/**
	 * 合服数据库类型
	 */
	private MergeDbType type;
	
	/** 查询所有卡牌活动表 */
	public static final String queryAllCardActivityEntity_merge = "queryAllCardActivityEntity_merge";
	
	/** 删除所有卡牌活动表 */
	public static final String delAllCardActivityEntity_merge = "delAllCardActivityEntity_merge";

	/** 查询所有卡牌活动玩家数据 */
	public static final String queryAllCardUserEntity_merge = "queryAllCardUserEntity_merge";
	
	/** 删除所有卡牌活动玩家数据 */
	public static final String delAllCardUserEntity_merge = "delAllCardUserEntity_merge";

	/** 查询所有幸运转盘活动表 */
	public static final String queryAllTurntableActivityEntity_merge = "queryAllTurntableActivityEntity_merge";
	
	/** 删除所有幸运转盘活动表 */
	public static final String delAllTurntableActivityEntity_merge = "delAllTurntableActivityEntity_merge";

	/** 查询所有精彩活动数据 */
	public static final String queryAllGoodActivityEntity_merge = "queryAllGoodActivityEntity_merge";
	
	/** 删除所有精彩活动数据 */
	public static final String delAllGoodActivityEntity_merge = "delAllGoodActivityEntity_merge";

	/** 查询所有玩家的精彩活动数据 */
	public static final String queryAllGoodActivityUserEntity_merge = "queryAllGoodActivityUserEntity_merge";
	
	/** 删除所有玩家的精彩活动数据 */
	public static final String delAllGoodActivityUserEntity_merge = "delAllGoodActivityUserEntity_merge";

	/** 查询所有角色信息 */
	public static final String queryAllHumanEntity_merge = "queryAllHumanEntity_merge";
	
	/** 删除所有角色信息 */
	public static final String delAllHumanEntity_merge = "delAllHumanEntity_merge";

	/** 查询所有武将信息 */
	public static final String queryAllPetEntity_merge = "queryAllPetEntity_merge";
	
	/** 删除所有武将信息 */
	public static final String delAllPetEntity_merge = "delAllPetEntity_merge";

	/** 查询所有坐骑信息 */
	public static final String queryAllHorseEntity_merge = "queryAllHorseEntity_merge";
	
	/** 删除所有坐骑信息 */
	public static final String delAllHorseEntity_merge = "delAllHorseEntity_merge";

	/** 查询所有邮件信息 */
	public static final String queryAllMailEntity_merge = "queryAllMailEntity_merge";
	
	/** 删除所有邮件信息 */
	public static final String delAllMailEntity_merge = "delAllMailEntity_merge";

	/** 查询所有物品信息 */
	public static final String queryAllItemEntity_merge = "queryAllItemEntity_merge";
	
	/** 删除所有物品信息 */
	public static final String delAllItemEntity_merge = "delAllItemEntity_merge";

	/** 查询所有离线奖励信息 */
	public static final String queryAllOfflineRewardEntity_merge = "queryAllOfflineRewardEntity_merge";
	
	/** 删除所有离线奖励信息 */
	public static final String delAllOfflineRewardEntity_merge = "delAllOfflineRewardEntity_merge";

	/** 查询所有充值订单信息 */
	public static final String queryAllQQChargeOrderEntity_merge = "queryAllQQChargeOrderEntity_merge";
	
	/** 删除所有充值订单信息 */
	public static final String delAllQQChargeOrderEntity_merge = "delAllQQChargeOrderEntity_merge";

	/** 查询所有场景信息 */
	public static final String queryAllSceneEntity_merge = "queryAllSceneEntity_merge";
	
	/** 删除所有场景信息 */
	public static final String delAllSceneEntity_merge = "delAllSceneEntity_merge";

	/** 查询所有数据库版本信息 */
	public static final String queryAllDbVersion_merge = "queryAllDbVersion_merge";
	
	/** 删除所有数据库版本信息 */
	public static final String delAllDbVersion_merge = "delAllDbVersion_merge";

	/** 查询所有过滤词配置信息 */
	public static final String queryAllDirtyWordsTypeEntity_merge = "queryAllDirtyWordsTypeEntity_merge";
	
	/** 删除所有过滤词配置信息 */
	public static final String delAllDirtyWordsTypeEntity_merge = "delAllDirtyWordsTypeEntity_merge";

	/** 查询所有集市任务完成条件 */
	public static final String queryAllQQMarketTaskTargetEntity_merge = "queryAllQQMarketTaskTargetEntity_merge";
	
	/** 删除所有集市任务完成条件 */
	public static final String delAllQQMarketTaskTargetEntity_merge = "delAllQQMarketTaskTargetEntity_merge";

	/** 查询所有世界BOSS信息 */
	public static final String queryAllWorldBossEntity_merge = "queryAllWorldBossEntity_merge";
	
	/** 删除所有世界BOSS信息 */
	public static final String delAllWorldBossEntity_merge = "delAllWorldBossEntity_merge";

	/** 查询所有模块数据 */
	public static final String queryAllModuleDataEntity_merge = "queryAllModuleDataEntity_merge";
	
	/** 删除所有模块数据 */
	public static final String delAllModuleDataEntity_merge = "delAllModuleDataEntity_merge";

	/** 查询所有用户信息 */
	public static final String queryAllUserInfo_merge = "queryAllUserInfo_merge";
	
	/** 删除所有用户信息 */
	public static final String delAllUserInfo_merge = "delAllUserInfo_merge";

	/** 查询所有竞技场数据 */
	public static final String queryAllArenaSnapEntity_merge = "queryAllArenaSnapEntity_merge";
	
	/** 删除所有竞技场数据 */
	public static final String delAllArenaSnapEntity_merge = "delAllArenaSnapEntity_merge";

	/** 查询所有财报道具消耗记录 */
	public static final String queryAllItemCostRecordEntity_merge = "queryAllItemCostRecordEntity_merge";
	
	/** 删除所有财报道具消耗记录 */
	public static final String delAllItemCostRecordEntity_merge = "delAllItemCostRecordEntity_merge";

	/** 查询所有斗地主表 */
	public static final String queryAllLandlordEntity_merge = "queryAllLandlordEntity_merge";
	
	/** 删除所有斗地主表 */
	public static final String delAllLandlordEntity_merge = "delAllLandlordEntity_merge";

	/** 查询所有关系表 */
	public static final String queryAllRelationEntity_merge = "queryAllRelationEntity_merge";
	
	/** 删除所有关系表 */
	public static final String delAllRelationEntity_merge = "delAllRelationEntity_merge";

	/** 查询所有正在做的任务信息 */
	public static final String queryAllDoingQuestEntity_merge = "queryAllDoingQuestEntity_merge";
	
	/** 删除所有正在做的任务信息 */
	public static final String delAllDoingQuestEntity_merge = "delAllDoingQuestEntity_merge";

	/** 查询所有已经完成的任务信息 */
	public static final String queryAllFinishedQuestEntity_merge = "queryAllFinishedQuestEntity_merge";
	
	/** 删除所有已经完成的任务信息 */
	public static final String delAllFinishedQuestEntity_merge = "delAllFinishedQuestEntity_merge";

	/** 查询所有军团信息 */
	public static final String queryAllCorpsEntity_merge = "queryAllCorpsEntity_merge";
	
	/** 删除所有军团信息 */
	public static final String delAllCorpsEntity_merge = "delAllCorpsEntity_merge";

	/** 查询所有军团成员信息 */
	public static final String queryAllCorpsMemberEntity_merge = "queryAllCorpsMemberEntity_merge";
	
	/** 删除所有军团成员信息 */
	public static final String delAllCorpsMemberEntity_merge = "delAllCorpsMemberEntity_merge";

	/** 查询所有领地数据 */
	public static final String queryAllLandEntity_merge = "queryAllLandEntity_merge";
	
	/** 删除所有领地数据 */
	public static final String delAllLandEntity_merge = "delAllLandEntity_merge";

	/** 查询所有环任务 */
	public static final String queryAllLoopTaskEntity_merge = "queryAllLoopTaskEntity_merge";
	
	/** 删除所有环任务 */
	public static final String delAllLoopTaskEntity_merge = "delAllLoopTaskEntity_merge";

	/** 查询所有摇钱树 */
	public static final String queryAllMoneyTreeEntity_merge = "queryAllMoneyTreeEntity_merge";
	
	/** 删除所有摇钱树 */
	public static final String delAllMoneyTreeEntity_merge = "delAllMoneyTreeEntity_merge";

	/** 查询所有内政任务 */
	public static final String queryAllPassTaskEntity_merge = "queryAllPassTaskEntity_merge";
	
	/** 删除所有内政任务 */
	public static final String delAllPassTaskEntity_merge = "delAllPassTaskEntity_merge";

	/** 查询所有成长目标任务 */
	public static final String queryAllStepTaskEntity_merge = "queryAllStepTaskEntity_merge";
	
	/** 删除所有成长目标任务 */
	public static final String delAllStepTaskEntity_merge = "delAllStepTaskEntity_merge";

	/** 查询所有离线数据 */
	public static final String queryAllUserSnapEntity_merge = "queryAllUserSnapEntity_merge";
	
	/** 删除所有离线数据 */
	public static final String delAllUserSnapEntity_merge = "delAllUserSnapEntity_merge";

	/** 查询所有礼包奖励 */
	public static final String queryAllUserPrize_merge = "queryAllUserPrize_merge";
	
	/** 删除所有礼包奖励 */
	public static final String delAllUserPrize_merge = "delAllUserPrize_merge";

	/** 查询所有vip数据 */
	public static final String queryAllVipEntity_merge = "queryAllVipEntity_merge";
	
	/** 删除所有vip数据 */
	public static final String delAllVipEntity_merge = "delAllVipEntity_merge";

	/** 查询所有渡江船只数据 */
	public static final String queryAllShipEntity_merge = "queryAllShipEntity_merge";
	
	/** 删除所有渡江船只数据 */
	public static final String delAllShipEntity_merge = "delAllShipEntity_merge";

	/** 查询所有渡江抢夺收益 */
	public static final String queryAllIncomeEntity_merge = "queryAllIncomeEntity_merge";
	
	/** 删除所有渡江抢夺收益 */
	public static final String delAllIncomeEntity_merge = "delAllIncomeEntity_merge";

	
	public MergeDao(DBService dbService,MergeDbType type) {
		this.dbService = dbService;
		this.type = type;
	}

	@SuppressWarnings("rawtypes")
	public void saveAll(List<BaseEntity> entityList){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		dbService.saveAll(entityList);
	}

	/** 查询所有卡牌活动表 */
	@SuppressWarnings("unchecked")
	public List<CardActivityEntity> queryAllCardActivityEntity() {
		return dbService.findByNamedQuery(queryAllCardActivityEntity_merge);
	}
	
	/** 删除所有卡牌活动表 */
	public void delAllCardActivityEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllCardActivityEntity_merge, null, null);
	}
	
	/** 查询所有卡牌活动玩家数据 */
	@SuppressWarnings("unchecked")
	public List<CardUserEntity> queryAllCardUserEntity() {
		return dbService.findByNamedQuery(queryAllCardUserEntity_merge);
	}
	
	/** 删除所有卡牌活动玩家数据 */
	public void delAllCardUserEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllCardUserEntity_merge, null, null);
	}
	
	/** 查询所有幸运转盘活动表 */
	@SuppressWarnings("unchecked")
	public List<TurntableActivityEntity> queryAllTurntableActivityEntity() {
		return dbService.findByNamedQuery(queryAllTurntableActivityEntity_merge);
	}
	
	/** 删除所有幸运转盘活动表 */
	public void delAllTurntableActivityEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllTurntableActivityEntity_merge, null, null);
	}
	
	/** 查询所有精彩活动数据 */
	@SuppressWarnings("unchecked")
	public List<GoodActivityEntity> queryAllGoodActivityEntity() {
		return dbService.findByNamedQuery(queryAllGoodActivityEntity_merge);
	}
	
	/** 删除所有精彩活动数据 */
	public void delAllGoodActivityEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllGoodActivityEntity_merge, null, null);
	}
	
	/** 查询所有玩家的精彩活动数据 */
	@SuppressWarnings("unchecked")
	public List<GoodActivityUserEntity> queryAllGoodActivityUserEntity() {
		return dbService.findByNamedQuery(queryAllGoodActivityUserEntity_merge);
	}
	
	/** 删除所有玩家的精彩活动数据 */
	public void delAllGoodActivityUserEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllGoodActivityUserEntity_merge, null, null);
	}
	
	/** 查询所有角色信息 */
	@SuppressWarnings("unchecked")
	public List<HumanEntity> queryAllHumanEntity() {
		return dbService.findByNamedQuery(queryAllHumanEntity_merge);
	}
	
	/** 删除所有角色信息 */
	public void delAllHumanEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllHumanEntity_merge, null, null);
	}
	
	/** 查询所有武将信息 */
	@SuppressWarnings("unchecked")
	public List<PetEntity> queryAllPetEntity() {
		return dbService.findByNamedQuery(queryAllPetEntity_merge);
	}
	
	/** 删除所有武将信息 */
	public void delAllPetEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllPetEntity_merge, null, null);
	}
	
	/** 查询所有坐骑信息 */
	@SuppressWarnings("unchecked")
	public List<HorseEntity> queryAllHorseEntity() {
		return dbService.findByNamedQuery(queryAllHorseEntity_merge);
	}
	
	/** 删除所有坐骑信息 */
	public void delAllHorseEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllHorseEntity_merge, null, null);
	}
	
	/** 查询所有邮件信息 */
	@SuppressWarnings("unchecked")
	public List<MailEntity> queryAllMailEntity() {
		return dbService.findByNamedQuery(queryAllMailEntity_merge);
	}
	
	/** 删除所有邮件信息 */
	public void delAllMailEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllMailEntity_merge, null, null);
	}
	
	/** 查询所有物品信息 */
	@SuppressWarnings("unchecked")
	public List<ItemEntity> queryAllItemEntity() {
		return dbService.findByNamedQuery(queryAllItemEntity_merge);
	}
	
	/** 删除所有物品信息 */
	public void delAllItemEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllItemEntity_merge, null, null);
	}
	
	/** 查询所有离线奖励信息 */
	@SuppressWarnings("unchecked")
	public List<OfflineRewardEntity> queryAllOfflineRewardEntity() {
		return dbService.findByNamedQuery(queryAllOfflineRewardEntity_merge);
	}
	
	/** 删除所有离线奖励信息 */
	public void delAllOfflineRewardEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllOfflineRewardEntity_merge, null, null);
	}
	
	/** 查询所有充值订单信息 */
	@SuppressWarnings("unchecked")
	public List<QQChargeOrderEntity> queryAllQQChargeOrderEntity() {
		return dbService.findByNamedQuery(queryAllQQChargeOrderEntity_merge);
	}
	
	/** 删除所有充值订单信息 */
	public void delAllQQChargeOrderEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllQQChargeOrderEntity_merge, null, null);
	}
	
	/** 查询所有场景信息 */
	@SuppressWarnings("unchecked")
	public List<SceneEntity> queryAllSceneEntity() {
		return dbService.findByNamedQuery(queryAllSceneEntity_merge);
	}
	
	/** 删除所有场景信息 */
	public void delAllSceneEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllSceneEntity_merge, null, null);
	}
	
	/** 查询所有数据库版本信息 */
	@SuppressWarnings("unchecked")
	public List<DbVersion> queryAllDbVersion() {
		return dbService.findByNamedQuery(queryAllDbVersion_merge);
	}
	
	/** 删除所有数据库版本信息 */
	public void delAllDbVersion(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllDbVersion_merge, null, null);
	}
	
	/** 查询所有过滤词配置信息 */
	@SuppressWarnings("unchecked")
	public List<DirtyWordsTypeEntity> queryAllDirtyWordsTypeEntity() {
		return dbService.findByNamedQuery(queryAllDirtyWordsTypeEntity_merge);
	}
	
	/** 删除所有过滤词配置信息 */
	public void delAllDirtyWordsTypeEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllDirtyWordsTypeEntity_merge, null, null);
	}
	
	/** 查询所有集市任务完成条件 */
	@SuppressWarnings("unchecked")
	public List<QQMarketTaskTargetEntity> queryAllQQMarketTaskTargetEntity() {
		return dbService.findByNamedQuery(queryAllQQMarketTaskTargetEntity_merge);
	}
	
	/** 删除所有集市任务完成条件 */
	public void delAllQQMarketTaskTargetEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllQQMarketTaskTargetEntity_merge, null, null);
	}
	
	/** 查询所有世界BOSS信息 */
	@SuppressWarnings("unchecked")
	public List<WorldBossEntity> queryAllWorldBossEntity() {
		return dbService.findByNamedQuery(queryAllWorldBossEntity_merge);
	}
	
	/** 删除所有世界BOSS信息 */
	public void delAllWorldBossEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllWorldBossEntity_merge, null, null);
	}
	
	/** 查询所有模块数据 */
	@SuppressWarnings("unchecked")
	public List<ModuleDataEntity> queryAllModuleDataEntity() {
		return dbService.findByNamedQuery(queryAllModuleDataEntity_merge);
	}
	
	/** 删除所有模块数据 */
	public void delAllModuleDataEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllModuleDataEntity_merge, null, null);
	}
	
	/** 查询所有用户信息 */
	@SuppressWarnings("unchecked")
	public List<UserInfo> queryAllUserInfo() {
		return dbService.findByNamedQuery(queryAllUserInfo_merge);
	}
	
	/** 删除所有用户信息 */
	public void delAllUserInfo(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllUserInfo_merge, null, null);
	}
	
	/** 查询所有竞技场数据 */
	@SuppressWarnings("unchecked")
	public List<ArenaSnapEntity> queryAllArenaSnapEntity() {
		return dbService.findByNamedQuery(queryAllArenaSnapEntity_merge);
	}
	
	/** 删除所有竞技场数据 */
	public void delAllArenaSnapEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllArenaSnapEntity_merge, null, null);
	}
	
	/** 查询所有财报道具消耗记录 */
	@SuppressWarnings("unchecked")
	public List<ItemCostRecordEntity> queryAllItemCostRecordEntity() {
		return dbService.findByNamedQuery(queryAllItemCostRecordEntity_merge);
	}
	
	/** 删除所有财报道具消耗记录 */
	public void delAllItemCostRecordEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllItemCostRecordEntity_merge, null, null);
	}
	
	/** 查询所有斗地主表 */
	@SuppressWarnings("unchecked")
	public List<LandlordEntity> queryAllLandlordEntity() {
		return dbService.findByNamedQuery(queryAllLandlordEntity_merge);
	}
	
	/** 删除所有斗地主表 */
	public void delAllLandlordEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllLandlordEntity_merge, null, null);
	}
	
	/** 查询所有关系表 */
	@SuppressWarnings("unchecked")
	public List<RelationEntity> queryAllRelationEntity() {
		return dbService.findByNamedQuery(queryAllRelationEntity_merge);
	}
	
	/** 删除所有关系表 */
	public void delAllRelationEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllRelationEntity_merge, null, null);
	}
	
	/** 查询所有正在做的任务信息 */
	@SuppressWarnings("unchecked")
	public List<DoingQuestEntity> queryAllDoingQuestEntity() {
		return dbService.findByNamedQuery(queryAllDoingQuestEntity_merge);
	}
	
	/** 删除所有正在做的任务信息 */
	public void delAllDoingQuestEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllDoingQuestEntity_merge, null, null);
	}
	
	/** 查询所有已经完成的任务信息 */
	@SuppressWarnings("unchecked")
	public List<FinishedQuestEntity> queryAllFinishedQuestEntity() {
		return dbService.findByNamedQuery(queryAllFinishedQuestEntity_merge);
	}
	
	/** 删除所有已经完成的任务信息 */
	public void delAllFinishedQuestEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllFinishedQuestEntity_merge, null, null);
	}
	
	/** 查询所有军团信息 */
	@SuppressWarnings("unchecked")
	public List<CorpsEntity> queryAllCorpsEntity() {
		return dbService.findByNamedQuery(queryAllCorpsEntity_merge);
	}
	
	/** 删除所有军团信息 */
	public void delAllCorpsEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllCorpsEntity_merge, null, null);
	}
	
	/** 查询所有军团成员信息 */
	@SuppressWarnings("unchecked")
	public List<CorpsMemberEntity> queryAllCorpsMemberEntity() {
		return dbService.findByNamedQuery(queryAllCorpsMemberEntity_merge);
	}
	
	/** 删除所有军团成员信息 */
	public void delAllCorpsMemberEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllCorpsMemberEntity_merge, null, null);
	}
	
	/** 查询所有领地数据 */
	@SuppressWarnings("unchecked")
	public List<LandEntity> queryAllLandEntity() {
		return dbService.findByNamedQuery(queryAllLandEntity_merge);
	}
	
	/** 删除所有领地数据 */
	public void delAllLandEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllLandEntity_merge, null, null);
	}
	
	/** 查询所有环任务 */
	@SuppressWarnings("unchecked")
	public List<LoopTaskEntity> queryAllLoopTaskEntity() {
		return dbService.findByNamedQuery(queryAllLoopTaskEntity_merge);
	}
	
	/** 删除所有环任务 */
	public void delAllLoopTaskEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllLoopTaskEntity_merge, null, null);
	}
	
	/** 查询所有摇钱树 */
	@SuppressWarnings("unchecked")
	public List<MoneyTreeEntity> queryAllMoneyTreeEntity() {
		return dbService.findByNamedQuery(queryAllMoneyTreeEntity_merge);
	}
	
	/** 删除所有摇钱树 */
	public void delAllMoneyTreeEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllMoneyTreeEntity_merge, null, null);
	}
	
	/** 查询所有内政任务 */
	@SuppressWarnings("unchecked")
	public List<PassTaskEntity> queryAllPassTaskEntity() {
		return dbService.findByNamedQuery(queryAllPassTaskEntity_merge);
	}
	
	/** 删除所有内政任务 */
	public void delAllPassTaskEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllPassTaskEntity_merge, null, null);
	}
	
	/** 查询所有成长目标任务 */
	@SuppressWarnings("unchecked")
	public List<StepTaskEntity> queryAllStepTaskEntity() {
		return dbService.findByNamedQuery(queryAllStepTaskEntity_merge);
	}
	
	/** 删除所有成长目标任务 */
	public void delAllStepTaskEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllStepTaskEntity_merge, null, null);
	}
	
	/** 查询所有离线数据 */
	@SuppressWarnings("unchecked")
	public List<UserSnapEntity> queryAllUserSnapEntity() {
		return dbService.findByNamedQuery(queryAllUserSnapEntity_merge);
	}
	
	/** 删除所有离线数据 */
	public void delAllUserSnapEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllUserSnapEntity_merge, null, null);
	}
	
	/** 查询所有礼包奖励 */
	@SuppressWarnings("unchecked")
	public List<UserPrize> queryAllUserPrize() {
		return dbService.findByNamedQuery(queryAllUserPrize_merge);
	}
	
	/** 删除所有礼包奖励 */
	public void delAllUserPrize(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllUserPrize_merge, null, null);
	}
	
	/** 查询所有vip数据 */
	@SuppressWarnings("unchecked")
	public List<VipEntity> queryAllVipEntity() {
		return dbService.findByNamedQuery(queryAllVipEntity_merge);
	}
	
	/** 删除所有vip数据 */
	public void delAllVipEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllVipEntity_merge, null, null);
	}
	
	/** 查询所有渡江船只数据 */
	@SuppressWarnings("unchecked")
	public List<ShipEntity> queryAllShipEntity() {
		return dbService.findByNamedQuery(queryAllShipEntity_merge);
	}
	
	/** 删除所有渡江船只数据 */
	public void delAllShipEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllShipEntity_merge, null, null);
	}
	
	/** 查询所有渡江抢夺收益 */
	@SuppressWarnings("unchecked")
	public List<IncomeEntity> queryAllIncomeEntity() {
		return dbService.findByNamedQuery(queryAllIncomeEntity_merge);
	}
	
	/** 删除所有渡江抢夺收益 */
	public void delAllIncomeEntity(){
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.queryForUpdate(delAllIncomeEntity_merge, null, null);
	}
	
}
