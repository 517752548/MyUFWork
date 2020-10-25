package com.imop.lj.gameserver.corps.manager;

import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsMemberComparator;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.player.Player;

/**
 * 军团成员管理
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMemberManager {
	/** 军团成员比较器 */
	public static CorpsMemberComparator corpsMemberComparator = new CorpsMemberComparator();

	/** 副团长排名开始 */
	public static final int VICE_CHAIRMAN_RANK_START = 1;
	/** 副团长排名 结束 */
	public static final int VICE_CHAIRMAN_RANK_END = 2;
	/** 精英排名开始 */
	public static final int ELITE_RANK_START = 3;
	/** 精英排名结束 */
	public static final int ELITE_RANK_END = 7;
	
	/** 已加入军团的成员<key:角色ID, value:成员> */
	private Map<Long, CorpsMember> corpsMemberMap = Maps.newHashMap();
	/** 已加入军团的成员列表，已排序 */
	private List<CorpsMember> corpsMemberList = Lists.newArrayList();

	/**
	 * 是否已加入此军团
	 * 
	 * @param playerId
	 * @return
	 */
	public boolean isInCorps(long playerId) {
		return this.corpsMemberMap.containsKey(playerId);
	}

	/**
	 * 获取军团成员列表
	 * 
	 * @return
	 */
	public List<CorpsMember> getCorpsMemberList() {
		return corpsMemberList;
	}

	/**
	 * 成员数量
	 * 
	 * @return
	 */
	public int size() {
		return corpsMemberMap.size();
	}

	/**
	 * 获取军团成员
	 * 
	 * @param roleId
	 * @return
	 */
	public CorpsMember getCorpsMemberByRoleId(long roleId) {
		return this.corpsMemberMap.get(roleId);
	}
	
	/**
	 * 添加军团成员
	 * 
	 * @param mem
	 * @return
	 */
	public boolean addCorpsMember(CorpsMember mem) {
		if(this.corpsMemberMap.containsKey(mem.getRoleId())){
			return false;
		}
		
		this.corpsMemberList.add(mem);
		this.corpsMemberMap.put(mem.getRoleId(), mem);
		
		return true;
	}
	
	/**
	 * 删除指定成员
	 * 
	 * @param memId
	 * @return
	 */
	public CorpsMember remove(long memId){
		CorpsMember mem = this.corpsMemberMap.remove(memId);
		if(mem == null){
			return null;
		}
		
		this.corpsMemberList.remove(mem);
		return mem;
	}
	
	/**
	 * 删除所有成员，并删除在CorpsService中的引用
	 */
	public void clear(){
		for (CorpsMember mem : corpsMemberMap.values()) {
			mem.onDelete();
			// 删除玩家军团信息
			Globals.getCorpsService().deleteJoinCorpsMemberInfo(mem.getRoleId());
		}

		for (CorpsMember mem : corpsMemberList) {
			mem.onDelete();
			// 删除玩家军团信息
			Globals.getCorpsService().deleteJoinCorpsMemberInfo(mem.getRoleId());
		}
		
		this.corpsMemberList.clear();
		this.corpsMemberList.clear();
	}
	
	/**
	 * 会员排序，并重新分配除团长以外的职位
	 * 注释掉重新分配职位
	 * 注释掉排序 现在排序在前台做
	 * @return 升职人员
	 */
	public List<CorpsMember> sortCorpsMember() {
		// 排序前职位
//		Map<Long, MemberJob> officialMap = new HashMap<Long, MemberJob>();
//		for (CorpsMember mem : this.corpsMemberList) {
//			if (mem.getJob() == MemberJob.PRESIDENT	|| mem.getJob() == MemberJob.VICE_CHAIRMAN || mem.getJob() == MemberJob.ELITE) {
//				officialMap.put(mem.getRoleId(), mem.getJob());
//			}
//		}

		// 排序
//		Collections.sort(this.corpsMemberList, corpsMemberComparator);
//
//		// 分配职位
//		for (int i = 0; i < this.corpsMemberList.size(); i++) {
//			CorpsMember corpsMem = this.corpsMemberList.get(i);
//			if (corpsMem.getJob() == MemberJob.NONE) {
//				continue;
//			}
//
//			if (i == 0) {
//				corpsMem.setJob(MemberJob.PRESIDENT);
//			} else if (i >= VICE_CHAIRMAN_RANK_START && i <= VICE_CHAIRMAN_RANK_END) {
//				corpsMem.setJob(MemberJob.VICE_CHAIRMAN);
//			} else if (i >= ELITE_RANK_START && i <= ELITE_RANK_END) {
//				corpsMem.setJob(MemberJob.ELITE);
//			} else {
//				corpsMem.setJob(MemberJob.MEMBER);
//			}
//		}
//
//		// 检查升职人员
//		List<CorpsMember> list = new ArrayList<CorpsMember>();
//		for (Entry<Long, MemberJob> entry : officialMap.entrySet()) {
//			long roleId = entry.getKey();
//			MemberJob job = entry.getValue();
//
//			CorpsMember temp = this.corpsMemberMap.get(roleId);
//			if (temp == null) {
//				continue;
//			}
//
//			if (temp.getJob().getIndex() > job.getIndex()) {
//				// 升职
//				list.add(temp);
//			}
//		}
//
//		return list;
		
		return this.corpsMemberList;
	}
	
	
	/**
	 * 广播消息
	 * 
	 * @param message
	 */
	public void broadcastMessage(IMessage message){
		for(CorpsMember mem : this.corpsMemberList){
			Player player = Globals.getOnlinePlayerService().getPlayer(mem.getRoleId());
			if(player != null){
				player.sendMessage(message);
			}
		}
	}
}
