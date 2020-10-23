
package com.imop.lj.gameserver.equip.handler;


import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.equip.msg.CGEqpCraft;
import com.imop.lj.gameserver.equip.msg.CGEqpDecompose;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSet;
import com.imop.lj.gameserver.equip.msg.CGEqpGemSynthesis;
import com.imop.lj.gameserver.equip.msg.CGEqpGemTakedown;
import com.imop.lj.gameserver.equip.msg.CGEqpRecast;
import com.imop.lj.gameserver.equip.msg.CGEqpRefinery;
import com.imop.lj.gameserver.equip.msg.CGEqpUpstar;
import com.imop.lj.gameserver.equip.template.CraftEquipTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.container.PetGemBag;
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
		
		if (cgEqpCraft.getEquipmentID() <= 0) {
			return;
		}
		
		if (null == Globals.getTemplateCacheService().getTemplateService().get(cgEqpCraft.getEquipmentID(), CraftEquipTemplate.class)) {
			return;
		}
		Globals.getEquipService().craftEquip(player.getHuman(), cgEqpCraft.getEquipmentID());
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
		//判断这个装备位是否可以镶嵌宝石
		if(!PetGemBag.containedPositionIndex(cgEqpGemSet.getEquipPosition())){
			return;
		}
		//判断宝石包的subIndex是否合法
		if(cgEqpGemSet.getGemPosition()<0 || cgEqpGemSet.getGemPosition()>PetGemBag.getSubCapacity()){
			return;
		}
		//判断主背包有对应宝石index
		if(!player.getHuman().getInventory().getPrimBag().checkIndex(cgEqpGemSet.getGemIndex())){
			return;
		}
		//判断目标是否是一块宝石
		if(!Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().containsKey(player.getHuman().getInventory().getPrimBag().getByIndex(cgEqpGemSet.getGemIndex()).getTemplateId())){
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getEquipService().putOnOneGem(player.getHuman(),cgEqpGemSet.getEquipPosition(),cgEqpGemSet.getGemPosition(),cgEqpGemSet.getGemIndex());
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
		if(player.getHuman().getPetManager().getLeader() == null){
			return;
		}
		//判断这个装备位是否可以镶嵌宝石
		if(!PetGemBag.containedPositionIndex(cgEqpGemTakedown.getEquipPosition())){
			return;
		}
		//判断宝石包的subIndex是否合法
		if(cgEqpGemTakedown.getGemPosition()<0 || cgEqpGemTakedown.getGemPosition()>PetGemBag.getSubCapacity()){
			return;
		}
		//判断宝石包对应位置有宝石
		if(!player.getHuman().getInventory().getGemBagByPet(player.getHuman().getPetManager().getLeader().getUUID()).hasGem(Position.valueOf(cgEqpGemTakedown.getEquipPosition()), cgEqpGemTakedown.getGemPosition())){
			return;
		}
		//判断有空位
		if(player.getHuman().getInventory().getPrimBag().getEmptySlotCount()<=0){
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getEquipService().takeOffOneGem(player.getHuman(),cgEqpGemTakedown.getEquipPosition(),cgEqpGemTakedown.getGemPosition());
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
		if(player.getHuman().getPetManager().getLeader() == null){
			return ;
		}
		//目标等级在区间内
		if(cgEqpGemSynthesis.getGemLevel() < Globals.getGameConstants().getGemCanBeSynthesisLowestLevel()
				||cgEqpGemSynthesis.getGemLevel() > Globals.getGameConstants().getGemCanBeSynthesisHighestLevel()){
			return ;
		}
		//目标类型有效
		if(cgEqpGemSynthesis.getGemType()<=0 
				|| ItemDef.GemType.valueOf(cgEqpGemSynthesis.getGemType()) == null
				|| ItemDef.GemType.valueOf(cgEqpGemSynthesis.getGemType()) == ItemDef.GemType.NULL){
			return ;
		}
		//合成宝石基数在区间内
		if (cgEqpGemSynthesis.getSynthesisBase() < Globals.getGameConstants().getGemCanBeSynthesisLowestBase()
				|| cgEqpGemSynthesis.getSynthesisBase() > Globals.getGameConstants().getGemCanBeSynthesisHighestBase()) {
			return ;
		}
		//合成方式有效 1单个 2全部
		if(cgEqpGemSynthesis.getSynthesisType() != 1 && cgEqpGemSynthesis.getSynthesisType() != 2){
			return ;
		}

		Globals.getEquipService().synthesisGem(player.getHuman(), cgEqpGemSynthesis.getGemType(), 
				cgEqpGemSynthesis.getGemLevel(), cgEqpGemSynthesis.getSynthesisBase(),cgEqpGemSynthesis.getSynthesisType());
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
 	* 洗炼装备
 	* 
 	* CodeGenerator
 	*/
	public void handleEqpRefinery(Player player, CGEqpRefinery cgEqpRefinery) {
		//判断玩家信息以及当前使用的角色
		if (player == null || player.getHuman() == null) {
			return;
		}
		//玩家当前使用的角色是否开启了炼化功能
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.REFINE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.REFINE);
			return ;
		}
		//判断装备是否合法
		if(cgEqpRefinery.getEquipUuid() == null){
			return;
		}
		//玩家需要洗炼的装备
		Globals.getEquipService().refinery(player.getHuman(), cgEqpRefinery.getEquipUuid());
	}
}
