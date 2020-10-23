package com.imop.lj.gameserver.map.msg;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.map.MapPlayerInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.ChangedType;

public class MapMsgBuilder {
	
	public static GCMapPlayerChangedList buildHumanMapInfoChangedMsg(Human human, ChangedType cType) {
		GCMapPlayerChangedList msg = new GCMapPlayerChangedList();
		msg.setMapId(human.getMapId());
		
		MapPlayerInfo info = buildMapPlayerInfo(human, cType);
		List<MapPlayerInfo> lst = new ArrayList<MapPlayerInfo>();
		lst.add(info);
		
		msg.setMapPlayerInfoDataList(lst.toArray(new MapPlayerInfo[0]));
		return msg;
	}
	
	public static GCMapPlayerChangedList buildMapPlayerInfoList(int mapId, List<MapPlayerInfo> lst) {
		GCMapPlayerChangedList msg = new GCMapPlayerChangedList();
		msg.setMapId(mapId);
		msg.setMapPlayerInfoDataList(lst.toArray(new MapPlayerInfo[0]));
		return msg;
	}
	
	public static MapPlayerInfo buildMapPlayerInfo(Human human, ChangedType cType) {
		MapPlayerInfo info = new MapPlayerInfo();
		
		info.setMsgType(cType.getIndex());
		
		info.setUuid(human.getCharId());
		switch (cType) {
		case DELETE:
			//删除只设置uuid即可
			break;
		case MOVE:
		case ADD:
		case UPDATE:
			info.setName(human.getName());
			info.setLevel(human.getLevel());
			info.setMapId(human.getMapId());
			info.setModel(human.getModelId());
			info.setTileX(human.getTileX());
			info.setTileY(human.getTileY());
			info.setX(human.getX());
			info.setY(human.getY());
			info.setIsLeader(Globals.getTeamService().isTeamLeader(human.getCharId()) ? 1 : 0);
			info.setIsFighting(human.isInAnyBattle() ? 1 : 0);
			info.setRideHorseTplId(Globals.getOfflineDataService().getRidingHorseTplId(human));
			info.setTitleName(Globals.getTitleService().getCurrentTitleName(human.getCharId()));
			info.setIsForaging(human.isDoingForageTask() ? 1 : 0);
			info.setCorpsId(Globals.getCorpsService().getUserCorpsId(human.getCharId()));
			info.setExtStr("");
			info.setWingTplId(human.getWingManager().getWingingTplId());
			info.setFashionTplId(Globals.getEquipService().getFashioningTplId(human));
			//玩家主将左右手武器模板Id
			info.setEquipWeaponId(Globals.getEquipService().getLeaderWeaponTplId(human.getCharId()));
			//vip等级
			info.setVipLevel(Globals.getVipService().getCurVipLevel(human.getCharId()));
			break;

		default:
			break;
		}
		return info;
	}
	
	public static MapPlayerInfo buildPlayerMoveInfo(Human human, int dx, int dy, int tileX, int tileY) {
		MapPlayerInfo info = buildMapPlayerInfo(human, ChangedType.MOVE);
		//move设置坐标
		info.setTileX(tileX);
		info.setTileY(tileY);
		info.setX(dx);
		info.setY(dy);
		return info;
	}
	
	public static GCMapPlayerEnter buildPlayerEnterMsg(Human human) {
		GCMapPlayerEnter msg = new GCMapPlayerEnter();
		msg.setUuid(human.getCharId());
		msg.setMapId(human.getMapId());
		msg.setX(human.getX());
		msg.setY(human.getY());
		return msg;
	}

	public static GCMapPlayerSetPosition buildSetPositionMsg(long uuid, int mapId, int dx, int dy) {
		GCMapPlayerSetPosition msg = new GCMapPlayerSetPosition();
		msg.setUuid(uuid);
		msg.setMapId(mapId);
		msg.setX(dx);
		msg.setY(dy);
		return msg;
	}
	
}
