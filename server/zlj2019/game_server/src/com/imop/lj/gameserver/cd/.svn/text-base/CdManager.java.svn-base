package com.imop.lj.gameserver.cd;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONArray;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.cd.template.CdOpenCondTemplate;
import com.imop.lj.gameserver.cd.template.CdTemplate;
import com.imop.lj.gameserver.cd.template.CdTiredRatioTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.human.msg.GCHumanCdQueueUpdate;

/**
 * 冷却队列管理器
 *
 * @author haijiang.jin
 *
 */
public class CdManager implements JsonPropDataHolder {
	/** 所属玩家角色 */
	private Human _owner;
	/** 冷却队列字典 */
	private Map<CdTypeEnum, List<CdQueue>> _cdMap;
	/** 修改过的冷却队列 */
	private List<CdQueue> _changedCdQueueList;
	/** 冷却队列服务 */
	private CdService _cdServ;
	/** Cd 事件监听队列 */
	private List<CdListener> _listeners = null;

	/**
	 * 类默认构造器
	 *
	 * @param human
	 *            所属玩家角色
	 * @throws IllegalArgumentException
	 *             if human == null
	 *
	 */
	public CdManager(Human human, CdService cdServ) {
		if (human == null) {
			throw new IllegalArgumentException("human is null");
		}

		// 设置所属玩家角色
		this._owner = human;
		this._cdServ = cdServ;
		this.init();
	}

	/**
	 * 初始化
	 *
	 * @param templateServ
	 *
	 */
	private void init() {
		

		// 获取冷却模版配置字典
		Map<Integer, CdTemplate> cdtMap =Globals.getTemplateCacheService().getAll(CdTemplate.class);

		if (cdtMap == null) {
			return;
		}

		// 创建冷却队列字典
		this._cdMap = new HashMap<CdTypeEnum, List<CdQueue>>();
		// 创建已修改的冷却队列
		this._changedCdQueueList = new ArrayList<CdQueue>();

		for (Integer cdTypeInt : cdtMap.keySet()) {
			// 获取冷却队列配置模版
			CdTemplate cdTemp = cdtMap.get(cdTypeInt);
			// 获取冷却类型
			CdTypeEnum cdType = CdTypeEnum.valueOf(cdTypeInt);

			// 冷却队列列表
			List<CdQueue> cdqList = new ArrayList<CdQueue>();
			// 冷却队列上限
			int cdQueueMax = cdTemp.getCdQueueMax();

			for (int i = 0; i < cdQueueMax; i++) {
				CdQueue cdq = new CdQueue();

				cdq.setCdType(cdType);
				cdq.setIndex(i);
				cdq.setName(cdTemp.getCdTypeName());
				cdq.setIcon(cdTemp.getIcon());
				cdq.setCdTimeThreshold(cdTemp.getCdTimeThreshold());
				cdq.setOpened(i < cdTemp.getCdQueueDefault());
				cdq.setAddNeedGold(this._cdServ.getAddCdNeedGold(cdq.getCdType(), i));
				cdq.setKillCdSpaceTime(cdTemp.getKillCdSpaceTime());
				cdq.setKillCdNeedGold(cdTemp.getKillCdNeedGold());
				cdq.setTimes(0, 0);

				cdqList.add(cdq);
			}

			this._cdMap.put(cdType, cdqList);
		}

		// 获取游戏常量设置
		// GameConstants gameConstants = Globals.getGameConstants();
		// 设置冷却队列操作次数重置时间
		// _owner.setCdOpCountResetTime(gameConstants.getCdOpCountResetTime());

		this._listeners = Arrays.asList(new CdListener[] { new CdGuideListener(), });
	}

	/**
	 * 获取所属玩家角色
	 *
	 * @return
	 */
	public Human getHuman() {
		return this._owner;
	}

