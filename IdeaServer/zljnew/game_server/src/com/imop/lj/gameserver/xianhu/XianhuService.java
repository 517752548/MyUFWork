package com.imop.lj.gameserver.xianhu;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.XianhuRankInfo;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.XianhuEntity;
import com.imop.lj.db.model.XianhuRankEntity;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCXianhuPanel;
import com.imop.lj.gameserver.human.msg.GCXianhuRankList;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.xianhu.XianhuDef.XianhuRankType;
import com.imop.lj.gameserver.xianhu.model.Xianhu;
import com.imop.lj.gameserver.xianhu.model.XianhuCurRank;
import com.imop.lj.gameserver.xianhu.model.XianhuRank;
import com.imop.lj.gameserver.xianhu.model.XianhuRankTmp;
import com.imop.lj.gameserver.xianhu.template.XianhuRankRewardTemplate;

public class XianhuService implements InitializeRequired {
	protected static XianhuRankComparator RankSortor;
	
	/** 玩家仙葫数据Map */
	protected Map<Long, Xianhu> roleMap = Maps.newHashMap();
	
	/** 昨日上周排行数据，db中的数据 */
	protected Map<XianhuRankType, List<XianhuRank>> preRankMap = Maps.newHashMap();
	/** 玩家昨日上周排行数据，同preRankMap变化而变化 */
	protected Map<XianhuRankType, Map<Long, XianhuRank>> rolePreRankMap = Maps.newHashMap();
	
	/** 当前排行数据，内存中的数据 */
	protected Map<XianhuRankType, List<XianhuCurRank>> curRankMap = Maps.newHashMap();
	
	/** 显示排行用的缓存数据 */
	protected Map<XianhuRankType, List<XianhuRankInfo>> showCacheMap = Maps.newHashMap();
	
	
	public XianhuService() {
		RankSortor = new XianhuRankComparator();
		
		//验证仙葫排行时间id是否存在
		if (Globals.getTemplateCacheService().get(XianhuDef.RankTimeEventId, TimeEventTemplate.class) == null) {
			throw new TemplateConfigException("", 0, "仙葫排行时间id不存在！");
		}
	}
	
	@Override
	public void init() {
		//加载玩家仙葫数据
		List<XianhuEntity> roleEntityList = Globals.getDaoService().getXianhuDao().loadAllEntity();
		if (roleEntityList != null && !roleEntityList.isEmpty()) {
			for (XianhuEntity entity : roleEntityList) {
				Xianhu xianhu = new Xianhu();
				xianhu.fromEntity(entity);
				this.roleMap.put(xianhu.getRoleId(), xianhu);
			}
		}
		
		//加载preRankMap的数据
		List<XianhuRankEntity> rankEntityList = Globals.getDaoService().getXianhuRankDao().loadAllEntity();
		if (rankEntityList != null && !rankEntityList.isEmpty()) {
			for (XianhuRankEntity entity : rankEntityList) {
				XianhuRank xianhuRank = new XianhuRank();
				xianhuRank.fromEntity(entity);
				
				XianhuRankType type = XianhuRankType.valueOf(xianhuRank.getRankType());
				
				List<XianhuRank> lst = this.preRankMap.get(type);
				if (lst == null) {
					lst = new ArrayList<XianhuRank>();
					this.preRankMap.put(type, lst);
				}
				lst.add(xianhuRank);
				
				Map<Long, XianhuRank> rm = this.rolePreRankMap.get(type);
				if (rm == null) {
					rm = new HashMap<Long, XianhuRank>();
					this.rolePreRankMap.put(type, rm);
				}
				rm.put(xianhuRank.getRoleId(), xianhuRank);
			}
			
			//按rank字段排序下
			for (XianhuRankType type : this.preRankMap.keySet()) {
				Collections.sort(this.preRankMap.get(type), new Comparator<XianhuRank>() {
					@Override
					public int compare(XianhuRank o1, XianhuRank o2) {
						if (o1.getRank() > o2.getRank()) {
							return 1;
						}
						return -1;
					}
				});
				
				//更新显示用的缓存数据
				refreshShowCacheByPreRankType(type);
			}
		}
		
		//刷新当前排行数据
		refreshCurRank(false);
	}
	
	protected void refreshShowCacheByPreRankType(XianhuRankType preType) {
		List<XianhuRankInfo> infoList = new ArrayList<XianhuRankInfo>();
		List<XianhuRank> preList = this.preRankMap.get(preType);
		if (preList != null && !preList.isEmpty()) {
			for (XianhuRank xr : preList) {
				infoList.add(buildXianhuRankInfo(xr.getRoleId(), xr.getRank(), xr.getTargetCount()));
			}
		}
		//更新缓存
		this.showCacheMap.put(preType, infoList);
	}
	
