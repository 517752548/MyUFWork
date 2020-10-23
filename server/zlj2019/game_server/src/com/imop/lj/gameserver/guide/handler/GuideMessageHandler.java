
package com.imop.lj.gameserver.guide.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.guide.msg.CGFinishGuide;
import com.imop.lj.gameserver.guide.msg.CGShowGuideByFunc;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class GuideMessageHandler {	
	
	public GuideMessageHandler() {	
	}	
		/**
 	* 根据功能Id显示新手引导
 	* 
 	* CodeGenerator
 	*/
	public void handleShowGuideByFunc(Player player, CGShowGuideByFunc cgShowGuideByFunc) {
		if (!checkCond(player)) {
			return;
		}
		FuncTypeEnum funcType = FuncTypeEnum.valueOf(cgShowGuideByFunc.getFuncTypeId());
		if (null == funcType) {
			return;
		}
		
		Globals.getGuideService().showGuideInfoByFuncType(player.getHuman(), funcType);
	}
		/**
 	* 完成新手引导，一些特殊的地方需要前台主动发完成才算完成，如欢迎的新手、vip体验卡的新手
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishGuide(Player player, CGFinishGuide cgFinishGuide) {
		if (!checkCond(player)) {
			return;
		}
		
		GuideType guideType = GuideType.valueOf(cgFinishGuide.getGuideTypeId());
		if (null == guideType) {
			return;
		}
		
		Globals.getGuideService().finishGuide(player.getHuman(), guideType);
	}
	
	protected boolean checkCond(Player player) {
		if (player == null || player.getHuman() == null) {
			return false;
		}
		return true;
	}
	}