	/**
	 * 增加cd时间，即时当前cd已红
	 *
	 * @param cdType
	 * @param ms
	 */
	public void addTimeWithoutCheck(CdTypeEnum cdType, int index, long ms) {
		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		// 可用的冷却队列
		if (cdQueueList.size() <= index)
			return;
		CdQueue cdq = cdQueueList.get(index);

		if (cdq != null) {
			// 获取当前时间差与结束时间的时间差
			long currTimeDiff = cdq.getCurrTimeDiff();

			if (currTimeDiff <= 0) {
				// 如果冷却队列时间已经彻底结束,
				// 则清除开始结束时间
				cdq.setTimes(0, 0);
			}

			if (cdq.getLastOpTime() <= getOpCountResetTime(this._owner)) {
				// 操作次数清零
				cdq.setOpCount(0);
			}

			long now = Globals.getTimeService().now();

			// 开始时间 = 系统当前时间
			long startTime = now;
			// 结束时间 = 开始时间 + 时间差 + (累计时间 * 疲劳度)
			long endTime = startTime + currTimeDiff + this.computeSpendTime(cdType, ms);

			// 设置开始结束时间
			cdq.setTimes(startTime, endTime);
			// 设置操作次数和操作时间
			cdq.addOpCount(1);
			cdq.setLastOpTime(now);

			// 保存玩家角色修改
			this._owner.setModified();

			if (!this._changedCdQueueList.contains(cdq)) {
				this._changedCdQueueList.add(cdq);
			}
		}
	}

	/**
	 * 累计冷却时间
	 *
	 * @param cdType
	 * @param ms
	 */
	public void addTime(CdTypeEnum cdType, long ms) {
		if (!this.canAddTime(cdType)) {
			// 如果指定类型的队列尚未冷却,
			// 则直接退出
			return;
		}

		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		// 可用的冷却队列
		CdQueue cdq = null;

		for (CdQueue cdQueue : cdQueueList) {
			if (cdQueue.canAddTime()) {
				cdq = cdQueue;
				break;
			}
		}

		if (cdq != null) {
			// 获取当前时间差与结束时间的时间差
			long currTimeDiff = cdq.getCurrTimeDiff();

			if (currTimeDiff <= 0) {
				// 如果冷却队列时间已经彻底结束,
				// 则清除开始结束时间
				cdq.setTimes(0, 0);
			}

			if (cdq.getLastOpTime() <= getOpCountResetTime(this._owner)) {
				// 操作次数清零
				cdq.setOpCount(0);
			}

			long now = Globals.getTimeService().now();

			// 开始时间 = 系统当前时间
			long startTime = now;
			// 结束时间 = 开始时间 + 时间差 + (累计时间 * 疲劳度)
			int spendTime = this.computeSpendTime(cdType, ms);
			long endTime = startTime + currTimeDiff + spendTime;

			// 设置开始结束时间
			cdq.setTimes(startTime, endTime);
			// 设置操作次数和操作时间
			cdq.addOpCount(1);
			cdq.setLastOpTime(now);

			// 保存玩家角色修改
			this._owner.setModified();

			if (!this._changedCdQueueList.contains(cdq)) {
				this._changedCdQueueList.add(cdq);
			}
		}
	}

	/**
	 * 计算 Cd 花费时间
	 *
	 * @param cdType
	 * @param baseMS
	 * @return
	 */
	public int computeSpendTime(CdTypeEnum cdType, long baseMS) {
//		// 获取冷却队列列表
//		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
//		// 操作次数
//		int opCount = 0;
//
//		for (CdQueue cdq : cdQueueList) {
//			opCount += cdq.getOpCount();
//		}
//
//		// 计算疲劳度
//		float tiredRatio = this.getTiredRatio(cdType, opCount);
//		// 基本时间 * 疲劳度
//		return (int) (baseMS * (1 + tiredRatio));
		//TODO 去掉疲劳度
		return (int)baseMS;
	}

