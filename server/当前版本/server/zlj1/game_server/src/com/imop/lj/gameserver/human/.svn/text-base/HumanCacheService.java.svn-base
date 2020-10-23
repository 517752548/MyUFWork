package com.imop.lj.gameserver.human;

import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.startup.GameServerRuntime;
import com.imop.lj.gameserver.team.TeamDef;

/**
 * Human缓存服务
 * 玩家登录过程中，如果有缓存，则将其human替换为缓存的human，保证缓存数据优先
 * 在增加、删除缓存时，都进行一次setModify存库，保证缓存的数据能存到db中
 * 增加删除都是在场景线程中，读取会在主线程中
 * 
 * @author yu.zhao
 *
 */
public class HumanCacheService {
	
	protected static boolean OPEN = true; 

	protected Map<Long, Human> humanMap = new ConcurrentHashMap<Long, Human>();
	
	public static boolean isOpen() {
		return OPEN;
	}
	
	protected void addHuman(Human human, String source) {
		humanMap.put(human.getUUID(), human);
		//进行一次存库操作
		human.updateCacheFlag();
		
		//记录日志
		Loggers.loginLogger.info("#HumanCacheService#onHumanLeaveScene#humanId=" + human.getUUID() + 
				";pid=" + (human.getPlayer() != null ? human.getPlayer().getPassportId() : "") +
				";playerState=" + (human.getPlayer() != null ? human.getPlayer().getState() : "") +
				";source=" + source);
	}
	
	protected Human delHuman(long roleId, String source) {
		Human delHuman = humanMap.remove(roleId);
		if (delHuman != null) {
			//进行一次存库操作
			delHuman.updateCacheFlag();
			delHuman.getPlayer().updateData();
			
			//记录日志
			Loggers.loginLogger.info("#HumanCacheService#delHuman#humanId=" + delHuman.getUUID() + 
					";pid=" + (delHuman.getPlayer() != null ? delHuman.getPlayer().getPassportId() : "") +
					";playerState=" + (delHuman.getPlayer() != null ? delHuman.getPlayer().getState() : "") + 
					";source=" + source);
		}
		return delHuman;
	}
	
	public boolean hasHuman(long roleId) {
		return humanMap.containsKey(roleId);
	}
	
	/**
	 * 获取缓存中的玩家，可能返回null
	 * @param roleId
	 * @return
	 */
	public Human getHuman(long roleId) {
		return humanMap.get(roleId);
	}
	
	/**
	 * 获取human，先从在线中获取，如果没有再从缓存中获取，可能返回null
	 * @param roleId
	 * @return 可能为null,这时玩家就可视为真离线了,可不进行处理了
	 */
	public Human getHumanOnlineOrCache(long roleId) {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null && player.isInScene()) {
			return player.getHuman();
		}
		return getHuman(roleId);
	}
	
	public void onHumanEnterScene(long roleId) {
		if (!OPEN) {
			return;
		}
		
		delHuman(roleId, "onHumanEnterScene");
	}
	
	public void onHumanLeaveScene(Human human) {
		if (!OPEN) {
			return;
		}
		//服务器关了，就不缓存了
		if (!GameServerRuntime.isOpen()) {
			return;
		}
		if (human == null) {
			return;
		}
		
		//设置玩家最后一次加入缓存的时间，用于定时清除玩家缓存
		human.setLastCachedTime(Globals.getTimeService().now());
		addHuman(human, "onHumanLeaveScene");
	}
	
	public void heartBeat() {
		if (!OPEN || humanMap.isEmpty()) {
			return;
		}
		
		//玩家数据更新
		for (Human human : humanMap.values()) {
			if (human.getPlayer() != null) {
				human.getPlayer().updateData();
			}
		}
	}
	
	public void checkDel() {
		if (!OPEN) {
			return;
		}

		Set<Long> delSet = new HashSet<Long>();
		long now = Globals.getTimeService().now();
		for (Human human : humanMap.values()) {
			//玩家离线超过20分钟，则清除玩家缓存
			if (human.getLastCachedTime() + TeamDef.MAX_OFFLINE_TIME < now) {
				delSet.add(human.getUUID());
			}
		}
		for (Long roleId : delSet) {
			delHumanOnTime(roleId);
		}
	}
	
	protected void delHumanOnTime(long roleId) {
		try {
			//如果在队伍中，则设置为暂离状态，这样玩家数据就不会再更新了
			Globals.getTeamService().checkTeamMemberAway(roleId);
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.loginLogger.error(e.getMessage());
		}
		//从humanMap中删除该玩家
		delHuman(roleId, "delHumanOnTime");
	}
	
	public void gmTest() {
		Human human = null;
		for (Human h : humanMap.values()) {
			human = h;
			break;
		}
		if (human == null) {
			return;
		}
		
		System.out.println("passportId=" + human.getPassportId() + ";roleId=" + human.getUUID());
		
		System.out.println(human.getBehaviorManager().getCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM));
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.ARENA_CHALLENGE_NUM);
		System.out.println(human.getBehaviorManager().getCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM));
		
		int rewardId = 1405;
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, "gmTest");
		boolean flag = Globals.getRewardService().giveReward(human, reward, true);
		System.out.println("give reward flag=" + flag);
		
		int rewardId2 = 1001;
		Reward reward2 = Globals.getRewardService().createReward(human.getUUID(), rewardId2, "gmTest");
		boolean flag2 = Globals.getRewardService().giveReward(human, reward2, true);
		System.out.println("give reward flag2=" + flag2);
		
	}
}
