package com.imop.lj.mergedb.service;

import java.text.MessageFormat;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.mergedb.exception.MergeException;
import com.imop.lj.mergedb.log.Loggers;
import com.imop.lj.mergedb.strategy.IStrategy;
import com.imop.lj.mergedb.strategy.impl.ArenaSnapEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.CardActivityEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.CardUserEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.CorpsEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.CorpsMemberEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.DbVersionStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.DirtyWordsTypeEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.DoingQuestEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.FinishedQuestEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.GoodActivityEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.GoodActivityUserEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.HorseEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.HumanEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.IncomeEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.ItemCostRecordEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.ItemEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.LandEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.LandlordEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.LoopTaskEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.MailEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.ModuleDataEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.MoneyTreeEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.OfflineRewardEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.PassTaskEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.PetEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.QQChargeOrderEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.QQMarketTaskTargetEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.RelationEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.SceneEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.ShipEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.StepTaskEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.TurntableActivityEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.UserInfoStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.UserPrizeStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.UserSnapEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.VipEntityStrategyImpl;
import com.imop.lj.mergedb.strategy.impl.WorldBossEntityStrategyImpl;

public class MergeStrategyService implements InitializeRequired {
	// 重命名的标记
	public static final int RENAME_FLAG = 1;
	
	protected Map<String, IStrategy> strategyMap = new java.util.LinkedHashMap<String, IStrategy>();
	
	protected HumanEntityStrategyImpl humanStrategy = new HumanEntityStrategyImpl();
	
	protected DbVersionStrategyImpl dbVersionStrategy = new DbVersionStrategyImpl();
	
	@Override
	public void init() {
		strategyMap.put("ArenaSnapEntityStrategyImpl", new ArenaSnapEntityStrategyImpl());
		strategyMap.put("CorpsEntityStrategyImpl", new CorpsEntityStrategyImpl());
		strategyMap.put("CorpsMemberEntityStrategyImpl", new CorpsMemberEntityStrategyImpl());
		strategyMap.put("DirtyWordsTypeEntityStrategyImpl", new DirtyWordsTypeEntityStrategyImpl());
		strategyMap.put("DoingQuestEntityStrategyImpl", new DoingQuestEntityStrategyImpl());
		strategyMap.put("FinishedQuestEntityStrategyImpl", new FinishedQuestEntityStrategyImpl());
		strategyMap.put("HorseEntityStrategyImpl", new HorseEntityStrategyImpl());
		strategyMap.put("ItemCostRecordEntityStrategyImpl", new ItemCostRecordEntityStrategyImpl());
		strategyMap.put("ItemEntityStrategyImpl", new ItemEntityStrategyImpl());
		strategyMap.put("LandEntityStrategyImpl", new LandEntityStrategyImpl());
		strategyMap.put("LandlordEntityStrategyImpl", new LandlordEntityStrategyImpl());
		strategyMap.put("LoopTaskEntityStrategyImpl", new LoopTaskEntityStrategyImpl());
		strategyMap.put("MailEntityStrategyImpl", new MailEntityStrategyImpl());
		strategyMap.put("MoneyTreeEntityStrategyImpl", new MoneyTreeEntityStrategyImpl());
		strategyMap.put("OfflineRewardEntityStrategyImpl", new OfflineRewardEntityStrategyImpl());
		strategyMap.put("PassTaskEntityStrategyImpl", new PassTaskEntityStrategyImpl());
		strategyMap.put("PetEntityStrategyImpl", new PetEntityStrategyImpl());
		strategyMap.put("QQChargeOrderEntityStrategyImpl", new QQChargeOrderEntityStrategyImpl());
		strategyMap.put("QQMarketTaskTargetEntityStrategyImpl", new QQMarketTaskTargetEntityStrategyImpl());
		strategyMap.put("RelationEntityStrategyImpl", new RelationEntityStrategyImpl());
		strategyMap.put("SceneEntityStrategyImpl", new SceneEntityStrategyImpl());
		strategyMap.put("StepTaskEntityStrategyImpl", new StepTaskEntityStrategyImpl());
		strategyMap.put("UserInfoStrategyImpl", new UserInfoStrategyImpl());
		strategyMap.put("UserPrizeStrategyImpl", new UserPrizeStrategyImpl());
		strategyMap.put("UserSnapEntityStrategyImpl", new UserSnapEntityStrategyImpl());
		strategyMap.put("VipEntityStrategyImpl", new VipEntityStrategyImpl());
		strategyMap.put("WorldBossEntityStrategyImpl", new WorldBossEntityStrategyImpl());
		strategyMap.put("ShipEntityStrategyImpl", new ShipEntityStrategyImpl());
		strategyMap.put("IncomeEntityStrategyImpl", new IncomeEntityStrategyImpl());
		strategyMap.put("ModuleDataEntityStrategyImpl", new ModuleDataEntityStrategyImpl());
		// 新增活动的策略，注意：活动表先，玩家表后，因为玩家表用到了活动表的数据
		strategyMap.put("CardActivityEntityStrategyImpl", new CardActivityEntityStrategyImpl());
		strategyMap.put("CardUserEntityStrategyImpl", new CardUserEntityStrategyImpl());
		strategyMap.put("TurntableActivityEntityStrategyImpl", new TurntableActivityEntityStrategyImpl());
		strategyMap.put("GoodActivityEntityStrategyImpl", new GoodActivityEntityStrategyImpl());
		strategyMap.put("GoodActivityUserEntityStrategyImpl", new GoodActivityUserEntityStrategyImpl());
		
	}

