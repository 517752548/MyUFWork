package com.imop.lj.gameserver.guaji.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.guaji.GuaJiDef.GuaJiParam;
import com.imop.lj.gameserver.guaji.msg.CGGuaJiPanel;
import com.imop.lj.gameserver.guaji.msg.CGStartGuaJi;
import com.imop.lj.gameserver.guaji.msg.CGPauseGuaJi;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class GuajiMessageHandler {	
	
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
	
	public GuajiMessageHandler() {	
	}	
		/**
 	* 打开挂机面板
 	* 
 	* CodeGenerator
 	*/
	public void handleGuaJiPanel(Player player, CGGuaJiPanel cgGuaJiPanel) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.GUA_JI)){
			return;
		}
		
		Globals.getGuaJiService().noticeGuaJiInfo(player.getHuman());
	}
		/**
 	* 开始挂机
 	* 
 	* CodeGenerator
 	*/
	public void handleStartGuaJi(Player player, CGStartGuaJi cgStartGuaJi) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.GUA_JI)){
			return;
		}
		
		/** 遇敌间隔 */
		int encounterSecond = cgStartGuaJi.getEncounterSecond();
		if(encounterSecond <= 0){
			return;
		}
		if(!Globals.getTemplateCacheService().getGuaJiTemplateCache().guajiParamIsCorrect(GuaJiParam.ENCOUNTER, encounterSecond)){
			return;
		}
		/** 增加人物经验(1-1倍经验,2-2倍经验) */
		int humanExpTimes = cgStartGuaJi.getHumanExpTimes();
		if(humanExpTimes <= 0){
			return;
		}
		if(!Globals.getTemplateCacheService().getGuaJiTemplateCache().guajiParamIsCorrect(GuaJiParam.HUMAN_EXP_TIMES, humanExpTimes)){
			return;
		}
		/** 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验) */
		int petExpTimes = cgStartGuaJi.getPetExpTimes();
		if(petExpTimes <= 0){
			return;
		}
		if(!Globals.getTemplateCacheService().getGuaJiTemplateCache().guajiParamIsCorrect(GuaJiParam.PET_EXP_TIMES, petExpTimes)){
			return;
		}
		/** 1开启，0关闭 */
		int fullEnemyFlag = cgStartGuaJi.getFullEnemy();
		if(fullEnemyFlag < 0 || fullEnemyFlag > 1){
			return;
		}
		if(!Globals.getTemplateCacheService().getGuaJiTemplateCache().guajiParamIsCorrect(GuaJiParam.FULL_ENEMY, fullEnemyFlag)){
			return;
		}
		boolean fullEnemy = fullEnemyFlag == 1 ? true : false;
		/** 1开启，0关闭 */
		int switchSceneFlag = cgStartGuaJi.getSwitchScene();
		if(switchSceneFlag < 0 || switchSceneFlag > 1){
			return;
		}
		boolean switchScene = switchSceneFlag == 1 ? true : false;
		/** 挂机分钟数 */
		int guaJiMinute = cgStartGuaJi.getGuaJiMinute();
		if(guaJiMinute <= 0){
			return;
		}
		if(!Globals.getTemplateCacheService().getGuaJiTemplateCache().guajiParamIsCorrect(GuaJiParam.GUA_JI_MINUTE, guaJiMinute)){
			return;
		}
		/** 所需挂机点数 */
		int needGuaJiPoint = cgStartGuaJi.getNeedGuaJiPoint();
		Globals.getGuaJiService().handleStartGuaJi(player.getHuman(), encounterSecond,
				humanExpTimes, petExpTimes, fullEnemy, switchScene, guaJiMinute, needGuaJiPoint);
	}
		/**
 	* 暂停挂机
 	* 
 	* CodeGenerator
 	*/
	public void handlePauseGuaJi(Player player, CGPauseGuaJi cgPauseGuaJi) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.GUA_JI)){
			return;
		}
		
		Globals.getGuaJiService().pauseGuaJi(player.getHuman());
	}
	}
