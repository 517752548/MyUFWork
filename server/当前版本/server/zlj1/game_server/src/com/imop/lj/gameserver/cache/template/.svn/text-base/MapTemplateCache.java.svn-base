package com.imop.lj.gameserver.cache.template;

import java.awt.Point;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.map.template.MapMeetMonsterTemplate;
import com.imop.lj.gameserver.map.template.MapNpcTemplate;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.map.template.PetIslandTemplate;
import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.siegedemon.template.SiegeDemonPositionTemplate;
import com.imop.lj.gameserver.util.MapUtil;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidPositionTemplate;

/**
 * 负责地图初始化数据
 * 
 */
public class MapTemplateCache implements InitializeRequired {
	protected TemplateService templateService;

	/** Map<地图Id, npcIdSet> */
	private Map<Integer, Set<Integer>> npcMap = Maps.newHashMap();
	/** Map<地图Id, npcPointSet> */
	private Map<Integer, Set<Integer>> npcPointMap = Maps.newHashMap();
	
	/** Map<地图Id, Map<NpcId, npc所在点>> */
	private Map<Integer, Map<Integer, Integer>> mapNpcPointMap = Maps.newHashMap();
	
	/** 遇怪方案Map<方案Id，List<方案模板>> */
	private Map<Integer, List<MapMeetMonsterTemplate>> meetMonsterMap = Maps.newHashMap();
	/** 遇怪权重Map<方案Id，List<方案权重>> */
	private Map<Integer, List<Integer>> meetMonsterProbMap = Maps.newHashMap();
	
	/** 宠物岛的地图Map */
	private Map<Integer, Map<Integer, List<Integer>>> petIslandMap = Maps.newHashMap();
	private final int npcIdKey = 1;
	private final int npcWeightKey = 2;
	/** 排序好的宠物岛地图Id列表 */
	private List<Integer> petIslandMapIdList = new ArrayList<Integer>();
	
	/** 通天塔的地图Map<地图Id, npcId> */
	private Map<Integer,Integer> towerMap = Maps.newHashMap();
	/** 排序好的通天塔地图Id列表 */
	private List<Integer> towerMapIdList = new ArrayList<Integer>();
	
	private int corpsMainMapId;
	
	/** 绿野仙踪地图Id */
	private int wizardRaidMapId;
	/** 军团战地图id */
	private int corpsWarMapId;
	/** nvn联赛地图Id */
	private int nvnWarMapId;
	/** 围剿魔族地图Id */
	private int siegeDemonMapId;
	
