package com.imop.lj.gameserver.map;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.GameConstants;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.model.CorpsMainMap;
import com.imop.lj.gameserver.map.model.DynamicGameMapBase;
import com.imop.lj.gameserver.map.model.NormalGameMap;
import com.imop.lj.gameserver.map.model.PetIslandMap;
import com.imop.lj.gameserver.map.model.TowerMap;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.team.model.Team;

public class MapService implements InitializeRequired {
	/** 不同等级地图的遇敌率，第一维是地图等级 */
	protected static double[][] PROBABILITY = {
		{0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0,		0},
		{0,		.03,	.03,	.03,	.04,	.04,	.04,	.05,	.05,	.05,	.05, 	.07},
		{0,		.05,	.06,	.07,	.08,	.09,	.10,	.11,	.12,	.13,	.14, 	.15,},
		{0,		.07,	.10,	.13,	.16,	.19,	.21,	.24,	.27,	.30,	.33, 	.40},
		{0,		.10,	.15,	.20,	.25,	.30,	.35,	.40,	.45,	.50,	.55, 	.60},
//		{0,		.10,	.15,	.20,	.40,	.45,	.50,	.55,	.60,	.65,	.80, 	.80},
//		{0,		.10,	.15,	.20,	.50,	.55,	.60,	.65,	.70,	.75,	.80, 	.90}
	};
	
	
	protected String resourceFolder;
	/** 所有地图对象Map，key为地图id */
	protected Map<Integer, AbstractGameMap> allGameMap = new HashMap<Integer, AbstractGameMap>();
	
	public MapService(String resourceFolder) {
		this.resourceFolder = resourceFolder;
	}

	@Override
	public void init() {
		for (MapTemplate mapTpl : Globals.getTemplateCacheService().getAll(MapTemplate.class).values()) {
			int mapId = mapTpl.getId();
			MapType mType = mapTpl.getMapType();
			
			AbstractGameMap gameMap = makeGameMap(mapId, mType);
			String path = resourceFolder + File.separator + mapTpl.getId() + Globals.getGameConstants().getMapFileType();
			
			try {
				gameMap.initMapData(path);
			} catch (Exception e) {
				e.printStackTrace();
				Loggers.gameLogger.error("init map exception!e=" + e);
				System.exit(1);
			}
			
			allGameMap.put(mapId, gameMap);
		}
	}
	
	/**
	 * 进行地图上的点的相关检查
	 */
	public void checkMapPointRelated() {
		Globals.getTemplateCacheService().getMapTemplateCache().checkNpcPoint();
		Globals.getTemplateCacheService().getMapTemplateCache().checkWizardRaidPoint();
		Globals.getTemplateCacheService().getMapTemplateCache().checkSiegeDemonPoint();
	}

	protected AbstractGameMap makeGameMap(int mapId, MapType mType) {
		AbstractGameMap gameMap = null;
		//XXX 添加类型时从这加
		switch (mType) {
		case NORMAL:
			gameMap = new NormalGameMap(mapId);
			break;
		case PET_ISLAND:
			gameMap = new PetIslandMap(mapId);
			break;
			
		//这里创建的是军团基础地图数据，不是真正的军团中的主城
		case CORPS_MAIN:
			gameMap = new AbstractGameMap(mapId, mType);
			break;
			
		//绿野仙踪基础数据地图
		case WIZARD_RAID:
			gameMap = new AbstractGameMap(mapId, mType);
			break;
			
		//围剿魔族基础数据地图
		case SIEGE_DEMON:
			gameMap = new AbstractGameMap(mapId, mType);
			break;
		
		//帮派竞赛基础数据地图
		case CORPS_WAR:
			gameMap = new AbstractGameMap(mapId, mType);
			break;
			
		//nvn联赛基础数据地图
		case NVN_WAR:
			gameMap = new AbstractGameMap(mapId, mType);
			break;
		//通天塔地图
		case TOWER:
			gameMap = new TowerMap(mapId);
			break;	
		default:
			break;
		}
		return gameMap;
	}
	