	protected void refreshShowCacheByCurRankType(XianhuRankType preType) {
		List<XianhuRankInfo> infoList = new ArrayList<XianhuRankInfo>();
		List<XianhuCurRank> preList = this.curRankMap.get(preType);
		if (preList != null && !preList.isEmpty()) {
			for (XianhuCurRank xr : preList) {
				infoList.add(buildXianhuRankInfo(xr.getRoleId(), xr.getRank(), xr.getTargetCount()));
			}
		}
		//更新缓存
		this.showCacheMap.put(preType, infoList);
	}
	
	protected XianhuRankInfo buildXianhuRankInfo(long roleId, int rank, int targetCount) {
		XianhuRankInfo info = new XianhuRankInfo();
		info.setRoleId(roleId);
		info.setName(Globals.getOfflineDataService().getUserName(roleId));
		info.setTplId(Globals.getOfflineDataService().getUserTplId(roleId));
		info.setLevel(Globals.getOfflineDataService().getUserLevel(roleId));
		info.setRank(rank);
		info.setNum(targetCount);
		info.setCorpsId(Globals.getCorpsService().getUserCorpsId(roleId));
		info.setCorpsName(Globals.getCorpsService().getUserCorpsName(roleId));
		return info;
	}
	
	/**
	 * 打开仙葫面板
	 * @param human
	 */
	public void openXianhuPanel(Human human) {
		//发消息更新面板
		human.sendMessage(buildGCXianhuPanel(human));
	}
	
