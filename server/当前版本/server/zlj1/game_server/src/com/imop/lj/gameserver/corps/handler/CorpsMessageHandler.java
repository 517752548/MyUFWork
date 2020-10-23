package com.imop.lj.gameserver.corps.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.allocate.AllocateItemInfo;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef;
import com.imop.lj.gameserver.corps.CorpsService;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.msg.CGAllocateActivityItem;
import com.imop.lj.gameserver.corps.msg.CGAllocationItem;
import com.imop.lj.gameserver.corps.msg.CGBackCorpsMap;
import com.imop.lj.gameserver.corps.msg.CGClickCorpsFunction;
import com.imop.lj.gameserver.corps.msg.CGClickCorpsMemberFunction;
import com.imop.lj.gameserver.corps.msg.CGClickCorpsPanel;
import com.imop.lj.gameserver.corps.msg.CGCorpsAddToFriend;
import com.imop.lj.gameserver.corps.msg.CGCorpsBatchAddApplyMember;
import com.imop.lj.gameserver.corps.msg.CGCorpsBatchFireMember;
import com.imop.lj.gameserver.corps.msg.CGCorpsDonate;
import com.imop.lj.gameserver.corps.msg.CGCorpsMemberInfo;
import com.imop.lj.gameserver.corps.msg.CGCorpsNoticeUpdate;
import com.imop.lj.gameserver.corps.msg.CGCorpsPageSkip;
import com.imop.lj.gameserver.corps.msg.CGCorpsQuickApply;
import com.imop.lj.gameserver.corps.msg.CGCorpswarInfo;
import com.imop.lj.gameserver.corps.msg.CGCorpswarRankList;
import com.imop.lj.gameserver.corps.msg.CGCreateCorps;
import com.imop.lj.gameserver.corps.msg.CGCreateCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGCultivateSkill;
import com.imop.lj.gameserver.corps.msg.CGEnterCorpswar;
import com.imop.lj.gameserver.corps.msg.CGGetBenifit;
import com.imop.lj.gameserver.corps.msg.CGGotCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGLearnAssistSkill;
import com.imop.lj.gameserver.corps.msg.CGLeaveCorpswar;
import com.imop.lj.gameserver.corps.msg.CGLookCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.CGMakeItem;
import com.imop.lj.gameserver.corps.msg.CGOpenAllocatePanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsAssistPanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsBenifitPanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsBuildingPanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsMemberList;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsPanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsRedEnvelopePanel;
import com.imop.lj.gameserver.corps.msg.CGOpenCorpsStorage;
import com.imop.lj.gameserver.corps.msg.CGSearchCorps;
import com.imop.lj.gameserver.corps.msg.CGUpgradeCorps;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Country;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeDef.RedEnvelopeType;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CorpsMessageHandler {

	
	private boolean checkRoleAndFunc(Player player, FuncTypeEnum funcType){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), funcType)) {
			Loggers.humanLogger.warn("player not open func " + funcType);
			return false;
		}
		return true;
	}
	
	public CorpsMessageHandler() {
	}

	/**
	 * 点击军团按钮
	 * 
	 * CodeGenerator
	 */
	public void handleClickCorpsPanel(Player player, CGClickCorpsPanel cgOpenClickPanel) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleOpenCorpsPanel corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleClickCorpsPanel(human);
	}

	/**
	 * 搜索军团
	 * 
	 * CodeGenerator
	 */
	public void handleSearchCorps(Player player, CGSearchCorps cgSearchCorps) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleSearchCorps corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Country country = Country.valueOf(cgSearchCorps.getCountry());
		if(country == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleSearchCorps country does not exist, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleSearchCorps(human, cgSearchCorps.getCountry(), cgSearchCorps.getName());
	}

	/**
	 * 页面跳转
	 * 
	 * CodeGenerator
	 */
	public void handleCorpsPageSkip(Player player, CGCorpsPageSkip cgCorpsPageSkip) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsPageSkip corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Country country = Country.valueOf(cgCorpsPageSkip.getCountry());
		if(country == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsPageSkip country does not exist, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleCorpsPageSkip(human, cgCorpsPageSkip.getCountry(), cgCorpsPageSkip.getPage());
	}
	
	/**
 	* 点击军团相关功能
 	* 
 	* CodeGenerator
 	*/
	public void handleClickCorpsFunction(Player player, CGClickCorpsFunction cgClickCorpsFunction) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleClickCorpsFunction corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleClickCorpsFunction(human, cgClickCorpsFunction.getCorpsId(), cgClickCorpsFunction.getFuncId());
	}
	
	/**
 	* 点击军团成员相关功能
 	* 
 	* CodeGenerator
 	*/
	public void handleClickCorpsMemberFunction(Player player, CGClickCorpsMemberFunction cgClickCorpsMemberFunction) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleClickCorpsMemberFunction corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleClickCorpsMemberFunction(human, cgClickCorpsMemberFunction.getCorpsMemberId(), cgClickCorpsMemberFunction.getFuncId());
	}
	
	/**
 	* 创建军团
 	* 
 	* CodeGenerator
 	*/
	public void handleCreateCorps(Player player, CGCreateCorps cgCreateCorps) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCreateCorps corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleCreateCorps(human, cgCreateCorps.getName(), cgCreateCorps.getNotice());
	}
		/**
 	* 打开军团面板
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenCorpsPanel(Player player, CGOpenCorpsPanel cgOpenCorpsPanel) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleOpenCorpsPanel corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleOpenCorpsPanel(human);
	}
		/**
 	* 军团捐献
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsDonate(Player player, CGCorpsDonate cgCorpsDonate) {
		
		return;
		
		/* 这部分注释掉，现在不要捐献功能
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsDonate corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleCorpsDonate(human, cgCorpsDonate.getNum());
		*/
	}
		/**
 	* 修改公告
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsNoticeUpdate(Player player, CGCorpsNoticeUpdate cgCorpsNoticeUpdate) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsNoticeUpdate corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleCorpsNoticeUpdate(human, cgCorpsNoticeUpdate.getQq(), cgCorpsNoticeUpdate.getNotice());
	}
	
	/**
 	* 打开军团成员列表
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenCorpsMemberList(Player player, CGOpenCorpsMemberList cgOpenCorpsmemberList) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleOpenCorpsmemberList corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleOpenCorpsmemberList(human);
	}
	
	/**
 	* 打开军团仓库
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenCorpsStorage(Player player, CGOpenCorpsStorage cgOpenCorpsStorage) {
		
		/* 这部分注释掉,现在没有仓库
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleOpenCorpsStorage corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleOpenCorpsStorage(human);
		*/
	}
	
	/**
 	* 分配物品
 	* 
 	* CodeGenerator
 	*/
	public void handleAllocationItem(Player player, CGAllocationItem cgAllocationItem) {
		/*这部分注释掉,现在没有仓库
		 * */
		/*
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleAllocationItem corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		
		Globals.getCorpsService().handleAllocationItem(human, cgAllocationItem.getTargetId(), cgAllocationItem.getStorageItemList());
		*/
	}
	
	/**
	 * 功能是否开启
	 * 
	 * @param human
	 * @return
	 */
	private boolean isFuncOpen(Human human){
		if(human == null){
			return false;
		}
		
//		if(!human.getCountryManager().hasCountry()){
//			return false;
//		}
		return Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.CORPS);
	}
		/**
 	* 添加军团成员成好友
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsAddToFriend(Player player, CGCorpsAddToFriend cgCorpsAddToFriend) {
		/* 这部分暂时注释掉,现在军团人数比好友人数多
		if(null == player || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsAddToFriend corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		Globals.getCorpsService().addCorpsMem2Friends(player.getHuman());
		*/
	}
	/**
 	* 批量踢出成员
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsBatchFireMember(Player player, CGCorpsBatchFireMember cgCorpsBatchFireMember) {
		if(null == player || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
		//	Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsBatchFireMember corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		if(cgCorpsBatchFireMember.getTargetIds() == null || cgCorpsBatchFireMember.getTargetIds().length <= 0){
			return;
		}
		Globals.getCorpsService().batchCorpsMemberOper(human, cgCorpsBatchFireMember.getTargetIds(),CorpsService.BATCH_FIRE);
	}
	
	/**
 	* 批量添加成员
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsBatchAddApplyMember(Player player, CGCorpsBatchAddApplyMember cgCorpsBatchAddApplyMember) {
		if(null == player || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
		//	Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsBatchAddApplyMember corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		if(cgCorpsBatchAddApplyMember.getTargetIds() == null || cgCorpsBatchAddApplyMember.getTargetIds().length <= 0){
			return;
		}
		Globals.getCorpsService().batchCorpsMemberOper(human, cgCorpsBatchAddApplyMember.getTargetIds(),CorpsService.BATCH_ADD);
	}
	
	/**
	* 请求个人帮派成员信息
	* 
	* CodeGenerator
	*/
	public void handleCorpsMemberInfo(Player player, CGCorpsMemberInfo cgCorpsMemberInfo) {
		if(null == player || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
		//	Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsMemberInfo corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		//Globals.getCorpsService().getCorpsMemberInfo(human);
	}
	
	/**
	* 一键申请
	* 
	* CodeGenerator
	*/
	public void handleCorpsQuickApply(Player player, CGCorpsQuickApply cgCorpsQuickApply) {
		if(null == player || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();
		if(!this.isFuncOpen(human)){
		//	Loggers.corpsLogger.error("CorpsMessageHandler.handleCorpsQuickApply corps func is not open, playerId = " + player.getRoleUUID());
			return;
		}
		Globals.getCorpsService().quickApply(human, cgCorpsQuickApply.getPage());
	}

	/**
	 * 请求进入帮派竞赛
	 * @param player
	 * @param cgEnterCorpswar
	 */
	public void handleEnterCorpswar(Player player, CGEnterCorpswar cgEnterCorpswar) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CORPSWAR)) {
			return;
		}
		
		Globals.getCorpsWarService().enterCorpsWar(player.getHuman());
	}
	
	/**
	 * 请求离开帮派竞赛
	 * @param player
	 * @param cgLeaveCorpswar
	 */
	public void handleLeaveCorpswar(Player player, CGLeaveCorpswar cgLeaveCorpswar) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CORPSWAR)) {
			return;
		}
		
		Globals.getCorpsWarService().leaveCorpsWar(player.getHuman());
	}
	
	/**
	 * 请求帮派竞赛排行榜
	 * @param player
	 * @param cgCorpswarRankList
	 */
	public void handleCorpswarRankList(Player player, CGCorpswarRankList cgCorpswarRankList) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		Globals.getCorpsWarService().showRankList(player.getHuman());
	}
	
	/**
	 * 请求帮派竞赛信息
	 * @param player
	 * @param cgCorpswarInfo
	 */
	public void handleCorpswarInfo(Player player, CGCorpswarInfo cgCorpswarInfo) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		Globals.getCorpsWarService().sendCorpsWarInfoMsg(player.getHuman());
	}
	
		/**
		* 请求回到帮派场景
		* 
		* CodeGenerator
		*/
	public void handleBackCorpsMap(Player player, CGBackCorpsMap cgBackCorpsMap) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		//玩家是否在军团中
		long corpsId = Globals.getCorpsService().getUserCorpsId(player.getHuman().getCharId());
		if (corpsId <= 0) {
			return;
		}
		
		Globals.getCorpsService().backCorpsMap(player.getHuman(),corpsId);
	}
	
	/**
	 * 请求建筑面板
	 * @param player
	 * @param cgOpenCorpsBuildingPanel
	 */
	public void handleOpenCorpsBuildingPanel(Player player, CGOpenCorpsBuildingPanel cgOpenCorpsBuildingPanel) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		//建筑类型是否正确
		if(CorpsDef.BuildType.valueOf(cgOpenCorpsBuildingPanel.getBuildType()) == null){
			return;
		}
		
		Globals.getCorpsService().handleOpenCorpsBuildingPanel(player.getHuman(),corps, cgOpenCorpsBuildingPanel.getBuildType());
	}
	
	
		/**
		* 请求升级帮派建筑
		* 
		* CodeGenerator
		*/
	public void handleUpgradeCorps(Player player, CGUpgradeCorps cgUpgradeCorps) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		//建筑类型是否正确
		if(CorpsDef.BuildType.valueOf(cgUpgradeCorps.getBuildType()) == null){
			return;
		}
		Globals.getCorpsService().upgradeCorps(player.getHuman(),corps, cgUpgradeCorps.getBuildType());
	}

	/**
	 * 打开帮派福利面板
	 * @param player
	 * @param cgOpenCorpsBenifitPanel
	 */
	public void handleOpenCorpsBenifitPanel(Player player, CGOpenCorpsBenifitPanel cgOpenCorpsBenifitPanel) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		Globals.getCorpsService().handleOpenCorpsBenifitPanel(player.getHuman(),corps);
	}
	/**
	 * 请求领取奖励
	 * @param player
	 * @param cgGetBenifit
	 */
	public void handleGetBenifit(Player player, CGGetBenifit cgGetBenifit) {
		if (null == player || player.getHuman() == null) {
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		Globals.getCorpsService().getBenifit(player.getHuman(),corps);
	}
	
	/**
	 *  请求打开帮派修炼技能面板
	 * @param player
	 * @param cgOpenCorpsCultivatePanel
	 */
	public void handleOpenCorpsCultivatePanel(Player player, CGOpenCorpsCultivatePanel cgOpenCorpsCultivatePanel) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_CULTIVATE)){
			return;
		}
		
		Globals.getCorpsCultivateService().handleOpenCorpsCultivatePanel(player.getHuman());
	}

	/**
	 * 请求修炼技能
	 * @param player
	 * @param cgCultivateSkill
	 */
	public void handleCultivateSkill(Player player, CGCultivateSkill cgCultivateSkill) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_CULTIVATE)){
			return;
		}
		
		//技能Id是否有效
		int skillId = cgCultivateSkill.getSkillId();
		if(CorpsDef.CultivateSkillType.valueOf(skillId) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCultivateSkill skillId is invalid, playerId = " + player.getRoleUUID() +";skillId = " + skillId);
			return;
		}
		//是否批量
		int type = cgCultivateSkill.getIsBatch();
		if(CorpsDef.CultivateBatchType.valueOf(type) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleCultivateSkill isBatch is invalid, playerId = " + player.getRoleUUID() +";isBatch = " + type);
			return;
		}
		
		boolean isBatch = type == 1 ? true : false;
		
		
		Globals.getCorpsCultivateService().handleCultivateSkill(player.getHuman(), skillId, isBatch);
	}
	
	/**
	 * 请求打开帮派辅助技能面板
	 * @param player
	 * @param cgOpenCorpsAssistPanel
	 */
	public void handleOpenCorpsAssistPanel(Player player, CGOpenCorpsAssistPanel cgOpenCorpsAssistPanel) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_ASSIST)){
			return;
		}
		
		Globals.getCorpsAssistService().handleOpenCorpsAssistPanel(player.getHuman());
	}
	
	/**
	 * 请求学习辅助技能
	 * @param player
	 * @param cgLearnAssistSkill
	 */
	public void handleLearnAssistSkill(Player player, CGLearnAssistSkill cgLearnAssistSkill) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_ASSIST)){
			return;
		}
		
		//技能Id是否有效
		int skillId = cgLearnAssistSkill.getSkillId();
		if(CorpsDef.AssistSkillType.valueOf(skillId) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleLearnAssistSkill skillId is invalid, playerId = " + player.getRoleUUID() +";skillId = " + skillId);
			return;
		}
		
		Globals.getCorpsAssistService().handleLearnAssistSkill(player.getHuman(), skillId);
	}

	/**
	 * 请求制作物品
	 * @param player
	 * @param cgMakeItem
	 */
	public void handleMakeItem(Player player, CGMakeItem cgMakeItem) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_ASSIST)){
			return;
		}
		
		//技能Id是否有效
		int skillId = cgMakeItem.getSkillId();
		if(CorpsDef.AssistSkillType.valueOf(skillId) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleMakeItem skillId is invalid, playerId = " + player.getRoleUUID() +";skillId = " + skillId);
			return;
		}
		
		int targetLevel = cgMakeItem.getTargetLevel();
		if(targetLevel > Globals.getGameConstants().getAssistUpgradeMaxLevel() || targetLevel < Globals.getGameConstants().getAssistUpgradeMinLevel()){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleMakeItem targetLevel is invalid, playerId = " + player.getRoleUUID() +";targetLevel = " + targetLevel);
			return;
		}
		
		
		Globals.getCorpsAssistService().handleMakeItem(player.getHuman(), skillId, targetLevel);
	}


	/**
	 * 请求打开帮派红包面板
	 * @param player
	 * @param cgOpenCorpsRedEnvelopePanel
	 */
	public void handleOpenCorpsRedEnvelopePanel(Player player,
			CGOpenCorpsRedEnvelopePanel cgOpenCorpsRedEnvelopePanel) {
		
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_RED_ENVELOPE)){
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		Globals.getRedEnvelopeService().handleOpenCorpsRedEnvelopePanel(player.getHuman(), corps);
		
	}
	
	/**
	 * 请求发送帮派红包
	 * @param player
	 * @param cgCreateCorpsRedEnvelope
	 */
	public void handleCreateCorpsRedEnvelope(Player player, CGCreateCorpsRedEnvelope cgCreateCorpsRedEnvelope) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_RED_ENVELOPE)){
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		//红包金额是否有效
		int bonusAmount = cgCreateCorpsRedEnvelope.getBonusAmount();
		if(bonusAmount < Globals.getGameConstants().getRedEnvelopeMin()
				|| bonusAmount > Globals.getGameConstants().getRedEnvelopeMax()){
			player.sendErrorMessage(LangConstants.SEND_A_RED_ENVELOPE_MIN_BONUS, Globals.getGameConstants().getRedEnvelopeMin());
			return;
		}
		
		//红包内容
		String content = cgCreateCorpsRedEnvelope.getContent();
		//红包类型
		if(RedEnvelopeType.valueOf(cgCreateCorpsRedEnvelope.getRedEnvelopeType()) == null){
			player.sendErrorMessage(LangConstants.RED_ENVELOPE_TYPE_NOT_EXIST);
			return;
		}
		
		Globals.getRedEnvelopeService().handleCreateCorpsRedEnvelope(player.getHuman(), bonusAmount, content, corps);
	}

	/**
	 * 请求领取帮派红包
	 * @param player
	 * @param cgGotCorpsRedEnvelope
	 */
	public void handleGotCorpsRedEnvelope(Player player, CGGotCorpsRedEnvelope cgGotCorpsRedEnvelope) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_RED_ENVELOPE)){
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		String uuid = cgGotCorpsRedEnvelope.getUuid();
		//红包类型
		if(RedEnvelopeType.valueOf(cgGotCorpsRedEnvelope.getRedEnvelopeType()) == null){
			player.sendErrorMessage(LangConstants.RED_ENVELOPE_TYPE_NOT_EXIST);
			return;
		}
		
		Globals.getRedEnvelopeService().handleGotCorpsRedEnvelope(player.getHuman(), uuid, corps);
	}
	
	/**
	 * 请求查看红包详情
	 * @param player
	 * @param cgLookCorpsRedEnvelope
	 */
	public void handleLookCorpsRedEnvelope(Player player, CGLookCorpsRedEnvelope cgLookCorpsRedEnvelope) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.CORPS_RED_ENVELOPE)){
			return;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		String uuid = cgLookCorpsRedEnvelope.getUuid();
		
		Globals.getRedEnvelopeService().handleLookCorpsRedEnvelope(player.getHuman(), uuid);
		
	}
	
	/**
	 * 请求打开活动奖励分配面板
	 * @param player
	 * @param cgOpenAllocatePanel
	 */
	public void handleOpenAllocatePanel(Player player, CGOpenAllocatePanel cgOpenAllocatePanel) {
		//帮派所有的人都可以看到
		if(player == null){
			return ;
		}
		if(player.getHuman() == null){
			return ;
		}
		
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		//活动类型
		int activityType = cgOpenAllocatePanel.getActivityType();
		if(ActivityType.valueOf(activityType) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleOpenAllocatePanel activityType is invalid, playerId = " + player.getRoleUUID() +";activityType = " + activityType);
			return;
		}
		
		Globals.getAllocateActivityStorageService().handleOpenAllocatePanel(player.getHuman(), corps, activityType);
	}

	/**
	 * 请求分配活动得到的物品
	 * @param player
	 * @param cgAllocateActivityItem
	 */
	public void handleAllocateActivityItem(Player player, CGAllocateActivityItem cgAllocateActivityItem) {
		if(player == null){
			return ;
		}
		if(player.getHuman() == null){
			return ;
		}
		//是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(player.getHuman().getCharId());
		if(corps == null){
			return;
		}
		
		//活动类型
		int activityType = cgAllocateActivityItem.getActivityType();
		if(ActivityType.valueOf(activityType) == null){
			Loggers.corpsLogger.error("CorpsMessageHandler.handleAllocateActivityItem activityType is invalid, playerId = " + player.getRoleUUID() +";activityType = " + activityType);
			return;
		}
		
		//帮主可以给自己发
		
		//物品列表不可以为空
		AllocateItemInfo[] allocatingItemInfos = cgAllocateActivityItem.getAllocatingItemInfos();
		if (allocatingItemInfos.length == 0) {
			Loggers.corpsLogger.error("CorpsMessageHandler.handleAllocateActivityItem getAllocatingItemInfos length is 0, playerId = " + player.getRoleUUID() +";allocatingItemInfos = " + allocatingItemInfos);
			return;
		}
		
		//参数基础校验，道具数量在指定范围内，道具id存在
		for (int i = 0; i < allocatingItemInfos.length; i++) {
			if (allocatingItemInfos[i].getNum() <= 0 
					|| allocatingItemInfos[i].getNum() > Globals.getGameConstants().getItemMaxOverlapNum()
					|| Globals.getTemplateCacheService().get(allocatingItemInfos[i].getItemId(), ItemTemplate.class) == null) {
				Loggers.corpsLogger.error("CorpsMessageHandler.handleAllocateActivityItem invalid item num, playerId = " + player.getRoleUUID() +";allocatingItemInfos = " + allocatingItemInfos);
				return;
			}
		}
		
		//帮派竞赛活动类型的分配奖励
		if(activityType == ActivityType.CORPS_WAR.getIndex()){
			if(allocatingItemInfos[0].getNum() > Globals.getGameConstants().getAllocateCorpsWarActivityNum()){
				Loggers.corpsLogger.error("CorpsMessageHandler.handleAllocateActivityItem allocate item greater than "+ Globals.getGameConstants().getAllocateCorpsWarActivityNum() 
						+", playerId = " + player.getRoleUUID());
				return;
			}
		}
		
		Globals.getAllocateActivityStorageService().handleAllocateActivityItem(player.getHuman(), corps, activityType, cgAllocateActivityItem.getTargetId(), allocatingItemInfos);
	}
	
	


}
