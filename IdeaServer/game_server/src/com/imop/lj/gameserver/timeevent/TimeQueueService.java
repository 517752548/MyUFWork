package com.imop.lj.gameserver.timeevent;

import java.text.MessageFormat;
import java.util.Calendar;
import java.util.Collection;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.ArrayListMultimap;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.activity.function.ActivityTask;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.cache.service.TemplateCacheService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpsboss.CorpsBossDef;
import com.imop.lj.gameserver.nvn.NvnDef;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.msg.AddLoginDaysMessage;
import com.imop.lj.gameserver.player.msg.SysGivePowerMessage;
import com.imop.lj.gameserver.timeevent.template.RefreshActivityStateTemplate;
import com.imop.lj.gameserver.timeevent.template.RefreshArenaTemplate;
import com.imop.lj.gameserver.timeevent.template.RefreshDevilIncarnateTemplate;
import com.imop.lj.gameserver.timeevent.template.ScribedLogTimeEventTemplate;
import com.imop.lj.gameserver.timeevent.template.SysPowerGiveTimeTemplate;
import com.imop.lj.gameserver.timeevent.template.TimeNoticeTemplate;
import com.imop.lj.gameserver.xianhu.XianhuDef;

/**
 * 定时服务 外部只需要关心已经定义的时间id,增加自己要运行的{@link Runnable}即可
 * 
 * @author jiliang.lu
 * 
 */
public class TimeQueueService implements InitializeRequired {

	protected TimeEventHeartbeatThread timeEventHeartbeatThread;

	/** key - 定时时间点的id, value 时间点 */
	protected Map<Integer, Long> timePoints = Maps.newConcurrentHashMap();

	/** key - 距离{{@link #getZeroTime()}的时间点, value - 要运行的Runnable组 */
	protected ArrayListMultimap<Long, Runnable> eventMap = new ArrayListMultimap<Long, Runnable>();

	public TimeQueueService() {
		
	}

	@Override
	public void init() {
		TimeService timeService = Globals.getTimeService();
		TemplateCacheService tmplService = Globals.getTemplateCacheService();
		Collection<TimeEventTemplate> allTimePoint = tmplService.getAll(TimeEventTemplate.class).values();
		for (TimeEventTemplate timeEventTmpl : allTimePoint) {
			long zeroTime = TimeUtils.getTodayBegin(timeService);

			Calendar nowCal = Calendar.getInstance();
			nowCal.setTimeInMillis(timeService.now());
			Calendar date = TimeUtils.mergeDateAndTime(nowCal, timeEventTmpl.getTriggerTimePoint());

			long diff = date.getTimeInMillis() - zeroTime;

			timePoints.put(timeEventTmpl.getId(), diff);
		}

		// 补充军令
		SysPowerGiveTimeTemplate sysPowerGiveTimeTemplate = tmplService.get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, SysPowerGiveTimeTemplate.class);
		for (int timeEventId : sysPowerGiveTimeTemplate.getTimeEventIds()) {
			addTask(timeEventId, this.new SysGivePowerTask());
		}