	/**
	 * 获取需要删除的角色Id集合
	 * @return
	 */
	public Set<Long> getDeletedCharIdSet() {
		return humanStrategy.getDeletedCharIdSet();
	}

	/**
	 * 获取需要重命名的角色Id的Map<角色Id，新名字>
	 * @return
	 */
	public Map<Long, String> getRenameCharNameMap() {
		return humanStrategy.getRenameCharNameMap();
	}
	
	public int getHumanServerId(long humanId) {
		return humanStrategy.getHumanServerIdMap().get(humanId);
	}
	
	public Map<Integer, String> getServerNameMap() {
		return dbVersionStrategy.getServerNameMap();
	}
	
	public Set<Long> getCardActivityClosedIdSet() {
		return ((CardActivityEntityStrategyImpl)strategyMap.get("CardActivityEntityStrategyImpl")).getClosedIdSet();
	}
	
	public Set<Long> getGoodActivityClosedIdSet() {
		return ((GoodActivityEntityStrategyImpl)strategyMap.get("GoodActivityEntityStrategyImpl")).getClosedIdSet();
	}
	
	/**
	 * 后去合服的名字后缀，从dbVersion生成的map中获取
	 * @param serverId
	 * @return
	 */
	public String getServerNameOfMerge(int serverId) {
		if (!getServerNameMap().containsKey(serverId)) {
			throw new MergeException("", "", MessageFormat.format("serverId找不到对应的serverName！serverId={1}", serverId));
		}
		return getServerNameMap().get(serverId);
	}
	
	public void start() {
		// 先执行dbVersion策略，生成serverNameMap
		dbVersionStrategy.execute();
		// 执行human的策略，其他的依赖其生成的一些数据
		humanStrategy.execute();
		
		strategyMap.remove("DbVersionStrategyImpl");
		strategyMap.remove("HumanEntityStrategyImpl");
		int size = strategyMap.size();
		int increment = (int)(100.0f / size);
		Loggers.mergeProgressDbLogger.info("strategyMap size="+size+";increment="+increment);
		int i=0;
		for(IStrategy s : strategyMap.values()){
			s.execute();
			i++;
			
			Loggers.mergeProgressDbLogger.info("合服进度   " + increment * i + "%" + ".....");
		}
		if (i == size) {
			Loggers.mergeProgressDbLogger.info("合服进度   " + "100%" + ".....");
		}
	}
}
