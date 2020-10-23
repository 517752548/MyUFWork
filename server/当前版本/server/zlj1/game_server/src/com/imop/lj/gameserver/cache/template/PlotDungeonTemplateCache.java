package com.imop.lj.gameserver.cache.template;

import java.util.Collection;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonDef.DungeonType;
import com.imop.lj.gameserver.plotdungeon.template.PlotDungeonTemplate;

/**
 * 剧情副本模版缓存
 * 
 * 
 */
public class PlotDungeonTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;

	/** Map<剧情副本进度ID,剧情副本模板>	 */
	private Map<Integer,PlotDungeonTemplate> easyPlotMap = Maps.newHashMap();
	
	/** Map<剧情副本进度ID,剧情副本模板>	 */
	private Map<Integer,PlotDungeonTemplate> hardPlotMap = Maps.newHashMap();
	
	/** Map<怪物组ID, 剧情副本模板>*/
	private Map<Integer, PlotDungeonTemplate> enemyPlotMap = Maps.newHashMap();
	
	/** 剧情副本怪物组集合*/
	private Set<Integer> enemyPlotSet = new HashSet<>();
	
	
	public PlotDungeonTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initPlotDungeonMap();
	}


	private void initPlotDungeonMap() {
		Set<Integer> enemyArmyIdSet = new HashSet<Integer>();
		for(PlotDungeonTemplate tpl : templateService.getAll(PlotDungeonTemplate.class).values()){
			if(tpl.getHardFlag() == DungeonType.EASY.getIndex()){				
				easyPlotMap.put(tpl.getPlotDungeonLevel(), tpl);
			}
			if(tpl.getHardFlag() == DungeonType.HARD.getIndex()){				
				hardPlotMap.put(tpl.getPlotDungeonLevel(), tpl);
			}
			
			
			
			//怪物组Id不可以重复
			if (!enemyArmyIdSet.contains(tpl.getEnemyArmyId())) {
				enemyArmyIdSet.add(tpl.getEnemyArmyId());
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "怪物组Id重复！" + tpl.getEnemyArmyId());
			}
			
			enemyPlotMap.put(tpl.getEnemyArmyId(), tpl);
			
			//怪物组Set
			enemyPlotSet.add(tpl.getEnemyArmyId());
		}
		
		//普通副本和精英副本数量必须一致
		PlotDungeonTemplate tpl = templateService.get(1, PlotDungeonTemplate.class);
		if(easyPlotMap.size() != hardPlotMap.size()){
			throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "普通副本和精英副本的关数不相等！" 
					+ "普通副本数量:" + easyPlotMap.size()
					+";精英副本数量:" + hardPlotMap.size());
		}
		
		//普通副本开启的任务Id和精英副本开启的任务ID必须一样,否则当开启普通副本的时候,精英副本就没有对应的开启了!
		Collection<Integer> easyQuestIdSet = new HashSet<Integer>();
		Collection<Integer> hardQuestIdSet = new HashSet<Integer>();
		
		for(PlotDungeonTemplate easyTpl : easyPlotMap.values()){
			easyQuestIdSet.add(easyTpl.getTriggerQuestId());
		}
		for(PlotDungeonTemplate easyTpl : hardPlotMap.values()){
			hardQuestIdSet.add(easyTpl.getTriggerQuestId());
		}
		
		if(!easyQuestIdSet.containsAll(hardQuestIdSet)
			|| !hardQuestIdSet.containsAll(easyQuestIdSet)){
			throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "普通副本开启的任务Id和精英副本开启的任务ID不一样！" 
					+ "普通副本任务Id:" + easyQuestIdSet
					+";精英副本任务Id:" + hardQuestIdSet);
		}
	}
	
	/**
	 * 简单剧情副本进度是否有效
	 * @param level
	 * @return
	 */
	public boolean isValidEasyPlotLevel(int level){
		if(!easyPlotMap.isEmpty()){
			return easyPlotMap.containsKey(level);
		}
		return false;
	}
	
	/**
	 * 精英剧情副本进度是否有效
	 * @param level
	 * @return
	 */
	public boolean isValidHardPlotLevel(int level){
		if(!hardPlotMap.isEmpty()){
			return hardPlotMap.containsKey(level);
		}
		return false;
	}
	
	/**
	 * 是否是剧情副本的怪物组
	 * @param enemyArmyId
	 * @return
	 */
	public boolean isPlotDungeonEnemy(int enemyArmyId){
		if(!enemyPlotSet.isEmpty()){
			return enemyPlotSet.contains(enemyArmyId);
		}
		return false;
	}
	
	/**
	 * 根据进度查询剧情副本信息模板
	 * @param level
	 * @param type
	 * @return
	 */
	public PlotDungeonTemplate getPlotDungeonInfoByLevel(int level, DungeonType type){
		if(type == DungeonType.EASY){
			if(easyPlotMap.containsKey(level)){
				return easyPlotMap.get(level);
			}
		}else if(type == DungeonType.HARD){
			if(hardPlotMap.containsKey(level)){
				return hardPlotMap.get(level);
			}
		}
		return null;
	}
	
	/**
	 * 得到剧情副本的总章节数
	 * @param type
	 * @return
	 */
	public int getPlotDungeonChapterNumByType(DungeonType type){
		if(type == DungeonType.EASY){
			return easyPlotMap.size() / Globals.getGameConstants().getChapterByPlotDungeon();
		}else if(type == DungeonType.HARD){
			return hardPlotMap.size()  / Globals.getGameConstants().getChapterByPlotDungeon();
		}
		return 0;
	}
	
	/**
	 * 根据怪物组查询剧情副本信息模板
	 * @param level
	 * @return
	 */
	public PlotDungeonTemplate getPlotDungeonInfoByEnemy(int enemyArmyId){
		if(enemyPlotMap.containsKey(enemyArmyId)){
			return enemyPlotMap.get(enemyArmyId);
		}
		return null;
	}

}
