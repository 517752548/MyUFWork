package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerCorpsChangedEvent;
import com.imop.lj.gameserver.corps.model.CorpsMemberChangeInfo;
import com.imop.lj.gameserver.player.Player;

public class PlayerCorpsChangedListener implements IEventListener<PlayerCorpsChangedEvent> {

	/**
	 * 玩家加入或退出军团是的监听
	 */
	@Override
	public void fireEvent(PlayerCorpsChangedEvent event) {
		CorpsMemberChangeInfo info = event.getInfo();
		long presidentId = info.getPresidentId();
		long memId = info.getMemId();
		long corpsId = info.getCorpsId();
		//帮主和成员公用的方法,通过该字段来区分
		boolean isPresident = info.isPresident();
		boolean isInCorps = Globals.getCorpsService().inCorps(presidentId);

		if(isPresident){
			//处理帮主
			Player player = Globals.getOnlinePlayerService().getPlayer(presidentId);
			if (player != null && player.getHuman() != null && player.isInScene()) {
				
				
				//如果玩家推出了军团，还在军团地图，则回到之前的地图
				if (!isInCorps && 
						player.getHuman().getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId()) {
					//如果玩家处于组队状态，则需要先离开队伍
					if (Globals.getTeamService().isInTeamNormal(presidentId)) {
						Globals.getTeamService().playerLeaveTeam(player.getHuman());
					}
					//进入之前的地图
					Globals.getMapService().enterMap(player.getHuman(), player.getHuman().getBackMapId());
					
					//玩家已经退出军团，没有离开原军团地图，所以这里再单独获取军团地图让玩家离开
					if (Globals.getCorpsService().getCorpsMap(corpsId) != null) {
						Globals.getCorpsService().getCorpsMap(corpsId).userLeaveMap(player.getHuman(), false);
					}
				}
				
			}
		}
		if(!isPresident){
			//处理帮派成员
			boolean isInCorpsMem = Globals.getCorpsService().inCorps(memId);
			Player memPlayer = Globals.getOnlinePlayerService().getPlayer(memId);
			if (memPlayer != null && memPlayer.getHuman() != null && memPlayer.isInScene()) {
				
				
				//如果玩家推出了军团，还在军团地图，则回到之前的地图
				if (!isInCorpsMem && 
						memPlayer.getHuman().getMapId() == Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId()) {
					//如果玩家处于组队状态，则需要先离开队伍
					if (Globals.getTeamService().isInTeamNormal(memId)) {
						Globals.getTeamService().playerLeaveTeam(memPlayer.getHuman());
					}
					//玩家已经退出军团，没有离开原军团地图，所以这里再单独获取军团地图让玩家离开
					if (Globals.getCorpsService().getCorpsMap(corpsId) != null) {
						//进入之前的地图
						Globals.getMapService().enterMap(memPlayer.getHuman(), memPlayer.getHuman().getBackMapId(),
								memPlayer.getHuman().getBackX(), memPlayer.getHuman().getBackY(), Globals.getCorpsService().getCorpsMap(corpsId));
					}
				}
				
			}
		}
		
		//军团战处理
		Globals.getCorpsWarService().onPlayerCorpsChanged(presidentId, isInCorps);
		
		//帮派boss处理
		Globals.getCorpsBossService().onPlayerCorpsChanged(corpsId, isInCorps);
	}
}
