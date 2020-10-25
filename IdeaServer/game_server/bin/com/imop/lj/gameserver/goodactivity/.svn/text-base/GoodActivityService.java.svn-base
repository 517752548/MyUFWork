package com.imop.lj.gameserver.goodactivity;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import net.sf.json.JSONObject;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.GoodActivityLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.goodactivity.GoodActivityInfo;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityStatus;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.goodactivity.activity.impl.BuyMoneyActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.DayTotalChargeActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.EveryCostActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.LevelMoneyActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.LevelUpActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.NormalTotalChargeActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.SevenDayLoginActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.TotalChargeBuyActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.TotalCostActivity;
import com.imop.lj.gameserver.goodactivity.activity.impl.VipLevelActivity;
import com.imop.lj.gameserver.goodactivity.msg.GoodActivityMsgBuilder;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityUserPO;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBaseTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.player.Player;

/**
 * 精彩活动服务
 *
 * @author yu.zhao
 */
public class GoodActivityService implements InitializeRequired {

    /**
     * 活动数据Map<活动唯一Id， 活动对象>
     */
    protected Map<Long, AbstractGoodActivity> activityMap = Maps.newTreeMap();

    /**
     * 对事件敏感的活动集合Map<事件类型，Set<活动唯一Id>>
     */
    protected Map<EventType, Set<Long>> eventToActivityMap = Maps.newHashMap();

    /**
     * 玩家活动Map<玩家Id，Map<活动唯一Id，玩家活动对象>>
     */
    protected Map<Long, Map<Long, AbstractUserGoodActivity>> userActivityMap = Maps.newHashMap();
    /**
     * 活动对应的所有玩家列表，用于活动结束后的发奖等 Map<活动唯一Id，参加该活动的玩家列表>
     */
    protected Map<Long, List<AbstractUserGoodActivity>> userJoinActivityMap = Maps.newHashMap();


    public GoodActivityService() {

    }

    @Override
    public void init() {
        // 加载活动数据、玩家活动数据
        loadAllActivity();
        loadAllUserActivity();
    }

    /**
     * 加载所有未关闭的活动
     */
    protected void loadAllActivity() {
        // 加载所有未关闭的活动
        List<GoodActivityEntity> activityEntityList = Globals.getDaoService().getGoodActivityDao().loadAllEntity();
        for (GoodActivityEntity entity : activityEntityList) {
            GoodActivityType activityType = GoodActivityType.valueOf(entity.getActivityType());
            if (null == activityType) {
                // 非法数据
                continue;
            }
            // 活动已关闭
            if (entity.getIsClosed() > 0) {
                continue;
            }

            GoodActivityPO goodActivityPO = new GoodActivityPO();
            goodActivityPO.fromEntity(entity);
            AbstractGoodActivity activity = buildGoodActivity(activityType, goodActivityPO);
            addActivity(activity);
        }
    }

    /**
     * 加载未关闭的活动的玩家数据
     */
    protected void loadAllUserActivity() {
        // 加载玩家活动数据，如果活动已关闭，则不放入内存
        List<GoodActivityUserEntity> userEntityList = Globals.getDaoService().getGoodActivityUserDao().loadAllEntity();
        for (GoodActivityUserEntity userEntity : userEntityList) {
            long activityId = userEntity.getActivityId();
            // 全局活动map中没有，说明此活动没有或已关闭，这样的数据不加载
            AbstractGoodActivity activity = getGoodActivity(activityId);
            if (null == activity) {
                continue;
            }
            // 已删除的数据不加载
            if (userEntity.getDeleted() != 0) {
                continue;
            }
            AbstractUserGoodActivity userGoodActivity = activity.buildUserGoodActivity(userEntity.getCharId());
            GoodActivityUserPO userPO = new GoodActivityUserPO(userGoodActivity);
            userPO.fromEntity(userEntity);
            userGoodActivity.setGoodActivityUserPO(userPO);
            addToMapOnUserJoinActivity(userGoodActivity);
        }
    }

    /**
     * 获取玩家所有活动数据map
     *
     * @param uuid
     * @return
     */
    protected Map<Long, AbstractUserGoodActivity> getUserActivityMap(long uuid) {
        return userActivityMap.get(uuid);
    }

    /**
     * 获取玩家指定活动的数据
     *
     * @param uuid
     * @param activityId
     * @return
     */
    public AbstractUserGoodActivity getUserActivity(long uuid, long activityId) {
        Map<Long, AbstractUserGoodActivity> userActivityMap = getUserActivityMap(uuid);
        if (null != userActivityMap) {
            return userActivityMap.get(activityId);
        }
        return null;
    }

    /**
     * 获取对指定事件敏感的活动Id集合
     *
     * @param eventType
     * @return
     */
    protected Set<Long> getActivitySetByEvent(EventType eventType) {
        return eventToActivityMap.get(eventType);
    }

    /**
     * 将活动加入事件敏感集合
     *
     * @param activity
     */
    protected void addActivityToEventMap(AbstractGoodActivity activity) {
        if (null == activity) {
            return;
        }
        EventType eventType = activity.getBindEventType();
        if (null == eventType) {
            return;
        }
        Set<Long> activityIdSet = getActivitySetByEvent(eventType);
        if (null == activityIdSet) {
            activityIdSet = new HashSet<Long>();
            eventToActivityMap.put(eventType, activityIdSet);
        }
        activityIdSet.add(activity.getId());
    }

    /**
     * 获取参加某一活动的玩家活动数据列表
     *
     * @param activityId
     * @return
     */
    public List<AbstractUserGoodActivity> getJoinActivityUserList(long activityId) {
        return userJoinActivityMap.get(activityId);
    }

