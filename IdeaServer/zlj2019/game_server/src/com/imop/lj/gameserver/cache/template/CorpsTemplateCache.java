package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.SkillType;
import com.imop.lj.gameserver.corps.template.CorpsBenifitTemplate;
import com.imop.lj.gameserver.corps.template.CorpsBuildingUpgradeTemplate;
import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistCostTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistCritTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistGenTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistTemplate;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossCountRankTemplate;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossRankTemplate;
import com.imop.lj.gameserver.corpsboss.template.CorpsBossTemplate;
import com.imop.lj.gameserver.corpscultivate.template.CorpsCultivateCostTemplate;
import com.imop.lj.gameserver.corpscultivate.template.CorpsCultivateTemplate;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;

/**
 * 军团模版缓存
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;
	
	/** Map<帮派等级,帮派升级模板>	 */
	private Map<Integer,CorpsUpgradeTemplate> upgradeMap = Maps.newHashMap();
	
	/**	List<帮派福利模板> */
	private List<CorpsBenifitTemplate> benifitLst = Lists.newArrayList();

	/** Map<帮派boss进度ID,帮派boss模板>	 */
	private Map<Integer,CorpsBossTemplate> bossMap = Maps.newHashMap();
	
	/** Map<怪物组ID, 帮派boss模板>*/
	private Map<Integer, CorpsBossTemplate> enemyBossMap = Maps.newHashMap();
	
	/** 帮派boss怪物组集合*/
	private Set<Integer> enemyBossSet = new HashSet<>();
	
	/** Map<帮派boss排名,boss排名奖励模板>	 */
	private Map<Integer,CorpsBossRankTemplate> bossRankMap = Maps.newHashMap();
	
	/** Map<帮派boss挑战次数排名,挑战次数排名模板>	 */
	private Map<Integer,CorpsBossCountRankTemplate> bossCountRankMap = Maps.newHashMap();
	
	
	/** Map<建筑类型,List<帮派建筑模板>>*/
	private Map<Integer, List<CorpsBuildingUpgradeTemplate>> buildingMap = Maps.newHashMap();
	
	/** Map<修炼技能Id,修炼技能模板>*/
	private Map<Integer, CorpsCultivateTemplate> cultivateMap = Maps.newHashMap();
	/** Map<修炼技能Id,修炼人物技能模板>*/
	private Map<Integer, CorpsCultivateTemplate> cultivatePlayerMap = Maps.newHashMap();
	/** Map<修炼技能Id,修炼宠物技能模板>*/
	private Map<Integer, CorpsCultivateTemplate> cultivatePetMap = Maps.newHashMap();
	/** Map<修炼等级,修炼消耗模板>*/
	private Map<Integer, CorpsCultivateCostTemplate> culCostMap = Maps.newHashMap();
	/** 修炼升级经验配置 */
	private ExpConfigInfo cultivateExpConfigInfo;
	
	
	/** Map<辅助技能Id,辅助技能模板>*/
	private Map<Integer, CorpsAssistTemplate> assistMap = Maps.newHashMap();
	/** Map<辅助等级,辅助消耗模板>*/
	private Map<Integer, CorpsAssistCostTemplate> assCostMap = Maps.newHashMap();
	/** Map<辅助技能Id, List<辅助产出模板>>*/
	private Map<Integer, List<CorpsAssistGenTemplate>> assGenMap = Maps.newHashMap(); 
	/** Map<侍剑堂等级,暴击上限>*/
	private Map<Integer, Integer> sjCritMap = Maps.newHashMap();
	
	
	public CorpsTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initUpgradeMap();
		initBenifitLst();
		initCorpsBossMap();
		initBossRankMap();
		initBossCountRankMap();
		
		initBuildingMap();
		initCultivateMap();
		initCulCostMap();
		initCulExpConfigInfo();
		
		initAssistMap();
		initAssCostMap();
		initAssGenMap();
		initSjCritMap();
		
	}

	private void initBuildingMap() {
		for(CorpsBuildingUpgradeTemplate tpl : templateService.getAll(CorpsBuildingUpgradeTemplate.class).values()){
			int type = tpl.getBuildType();
			
			List<CorpsBuildingUpgradeTemplate> lst = buildingMap.get(type);
			if(lst == null){
				lst = Lists.newArrayList();
				buildingMap.put(type, lst);
			}
			lst.add(tpl);
		}
	}
	
	/**
	 * 通过建筑类型和建筑等级,得到建筑升级模板
	 * @param type
	 * @param level
	 * @return
	 */
	public CorpsBuildingUpgradeTemplate getbldUpgradeByTypeAndLevel(int type, int level){
		if(buildingMap.containsKey(type)){
			List<CorpsBuildingUpgradeTemplate> lst = buildingMap.get(type);
			for (CorpsBuildingUpgradeTemplate tpl : lst) {
				if(tpl.getCorpsBldgLevel() == level){
					return tpl;
				}
			}
		}
		return null;
	}

	private void initCultivateMap() {
		for(CorpsCultivateTemplate tpl : templateService.getAll(CorpsCultivateTemplate.class).values()){
			cultivateMap.put(tpl.getCultivateId(), tpl);
			
			if(tpl.getPlayerSkillFlag() == SkillType.PLAYER.getIndex()){
				cultivatePlayerMap.put(tpl.getCultivateId(), tpl);
			}
			
			if(tpl.getPlayerSkillFlag() == SkillType.PET.getIndex()){
				cultivatePetMap.put(tpl.getCultivateId(), tpl);
			}
		}
		
	}
	
	/**
	 * 是否是人物技能
	 * @param skillId
	 * @return
	 */
	public boolean isPlayerSkill(int skillId){
		return cultivatePlayerMap.containsKey(skillId);
	}
	
	/**
	 * 是否是宠物技能
	 * @param skillId
	 * @return
	 */
	public boolean isPetSkill(int skillId){
		return cultivatePetMap.containsKey(skillId);
	}
	
	public Map<Integer, CorpsCultivateTemplate> getCultivateMap(){
		return this.cultivateMap;
	}
	
	public CorpsCultivateTemplate getCultivateById(int skillId){
		if(this.cultivateMap.containsKey(skillId)){
			return this.cultivateMap.get(skillId);
		}
		return null;
	}
	
	public CorpsCultivateTemplate getCultivatePlayerMapById(int skillId){
		if(this.cultivatePlayerMap.containsKey(skillId)){
			return this.cultivatePlayerMap.get(skillId);
		}
		return null;
	}
	
	public CorpsCultivateTemplate getCultivatePetMapById(int skillId){
		if(this.cultivatePetMap.containsKey(skillId)){
			return this.cultivatePetMap.get(skillId);
		}
		return null;
	}

	private void initCulCostMap() {
		for(CorpsCultivateCostTemplate tpl : templateService.getAll(CorpsCultivateCostTemplate.class).values()){
			culCostMap.put(tpl.getCultivateLevel(), tpl);
		}
	}
	
	private void initCulExpConfigInfo() {
		Map<Integer, Long> expConfigMap = new HashMap<Integer, Long>();
		for (CorpsCultivateCostTemplate tpl : templateService.getAll(CorpsCultivateCostTemplate.class).values()) {
			expConfigMap.put(tpl.getCultivateLevel(), tpl.getCostExp());
		}
		
		if(expConfigMap.isEmpty()){
			throw new TemplateConfigException("", 1, "修炼消耗经验模版为空");
		}
		this.cultivateExpConfigInfo = Globals.getExpService().createExpConfig(expConfigMap, true, 0);
	}
	
	
	/**
	 * 通过修炼等级得到修炼消耗模板
	 * @param level
	 * @return
	 */
	public CorpsCultivateCostTemplate getCulCostTplByLevel(int level){
		if(culCostMap.containsKey(level)){
			return culCostMap.get(level);
		}
		return null;
	}
	
	/**
	 * 获取修炼
	 * @return
	 */
	public ExpConfigInfo getCultivateExpConfigInfo(){
		return this.cultivateExpConfigInfo;
	}

	private void initAssistMap() {
		for(CorpsAssistTemplate tpl : templateService.getAll(CorpsAssistTemplate.class).values()){
			assistMap.put(tpl.getAssistId(), tpl);
		}
	}
	
	public Map<Integer, CorpsAssistTemplate> getAssistMap(){
		return this.assistMap;
	}
	
	public CorpsAssistTemplate getAssistTplById(int skillId){
		if(assistMap.containsKey(skillId)){
			return assistMap.get(skillId);
		}
		return null;
	}

	private void initAssCostMap() {
		for(CorpsAssistCostTemplate tpl : templateService.getAll(CorpsAssistCostTemplate.class).values()){
			assCostMap.put(tpl.getAssistLevel(), tpl);
		}
	}
	
	/**
	 * 通过辅助等级得到辅助消耗模板
	 * @param level
	 * @return
	 */
	public CorpsAssistCostTemplate getAssCostTplByLevel(int level){
		if(assCostMap.containsKey(level)){
			return assCostMap.get(level);
		}
		return null;
	}

	private void initAssGenMap() {
		for(CorpsAssistGenTemplate tpl : templateService.getAll(CorpsAssistGenTemplate.class).values()){
			int assitId = tpl.getAssistId();
			List<CorpsAssistGenTemplate> lst = assGenMap.get(assitId);
			if(lst == null){
				lst = Lists.newArrayList();
				assGenMap.put(assitId, lst);
			}
			lst.add(tpl);
		}
	}
	
	/**
	 * 通过辅助技能Id和技能等级,得到对应随机产出的项目
	 * @param id
	 * @return
	 */
	public CorpsAssistGenTemplate getAssGenLstById(int id, int level){
		if(assGenMap.containsKey(id)){
			List<CorpsAssistGenTemplate> lst = assGenMap.get(id);
			List<CorpsAssistGenTemplate> retLst = Lists.newArrayList(); 
			for (CorpsAssistGenTemplate tpl : lst) {
				if(tpl.getAssistLevel() <= level){
					retLst.add(tpl);
				}
			}
			int maxLevel = 0;
			for (CorpsAssistGenTemplate targetTpl : retLst) {
				if(maxLevel < targetTpl.getAssistLevel()){
					maxLevel = targetTpl.getAssistLevel();
				}
			}
			
			return this.getAssGenTplById(id, maxLevel);
		}
		
		return null;
	}
	
	/**
	 * 通过技能id和指定等级,来生产东西
	 * @param skillId
	 * @param targetLevel
	 * @return
	 */
	public CorpsAssistGenTemplate getAssGenTplById(int skillId, int targetLevel){
		if(assGenMap.containsKey(skillId)){
			List<CorpsAssistGenTemplate> lst = assGenMap.get(skillId);
			for (CorpsAssistGenTemplate tpl : lst) {
				if(tpl.getAssistLevel() == targetLevel){
					return tpl;
				}
			}
		}
		return null;
	}
	
	

	private void initSjCritMap() {
		for(CorpsAssistCritTemplate tpl : templateService.getAll(CorpsAssistCritTemplate.class).values()){
			sjCritMap.put(tpl.getSjLevel(), tpl.getCritLimit());
		}
	}
	
	/**
	 * 通过侍剑堂等级,得到对应的暴击率
	 * @param level
	 * @return
	 */
	public int getAssistCritByLevel(int level){
		if(sjCritMap.containsKey(level)){
			return sjCritMap.get(level);
		}
		return 0;
	}

	private void initBossCountRankMap() {
		for(CorpsBossCountRankTemplate tpl : templateService.getAll(CorpsBossCountRankTemplate.class).values()){
			bossCountRankMap.put(tpl.getRank(), tpl);
		}
	}
	
	/**
	 * 根据排名获取帮派boss挑战次数排行榜模板
	 * @param rank
	 * @return
	 */
	public CorpsBossCountRankTemplate getBossCountRankInfoByRank(int rank){
		if(bossCountRankMap.containsKey(rank)){
			return bossCountRankMap.get(rank);
		}
		return null;
	}

	private void initBossRankMap() {
		for(CorpsBossRankTemplate tpl : templateService.getAll(CorpsBossRankTemplate.class).values()){
			bossRankMap.put(tpl.getRank(), tpl);
		}
	}
	
	/**
	 * 根据排名获取帮派boss排行榜模板
	 * @param rank
	 * @return
	 */
	public CorpsBossRankTemplate getBossRankInfoByRank(int rank){
		if(bossRankMap.containsKey(rank)){
			return bossRankMap.get(rank);
		}
		return null;
	}

	private void initCorpsBossMap() {
		Set<Integer> enemyArmyIdSet = new HashSet<Integer>();
		for(CorpsBossTemplate tpl : templateService.getAll(CorpsBossTemplate.class).values()){
			bossMap.put(tpl.getBossLevel(), tpl);
			
			//怪物组Id不可以重复
			if (!enemyArmyIdSet.contains(tpl.getEnemyArmyId())) {
				enemyArmyIdSet.add(tpl.getEnemyArmyId());
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "怪物组Id重复！" + tpl.getEnemyArmyId());
			}
			
			enemyBossMap.put(tpl.getEnemyArmyId(), tpl);
			
			//怪物组Set
			enemyBossSet.add(tpl.getEnemyArmyId());
		}
	}
	
	/**
	 * 帮派boss进度是否有效
	 * @param level
	 * @return
	 */
	public boolean isValidBossLevel(int level){
		if(!bossMap.isEmpty()){
			return bossMap.containsKey(level);
		}
		return false;
	}
	
	/**
	 * 是否是帮派boss的怪物组
	 * @param enemyArmyId
	 * @return
	 */
	public boolean isCorpsBossEnemy(int enemyArmyId){
		if(!enemyBossSet.isEmpty()){
			return enemyBossSet.contains(enemyArmyId);
		}
		return false;
	}
	
	/**
	 * 根据进度查询帮派boss信息模板
	 * @param level
	 * @return
	 */
	public CorpsBossTemplate getCorpsBossInfoByLevel(int level){
		if(bossMap.containsKey(level)){
			return bossMap.get(level);
		}
		return null;
	}
	
	/**
	 * 得到帮派boss总进度
	 * @return
	 */
	public int getCorpsBossMaxLevel(){
		return bossMap.keySet().size();
	}
	
	/**
	 * 根据怪物组查询帮派boss信息模板
	 * @param level
	 * @return
	 */
	public CorpsBossTemplate getCorpsBossInfoByEnemy(int enemyArmyId){
		if(enemyBossMap.containsKey(enemyArmyId)){
			return enemyBossMap.get(enemyArmyId);
		}
		return null;
	}

	private void initBenifitLst() {
		for(CorpsBenifitTemplate tpl : templateService.getAll(CorpsBenifitTemplate.class).values()){
			benifitLst.add(tpl);
		}
	}
	
	public CorpsBenifitTemplate getCorpsBenifitByContri(int contri){
		if(contri < 0 || benifitLst.isEmpty()){
			return null;
		}
		for (CorpsBenifitTemplate tpl : benifitLst) {
			if(contri >= tpl.getContributionFoot() && contri <= tpl.getContributionTop()){
				return tpl;
			}
		}
		return null;
	}
	

	private void initUpgradeMap() {
		for (CorpsUpgradeTemplate temp : templateService.getAll(CorpsUpgradeTemplate.class).values()) {
			upgradeMap.put(temp.getCorpsLevel(), temp);
		}
	}
	
	public CorpsUpgradeTemplate getCorpsUpgradeTplByLevel(int level){
		if(upgradeMap.containsKey(level)){
			return upgradeMap.get(level);
		}
		return null;
	}
	
	public int getCorpsMaxLevel(){
		return upgradeMap.size();
	}
	
	/**
	 * 返回帮派boss最大层数
	 * @return
	 */
	public int getMaxCorpsBossLevel(){
		if(!bossMap.isEmpty()){
			return bossMap.size();
		}
		return 0;
	}
	
	/**
	 * 返回帮派boss最小层数
	 * @return
	 */
	public int getMinCorpsBossLevel(){
		if(!bossMap.isEmpty()){
			return 1;
		}
		return 0;
	}
}
