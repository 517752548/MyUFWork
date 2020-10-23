package com.imop.lj.gameserver.map.model;

import java.awt.Point;
import java.io.File;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.FileUtils;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.common.model.map.MapPlayerInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.MoveInfo;
import com.imop.lj.gameserver.map.MapDef;
import com.imop.lj.gameserver.map.MapDef.ChangedType;
import com.imop.lj.gameserver.map.MapDef.DiffType;
import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.map.MapDef.TrendType;
import com.imop.lj.gameserver.map.msg.GCMapAddNpc;
import com.imop.lj.gameserver.map.msg.GCMapAddNpcList;
import com.imop.lj.gameserver.map.msg.GCMapPlayerChangedList;
import com.imop.lj.gameserver.map.msg.GCMapRemoveAddNpc;
import com.imop.lj.gameserver.map.msg.GCMapUpdateAddNpc;
import com.imop.lj.gameserver.map.msg.MapMsgBuilder;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.util.MapUtil;

public class AbstractGameMap implements IGameMap {
	// 每个Tile的类型
	/** 不能行走 */
	public static final short BLOCK_TILE = 0;
	/** 可以行走 */
	public static final short PATH_TILE = 1;
	/** 半透明 */
	public static final short MASK_TILE = 2;
	/** 非法 */
	public static final short INVALID_TILE = -1;
	
	public static final short PN_TILE = 3;

	/** 地图唯一Id */
	protected int id;

	/** 地图类型 */
	protected MapType type;

	/*** 地图公共数据 ***/
	/** 地图数据 */
	protected short[][] mapData;
	/** 地图中tile的行数 */
	protected int tileRows;
	/** 地图中tile的列数 */
	protected int tileCols;

	/** 地图内可用点，排除配置表中的npc */
	protected List<Integer> canUsePoint = new ArrayList<Integer>();
	protected static int base = 1000;
	/*** 地图公共数据 end***/
	
	/** 地图中动态NPC，由程序增加的，非配置的 */
	protected List<NpcInfo> addList = new ArrayList<NpcInfo>();
	
	/** 地图内所有的玩家，视情况看是否使用同步的map */
	protected Map<Long, Human> humans = new HashMap<Long, Human>();
	
	
	public AbstractGameMap(int id, MapType type) {
		this.id = id;
		this.type = type;
	}

	public void initMapData(String mapFile) throws Exception {
		// 初始化地图数据，解析XOo文件
		List<?> lines = FileUtils.readLines(new File(mapFile), "gb2312");
		if (lines.size() < 2) {
			throw new Exception("错误的地图文件格式(内容过少):" + mapFile);
		}
		if (lines.size() > 1) {
			Iterator<?> iter = lines.iterator();
			String paramline = (String) iter.next();
			String[] params = paramline.split(",");
			if (params.length < 4) {
				throw new Exception("错误的地图文件格式(参数不足):" + mapFile);
			}
			tileCols = Integer.parseInt(params[0]);
			tileRows = Integer.parseInt(params[1]);
			int tileWidth = Integer.parseInt(params[2]);
			int tileHeight = Integer.parseInt(params[3]);
			if (tileWidth != MapUtil.TILE_WIDTH
					|| tileHeight != MapUtil.TILE_HEIGHT) {
				throw new Exception("tile width or height is invalid!");
			}

			mapData = new short[tileRows][tileCols];
			if (lines.size() < tileRows + 1) {
				throw new Exception("错误的地图文件格式(地图行数不足):" + mapFile);
			}

			int row = 0;
			while (iter.hasNext()) {
				String line = (String) iter.next();
				if (line.equals("PATH") || line.equals("Area")
						|| line.equals("Monster")) {
					continue;
				}
				if (line.length() < tileCols) {
					throw new Exception("错误的地图文件格式(地图列数不足):" + mapFile);
				}
				for (int i = 0; i < tileCols; i++) {
					switch (line.charAt(i)) {
					case 'X': 
						mapData[row][i] = BLOCK_TILE;
						break;
					case 'O':
						mapData[row][i] = PATH_TILE;
						//可用点，去除配置表中的npc
						int p = calcPoint(i, row);
						if (!Globals.getTemplateCacheService().getMapTemplateCache().isNpcPoint(getId(), p)) {
							canUsePoint.add(p);
						}
						break;
					case 'o':
						mapData[row][i] = MASK_TILE;
						break;
					}
				}
				row++;
			}
			
			//修正，可走格子的相邻格子都可走
			for (int i = 0; i < mapData.length; i++) {
				for (int j = 0; j < mapData[i].length; j++) {
					if (mapData[i][j] == PATH_TILE || mapData[i][j] == MASK_TILE) {
						//相邻的四个格子均可走
						setNeighorCanWalk(i, j);
					}
				}
			}
		}

	}
	