	/**
	 * 开启祝福仙葫
	 * @param human
	 */
	public void playZhufu(Human human) {
		//背包是否有空格
		if (human.getInventory().getPrimBag().getEmptySlot() == null) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL);
			return;
		}
		
		BehaviorTypeEnum bt = BehaviorTypeEnum.XIANHU_ZHUFU;
		//次数是否已达上限
		if (!human.getBehaviorManager().canDo(bt)) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL1);
			return;
		}
		
		int count = human.getBehaviorManager().getCount(bt) + 1;
		int costGold = count * Globals.getGameConstants().getXianhuZhufuCostCoef();
		
		//银子是否足够
		if (!human.hasEnoughMoney(costGold, Currency.GOLD2, false)) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL2);
			return;
		}
		
		//扣银子
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.XIANHU_ZHUFU_COST, count);
		if (!human.costMoney(costGold, Currency.GOLD2, true, 0, MoneyLogReason.XIANHU_ZHUFU_COST, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣次数
		human.getBehaviorManager().doBehavior(bt);
		
		//给开仙葫奖励
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), 
				Globals.getGameConstants().getXianhuZhufuRewardId(), "xianhuZhufu:" + count);
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		if (!flag) {
			Loggers.humanLogger.error("xianhu zhufu reward flag is false!roleId=" + human.getUUID() + ";count=" + count);
		}
		
		//发消息更新面板
		human.sendMessage(buildGCXianhuPanel(human));
	}
	
	/**
	 * 开启祈福仙葫
	 * @param human
	 */
	public void playQifu(Human human) {
		if (!canPlayByTime()) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL7);
			return;
		}
		
		//背包是否有空格
		if (human.getInventory().getPrimBag().getEmptySlot() == null) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL);
			return;
		}
		long roleId = human.getUUID();
		long now = Globals.getTimeService().now();
		
		int count = 1;
		if (hasXianhuData(roleId)) {
			Xianhu xh = getOrCreateXianhu(roleId);
			if (TimeUtils.isSameDay(now, xh.getNormalLastTime())) {
				count = xh.getNormalCount() + 1;
			}
		}

		//花费的金子数
		int costBond = Globals.getGameConstants().getXianhuQifuCostBond();
		
		//金子是否足够
		if (!human.hasEnoughMoney(costBond, Currency.BOND, false)) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL3);
			return;
		}
		
		//次数是否已达上限
		if (count > Globals.getGameConstants().getXianhuQifuMaxNum()) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL1);
			return;
		}
		
		//扣金子
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.XIANHU_QIFU_COST, count);
		if (!human.costMoney(costBond, Currency.BOND, true, 0, MoneyLogReason.XIANHU_QIFU_COST, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣次数
		Xianhu xh = getOrCreateXianhu(roleId);
		xh.setNormalCount(count);
		xh.setNormalLastTime(now);
		xh.setModified();
		
		//给开仙葫奖励
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), 
				Globals.getGameConstants().getXianhuQifuRewardId(), "xianhuQifu:" + count);
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		if (!flag) {
			Loggers.humanLogger.error("xianhu qifu reward flag is false!roleId=" + human.getUUID() + ";count=" + count);
		}
		
		//判断是否需要给额外奖励，如果有则增加额外奖励次数
		if (count % Globals.getGameConstants().getXianhuQifuExtra1Num() == 0) {
			human.getBehaviorManager().addOp(BehaviorTypeEnum.XIANHU_FUGUI);
		}
		if (count % Globals.getGameConstants().getXianhuQifuExtra2Num() == 0) {
			human.getBehaviorManager().addOp(BehaviorTypeEnum.XIANHU_ZHIZUN);
		}
		
		//发消息更新面板
		human.sendMessage(buildGCXianhuPanel(human));
	}
	
	/**
	 * 领取额外奖励
	 * @param human
	 * @param isZhizun false富贵仙葫，true至尊仙葫
	 */
	public void giveExtraReward(Human human, boolean isZhizun) {
		//背包是否有空格
		if (human.getInventory().getPrimBag().getEmptySlot() == null) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL);
			return;
		}
		
		BehaviorTypeEnum bt = BehaviorTypeEnum.XIANHU_FUGUI;
		if (isZhizun) {
			bt = BehaviorTypeEnum.XIANHU_ZHIZUN;
		}
		
		//是否有可领取次数
		if (!human.getBehaviorManager().canDo(bt)) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL4);
			return;
		}
		
		//扣次数
		human.getBehaviorManager().doBehavior(bt);

		//给开仙葫奖励
		int rewardId = Globals.getGameConstants().getXianhuFuguiRewardId();
		if (isZhizun) {
			rewardId = Globals.getGameConstants().getXianhuZhizunRewardId();
		}
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, "xianhuExtra;type=" + bt);
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		if (!flag) {
			Loggers.humanLogger.error("xianhu extra reward flag is false!roleId=" + human.getUUID() + ";bt=" + bt);
		}
		
		//发消息更新面板
		human.sendMessage(buildGCXianhuPanel(human));
	}
	
	/**
	 * 获取今日开启祈福仙葫次数
	 * @param roleId
	 * @return
	 */
	protected int getQifuNum(long roleId) {
		int count = 0;
		if (hasXianhuData(roleId)) {
			Xianhu xh = getOrCreateXianhu(roleId);
			if (TimeUtils.isSameDay(Globals.getTimeService().now(), xh.getNormalLastTime())) {
				count = xh.getNormalCount();
			}
		}
		return count;
	}
	
	protected GCXianhuPanel buildGCXianhuPanel(Human human) {
		GCXianhuPanel msg = new GCXianhuPanel();
		
		msg.setZhufuNum(human.getBehaviorManager().getCount(BehaviorTypeEnum.XIANHU_ZHUFU));
		msg.setQifuNum(getQifuNum(human.getUUID()));
		msg.setFuguiNum(human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.XIANHU_FUGUI));
		msg.setZhizunNum(human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.XIANHU_ZHIZUN));
		msg.setRewardId(Globals.getGameConstants().getXianhuShowRewardId());
		msg.setFuguiRewardId(Globals.getGameConstants().getXianhuFuguiShowRewardId());
		msg.setZhizunRewardId(Globals.getGameConstants().getXianhuZhizunShowRewardId());
		
		return msg;
	}
	
	/**
	 * 显示仙葫排行榜数据
	 * @param human
	 * @param type
	 */
	public void showRankPanel(Human human, XianhuRankType type) {
		List<XianhuRankInfo> infoList = this.showCacheMap.get(type);
		if (infoList == null) {
			infoList = new ArrayList<XianhuRankInfo>();
		}
		
		//获取自身的排行信息
		long roleId = human.getUUID();
		int myRank = 0;
		int myNum = 0;
		long myCorpsId = Globals.getCorpsService().getUserCorpsId(roleId);
		String myCorpsName = Globals.getCorpsService().getCorpsNameByHumanId(roleId);
		for (XianhuRankInfo info : infoList) {
			if (info.getRoleId() == roleId) {
				myRank = info.getRank();
				myNum = info.getNum();
				break;
			}
		}
		
		//发消息
		human.sendMessage(new GCXianhuRankList(type.getIndex(), myRank, myNum, myCorpsId, myCorpsName, infoList.toArray(new XianhuRankInfo[0])));
	}
	
	/**
	 * 领取仙葫排行奖励
	 * @param human
	 */
	public void giveRankReward(Human human, XianhuRankType type) {
		long roleId = human.getUUID();
		//玩家仙葫数据
		Xianhu xh = getXianhu(roleId);
		if (xh == null) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL5);
			return;
		}
		
		//查询玩家是否有未领取的排行奖励
		XianhuRank xr = getRolePreRankByType(roleId, type);
		//没进入排名
		if (xr == null) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL5);
			return;
		}
		int rank = xr.getRank();
		//该排名是否有奖励
		boolean hasReward = Globals.getTemplateCacheService().getXianhuTemplateCache().hasRankReward(type, rank);
		if (!hasReward) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL5);
			return;
		}
		//已经领取过该奖励
		if (xr.getRewardFlag() == 1) {
			human.sendErrorMessage(LangConstants.XIANHU_FAIL6);
			return;
		}
	
		XianhuRankRewardTemplate rankRewardTpl = Globals.getTemplateCacheService().getXianhuTemplateCache().getRankRewardTpl(type, rank);
		if (rankRewardTpl == null) {
			//前面验证了是否有奖励，不应该走到这里
			return;
		}
		
		//设置奖励为已领取状态
		xr.setRewardFlag(1);
		xr.setRewardTime(Globals.getTimeService().now());
		xr.setModified();
		
		//发消息
		human.sendErrorMessage(LangConstants.XIANHU_RANK_REWARD_NOTICE, Globals.getLangService().readSysLang(type.getLangId()));
		
		//给奖励
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rankRewardTpl.getRewardId(), 
				"xianhuRank;type=" + type + ";rank=" + rank);
		boolean rewardFlag = Globals.getRewardService().giveReward(human, reward, true);
		if (!rewardFlag) {
			Loggers.humanLogger.error("xianhu extra reward flag is false!roleId=" + human.getUUID() + ";bt=" + type + ";rank=" + rank);
		}
	}
	
	protected XianhuRank getRolePreRankByType(long roleId, XianhuRankType type) {
		if (this.rolePreRankMap.containsKey(type)
				&& this.rolePreRankMap.get(type).containsKey(roleId)) {
			return this.rolePreRankMap.get(type).get(roleId);
		}
		return null;
	}
	
	/**
	 * 使用灵犀仙葫道具时，计数处理
	 * @param roleId
	 * @param count
	 */
	public void onPlayLingxi(long roleId, int count) {
		Xianhu xh = getOrCreateXianhu(roleId);
		
		long now = Globals.getTimeService().now();
		//日的灵犀
		int dayCount = xh.getLingxiDayCount() + count;
		//如果最后一次更新时间和当前时间不是同一天，则数据为旧数据，需要清零重新计数
		if (!TimeUtils.isSameDay(now, xh.getLingxiDayLastTime())) {
			dayCount = count;
		}
		xh.setLingxiDayCount(dayCount);
		xh.setLingxiDayLastTime(now);
		
		//周的灵犀
		int weekCount = xh.getLingxiWeekCount() + count;
		//如果最后一次更新时间和当前时间不是同一周，则数据为旧数据，需要清零重新计数
		if (!TimeUtils.isInSameWeek(now, xh.getLingxiWeekLastTime())) {
			weekCount = count;
		}
		xh.setLingxiWeekCount(weekCount);
		xh.setLingxiWeekLastTime(now);
		
		xh.setModified();
	}
	
	protected boolean hasXianhuData(long roleId) {
		return this.roleMap.containsKey(roleId);
	}
	
	protected Xianhu getXianhu(long roleId) {
		return this.roleMap.get(roleId);
	}
	
	protected Xianhu getOrCreateXianhu(long roleId) {
		if (!this.roleMap.containsKey(roleId)) {
			Xianhu xh = buildXianhu(roleId);
			this.roleMap.put(roleId, xh);
		}
		return this.roleMap.get(roleId);
	}
	
	protected Xianhu buildXianhu(long roleId) {
		Xianhu xh = new Xianhu();
		xh.setId(Globals.getUUIDService().getNextUUID(UUIDType.XIANHU));
		xh.setInDb(false);
		xh.setRoleId(roleId);
		//激活并存库
		xh.active();
		xh.setModified();
		return xh;
	}
	
	/**
	 * 时间上是否允许玩家操作仙葫
	 * 由于每日23：50进行排行，这个时间到第二天0点的数据会在0点清除，所以这期间就不让操作了
	 * @return
	 */
	public boolean canPlayByTime() {
		return Globals.getTimeService().now() < getTodayRankTime();
	}
	
	/**
	 * 获取今日仙葫排行时间
	 * @return
	 */
	public long getTodayRankTime() {
		return Globals.getTimeQueueService().getLastRealTime(XianhuDef.RankTimeEventId);
	}
	
	/**
	 * 每日定时刷新排行榜，含周榜
	 */
	public void refreshPreRankDaily(boolean isGM, boolean gmWeekFlag) {
		List<XianhuRankTmp> normalList = new ArrayList<XianhuRankTmp>();
		List<XianhuRankTmp> lingxiList = new ArrayList<XianhuRankTmp>();
		List<XianhuRankTmp> lingxiWeekList = new ArrayList<XianhuRankTmp>();
		
		//如果是周日，则生成周榜
		boolean weekFlag = TimeUtils.getDayOfTheWeekNum(Globals.getTimeService().now()) == XianhuDef.RankWeekNum;
		//gm强制刷新周榜
		if (isGM && gmWeekFlag) {
			weekFlag = true;
		}
		
		//生成三个榜的基础数据
		genBaseList(normalList, lingxiList, lingxiWeekList, weekFlag);
		
		//排序并刷新排行榜数据
		refreshPreRankByType(XianhuRankType.NORMAL_YESTODAY, normalList);
		refreshPreRankByType(XianhuRankType.LINGXI_YESTODAY, lingxiList);
		if (weekFlag) {
			refreshPreRankByType(XianhuRankType.LINGXI_LASTWEEK, lingxiWeekList);
		}
		
		Loggers.gameLogger.info("refreshPreRankDaily isGM=" + isGM + ";gmWeekFlag=" + gmWeekFlag);
	}
	
	protected void refreshPreRankByType(XianhuRankType rankType, List<XianhuRankTmp> tmpList) {
		//删除旧数据
		if (this.preRankMap.get(rankType) != null) {
			for (XianhuRank oRank : this.preRankMap.get(rankType)) {
				oRank.onDelete();
			}
			this.preRankMap.remove(rankType);
		}
		if (this.rolePreRankMap.get(rankType) != null) {
			this.rolePreRankMap.get(rankType).clear();
		} else {
			this.rolePreRankMap.put(rankType, new HashMap<Long, XianhuRank>());
		}
		
		//排序
		Collections.sort(tmpList, RankSortor);
		
		//最多100名
		int size = Math.min(tmpList.size(), XianhuDef.RankNum);
		
		//插入新数据
		List<XianhuRank> newList = new ArrayList<XianhuRank>(size);
		for (int i = 0; i < size; i++) {
			XianhuRankTmp tmp = tmpList.get(i);
			XianhuRank xr = buildXianhuRank(rankType, tmp, i + 1);
			newList.add(xr);
			
			//放入rolePreRankMap
			this.rolePreRankMap.get(rankType).put(xr.getRoleId(), xr);
		}
		
		//放入map
		this.preRankMap.put(rankType, newList);
		
		//更新显示用的缓存数据
		refreshShowCacheByPreRankType(rankType);
	}
	
	protected XianhuRank buildXianhuRank(XianhuRankType rankType, XianhuRankTmp tmp, int rank) {
		XianhuRank xr = new XianhuRank();
		xr.setId(Globals.getUUIDService().getNextUUID(UUIDType.XIANHU_RANK));
		xr.setRank(rank);
		xr.setLastTime(Globals.getTimeService().now());
		xr.setRankType(rankType.getIndex());
		xr.setRoleId(tmp.getRoleId());
		xr.setTargetCount(tmp.getCount());
		xr.setRewardFlag(0);
		xr.setRewardTime(0);
		
		xr.setInDb(false);
		//激活并存库
		xr.active();
		xr.setModified();
		
		return xr;
	}
	
	/**
	 * 刷新今日、本周榜，类即时
	 */
	public void refreshCurRank(boolean isGM) {
		List<XianhuRankTmp> normalList = new ArrayList<XianhuRankTmp>();
		List<XianhuRankTmp> lingxiList = new ArrayList<XianhuRankTmp>();
		List<XianhuRankTmp> lingxiWeekList = new ArrayList<XianhuRankTmp>();
		
		//生成三个榜的基础数据
		genBaseList(normalList, lingxiList, lingxiWeekList, true);
		
		//排序并刷新排行榜数据
		refreshCurRankByType(XianhuRankType.NORMAL_TODAY, normalList);
		refreshCurRankByType(XianhuRankType.LINGXI_TODAY, lingxiList);
		refreshCurRankByType(XianhuRankType.LINGXI_WEEK, lingxiWeekList);
		
		Loggers.gameLogger.info("refreshCurRank isGM=" + isGM);
	}
	
	protected void refreshCurRankByType(XianhuRankType rankType, List<XianhuRankTmp> tmpList) {
		//排序
		Collections.sort(tmpList, RankSortor);
		
		//最多100名
		int size = Math.min(tmpList.size(), XianhuDef.RankNum);
		
		//插入新数据
		List<XianhuCurRank> newList = new ArrayList<XianhuCurRank>(size);
		for (int i = 0; i < size; i++) {
			XianhuRankTmp tmp = tmpList.get(i);
			XianhuCurRank xr = buildXianhuCurRank(rankType, tmp, i + 1);
			newList.add(xr);
		}
		
		//删除旧数据
		if (this.curRankMap.get(rankType) != null) {
			this.curRankMap.remove(rankType);
		}
		//新数据放入map
		this.curRankMap.put(rankType, newList);
		
		//更新显示用的缓存数据
		refreshShowCacheByCurRankType(rankType);
	}
	
	protected XianhuCurRank buildXianhuCurRank(XianhuRankType rankType, XianhuRankTmp tmp, int rank) {
		XianhuCurRank xcr = new XianhuCurRank();
		xcr.setRoleId(tmp.getRoleId());
		xcr.setLastTime(tmp.getLastTime());
		xcr.setRank(rank);
		xcr.setRankType(rankType.getIndex());
		xcr.setTargetCount(tmp.getCount());
		return xcr;
	}
	
	/**
	 * 生成排行用的基础数据，即可以参与排名的玩家数据列表
	 * @param normalList
	 * @param lingxiList
	 * @param lingxiWeekList
	 * @param weekFlag
	 */
	protected void genBaseList(List<XianhuRankTmp> normalList, List<XianhuRankTmp> lingxiList, 
			List<XianhuRankTmp> lingxiWeekList, boolean weekFlag) {
		long now = Globals.getTimeService().now();
		long todayBegin = TimeUtils.getBeginOfDay(now);
		long weekBegin = TimeUtils.getBeginOfWeek(now);
		
		for (Xianhu xianhu : this.roleMap.values()) {
			//普通，取时间为今天的玩家数据
			if (xianhu.getNormalLastTime() >= todayBegin 
					&& xianhu.getNormalCount() > 0) {
				normalList.add(new XianhuRankTmp(xianhu.getCharId(), xianhu.getNormalCount(), xianhu.getNormalLastTime()));
			}
			
			//灵犀，取时间为今天的玩家数据
			if (xianhu.getLingxiDayLastTime() >= todayBegin
					&& xianhu.getLingxiDayCount() > 0) {
				lingxiList.add(new XianhuRankTmp(xianhu.getCharId(), xianhu.getLingxiDayCount(), xianhu.getLingxiDayLastTime()));
			}
			
			//灵犀，周榜
			if (weekFlag) {
				if (xianhu.getLingxiWeekLastTime() >= weekBegin
						&& xianhu.getLingxiWeekCount() > 0) {
					lingxiWeekList.add(new XianhuRankTmp(xianhu.getCharId(), xianhu.getLingxiWeekCount(), xianhu.getLingxiWeekLastTime()));
				}
			}
		}
	}
	
	/**
	 * 排序类
	 * @author yu.zhao
	 *
	 */
	protected class XianhuRankComparator implements Comparator<XianhuRankTmp> {
		
		/**
		 * 仙葫排名，先按计数，相同按时间（时间小的排前面），再相同按玩家id（id小的排前面）
		 */
		@Override
		public int compare(XianhuRankTmp o1, XianhuRankTmp o2) {
			if (o1.getCount() > o2.getCount()) {
				return -1;
			} else if (o1.getCount() < o2.getCount()) {
				return 1;
			} else {
				if (o1.getLastTime() < o2.getLastTime()) {
					return -1;
				} else if (o1.getLastTime() > o2.getLastTime()) {
					return 1;
				} else {
					if (o1.getRoleId() < o2.getRoleId()) {
						return -1;
					} else if (o1.getRoleId() > o2.getRoleId()) {
						return 1;
					} else {
						return -1;
					}
				}
			}
		}
	}
	
}
