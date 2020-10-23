package com.imop.lj.gameserver.scene;

import java.util.LinkedHashMap;
import java.util.Map;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.allocate.persistance.AllocateActivityStorageUpdater;
import com.imop.lj.gameserver.arena.model.ArenaMember;
import com.imop.lj.gameserver.arena.persistance.ArenaMemberUpdater;
import com.imop.lj.gameserver.cdkeygift.persistance.CDKeyDataUpdater;
import com.imop.lj.gameserver.cdkeygift.persistance.CDKeyPO;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corps.CorpsMemberUpdater;
import com.imop.lj.gameserver.corps.CorpsUpdater;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corpsboss.CorpsBossCountRank;
import com.imop.lj.gameserver.corpsboss.CorpsBossRank;
import com.imop.lj.gameserver.corpsboss.persistance.CorpsBossCountUpdater;
import com.imop.lj.gameserver.corpsboss.persistance.CorpsBossUpdater;
import com.imop.lj.gameserver.corpswar.model.CorpsWarRank;
import com.imop.lj.gameserver.corpswar.persistance.CorpsWarUpdater;
import com.imop.lj.gameserver.dirtywords.DirtyWordsType;
import com.imop.lj.gameserver.dirtywords.DirtyWordsTypeUpdater;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityUpdater;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityUserPO;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityUserUpdater;
import com.imop.lj.gameserver.mail.SysMailInstance;
import com.imop.lj.gameserver.mail.SysMailUpdater;
import com.imop.lj.gameserver.mall.Mall;
import com.imop.lj.gameserver.mall.MallUpdater;
import com.imop.lj.gameserver.marry.Marry;
import com.imop.lj.gameserver.marry.persistance.MarryUpdater;
import com.imop.lj.gameserver.moduledata.holder.ModuleData;
import com.imop.lj.gameserver.moduledata.persistance.ModuleDataUpdater;
import com.imop.lj.gameserver.moneyreport.updater.ItemCostRecord;
import com.imop.lj.gameserver.moneyreport.updater.ItemCostRecordUpdater;
import com.imop.lj.gameserver.nvn.model.NvnRank;
import com.imop.lj.gameserver.nvn.persistance.NvnUpdater;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserOfflineDataUpdater;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.offlinedata.UserSnapUpdater;
import com.imop.lj.gameserver.overman.Overman;
import com.imop.lj.gameserver.overman.persistance.OvermanUpdater;
import com.imop.lj.gameserver.redenvelope.RedEnvelope;
import com.imop.lj.gameserver.redenvelope.persistance.RedEnvelopeUpdater;
import com.imop.lj.gameserver.title.Title;
import com.imop.lj.gameserver.title.persistance.TitleUpdater;
import com.imop.lj.gameserver.tower.Tower;
import com.imop.lj.gameserver.tower.persistance.TowerUpdater;
import com.imop.lj.gameserver.trade.Trade;
import com.imop.lj.gameserver.trade.persistens.TradeUpdater;
import com.imop.lj.gameserver.vip.Vip;
import com.imop.lj.gameserver.vip.persistance.VipUpdater;

public class CommonDataUpdater extends AbstractSceneDataUpdater {
	private static Map<Class<? extends PersistanceObject<?, ?>>, POUpdater> operationDbMap = new LinkedHashMap<Class<? extends PersistanceObject<?, ?>>, POUpdater>();

	static {
		/** 玩家离线数据 */
		operationDbMap.put(UserSnap.class, new UserSnapUpdater());
		/** 全服邮件数据 */
		operationDbMap.put(SysMailInstance.class, new SysMailUpdater());
		/** 精彩活动数据 */
		operationDbMap.put(GoodActivityPO.class, new GoodActivityUpdater());
		/** 玩家精彩活动数据 */
		operationDbMap.put(GoodActivityUserPO.class, new GoodActivityUserUpdater());
		/** 商城数据*/
		operationDbMap.put(Mall.class, new MallUpdater());
		/** 财务汇报道具数据*/
		operationDbMap.put(ItemCostRecord.class, new ItemCostRecordUpdater());
		/** 过滤词 */
		operationDbMap.put(DirtyWordsType.class, new DirtyWordsTypeUpdater());
		/**功能数据存储*/
		operationDbMap.put(ModuleData.class, new ModuleDataUpdater());
		/** cdkey数据 */
		operationDbMap.put(CDKeyPO.class, new CDKeyDataUpdater());
		/** 交易行数据 */
		operationDbMap.put(Trade.class, new TradeUpdater());
		/** 军团成员 */
		operationDbMap.put(CorpsMember.class, new CorpsMemberUpdater());
		/** 军团 */
		operationDbMap.put(Corps.class, new CorpsUpdater());
		/** 玩家离线数据2 */
		operationDbMap.put(UserOfflineData.class, new UserOfflineDataUpdater());
		/** 军团战排名 */
		operationDbMap.put(CorpsWarRank.class, new CorpsWarUpdater());
		/** 师徒关系 */
		operationDbMap.put(Overman.class,new OvermanUpdater());
		/** 夫妻关系 */
		operationDbMap.put(Marry.class,new MarryUpdater());
		/** nvn排名 */
		operationDbMap.put(NvnRank.class,new NvnUpdater());
		/** 竞技场数据 */
		operationDbMap.put(ArenaMember.class, new ArenaMemberUpdater());
		/** 称号 */
		operationDbMap.put(Title.class,new TitleUpdater());
		/** 通天塔 */
		operationDbMap.put(Tower.class,new TowerUpdater());
		/** vip */
		operationDbMap.put(Vip.class,new VipUpdater());
		/** 帮派Boss进度榜排名*/
		operationDbMap.put(CorpsBossRank.class,new CorpsBossUpdater());
		/** 帮派Boss挑战次数榜排名*/
		operationDbMap.put(CorpsBossCountRank.class,new CorpsBossCountUpdater());
		/** 帮派红包*/
        operationDbMap.put(RedEnvelope.class, new RedEnvelopeUpdater());
        /** 活动分配仓库物品*/
        operationDbMap.put(AllocateActivityStorage.class, new AllocateActivityStorageUpdater());
		
	}

	public CommonDataUpdater() {
		super();
	}
	@Override
	protected void doUpdate(LifeCycle lc) {
		if (!lc.isActive()) {
			throw new IllegalStateException(
					"Only the live object can be updated.");

		}
		PersistanceObject<?, ?> po = lc.getPO();
		POUpdater poUpdater = operationDbMap.get(po.getClass());
		poUpdater.save(po);
	}

	@Override
	protected void doDel(LifeCycle lc) {
		if (!lc.isDestroyed()) {
			throw new IllegalStateException(
					"Only the destroyed object can be deleted.");
		}
		PersistanceObject<?, ?> po = lc.getPO();
		operationDbMap.get(po.getClass()).delete(po);
	}

}