	protected void setNeighorCanWalk(int i, int j) {
//		设点P(x,y) 则x=j,y=i
//		周围八个点依次为：
//		x,y-2
//		x,y-1
//		x-1,y
//		x,y+1
//		x,y+2
//		x+1,y+1
//		x+1,y
//		x+1,y-1
		if (mapData[i][j] == PATH_TILE || mapData[i][j] == MASK_TILE) {
			//x,y-2
			int a1 = i - 2;
			if (a1 > 0 && a1 < mapData.length) {
				if (mapData[a1][j] == BLOCK_TILE) mapData[a1][j] = PN_TILE;
			}
			
			//x,y-1
			int a2 = i - 1;
			if (a2 > 0 && a2 < mapData.length) {
				if (mapData[a2][j] == BLOCK_TILE) mapData[a2][j] = PN_TILE;
				
				//x+1,y-1
				int a8 = j + 1;
				if (a8 > 0 && a8 < mapData[a2].length) {
					if (mapData[a2][a8] == BLOCK_TILE) mapData[a2][a8] = PN_TILE;
				}
			}
			
			//x-1,y
			int a3 = j - 1;
			if (a3 > 0 && a3 < mapData[i].length) {
				if (mapData[i][a3] == BLOCK_TILE) mapData[i][a3] = PN_TILE;
			}
			
			//x,y+1
			int a4 = i + 1;
			if (a4 > 0 && a4 < mapData.length) {
				if (mapData[a4][j] == BLOCK_TILE) mapData[a4][j] = PN_TILE;
				
				//x+1,y+1
				int a6 = j + 1;
				if (a6 > 0 && a6 < mapData[a4].length) {
					if (mapData[a4][a6] == BLOCK_TILE) mapData[a4][a6] = PN_TILE;
				}
			}
			
			//x,y+2
			int a5 = i + 2;
			if (a5 > 0 && a5 < mapData.length) {
				if (mapData[a5][j] == BLOCK_TILE) mapData[a5][j] = PN_TILE;
			}
			
			//x+1,y
			int a7 = j + 1;
			if (a7 > 0 && a7 < mapData[i].length) {
				if (mapData[i][a7] == BLOCK_TILE) mapData[i][a7] = PN_TILE;
			}
		}
	}
	
	public int getId() {
		return id;
	}

	public MapType getType() {
		return type;
	}
	
	public short[][] getMapData() {
		return mapData;
	}

	public int getTileRows() {
		return tileRows;
	}

	public int getTileCols() {
		return tileCols;
	}

	public static int calcPoint(int x, int y) {
		return base * x + y;
	}
	
	/**
	 * 计算点的x值
	 * @param p
	 * @return
	 */
	public static int calcPointX(int p) {
		return p / base;
	}
	
	/**
	 * 计算点的y值
	 * @param p
	 * @return
	 */
	public static int calcPointY(int p) {
		return p % base;
	}
	
