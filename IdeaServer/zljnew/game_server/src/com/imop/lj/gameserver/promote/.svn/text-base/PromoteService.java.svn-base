package com.imop.lj.gameserver.promote;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.promote.msg.GCPromotePanel;

/**
 * 
 *提升功能
 */
public class PromoteService implements InitializeRequired{

	protected Map<PromoteID, AbstractPromoter> allPromoterMap = new HashMap<PromoteID, AbstractPromoter>();
	

	@Override
	public void init() {
		PromoteID[] ids = PromoteID.values();
		for (int i = 0; i < ids.length; i++) {
			PromoteID id = ids[i];
			allPromoterMap.put(id, id.getPromoterFactory().createPromoter());
		}
	}
	
	protected AbstractPromoter getPromoter(PromoteID promoteId) {
		return allPromoterMap.get(promoteId);
	}
	
	/**
	 * 是否有可以提升的内容
	 * @param human
	 * @return
	 */
	public boolean canPromote(Human human){
		if(human == null){
			return false;
		}
		
		return isNeedPromote(human);
	}

	protected boolean isNeedPromote(Human human) {
		boolean isNeed = false;
		
		for (PromoteID id : PromoteID.values()) {
			AbstractPromoter promoter = getPromoter(id);
			isNeed |= promoter.canPromote(human);
		}
		
		return isNeed;
	}
	
	protected void addPromoteList(Human human) {
		if(human == null){
			return ;
		}
		
		//每次都清空提升列表
		human.getPromoteManager().getCanPromoteSet().clear();
		
		for (PromoteID id : PromoteID.values()) {
			AbstractPromoter promoter = getPromoter(id);
			if(promoter.canPromote(human)){
				human.getPromoteManager().addPromoteList(id.getIndex());
			}
		}
	}

	/**
	 * 返回提升面板信息
	 * @param human
	 */
	public void sendPromotePanel(Human human) {
		human.sendMessage(createGCPromotePanel(human));
	}
	
	/**
	 * 构造提升面板信息
	 * @param human
	 * @return
	 */
	protected GCPromotePanel createGCPromotePanel(Human human){
		GCPromotePanel msg = new GCPromotePanel();
		msg.setPromoteInfo(createPromoteInfo(human));
		return msg;
	}

	/**
	 * 构造提升单元信息
	 * @param human
	 * @return
	 */
	protected PromoteInfo[] createPromoteInfo(Human human) {
		List<PromoteInfo> lst = new ArrayList<PromoteInfo>();
		for (Integer id : human.getPromoteManager().getCanPromoteSet()) {
			PromoteInfo info = new PromoteInfo();
			info.setProtmoteId(id);
			info.setCanPromote(true);
			lst.add(info);
		}
		return lst.toArray(new PromoteInfo[0]);
	}

	/**
	 * 登录,获得技能经验的时候,玩家升级,宠物升级,骑宠升级
	 * @param human
	 */
	public void noticePromoteInfo(Human human) {
		addPromoteList(human);
		sendPromotePanel(human);
	}

	
}
