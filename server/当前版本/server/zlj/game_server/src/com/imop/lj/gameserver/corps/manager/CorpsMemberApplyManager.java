package com.imop.lj.gameserver.corps.manager;

import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;

/**
 * 军团申请管理
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMemberApplyManager {
	/** 请求加入军团的成员<key:角色ID, value:成员> */
	private Map<Long, CorpsMember> applyMap = Maps.newLinkedHashMap();
	/** 请求加入军团的成员 */
	private LinkedList<CorpsMember> applyList = Lists.newLinkedList();
	/**所属军团*/
	private Corps corps;
	
	public CorpsMemberApplyManager(Corps corps){
		this.corps = corps;
	}
	/**
	 * 是否在申请列表中
	 * 
	 * @param playerId
	 * @return
	 */
	public boolean isInApplicantList(long playerId) {
		return this.applyMap.containsKey(playerId);
	}
	
	/**
	 * 获取军团成员
	 * 
	 * @param roleId
	 * @return
	 */
	public CorpsMember getApplyCorpsMemberByRoleId(long roleId) {
		return this.applyMap.get(roleId);
	}
	
	/**
	 * 添加军团申请
	 * 
	 * @param mem
	 * @return
	 */
	public boolean addApplyCorpsMember(CorpsMember mem) {
		//超出数量则删掉最先申请的
		if (this.applyMap.size() >= Globals.getGameConstants().getMaxCorpsReceiveApplyNum()) {
			CorpsMember deleteMem = applyList.removeLast();
			if(deleteMem == null){
				return false;
			}
			
			this.applyMap.remove(deleteMem.getRoleId());
			deleteMem.setModified();
		}
		
		if(this.applyMap.containsKey(mem.getRoleId())){
			return false;
		}
		
		this.applyList.add(mem);
		this.applyMap.put(mem.getRoleId(), mem);
		mem.setModified();
		return true;
	}
	
	/**
	 * 删除申请信息
	 * 
	 * @param memId
	 * @return
	 */
	public CorpsMember remove(long memId) {
		CorpsMember mem = this.applyMap.remove(memId);
		if(mem == null){
			return null;
		}
		
		this.applyList.remove(mem);
		return mem;
	}

	/**
	 * 清空所有军团申请，包括内存和数据库数据，并删除CorpsService.applyCorpsMap中的引用
	 * 
	 */
	public void clear(){
		for (CorpsMember mem : this.applyList) {
			mem.onDelete();
			// 删除玩家申请信息
			Globals.getCorpsService().deleteApplyCorpsMemberInfo(mem.getId(), this.corps.getId());
		}
		
		for (CorpsMember mem : this.applyMap.values()) {
			mem.onDelete();
			// 删除玩家申请信息
			Globals.getCorpsService().deleteApplyCorpsMemberInfo(mem.getId(), this.corps.getId());
		}
		
		this.applyList.clear();
		this.applyMap.clear();
	}
	
	/**
	 * 返回申请列表
	 * @return
	 */
	public List<CorpsMember> getCorpsMemberList(){
		return this.applyList;
	}
	
}
