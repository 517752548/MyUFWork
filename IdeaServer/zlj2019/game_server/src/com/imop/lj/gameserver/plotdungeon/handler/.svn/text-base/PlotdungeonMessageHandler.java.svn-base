package com.imop.lj.gameserver.plotdungeon.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonDef.DungeonType;
import com.imop.lj.gameserver.plotdungeon.msg.CGDailyPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.CGGetDailyPlotDungeonReward;
import com.imop.lj.gameserver.plotdungeon.msg.CGPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.CGPlotDungeonStart;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class PlotdungeonMessageHandler {	
	
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
	
	public PlotdungeonMessageHandler() {	
	}	
		/**
 	* 查看当前剧情副本情况
 	* 
 	* CodeGenerator
 	*/
	public void handlePlotDungeonInfo(Player player, CGPlotDungeonInfo cgPlotDungeonInfo) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.PLOT_DUNGEON)){
			return;
		}
		//副本类型是否正确
		int plotDungeonType = cgPlotDungeonInfo.getPlotDungeonType();
		if(DungeonType.valueOf(plotDungeonType) == null){
			Loggers.plotDungeonLogger.error("handlePlotDungeonInfo DungeonType is invalid!charId = " + player.getHuman().getCharId()
			+";type = " + plotDungeonType);
			return;
		}
		
		Globals.getPlotDungeonService().handlePlotDungeonInfo(player.getHuman(), plotDungeonType);
	}
		/**
 	* 请求挑战剧情副本
 	* 
 	* CodeGenerator
 	*/
	public void handlePlotDungeonStart(Player player, CGPlotDungeonStart cgPlotDungeonStart) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.PLOT_DUNGEON)){
			return;
		}
		//副本类型是否正确
		int plotDungeonType = cgPlotDungeonStart.getPlotDungeonType();
		if(DungeonType.valueOf(plotDungeonType) == null){
			Loggers.plotDungeonLogger.error("handlePlotDungeonStart DungeonType is invalid!charId = " + player.getHuman().getCharId()
			+";type = " + plotDungeonType);
			return;
		}
		//请求关数是否正确
		int plotLevel = cgPlotDungeonStart.getPlotDungeonLevel();
		
		
		Globals.getPlotDungeonService().handlePlotDungeonStart(player.getHuman(), plotDungeonType, plotLevel);
	}
	
	/**
	 * 请求查看每日剧情副本奖励信息
	 * @param player
	 * @param cgDailyPlotDungeonInfo
	 */
	public void handleDailyPlotDungeonInfo(Player player, CGDailyPlotDungeonInfo cgDailyPlotDungeonInfo) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.PLOT_DUNGEON)){
			return;
		}
		
		Globals.getPlotDungeonService().noticePlotDungeonReward(player.getHuman());
	}
	
	/**
	 * 领取每日剧情副本奖励
	 * @param player
	 * @param cgGetDailyPlotDungeonReward
	 */
	public void handleGetDailyPlotDungeonReward(Player player,CGGetDailyPlotDungeonReward cgGetDailyPlotDungeonReward) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.PLOT_DUNGEON)){
			return;
		}
		//副本类型是否正确
		int plotDungeonType = cgGetDailyPlotDungeonReward.getPlotDungeonType();
		if(DungeonType.valueOf(plotDungeonType) == null){
			Loggers.plotDungeonLogger.error("handleGetDailyPlotDungeonReward DungeonType is invalid!charId = " + player.getHuman().getCharId()
			+";type = " + plotDungeonType);
			return;
		}
		
		//副本章数是否正确
		int plotDungeonChapter = cgGetDailyPlotDungeonReward.getPlotDungeonChapter();
		int chapterMaxNum = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonChapterNumByType(DungeonType.EASY);
		if(plotDungeonChapter > chapterMaxNum
				|| plotDungeonChapter <= 0){
			Loggers.plotDungeonLogger.error("handleGetDailyPlotDungeonReward plotDungeonChapter is invalid!charId = " + player.getHuman().getCharId()
			+";plotDungeonChapter = " + plotDungeonChapter);
			return;
		}
		Globals.getPlotDungeonService().getDailyPlotDungeonReward(player.getHuman(), plotDungeonType, plotDungeonChapter);
		
	}

	
	}
