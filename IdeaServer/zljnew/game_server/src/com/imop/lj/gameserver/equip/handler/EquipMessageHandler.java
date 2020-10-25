
package com.imop.lj.gameserver.equip.handler;


import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.msg.CGEqpCraft;
import com.imop.lj.gameserver.equip.msg.CGEqpDecompose;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSet;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSynthesis;
import com.imop.lj.gameserver.equip.msg.CGEqpGemTakedown;
import com.imop.lj.gameserver.equip.msg.CGEqpHole;
import com.imop.lj.gameserver.equip.msg.CGEqpRecast;
import com.imop.lj.gameserver.equip.msg.CGEqpUpstar;
import com.imop.lj.gameserver.equip.template.CraftEquipCostTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class EquipMessageHandler {	
	
	public EquipMessageHandler() {	
	}	
	
	
	/**
 	* 打造装备
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpCraft(Player player, CGEqpCraft cgEqpCraft) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CRAFT)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.CRAFT);
			return ;
		}
		
		if (cgEqpCraft.getCostTplId() <= 0 || cgEqpCraft.getGradeId() <= 0 || cgEqpCraft.getIsSimulate() < 0) {
			return;
		}
		int size = cgEqpCraft.getItemNumList().length;
		for (int i = 0; i < size; i++) {
			if (cgEqpCraft.getItemNumList()[i] <= 0 || cgEqpCraft.getItemNumList()[i] > Globals.getGameConstants().getItemMaxOverlapNum()) {
				return;
			}
		}
		
		if (null == Globals.getTemplateCacheService().getTemplateService().get(cgEqpCraft.getCostTplId(), CraftEquipCostTemplate.class)) {
			return;
		}
		if (null == Grade.valueOf(cgEqpCraft.getGradeId())) {
			return;
		}
		
		if (cgEqpCraft.getIsSimulate() > 0) {
			//模拟打造
			Globals.getEquipService().craftEquipSimulate(player.getHuman(), cgEqpCraft.getCostTplId(), cgEqpCraft.getItemNumList(), cgEqpCraft.getGradeId());
		} else {
			//打造装备
			Globals.getEquipService().craftEquip(player.getHuman(), cgEqpCraft.getCostTplId(), cgEqpCraft.getItemNumList(), cgEqpCraft.getGradeId());
		}
	}
	
	/**
	 * 装备位升星
	 * @param player
	 * @param cgEqpUpstar
	 */
	public void handleEqpUpstar(Player player, CGEqpUpstar cgEqpUpstar) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.UPSTAR)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.UPSTAR);
			return ;
		}
		
		if(cgEqpUpstar.getEquipPosition()<=0){
			return;
		}
		Object o = ItemDef.Position.valueOf(cgEqpUpstar.getEquipPosition());
		if (o==null||(!(o instanceof ItemDef.Position))) {
			return;
		}
		if(!ItemDef.Position.valueOf(cgEqpUpstar.getEquipPosition()).isCanUpStar()){
			return;
		}
		if(cgEqpUpstar.getUseExtraItem()!=1&&cgEqpUpstar.getUseExtraItem()!=2){
			return;
		}
		Position pos = Position.valueOf(cgEqpUpstar.getEquipPosition());
		if (pos == null || pos == Position.NULL) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		boolean useExtraItemFlag = cgEqpUpstar.getUseExtraItem() == 1;
		Globals.getEquipService().upgradeStar(player.getHuman(), pos, useExtraItemFlag);
	}
	
	/**
 	* 镶嵌宝石
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpGemSet(Player player, CGEqpGemSet cgEqpGemSet) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.GEM_EQUIP)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.GEM_EQUIP);
			return ;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		if (cgEqpGemSet.getEquipUuid().isEmpty()) {
			return;
		}
		if (cgEqpGemSet.getHoleNum() <= 0 || cgEqpGemSet.getHoleNum() > Globals.getGameConstants().getGemHoleMaxNum()) {
			return;
		}
		if (cgEqpGemSet.getGemItemId() <= 0) {
			return;
		}
		if (cgEqpGemSet.getExtraItemId() <= 0) {
			return;
		}
		
		Globals.getEquipService().gemUp(player.getHuman(), cgEqpGemSet.getEquipUuid(), 
				cgEqpGemSet.getHoleNum(), cgEqpGemSet.getGemItemId(), cgEqpGemSet.getExtraItemId());
	}
	
	/**
 	* 取下宝石
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpGemTakedown(Player player, CGEqpGemTakedown cgEqpGemTakedown) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.GEM_EQUIP)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.GEM_EQUIP);
			return ;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		
		if (cgEqpGemTakedown.getEquipUuid().isEmpty()) {
			return;
		}
		if (cgEqpGemTakedown.getHoleNum() <= 0 || cgEqpGemTakedown.getHoleNum() > Globals.getGameConstants().getGemHoleMaxNum()) {
			return;
		}
		if (cgEqpGemTakedown.getExtraItemId() <= 0) {
			return;
		}
		
		Globals.getEquipService().gemDown(player.getHuman(), cgEqpGemTakedown.getEquipUuid(), 
				cgEqpGemTakedown.getHoleNum(), cgEqpGemTakedown.getExtraItemId());
	}
	
	/**
 	* 合成宝石
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpGemSynthesis(Player player, CGEqpGemSynthesis cgEqpGemSynthesis) {
		if (player == null || player.getHuman() == null) {
			return ;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.GEM_SYNTHESIS)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.GEM_SYNTHESIS);
			return ;
		}
		if (player.getHuman().getPetManager().getLeader() == null){
			return ;
		}
		if (cgEqpGemSynthesis.getGemTplId() <= 0) {
			return;
		}
		//合成宝石基数在区间内
		if (cgEqpGemSynthesis.getSynthesisBase() < Globals.getGameConstants().getGemCanBeSynthesisLowestBase()
				|| cgEqpGemSynthesis.getSynthesisBase() > Globals.getGameConstants().getGemCanBeSynthesisHighestBase()) {
			return ;
		}
		//合成方式有效 0单个 1全部
		if(cgEqpGemSynthesis.getSynthesisType() != 0 && cgEqpGemSynthesis.getSynthesisType() != 1){
			return ;
		}

		Globals.getEquipService().synthesisGem(player.getHuman(), 
				cgEqpGemSynthesis.getGemTplId(),
				cgEqpGemSynthesis.getSynthesisBase(),
				cgEqpGemSynthesis.getSynthesisType() > 0);
	}
	
	/**
 	* 重铸装备
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpRecast(Player player, CGEqpRecast cgEqpRecast) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.RECAST)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.RECAST);
			return ;
		}
		if(cgEqpRecast.getEquipUuid() == null){
			return;
		}
		
		Globals.getEquipService().recast(player.getHuman(), cgEqpRecast.getEquipUuid(),cgEqpRecast.getEquipRecastInfo());
	}
	
	/**
 	* 分解装备
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpDecompose(Player player, CGEqpDecompose cgEqpDecompose) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.DECOMPOSE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.DECOMPOSE);
			return ;
		}
		if(cgEqpDecompose.getEquipList() == null){
			return;
		}
		Globals.getEquipService().decompose(player.getHuman(), cgEqpDecompose.getEquipList());
	}
	
	/**
	 * 装备打孔、洗孔
	 * @param player
	 * @param cgEqpHole
	 */
	public void handleEqpHole(Player player, CGEqpHole cgEqpHole) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgEqpHole.getEquipUUId().isEmpty()) {
			return;
		}
		
		if (cgEqpHole.getIsRefresh() <= 0) {
			//装备打孔
			if (cgEqpHole.getHoleItemId() <= 0) {
				return;
			}
			Globals.getEquipService().equipHoleCreate(player.getHuman(), cgEqpHole.getEquipUUId(), cgEqpHole.getHoleItemId());
		} else {
			//装备洗孔
			if (cgEqpHole.getHoleNum() <= 0 || cgEqpHole.getHoleNum() > Globals.getGameConstants().getGemHoleMaxNum()) {
				return;
			}
			Globals.getEquipService().equipHoleRefresh(player.getHuman(), cgEqpHole.getEquipUUId(), cgEqpHole.getHoleNum());
		}
		
	}
	
}
