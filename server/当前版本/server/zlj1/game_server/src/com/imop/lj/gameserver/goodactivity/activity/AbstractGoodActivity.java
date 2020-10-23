package com.imop.lj.gameserver.goodactivity.activity;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collection;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import net.sf.json.JSONArray;

import com.imop.lj.common.LogReasons.GoodActivityLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.GoodActivityFinishTargetEvent;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityStatus;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBaseTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;

/**
 * 精彩活动抽象类
 * @author yu.zhao
 *
 */
public abstract class AbstractGoodActivity implements IGoodActivity {
	/** 活动模板 */
	private GoodActivityBaseTemplate tpl;
	
	/** 活动数据对象 */
	private GoodActivityPO goodActivityPO;
	
	/** 目标列表，已排序 */
	private Map<Integer, AbstractGoodActivityTargetUnit> targetMap = new LinkedHashMap<Integer, AbstractGoodActivityTargetUnit>();
	
	/** 前置目标Id集合 */
	private Set<Integer> preTargetIdSet = new HashSet<Integer>();
	
	/** 下次刷新时间的缓存，内存数据 */
	private Long nextRefreshTimeCache;
	
	public AbstractGoodActivity(GoodActivityPO goodActivityPO) {
		this.goodActivityPO = goodActivityPO;
		this.tpl = Globals.getTemplateCacheService().get(goodActivityPO.getActivityTplId(), GoodActivityBaseTemplate.class);
		// 构建目标列表
		buildTaretList(tpl);
		//构建前置目标Id集合
		buildPreTargetIdSet();
	}
	
	protected void buildPreTargetIdSet() {
		for (AbstractGoodActivityTargetUnit tu : this.targetMap.values()) {
			if (tu.hasPreTarget()) {
				this.preTargetIdSet.add(tu.getPreTargetId());
			}
		}
	}
	
	/**
	 * 构建目标列表
	 * @param tpl
	 */
	protected void buildTaretList(GoodActivityBaseTemplate tpl) {
		// 从模板缓存中按照活动Id取对应的目标列表
		List<GoodActivityTargetTemplate> tplList = 
				Globals.getTemplateCacheService().getGoodActivityTemplateCache().getTargetTplList(tpl.getId());
		for (GoodActivityTargetTemplate targetTpl : tplList) {
			buildTargetUnit(targetTpl);
		}
	}
	
	public final boolean isPreTargetId(int targetId) {
		return this.preTargetIdSet.contains(targetId);
	}
	
	/**
	 * 获取活动显示目标（奖励）相关信息
	 * @return
	 */
	public Collection<AbstractGoodActivityTargetUnit> getTargetList() {
		return this.targetMap.values();
	}
	
	/**
	 * 获取第一个目标
	 * @return
	 */
	public AbstractGoodActivityTargetUnit getFirstTarget() {
		for (AbstractGoodActivityTargetUnit unit : this.targetMap.values()) {
			return unit;
		}
		return null;
	}
	
	/**
	 * 添加一个目标单元
	 * @param targetUnit
	 */
	protected void addTargetUnit(AbstractGoodActivityTargetUnit targetUnit) {
		targetMap.put(targetUnit.getTargetId(), targetUnit);
	}
	
	/**
	 * 根据目标Id获取目标对象
	 * @param targetId
	 * @return
	 */
	public AbstractGoodActivityTargetUnit getTargetUnit(int targetId) {
		return targetMap.get(targetId);
	}
	
	public final int getTplId() {
		return tpl.getId();
	}
	
	/**
	 * 活动是否开启中，活动必须可用，且未关闭，且结束时间大于当前时间，且已经开始，才算开启中
	 */
	public boolean isOpening() {
		// 是否无效活动，如果是，则视为未开启
		if (!goodActivityPO.isAvailable()) {
			return false;
		}
		// 活动未关闭，已经开始，未到结束时间，同时满足3个条件才视为活动是开启中
		if (goodActivityPO.getIsClosed() == 0 && 
				goodActivityPO.isStarted() && 
				goodActivityPO.getEndTime() > Globals.getTimeService().now()) {
			return true;
		}
		return false;
	}
	