		ScribedLogTimeEventTemplate scribedLogTimeEventTemplate = tmplService.get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, ScribedLogTimeEventTemplate.class);
		for (int timeEventId : scribedLogTimeEventTemplate.getTimeEventIds()) {
			addTask(timeEventId, this.new sendScribedLogTask());
		}
		
		//刷新混世魔王
		RefreshDevilIncarnateTemplate devilRefreshTpl = tmplService.get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, RefreshDevilIncarnateTemplate.class);
		for (int timeEventId : devilRefreshTpl.getTimeEventIds()) {
			addTask(timeEventId, this.new RefreshDevilTask());
		}
		
		//刷新限时活动
		RefreshDevilIncarnateTemplate pushTpl = tmplService.get(SharedConstants.CONFIG_TEMPLATE_SKILL_POINT_ID, RefreshDevilIncarnateTemplate.class);
		for (int timeEventId : pushTpl.getTimeEventIds()) {
			addTask(timeEventId, this.new pushTimeLimitAct());
		}
		
		// 登录天数更新，每天0点
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), this.new AddLoginDaysTask());
//		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new VipFreshTask());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateArmyTitleSalaryDaysTask());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateBankDaysTask());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateEveryDayTargetTask());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateGemMazeEnergy());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateLoopTask());
//		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new EscortFreshTask());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateEveryDayChargeGift());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateSpecialActivityUI());
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateRank());
		//nvn联赛排名刷新
		addTask(NvnDef.NvnRankRewardTimeId, this.new RefreshNvnRankTask());
		//帮派维护费用
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new updateCorpsMaintenanceCost());
		//刷新科举
		addTask(Globals.getGameConstants().getAddLoginDaysTimeEventId(), new RefreshExamTask());
		//帮派boss进度榜排名刷新
		addTask(Globals.getGameConstants().getCorpsBossRankRewardTimeId(), this.new RefreshCorpsBossRankTask());
		//帮派boss挑战次数榜排名刷新
		addTask(CorpsBossDef.rankRewardTimeId, this.new RefreshCorpsBossCountRankTask());
		//仙葫排行榜
		addTask(XianhuDef.RankTimeEventId, this.new RefreshXianhuRank());
		
		// 活动
		Map<Integer, ActivityTemplate> activityTemplateMap = tmplService.getAll(ActivityTemplate.class);
		for (Entry<Integer, ActivityTemplate> entry : activityTemplateMap.entrySet()) {
			ActivityTemplate activityTemplate = entry.getValue();
			if (activityTemplate.getNoticeActivityTimeEventId() != 0 && activityTemplate.getNoticeFunction() != null) {
				addTask(activityTemplate.getNoticeActivityTimeEventId(), new ActivityTask(activityTemplate.getNoticeFunction()));
			}
			if (activityTemplate.getReadyActivityTimeEventId() != 0 && activityTemplate.getReadyFunction() != null) {
				addTask(activityTemplate.getReadyActivityTimeEventId(), new ActivityTask(activityTemplate.getReadyFunction()));
			}
			if (activityTemplate.getStartActivityTimeEventId() != 0 && activityTemplate.getStartFunction() != null) {
				addTask(activityTemplate.getStartActivityTimeEventId(), new ActivityTask(activityTemplate.getStartFunction()));
			}
			if (activityTemplate.getEndActivityTimeEventId() != 0 && activityTemplate.getEndFunction() != null) {
				addTask(activityTemplate.getEndActivityTimeEventId(), new ActivityTask(activityTemplate.getEndFunction()));
			}
		}
		// 活动刷新
		RefreshActivityStateTemplate refreshActivityStateTemplate = tmplService.get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, RefreshActivityStateTemplate.class);
		for (int timeEventId : refreshActivityStateTemplate.getTimeEventIds()) {
			addTask(timeEventId, this.new RefreshActivityTask());
		}
		
		// 竞技场刷新
		RefreshArenaTemplate refreshArenaTemplate = tmplService.get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, RefreshArenaTemplate.class);
		for (int timeEventId : refreshArenaTemplate.getTimeEventIds()) {
			addTask(timeEventId, this.new RefreshArenaTask());
		}
		
