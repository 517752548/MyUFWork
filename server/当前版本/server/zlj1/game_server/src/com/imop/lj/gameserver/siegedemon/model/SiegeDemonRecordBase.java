package com.imop.lj.gameserver.siegedemon.model;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.model.SiegeDemonMap;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SDMonsterType;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SiegeDemonType;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

public abstract class SiegeDemonRecordBase {
	/** 队伍Id */
	private int teamId;
	/** 副本类型 */
	protected SiegeDemonType type;
	
	/** 进入副本的时间 */
	protected long enterTime;
	
	/** 当前战斗的怪物集合,战斗完毕后会删除,key为uuid */
	protected Map<String, SiegeDemonMonster> monsterMap = Maps.newHashMap();
	/** 战胜的怪物数量 */
	protected int winMonsterNum;
	
	/** 副本地图 */
	protected SiegeDemonMap map;
	
	public SiegeDemonRecordBase() {
		map = new SiegeDemonMap();
	}
	
	protected void giveAssistReward() {
		
	}
	
	protected void exitRaid(){
		Globals.getSiegeDemonService().exitSiegeDemon(this);
	}
	
	public void noticeMonster(int npcId, SDMonsterType type){
		Team team = Globals.getTeamService().getTeam(this.getTeamId());
		if (team == null) {
			return;
		}
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		for (TeamMember tm : team.getMemberMap().values()) {
			long roleId = tm.getRoleId();
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			if (player != null && player.getHuman() != null) {
				player.sendSystemMessage(type.getLangId(), npcTpl.getName());
			}
		}
	}
	
	/**
	 * 进入副本后，流逝（过去）的时间
	 * @return
	 */
	public long getPassTimeUntilNow(){
		return Globals.getTimeService().now() - getEnterTime();
	}
	
	public int getCurMonsterNum() {
		return monsterMap.size();
	}

	public SiegeDemonMonster getMonster(String uuid) {
		return monsterMap.get(uuid);
	}
	
	public SiegeDemonType getType() {
		return type;
	}

	public void setType(SiegeDemonType type) {
		this.type = type;
	}

	public long getEnterTime() {
		return enterTime;
	}

	public void setEnterTime(long enterTime) {
		this.enterTime = enterTime;
	}

	public Map<String, SiegeDemonMonster> getMonsterMap() {
		return monsterMap;
	}

	public SiegeDemonMonster removeMonsterMap(String uuid){
		if(monsterMap.containsKey(uuid)){
			return monsterMap.remove(uuid);
		}
		return null;
	}
	public int getWinMonsterNum() {
		return winMonsterNum;
	}

	public void setWinMonsterNum(int winMonsterNum) {
		this.winMonsterNum = winMonsterNum;
	}

	public SiegeDemonMap getMap() {
		return map;
	}
	
	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}

	@Override
	public String toString() {
		return "SiegeDemonRecordBase [teamId=" + teamId + ", type=" + type + ", enterTime=" + enterTime
				+ ", monsterMap=" + monsterMap + ", winMonsterNum=" + winMonsterNum + ", map=" + map + "]";
	}

}
