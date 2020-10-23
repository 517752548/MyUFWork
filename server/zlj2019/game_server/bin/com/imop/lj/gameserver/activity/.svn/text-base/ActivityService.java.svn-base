package com.imop.lj.gameserver.activity;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.annotation.SyncOper;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.msg.GCActivityList;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * 游戏功能服务
 * 
 * @author haijiang.jin
 * 
 */
public class ActivityService {
	public static final int CorpsWarId = 1;
	public static final int WorldBossWarId = 2;
	public static final int BunId = 3;
	public static final int MonsterWarId = 5;
	
	protected Map<Integer,Activity> allActivity;

	/**
	 * 类默认构造器
	 * 
	 */
	public ActivityService() {
		allActivity = new HashMap<Integer,Activity>();
	}

	/**
	 * 初始化游戏功能服务
	 * 
	 */
	@SyncOper
	public void init() {
		//加载各个活动
		Map<Integer,ActivityTemplate> activityTemplateMap = Globals.getTemplateCacheService().getAll(ActivityTemplate.class);
		for(Entry<Integer,ActivityTemplate> entry : activityTemplateMap.entrySet()){
			Activity activity = new Activity();
			activity.setActivityId(entry.getKey());
			activity.setTemplate(entry.getValue());
			// 按照模版设置活动状态，有可能有些活动关闭了
			ActivityState state = entry.getValue().getIsOpen() == 1 ? ActivityState.NOT_OPEN : ActivityState.CLOSE;
			activity.setState(state);
			allActivity.put(entry.getKey(), activity);
		}
	}
	
	public boolean activityIsOpen(int activityId){
		Activity activity = allActivity.get(activityId);
		if(activity != null && activity.getState().equals(ActivityState.OPENING)){
			return true;
		}
		return false;
	}
	
	public boolean setActivityState(int activityId , ActivityState state){
		Activity activity = allActivity.get(activityId);
		if(activity == null){
			return false;
		}
		activity.setState(state);
		try {
			Collection<Long> onlinePlayerIdList = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
			for (Long playerId : onlinePlayerIdList) {
				Player player = Globals.getOnlinePlayerService().getPlayer(playerId);
				if (player == null || player.getHuman() == null) {
					continue;
				}
				// 这里如果数据是请求的时候发，就不需要在这里再发消息给玩家了  XXX 
//				// XXX 到时候更前台定一下，看数据什么时候发，如果是请求发，那就可以注掉这里了
//				// 玩家是否开启了活动对应的功能
//				if (Globals.getFuncService().hasOpenedFunc(player.getHuman(), activity.getTemplate().getFuncType())) {
//					GCActivityUpdate gcActivityUpdate = new GCActivityUpdate();
//					gcActivityUpdate.setActivityList(activity.buildActivityInfo());
//					
//					player.sendMessage(gcActivityUpdate);
//				}
				// 功能按钮变化
				Globals.getFuncService().onFuncChanged(player.getHuman(), FuncTypeEnum.ACTIVITY_UI);
			}
			// 通知每日活动面板
//			Globals.getEveryDayActivityService().activityStateChange(activityId);
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.playerLogger.error("setActivityState error="+e.getMessage());
		}
		return true;
	}
	
	public Activity getActivity(int activityId){
		return allActivity.get(activityId);
	}
	
	/**
	 * 用户上线时，通知正在进行的活动
	 * @param human
	 */
	public void noticeActivity(Human human) {
		if (!allActivity.isEmpty()) {
			List<ActivityInfo> activityList = new ArrayList<ActivityInfo>();
			for (Activity activity : allActivity.values()) {
				// 玩家是否开启了活动对应的功能
				if (Globals.getFuncService().hasOpenedFunc(human, activity.getTemplate().getFuncType())) {
					ActivityInfo activityInfo = activity.buildActivityInfo();
					activityList.add(activityInfo);
				}
			}
			if (activityList.size() > 0) {
				GCActivityList gcActivityList = new GCActivityList(activityList.toArray(new ActivityInfo[0]));
				human.sendMessage(gcActivityList);
			}
		}
	}
	
	
	/**
	 * 刷新活动
	 * @param human
	 */
	public void refreshActivity() {
		for (Activity activity : allActivity.values()) {
			activity.setState(ActivityState.NOT_OPEN);
		}
	}
	
	public Map<Integer, Activity> getAllActivity() {
		return allActivity;
	}
	
}