//		//装备强化活动刷新
//		for(EnhanceActivityTemplate temp : Globals.getTemplateCacheService().getAll(EnhanceActivityTemplate.class).values()){
//			addTask(temp.getStartTimeId(), new EnhanceActivityTask(true, temp.getId()));
//			addTask(temp.getEndTimeId(), new EnhanceActivityTask(false, temp.getId()));
//		}
		
		// 定时公告
		for (TimeNoticeTemplate tpl : Globals.getTemplateCacheService().getAll(TimeNoticeTemplate.class).values()) {
			addTask(tpl.getNoticeTimeId(), new TimeBroadcastTask(tpl.getBroadcastId()));
		}
		
				
		timeEventHeartbeatThread = new TimeEventHeartbeatThread(eventMap);
	}

	public void start() {
		Loggers.gameLogger.info("begin start timeEventHeartbeatThread");
		timeEventHeartbeatThread.start();
		Loggers.gameLogger.info("end start timeEventHeartbeatThread");
	}

	public void stop() {
		Loggers.gameLogger.info("begin stop timeEventHeartbeatThread");
		timeEventHeartbeatThread.shutdown();
		Loggers.gameLogger.info("end stop timeEventHeartbeatThread");
	}
	
	public void restart(){
		Loggers.gameLogger.info("begin restart timeEventHeartbeatThread");
		timeEventHeartbeatThread.restart();
		Loggers.gameLogger.info("end restart timeEventHeartbeatThread");
	}
	
	/**
	 * 提交任务马上执行
	 * 
	 * @param task
	 */
	public void sumbit(Runnable task){
		if(task == null){
			Loggers.gameLogger.error("[TimeQueueService sumit]The submit task is null");
			return;
		}
		timeEventHeartbeatThread.submit(task);
	}

	/**
	 * 提交一个调度任务
	 * 
	 * @param task
	 * @param delay
	 */
	public void addTask(int timeId, Runnable task) {
		if (!timePoints.containsKey(timeId)) {
			Loggers.gameLogger.warn(String.format("提交了一个未知的定时时间点任务,timeId:%s", timeId));
			return;
		}
		eventMap.put(timePoints.get(timeId), task);
	}

	/**
	 * 赠送体力消息
	 * 
	 * 
	 */
	public class SysGivePowerTask implements Runnable {
		@Override
		public void run() {
			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
			long start=Globals.getTimeService().now();
			for (Player player : onlinePlayerService.getOnlinePlayers()) {
				player.putMessage(new SysGivePowerMessage(player.getRoleUUID()));
			}
			long end=Globals.getTimeService().now();
			// 记录日志
			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
				String content = "任务：{0}:执行所需时间:{1}ms";
				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"SysGivePowerTask",end-start+""));
			}
		}
	}
	
	/**
	 * 刷新活动消息
	 * 
	 * 
	 */
	public class RefreshActivityTask implements Runnable {
		@Override
		public void run() {
//			long start=Globals.getTimeService().now();
//			Globals.getActivityService().refreshActivity();
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"RefreshActivityTask",end-start+""));
//			}
			long start=Globals.getTimeService().now();
			// 改为放入公共场景中处理活动的状态变化
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getActivityService().refreshActivity();
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
			
			long end=Globals.getTimeService().now();
			// 记录日志
			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
				String content = "任务：{0}:执行所需时间:{1}ms";
				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"RefreshActivityTask",end-start+""));
			}

		}
	}
	
	/*
	 * 刷新竞技场信息
	 */
	public class RefreshArenaTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getArenaService().refreshArena("RefreshArenaMsg");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新nvn联赛排名
	 */
	public class RefreshNvnRankTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getNvnService().refreshNvnRankMonthly("RefreshNvnRankTask");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新科举
	 */
	public class RefreshExamTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getExamService().refreshExam("RefreshExamTask");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新混世魔王
	 */
	public class RefreshDevilTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getDevilIncarnateService().randAddDevilNpc("RefreshDevilTask");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新限时活动
	 */
	public class pushTimeLimitAct implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getTimeLimitService().randomPush("pushTimeLimitAct");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新帮派boss进度榜排名
	 */
	public class RefreshCorpsBossRankTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getCorpsBossService().refreshCorpsBossRankWeekly("RefreshCorpsBossRankTask");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/*
	 * 刷新帮派boss挑战次数榜排名
	 */
	public class RefreshCorpsBossCountRankTask implements Runnable {
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getCorpsBossService().refreshCorpsBossCountRankWeekly("RefreshCorpsBossCountRankTask");
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/**
	 * 定时广播
	 * @author yu.zhao
	 *
	 */
	public class TimeBroadcastTask implements Runnable {
		private int broadcastId;
		
		public TimeBroadcastTask(int broadcastId) {
			this.broadcastId = broadcastId;
		}
		
		@Override
		public void run() {
			Globals.getBroadcastService().broadcastWorldMessage(broadcastId);
		}
	}
	
	/**
	 * 汇报留存
	 * 
	 */
	public class sendScribedLogTask implements Runnable {
		@Override
		public void run() {
			Globals.getLocalScribeService().localScribedAllLeftBond();
		}
	}
	
	/**
	 * 增加登录天数
	 * @author yu.zhao
	 *
	 */
	public class AddLoginDaysTask implements Runnable {
		@Override
		public void run() {
			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
			long start=Globals.getTimeService().now();
			for (Player player : onlinePlayerService.getOnlinePlayers()) {
				player.putMessage(new AddLoginDaysMessage(player.getRoleUUID()));
			}
			long end=Globals.getTimeService().now();
			// 记录日志
			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
				String content = "任务：{0}:执行所需时间:{1}ms";
				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"AddLoginDaysTask",end-start+""));
			}
		}
	}
	
	/**
	 * 得到某时间点对应当天的实际毫秒数
	 * 
	 * @param timeId
	 * @return
	 */
	public long getLastRealTime(int timeId) {
		TimeService timeService = Globals.getTimeService();
		if (timePoints.containsKey(timeId)) {
			long zeroTime = TimeUtils.getTodayBegin(timeService);
			return zeroTime + timePoints.get(timeId);
		}
		return -1l;
	}
	
	/**
	 * 0点更新军团俸禄
	 * @author bing.dong
	 *
	 */
	public class updateArmyTitleSalaryDaysTask implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateArmyTitlSalaryMessage(player.getRoleUUID()));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateArmyTitleSalaryDaysTask",end-start+""));