	/**
	 * 减少冷却时间. 如果希望彻底清除冷却时间可以使用 {@link #killTime} 方法
	 *
	 * @param cdType
	 *            冷却队列类型
	 * @param index
	 *            冷却队列索引, 起始值 = 0
	 * @param ms
	 *            减少时间 (单位毫秒)
	 */
	public void subTime(CdTypeEnum cdType, int index, long ms) {
		if (cdType == null) {
			return;
		}

		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		// 可用的冷却队列
		CdQueue cdq = cdQueueList.get(index);

		if (cdq != null) {
			// 获取当前时间差与结束时间的时间差
			long currTimeDiff = cdq.getCurrTimeDiff();

			if (currTimeDiff <= 0) {
				// 如果冷却队列时间已经彻底结束,
				// 则直接退出
				return;
			}

			long now = Globals.getTimeService().now();

			// 开始时间 = 系统当前时间
			long startTime = now;
			// 结束时间 = 开始时间 + 时间差 - 时间
			long endTime = startTime + Math.max(currTimeDiff - ms, 0);

			// 设置开始结束时间
			cdq.setTimes(startTime, endTime);

			// 保存玩家角色修改
			this._owner.setModified();

			if (!this._changedCdQueueList.contains(cdq)) {
				this._changedCdQueueList.add(cdq);
			}
		}
	}

	/**
	 * 判断指定类型的队列是否可以累计时间
	 *
	 * @param cdType
	 * @return
	 */
	public boolean canAddTime(CdTypeEnum cdType) {
		if (cdType == null) {
			return false;
		}

		List<CdQueue> cdqList = this._cdMap.get(cdType);

		for (CdQueue cdq : cdqList) {
			if (cdq.canAddTime()) {
				return true;
			}
		}

		return false;
	}

	/**
	 * 获取冷却队列阈值
	 *
	 * @param cdType
	 * @return
	 */
	public long getCdTimeThreshold(CdTypeEnum cdType) {
		// 获取冷却队列列表
		List<CdQueue> cdqList = this._cdMap.get(cdType);

		if ((cdqList == null) || (cdqList.size() <= 0)) {
			return 0;
		}

		// 获取冷却队列
		CdQueue cdq = cdqList.get(0);

		return cdq.getCdTimeThreshold();
	}

	/**
	 * 设置冷却队列阈值
	 *
	 * @param cdType
	 *            冷却队列类型
	 * @param threshold
	 *            新阈值
	 */
	public void setCdTimeThreshold(CdTypeEnum cdType, long threshold) {
		// 获取冷却队列列表
		List<CdQueue> cdqList = this._cdMap.get(cdType);

		if ((cdqList == null) || (cdqList.size() <= 0)) {
			return;
		}

		for (CdQueue cdq : cdqList) {
			// 设置冷却时间阈值
			cdq.setCdTimeThreshold(threshold);

			if (!this._changedCdQueueList.contains(cdq)) {
				this._changedCdQueueList.add(cdq);
			}
		}

		// 保存玩家角色修改
		this._owner.setModified();
	}

	/**
	 * 获取冷却队列
	 *
	 * @param cdType
	 *            冷却队列类型
	 * @param index
	 *            冷却队列索引位置
	 * @return
	 */
	public CdQueue getCdQueue(CdTypeEnum cdType, int index) {
		if (cdType == null) {
			return null;
		}

		List<CdQueue> cdqList = this._cdMap.get(cdType);

		if (cdqList == null) {
			return null;
		}

		return cdqList.get(index);
	}

	/**
	 * 获取当前时间到冷却队列结束时间的时间差，单位秒
	 *
	 * @param cdType
	 * @return
	 */
	public int getCurrTimeDiffWithSeconds(CdTypeEnum cdType) {
		return (int) (this.getCurrTimeDiff(cdType, 0) / 1000);
	}

	/**
	 * 获取当前时间到冷却队列结束时间的时间差
	 *
	 * @param cdType
	 * @return
	 *
	 */
	public long getCurrTimeDiff(CdTypeEnum cdType) {
		return this.getCurrTimeDiff(cdType, 0);
	}