	public CorpsMainMap createCorpsMap(long corpsId) {
		return new CorpsMainMap(corpsId);
	}
	
	/**
	 * 获取固定的地图对象
	 * @param mapId
	 * @return
	 */
	public AbstractGameMap getGameMap(int mapId) {
		return allGameMap.get(mapId);
	}
	
	/**
	 * 根据玩家获取地图对象，固定的地图直接返回，动态地图根据类型返回
	 * @param mapId
	 * @param human
	 * @return
	 */
	public AbstractGameMap getGameMap(int mapId, long roleId) {
		AbstractGameMap ret = null;
		AbstractGameMap map = getGameMap(mapId);
		if (map == null) {
			return null;
		}
		
		MapType mType = map.getType();
		//XXX 根据不同类型获取
		switch (mType) {
		//军团主城地图，从军团中获取
		case CORPS_MAIN:
			if (roleId > 0) {
				ret = Globals.getCorpsService().getUserCorpsMap(roleId);
			}
			break;
		case WIZARD_RAID:
			if (roleId > 0) {
				ret = Globals.getWizardRaidService().getGameMap(roleId);
			}
			break;
		case SIEGE_DEMON:
			if (roleId > 0) {
				ret = Globals.getSiegeDemonService().getGameMap(roleId);
			}
			break;
		case CORPS_WAR:
			if (roleId > 0) {
				ret = Globals.getCorpsWarService().getGameMap(roleId);
			}
			break;
		case NVN_WAR:
			ret = Globals.getNvnService().getGameMap();
			break;
		default:
			ret = map;
			break;
		}
		
		return ret;
	}
	
	public void onPlayerLogin(Human human) {
		long roleId = human.getUUID();
		//判断玩家如果在队伍中，且为正常状态，则进入队长地图；否则进入自身上次离开的地图
		int mapId = Globals.getTeamService().checkNeedEnterTeamMapOnLogin(human);
		AbstractGameMap curMap = getGameMap(mapId, human.getCharId());
		if (curMap == null || !curMap.canUserEnterMap(roleId, false)) {
			//看备用地图是否可用
			curMap = getGameMap(human.getBackMapId());
			if (curMap == null || !curMap.canUserEnterMap(roleId, false)) {
				//强制进入初始地图
				curMap = getGameMap(Globals.getGameConstants().getInitMapId());
			}
		}
		
		boolean flag = curMap.canUserEnterMap(roleId, false);
		if (flag) {
			curMap.userEnterMap(human, true, false);
		} else {
			Loggers.mapLogger.error("cur map can not enter!humanId=" + roleId + ";mapId=" + mapId);
		}
		
		//如果玩家是队伍的队员，则发队长位置信息
		Globals.getTeamService().checkSendLeaderPositionOnLogin(human);
	}
	
	public void onPlayerLogout(Human human) {
		AbstractGameMap curMap = getGameMap(human.getMapId(), human.getCharId());
		if (curMap != null) {
			boolean flag = curMap.userLeaveMap(human, false);
			if (!flag) {
				Loggers.mapLogger.error("onPlayerLogout leave map failed!humanId=" + human.getCharId() + ";mapId=" + curMap.getId());
			}
		}
	}
	
