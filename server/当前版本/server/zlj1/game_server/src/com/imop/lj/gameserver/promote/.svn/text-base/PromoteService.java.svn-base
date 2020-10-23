package com.imop.lj.gameserver.promote;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.promote.msg.GCPromotePanel;

/**
 * 
 *提升功能
 */
public class PromoteService implements InitializeRequired{

	/**
	 * 是否有可以提升的内容
	 * @param human
	 * @return
	 */
	public boolean canPromote(Human human){
		
		if(human == null){
			return false;
		}
		
		//角色加点
		boolean canAddPointLeader = Globals.getPetService().isNeedAddPointLeader(human);
		//宠物加点
		boolean canAddPointPet = Globals.getPetService().isNeedAddPointPet(human);
		//装备升星
		boolean canUpStr = Globals.getEquipService().isNeedUpStar(human);
		//宝石镶嵌
		boolean canPutOnGem = Globals.getEquipService().isNeedPutonGem(human);
		//心法升级
		boolean canMindLevelUpgrade = Globals.getHumanSkillService().canMindLevelUpgrade(human);
		//技能升级
		boolean canmindSkillUpgrade = Globals.getHumanSkillService().canMindSkillUpgrade(human);
		//翅膀进阶
		boolean canWingUpgrade = Globals.getWingService().isNeedUpgrade(human);
		
		//生成提升列表
		genPromoteList(human, canAddPointLeader, canAddPointPet, canUpStr, canPutOnGem, canMindLevelUpgrade,
				canmindSkillUpgrade, canWingUpgrade);
		
		return isNeedPromote(canAddPointLeader, canAddPointPet, canUpStr, canPutOnGem, canMindLevelUpgrade,
				canmindSkillUpgrade, canWingUpgrade);
	}

	/**
	 * 加入可提升的列表
	 * @param human
	 * @param canAddPointLeader
	 * @param canAddPointPet
	 * @param canUpStr
	 * @param canPutOnGem
	 * @param canMindLevelUpgrade
	 * @param canmindSkillUpgrade
	 * @param canWingUpgrade
	 */
	protected void genPromoteList(Human human, boolean canAddPointLeader, boolean canAddPointPet, boolean canUpStr,
			boolean canPutOnGem, boolean canMindLevelUpgrade, boolean canmindSkillUpgrade, boolean canWingUpgrade) {
		//每次都清空提升列表
		human.getPromoteManager().getCanPromoteSet().clear();
		
		if(canAddPointLeader){
			human.getPromoteManager().addPromoteList(PromoteID.ADD_POINT_LEADER.getIndex());
		}
		
		if(canAddPointPet){
			human.getPromoteManager().addPromoteList(PromoteID.ADD_POINT_PET.getIndex());
		}
		
		if(canUpStr){
			human.getPromoteManager().addPromoteList(PromoteID.UP_STAR.getIndex());
		}
		
		if(canPutOnGem && Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.GEM_EQUIP)){
			human.getPromoteManager().addPromoteList(PromoteID.PUT_ON_GEM.getIndex());
		}

		if(canMindLevelUpgrade && Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.MINDSKILL)){
			human.getPromoteManager().addPromoteList(PromoteID.MIND_LEVEL_UP.getIndex());
		}

		if(canmindSkillUpgrade && Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.MINDSKILL)){
			human.getPromoteManager().addPromoteList(PromoteID.MIND_SKILL_UP.getIndex());
		}

		if(canWingUpgrade && Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.WING)){
			human.getPromoteManager().addPromoteList(PromoteID.WING_UP.getIndex());
		}
		
	}

	protected boolean isNeedPromote(boolean canAddPointLeader, boolean canAddPointPet, boolean canUpStr,
			boolean canPutOnGem, boolean canMindLevelUpgrade, boolean canmindSkillUpgrade, boolean canWingUpgrade) {
		return canAddPointLeader || canAddPointPet || canUpStr || canPutOnGem || canMindLevelUpgrade || canmindSkillUpgrade || canWingUpgrade;
	}

	
	
	@Override
	public void init() {
		
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
	 * 登录,获得技能经验的时候,玩家升级,宠物升级
	 * @param human
	 */
	public void noticePromoteInfo(Human human) {
		canPromote(human);
		sendPromotePanel(human);
	}

	
}