	public MapTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initMapNpc();
		initMeetMonsterMap();
		initPetIslandMap();
	}
	
	private void initMapNpc() {
		Map<Integer, MapNpcTemplate> allMapNpcTemplates = templateService.getAll(MapNpcTemplate.class);

		for (MapNpcTemplate mapNpcTemplate : allMapNpcTemplates.values()) {
			int mapId = mapNpcTemplate.getMapId();
			int npcId = mapNpcTemplate.getNpcId();
			Set<Integer> s = npcMap.get(mapId);
			if (null == s) {
				s = new HashSet<Integer>();
				npcMap.put(mapId, s);
			}
			//一张地图内的npcid不能重复
			if (s.contains(npcId)) {
				throw new TemplateConfigException(mapNpcTemplate.getSheetName(), mapNpcTemplate.getId(), "地图中的NPCId重复！" + npcId);
			}
			s.add(npcId);
			
			Set<Integer> ps = npcPointMap.get(mapId);
			if (null == ps) {
				ps = new HashSet<Integer>();
				npcPointMap.put(mapId, ps);
			}
			
			int p = 0;
			if (mapNpcTemplate.isPixel()) {
				Point pt = MapUtil.image2TileCoord(mapNpcTemplate.getX(), mapNpcTemplate.getY());
				p = AbstractGameMap.calcPoint(pt.x, pt.y);
			} else {
				p = AbstractGameMap.calcPoint(mapNpcTemplate.getX(), mapNpcTemplate.getY());
			}
			
			ps.add(p);
			
			Map<Integer, Integer> m1 = mapNpcPointMap.get(mapId);
			if (m1 == null) {
				m1 = new HashMap<Integer, Integer>();
				mapNpcPointMap.put(mapId, m1);
			}
			m1.put(npcId, p);
			
			//通天塔
			towerMap.put(mapId, npcId);
		}
	}
	
	private void initMeetMonsterMap() {
		//整理遇怪方案map
		Map<Integer, MapMeetMonsterTemplate> tplMap = templateService.getAll(MapMeetMonsterTemplate.class);
		for (MapMeetMonsterTemplate tpl : tplMap.values()) {
			int planId = tpl.getMeetMonsterPlanId();
			List<MapMeetMonsterTemplate> lst = meetMonsterMap.get(planId);
			if (lst == null) {
				lst = new ArrayList<MapMeetMonsterTemplate>();
				meetMonsterMap.put(planId, lst);
			}
			lst.add(tpl);
		}
		
		//遇怪权重
		for (Entry<Integer, List<MapMeetMonsterTemplate>> entry : meetMonsterMap.entrySet()) {
			int planId = entry.getKey();
			int weight = 0;
			for (MapMeetMonsterTemplate mmt : entry.getValue()) {
				weight += mmt.getWeight();
				List<Integer> probLst = meetMonsterProbMap.get(planId);
				if (null == probLst) {
					probLst = new ArrayList<Integer>();
					meetMonsterProbMap.put(planId, probLst);
				}
				probLst.add(weight);
			}
			if (weight != Globals.getGameConstants().getRandomBase()) {
				throw new TemplateConfigException("", 0, String.format("地图遇怪概率数值[%d]不等于总基数！", weight));
			}
		}
		
		//判断地图配置表的遇怪方案是否存在
		for (MapTemplate mapTpl : templateService.getAll(MapTemplate.class).values()) {
			if (mapTpl.getMeetMonsterPlanId() > 0) {
				if (!meetMonsterMap.containsKey(mapTpl.getMeetMonsterPlanId())) {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "遇怪方案不存在！" + mapTpl.getMeetMonsterPlanId());
				}
			}
		}
		
	}
	
	private void initPetIslandMap() {
		for (MapTemplate mapTpl : templateService.getAll(MapTemplate.class).values()) {
			if (mapTpl.getMapType() == MapType.PET_ISLAND) {
				Map<Integer, List<Integer>> m = new HashMap<Integer, List<Integer>>();
				m.put(npcIdKey, new ArrayList<Integer>());
				m.put(npcWeightKey, new ArrayList<Integer>());
				petIslandMap.put(mapTpl.getId(), m);
				
				petIslandMapIdList.add(mapTpl.getId());
			}
			
			//通天塔
			if (mapTpl.getMapType() == MapType.TOWER) {
				towerMapIdList.add(mapTpl.getId());
			}
			
			//设置军团主城地图Id
			if (mapTpl.getMapType() == MapType.CORPS_MAIN) {
				if (corpsMainMapId == 0) {
					corpsMainMapId = mapTpl.getId();
				} else {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "重复的军团主城地图Id！" + mapTpl.getId());
				}
			}
			
			//设置绿野仙踪地图Id
			if (mapTpl.getMapType() == MapType.WIZARD_RAID) {
				if (wizardRaidMapId == 0) {
					wizardRaidMapId = mapTpl.getId();
				} else {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "重复的绿野仙踪地图Id！" + mapTpl.getId());
				}
			}
			
			//设置围剿魔族地图Id
			if (mapTpl.getMapType() == MapType.SIEGE_DEMON) {
				if (siegeDemonMapId == 0) {
					siegeDemonMapId = mapTpl.getId();
				} else {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "重复的围剿魔族地图Id！" + mapTpl.getId());
				}
			}
			
			//设置帮派竞赛地图Id
			if (mapTpl.getMapType() == MapType.CORPS_WAR) {
				if (corpsWarMapId == 0) {
					corpsWarMapId = mapTpl.getId();
				} else {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "重复的帮派竞赛地图Id！" + mapTpl.getId());
				}
			}
			
			//设置nvn竞赛地图Id
			if (mapTpl.getMapType() == MapType.NVN_WAR) {
				if (nvnWarMapId == 0) {
					nvnWarMapId = mapTpl.getId();
				} else {
					throw new TemplateConfigException(mapTpl.getSheetName(), mapTpl.getId(), "重复的nvn联赛地图Id！" + mapTpl.getId());
				}
			}
			
		}
		if (corpsMainMapId == 0) {
			throw new TemplateConfigException("", 0, "地图配置中没有军团主城地图Id！");
		}
		if (wizardRaidMapId == 0) {
			throw new TemplateConfigException("", 0, "地图配置中没有绿野仙踪地图Id！");
		}
		if (corpsWarMapId == 0) {
			throw new TemplateConfigException("", 0, "地图配置中没有帮派竞赛地图Id！");
		}
		if (nvnWarMapId == 0) {
			throw new TemplateConfigException("", 0, "地图配置中没有nvn联赛地图Id！");
		}

		Set<Integer> tmpSet = new HashSet<Integer>();
		for (PetIslandTemplate tpl : templateService.getAll(PetIslandTemplate.class).values()) {
			int mapId = tpl.getMapId();
			Map<Integer, List<Integer>> m = petIslandMap.get(mapId);
			List<Integer> m1 = m.get(npcIdKey);
			List<Integer> m2 = m.get(npcWeightKey);
			int npcId = tpl.getNpcId();
			//一个地图内的npcId不能重复
			if (m1.contains(npcId)) {
				throw new TemplateConfigException("宠物岛神兽配置", 0, "NPCId重复！" + npcId);
			}
			//不能和已经配置的npcId重复
			if (npcMap.containsKey(mapId) &&
					npcMap.get(mapId).contains(npcId)) {
				throw new TemplateConfigException("宠物岛神兽配置", 0, "NPCId和已有的重复！" + npcId);
			}
			
			m1.add(tpl.getNpcId());
			m2.add(tpl.getWeight());
			
			tmpSet.add(tpl.getMapId());
		}
		if (tmpSet.size() != petIslandMap.keySet().size()) {
			throw new TemplateConfigException("宠物岛神兽配置", 0, "有没有神兽的地图！");
		}
		
		Collections.sort(petIslandMapIdList, new Comparator<Integer>() {
			public int compare(Integer o1, Integer o2) {
				MapTemplate m1 = templateService.get(o1, MapTemplate.class);
				MapTemplate m2 = templateService.get(o2, MapTemplate.class);
				//先按开启等级排序
				if (m1.getOpenLevel() < m2.getOpenLevel()) {
					return -1;
				}
				if (m1.getOpenLevel() > m2.getOpenLevel()) {
					return 1;
				}
				
				//然后按地图Id排序
				if (m1.getId() < m2.getId()) {
					return -1;
				}
				if (m1.getId() > m2.getId()) {
					return 1;
				}
				
				return 0;
			}
		});
		
		
		
		Collections.sort(towerMapIdList, new Comparator<Integer>() {
			public int compare(Integer o1, Integer o2) {
				MapTemplate m1 = templateService.get(o1, MapTemplate.class);
				MapTemplate m2 = templateService.get(o2, MapTemplate.class);
				//先按开启等级排序
				if (m1.getOpenLevel() < m2.getOpenLevel()) {
					return -1;
				}
				if (m1.getOpenLevel() > m2.getOpenLevel()) {
					return 1;
				}
				
				//然后按地图Id排序
				if (m1.getId() < m2.getId()) {
					return -1;
				}
				if (m1.getId() > m2.getId()) {
					return 1;
				}
				
				return 0;
			}
		});
		
	}
	
	public void checkNpcPoint() {
		List<MapNpcTemplate> lst = new ArrayList<MapNpcTemplate>();
		for (MapNpcTemplate tpl : templateService.getAll(MapNpcTemplate.class).values()) {
			int mapId = tpl.getMapId();
			int npcId = tpl.getNpcId();
			//特效npc排除掉
			if (templateService.get(npcId, NpcTemplate.class).getNpcType() == NpcType.SHOW_EFFECT) {
				continue;
			}
			
			int x = 0;
			int y = 0;
			if (tpl.isPixel()) {
				Point pt = MapUtil.image2TileCoord(tpl.getX(), tpl.getY());
				x = pt.x;
				y = pt.y;
			} else {
				x = tpl.getX();
				y = tpl.getY();
			}
			
			boolean canWalk = Globals.getMapService().getGameMap(mapId).canWalk(x, y);
			if (!canWalk) {
				lst.add(tpl);
			}
		}
		
		if (!lst.isEmpty()) {
			for (MapNpcTemplate tpl : lst) {
				try {
					throw new TemplateConfigException(tpl.getSheetName(),
							tpl.getId(), "npc所在点不可走！mapId=" + tpl.getMapId()
									+ ";npcId=" + tpl.getNpcId());
				} catch (Exception e) {
					e.printStackTrace();
					Loggers.gameLogger.error("checkNpcPoint exception!", e);
				}
			}
			System.exit(1);
		}
		
		//检查到指定区域使用道具的点是否合法
		List<ItemTemplate> itemLst = new ArrayList<ItemTemplate>();
		for (ItemTemplate tpl : templateService.getAll(ItemTemplate.class).values()) {
			if (tpl instanceof ConsumeItemTemplate) {
				ConsumeItemTemplate cTpl = (ConsumeItemTemplate) tpl;
				if (cTpl.getFunction() == ConsumableFunc.QUEST_AT_PLACE_USED) {
					boolean canWalk = Globals.getMapService().getGameMap(cTpl.getMapId()).canWalk(cTpl.getTileX(), cTpl.getTileY());
					if (!canWalk) {
						itemLst.add(tpl);
					}
				}
			}
		}
		if (!itemLst.isEmpty()) {
			for (ItemTemplate tpl : itemLst) {
				try {
					throw new TemplateConfigException(tpl.getSheetName(),
							tpl.getId(), "道具指定点不可走！");
				} catch (Exception e) {
					e.printStackTrace();
					Loggers.gameLogger.error("checkNpcPoint exception!", e);
				}
			}
			System.exit(1);
		}
		
	}
	
	public void checkWizardRaidPoint() {
		int mapId = this.wizardRaidMapId;
		List<WizardRaidPositionTemplate> lst = new ArrayList<WizardRaidPositionTemplate>();
		for (WizardRaidPositionTemplate tpl : templateService.getAll(WizardRaidPositionTemplate.class).values()) {
			int x = tpl.getX();
			int y = tpl.getY();
			
			boolean canWalk = Globals.getMapService().getGameMap(mapId).canWalk(x, y);
			if (!canWalk) {
				lst.add(tpl);
			}
		}
		
		if (!lst.isEmpty()) {
			for (WizardRaidPositionTemplate tpl : lst) {
				try {
					throw new TemplateConfigException(tpl.getSheetName(),
							tpl.getId(), "该点不可走！mapId=" + mapId
									+ ";x=" + tpl.getX() + ";y=" + tpl.getY());
				} catch (Exception e) {
					e.printStackTrace();
					Loggers.gameLogger.error("checkNpcPoint exception!", e);
				}
			}
			System.exit(1);
		}
		
		
	}
	public void checkSiegeDemonPoint() {
		int mapId = this.siegeDemonMapId;
		List<SiegeDemonPositionTemplate> lst = new ArrayList<SiegeDemonPositionTemplate>();
		for (SiegeDemonPositionTemplate tpl : templateService.getAll(SiegeDemonPositionTemplate.class).values()) {
			int x = tpl.getX();
			int y = tpl.getY();
			
			boolean canWalk = Globals.getMapService().getGameMap(mapId).canWalk(x, y);
			if (!canWalk) {
				lst.add(tpl);
			}
		}
		
		if (!lst.isEmpty()) {
			for (SiegeDemonPositionTemplate tpl : lst) {
				try {
					throw new TemplateConfigException(tpl.getSheetName(),
							tpl.getId(), "该点不可走！mapId=" + mapId
							+ ";x=" + tpl.getX() + ";y=" + tpl.getY());
				} catch (Exception e) {
					e.printStackTrace();
					Loggers.gameLogger.error("checkNpcPoint exception!", e);
				}
			}
			System.exit(1);
		}
		
	}
	
	/**
	 * 检查某个地图的NPC是否存在
	 * @param mapId
	 * @param npcId
	 * @return
	 */
	public boolean isNpcInMap(int mapId, int npcId) {
		if (npcMap.containsKey(mapId)) {
			if (npcMap.get(mapId).contains(npcId)) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 根据遇怪方案Id获取方案列表
	 * @param planId
	 * @return
	 */
	public List<MapMeetMonsterTemplate> getMeetMonsterPlan(int planId) {
		return meetMonsterMap.get(planId);
	}
	
	/**
	 * 遇怪方案权重列表
	 * @param planId
	 * @return
	 */
	public List<Integer> getMeetMonsterPlanProb(int planId) {
		return meetMonsterProbMap.get(planId);
	}
	
	public List<Integer> getPetIslandNpcIdList(int mapId) {
		if (petIslandMap.containsKey(mapId)) {
			return petIslandMap.get(mapId).get(npcIdKey);
		}
		return null;
	}
	
	public List<Integer> getPetIslandNpcWeightList(int mapId) {
		if (petIslandMap.containsKey(mapId)) {
			return petIslandMap.get(mapId).get(npcWeightKey);
		}
		return null;
	}
	
	public List<Integer> getPetIslandMapIdList() {
		return petIslandMapIdList;
	}
	
	public List<Integer> getTowerMapIdList(){
		return towerMapIdList;
	}
	
	public int getTowerNpcIdByMapId(int mapId){
		if(towerMap.containsKey(mapId)){
			return towerMap.get(mapId);
		}
		return 0;
	}
	
	/**
	 * 得到所有通天塔NPCID列表
	 * @return
	 */
	public List<Integer> getTowerNpcIdList(){
		List<Integer> npcIdList = Lists.newArrayList();
		npcIdList.addAll(towerMap.values());
		return npcIdList;
	}
	
	public boolean isNpcPoint(int mapId, int p) {
		if (npcPointMap.containsKey(mapId)) {
			if (npcPointMap.get(mapId).contains(p)) {
				return true;
			}
		}
		return false;
	}
	
	public Point getNpcPoint(int mapId, int npcId) {
		Point point = null;
		if (mapNpcPointMap.containsKey(mapId)) {
			if (mapNpcPointMap.get(mapId).containsKey(npcId)) {
				int p = mapNpcPointMap.get(mapId).get(npcId);
				point = new Point(AbstractGameMap.calcPointX(p), 
						AbstractGameMap.calcPointY(p));
			}
		}
		return point;
	}
	
	public Set<Integer> getAllNpcByMapId(int mapId){
		if(npcMap.containsKey(mapId)){
			return npcMap.get(mapId);
		}
		return null;
	}

	/**
	 * 获取军团主城Id
	 * @return
	 */
	public int getCorpsMainMapId() {
		return this.corpsMainMapId;
	}
	
	/**
	 * 获取绿野仙踪地图Id
	 * @return
	 */
	public int getWizardRaidMapId() {
		return this.wizardRaidMapId;
	}
	
	/**
	 * 获取围剿魔族地图Id
	 * @return
	 */
	public int getSiegeDemonMapId() {
		return this.siegeDemonMapId;
	}
	
	/**
	 * 获取帮派竞赛地图Id
	 * @return
	 */
	public int getCorpsWarMapId() {
		return this.corpsWarMapId;
	}
	
	/**
	 * 获取nvn联赛地图
	 * @return
	 */
	public int getNvnMapId() {
		return this.nvnWarMapId;
	}

}
