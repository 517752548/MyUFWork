package com.imop.lj.gameserver.timelimit;

import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.google.common.collect.Lists;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

public class TimeLimitService implements InitializeRequired {

	/** 参加限时活动的玩家Id集合*/
	protected Set<Long> playerIdSet = new HashSet<Long>();
	
	public void addPlayIdSet(long id){
		this.playerIdSet.add(id);
	} 
	
	public void removePlayId(long id){
		this.playerIdSet.remove(id);
	}
	
	public int playerIdNum(){
		return this.playerIdSet.size();
	}
	
	public Set<Long> getPlayerIdSet(){
		return this.playerIdSet;
	}
	
	@Override
	public void init() {
		
	}
	
	/** 整点时间的仙缘活动,给一定比例的玩家推送随机活动*/
	public void randomPush(String source){
		List<Long> allPlayerIdList = Lists.newArrayList();
		Collection<Long> onlinePlayerIdList = Globals.getOnlinePlayerService().getAllOnlinePlayerRoleUUIDs();
		//线上没有玩家
		if(onlinePlayerIdList.isEmpty()){
			return;
		}
		allPlayerIdList.addAll(onlinePlayerIdList);
		//取一定比例的玩家数量
		int randomPlayerNum = (int) (allPlayerIdList.size() * Globals.getGameConstants().getTimeLimitPushPlayerProb());
		//返回随机人数是等于0,但明明有1个人的情况
		if(randomPlayerNum < 1){
			randomPlayerNum = 1;
		}
		
		//是否超过最大值
		if(randomPlayerNum > Globals.getGameConstants().getTimeLimitPushPlayerMaxNum()){
			randomPlayerNum = Globals.getGameConstants().getTimeLimitPushPlayerMaxNum();
		}
		List<Long> timeLimitPlayerIdLst = RandomUtils.hitObjects(allPlayerIdList, randomPlayerNum);
		//遍历随机玩家
		for (Long playerId : timeLimitPlayerIdLst) {
			Player player = Globals.getOnlinePlayerService().getPlayer(playerId);
			if (player == null || player.getHuman() == null || !player.isInScene()) {
				continue;
			}
			
			//玩家最少20级
			Human human = player.getHuman();
			if(human.getLevel() < Globals.getGameConstants().getTimeLimitMinLevel()){
				continue;
			}
			//随机出来活动,推送
			int pushType = randTimeLimitActId(human.getLevel());
			if(pushType == 0 || human.getTimeLimitManager() == null){
				continue;
			}
			boolean pushFlag = pushPlayerTimeLimitAct(human, pushType);
			if(!pushFlag){
				continue;
			}
			
			//加入集合
			addPlayIdSet(playerId);
		}
		
		Loggers.timeLimitLogger.info("playerIdSet Num is "+playerIdNum()+";randomPush source = "+ source);
		
		// 广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getTimeLimitOpenNoticeId());
	}
	
	/**
	 * 随机出来一个限时活动类型Id
	 * @param level
	 * @return
	 */
	protected int randTimeLimitActId(int level){
		List<Integer> actIdLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitPushActIdLst(level);
		List<Integer> wtLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitPushWtLst(level);
		List<Integer> randList = RandomUtils.hitObjectsWithWeightNum(wtLst, actIdLst, 1);
		if (randList.isEmpty()) {
			return 0;
		}
		return randList.get(0);
	}
	
	protected int randTimeLimitMonsterQstId(int level){
		List<Integer> actIdLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitMonsterQstIdLst(level);
		List<Integer> wtLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitMonsterWtLst(level);
		List<Integer> randList = RandomUtils.hitObjectsWithWeightNum(wtLst, actIdLst, 1);
		if (randList.isEmpty()) {
			return 0;
		}
		return randList.get(0);
	}
	protected int randTimeLimitNpcQstId(int level){
		List<Integer> actIdLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitNpcQstIdLst(level);
		List<Integer> wtLst = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getTimeLimitNpcWtLst(level);
		List<Integer> randList = RandomUtils.hitObjectsWithWeightNum(wtLst, actIdLst, 1);
		if (randList.isEmpty()) {
			return 0;
		}
		return randList.get(0);
	}
	
	
	
	/**
	 * 推送玩家活动
	 * @param human
	 */
	protected boolean pushPlayerTimeLimitAct(Human human, int pushType){
		if(human == null 
			|| human.getTimeLimitManager() == null
			|| ActivityDef.TimeLimitType.valueOf(pushType) == null){
			return false;
		}
		human.getTimeLimitManager().setPushType(pushType);
		//答题
		if(pushType == ActivityDef.TimeLimitType.DT.getIndex()){
			human.getTimeLimitManager().setPushQuestId(0);
		}else{
			//杀怪
			if(pushType == ActivityDef.TimeLimitType.SG.getIndex()){
				human.getTimeLimitManager().setPushQuestId(randTimeLimitMonsterQstId(human.getLevel()));
			}
			//npc
			if(pushType == ActivityDef.TimeLimitType.NPC.getIndex()){
				human.getTimeLimitManager().setPushQuestId(randTimeLimitNpcQstId(human.getLevel()));
			}
		}
		human.getTimeLimitManager().setStartTime(Globals.getTimeService().now());
		human.setModified();
		
		return true;
	}

	/**
	 * 玩家登录的时候,需要检测时间是否超时
	 * @param human
	 */
	public void onPlayerLogin(Human human) {
		//玩家身上是否有限时活动
		if(human == null || human.getTimeLimitManager() == null){
			return;
		}
		if(ActivityDef.TimeLimitType.valueOf(human.getTimeLimitManager().getPushType()) == null){
			return;
		}
		//超时
		if(Globals.getTimeService().now() - human.getTimeLimitManager().getStartTime() > Globals.getGameConstants().getTimeLimitExistenceTime()){
			human.getTimeLimitManager().resetTimeLimit(human);
		} 
	}
	
}