	public final long getId() {
		return goodActivityPO.getId();
	}
	
	public final GoodActivityType getGoodActivityType() {
		return tpl.getActivityType();
	}
	
	public final GoodActivityPO getGoodActivityPO() {
		return goodActivityPO;
	}
	
	public GoodActivityBaseTemplate getTpl() {
		return tpl;
	}

	/**
	 * 获取活动的名称，优先数据库中的名称，如果为空，则使用模板中的名称
	 */
	public String getName() {
		// 优先数据库，然后模板
		String name = getTpl().getName();
		if (null != goodActivityPO && 
				goodActivityPO.getActivityName() != null &&
				!goodActivityPO.getActivityName().equalsIgnoreCase("")) {
			name = goodActivityPO.getActivityName();
		}
		return name;
	}
	
	/**
	 * 获取活动的描述，优先数据库中的描述，如果为空，则使用模板中的描述
	 */
	public String getDesc() {
		// 优先数据库，然后模板
		String desc = getTpl().getDesc();
		if (null != goodActivityPO && 
				goodActivityPO.getActivityDesc() != null &&
				!goodActivityPO.getActivityDesc().equalsIgnoreCase("")) {
			desc = goodActivityPO.getActivityDesc();
		}
		return desc;
	}
	
	/**
	 * 获取日志列表
	 * @return
	 */
	public List<String> getLogList() {
		if (null != goodActivityPO) {
			return goodActivityPO.getLogList();
		} 
		return new ArrayList<String>();
	}
	
	/**
	 * 添加一个日志并存库
	 * @param log
	 */
	public void addLog(String log) {
		if (null != goodActivityPO && 
				log != null && !log.isEmpty()) {
			goodActivityPO.addLog(log);
			goodActivityPO.setModified();
		}
	}
	
	public int getIcon() {
		return getTpl().getIcon();
	}
	
	/**
	 * 获取活动名称图标，优先数据库中的字段，默认为0
	 */
	public int getNameIcon() {
		// 优先数据库，然后默认为0
		int nameIcon = 0;
		if (null != goodActivityPO) {
			nameIcon = goodActivityPO.getNameIcon();
		}
		return nameIcon;
	}
	
	/**
	 * 获取标题图标，优先数据库中的字段，默认为0
	 */
	public int getTitleIcon() {
		// 优先数据库，然后默认为0
		int titleIcon = 0;
		if (null != goodActivityPO) {
			titleIcon = goodActivityPO.getTitleIcon();
		}
		return titleIcon;
	}
	
	/**
	 * 前台显示用的一个字段，用于区分不用的目标显示类型，如军团战需要分组，其他为普通的目标
	 */
	public int getShowTargetType() {
		return getTpl().getShowTargetType();
	}
	
	/**
	 * 获取活动的开始时间
	 */
	public long getStartTime() {
		return getGoodActivityPO().getStartTime();
	}
	
	/**
	 * 获取活动的结束时间
	 */
	public long getEndTime() {
		return getGoodActivityPO().getEndTime();
	}
	
	/**
	 * 获取活动最后一次刷新的时间
	 * @return
	 */
	public long getLastRefreshTime() {
		return getGoodActivityPO().getLastRefreshTime();
	}
	
	/**
	 * 更新最后一次刷新时间
	 * 对于周期性刷新的活动，需要依据此时间判断是否到了下一次刷新时间
	 * @param lastRefreshTime
	 */
	public void updateLastRefreshTime(long lastRefreshTime) {
		getGoodActivityPO().setLastRefreshTime(lastRefreshTime);
		// 清除下次刷新时间的缓存
		clearNextRefreshTimeCache();
	}
	
	/**
	 * 活动是否已开始
	 * @return
	 */
	public boolean isStarted() {
		return getGoodActivityPO().isStarted();
	}
	
