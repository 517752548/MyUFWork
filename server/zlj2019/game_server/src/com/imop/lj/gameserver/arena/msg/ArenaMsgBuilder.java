package com.imop.lj.gameserver.arena.msg;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.arena.ArenaMemberInfo;
import com.imop.lj.common.model.arena.ArenaReportHistoryInfo;
import com.imop.lj.gameserver.arena.model.ArenaMember;
import com.imop.lj.gameserver.arena.model.ArenaOpponent;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnap;

public class ArenaMsgBuilder {

	/**
	 * 构建竞技场面板信息-主要
	 * @param human
	 * @param selfMember
	 * @return
	 */
	public static GCShowArenaPanelMain buildGCShowArenaPanelMain(Human human, ArenaMember selfMember) {
		GCShowArenaPanelMain msg = new GCShowArenaPanelMain();
		msg.setRank(selfMember.getRank());
		msg.setRankMax(selfMember.getRankMax());
		msg.setConWinTimes(selfMember.getConWinTimes());
		
		msg.setChallengeTimes(Globals.getArenaService().getChallengeLeftTimes(human));
		msg.setBuyChallengeTimesCost(Globals.getArenaService().calBuyChallengeTimeCost(human));
		
		msg.setCanBuyChallengeTimes(human.getBehaviorManager().canDo(BehaviorTypeEnum.BUY_ARENA) ? 1 : 0);
		
		msg.setCanChallenge(Globals.getArenaService().canChallengeForShow(human) ? 1 : 0);
		msg.setChallengeCdTime((int)Globals.getArenaService().getChallengeCdTimeForShow(human));
		
		msg.setKillCdCost(Globals.getArenaService().getKillCdCost(human));

		//对手列表
		List<ArenaMemberInfo> opInfoList = new ArrayList<ArenaMemberInfo>();
		for (ArenaOpponent ao : selfMember.getOpList()) {
			opInfoList.add(converArenaMember(human.getCharId(), ao));
		}
		msg.setArenaChallengeList(opInfoList.toArray(new ArenaMemberInfo[0]));
		return msg;
	}
	
	/**
	 * 竞技场成员对象转化为显示对象
	 * @param member
	 * @return
	 */
	protected static ArenaMemberInfo converArenaMember(long roleId, ArenaMember member) {
		ArenaMemberInfo memberInfo = new ArenaMemberInfo();
		memberInfo.setMemberId(member.getId());
		memberInfo.setRank(member.getRank());
		//从离线数据管理器中获取
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(member.getId());
		memberInfo.setName(userSnap.getName());
		memberInfo.setLevel(userSnap.getLevel());
		memberInfo.setTplId(userSnap.getHumanTplId());
		
		memberInfo.setFightPower(userSnap.getPsManager().getLeader().getFightPower());
		
		memberInfo.setCorpsId(Globals.getCorpsService().getUserCorpsId(member.getCharId()));
		memberInfo.setCorpsName(Globals.getCorpsService().getUserCorpsName(member.getCharId()));
		
		memberInfo.setIsRobot(0);
		memberInfo.setIsSelf(roleId == member.getCharId() ? 1 : 0);
		return memberInfo;
	}
	
	protected static ArenaMemberInfo converArenaMember(long roleId, ArenaOpponent ao) {
		//非机器人
		if (!ao.isRobot()) {
			return converArenaMember(roleId, Globals.getArenaService().getArenaMember(ao.getRoleId()));
		}
		
		//机器人
		ArenaMemberInfo memberInfo = new ArenaMemberInfo();
		memberInfo.setMemberId(0);
		memberInfo.setRank(ao.getRank());
		
		memberInfo.setName(ao.getName());
		memberInfo.setLevel(ao.getRobotLevel());
		memberInfo.setTplId(ao.getTplId());
		
		memberInfo.setFightPower(ao.getRobotFightPower());
		
		memberInfo.setCorpsId(0);
		memberInfo.setCorpsName("");
		
		memberInfo.setIsRobot(1);
		memberInfo.setIsSelf(0);
		return memberInfo;
	}
	
	/**
	 * 构建英雄榜玩家列表消息
	 * @param human
	 * @return
	 */
	public static GCArenaTopRankList buildGCArenaTopRankList(Human human) {
		GCArenaTopRankList gcArenaTopRankList = new GCArenaTopRankList();
		long roleId = human.getCharId();
		gcArenaTopRankList.setMyCorpsId(Globals.getCorpsService().getUserCorpsId(roleId));
		gcArenaTopRankList.setMyCorpsName(Globals.getCorpsService().getUserCorpsName(roleId));
		gcArenaTopRankList.setMyRank(Globals.getArenaService().getArenaRank(roleId));
		List<ArenaMemberInfo> topMemberInfoList = new ArrayList<ArenaMemberInfo>();
		List<ArenaMember> topMemberList = Globals.getArenaService().getTopRankMemberList();
		for (ArenaMember topMember : topMemberList) {
			topMemberInfoList.add(converArenaMember(human.getCharId(), topMember));
		}
		gcArenaTopRankList.setArenaTopMemberList(topMemberInfoList.toArray(new ArenaMemberInfo[0]));
		return gcArenaTopRankList;
	}
	
	/**
	 * 成功购买竞技场挑战次数
	 * @param times
	 * @return
	 */
	public static GCArenaBuyChallengeTime buildGCBuyChallengeTime(Human human) {
		GCArenaBuyChallengeTime msg = new GCArenaBuyChallengeTime();
		msg.setChallengeTimes(human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM));
		msg.setBuyChallengeTimesCost(Globals.getArenaService().calBuyChallengeTimeCost(human));
		return msg;
	}
	

	public static GCArenaBattleRecord buildGCArenaBattleRecord(Human human, List<ArenaReportHistoryInfo> infoList) {
		GCArenaBattleRecord msg = new GCArenaBattleRecord();
		msg.setCurTime(Globals.getTimeService().now());
		msg.setArenaReportHistoryList(infoList.toArray(new ArenaReportHistoryInfo[0]));
		return msg;
	}
	
}
