
package com.imop.lj.gameserver.relation.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.relation.RelationTypeEnum;
import com.imop.lj.gameserver.relation.msg.CGAddRelationBatch;
import com.imop.lj.gameserver.relation.msg.CGAddRelationById;
import com.imop.lj.gameserver.relation.msg.CGAddRelationByIdStr;
import com.imop.lj.gameserver.relation.msg.CGAddRelationByName;
import com.imop.lj.gameserver.relation.msg.CGClickRelationPanel;
import com.imop.lj.gameserver.relation.msg.CGDelRelation;
import com.imop.lj.gameserver.relation.msg.CGShowRecommendFriendList;
import com.imop.lj.gameserver.relation.msg.RelationMsgBuilder;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class RelationMessageHandler {	
	
	public RelationMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.RELATION)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.RELATION);
			return false;
		}
		return true;
	}
	
		/**
 	* 打开好友面板
 	* 
 	* CodeGenerator
 	*/
	public void handleClickRelationPanel(Player player, CGClickRelationPanel cgClickRelationPanel) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgClickRelationPanel.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		if (cgClickRelationPanel.getPage() <= 0) {
			return;
		}
		
		Human human = player.getHuman();
		human.sendMessage(RelationMsgBuilder.buildGCClickRelationPanelMsg(human, relationType, cgClickRelationPanel.getPage()));
	}
		/**
 	* 添加关系
 	* 
 	* CodeGenerator
 	*/
	public void handleAddRelationByName(Player player, CGAddRelationByName cgAddRelationByName) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgAddRelationByName.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		if (cgAddRelationByName.getTargetName() == null || cgAddRelationByName.getTargetName().equalsIgnoreCase("")) {
			return;
		}
		
		Globals.getRelationService().addRelation(player.getHuman(), cgAddRelationByName.getTargetName(), relationType);
		
	}
	
		/**
 	* 添加关系
 	* 
 	* CodeGenerator
 	*/
	public void handleAddRelationById(Player player, CGAddRelationById cgAddRelationById) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgAddRelationById.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		if (cgAddRelationById.getTargetCharId() <= 0) {
			return;
		}
		
		Globals.getRelationService().addRelation(player.getHuman(), cgAddRelationById.getTargetCharId(), relationType);
		
	}
	
	/**
 	* 添加关系
 	* 
 	* CodeGenerator
 	*/
	public void handleAddRelationByIdStr(Player player, CGAddRelationByIdStr cgAddRelationByIdStr) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgAddRelationByIdStr.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		
		long targetCharId = Long.parseLong(cgAddRelationByIdStr.getTargetCharIdStr());
		if (targetCharId <= 0) {
			return;
		}
		
		Globals.getRelationService().addRelation(player.getHuman(), targetCharId, relationType);
	}
	
	/**
 	* 删除关系
 	* 
 	* CodeGenerator
 	*/
	public void handleDelRelation(Player player, CGDelRelation cgDelRelation) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgDelRelation.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		if (cgDelRelation.getTargetName() == null || cgDelRelation.getTargetName().equalsIgnoreCase("")) {
			return;
		}
		
		Globals.getRelationService().delRelation(player.getHuman(), cgDelRelation.getTargetName(), relationType);
	}
	
	/**
	 * 批量添加关系
	 * @param player
	 * @param cgAddRelationBatch
	 */
	public void handleAddRelationBatch(Player player, CGAddRelationBatch cgAddRelationBatch) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		RelationTypeEnum relationType = RelationTypeEnum.valueOf(cgAddRelationBatch.getRelationType());
		if (relationType == null || relationType == RelationTypeEnum.NONE) {
			return;
		}
		if (cgAddRelationBatch.getTargetCharIdArr().length == 0) {
			return;
		}
		
		Globals.getRelationService().addRelationBatch(player.getHuman(), relationType, cgAddRelationBatch.getTargetCharIdArr());
	}
	
	/**
	 * 显示推荐好友面板
	 * @param player
	 * @param cgShowRecommendFriendList
	 */
	public void handleShowRecommendFriendList(Player player, CGShowRecommendFriendList cgShowRecommendFriendList) {
		// 参数验证
		if (player == null || player.getHuman() == null || player.getHuman().getRelationManager() == null) {
			return;
		}
		if(!checkRoleAndFunc(player)){
			return;
		}
		Globals.getRelationService().showRecommendFriendList(player.getHuman());
	}
	}