	/**
	 * 获取当前时间到冷却队列结束时间的时间差
	 *
	 * @param cdType
	 *            冷却队列类型
	 * @param index
	 *            冷却队列索引位置
	 * @return
	 */
	public long getCurrTimeDiff(CdTypeEnum cdType, int index) {
		// 获取冷却队列
		CdQueue cdq = this.getCdQueue(cdType, index);

		if (cdq == null) {
			return 0;
		}

		return cdq.getCurrTimeDiff();
	}

	/**
	 * 获取冷却队列数组
	 *
	 * @return
	 */
	public CdQueue[] getCdQueues() {
		// 冷却队列列表
		List<CdQueue> cdqList = new ArrayList<CdQueue>();

		for (CdTypeEnum cdType : CdTypeEnum.values()) {
			cdqList.addAll(this._cdMap.get(cdType));
		}

		// 将冷却队列列表转换成数组
		CdQueue[] cdqArray = cdqList.toArray(new CdQueue[cdqList.size()]);

		return cdqArray;
	}

	/**
	 * 获取冷却队列信息数组
	 *
	 * @return
	 */
	public CdQueueInfo[] getCdQueueInfos() {
//		// 获取冷却队列数组
//		CdQueue[] cdqArray = this.getCdQueues();
//
//		if (cdqArray == null) {
//			return new CdQueueInfo[0];
//		}
//
//		List<CdQueueInfo> cdqInfoList = new ArrayList<CdQueueInfo>(cdqArray.length);
//
//		for (int i = 0; i < cdqArray.length; i++) {
//			CdQueue cdq = cdqArray[i];
//
//			if (this.canVisit(cdq)) {
//				// 获取冷却队列信息
//				cdqInfoList.add(cdq.getCdQueueInfo());
//			}
//		}

		List<CdQueue> cdqList = this.getAllDisplayCdQueue();
		List<CdQueueInfo> cdqInfoList = new ArrayList<CdQueueInfo>();
		for(CdQueue cdQueue : cdqList){
			cdqInfoList.add(cdQueue.getCdQueueInfo());
		}

		return cdqInfoList.toArray(new CdQueueInfo[0]);
	}

	/**
	 * 获取已修改的冷却队列数组快照
	 *
	 * @param reset
	 *            是否重置
	 * @return
	 */
	public void snapChangedCdQueues(boolean reset) {
		// 获取已修改的冷却队列数量
		int count = this._changedCdQueueList.size();

		if (count <= 0) {
			return;
		}

		// 将冷却队列列表转换成数组
		CdQueue[] cdqArray = this._changedCdQueueList.toArray(new CdQueue[count]);
		// 创建冷却队列信息数组
		List<CdQueueInfo> cdqInfoList = new ArrayList<CdQueueInfo>(count);

		for (int i = 0; i < count; i++) {
			CdQueue cdq = cdqArray[i];

			if (this.canVisit(cdq)) {
				// 获取冷却队列信息
				cdqInfoList.add(cdq.getCdQueueInfo());
			}
		}
		// TODO 下行消息
		// 发送冷却队列更新消息
		this._owner.sendMessage(new GCHumanCdQueueUpdate(cdqInfoList.toArray(new CdQueueInfo[0])));

		if (reset) {
			this._changedCdQueueList.clear();
		}
	}

	/**
	 * 冷却队列是否可见
	 *
	 * @param cd
	 * @return
	 *
	 */
	private boolean canVisit(CdQueue cd) {
		// 获取冷却队列开放模版
		CdOpenCondTemplate tmpl = this._cdServ.getCdOpenCondTemplate(cd.getCdType(), cd.getIndex());

		if (tmpl == null) {
			return false;
		}
		return true;
//		// XXX 这里改为为取修正后的vip等级
//		return Globals.getVipService().getVipLevel(this._owner.getUUID()) >= tmpl.getNeedVipLevel();
	}