//			}
		}
	}
	
	/**
	 * 钱庄0点更新
	 * @author bing.dong
	 *
	 */
	public class updateBankDaysTask implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateBankweekMessage(player.getRoleUUID()));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateBankDaysTask",end-start+""));
//			}
		}
	}
	
	/**
	 * 每日必做0点更新
	 * 每日首充0点更新
	 * @author bing.dong
	 *
	 */
	public class updateEveryDayTargetTask implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateEveryDayTargetDataMessage(player.getRoleUUID()));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateEveryDayTargetTask",end-start+""));
//			}
		}
	}
	
	/**
	 * 宝石迷阵恢复体力，0点更新
	 * @author bing.dong
	 *
	 */
	public class updateGemMazeEnergy implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateGemMazeEnergyDataMessage(player.getRoleUUID()));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"UpdateGemMazeEnergyDataMessage",end-start+""));
//			}
		}
	}
	
	/**
	 * 主界面邀请好友的状态，0点更新
	 *
	 */
	public class updateMainPanelInviteInfo implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateMainPanelInviteInfoMsg(player));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateMainPanelInviteInfo",end-start+""));
//			}
		}
	}
	/**
	 * 环任务，0点更新
	 *
	 */
	public class updateLoopTask implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateLoopTask0ClockMsg(player));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateLoopTask",end-start+""));
//			}
		}
	}
	/**
	 * 每日首充
	 * @author bing.dong
	 */
	public class updateEveryDayChargeGift implements Runnable {
		@Override
		public void run() {
//			OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();
//			long start=Globals.getTimeService().now();
//			for (Player player : onlinePlayerService.getOnlinePlayers()) {
//				player.putMessage(new UpdateEverydayChargeGift0ClockMsg(player));
//			}
//			long end=Globals.getTimeService().now();
//			// 记录日志
//			if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
//				String content = "任务：{0}:执行所需时间:{1}ms";
//				Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateEveryDayChargeGift",end-start+""));
//			}
		}
	}
	
	/**
	 * 每天0点刷新活动ui的推荐活动及节日
	 * @author jialiang.liu
	 */
	public class updateSpecialActivityUI implements Runnable {
		
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					long start=Globals.getTimeService().now();
					Globals.getActivityUIService().init();
					long end=Globals.getTimeService().now();
					// 记录日志
					if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
						String content = "任务：{0}:执行所需时间:{1}ms";
						Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateSpecialActivityUI",end-start+""));
					}
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/**
	 * 每天定时刷新排行榜
	 * @author jialiang.liu
	 */
	public class updateRank implements Runnable {
		
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					long start=Globals.getTimeService().now();
					Globals.getRankService().rebuildRanks();
					long end=Globals.getTimeService().now();
					// 记录日志
					if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
						String content = "任务：{0}:执行所需时间:{1}ms";
						Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateRanks",end-start+""));
					}
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
	/**
	 * 每天0点扣除帮派维护费用
	 * @author Administrator
	 *
	 */
	public class updateCorpsMaintenanceCost implements Runnable{

		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					long start = Globals.getTimeService().now();
					Globals.getCorpsService().updateCorpsMaintenanceCost();
					long end = Globals.getTimeService().now();
					// 记录日志
					if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
						String content = "任务：{0}:执行所需时间:{1}ms";
						Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateCorpsMaintenanceCost",end-start+""));
					}
				}
			};
			
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
		
	}
	
	/**
	 * 刷新仙葫排行榜
	 * @author yu.zhao
	 *
	 */
	public class RefreshXianhuRank implements Runnable {
		
		@Override
		public void run() {
			IMessage msg = new SysInternalMessage() {
				@Override
				public void execute() {
					long start = Globals.getTimeService().now();
					Globals.getXianhuService().refreshPreRankDaily(false, false);
					long end = Globals.getTimeService().now();
					// 记录日志
					if (Loggers.timeEventTaskLogger.isInfoEnabled()) {
						String content = "任务：{0}:执行所需时间:{1}ms";
						Loggers.timeEventTaskLogger.warn(MessageFormat.format(content,"updateXianhuRank",end-start+""));
					}
				}
			};
			Globals.getSceneService().getCommonScene().putMessage(msg);
		}
	}
	
}
