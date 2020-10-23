package com.imop.lj.gameserver.tower.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.tower.TowerDef;
import com.imop.lj.gameserver.tower.msg.CGGuaji;
import com.imop.lj.gameserver.tower.msg.CGOpenDoubleStatus;
import com.imop.lj.gameserver.tower.msg.CGTowerInfo;
import com.imop.lj.gameserver.tower.msg.CGTowerReward;
import com.imop.lj.gameserver.tower.msg.CGWatchBestKillerReplay;
import com.imop.lj.gameserver.tower.msg.CGWatchFirstKillerReplay;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TowerMessageHandler {	
	
	public TowerMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player, boolean isLowerLevel){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if(!isLowerLevel){
			if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.TOWER)) {
				Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.TOWER);
				return false;
			}
		}
		if(!Globals.getTowerService().isOpening()){
			return false;
		}
		return true;
	}
	
		/**
 	* 请求打开通天塔面板
 	* 
 	* CodeGenerator
 	*/
	public void handleTowerInfo(Player player, CGTowerInfo cgTowerInfo) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		
		Globals.getTowerService().openTowerPanel(player.getHuman());
		
	}
		/**
 	* 请求开启双倍状态
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenDoubleStatus(Player player, CGOpenDoubleStatus cgOpenDoubleStatus) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		
		if(TowerDef.DoubleType.valueOf(cgOpenDoubleStatus.getOpenOrClose()) == null){
			return;
		}
		
	}
		/**
 	* 请求查看最先击败者
 	* 
 	* CodeGenerator
 	*/
	public void handleWatchFirstKillerReplay(Player player, CGWatchFirstKillerReplay cgWatchFirstKillerReplay) {
		if(!checkRoleAndFunc(player, false)){
			return;
		}
		int towerLevel = cgWatchFirstKillerReplay.getTowerLevel();
		
		if(!Globals.getTowerService().isValidTowerLevel(towerLevel)){
			return;
		}
		
		Globals.getTowerService().watchFirstKillerReplay(player.getHuman(), towerLevel);
	}
		/**
 	* 请求查看最优击败者
 	* 
 	* CodeGenerator
 	*/
	public void handleWatchBestKillerReplay(Player player, CGWatchBestKillerReplay cgWatchBestKillerReplay) {
		if(!checkRoleAndFunc(player,false)){
			return;
		}
		
		int towerLevel = cgWatchBestKillerReplay.getTowerLevel();
		if(!Globals.getTowerService().isValidTowerLevel(towerLevel)){
			return;
		}
		
		Globals.getTowerService().watchBestKillerReplay(player.getHuman(), towerLevel);
	}

	/**
	 * 请求查看通天塔奖励
	 * @param player
	 * @param cgTowerReward
	 */
	public void handleTowerReward(Player player, CGTowerReward cgTowerReward) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		
		Globals.getTowerService().sendTowerReward(player.getHuman());
	}

	/**
	 * 请求挂机
	 * @param player
	 * @param cgGuaji
	 */
	public void handleGuaji(Player player, CGGuaji cgGuaji) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		int mapId = cgGuaji.getMapId();
		//检查地图是否有效
		MapTemplate map = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if (map == null) {
			return;
		}
		
		Globals.getTowerService().startGuaji(player.getHuman(), mapId);
	}
}