	/**
	 * 抵消冷却等待时间. 如果希望减少冷却时间可以使用 {@link #subTime} 方法
	 *
	 * @param cdType
	 * @param cdIndex
	 * @param trade
	 *            是否扣费
	 */

	public void killTime(CdTypeEnum cdType, int cdIndex) {
		killTime(cdType, cdIndex, true);
	}

	public void killTime(CdTypeEnum cdType, int cdIndex, boolean trade) {
		if (!this._cdMap.containsKey(cdType)) {
			return;
		}

		// 获取冷却队列
		List<CdQueue> cdqList = this._cdMap.get(cdType);

		if ((cdIndex < 0) || (cdIndex >= cdqList.size())) {
			return;
		}

		// 获取冷却队列并重置
		CdQueue cdq = cdqList.get(cdIndex);

		if (cdq == null) {
			return;
		}
		boolean costOk = false; // 扣费是否成功
		if (trade) {
			// 计算所需金币
			int needGold = cdq.getKillCurrTimeNeedGold();

			if (needGold <= 0) {
				// 如果所需金币 <= 0,
				// 则直接退出
				return;
			}

			// 判断玩家是否有足够金币

			boolean hasEnoughGold = this._owner.hasEnoughMoney(needGold, Currency.GIFT_BOND, true);

			String detailReason;

			// Cd类型={0}|Cd名称={1}|Cd索引位置={2}
			detailReason = MoneyLogReason.CD_KILL.getReasonText();
			detailReason = MessageFormat.format(detailReason, cdq.getCdType().getIndex(), cdq.getName(), cdq.getIndex());

			// 判断玩家消耗金币是否成功
			costOk = hasEnoughGold && _owner.costMoney(needGold, Currency.GIFT_BOND, true, 0, MoneyLogReason.CD_KILL, detailReason, 0);
		}
		if (costOk || !trade) {
			// 清除开始结束时间
			cdq.setTimes(0, 0);

			// 保存玩家角色修改
			this._owner.setModified();

			// 任务
//			this._owner.getQuestDiary().getListener().onKillCd(this._owner);

			if (!this._changedCdQueueList.contains(cdq)) {
				this._changedCdQueueList.add(cdq);
			}
		}
	}

	/**
	 * 增加冷却队列上限
	 *
	 * @param cdType
	 */
	public void addCdQueueMax(CdTypeEnum cdType) {
		if (!this._cdMap.containsKey(cdType)) {
			return;
		}

		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		// 已关闭的冷却队列
		CdQueue cdq = null;

		for (CdQueue cdQueue : cdQueueList) {
			if (!cdQueue.isOpened()) {
				cdq = cdQueue;
				break;
			}
		}

		if (cdq == null) {
			return;
		}

		// 计算所需金币
		int needGold = cdq.getAddNeedGold();

		if (needGold <= 0) {
			// 如果所需金币 <= 0,
			// 则直接退出
			return;
		}

		// 判断玩家是否有足够金币
		boolean hasEnoughGold = this._owner.hasEnoughMoney(needGold, Currency.GIFT_BOND, true);

		String detailReason;

		// Cd类型={0}|Cd名称={1}
		detailReason = MoneyLogReason.CD_ADD.getReasonText();
		detailReason = MessageFormat.format(detailReason, cdq.getCdType().getIndex(), cdq.getName());

		// 判断玩家消耗金币是否成功
		boolean costOk = hasEnoughGold && _owner.costMoney(needGold, Currency.GIFT_BOND, true, 0, MoneyLogReason.CD_ADD, detailReason, 0);

		if (costOk) {
			// 开启冷却队列
			cdq.setOpened(true);
			cdq.setTimes(0, 0);
			//更新全部显示队列
			List<CdQueue> cdqList = this.getDisplayCdQueueByType(cdType);
			for(CdQueue cdQueue : cdqList){
				if (!this._changedCdQueueList.contains(cdQueue)) {
					this._changedCdQueueList.add(cdQueue);
				}
			}
			for (CdListener listener : this._listeners) {
				listener.afterAddCdQueueMax(this.getHuman(), cdq);
			}
		}
	}