	/**
	 * 判断是否在区域内
	 * @param x 当前x
	 * @param y 当前y
	 * @param dx 目的x
	 * @param dy 目的y
	 * @param offset 偏移量
	 * @return
	 */
	public static boolean inArea(int x, int y, int dx, int dy, int offset) {
		if(offset <= 0){
			return false;
		}
		if(Math.sqrt((x-dx)^2 + (y-dy)^2) > offset){
			return false;
		}
		return true;
	}
	

	public MapTemplate getMapTemplate() {
		return Globals.getTemplateCacheService()
				.get(getId(), MapTemplate.class);
	}

	public int getMapWidth() {
		if (getMapTemplate() != null) {
			return getMapTemplate().getWidth();
		}
		return 0;
	}

	public int getMapHeight() {
		if (getMapTemplate() != null) {
			return getMapTemplate().getHeight();
		}
		return 0;
	}
	
	protected void addHuman(Human human) {
		humans.put(human.getCharId(), human);
	}
	
	protected void delHuman(Human human) {
		humans.remove(human.getCharId());
	}
	
	public DiffType getDiffType(Human screenHuman, int x1, int y1, int x2, int y2) {
		if (screenHuman.getPlayer() != null) {
			return getDiffType(x1, y1, x2, y2, 
					screenHuman.getPlayer().getScreenWidth(), screenHuman.getPlayer().getScreenHeight());
		}
		return DiffType.FAR;
	}

	/**
	 * 根据像素坐标，判断两个点的距离类型，近or远
	 * 
	 * @param x1
	 * @param y1
	 * @param x2
	 * @param y2
	 * @return
	 */
	protected DiffType getDiffType(int x1, int y1, int x2, int y2, int screenWidth, int screenHeight) {
        int mapWidth = getMapWidth();
        int mapHeight = getMapHeight();

        //默认以角色为中心的半屏范围可视
        int halfScreenWidth = screenWidth / 2;
        int halfScreenHeight = screenHeight / 2;
        int rectWidth = halfScreenWidth;
        int rectHeight = halfScreenHeight;
        
        //左右边界情况
        if (x1 < halfScreenWidth)
        {
            rectWidth = screenWidth - x1;
        }
        if (x1 > mapWidth - halfScreenWidth)
        {
            rectWidth = screenWidth - (mapWidth - x1);
        }
        //上下边界情况
        if (y1 < halfScreenHeight)
        {
            rectHeight = screenHeight - y1;
        }
        if (y1 > mapHeight - halfScreenHeight)
        {
        	rectHeight = screenHeight - (mapHeight - y1);
        }
        if (Math.abs(x2 - x1) < rectWidth && Math.abs(y2 - y1) < rectHeight)
        {
            return DiffType.NEAR;
        }
        return DiffType.FAR;
	}

	public TrendType getTrendType(Human screenHuman, int x, int y, int dx, int dy, Human humanB) {
		int diffOld = getDiffType(screenHuman, x, y, humanB.getX(), humanB.getY()).getIndex();
		int diffNew = getDiffType(screenHuman, dx, dy, humanB.getX(), humanB.getY()).getIndex();
		
		return TrendType.valueOf(diffOld * 2 + diffNew);
	}