	public boolean canEnterMap(Human human, int targetMapId, boolean isClient, AbstractGameMap curMap) {
		long roleId = human.getCharId();
		AbstractGameMap gameMap = getGameMap(targetMapId, roleId);
		if (null == gameMap) {
			return false;
		}
		
		if (human.getMapId() == targetMapId) {
			human.sendErrorMessage(LangConstants.MAP_ENTER_REPEAT_);
			Loggers.humanLogger.warn("human already in this map!humanId=" + roleId + "targetMapId=" + targetMapId);
			return false;
		}
		
		//能否离开原地图
		if (curMap == null) {
			curMap = getGameMap(human.getMapId(), roleId);
		}
		if (curMap != null) {
			if (!curMap.canUserLeaveMap(human, isClient)) {
				return false;
			}
		}
		
		//地图的条件检查
		if (!gameMap.canUserEnterMap(roleId, isClient)) {
			human.sendErrorMessage(LangConstants.MAP_ENTER_FAIL);
			Loggers.humanLogger.warn("human can not enter map!humanId=" + roleId + "targetMapId" + targetMapId);
			return false;
		}
		
		//队伍检查
		if (!Globals.getTeamService().canPlayerEnterMap(human, targetMapId)) {
			return false;
		}
		
		//战斗中不可以切换地图
		if(human.isInAnyBattle()){
			return false;
		}
		return true;
	}
	
	/**
	 * 玩家进入指定地图
	 * @param human
	 * @param targetMapId
	 * @param isClient 是否客户端CGMapPlayerEnter的请求
	 * @return
	 */
	public boolean enterMap(Human human, int targetMapId, boolean isClient) {
		return enterMap(human, targetMapId, 0, 0, isClient, null);
	}
	
	/**
	 * 玩家进入指定地图
	 * @param human
	 * @param targetMapId
	 * @return
	 */
	public boolean enterMap(Human human, int targetMapId) {
		return enterMap(human, targetMapId, 0, 0, false, null);
	}
	
	/**
	 * 玩家进入指定地图指定点
	 * @param human
	 * @param targetMapId
	 * @param x
	 * @param y
	 * @param curMap
	 * @return
	 */
	public boolean enterMap(Human human, int targetMapId, int x, int y, AbstractGameMap curMap) {
		return enterMap(human, targetMapId, x, y, false, curMap);
	}
	
	/**
	 * 玩家进入指定地图指定点
	 * @param human
	 * @param targetMapId
	 * @param x
	 * @param y
	 * @return
	 */
	public boolean enterMap(Human human, int targetMapId, int x, int y) {
		return enterMap(human, targetMapId, x, y, false, null);
	}
	
	/**
	 * 玩家进入指定地图
	 * @param human
	 * @param targetMapId 目标地图id
	 * @param x 进入地图的指定点x像素坐标
	 * @param y 进入地图的指定点y像素坐标
	 * @param isClient 是否客户端CGMapPlayerEnter的请求
	 * @param curMap 玩家当前所在地图，为null则会调用getGameMap获取，不为null则使用该参数。
	 * 				如绿野仙踪副本，在玩家退队的时候，需要退出副本地图，此时玩家已经退出队伍，getGameMap获取不到，所以直接传入当前地图
	 * @return 是否成功进入
	 */
	protected boolean enterMap(Human human, int targetMapId, int x, int y, 
			boolean isClient, AbstractGameMap curMap) {
		//地图的条件检查
		if (!canEnterMap(human, targetMapId, isClient, curMap)) {
//			human.sendErrorMessage(LangConstants.MAP_ENTER_FAIL);
			return false;
		}
		
		long roleId = human.getCharId();
		AbstractGameMap gameMap = getGameMap(targetMapId, roleId);
		
		//玩家离开原地图
		if (curMap == null) {
			curMap = getGameMap(human.getMapId(), roleId);
		}
		if (curMap != null) {
			boolean leaveFlag = curMap.userLeaveMap(human, isClient);
			if (!leaveFlag) {
				Loggers.humanLogger.error("human leave self map failed!humanId=" + roleId 
						+ "targetMapId=" + targetMapId + ";selfMapId=" + human.getMapId());
				return false;
			}
		} else {
			Loggers.mapLogger.warn("curMap is null,may the human still in old map,not removed!roleId=" + roleId
					+ ";human.curMapId=" + human.getMapId());
		}
		
		//玩家进入新地图
		boolean flag = gameMap.userEnterMap(human, false, isClient, x, y);
		if (!flag) {
			Loggers.humanLogger.error("human enter map failed!humanId=" + roleId + "targetMapId=" + targetMapId);
		} else {
			//队长进入地图后，队员需进入
			Globals.getTeamService().onLeaderEnterMap(human);
		}
		return flag;
	}
	