	/**
	 * 将当前对象转换为 JSON 字符串
	 *
	 * @return
	 */
	@Override
	public String toJsonProp() {
		JSONArray jsonArr = new JSONArray();

		for (CdTypeEnum cdType : CdTypeEnum.values()) {
			// 获取冷却队列列表
			List<CdQueue> cdQueueList = this._cdMap.get(cdType);

			for (CdQueue cdQueue : cdQueueList) {
				jsonArr.add(cdQueue.toJsonStr());
			}
		}
		return jsonArr.toString();
	}

	/**
	 * 从 JSON 字符串中还原对象
	 *
	 * @param jsonStr
	 */
	@Override
	public void loadJsonProp(String jsonStr) {
		if ((jsonStr == null) || (jsonStr.equals(""))) {
			return;
		}

		JSONArray jsonArr = JSONArray.fromObject(jsonStr);

		// 创建临时冷却队列对象
		CdQueue tempCdq = new CdQueue();

		for (int i = 0; i < jsonArr.size(); i++) {
			// 获取冷却队列 JSON 字符串
			String cdqJsonStr = jsonArr.getString(i);
			// 还原冷却队列
			tempCdq.fromJsonStr(cdqJsonStr);

			// 获取冷却类型
			CdTypeEnum cdType = tempCdq.getCdType();
			if (null == cdType) {
				// 记录错误日志
				Loggers.humanLogger.error("#CdManager#loadJsonProp#cdType is null!cdqJsonStr="+cdqJsonStr);
				continue;
			}

			List<CdQueue> cdqList = this._cdMap.get(cdType);

			if (tempCdq.getIndex() >= cdqList.size()) {
				return;
			}

			// 获取冷却队列
			CdQueue cdq = cdqList.get(tempCdq.getIndex());

			if (cdq == null) {
				return;
			}

			cdq.setTimes(tempCdq.getStartTime(), tempCdq.getEndTime());
			cdq.setOpened(tempCdq.isOpened());
			cdq.setLastOpTime(tempCdq.getLastOpTime());
			cdq.setOpCount(tempCdq.getOpCount());
		}
	}

	/**
	 * 获取操作次数重置时间
	 *
	 * @return
	 */
	private static long getOpCountResetTime(Human human) {
		// 获取当前时间
		GregorianCalendar nowTime = new GregorianCalendar();
		// 计算今日整点时间
		GregorianCalendar todayOclock = new GregorianCalendar(nowTime.get(Calendar.YEAR), nowTime.get(Calendar.MONTH), nowTime.get(Calendar.DATE),
				human.getCdOpCountResetTime(), 0, 0);

		return todayOclock.getTimeInMillis();
	}

	/**
	 * 获取疲劳度
	 *
	 * @param cdType
	 * @param opCount
	 * @return
	 */
	private float getTiredRatio(CdTypeEnum cdType, int opCount) {
//		// 获取模版服务
//		TemplateService templateServ = Globals.getTemplateCacheService().getTemplateService();
		// 获取疲劳度配置
		CdTiredRatioTemplate cdTiredRatio = Globals.getTemplateCacheService().get(opCount, CdTiredRatioTemplate.class);

		if (cdTiredRatio == null) {
			return 0.0f;
		}

		return cdTiredRatio.getTiredRatio(cdType);
	}

	/**
	 * 获取某种冷却队列的数量
	 *
	 * @param cdType
	 * @return
	 */
	public int getCdQueueNum(CdTypeEnum cdType) {
		int queueNum = 0;
		if (null != this._cdMap && null != this._cdMap.get(cdType)) {
			if (this._cdMap.get(cdType).size() > 0) {
				List<CdQueue> cdqList = this._cdMap.get(cdType);
				for (CdQueue cdQueue : cdqList) {
					if (cdQueue.isOpened()) {
						queueNum++;
					}
				}
			}
		}
		return queueNum;
	}