	@Override
	public boolean canUserEnterMap(long roleId, boolean isClient) {
		//XXX 条件检查，玩家能否进入指定地图
		int humanLevel = 0;
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			humanLevel = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman().getLevel();
		} else {
			UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
			if (userSnap != null) {
				humanLevel = userSnap.getLevel();
			}
		}
		MapTemplate mapTpl = getMapTemplate();
		if (mapTpl != null && humanLevel >= mapTpl.getOpenLevel()) {
			return true;
		}
		return false;
	}
	
	@Override
	public boolean userEnterMap(Human human, boolean isLogin, boolean isClient, int x, int y) {
		if (x > 0 && y > 0) {
			Point tilePoint = MapUtil.image2TileCoord(x, y);
			if (canWalk(tilePoint.x, tilePoint.y)) {
				return userEnterMapPoint(human, isLogin, x, y);
			}
		}
		
		return userEnterMap(human, isLogin, isClient);
	}
	
	@Override
	public boolean userEnterMap(Human human, boolean isLogin, boolean isClient) {
		return userEnterMapPoint(human, isLogin, 0, 0);
	}
	
	/**
	 * 玩家进入地图的指定点
	 * @param human
	 * @param isLogin
	 * @param x
	 * @param y
	 * @return
	 */
	protected boolean userEnterMapPoint(Human human, boolean isLogin, int x, int y) {
		if (isUserInMap(human)) {
			// 玩家已经在地图中了，不能重复进入
			Loggers.humanLogger.error("error!user in map now!" + human.getCharId());
			return false;
		}

		//该地图中加入玩家
		addHuman(human);
		
		//默认为地图的初始点
		int initX = getTemplate().getInitX();
		int initY = getTemplate().getInitY();
		//如果指定了点，则到指定点
		if (x > 0 && y > 0) {
			initX = x;
			initY = y;
		}
		// 玩家进入地图
		human.onEnterMap(this, isLogin, initX, initY);

		List<MapPlayerInfo> neighborList = new ArrayList<MapPlayerInfo>();
		int neighborListCount = 0;
		// 通知附近的人，有人来了
		ChangedType cType = ChangedType.ADD;
		
		//这里根据情况决定是即时发还是延迟发
		GCMapPlayerChangedList hMsg = null;
		MapPlayerInfo hInfo = null;
		boolean needDelayPos = Globals.getHumanPosService().needDelayPos();
		if (needDelayPos) {
			hInfo = MapMsgBuilder.buildMapPlayerInfo(human, cType);
		} else {
			hMsg = MapMsgBuilder.buildHumanMapInfoChangedMsg(human, cType);
		}
		
		for (Human h : humans.values()) {
			//排除自己
			if (h.getCharId() == human.getCharId()) {
				continue;
			}
			
			//自己能看到的其他人
			if (DiffType.NEAR == getDiffType(human, human.getX(), human.getY(),	h.getX(), h.getY())) {
				if (neighborListCount < MapDef.MAP_PLAYER_CHANGED_LIST_MAX) {
					neighborList.add(MapMsgBuilder.buildMapPlayerInfo(h, cType));
					neighborListCount++;
				}
			}
			//其他人能看到自己
			if (DiffType.NEAR == getDiffType(h, human.getX(), human.getY(),	h.getX(), h.getY())) {
				if (needDelayPos) {
					//延迟发
					h.addLocationInfo(hInfo);
				} else {
					//即时发
					h.sendMessage(hMsg);
				}
			}
		}

		// 通知客户端 玩家进入地图
		human.sendMessage(MapMsgBuilder.buildPlayerEnterMsg(human));
		// 通知客户端 周围玩家列表
		if (!neighborList.isEmpty()) {
			human.sendMessage(MapMsgBuilder.buildMapPlayerInfoList(getId(), neighborList));
		}

		//发送地图中动态的npc列表
		human.sendMessage(new GCMapAddNpcList(getAddNpcList().toArray(new NpcInfo[0])));
		
		return true;
	}
	
	@Override
	public boolean canUserLeaveMap(Human human, boolean isClient) {
		if (!isUserInMap(human)) {
			// 玩家没在该地图，不需要退出
			return false;
		}
		return true;
	}

	@Override
	public boolean userLeaveMap(Human human, boolean isClient) {
		if (!canUserLeaveMap(human, isClient)) {
			// 玩家没在该地图，不需要退出
			return false;
		}
		
		//该地图中移除玩家
		delHuman(human);

		// 玩家离开地图
		human.onLeaveMap();

		//这里根据情况决定是即时发还是延迟发
		boolean needDelayPos = Globals.getHumanPosService().needDelayPos();
		if (needDelayPos) {
			//延迟发
			MapPlayerInfo delInfo = MapMsgBuilder.buildMapPlayerInfo(human, ChangedType.DELETE);
			for (Human h : humans.values()) {
				//排除自己
				if (h.getCharId() != human.getCharId()) {
					//自己能看到的人 和 能看到自己的人 都算附近的人
					if (DiffType.NEAR == getDiffType(human, human.getX(), human.getY(),	h.getX(), h.getY()) ||
							DiffType.NEAR == getDiffType(h, human.getX(), human.getY(),	h.getX(), h.getY())) {
						h.addLocationInfo(delInfo);
					}
				}
			}
		} else {
			//即时发
			broadcastToNear(human,
					MapMsgBuilder.buildHumanMapInfoChangedMsg(human, ChangedType.DELETE));
		}

		return true;
	}

	@Override
	public boolean userMove(Human human, int dx, int dy, int fx, int fy) {
		//像素坐标转为tile坐标
		Point tilePoint = MapUtil.image2TileCoord(dx, dy);
		Point fTilePoint = MapUtil.image2TileCoord(fx, fy);
		
		// 检查是否作弊，如果是，则拉回原位置
		if (isUserMoveCheat(human, dx, dy, tilePoint.x, tilePoint.y)) {
			human.sendMessage(MapMsgBuilder.buildSetPositionMsg(human.getCharId(), 
					human.getMapId(), human.getX(), human.getY()));
			return false;
		}
		
		//其他玩家对该移动玩家发生的变化
		List<MapPlayerInfo> changedList = new ArrayList<MapPlayerInfo>();
		//初始值为human上当前有的条数
		int changedListCount = human.getCurLocInfoListSize();
		
		//该玩家相对其他玩家发生的变化，给别人发的时候，发的是玩家移动目标点，为了看起来效果更好一些
		MapPlayerInfo moveInfo = MapMsgBuilder.buildPlayerMoveInfo(human, dx, dy, fTilePoint.x, fTilePoint.y);
		MapPlayerInfo delInfo = MapMsgBuilder.buildMapPlayerInfo(human, ChangedType.DELETE);
		MapPlayerInfo addInfo = MapMsgBuilder.buildMapPlayerInfo(human, ChangedType.ADD);
		//其他玩家的位置列表中，该移动的玩家变化
		for (Human h : humans.values()) {
			if (h.getCharId() == human.getCharId()) {
				continue;
			}
			
			TrendType tType = getTrendType(human, human.getX(), human.getY(), dx, dy, h);
			switch (tType) {
			case TREND_NEAR_2_NEAR:
//				h.addLocationInfo(moveInfo);
				break;
			case TREND_NEAR_2_FAR:
//				h.addLocationInfo(delInfo);
				if (changedListCount < MapDef.MAP_PLAYER_CHANGED_LIST_MAX) {
					changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.DELETE));
					changedListCount++;
				}
				break;
			case TREND_FAR_2_NEAR:
//				h.addLocationInfo(addInfo);
//				h.addLocationInfo(moveInfo);
				if (changedListCount < MapDef.MAP_PLAYER_CHANGED_LIST_MAX) {
					changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.ADD));
					changedListCount++;
				}
				break;
			case TREND_FAR_2_FAR:
				break;
			default:
				break;
			}
			
			TrendType tType_h = getTrendType(h, human.getX(), human.getY(), dx, dy, h);
			switch (tType_h) {
			case TREND_NEAR_2_NEAR:
				h.addLocationInfo(moveInfo);
				break;
			case TREND_NEAR_2_FAR:
				h.addLocationInfo(delInfo);
//				changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.DELETE));
				break;
			case TREND_FAR_2_NEAR:
				h.addLocationInfo(addInfo);
				h.addLocationInfo(moveInfo);
//				changedList.add(MapMsgBuilder.buildMapPlayerInfo(h, ChangedType.ADD));
				break;
			case TREND_FAR_2_FAR:
				break;
			default:
				break;
			}
		}
		
		//玩家可见的其他玩家列表变化
		human.addLocationInfoList(changedList);
		
		//更新nextMoves
		human.onPositionChanging(dx, dy);
		
		//设置玩家位置
		human.setX(dx);
		human.setY(dy);
		human.setTileX(tilePoint.x);
		human.setTileY(tilePoint.y);
		//设置备用地图坐标
		if (isEternal()) {
			human.setBackX(dx);
			human.setBackY(dy);
			
			//如果玩家是队长，则更新队伍备用地图
	        if (Globals.getTeamService().isTeamLeader(human.getCharId())) {
	        	Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
				team.setBackX(human.getBackX());
				team.setBackY(human.getBackY());
	        }
		}
		
		//最后一次移动时间
		human.setLastMoveTime(Globals.getTimeService().now());
		//移动数据缓存
		human.addMoveInfo(new MoveInfo(human.getMapId(), human.getLastMoveTime(), human.getX(), human.getY()));
		
		//移动时需要更新一些状态等
		human.onPositionChanged();
		
		return true;
	}
	
	/**
	 * 当human的MapPlayerInfo更改时，通知附近玩家
	 * @param human
	 * @param isDelay 一般情况true即可，除非特殊的需要立即通知的情况为false
	 */
	public void noticeNearMapInfoChanged(Human human, boolean isDelay) {
		ChangedType ct = ChangedType.UPDATE;
		for (Human h : humans.values()) {
			//排除自己
			if (h.getCharId() != human.getCharId()) {
				//能看到自己的人
				if (DiffType.NEAR == getDiffType(h, human.getX(), human.getY(),	h.getX(), h.getY())) {
					//延迟通知
					if (isDelay) {
						h.addLocationInfo(MapMsgBuilder.buildMapPlayerInfo(human, ct));
					} else {
						//立即通知
						h.sendMessage(MapMsgBuilder.buildHumanMapInfoChangedMsg(human, ct));
					}
				}
			}
		}
	}

	@Override
	public boolean groupEnterMap(Human leader) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean groupLeaveMap(Human leader) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public void broadcastToNear(Human human, GCMessage msg) {
		for (Human h : humans.values()) {
			//排除自己
			if (h.getCharId() != human.getCharId()) {
				//自己能看到的人 和 能看到自己的人 都算附近的人
				if (DiffType.NEAR == getDiffType(human, human.getX(), human.getY(),	h.getX(), h.getY()) ||
						DiffType.NEAR == getDiffType(h, human.getX(), human.getY(),	h.getX(), h.getY())) {
					h.sendMessage(msg);
				}
			}
		}
	}

	@Override
	public void broadcastToMap(GCMessage msg) {
		for (Human h : humans.values()) {
			h.sendMessage(msg);
		}
	}

	@Override
	public boolean isUserInMap(Human human) {
		return humans.containsKey(human.getCharId());
	}
	
	/**
	 * 检查用户移动是否作弊
	 * 
	 * 作弊条件： 两次移动时间间隔较短 移动速度过快 目标点不能走
	 */
	public boolean isUserMoveCheat(Human human, int dx, int dy, int tileX, int tileY) {
		//是否不能走的点
		if (!canWalk(tileX, tileY)) {
			Loggers.humanLogger.warn("目标点不能走(x:" +tileX+ ", y:" +tileY+ ") + (dx="+dx+",dy="+dy+") mapid=" + getId() 
					+ ";humanId=" + human.getCharId() + ";name=" + human.getName());
			return true;
		}
		
		//如果未开启移动速度限制，直接返回
		if (!SharedConstants.MOVE_SPEED_LIMIT_OPEN) {
			return false;
		}
		
//		//移动时间间隔 XXX 这个先不检测了。。。
		long now = Globals.getTimeService().now();
//		if (now - user.getLastMoveTime() < SharedConstants.MOVE_TIME_MIN) {
//			Loggers.humanLogger.warn("两次移动时间间隔过短(last:"+user.getLastMoveTime()+", now:"+now+";diff=" + (now - user.getLastMoveTime()));
//			return true;
//		}
		
		//移动速度 TODO 类似运粮这类任务，需要验证玩家是否在npc附近，超过一定范围则视为作弊
//		double toMove = Math.sqrt((dx-human.getX())*(dx-human.getX())+(dy-human.getY())*(dy-human.getY()));
//		if (toMove < 1) {
//			Loggers.humanLogger.warn("移动距离过短(toMove:%d)", toMove);
//			return true;
//		}
		
		//TODO FIXME 有卡包的情况，即可能会一起发好几个包过来，这时服务器计算后就会是作弊
		
		//没有移动数据，按作弊算，正常不会走到这里
		if (human.isMoveQueueEmpty()) {
			Loggers.humanLogger.warn("moveInfo queue is empty!humanId=" + human.getCharId());
			return true;
		}
		
		//检查最近几次的行走记录，只要有一个数据合法就不算作弊，因为客户端发包时间和服务器收包时间不一致，会延迟
		int start = human.getMoveQueueSize() - 1;
		for (int i = start; i >= 0; i--) {
			MoveInfo moveInfo = human.getMoveInfo(i);
			if (moveInfo != null && 
					human.getMapId() == moveInfo.getMapId()) {
				double toMove = Math.sqrt((dx-moveInfo.getX())*(dx-moveInfo.getX())+(dy-moveInfo.getY())*(dy-moveInfo.getY()));
				long deltaTime = now + SharedConstants.GS_HEART_BEAT_INTERVAL - moveInfo.getMoveTime();
				//客户端正常情况下最短1秒发一次move，如果收到的消息时间间隔小于1秒，则可能是网络延迟造成的，所以如此。当然也存在作弊的情况，暂时先不管。
				if (deltaTime < SharedConstants.MOVE_DELTA_TIME) {
					deltaTime = SharedConstants.MOVE_DELTA_TIME;
				}
				//加一个心跳的偏差
				double speed = toMove * 1000 / deltaTime;
				
				//只要有一个数据合法，就不算作弊
				if (speed <= SharedConstants.MOVE_SPEED_MAX) {
					return false;
				} else {
					Loggers.humanLogger.warn("移动速度过快(cur:" + speed + ", max:" + SharedConstants.MOVE_SPEED_MAX + ")" + 
							";moveInfo=" + moveInfo + ";count=" + i 
							+ ";humanId=" + human.getCharId() + ";name=" + human.getName());
				}
			} else {
				break;
			}
		}
		
		for (int i = 0; i < SharedConstants.MOVE_INFO_QUEUE_SIZE; i++) {
			MoveInfo moveInfo = human.getMoveInfo(i);
			if (moveInfo != null) {
				Loggers.humanLogger.warn("failed move!moveInfo=" + moveInfo + ";humanId=" + human.getCharId());
			}
		}
		
		return true;
	}
	
	public boolean canWalk(int x, int y) {
		short tile = getTileType(x, y);
		return (tile == PATH_TILE || tile == MASK_TILE || tile == PN_TILE);
	}
	
	protected short getTileType(int x, int y) {
		if ((x < 0) || (y < 0)) {
			return INVALID_TILE;
		}
		
		if (x >= getTileCols() || y >= getTileRows()) {
			return INVALID_TILE;
		}
		else {
			return getMapData()[y][x];
		}
	}
	
	public NpcInfo getAddNpc(String npcUUID) {
		for (NpcInfo info : addList) {
			if (info.getUuid().equalsIgnoreCase(npcUUID)) {
				return info;
			}
		}
		return null;
	}
	
	public boolean isAddNpc(String npcUUID) {
		for (NpcInfo info : addList) {
			if (info.getUuid().equalsIgnoreCase(npcUUID)) {
				return true;
			}
		}
		return false;
	}

	public void fightNpc(Human human, NpcInfo npcInfo) {
		//默认的npc战斗，不进行广播
		Globals.getMapService().mapFightNpc(human, npcInfo, false);
	}
	
	public List<NpcInfo> getAddNpcList() {
		return addList;
	}

	/**
	 * 获取地图中可用的点（格子点，非像素点）
	 * 注意：未排除动态添加的NPC，如果外层需要，则自己排除
	 * @return 返回的点需要通过 {@link AbstractGameMap#calcPointX(int)}获取x，{@link AbstractGameMap#calcPointY(int)}获取y
	 */
	public List<Integer> getCanUsePoint() {
		return canUsePoint;
	}
	
	/**
	 * 获取地图中可用的点（格子点，非像素点）
	 * 排除了所有npc
	 * @return 返回的点需要通过 {@link AbstractGameMap#calcPointX(int)}获取x，{@link AbstractGameMap#calcPointY(int)}获取y
	 */
	public List<Integer> getReallyCanUsePoint() {
		//获取地图中可用的点
		List<Integer> fList = new ArrayList<Integer>();
		fList.addAll(getCanUsePoint());
		//去除附加的npc占用的点
		List<Integer> rmList = new ArrayList<Integer>();
		List<NpcInfo> addList = getAddNpcList();
		for (NpcInfo npcInfo : addList) {
			int p = AbstractGameMap.calcPoint(npcInfo.getX(), npcInfo.getY());
			rmList.add(p);
		}
		fList.removeAll(rmList);
		return fList;
	}
	
	/**
	 * 获取地图中动态npc已经占用的位置
	 * @return
	 */
	public List<Integer> getAddNpcUsedPoint() {
		List<Integer> rmList = new ArrayList<Integer>();
		for (NpcInfo npcInfo : addList) {
			int p = AbstractGameMap.calcPoint(npcInfo.getX(), npcInfo.getY());
			rmList.add(p);
		}
		return rmList;
	}
	
	public boolean removeAddNpc(String npcUUID) {
		int rm = -1;
		for (int i = 0; i < addList.size(); i++) {
			NpcInfo info = addList.get(i);
			if (info.getUuid().equalsIgnoreCase(npcUUID)) {
				rm = i;
				break;
			}
		}
		if (rm >= 0) {
			addList.remove(rm);
			//广播地图中的玩家，删除了一个npc
			broadcastToMap(new GCMapRemoveAddNpc(new String[]{npcUUID}));
			return true;
		}
		return false;
	}
	
	public void addNpc(NpcInfo npc) {
		addList.add(npc);
		//广播地图中的玩家，增加了一个npc
		broadcastToMap(new GCMapAddNpc(npc));
	}
	
	public void clearAllAddNpc() {
		List<String> rList = new ArrayList<String>();
		for (NpcInfo info : addList) {
			rList.add(info.getUuid());
		}
		addList.clear();
		//广播地图中的玩家，npc没了
		broadcastToMap(new GCMapRemoveAddNpc(rList.toArray(new String[0])));
	}
	
	public void noticeUpdateAddNpc(NpcInfo info) {
		if (addList.contains(info)) {
			broadcastToMap(new GCMapUpdateAddNpc(info));
		}
	}

	/**
	 * 是否一张永久性地图
	 * @return
	 */
	public boolean isEternal() {
		return true;
	}
	
	public MapTemplate getTemplate() {
		return Globals.getTemplateCacheService().get(getId(), MapTemplate.class);
	}
	
	public Collection<Human> getAllHumans() {
		return Collections.unmodifiableCollection(humans.values());
	}
	
}
