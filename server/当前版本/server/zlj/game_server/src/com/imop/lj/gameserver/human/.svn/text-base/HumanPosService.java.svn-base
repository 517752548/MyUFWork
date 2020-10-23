package com.imop.lj.gameserver.human;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.map.MapPlayerInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.MapDef.ChangedType;
import com.imop.lj.gameserver.map.MapDef.DiffType;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.msg.MapMsgBuilder;
import com.imop.lj.gameserver.team.model.TeamMember;

/**
 * 玩家位置同步服务
 * @author yu.zhao
 *
 */
public class HumanPosService {
	
	/**
	 * 是否延迟发送位置信息，包括进出地图的判断也调用这里
	 * @return
	 */
	public boolean needDelayPos() {
		if (Globals.getOnlinePlayerService().getOnlinePlayerNumCache() >= SharedConstants.MapLocationNum2) {
			return true;
		}
		return false;
	}
	
	/**
	 * 根据服务器当前人数决定发送位置信息的策率
	 * @param human
	 */
	public void sendLocationInfo(Human human) {
		int count = human.getCurLocInfoListSize();
		//服务器人多时的策率
		if (needDelayPos()) {
			//取消人多的时候的条数策略，因为几乎都能走到，频率太高，只用时间的策略
			if (Globals.getTimeService().now() - human.getLastSendLocInfoTime() > SharedConstants.MapLocationTime2) {
				// 超过3秒发送
				human.sendLocationInfoAtOnce();
			}
		} else {
			//普通情况时的策率
			if (count >= SharedConstants.MapLocationCount) {
				// 超过10条消息发送
				human.sendLocationInfoAtOnce();
			} else if (Globals.getTimeService().now() - human.getLastSendLocInfoTime() > SharedConstants.MapLocationTime) {
				// 超过1秒发送
				human.sendLocationInfoAtOnce();
			}
		}
	}
	
	/**
	 * 定时刷新canSeeSet的时间间隔
	 * @return
	 */
	public int getRefreshCanSeeTimeInterval() {
		if (Globals.getOnlinePlayerService().getOnlinePlayerNumCache() >= SharedConstants.MapLocationNum2) {
			return SharedConstants.MapPlayerCanSeeRefreshTime2;
		}
		return SharedConstants.MapPlayerCanSeeRefreshTime1;
	}
	
	/**
	 * 刷新可见玩家列表
	 * 规则：
	 * curSet=之前的可见玩家列表
	 * nowSeeSet=新计算出的现在视野中的玩家列表
	 * newSet=新计算出的可见玩家列表=KeyPerson+nowSeeSet
	 * 通知前台删除的人集合=curSet-newSet（curSet中除去newSet中的后剩余的）
	 * 通知前台增加的人集合=nowSeeSet-curSet（nowSeeSet中除去curSet中的后剩余的）
	 * 
	 * @param human
	 */
	public void refreshHumanCanSee(Human human) {
		//是否到了刷新的时间点
		if (Globals.getTimeService().now() - human.getLastRefreshCanSeeTime() <= getRefreshCanSeeTimeInterval()) {
			return;
		}
		
		Set<Long> newSet = new HashSet<Long>();
		//当前的可见玩家集合
		Set<Long> curSet = new HashSet<Long>();
		curSet.addAll(human.getCanSeeSet());
		//获取关键人集合
		Set<Long> keyPersonSet = getKeyPersonOfCanSee(human);
		int canSeeMax = SharedConstants.MapPlayerCanSeeMax;
		
		//当前视野中的人集合
		Set<Long> nowSeeSet = new HashSet<Long>();
		//给前台需要新增的人集合，该集合数据是在curSet中没有，但现在可见的人（nowSeeSet-curSet），即认为当前可见的人，在之前也是可见的
		Set<Long> addSet = new HashSet<Long>();
		
		//加keyPerson
		newSet.addAll(keyPersonSet);
		
		//加附近可见
		int nearbyNum = 0;
		AbstractGameMap gameMap = Globals.getMapService().getGameMap(human.getMapId(), human.getRoleUUID());
		for (Human h : gameMap.getAllHumans()) {
			//达到可见人数上限，跳出
			if (nearbyNum >= canSeeMax) {
				break;
			}
			//排除自己
			if (h.getCharId() != human.getCharId()) {
				//自己能看到的人，加附近可见
				if (DiffType.NEAR == gameMap.getDiffType(human, human.getX(), human.getY(),	h.getX(), h.getY())) {
					nearbyNum++;
					newSet.add(h.getRoleUUID());
					nowSeeSet.add(h.getRoleUUID());
					//当前集合中没有的人，需要新增，即当前有的且可见的人，不用再增加了
					if (!curSet.contains(h.getRoleUUID())) {
						addSet.add(h.getRoleUUID());
					}
				}
			}
		}
		
		//重置玩家canSeeSet
		human.refreshCanSee(newSet);
		
		//对比curSet和newSet，构造变化数据
		List<MapPlayerInfo> changedList = new ArrayList<MapPlayerInfo>();
		
		//需要删除的旧数据，可能有不在当前屏幕内的也会删掉
		if (!curSet.isEmpty()) {
			//不在当前集合中的数据都删掉
			curSet.removeAll(newSet);
			for (Long delRoleId : curSet) {
				Human h = gameMap.getMapHuman(delRoleId);
				if (h != null) {
					changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.DELETE));
				}
			}
		}
		
		//需要新增的数据，这里从nowSeeSet改为addSet，防止重复add
		if (!addSet.isEmpty()) {
			for (Long addRoleId : addSet) {
				Human h = gameMap.getMapHuman(addRoleId);
				if (h != null) {
					changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.ADD));
				}
			}
		}
		
		//加到发送列表中，延迟发送
		human.addLocationInfoList(changedList);
	}
	
	/**
	 * 获取关键人集合，这些人是human必须关注其变化的人
	 * @param human
	 * @return
	 */
	public Set<Long> getKeyPersonOfCanSee(Human human) {
		Set<Long> kRoleSet = new HashSet<Long>();
		long roleId = human.getRoleUUID();
		//组队队友
		if (Globals.getTeamService().isInTeam(roleId)) {
			Collection<TeamMember> teamMemSet = Globals.getTeamService().getHumanTeam(roleId).getMemberMap().values();
			for (TeamMember mem : teamMemSet) {
				if (roleId != mem.getRoleId()) {
					kRoleSet.add(mem.getRoleId());
				}
			}
		}
		
		//TODO
		//结婚
		
		//师徒
		
		//军团团长
		
		//竞技场前三
		
		return kRoleSet;
	}
}