	/**
	 * 活动开始的处理
	 * 将活动设为已开始
	 * 如果活动是自动参加类型的，需要将在线玩家自动加入活动
	 */
	public void onActivityStart() {
		// 将活动设为已开始
		getGoodActivityPO().setIsStarted(GoodActivityStatus.OPENED.getIndex());
		
		// 是否需要自动参加
		if (!needAutoJoin()) {
			return;
		}
		
		// 可以自动参加，则遍历所有在线玩家，看能否自动参加
		Collection<Long> uuidCol = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
		for (Long uuid : uuidCol) {
			Player player = Globals.getOnlinePlayerService().getPlayer(uuid);
			if (player == null || player.getHuman() == null) {
				continue;
			}
			Human human = player.getHuman();
			boolean joinFlag = Globals.getGoodActivityService().checkAutoJoinActivity(human, this);
			if (joinFlag) {
				// 功能按钮变化
				Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GOOD_ACTIVITY);
			}
		}
	}

	/**
	 * 活动结束的处理
	 * 设置活动未已关闭
	 * 如果需要结束时结算奖励，则给玩家发未领取的奖励
	 */
	public void onActivityEnd() {
		// 将活动设为关闭状态
		goodActivityPO.setIsClosed(GoodActivityStatus.OPENED.getIndex());
		goodActivityPO.setCloseTime(Globals.getTimeService().now());
		goodActivityPO.setModified();
		
		// 活动结束时是否需要处理玩家未领取的奖励
		if (!needGiveUnGotRewardOnEnd()) {
			return;
		}
		
		// 给玩家未领取的奖励
		giveAllJoinedUserBonus();
	}
	
	/**
	 * 将玩家未领取的奖励，以邮件格式发给玩家
	 */
	protected void giveAllJoinedUserBonus() {
		// 给所有参加活动的玩家发奖励
		List<AbstractUserGoodActivity> userActivityList = Globals.getGoodActivityService().getJoinActivityUserList(getId());
		if (null != userActivityList && !userActivityList.isEmpty()) {
			for (AbstractUserGoodActivity userActivity : userActivityList) {
				Collection<AbstractGoodActivityTargetUnit> targetList = getTargetList();
				for (AbstractGoodActivityTargetUnit targetUnit : targetList) {
					int targetId = targetUnit.getTargetId();
					// 活动周期结算给奖励，isAutoSend为true
					giveBonus(userActivity, targetId, true, null);
				}
			}
		}
	}

	/**
	 * 获取目标列表的json字符串，给前台的消息中用
	 */
	@Override
	public String getTargetJsonStr(long charId) {
		JSONArray jsonArr = new JSONArray();
		AbstractUserGoodActivity userActivity = Globals.getGoodActivityService().getUserActivity(charId, getId());
		Collection<AbstractGoodActivityTargetUnit> bonusList = getTargetList();
		for (AbstractGoodActivityTargetUnit bonus : bonusList) {
			jsonArr.add(bonus.toJson(userActivity));
		}
		return jsonArr.toString();
	}
	
	/**
	 * 是否有可领取的奖励
	 * @param charId
	 * @return
	 */
	@Override
	public boolean hasBonus(long charId) {
		boolean flag = false;
		AbstractUserGoodActivity userActivity = Globals.getGoodActivityService().getUserActivity(charId, getId());
		if (null != userActivity && userActivity.getUserDataModel() != null) {
			flag = userActivity.getUserDataModel().hasBonus();
		}
		return flag;
	}
	
	/**
	 * 给玩家一个目标I对应的奖励，并记录日志
	 * @param userActivity
	 * @param targetId
	 * @param byMailSend 是否通过邮件发送
	 * @return
	 */
	protected boolean giveReward(AbstractUserGoodActivity userActivity, int targetId, boolean byMailSend, int giveBonusNum) {
		AbstractGoodActivityTargetUnit targetUnit = getTargetUnit(targetId);
		if (null == targetUnit || giveBonusNum <= 0) {
			return false;
		}
		// 按次数给奖励
		for (int i = 0; i < giveBonusNum; i++) {
			long charId = userActivity.getCharId();
			// 生成奖励
			Reward reward = targetUnit.createReward(userActivity.getCharId(), "goodActivityId=" + getId() + ";tplId=" + getTplId());
			if (reward == null || reward.isNull()) {
				return false;
			}
			
			boolean sendDirect = false;
			Player player = Globals.getOnlinePlayerService().getPlayer(charId);
			if (player != null && player.getHuman() != null && player.isInScene()) {
				// 玩家在线
				if (!byMailSend) {
					sendDirect = true;
					boolean flag = Globals.getRewardService().giveReward(player.getHuman(), reward, true);
					if (!flag) {
						// 记录错误日志
						Loggers.goodActivityLogger.error("#GoodActivity#giveReward#return false!charId=" + 
						charId + ";rewardUUId=" + reward.getUuid());
					}
				}
				// 功能按钮可能发生变化
				Globals.getFuncService().onFuncChanged(player.getHuman(), FuncTypeEnum.GOOD_ACTIVITY);
			}
	
			if (!sendDirect) {
				// 没有直接发，则通过邮件发奖励
				Globals.getMailService().sendSysMail(charId, MailType.SYSTEM, 
						targetUnit.getTargetTpl().getMailTitle(), targetUnit.getTargetTpl().getMailContent(), reward);
			}
			
			// 记录日志
			String param = "charId=" + charId + ";byMailSend=" + byMailSend + ";rewardUUId=" + reward.getUuid();
			Globals.getLogService().sendGoodActivityLog(null, GoodActivityLogReason.GIVE_REWARD, param, getId(), getTplId(), giveBonusNum, targetId);
		}
		return true;
	}
	
	/**
	 * 当前是否处于领奖阶段，默认为true，即随时可领奖
	 * @return
	 */
	public boolean isInGiveBonusState() {
		return true;
	}
	
	/**
	 * 能否领取指定的奖励
	 * @param userActivity
	 * @param targetId
	 * @param isAutoSend 是否活动结算时，自动给的奖励
	 * @return
	 */
	public boolean canGiveBonus(AbstractUserGoodActivity userActivity, int targetId, boolean isAutoSend, 
			Human human, boolean notice) {
		//如果是活动结算给奖励，则不需判断是否处于给奖励状态，否则需要看当前是否处于给奖励状态
		if (!isAutoSend && !isInGiveBonusState()) {
			return false;
		}
		//活动数据非法
		if (userActivity == null || 
				userActivity.getGoodActivity().getTargetUnit(targetId) == null) {
			return false;
		}
		
		AbstractGoodActivityTargetUnit targetUnit = userActivity.getGoodActivity().getTargetUnit(targetId);
		//目标的条件检查
		if (!targetUnit.condCheck(userActivity, notice, human)) {
			return false;
		}
		
		//需要消耗类的，在手动情况下为真，后边会检测扣除消耗；在自动情况下为假，即不自动消耗换奖励
		if (targetUnit.isNeedCost()) {
			if (isAutoSend) {
				return false;
			}
			//需要消耗的，默认只能一次 TODO
			
			return targetUnit.isCostEnough(human, notice);
		} else {
			//不需要消耗类的，看是否有未领取的奖励
			AbstractGoodActivityUserDataModel userDataModel = userActivity.getUserDataModel();
			if (null != userDataModel && userDataModel.hasUnGiveBonus(targetId)) {
				return true;
			}
		}
		
		return false;
	}
	
	/**
	 * 领取指定的奖励
	 * @param userActivity
	 * @param targetId
	 * @param isAutoSend 是否活动结算时，自动给的奖励
	 * @return
	 */
	public boolean giveBonus(AbstractUserGoodActivity userActivity, int targetId, boolean isAutoSend, Human human) {
		// 能否领取对应的奖励
		if (!canGiveBonus(userActivity, targetId, isAutoSend, human, false)) {
			return false;
		}
		
		int giveBonusNum = 0;
		AbstractGoodActivityUserDataModel userDataModel = userActivity.getUserDataModel();
		AbstractGoodActivityTargetUnit targeUnit = userActivity.getGoodActivity().getTargetUnit(targetId);
		//需要消耗的，先扣除消耗
		if (targeUnit.isNeedCost()) {
			//需要消耗的，自动情况下不给奖励
			if (isAutoSend) {
				return false;
			}
			//消耗扣除失败，不给奖励
			if (!targeUnit.costOnGiveBonus(human)) {
				return false;
			}
			//消耗成功扣除完后，reachNum+1
			userDataModel.addReachNum(targetId);
			
			//消耗类的固定就是一次
			giveBonusNum = 1;
		} else {
			// 获取未领取奖励的次数，自动发奖能给多少给多少，手动领奖只给一次
			giveBonusNum = userDataModel.getUnGiveBonusNum(targetId);
			if (!isAutoSend) {
				giveBonusNum = 1;
			}
		}
		if (giveBonusNum <= 0) {
			return false;
		}
		
		// 玩家活动数据更新
		boolean oFlag = userDataModel.onGiveBonus(targetId, giveBonusNum);
		if (!oFlag) {
			return false;
		}
		
		boolean flag = true;
		// 给玩家发奖励
		if (targeUnit.getTargetTpl().getRewardId() > 0) {
			flag &= giveReward(userActivity, targetId, isAutoSend, giveBonusNum);
		}
		//发目标的特殊奖励
		flag &= targeUnit.giveSpecialReward(human, giveBonusNum);
		
		//onFinishTarget事件监听
		Globals.getEventService().fireEvent(new GoodActivityFinishTargetEvent(null, 
				userActivity.getCharId(), getId(), targetId));
		
		return flag;
	}
	
	/**
	 * 是否新活动，1天之内开启的活动都返回true
	 * @return
	 */
	public boolean isNew() {
		long now = Globals.getTimeService().now();
		// 现在是1天
		long intervalTime = Globals.getGameConstants().getGoodAcitivtyNewTime();
		if (now - getStartTime() < intervalTime) {
			return true;
		}
		return false;
	}
	
	/**
	 * 是否最近开启的活动
	 * @return
	 */
	public boolean isRecentOpen() {
		long now = Globals.getTimeService().now();
		// 现在是2天
		long intervalTime = Globals.getGameConstants().getGoodAcitivtyRecentTime();
		if (now - getStartTime() < intervalTime) {
			return true;
		}
		return false;
	}
	
	/**
	 * 是否最近关闭的活动
	 * @return
	 */
	public boolean isRecentClose() {
		long now = Globals.getTimeService().now();
		// 现在是2天
		long intervalTime = Globals.getGameConstants().getGoodAcitivtyRecentTime();
		if (getEndTime() - now < intervalTime) {
			return true;
		}
		return false;
	}
	
	/**
	 * 获取倒计时时间，默认为距离活动结束的倒计时
	 */
	public long getCountDownTime() {
		long now = Globals.getTimeService().now();
		long diffTime = getEndTime() - now;
		if (diffTime < 0) {
			diffTime = 0;
		}
		return diffTime;
	}
	
	/**
	 * 获取倒计时的描述，默认为活动结束倒计时
	 */
	public String getCountDownTimeDesc() {
		return Globals.getLangService().readSysLang(LangConstants.GOOD_ACTIVITY_COUNT_DOWN_TIME_DESC_DEFAULT);
	}
	
	/**
	 * 获取活动界面中，玩家自身的描述信息，默认没有
	 */
	public String getSelfInfo(Human human) {
		return "";
	}
	
	/**
	 * 活动结束时是否需要发送玩家未领取的奖励，默认为true
	 * 
	 * @return
	 */
	public boolean needGiveUnGotRewardOnEnd() {
		// 默认活动结算后都需要结算奖励
		return true;
	}

	/**
	 * 是否需要周期性结算奖励，如果配置了周期天数，则视为需要周期性结算奖励，否则视为非周期性的
	 * @return
	 */
	public final boolean needGiveUnGotRewardPeriod() {
		// 如果配置了周期天数，则视为需要周期性结算奖励
		return getTpl().getUpdateDay() > 0;
	}

	/**
	 * 是否到了周期结算奖励的时间，默认为false
	 * @return
	 */
	protected boolean isReachGiveRewardPeriodTime() {
		// 检查是否到了结算周期
		return Globals.getTimeService().now() >= getNextRefreshTime();
	}

	/**
	 * 有结算周期类的活动定时检查发放奖励并更新结算时间，依据的时间是【lastRefreshTime】
	 * 注：结清玩家奖励后，该活动的所有玩家数据都会被删除，以便开始下一个新的周期
	 */
	public void checkGiveUnGotRewardPeriod() {
		// 是否有结算周期
		if (!needGiveUnGotRewardPeriod()) {
			return;
		}
		// 是否到了结算周期
		if (!isReachGiveRewardPeriodTime()) {
			return;
		}

		// 更新活动最后一次刷新时间
		updateLastRefreshTime(Globals.getTimeService().now());
		
		// 到了结算周期，需要给所有玩家发奖
		giveAllJoinedUserBonus();
		
		// 清除所有玩家数据
		Globals.getGoodActivityService().clearAllJoinedUserData(this);
	}
	
	/**
	 * 是否需要自动参加
	 * @return
	 */
	public boolean needAutoJoin() {
		// 默认不是玩家自动参加
		return false;
	}
	
	/**
	 * 获取下次刷新时间
	 * @return
	 */
	public long getNextRefreshTime() {
		long nextRefreshTime = 0;
		if (nextRefreshTimeCache == null) {
			nextRefreshTime = calcNextRefreshTime();
		} else {
			nextRefreshTime = nextRefreshTimeCache;
		}
		return nextRefreshTime;
	}
	
	/**
	 * 清除下一次刷新时间的缓存
	 */
	private void clearNextRefreshTimeCache() {
		nextRefreshTimeCache = null;
	}
	
	/**
	 * 计算下次刷新时间
	 * 以【最近一次刷新时间】为准，按照配置表的间隔时间计算出下次刷新时间
	 * @return
	 */
	private long calcNextRefreshTime() {
		long nextRefreshTime = 0;
		if (needGiveUnGotRewardPeriod()) {
			long lastRefreshTime = getLastRefreshTime();
			long diffDayTime = getTpl().getUpdateDay() * TimeUtils.DAY;
			int updateHour = getTpl().getUpdateHour();
			
			Calendar calendar = Calendar.getInstance();
			calendar.setTimeInMillis(lastRefreshTime + diffDayTime);
			calendar.set(Calendar.HOUR_OF_DAY, updateHour);
			calendar.set(Calendar.MINUTE, 0);
			calendar.set(Calendar.SECOND, 0);
			calendar.set(Calendar.MILLISECOND, 0);
			nextRefreshTime = calendar.getTimeInMillis();
			
			nextRefreshTimeCache = nextRefreshTime;
		}
		return nextRefreshTime;
	}
	
	/**
	 * 活动级的事件触发
	 * @param event
	 */
	public void onTriggerEvent(Event<?> event) {
		return;
	}
	
	/**
	 * 玩家能否参加/看到该活动
	 * 判断玩家的服务器Id是否在活动的服务器Ids中，如果在，则返回true，否则返回false
	 */
	@Override
	public boolean canUserJoin(long charId) {
		boolean flag = false;
		int serverId = Globals.getOfflineDataService().getUserServerId(charId);
		if (serverId > 0 && 
				null != goodActivityPO && null != goodActivityPO.getServerIdSet()) {
			flag = goodActivityPO.getServerIdSet().contains(serverId);
		}
		return flag;
	}
	
	/**
	 * 获取活动关心的事件
	 * @return
	 */
	public abstract EventType getBindEventType();
	
	/**
	 * 创建玩家活动对象
	 * @param charId
	 * @return
	 */
	public abstract AbstractUserGoodActivity buildUserGoodActivity(long charId);
	
	/**
	 * 构建一个目标
	 * @param targetTpl
	 */
	protected abstract void buildTargetUnit(GoodActivityTargetTemplate targetTpl);
	
	/**
	 * 活动是否需要隐藏掉
	 * @param userActivity
	 * @return
	 */
	public boolean needHide(AbstractUserGoodActivity userActivity) {
		if (userActivity != null) {
			if (userActivity.getUserDataModel().hasNothingToDo()) {
				return true;
			}
		}
		return false;
	}
}
