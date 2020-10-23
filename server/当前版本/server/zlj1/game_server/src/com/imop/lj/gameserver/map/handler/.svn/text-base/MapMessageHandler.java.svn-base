
package com.imop.lj.gameserver.map.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.msg.CGMapFightNpc;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.gameserver.map.msg.CGMapPlayerMove;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class MapMessageHandler {	
	
	public MapMessageHandler() {	
	}	
		/**
 	* 玩家进入地图
 	* 
 	* CodeGenerator
 	*/
	public void handleMapPlayerEnter(Player player, CGMapPlayerEnter cgMapPlayerEnter) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int mapId = cgMapPlayerEnter.getMapId();
		if (mapId <= 0) {
			return;
		}
		Globals.getMapService().enterMap(player.getHuman(), mapId, true);
	}
		/**
 	* 玩家移动
 	* 
 	* CodeGenerator
 	*/
	public void handleMapPlayerMove(Player player, CGMapPlayerMove cgMapPlayerMove) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int mapId = cgMapPlayerMove.getMapId();
		int x = cgMapPlayerMove.getX();
		int y = cgMapPlayerMove.getY();
		int fx = cgMapPlayerMove.getFx();
		int fy = cgMapPlayerMove.getFy();
		if (mapId <= 0 || x <= 0 || y <= 0 || fx <= 0 || fy <= 0) {
			return;
		}
		
		Globals.getMapService().move(player.getHuman(), mapId, x, y, fx, fy);
	}
	
	/**
	 * 请求与npc进行战斗
	 * @param player
	 * @param cgMapFightNpc
	 */
	public void handleMapFightNpc(Player player, CGMapFightNpc cgMapFightNpc) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int npcId = cgMapFightNpc.getNpcId();
		if (npcId <= 0) {
			return;
		}
		
		Globals.getMapService().clickFightTarget(player.getHuman(), npcId, cgMapFightNpc.getUuid());
	}
	}
