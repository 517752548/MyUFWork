package com.imop.lj.gameserver.map.model;

import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;

public interface IGameMap {

	boolean canUserEnterMap(long roleId, boolean isClient);
	
	boolean userEnterMap(Human human, boolean isLogin, boolean isClient);
	
	boolean userEnterMap(Human human, boolean isLogin, boolean isClient, int x, int y);
	
	boolean canUserLeaveMap(Human human, boolean isClient);
	
	boolean userLeaveMap(Human human, boolean isClient);
	
	boolean groupEnterMap(Human leader);
	
	boolean groupLeaveMap(Human leader);
	
	boolean userMove(Human human, int dx, int dy, int fx, int fy);
	
	void broadcastToNear(Human human, GCMessage msg);
	
	void broadcastToMap(GCMessage msg);

	boolean isUserInMap(Human human);
	
}
