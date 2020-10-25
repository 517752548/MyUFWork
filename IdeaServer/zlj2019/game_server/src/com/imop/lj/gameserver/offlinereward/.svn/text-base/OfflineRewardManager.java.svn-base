package com.imop.lj.gameserver.offlinereward;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.HeartBeatListener;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;

public class OfflineRewardManager implements RoleDataHolder, HeartBeatListener {
	/** 离线奖励所属的玩家 */
	private final Human owner;
	
	/** 所有离线奖励 */
	private Map<Long, OfflineReward> allOfflineRewards = Maps.newHashMap();
	
	/** 按照类型索引的奖励 */
	private Map<OfflineRewardType, List<OfflineReward>> rewardsByTypeMap = Maps.newHashMap();

	/** 心跳任务处理器 */ 
	private HeartbeatTaskExecutor hbTaskExecutor;
	
	public OfflineRewardManager(Human owner) {
		this.owner = owner;
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		hbTaskExecutor.submit(new OfflineRewardExpireProcessor(this));
//		if (Globals.isQQPlatform()) {
//			hbTaskExecutor.submit(new QQScheduleCheckWS(owner));
//		}
	}
	
	/**
	 * 从db中加载所有的离线奖励
	 */
	public void load() {
		// 加载玩家所有的离线奖励
		List<OfflineRewardEntity> rewardEntityList = Globals.getDaoService().getOfflineRewardDao().getOfflineRewardsByCharId(owner.getCharId());
		if (null == rewardEntityList || rewardEntityList.isEmpty()) {
			return;
		}
		for (OfflineRewardEntity entity : rewardEntityList) {
			OfflineReward offlineReward = OfflineReward.buildFromItemEntity(entity, owner);
			if (offlineReward == null || offlineReward.getOfflineRewardType() == null || offlineReward.getReward() == null) {
				Loggers.offlineRewardLogger.error("#OfflineRewardManager#load#some params is null!humanId=" + owner.getCharId());
				continue;
			}
			// 激活
			offlineReward.getLifeCycle().activate();
			// 添加奖励数据
			addOfflineReward(offlineReward, true);
		}
	}
	
	public List<OfflineReward> getOfflineRewardListByType(OfflineRewardType type) {
		return rewardsByTypeMap.get(type);
	}
	
	public OfflineReward getOfflineRewardById(long id) {
		return allOfflineRewards.get(id);
	}
	
	/**
	 * 添加一个离线奖励
	 * @param offlineReward
	 * @param isInit
	 */
	public void addOfflineReward(OfflineReward offlineReward, boolean isInit) {
		if (offlineReward == null || offlineReward.getOfflineRewardType() == null || 
				offlineReward.getReward() == null || offlineReward.getReward().isNull()) {
			// 记录错误日志
			Loggers.offlineRewardLogger.error("#OfflineRewardManager#addOfflineReward#ERROR!offlineReward is invalid!isInit=" + 
					isInit + ";offlineReward=" + offlineReward);
			return;
		}
		
		// 该奖励已经添加过了，不能重复添加
		if (allOfflineRewards.containsKey(offlineReward.getId())) {
			return;
		}
		
		// 全部的map
		allOfflineRewards.put(offlineReward.getId(), offlineReward);
		
		// 按类型的列表
		List<OfflineReward> rewardByTypeList = rewardsByTypeMap.get(offlineReward.getOfflineRewardType());
		if (null == rewardByTypeList) {
			rewardByTypeList = new ArrayList<OfflineReward>();
			rewardsByTypeMap.put(offlineReward.getOfflineRewardType(), rewardByTypeList);
		}
		rewardByTypeList.add(offlineReward);
		
		// 奖励从无到有，非自动领取的才发消息
		if (rewardByTypeList.size() == 1 && 
				!offlineReward.getOfflineRewardType().isAutoSend()) {
			// 给前台发消息，通知玩家有未领取的离线奖励
			FuncTypeEnum funcType = offlineReward.getOfflineRewardType().getBindFuncType();
			if (null != funcType) {
				Globals.getFuncService().onFuncChanged(getOwner(), funcType);
			}
		}
		
		// 记录日志
		if (!isInit) {
			if (Loggers.offlineRewardLogger.isDebugEnabled()) {
				Loggers.offlineRewardLogger.debug("#OfflineRewardManager#addOfflineReward#offlineReward is added!offlineReward=" + offlineReward);
			}
		}
	}
	
	/**
	 * 删除一个离线奖励
	 * @param offlineReward
	 * @param isExpiredDel
	 */
	public void deleteOfflineReward(OfflineReward offlineReward, boolean isExpiredDel) {
		if (null == offlineReward || !allOfflineRewards.containsKey(offlineReward.getId())) {
			return;
		}
		
		// 删除奖励
		offlineReward.onDelete();
		
		// 从map中移除
		allOfflineRewards.remove(offlineReward.getId());
		
		// 从类型列表中移除
		OfflineRewardType offlineRewardType = offlineReward.getOfflineRewardType();
		List<OfflineReward> rewardByTypeList = rewardsByTypeMap.get(offlineRewardType);
		if (null != rewardByTypeList) {
			rewardByTypeList.remove(offlineReward);
		}
		
		// 奖励从有到无，非自动领取的才发消息
		if (rewardByTypeList.isEmpty() && 
				!offlineReward.getOfflineRewardType().isAutoSend()) {
			// 给前台发消息，通知奖励没有了，功能按钮变化
			FuncTypeEnum funcType = offlineReward.getOfflineRewardType().getBindFuncType();
			if (null != funcType) {
				Globals.getFuncService().onFuncChanged(getOwner(), funcType);
			}
		}
		
		// 记录日志
		if (isExpiredDel) {
			Loggers.offlineRewardLogger.warn("#OfflineRewardManager#deleteOfflineReward#offlineReward is expired!offlineReward=" + offlineReward);
		} else {
			if (Loggers.offlineRewardLogger.isDebugEnabled()) {
				Loggers.offlineRewardLogger.debug("#OfflineRewardManager#deleteOfflineReward#offlineReward is deleted!offlineReward=" + offlineReward);
			}
		}
	}
	
	/**
	 * 检查奖励是否已过期
	 */
	public void checkExpiredReward() {
		long now = Globals.getTimeService().now();
		List<OfflineReward> offlineRewardList = new ArrayList<OfflineReward>(allOfflineRewards.values());
		for (OfflineReward offlineReward : offlineRewardList) {
			if (offlineReward.getCreateTime() + OfflineRewardDef.OFFLINE_REWARD_EXPIRED_TIME < now) {
				deleteOfflineReward(offlineReward, true);
			}
		}
	}

	public Human getOwner() {
		return owner;
	}
	
	@Override
	public void checkAfterRoleLoad() {
		
	}

	@Override
	public void checkBeforeRoleEnter() {

	}

	@Override
	public void onHeartBeat() {
		hbTaskExecutor.onHeartBeat();
	}
}
