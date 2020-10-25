package com.imop.lj.gameserver.offlinereward;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCOfflinerewardInfo;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.offlinereward.async.SaveOfflineRewardOperation;
import com.imop.lj.gameserver.offlinereward.msg.SysSaveOfflineRewardMsg;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

public class OfflineRewardService {

	public OfflineRewardService() {
		
	}
	
	/**
	 * 给玩家发送离线奖励，如果玩家在线，会给玩家发消息通知有奖励可领取
	 * 
	 * @param uuid 玩家Id
	 * @param offlineRewardType 离线奖励类型
	 * @param reward 奖励
	 * @param props 属性，用于领取奖励时前台显示的内容
	 * @return true记录成功，false有非法的参数，存储奖励失败
	 */
	public boolean sendOfflineReward(long uuid, OfflineRewardType offlineRewardType, Reward reward, String props) {
		if (null == offlineRewardType || null == reward || reward.isNull()) {
			return false;
		}
		OfflineReward offlineReward = createOfflineReward(uuid, offlineRewardType, reward, props);
		// 如果玩家在线，则用playerDataUpdater存库，否则创建operation存库
		if (!onlineSaveReward(offlineReward, false)) {
			SaveOfflineRewardOperation saveTask = new SaveOfflineRewardOperation(offlineReward);
			Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);
		}
		return true;
	}
	
	/**
	 * 玩家领取离线奖励，并通知玩家奖励已领取
	 * @param human
	 * @param offlineRewardId
	 * @return
	 */
	public boolean giveOfflineReward(Human human, long offlineRewardId) {
		if (human == null || human.getOfflineRewardManager() == null) {
			return false;
		}
		OfflineReward offlineReward = human.getOfflineRewardManager().getOfflineRewardById(offlineRewardId);
		if (null == offlineReward) {
			// 奖励不存在或已经领取过了
			return false;
		}
		
		// 得到奖励
		Reward reward = offlineReward.getReward();
		
		// 删除奖励，内部给玩家发消息通知奖励没了
		human.getOfflineRewardManager().deleteOfflineReward(offlineReward, false);
		
		// 给奖励
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		if (!flag) {
			Loggers.offlineRewardLogger.error("#OfflineRewardService#giveOfflineReward#giveReward return false!offlineReward=" + 
					offlineReward + ";rewardUUID=" + reward.getUuid());
			return false;
		}
		// 玩家获得离线奖励后的事件监听
		onGiveOfflineReward(human, reward);
		
		return true;
	}
	
	/**
	 * 登录时给玩家自动领取类型的奖励
	 * @param human
	 * @return
	 */
	public boolean giveAutoSendOfflineReward(Human human) {
		if (human == null || human.getPlayer() == null || 
				!human.getPlayer().isInScene() || human.getOfflineRewardManager() == null) {
			// 记录错误日志
			Loggers.offlineRewardLogger.error("#OfflineRewardService#giveAutoSendOfflineReward#param is invalid!humanId=" + 
					(human != null ? human.getUUID() : 0));
			return false;
		}
		
		// 将需要自动给类型的奖励发给玩家
		for (OfflineRewardType type : OfflineRewardType.values()) {
			if (!type.isAutoSend()) {
				continue;
			}
			List<OfflineReward> offlineRewardList = human.getOfflineRewardManager().getOfflineRewardListByType(type);
			if (null != offlineRewardList && !offlineRewardList.isEmpty()) {
				Map<RewardReasonType, List<Reward>> rewardMap = new HashMap<RewardReasonType, List<Reward>>();
				//遍历奖励，相同的合并
				Iterator<OfflineReward> it = offlineRewardList.iterator();
				for (;it.hasNext();) {
					OfflineReward offlineReward = it.next();
					// 迭代器删除
					it.remove();
					// 删除奖励
					human.getOfflineRewardManager().deleteOfflineReward(offlineReward, false);
					
					Reward reward = offlineReward.getReward();
					//非法数据，不应该出现
					if (reward.getReasonType() == null || reward.getReasonType() == RewardReasonType.NULL_REWARD) {
						Loggers.offlineRewardLogger.error("#OfflineRewardService#giveAutoSendOfflineReward#giveReward return false!offlineReward=" + 
								offlineReward + ";rewardUUID=" + reward.getUuid());
						continue;
					}
					//放到同一list里面
					List<Reward> lst = rewardMap.get(reward.getReasonType());
					if (lst == null) {
						lst = new ArrayList<Reward>();
						rewardMap.put(reward.getReasonType(), lst);
					}
					lst.add(reward);
				}
				
				//合并奖励，然后给一次
				for (List<Reward> lt : rewardMap.values()) {
					Reward mergeReward = Globals.getRewardService().mergeReward(lt);
					// 给奖励
					boolean flag = Globals.getRewardService().giveReward(human, mergeReward, false);
					if (!flag) {
						Loggers.offlineRewardLogger.error("#OfflineRewardService#giveAutoSendOfflineReward#giveReward return false!rewardType=" + 
								mergeReward.getReasonType() + ";rewardUUID=" + mergeReward.getUuid());
						return false;
					}
					
					// 玩家获得离线奖励后的事件监听
					onGiveOfflineReward(human, mergeReward);
				}
			}
		}
		return true;
	}
	
	/**
	 * 玩家获得离线奖励后的事件监听
	 * @param human
	 * @param reward
	 */
	protected void onGiveOfflineReward(Human human, Reward reward) {
//		switch (reward.getReasonType()) {
//		// 斗地主获取经验事件监听
//		case LANDLORD_SLAVER_EXP:
//			int exp = reward.getRewardExp();
//			Globals.getEventService().fireEvent(new LandlordGetExpEvent(human, exp));
//			break;
//
//		default:
//			break;
//		}
	}
	
	/**
	 * 创建离线奖励
	 * @param uuid
	 * @param offlineRewardType
	 * @param reward
	 * @param props
	 * @return
	 */
	protected OfflineReward createOfflineReward(long uuid, OfflineRewardType offlineRewardType, Reward reward, String props) {
		OfflineReward offlineReward = OfflineReward.newDeactivedInstanceWithoutOwner();
		offlineReward.setCharId(uuid);
		offlineReward.setOfflineRewardType(offlineRewardType);
		offlineReward.setReward(reward);
		if (props != null) {
			offlineReward.setProps(props);
		}
		return offlineReward;
	}
	
	/**
	 * 如果玩家在线，则用playerDataUpdater存库，并更新内存数据
	 * @param mailInstance
	 * @return
	 */
	public boolean onlineSaveReward(OfflineReward offlineReward, boolean hasSaved) {
		long ownerId = offlineReward.getCharId();
		Player player = Globals.getOnlinePlayerService().getPlayer(ownerId);
		if (player != null && player.getHuman() != null && player.getHuman().getOfflineRewardManager() != null) {
			// 如果还未存库，玩家必须在场景中，才能保证能存储成功
			if (hasSaved || (!hasSaved && player.isInScene())) {
				offlineReward.setOwner(player.getHuman());
				SysSaveOfflineRewardMsg saveMsg = new SysSaveOfflineRewardMsg(offlineReward);
				player.putMessage(saveMsg);
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 添加一个offlineReward数据的方法，仅在{@link SysSaveOfflineRewardMsg}消息中调用的
	 * @param offlineReward
	 */
	public void addSaveOfflineReward(OfflineReward offlineReward) {
		if (offlineReward == null || offlineReward.getOwner() == null) {
			// 应该不会走到这里
			Loggers.offlineRewardLogger.error("#OfflineRewardService#addSaveOfflineReward#offlineReward or owner is null!offlineReward=" + offlineReward);
			return;
		}
		if (offlineReward.getOwner().getOfflineRewardManager() == null) {
			Loggers.mailLogger.error("#OfflineRewardService#addSaveOfflineReward#owner offlineRewardManager is null !offlineReward=" + offlineReward);
			return;
		}
		if (!offlineReward.getOwner().getPlayer().isInScene()) {
			// 如果玩家当前没在场景中，则可能该条数据没存库
			Loggers.mailLogger.error("#OfflineRewardService#addSaveOfflineReward#player is not in scene!humanId=" + 
					offlineReward.getOwner().getCharId()+";offlineRewardID=" + offlineReward.getId());
		}
		
		Human owner = offlineReward.getOwner();
		// 激活
		offlineReward.getLifeCycle().activate();
		// 存库
		offlineReward.setModified();
		// 加入内存中
		owner.getOfflineRewardManager().addOfflineReward(offlineReward, false);
		
		// 如果是自动给的奖励，则直接给了
		if (offlineReward.getOfflineRewardType().isAutoSend()) {
			giveOfflineReward(owner, offlineReward.getId());
		}
	}
	
	/**
	 * 根据功能类型找到对应的离线奖励类型
	 * @param funcType
	 * @return
	 */
	protected OfflineRewardType getOfflineRewardTypeByFuncType(FuncTypeEnum funcType) {
		OfflineRewardType rewardType = null;
		switch (funcType) {
//		case BOSSWAR_SHU_REWARD:
//			rewardType = OfflineRewardType.BOSSWAR_SHU;
//			break;
//		case BOSSWAR_WEI_REWARD:
//			rewardType = OfflineRewardType.BOSSWAR_WEI;
//			break;
//		case BOSSWAR_WU_REWARD:
//			rewardType = OfflineRewardType.BOSSWAR_WU;
//			break;
//		case MONSTER_WAR_RANK_REWARD:
//			rewardType = OfflineRewardType.MONSTER_WAR_RANK_REWARD;
//			break;
//		case ESCORT_COMPLETE:
//			rewardType = OfflineRewardType.ESCORT_COMPLETE;
//			break;
//		case ESCORT_HELP_COMPLETE:
//			rewardType = OfflineRewardType.ESCORT_HELP_COMPLETE;
//			break;
		default:
			break;
		}
		return rewardType;
	}
	
	/**
	 * 显示某一类型的最近一个奖励的详细信息
	 * @param human
	 * @param funcType
	 */
	public void showOfflineRewardInfoByFunc(Human human, FuncTypeEnum funcType) {
		if (human == null || human.getOfflineRewardManager() == null) {
			return;
		}
		OfflineRewardType offlineRewardType = getOfflineRewardTypeByFuncType(funcType);
		if (null == offlineRewardType) {
			// 找不到指定功能类型对应的奖励类型
			Loggers.offlineRewardLogger.error("#OfflineRewardService#showOfflineRewardInfoByFunc#offlineRewardType is null!funcType=" + funcType);
			return;
		}
		
		List<OfflineReward> offlineRewardList = human.getOfflineRewardManager().getOfflineRewardListByType(offlineRewardType);
		if (offlineRewardList == null || offlineRewardList.isEmpty()) {
			// 没有奖励
			return;
		}
		// 获取最近的一个离线奖励
		int lastIndex = offlineRewardList.size() - 1;
		OfflineReward offlineReward = offlineRewardList.get(lastIndex);
		
		// 给玩家发离线奖励消息
		GCOfflinerewardInfo gcOfflinerewardInfo = new GCOfflinerewardInfo();
		gcOfflinerewardInfo.setOfflineRewardType(offlineRewardType.getIndex());
		gcOfflinerewardInfo.setCreateTime(TimeUtils.formatYMDTime(offlineReward.getCreateTime()));
		gcOfflinerewardInfo.setProps(offlineReward.getProps());
		gcOfflinerewardInfo.setRewardInfos(Globals.getRewardService().convertReward(offlineReward.getReward()));
		human.sendMessage(gcOfflinerewardInfo);
	}
	
	/**
	 * 玩家领取最近一个离线奖励
	 * @param human
	 * @param funcType
	 */
	public void giveLastOfflineRewardByFunc(Human human, FuncTypeEnum funcType) {
		if (human == null || human.getOfflineRewardManager() == null) {
			return;
		}
		OfflineRewardType offlineRewardType = getOfflineRewardTypeByFuncType(funcType);
		if (null == offlineRewardType) {
			// 找不到指定功能类型对应的奖励类型
			Loggers.offlineRewardLogger.error("#OfflineRewardService#showOfflineRewardInfoByFunc#offlineRewardType is null!funcType=" + funcType);
			return;
		}
		
		List<OfflineReward> offlineRewardList = human.getOfflineRewardManager().getOfflineRewardListByType(offlineRewardType);
		if (offlineRewardList == null || offlineRewardList.isEmpty()) {
			// 没有奖励
			return;
		}
		int lastIndex = offlineRewardList.size() - 1;
		OfflineReward offlineReward = offlineRewardList.get(lastIndex);
		// 给玩家最近一个离线奖励
		boolean giveFlag = giveOfflineReward(human, offlineReward.getId());
		
		// 如果需要显示详细信息面板，则给玩家发消息
		if (offlineRewardType.isShowPanel()) {
			GCOfflinerewardInfo gcOfflinerewardInfo = new GCOfflinerewardInfo();
			gcOfflinerewardInfo.setOfflineRewardType(offlineRewardType.getIndex());
			gcOfflinerewardInfo.setCreateTime(TimeUtils.formatYMDTime(offlineReward.getCreateTime()));
			gcOfflinerewardInfo.setProps(offlineReward.getProps());
			gcOfflinerewardInfo.setRewardInfos(Globals.getRewardService().convertReward(offlineReward.getReward()));
			human.sendMessage(gcOfflinerewardInfo);
		}
		
		// 记录日志
		Loggers.offlineRewardLogger.info("#OfflineRewardService#giveLastOfflineRewardByFunc#offlineRewardId=" + 
				offlineReward.getId() + ";funcType=" + funcType + ";lastIndex=" + lastIndex + ";giveFlag=" + giveFlag);
	}
	
	/**
	 * 玩家是否有指定类型的离线奖励，给功能按钮提供的接口
	 * @param human
	 * @param offlineRewardType
	 * @return
	 */
	public boolean hasOfflineRewardByFunc(Human human, FuncTypeEnum funcType) {
		if (human == null || human.getOfflineRewardManager() == null) {
			return false;
		}
		OfflineRewardType offlineRewardType = getOfflineRewardTypeByFuncType(funcType);
		if (null == offlineRewardType) {
			return false;
		}
		List<OfflineReward> offlineRewardList = human.getOfflineRewardManager().getOfflineRewardListByType(offlineRewardType);
		if (offlineRewardList == null || offlineRewardList.isEmpty()) {
			// 没有奖励
			return false;
		}
		return true;
	}
}