    /**
     * 某一活动是否有玩家数据
     *
     * @param activityId
     * @return
     */
    public boolean hasAnyUserInActivity(long activityId) {
        boolean flag = false;
        List<AbstractUserGoodActivity> userList = getJoinActivityUserList(activityId);
        if (userList != null && !userList.isEmpty()) {
            flag = true;
        }
        return flag;
    }

    /**
     * 获取所有的活动map
     *
     * @return
     */
    protected Map<Long, AbstractGoodActivity> getAllActivityMap() {
        return activityMap;
    }

    /**
     * 获取指定活动对象
     *
     * @param activityId
     * @return
     */
    public AbstractGoodActivity getGoodActivity(long activityId) {
        return activityMap.get(activityId);
    }

    /**
     * 添加一个活动对象
     *
     * @param activity
     */
    protected void addActivity(AbstractGoodActivity activity) {
        activityMap.put(activity.getId(), activity);
    }

    /**
     * 打开精彩活动面板
     *
     * @param human
     */
    public void openGoodActivityPanel(Human human, FuncTypeEnum func) {
        List<GoodActivityInfo> activityInfoList = getActivityInfoList(human, func);
        human.sendMessage(GoodActivityMsgBuilder.buildGCGoodActivityList(func, activityInfoList));
        if (!activityInfoList.isEmpty()) {
        	
        } else {
//            human.sendErrorMessage(LangConstants.GOOD_ACTIVITY_NO_DATA);
        }
    }

    /**
     * 获取精彩活动列表信息
     *
     * @param human
     * @return
     */
    public List<GoodActivityInfo> getActivityInfoList(Human human, FuncTypeEnum func) {
        long charId = human.getCharId();
        List<GoodActivityInfo> activityInfoList = new ArrayList<GoodActivityInfo>();
        for (AbstractGoodActivity activity : getAllActivityMap().values()) {
        	//func为null表示取全部，不是null则取对应func的活动数据
        	if (func != null && activity.getGoodActivityType().getFuncType() != func) {
        		continue;
        	}
            // 已关闭的活动不显示
            if (!activity.isOpening()) {
                continue;
            }
            // 如果不属于活动服务器Ids则不能参加，也不能显示
            if (!activity.canUserJoin(charId)) {
                continue;
            }
            //需要隐藏的活动不发给前台
            if (activity.needHide(getUserActivity(charId, activity.getId()))) {
            	continue;
            }

            activityInfoList.add(buildGoodActivityInfo(human, activity));
        }
        return activityInfoList;
    }

    /**
     * 构建一个活动的信息
     *
     * @param human
     * @param activity
     * @return
     */
    public GoodActivityInfo buildGoodActivityInfo(Human human, AbstractGoodActivity activity) {
        long charId = human.getUUID();
        GoodActivityInfo info = new GoodActivityInfo();
        info.setActivityId(activity.getId());
        info.setTypeId(activity.getGoodActivityType().getIndex());
        info.setIcon(activity.getIcon());
        info.setName(activity.getName());
        info.setDesc(activity.getDesc());
        info.setLogList(activity.getLogList().toArray(new String[0]));
        info.setNameIcon(activity.getNameIcon());
        info.setTitleIcon(activity.getTitleIcon());

        info.setStartTime(activity.getStartTime());
        info.setEndTime(activity.getEndTime());
        info.setIsNew(activity.isNew() ? 1 : 0);

        info.setHasUnGotBonus(activity.hasBonus(charId) ? 1 : 0);

        info.setCountDownTime(activity.getCountDownTime());
        info.setCountDownTimeDesc(activity.getCountDownTimeDesc());

        info.setSelfInfo(activity.getSelfInfo(human));
        info.setTargetInfo(activity.getTargetJsonStr(charId));
        info.setShowTargetType(activity.getShowTargetType());

        info.setIsRecentOpen(activity.isRecentOpen() ? 1 : 0);
        info.setIsRecentClose(activity.isRecentClose() ? 1 : 0);
        //是否需要隐藏活动
        info.setNeedHide(activity.needHide(getUserActivity(charId, activity.getId())) ? 1 : 0);
        return info;
    }

    /**
     * 获取玩家的一个活动的信息
     *
     * @param human
     * @param activityId
     * @return
     */
    public GoodActivityInfo getActivityInfo(Human human, int activityId) {
        AbstractGoodActivity activity = getGoodActivity(activityId);
        if (null == activity || !activity.isOpening()) {
            return new GoodActivityInfo();
        }
        return buildGoodActivityInfo(human, activity);
    }

    /**
     * 活动结束后，从相应的map中删除该活动
     * 注：玩家数据和活动数据都没有从db中删除
     *
     * @param activity
     */
    protected void clearFromMapOnActivityEnd(AbstractGoodActivity activity, String source) {
        long endActivityId = activity.getId();
        if (null != userJoinActivityMap.get(endActivityId)) {
            for (AbstractUserGoodActivity userActivity : userJoinActivityMap.get(endActivityId)) {
                long charId = userActivity.getCharId();
                Map<Long, AbstractUserGoodActivity> userMap = userActivityMap.get(charId);
                if (null != userMap && userMap.containsKey(endActivityId)) {
                    // 活动结束，从玩家map中移除
                    userMap.remove(endActivityId);
                    // 记录日志
                    Globals.getLogService().sendGoodActivityLog(null, GoodActivityLogReason.USER_DATE_DEL, "userActivity=" + userActivity,
                            endActivityId, activity.getTplId(), 0, 0);
                }
            }
            userJoinActivityMap.remove(endActivityId);
        }
        activityMap.remove(endActivityId);

        Set<Long> eventActivitySet = eventToActivityMap.get(activity.getBindEventType());
        if (null != eventActivitySet) {
            eventActivitySet.remove(endActivityId);
        }

        // 记录日志，活动结束，从map中删除
        Globals.getLogService().sendGoodActivityLog(null, GoodActivityLogReason.ACTIVITY_END, source, endActivityId, activity.getTplId(), 0, 0);
    }