	public CdQueue getCanOpenedCdQueue(CdTypeEnum cdType){
		if (!this._cdMap.containsKey(cdType)) {
			return null;
		}

		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		// 已关闭的冷却队列
		CdQueue cdq = null;

		for (CdQueue cdQueue : cdQueueList) {
			if (!cdQueue.isOpened() && this.canVisit(cdQueue)) {
				cdq = cdQueue;
				break;
			}
		}
		return cdq;
	}

	/**
	 *
	 * @param cdType队列类型
	 * @return 返回前台显示冷却队列,只显示开启队列和一个未开启队列
	 */
	public List<CdQueue> getDisplayCdQueueByType(CdTypeEnum cdType){
		List<CdQueue> cdqList = new ArrayList<CdQueue>();
		if (!this._cdMap.containsKey(cdType)) {
			return cdqList;
		}

		// 获取冷却队列列表
		List<CdQueue> cdQueueList = this._cdMap.get(cdType);
		//
		boolean hasDisplayCdQueue = false;
		for (CdQueue cdQueue : cdQueueList) {
			if (cdQueue.isOpened()) {
				cdqList.add(cdQueue);
			}else if (!cdQueue.isOpened() && this.canVisit(cdQueue) && !hasDisplayCdQueue) {
				cdqList.add(cdQueue);
				hasDisplayCdQueue = true;
			}
		}

		return cdqList;
	}

	/**
	 *
	 * @param cdType队列类型
	 * @return 返回前台显示冷却队列,只显示开启队列和一个未开启队列
	 */
	public List<CdQueue> getAllDisplayCdQueue(){
		// 冷却队列列表
		List<CdQueue> cdqList = new ArrayList<CdQueue>();

		for (CdTypeEnum cdType : CdTypeEnum.values()) {
			CdTemplate cdTemplate = Globals.getTemplateCacheService().get(cdType.getIndex(), CdTemplate.class);
//			if(cdTemplate.getGameFuncType() != 0){
//				boolean isOpenFunc = this._owner.getGameFuncManager().isOpenedFunc(IHumanFunc.TypeEnum.valueOf(cdTemplate.getGameFuncType()));
//				if(!isOpenFunc){
//					continue;
//				}
//			}
			cdqList.addAll(this.getDisplayCdQueueByType(cdType));
//			if(!(cdType == CdTypeEnum.rapidTraining)){
//
//			}
		}

		return cdqList;
	}

	/**
	 * 根据CdTypeEnum 获得队列中时间最小的CD
	 * @param typeEnum
	 * @return 返回列中时间最小的CD的索引 如果队列中没有CD 返回值-1
	 */

	public int getShortTimeCdQueueIndex(CdTypeEnum typeEnum) {
		if(typeEnum == null) {
			return 0;
		}
		long minCdTime = 0;
		int minCdIndex = -1;
		List<CdQueue> cdQueueList = _cdMap.get(typeEnum);

		for (int i = 0; i < cdQueueList.size(); i++) {
			CdQueue cdQueue = cdQueueList.get(i);
			if(i == 0) {
				minCdTime = cdQueue.getCurrTimeDiff();
				minCdIndex = i;
			} else {
				if(cdQueue.getCurrTimeDiff() < minCdTime) {
					minCdTime = cdQueue.getCurrTimeDiff();
					minCdIndex = i;
				}
			}
		}
		return minCdIndex;
	}

	/**
	 * 当VIP改变
	 */
	public void onVipChange(){
		boolean change = false;
//		// 强化CD
//		if(Globals.getVipService().checkVipRule(this._owner, VipTypeEnum.EQUIP_FREE_CD)){
//			this.killTime(CdTypeEnum.EQUIP_ENHANCE, 0, false);
//			change = true;
//		}
		
		if(change){
			this.snapChangedCdQueues(true);
		}
	}
}