	/**
	 * 玩家在本身地图中移动
	 * @param human
	 * @param mapId
	 * @param dx 玩家当前x坐标
	 * @param dy 玩家当前y坐标
	 * @param fx 玩家移动目标点x坐标
	 * @param fy 玩家移动目标点y坐标
	 */
	public void move(Human human, int mapId, int dx, int dy, int fx, int fy) {
		//检查地图id是否合法
		if (human.getMapId() != mapId) {
			Loggers.humanLogger.warn("human move failed,not in self map!humanId=" + human.getCharId() + 
					"curMapId=" + human.getMapId() + ";moveMapId=" + mapId);
			return;
		}
		
		AbstractGameMap gameMap = getGameMap(human.getMapId(), human.getCharId());
		if (null == gameMap) {
			return;
		}
		
		//战斗中，不能再移动
		if (human.isInAnyBattle()) {
			return;
		}
		
		//玩家是否进入战斗的判断，如果进入战斗，则未来要走的点就是当前点，因为会停在那里
		boolean canStartBattle = canStartBattle(human);
		if (canStartBattle) {
			fx = dx;
			fy = dy;
		}
		
		//处理玩家移动
		boolean flag = gameMap.userMove(human, dx, dy, fx, fy);
		if (!flag) {
			Loggers.humanLogger.warn("human move failed,may be cheat!humanId=" + human.getCharId() + 
					"curMapId=" + human.getMapId() + ";moveMapId=" + mapId);
		} else {
			//队长移动，队员需要跟随
			Globals.getTeamService().onLeaderMove(human);
		}
		
		//进入战斗
		if (canStartBattle) {
			Globals.getBattleService().meetMapMonsterBattle(human);
		}
		
	}
	
	
	/**
	 * 根据地图级别获得出现战斗的概率
	 * @param mapLevel
	 * @param move
	 * @return
	 */
	public double getProb(int mapLevel, int move) {
		double[] rate = PROBABILITY[0];
		if (mapLevel >= 1 && mapLevel <= PROBABILITY.length - 1) {
			rate = PROBABILITY[mapLevel];
		}
		double ret = rate[0];
		if (move < 1) {
			ret = rate[0];
		}
		if (move>=1 && move<=10) {
			ret = rate[move];
		} else {
			ret = rate[11];
		}
		return ret;
	}
	
	/**
	 * 判断玩家能否触发战斗，在地图中移动时调用
	 * @param human
	 * @return
	 */
	public boolean canStartBattle(Human human) {
		//战斗中，不能再战斗
		if (human.isInAnyBattle()) {
			return false;
		}
		//玩家可能在队伍中，判断能否触发战斗
		if (!Globals.getTeamService().canTriggerBattle(human.getCharId())) {
			return false;
		}
		
		int mapId = human.getMapId();
		MapTemplate mapTpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		//没有遇怪方案，说明该地图不遇怪
		if (mapTpl.getMeetMonsterPlanId() <= 0) {
			return false;
		}
		
		int mapLevel = mapTpl.getMapLevel();
		double mapAddProb = mapTpl.getMeetMonsterAddProb() * 1.0D / Globals.getGameConstants().getScale();
		
		boolean meetMonster = false;
		if (human.getNextMoves() > 0) {
			int leftMoves = human.getNextMoves();
			int toMoves = 0;
			while (leftMoves > 0) {
				leftMoves--;
				toMoves++;
				
				double rate = getProb(mapLevel, human.getMoves() + toMoves) + mapAddProb;
				
				if (MathUtils.shake(rate)) {
					meetMonster = true;
					break;
				}
			}
			human.setMoves(human.getMoves() + human.getNextMoves());
			human.setNextMoves(0);
		}
		else{
			// 尚未移动过，不会遇到怪物
			return false;
		}
		
		if(!meetMonster) {
			return false;
		}
		
		// TODO::检查其它状态，诸如驱魔香，或者任务之类
		//通天塔地图队长判断NPC是否通过
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			Team team = Globals.getTeamService().getHumanTeam(human.getCharId());
			if(team != null){
				Human leader = Globals.getTeamService().getTeamLeaderHuman(team);
				if(leader != null){
					if(this.isTower(mapId) && !Globals.getTowerService().isPassNPC(leader, mapId, true)){
						return false;
					}
				}
				
			}
		}else{
			//通天塔地图单人判断NPC是否通过
			if(this.isTower(mapId) && !Globals.getTowerService().isPassNPC(human, mapId, false)){
				return false;
			}
		}
		