    /**
     * 登录时检查有没有玩家可以自动参加的活动
     *
     * @param human
     */
    public void onPlayerLogin(Human human) {
        // 功能是否开启
        if (!Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.GOOD_ACTIVITY)) {
            return;
        }

        boolean joinFlag = false;
        for (AbstractGoodActivity activity : getAllActivityMap().values()) {
            if (activity.isOpening()) {
                // 检查玩家是否可加入活动中
                joinFlag |= checkAutoJoinActivity(human, activity);
            }
        }
        if (joinFlag) {
            // 功能按钮变化
            Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GOOD_ACTIVITY);
        }

        // 如果当前有精彩活动，则弹出界面
        List<GoodActivityInfo> activityInfoList = getActivityInfoList(human, FuncTypeEnum.GOOD_ACTIVITY);
        if (!activityInfoList.isEmpty()) {
            human.sendMessage(GoodActivityMsgBuilder.buildGCGoodActivityList(FuncTypeEnum.GOOD_ACTIVITY, activityInfoList));
        }
    }

    /**
     * 玩家自动参加活动的检查
     * 注：一些特殊的活动可能不需要玩家做操作，所以让玩家自动参加
     *
     * @param human
     * @param activity
     * @return
     */
    public boolean checkAutoJoinActivity(Human human, AbstractGoodActivity activity) {
        // 功能是否开启
        if (!Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.GOOD_ACTIVITY)) {
            return false;
        }

        // 自动参加，状态类活动，需要登录时候检查
        if (!activity.needAutoJoin()) {
            return false;
        }

        long charId = human.getCharId();
        // 玩家能否加入活动，如果不属于活动服务器Ids则不能参加
        if (!activity.canUserJoin(charId)) {
            return false;
        }

        boolean updateFlag = false;
        AbstractUserGoodActivity userGoodActivity = getUserActivity(charId, activity.getId());
        // 玩家已经加入过活动
        if (null != userGoodActivity) {
            // 因为是状态类活动，调用autoJoin是为了实时检查玩家状态是否发生了变化，从而引起一些活动变为可领奖，如果vip等级可离线发生变化
            updateFlag = userGoodActivity.getUserDataModel().autoJoin(human);
        } else {
            // 玩家未加入过活动，构建玩家活动数据
            userGoodActivity = buildUserGoodActivity(charId, activity);
            // 自动参加，更新相应数据
            updateFlag = userGoodActivity.getUserDataModel().autoJoin(human);
            if (updateFlag) {
                // 加入map并创建存储对象
                onUserJoinActivity(userGoodActivity);
                // 存库
                userGoodActivity.getUserDataModel().save();
            }
        }
        return updateFlag;
    }

    /**
     * 玩家直接达成某活动的指定目标
     * 注：一些特殊的活动是直接筛选出指定的玩家达成目标，不需要玩家自身操作
     *
     * @param charId
     * @param activity
     * @param targetId
     */
    public AbstractUserGoodActivity directReachTargetOfActivity(long charId, AbstractGoodActivity activity, int targetId) {
        // 如果玩家精彩活动已开启
        if (!Globals.getFuncService().hasOpenedFunc(charId, FuncTypeEnum.GOOD_ACTIVITY)) {
            return null;
        }
        // 玩家能否加入活动，如果不属于活动服务器Ids则不能参加
        if (!activity.canUserJoin(charId)) {
            return null;
        }

        AbstractUserGoodActivity userGoodActivity = getUserActivity(charId, activity.getId());
        if (null == userGoodActivity) {
            userGoodActivity = buildUserGoodActivity(charId, activity);
            onUserJoinActivity(userGoodActivity);
        }
        // 玩家直接达成目标
        userGoodActivity.getUserDataModel().directReachTarget(targetId);

        // 如果玩家在线，通知功能按钮变化
        Player player = Globals.getOnlinePlayerService().getPlayer(charId);
        if (player != null && player.getHuman() != null) {
            // 功能按钮变化
            Globals.getFuncService().onFuncChanged(player.getHuman(), FuncTypeEnum.GOOD_ACTIVITY);
        }
        return userGoodActivity;
    }

    /**
     * 创建玩家活动对象
     *
     * @param charId
     * @param activity
     * @return
     */
    protected AbstractUserGoodActivity buildUserGoodActivity(long charId, AbstractGoodActivity activity) {
        AbstractUserGoodActivity userActivity = getUserActivity(charId, activity.getId());
        if (null != userActivity) {
            // 玩家此活动数据已经构建过
            return userActivity;
        }
        AbstractUserGoodActivity userGoodActivity = activity.buildUserGoodActivity(charId);
        return userGoodActivity;
    }

    /**
     * 将玩家活动对象放入相应的map中，并构建db存储对象
     *
     * @param userGoodActivity
     * @return
     */
    protected AbstractUserGoodActivity onUserJoinActivity(AbstractUserGoodActivity userGoodActivity) {
        long charId = userGoodActivity.getCharId();
        long activityId = userGoodActivity.getGoodActivity().getId();
        // 检查是否已存在
        if (null != getUserActivity(charId, activityId)) {
            return userGoodActivity;
        }

        // 创建db存储对象
        GoodActivityUserPO userPO = createGoodActivityUserPO(userGoodActivity);
        userGoodActivity.setGoodActivityUserPO(userPO);

        // 加到map中
        addToMapOnUserJoinActivity(userGoodActivity);
        return userGoodActivity;
    }

    /**
     * 将玩家活动数据加入相应的map
     *
     * @param userGoodActivity
     */
    protected void addToMapOnUserJoinActivity(AbstractUserGoodActivity userGoodActivity) {
        long charId = userGoodActivity.getCharId();
        long activityId = userGoodActivity.getGoodActivity().getId();
        // 更新map
        Map<Long, AbstractUserGoodActivity> userMap = userActivityMap.get(charId);
        if (null == userMap) {
            userMap = new HashMap<Long, AbstractUserGoodActivity>();
            userActivityMap.put(charId, userMap);
        }
        if (!userMap.containsKey(activityId)) {
            userMap.put(activityId, userGoodActivity);
            // 更新玩家参加的map
            List<AbstractUserGoodActivity> userActivityList = userJoinActivityMap.get(activityId);
            if (null == userActivityList) {
                userActivityList = new ArrayList<AbstractUserGoodActivity>();
                userJoinActivityMap.put(activityId, userActivityList);
            }
            userActivityList.add(userGoodActivity);
        }
    }

    /**
     * 清除所有参加活动的玩家数据，周期结算奖励时调用
     *
     * @param activity
     */
    public void clearAllJoinedUserData(AbstractGoodActivity activity) {
        long activityId = activity.getId();
        List<AbstractUserGoodActivity> userActivityList = getJoinActivityUserList(activityId);
        if (null != userActivityList && !userActivityList.isEmpty()) {
            for (AbstractUserGoodActivity userGoodActivity : userActivityList) {
                removeUserGoodActivity(userGoodActivity);
            }
        }
        // map中移除所有玩家
        if (userJoinActivityMap.containsKey(activityId)) {
            userJoinActivityMap.remove(activityId);
        }
    }

    /**
     * 玩家活动数据中删除指定的活动数据
     *
     * @param userGoodActivity
     */
    protected void removeUserGoodActivity(AbstractUserGoodActivity userGoodActivity) {
        long activityId = userGoodActivity.getGoodActivity().getId();
        long charId = userGoodActivity.getCharId();

        // 玩家数据软删除
        userGoodActivity.onDelete();

        // 删除map数据
        if (userActivityMap.get(charId).containsKey(activityId)) {
            userActivityMap.get(charId).remove(activityId);
        }
    }

    /**
     * 创建玩家活动数据存储对象
     *
     * @param userGoodActivity
     * @return
     */
    protected GoodActivityUserPO createGoodActivityUserPO(AbstractUserGoodActivity userGoodActivity) {
        GoodActivityUserPO userPO = new GoodActivityUserPO(userGoodActivity);
        userPO.setInDb(false);
        userPO.setDbId(Globals.getUUIDService().getNextUUID(UUIDType.GOOD_ACTIVITY_USER));

        userPO.setCharId(userGoodActivity.getCharId());
        userPO.setActivityId(userGoodActivity.getGoodActivity().getId());
        long now = Globals.getTimeService().now();
        userPO.setCreateTime(now);
        userPO.setLastUpdateTime(now);

        // 激活并存库
        userPO.active();
        userPO.setModified();
        return userPO;
    }

    /**
     * 当玩家做一些事情的时候【玩家级事件】，可能对活动数据产生影响
     *
     * @param human
     * @param event
     */
    public void onPlayerDoSth(Human human, Event<?> event) {
        // 功能是否开启
        if (!Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.GOOD_ACTIVITY)) {
            return;
        }

        long uuid = human.getUUID();
        // 获取对该事件敏感的活动列表
        EventType eventType = event.getType();
        Set<Long> eventActivitySet = getActivitySetByEvent(eventType);
        if (null == eventActivitySet) {
            // 当前没有对该事件敏感的活动，直接返回
            return;
        }
        
        boolean funcFlag = false;
        for (Long activityId : eventActivitySet) {
            AbstractGoodActivity activity = getGoodActivity(activityId);
            if (activity == null) {
            	continue;
            }
            // 活动已关闭，不再处理
            if (!activity.isOpening()) {
                continue;
            }
            // 玩家能否加入活动，如果不属于活动服务器Ids则不能参加
            if (!activity.canUserJoin(uuid)) {
                continue;
            }

            AbstractUserGoodActivity userGoodActivity = getUserActivity(uuid, activityId);
            if (null == userGoodActivity) {
                // 创建玩家活动数据
                userGoodActivity = buildUserGoodActivity(uuid, activity);
            }

            // 更新玩家活动数据
            AbstractGoodActivityUserDataModel userDataModel = userGoodActivity.getUserDataModel();
            if (userDataModel.isCareEvent(event)) {
                boolean updateFlag = userDataModel.onPlayerDoEvent(event);
                if (updateFlag) {
                    // 加入map并创建存储对象
                    onUserJoinActivity(userGoodActivity);
                    // 存库
                    userGoodActivity.getUserDataModel().save();
                    //功能按钮
                    funcFlag = true;
                }
            }
        }
        
        if (funcFlag) {
        	// 功能按钮变化
            Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GOOD_ACTIVITY);
        }
    }
    
    /**
     * 完成精彩活动的目标finishTargetId时，会影响以finishTargetId为前置的目标，可能会变为可完成状态
     * @param roleId
     * @param goodActivityId
     * @param finishTargetId
     */
    public void onFinishTarget(long roleId, long goodActivityId, int finishTargetId) {
    	if (roleId == 0 || finishTargetId == 0) {
    		return;
    	}
    	if (getUserActivityMap(roleId) == null || getUserActivityMap(roleId).isEmpty()) {
    		return;
    	}
    	
    	boolean funcFlag = false;
    	Set<Long> activityIdSet = getUserActivityMap(roleId).keySet();
        for (Long activityId : activityIdSet) {
            AbstractGoodActivity activity = getGoodActivity(activityId);
            if (activity == null) {
            	continue;
            }
            //不是活动的前置目标中的数据，跳过
            if (!activity.isPreTargetId(finishTargetId)) {
            	continue;
            }
            // 活动已关闭，不再处理
            if (!activity.isOpening()) {
                continue;
            }
            // 玩家能否加入活动，如果不属于活动服务器Ids则不能参加
            if (!activity.canUserJoin(roleId)) {
                continue;
            }

            //玩家活动数据
            AbstractUserGoodActivity userGoodActivity = getUserActivity(roleId, activityId);
            if (null == userGoodActivity) {
                continue;
            }
            AbstractGoodActivityUserDataModel userDataModel = userGoodActivity.getUserDataModel();
            if (userDataModel == null) {
            	continue;
            }
            
            boolean updateFlag = userDataModel.checkOnFinishTarget(activityId, finishTargetId);
            if (updateFlag) {
            	funcFlag = true;
            }
        }
    	
        if (funcFlag) {
        	// 功能按钮变化
        	if (Globals.getTeamService().isPlayerOnline(roleId)) {
        		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
        		Globals.getFuncService().onFuncChanged(player.getHuman(), FuncTypeEnum.GOOD_ACTIVITY);
        	}
        }
    }

    /**
     * 领取活动奖励
     *
     * @param human
     * @param activityId
     * @param targetId
     */
    public void giveBonus(Human human, long activityId, int targetId) {
        long charId = human.getUUID();
        AbstractUserGoodActivity userActivity = getUserActivity(charId, activityId);
        if (null == userActivity) {
            return;
        }

        AbstractGoodActivity activity = userActivity.getGoodActivity();
        if (activity == null || !activity.isOpening()) {
            // 活动已关闭
            return;
        }
        //目标非法
        if (activity.getTargetUnit(targetId) == null) {
        	return;
        }
        
        if (!activity.canGiveBonus(userActivity, targetId, false, human, true)) {
            // 未满足领取奖励的条件，不能领奖
            return;
        }

        boolean flag = userActivity.getGoodActivity().giveBonus(userActivity, targetId, false, human);
        if (!flag) {
            // 记录错误日志
            Loggers.goodActivityLogger.error("#GoodActivityService#giveBonus#return false!charId=" +
                    charId + ";activityId=" + activityId + ";bonusIndex=" + targetId);
        }

        // 给玩家发活动更新消息
        human.sendMessage(GoodActivityMsgBuilder.buildGCGoodActivityUpdate(activity.getGoodActivityType().getFuncType(), buildGoodActivityInfo(human, activity)));

        // 功能按钮变化
        Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GOOD_ACTIVITY);

        // 记录日志
        Globals.getLogService().sendGoodActivityLog(human, GoodActivityLogReason.GIVE_BONUS, "", activityId,
                activity.getTplId(), 0, targetId);
    }

    /**
     * 心跳中调用的定时检查活动开启、关闭及周期结算奖励的方法
     */
    public void checkActivity() {
        // 检查活动是否需要开始或结束
        long now = Globals.getTimeService().now();
        List<AbstractGoodActivity> closedSet = new ArrayList<AbstractGoodActivity>();
        for (AbstractGoodActivity activity : getAllActivityMap().values()) {
            try {
                // 活动是否有效
                if (!activity.getGoodActivityPO().isAvailable()) {
                    // 无效活动，需要保留在map中，不做删除处理
                    continue;
                }
                // 已关闭的活动，清除
                if (activity.getGoodActivityPO().getIsClosed() > 0 ||
                        activity.getGoodActivityPO().isForceEnd()) {
                    closedSet.add(activity);
                    continue;
                }

                // 时间到了，活动结束
                if (activity.getEndTime() <= now) {
                    // 活动结束时，活动自身的相关处理
                    activity.onActivityEnd();
                    closedSet.add(activity);
                    continue;
                }

                // 时间到了，活动还未开始，则开始活动
                if (!activity.isStarted() && activity.getStartTime() <= now) {
                    activity.onActivityStart();
                    continue;
                }

                // 活动已开始，则进行活动刷新检测
                if (activity.isStarted()) {
                    activity.checkGiveUnGotRewardPeriod();
                    continue;
                }

            } catch (Exception e) {
                e.printStackTrace();
                Loggers.goodActivityLogger.error("#GoodActivityService#checkActivity#ERROR!e=" + e.getMessage() +
                        ";activityId=" + activity.getId());
            }
        }

        // map中删除已关闭的活动
        for (AbstractGoodActivity activity : closedSet) {
            clearFromMapOnActivityEnd(activity, "checkActivity");
        }
    }

    /**
     * 创建一个活动，并存库放入map
     *
     * @param goodActivityTplId 活动模板Id
     * @param startTime         活动开始时间
     * @param endTime           活动结束时间
     * @param isAvailable       是否生效
     * @return
     */
    public AbstractGoodActivity createActivity(int goodActivityTplId, long startTime, long endTime, boolean isAvailable,
                                               String name, String desc, int nameIcon, int titleIcon, Set<Integer> serverIdSet) {
        GoodActivityBaseTemplate activityTpl = Globals.getTemplateCacheService().get(goodActivityTplId, GoodActivityBaseTemplate.class);
        if (null == activityTpl) {
            Loggers.goodActivityLogger.error("#GoodActivityService#createActivity#activityTpl not exist!goodActivityTplId=" + goodActivityTplId);
            return null;
        }
        long now = Globals.getTimeService().now();
        if (startTime <= 0 || endTime <= now || endTime <= startTime) {
            Loggers.goodActivityLogger.error("#GoodActivityService#createActivity#startTime or endTime is invalid!goodActivityTplId=" +
                    goodActivityTplId + ";startTime=" + startTime + ";endTime=" + endTime);
            return null;
        }
        // 服务器serverIds为所有的合服id，如果不在这里面则视为非法
        Set<Integer> validServerIdSet = Globals.getServerIdSet();
        // serverId校验
        if (serverIdSet == null || serverIdSet.isEmpty()) {
            Loggers.goodActivityLogger.error("#GoodActivityService#createActivity#serverIdSet is invalid!goodActivityTplId=" + goodActivityTplId);
            return null;
        }
        for (Integer serverId : serverIdSet) {
            // serverId有不是本服的，非法
            if (!validServerIdSet.contains(serverId)) {
                // 记录错误日志，含有非法的serverId
                Loggers.goodActivityLogger.error("#GoodActivityService#createActivity#serverIdSet is invalid!goodActivityTplId=" +
                        goodActivityTplId + ";startTime=" + startTime + ";endTime=" + endTime + ";serverIdSet=" + serverIdSet + ";validServerIdSet=" + validServerIdSet);
                return null;
            }
        }

        if (null == name || name.equalsIgnoreCase("")) {
            // 如果传过来的名称为空则使用配置表的数据
            name = activityTpl.getName();
            Loggers.goodActivityLogger.warn("#GoodActivityService#createActivity#name or desc invalid!goodActivityTplId=" +
                    goodActivityTplId + ";name=" + name + ";desc=" + desc);
        }
        if (null == desc || desc.equalsIgnoreCase("")) {
            // 如果传过来的描述为空则使用配置表的数据
            desc = activityTpl.getDesc();
            Loggers.goodActivityLogger.warn("#GoodActivityService#createActivity#name or desc invalid!goodActivityTplId=" +
                    goodActivityTplId + ";name=" + name + ";desc=" + desc);
        }

        // 创建活动对象
        GoodActivityPO goodActivityPO = createGoodActivityPO(activityTpl, startTime, endTime, isAvailable,
                name, desc, nameIcon, titleIcon, serverIdSet);
        AbstractGoodActivity activity = buildGoodActivity(activityTpl.getActivityType(), goodActivityPO);
        // 加入map中
        addActivity(activity);

        Loggers.goodActivityLogger.info("#GoodActivityService#createActivity#ok.goodActivityTplId=" +
                goodActivityTplId + ";Id=" + goodActivityPO.getId());
        return activity;
    }

    /**
     * 更新活动是否生效的状态
     *
     * @param activityId
     * @param isAvailable
     * @return
     */
    public boolean updateActivityAvailableState(long activityId, boolean isAvailable) {
        AbstractGoodActivity activity = getGoodActivity(activityId);
        if (null != activity && null != activity.getGoodActivityPO()) {
            if (activity.getGoodActivityPO().isAvailable() != isAvailable) {
                activity.getGoodActivityPO().setIsAvailable(
                        isAvailable ? GoodActivityStatus.OPENED.getIndex() : GoodActivityStatus.CLOSED.getIndex());
                return true;
            }
        }
        return false;
    }

    /**
     * gm命令调用的关闭活动，测试用
     *
     * @param activityId
     * @return
     */
    public boolean gmClose(long activityId) {
        AbstractGoodActivity activity = getGoodActivity(activityId);
        if (null != activity &&
                null != activity.getGoodActivityPO() &&
                activity.getGoodActivityPO().getIsClosed() == GoodActivityStatus.CLOSED.getIndex()) {
            activity.onActivityEnd();
            activity.getGoodActivityPO().setModified();

            Loggers.goodActivityLogger.warn("#GoodActivityService#gmClose#activity is closed!activityId=" + activity.getId());
            return true;
        }
        return false;
    }

    /**
     * gm正常结束所有正在进行的活动，并结算奖励
     */
    public void gmCloseAllActivity() {
        // 结束所有正在进行中的活动
        for (AbstractGoodActivity activity : getAllActivityMap().values()) {
            gmClose(activity.getId());
        }
        // 记录日志
        Loggers.goodActivityLogger.warn("#GoodActivityService#gmCloseAllActivity#end");
    }

    /**
     * gm创建或更新活动
     * 注：已存在的活动只有当前为【不可用】且【未关闭】时，才可以修改，其他状态的活动不能修改
     *
     * @param activityStr
     * @return
     */
    public AbstractGoodActivity gmCreateOrUpdateGoodActivity(String activityStr) {
        // 解析json
        JSONObject json = JSONObject.fromObject(activityStr);
        long id = JsonUtils.getLong(json, GoodActivityDef.GOOD_ACTIVITY_ID_KEY);
        int tplId = JsonUtils.getInt(json, GoodActivityDef.GOOD_ACTIVITY_ACTIVITY_TPL_ID_KEY);
        int isAvailableInt = JsonUtils.getInt(json, GoodActivityDef.GOOD_ACTIVITY_USEABLE_KEY);
        long startTime = JsonUtils.getLong(json, GoodActivityDef.GOOD_ACTIVITY_START_TIME_KEY);
        long endTime = JsonUtils.getLong(json, GoodActivityDef.GOOD_ACTIVITY_END_TIME_KEY);
        String name = JsonUtils.getString(json, GoodActivityDef.GOOD_ACTIVITY_NAME_KEY);
        String desc = JsonUtils.getString(json, GoodActivityDef.GOOD_ACTIVITY_DESC_KEY);
        int nameIcon = JsonUtils.getInt(json, GoodActivityDef.GOOD_ACTIVITY_NAME_ICON_KEY);
        int titleIcon = JsonUtils.getInt(json, GoodActivityDef.GOOD_ACTIVITY_TITLE_ICON_KEY);

        boolean isAvailable = isAvailableInt > 0 ? true : false;
        AbstractGoodActivity activity = getGoodActivity(id);
        if (id > 0 && activity != null) {
            GoodActivityPO activityPO = activity.getGoodActivityPO();
            // 更新，只有当前为不可用，且未关闭的活动，才可以修改，其他状态的活动不能修改
            if (!activityPO.isAvailable() &&
                    activityPO.getIsClosed() == 0) {
                activityPO.setActivityTplId(tplId);
                activityPO.setIsAvailable(isAvailable ? GoodActivityStatus.OPENED.getIndex() : GoodActivityStatus.CLOSED.getIndex());
                activityPO.setStartTime(startTime);
                activityPO.setNameIcon(nameIcon);
                activityPO.setTitleIcon(titleIcon);
                // 初始的最后一次刷新时间为开始时间
                activityPO.setLastRefreshTime(startTime);
                activityPO.setEndTime(endTime);
                activityPO.setModified();
            } else {
                // 非法修改，记录错误日志
                Loggers.goodActivityLogger.error("#GoodActivityService#gmCreateOrUpdateGoodActivity#current state can not update!Id=" +
                        activity.getId() + ";isAvailable=" + activity.getGoodActivityPO().isAvailable() + ";isClosed=" +
                        activity.getGoodActivityPO().getIsClosed());
            }
        } else {
            // 获取当前服务器的serverIds
            Set<Integer> serverIdSet = Globals.getServerIdSet();
            // 创建
            activity = createActivity(tplId, startTime, endTime, isAvailable, name, desc, nameIcon, titleIcon, serverIdSet);
        }
        return activity;
    }

    /**
     * gm设置活动为可用状态
     *
     * @param activityStr
     * @return
     */
    public boolean gmGoodActivityAvailable(String activityStr) {
        boolean flag = false;
        // 解析json
        JSONObject json = JSONObject.fromObject(activityStr);
        long id = JsonUtils.getLong(json, GoodActivityDef.GOOD_ACTIVITY_ID_KEY);

        AbstractGoodActivity activity = getGoodActivity(id);
        if (id > 0 && activity != null) {
            GoodActivityPO activityPO = activity.getGoodActivityPO();
            // 更新，只有当前为不可用，且未关闭的活动，才可以修改，其他状态的活动不能修改
            if (!activityPO.isAvailable() &&
                    activityPO.getIsClosed() == GoodActivityStatus.CLOSED.getIndex()) {
                activityPO.setIsAvailable(GoodActivityStatus.OPENED.getIndex());
                activityPO.setModified();
            } else {
                // 非法修改，记录错误日志
                Loggers.goodActivityLogger.error("#GoodActivityService#gmGoodActivityAvailable#current state can not update!Id=" +
                        activity.getId() + ";isAvailable=" + activity.getGoodActivityPO().isAvailable() + ";isClosed=" +
                        activity.getGoodActivityPO().getIsClosed());
            }
        } else {
            // 非法修改，记录错误日志
            Loggers.goodActivityLogger.error("#GoodActivityService#gmGoodActivityAvailable#activity not exist!id=" + id);
        }

        return flag;
    }

    /**
     * 强制关闭活动
     * 注：不做活动正常结束的处理
     *
     * @param activityStr
     * @return
     */
    public boolean gmGoodActivityForceEnd(String activityStr) {
        boolean flag = false;
        // 解析json
        JSONObject json = JSONObject.fromObject(activityStr);
        long id = JsonUtils.getLong(json, GoodActivityDef.GOOD_ACTIVITY_ID_KEY);

        AbstractGoodActivity activity = getGoodActivity(id);
        if (id > 0 && activity != null) {
            long now = Globals.getTimeService().now();
            GoodActivityPO activityPO = activity.getGoodActivityPO();
            // 强制关闭，如果活动是非关闭状态，则可以关闭
            if (activityPO.getIsClosed() == GoodActivityStatus.CLOSED.getIndex()) {
                activityPO.setCloseTime(now);
                activityPO.setIsForceEnd(GoodActivityStatus.OPENED.getIndex());
                activityPO.setIsClosed(GoodActivityStatus.OPENED.getIndex());
                activityPO.setModified();
                // 从map中移除数据
                clearFromMapOnActivityEnd(activity, "gmGoodActivityForceEnd");
                // 记录日志
                Loggers.goodActivityLogger.warn("#GoodActivityService#gmGoodActivityForceEnd#activity is force end!id=" + id);
            } else {
                // 非法修改，记录错误日志
                Loggers.goodActivityLogger.error("#GoodActivityService#gmGoodActivityForceEnd#activity is not opened,not need force end!Id=" +
                        activity.getId() + ";isAvailable=" + activity.getGoodActivityPO().isAvailable() + ";isClosed=" +
                        activity.getGoodActivityPO().getIsClosed());
            }
        } else {
            // 非法修改，记录错误日志
            Loggers.goodActivityLogger.error("#GoodActivityService#gmGoodActivityForceEnd#activity not exist!id=" + id);
        }
        return flag;
    }

    /**
     * gm刷新周期性领奖活动的时间，这样程序会自动走活动结算和刷新{@link AbstractGoodActivity#checkGiveUnGotRewardPeriod}
     * 即玩家之前的活动数据会结算，重新计数。
     */
    public void gmRefreshAllPeriodActivity() {
        for (AbstractGoodActivity activity : getAllActivityMap().values()) {
            if (activity.needGiveUnGotRewardPeriod()) {
                activity.updateLastRefreshTime(Globals.getTimeService().now() - TimeUtils.DAY);
            }
        }
    }

    /**
     * 创建一个活动对象
     *
     * @param activityType
     * @param goodActivityPO
     * @return
     */
    protected AbstractGoodActivity buildGoodActivity(GoodActivityType activityType, GoodActivityPO goodActivityPO) {
        AbstractGoodActivity activity = null;
        // XXX 根据不同活动类型创建活动对象
        switch (activityType) {
            case NORMAL_TOTAL_CHARGE:
                activity = new NormalTotalChargeActivity(goodActivityPO);
                break;
            case DAY_TOTAL_CHARGE:
                activity = new DayTotalChargeActivity(goodActivityPO);
                break;
            case LEVEL_UP:
                activity = new LevelUpActivity(goodActivityPO);
                break;
            case TOTAL_COST:
                activity = new TotalCostActivity(goodActivityPO);
                break;
            case EVERY_COST:
                activity = new EveryCostActivity(goodActivityPO);
                break;
            case SEVEN_LOGIN:
                activity = new SevenDayLoginActivity(goodActivityPO);
                break;
            case VIP_LEVEL:
    			activity = new VipLevelActivity(goodActivityPO);
    			break;
            case BUY_MONEY:
            	activity = new BuyMoneyActivity(goodActivityPO);
            	break;
            case LEVEL_MONEY:
            	activity = new LevelMoneyActivity(goodActivityPO);
            	break;
			case TOTAL_CHARGE_BUY:
				activity = new TotalChargeBuyActivity(goodActivityPO);
				break;
				
			default:
				break;
        }

        // 加入事件map
        addActivityToEventMap(activity);
        return activity;
    }

    /**
     * 创建一个活动存储对象
     *
     * @param activityTpl
     * @param startTime
     * @param endTime
     * @return
     */
    protected GoodActivityPO createGoodActivityPO(GoodActivityBaseTemplate activityTpl,
                                                  long startTime, long endTime, boolean isAvailable, String name, String desc, int nameIcon, int titleIcon,
                                                  Set<Integer> serverIdSet) {
        GoodActivityPO activityPO = new GoodActivityPO();
        activityPO.setInDb(false);
        activityPO.setId(Globals.getUUIDService().getNextUUID(UUIDType.GOOD_ACTIVITY));
        // 设置活动模板Id
        activityPO.setActivityTplId(activityTpl.getId());
        // 设置活动类型
        activityPO.setActivityType(activityTpl.getGoodActivityType());
        // 设置活动时间
        activityPO.setStartTime(startTime);
        activityPO.setEndTime(endTime);
        // 初始的最后一次刷新时间为开始时间
        activityPO.setLastRefreshTime(startTime);
        // 设置活动是否生效
        activityPO.setIsAvailable(isAvailable ? GoodActivityStatus.OPENED.getIndex() : GoodActivityStatus.CLOSED.getIndex());
        activityPO.setActivityName(name);
        activityPO.setActivityDesc(desc);
        activityPO.setNameIcon(nameIcon);
        activityPO.setTitleIcon(titleIcon);
        // 设置服务器Ids
        activityPO.setServerIdSet(serverIdSet);

        // 激活并存库
        activityPO.active();
        activityPO.setModified();

        return activityPO;
    }

    /**
     * 当前一些【活动级的事件】触发时的处理
     *
     * @param event
     */
    public void onTriggerEvent(Event<?> event) {
        EventType eventType = event.getType();
        Set<Long> eventActivitySet = getActivitySetByEvent(eventType);
        if (null == eventActivitySet) {
            // 当前没有对该事件敏感的活动，直接返回
            return;
        }
        for (Long activityId : eventActivitySet) {
            AbstractGoodActivity activity = getGoodActivity(activityId);
            // 活动已关闭，不再处理
            if (!activity.isOpening()) {
                continue;
            }

            activity.onTriggerEvent(event);
        }
    }

    /**
     * 玩家所有活动中是否有可领取的奖励
     *
     * @param human
     * @return
     */
    public boolean hasBonus(Human human, FuncTypeEnum func) {
    	//这里将精彩活动func拆开成两个，按不同的活动属于不同的func通知前台，因为新增加的精彩活动和原来奖励里面的不能是一个func
    	//已经修改了FuncService的onFuncChanged方法，进行了联动调用
        boolean flag = false;
        long charId = human.getUUID();
        Map<Long, AbstractUserGoodActivity> userMap = getUserActivityMap(charId);
        if (null != userMap && !userMap.isEmpty()) {
            for (AbstractUserGoodActivity userActivity : userMap.values()) {
            	//对应的功能id
            	if (userActivity.getGoodActivity().getGoodActivityType().getFuncType() == func) {
	                if (userActivity.getUserDataModel() != null &&
	                		userActivity.getGoodActivity().canUserJoin(charId)) {
	                    flag |= userActivity.getUserDataModel().hasBonus();
	                    if (flag) {
	                        break;
	                    }
	                }
            	}
            }
        }
        return flag;
    }


}