		// 战斗结束一定时间内不会遇怪
		if (Globals.getTimeService().now() - human.getLastBattleEndTime() < BattleDef.MIN_TO_LAST_BATTLE) {
			return false;
		}
		
		return true;
	}
	
	/**
	 * 开始与npc进行战斗
	 * @param human
	 * @param npcInfo
	 * @param needBroadcast
	 * @return
	 */
	public int mapFightNpc(Human human, NpcInfo npcInfo, boolean needBroadcast) {
		long roleId = human.getCharId();
		//取npc对应的enemyArmyId
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcInfo.getNpcId(), NpcTemplate.class);
		int enemyArmyId = npcTpl.getEnemyGroupId();
		
		int battleId = 0;
		
		if (Globals.getTeamService().canTriggerSingleBattle(roleId)) {
			Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, human, true);
			//固定npc，数量按最大算
			EnemyParamContent epc = new EnemyParamContent(enemyArmyId, GameConstants.MAX_HUMAN_NUM, human.getLevel(), human.getMapId(), false);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			//开始单人战斗
			battleId = Globals.getBattleService().startPVEBattle(human, BattleType.SINGLE, attacker, defender, npcInfo);
		} else if (Globals.getTeamService().canTriggerTeamBattle(roleId)) {
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			Fighter<?> attacker = new Fighter<Team>(FighterType.TEAM, team, true);
			//固定npc，数量按最大算，用队伍的平均等级
			EnemyParamContent epc = new EnemyParamContent(enemyArmyId, GameConstants.MAX_HUMAN_NUM, team.getAvgLevel(), team.getMapId(), false);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			
			//开始组队战斗
			battleId = Globals.getTeamService().getTeamBattleLogic().startTeamPVEBattle(human, team, BattleType.TEAM, attacker, defender, npcInfo);
		} else {
			Loggers.battleLogger.error("meetMapMonsterBattle can not trigger fight!" + human.getCharId());
			return 0;
		}
		
		//设置为进入战斗状态
		npcInfo.setBattleId(battleId);
		
		//广播npc进入战斗状态
		if (needBroadcast && battleId > 0) {
			getGameMap(npcInfo.getMapId(), human.getCharId()).noticeUpdateAddNpc(npcInfo);
		}
		
		return battleId;
	}
	
	/**
	 * 根据地图id判断是否宠物岛
	 * @param mapId
	 * @return
	 */
	public boolean isPetIsland(int mapId) {
		boolean flag = false;
		MapTemplate tpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if (tpl != null && tpl.getMapType() == MapType.PET_ISLAND) {
			flag = true;
		}
		return flag;
	}
	
	/**
	 * 根据地图id判断是否通天塔
	 * @param mapId
	 * @return
	 */
	public boolean isTower(int mapId) {
		boolean flag = false;
		MapTemplate tpl = Globals.getTemplateCacheService().get(mapId, MapTemplate.class);
		if (tpl != null && tpl.getMapType() == MapType.TOWER) {
			flag = true;
		}
		return flag;
	}
	
	/**
	 * 根据地图id判断是否野外封妖
	 * @param mapId
	 * @return
	 */
	public boolean isSealDemonMap(int mapId) {
		List<Integer> lst = Globals.getTemplateCacheService().getSealDemonTemplateCache().getSealDemonMapLst();
		if(lst.isEmpty()){
			return false;
		}
		return lst.contains(mapId);
	}
	
	/**
	 * 根据地图id判断是否围剿魔族
	 * @param mapId
	 * @return
	 */
	public boolean isSiegeDemonMap(int mapId) {
		return Globals.getTemplateCacheService().getMapTemplateCache().getSiegeDemonMapId() == mapId;
	}
	
	/**
	 * 根据地图id判断是否混世魔王
	 * @param mapId
	 * @return
	 */
	public boolean isDevilIncarnateMap(int mapId) {
		List<Integer> lst = Globals.getTemplateCacheService().getDevilIncarnateTemplateCache().getDevilIncarnateMapLst();
		if(lst.isEmpty()){
			return false;
		}
		return lst.contains(mapId);
	}
	
	
	/**
	 * 是否绿野仙踪地图
	 * @param mapId
	 * @return
	 */
	public boolean isWizardRaidMap(int mapId) {
		return Globals.getTemplateCacheService().getMapTemplateCache().getWizardRaidMapId() == mapId;
	}
	
	/**
	 * 是否帮派主城地图
	 * @param mapId
	 * @return
	 */
	public boolean isCorpsMainMap(int mapId) {
		return Globals.getTemplateCacheService().getMapTemplateCache().getCorpsMainMapId() == mapId;
	}
	
	/**
	 * 请求与npc进行战斗
	 * @param human
	 * @param npcId
	 */
	public void clickFightTarget(Human human, int npcId, String npcUUID) {
		//战斗中，不能再进行战斗
		if (human.isInAnyBattle()) {
			return;
		}
		
		if (npcUUID == null || npcUUID.isEmpty()) {
			fightFixedNpc(human, npcId);
		} else {
			fightAddNpc(human, npcUUID);
		}
	}
	
	/**
	 * 与配置表中的npc进行战斗
	 * @param human
	 * @param npcId
	 */
	public void fightFixedNpc(Human human, int npcId) {
		NpcTemplate npcTpl = Globals.getTemplateCacheService().get(npcId, NpcTemplate.class);
		//npc是否存在
		if (npcTpl == null) {
			//非法数据
			return;
		}
		//是否可战斗的npc
		if (!npcTpl.isFightNpc()) {
			//非法请求
			return;
		}
		
		int mapId = human.getMapId();
		boolean isIn = Globals.getTemplateCacheService().getMapTemplateCache().isNpcInMap(mapId, npcId);
		if (!isIn) {
			Loggers.mapLogger.warn("npc not in player current map!humanId=" + 
					human.getCharId() + ";npcId=" + npcId);
			return;
		}
		
		NpcInfo info = new NpcInfo();
		info.setNpcId(npcId);
		info.setMapId(mapId);
		
		AbstractGameMap gameMap = getGameMap(mapId, human.getCharId());
		gameMap.fightNpc(human, info);
	}
	
	/**
	 * 与动态生成的npc进行战斗
	 * @param human
	 * @param npcUUID
	 */
	public void fightAddNpc(Human human, String npcUUID) {
		int mapId = human.getMapId();
		AbstractGameMap gameMap = getGameMap(mapId, human.getCharId());
		if (gameMap == null) {
			Loggers.mapLogger.warn("gameMap is null!humanId=" + 
					human.getCharId() + ";npcUUID=" + npcUUID + ";mapId=" + mapId);
			return;
		}
		NpcInfo info = gameMap.getAddNpc(npcUUID);
		if (info == null) {
			Loggers.mapLogger.warn("npc not in player current map!humanId=" + 
					human.getCharId() + ";npcUUID=" + npcUUID + ";mapId=" + mapId);
			return;
		}
		
		//如果正在进行战斗，则不能再触发战斗
		if (info.isInBattle()) {
			human.sendErrorMessage(LangConstants.MAP_FIGHT_NPC_FAIL_IN_BATTLE);
			return;
		}
		
		gameMap.fightNpc(human, info);
	}
	/**
	 * 判断玩家是否在点的有效范围内
	 * offset= {@link GameConstants#getPointInAreaOffset()}
	 * @param human
	 * @param mapId
	 * @param x tileX
	 * @param y tileY
	 * @return
	 */
	public boolean isInArea(Human human, int mapId, int x, int y) {
		if (mapId <= 0 || x <= 0 || y <= 0) {
			return false;
		}
		//玩家当前是否在指定的地图
		if (human.getMapId() != mapId) {
			return false;
		}
//		AbstractGameMap map = Globals.getMapService().getGameMap(human.getMapId(), human.getCharId());
//		if(map == null){
//			return false;
//		}
//		Integer p = AbstractGameMap.calcPoint(x, y);
//		if(p <= 0){
//			return false;
//		}
//		if(!map.getReallyCanUsePoint().contains(p)){
//			return false;
//		}
		//玩家是否在指定的区域范围内
		if (!AbstractGameMap.inArea(human.getTileX(), human.getTileY(), x, y, Globals.getGameConstants().getPointInAreaOffset())) {
			return false;
		}
		return true;
	}
	
	/**
	 * 通知附近玩家，该玩家地图显示信息变化
	 * @param human
	 */
	public void noticeNearMapInfoChanged(Human human) {
		if (human == null) {
			return;
		}
		AbstractGameMap m = Globals.getMapService().getGameMap(human.getMapId(), human.getUUID());
		if (m != null) {
			m.noticeNearMapInfoChanged(human, true);
		}
	}
	
	/**
	 * 所有gameMap的玩家返回原地图，gameMap必须是动态类型地图
	 * 
	 * @param gameMap
	 */
	public void allPlayerToBackMap(AbstractGameMap gameMap) {
		//gameMap必须是动态类型地图
		if (!(gameMap instanceof DynamicGameMapBase)) {
			Loggers.mapLogger.error("gameMap is not DynamicGameMapBase!mapId=" + gameMap.getId());
			return;
		}
		
		List<Human> col = new ArrayList<Human>(); 
		col.addAll(gameMap.getAllHumans());
		for (Human human : col) {
			long roleId = human.getCharId();
			boolean isTeamLeader = Globals.getTeamService().isTeamLeader(roleId);
			boolean isInTeamNormal = Globals.getTeamService().isInTeamNormal(roleId);
			//队长 或 暂离或未在队伍 的玩家回到备用地图
			if ( (isInTeamNormal && isTeamLeader) || !isInTeamNormal) {
				boolean flag = Globals.getMapService().enterMap(human, human.getBackMapId(), human.getBackX(), human.getBackY());
				if (!flag) {
					Loggers.mapLogger.error("human go to backup map failed-0!humanId=" + roleId + ";mapId=" + gameMap.getId());
				}
			}
		}
		
		col.clear();
		col.addAll(gameMap.getAllHumans());
		//剩余的玩家是状态为在队伍中且状态为普通的队员，由于队长不在线，队员在上面的方法中没有退出地图
		for (Human human : col) {
			long roleId = human.getCharId();
			boolean isInTeamNormal = Globals.getTeamService().isInTeamNormal(roleId);
			if (!isInTeamNormal) {
				Loggers.mapLogger.error("human go to backup map failed-1!humanId=" + roleId + ";mapId=" + gameMap.getId());
				continue;
			}
			
			Team team = Globals.getTeamService().getHumanTeam(roleId);
			//使用队伍backupMapId作为队伍地图id
			team.onUseBackMap();
			
			//玩家进入队伍的备用地图
			boolean flag = Globals.getMapService().enterMap(human, team.getBackMapId(), team.getBackX(), team.getBackY());
			if (!flag) {
				Loggers.mapLogger.error("human go to backup map failed-2!humanId=" + roleId + ";mapId=" + gameMap.getId());
			}
		}
	}
	
}
