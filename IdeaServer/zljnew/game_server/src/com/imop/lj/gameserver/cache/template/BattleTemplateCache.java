package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeMap;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.skill.template.SkillAddTemplate;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;
import com.imop.lj.gameserver.skill.template.SkillPerformTemplate;
import com.imop.lj.gameserver.skill.template.SkillPetHorseAddTemplate;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 负责所有战斗相关及游戏内部军队初始化数据，与玩家数据无关
 *
 */
public class BattleTemplateCache implements InitializeRequired {
	private static final int MOD = 1000;
	protected TemplateService templateService;
	
	private Map<String, SkillPerformTemplate> skillPerformMap = Maps.newHashMap();
	
	/** Map<技能Id, List<骑宠加成技能Id>>*/
	private Map<Integer,List<Integer>> skillAddMap = Maps.newHashMap();
	private Set<Integer> skillIdSet = new HashSet<Integer>();
	
	
	public BattleTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		this.initSkillAddEffect();
		this.checkBaseSkill();
		this.initSkillPerformMap();
		this.initSkillPetHorseAdd();
	}

	private void initSkillPetHorseAdd() {
		for(SkillPetHorseAddTemplate tpl : templateService.getAll(SkillPetHorseAddTemplate.class).values()){
			int effectSkillId = tpl.getEffectSkillId();
			List<Integer> list = skillAddMap.get(effectSkillId);
			if(list == null){
				list = Lists.newArrayList();
				skillAddMap.put(effectSkillId, list);
			}
			list.add(tpl.getId());
		}
	}

	private void checkBaseSkill() {
		//检查基础技能是否存在
		if (templateService.get(BattleDef.NORMAL_ATTACK_SKILL_ID, SkillTemplate.class) == null) {
			throw new TemplateConfigException("技能配置表", 0, "必须包含基础技能-普通攻击 " + BattleDef.NORMAL_ATTACK_SKILL_ID);
		}
		getNormalAttackEffectId();
		
		if (templateService.get(BattleDef.CATCH_PET_SKILL_ID, SkillTemplate.class) == null) {
			throw new TemplateConfigException("技能配置表", 0, "必须包含基础技能-捕捉 " + BattleDef.CATCH_PET_SKILL_ID);
		}
		
		if (templateService.get(BattleDef.DEFENCE_SKILL_ID, SkillTemplate.class) == null) {
			throw new TemplateConfigException("技能配置表", 0, "必须包含基础技能-防御 " + BattleDef.DEFENCE_SKILL_ID);
		}
		
		if (templateService.get(BattleDef.ESCAPE_SKILL_ID, SkillTemplate.class) == null) {
			throw new TemplateConfigException("技能配置表", 0, "必须包含基础技能-逃跑 " + BattleDef.ESCAPE_SKILL_ID);
		}
		
		for(SkillTemplate tpl : templateService.getAll(SkillTemplate.class).values()){
			if(!skillIdSet.contains(tpl.getId())){
				skillIdSet.add(tpl.getId());
			}else{
				throw new TemplateConfigException("技能配置表", tpl.getId(), "技能ID重复");
			}
		}
		
	}
	
	private void initSkillAddEffect() {
		//生成SkillTemplate中的effectIdMap
		for (SkillAddTemplate tpl : templateService.getAll(SkillAddTemplate.class).values()) {
			SkillTemplate skillTpl = templateService.get(tpl.getSkillId(), SkillTemplate.class);
			int mindId = tpl.getMindId();
			int mindLevelMin = tpl.getMindLevelMin();
			int mindLevelMax = tpl.getMindLevelMax();
			int skillLevelMin = tpl.getSkillLevelMin();
			int skillLevelMax = tpl.getSkillLevelMax();
			if (mindId > 0) {
				skillTpl.setHasMindIdLimit(true);
			}
			if (mindLevelMin > 0 || mindLevelMax > 0) {
				skillTpl.setHasMindLevelLimit(true);
			}
			if (skillLevelMin > 0 || skillLevelMax > 0) {
				skillTpl.setHasSkillLevelLimit(true);
			}
			
			int mindLevelKey = calcLevelKey(mindLevelMin, mindLevelMax);
			int skillLevelKey = calcLevelKey(skillLevelMin, skillLevelMax);
			
			Map<Integer, Map<Integer, Map<Integer, List<Integer>>>> m = skillTpl.getTmpEffectIdMap();
			Map<Integer, Map<Integer, List<Integer>>> m1 = m.get(mindId);
			if (m1 == null) {
				m1 = Maps.newHashMap();
				m.put(mindId, m1);
			}
			Map<Integer, List<Integer>> m2 = m1.get(mindLevelKey);
			if (m2 == null) {
				m2 = Maps.newHashMap();
				m1.put(mindLevelKey, m2);
			}
			List<Integer> m3 = m2.get(skillLevelKey);
			if (m3 == null) {
				m3 = tpl.getValidEffectIdList();
				m2.put(skillLevelKey, m3);
			} else {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "同一等级段只能有1条数据！");
			}
		}
		
		//检查等级段是否合法
		for (SkillTemplate skillTpl : templateService.getAll(SkillTemplate.class).values()) {
			if (skillTpl.isHasMindLevelLimit() && !skillTpl.isHasMindIdLimit()) {
				throw new TemplateConfigException(skillTpl.getSheetName(), skillTpl.getId(), "有心法等级限制，但没有心法Id限制！");
			}
			
			//检查心法等级段
			if (skillTpl.isHasMindLevelLimit()) {
				int mindLevelMax = Globals.getGameConstants().getLevelMax();
				//检查等级段是否有重叠，是否覆盖所有等级
				for (Integer mindId : skillTpl.getTmpEffectIdMap().keySet()) {
					checkLevelSection(skillTpl.getTmpEffectIdMap().get(mindId).keySet(), 
							mindLevelMax, skillTpl.getSheetName(), skillTpl.getId());
				}
			}
			
			//检查技能等级段
			if (skillTpl.isHasSkillLevelLimit()) {
				int skillLevelMax = Globals.getGameConstants().getLevelMax();
				if (skillTpl.getSkillType() == SkillType.PET_NORMAL || skillTpl.getSkillType() == SkillType.PET_TALENT
						|| skillTpl.getSkillType() == SkillType.MIND_A || skillTpl.getSkillType() == SkillType.LEADER_STUDY) {
					skillLevelMax = Globals.getGameConstants().getPetSkillLevelMax();
				}
				
				//检查等级段是否有重叠，是否覆盖所有等级
				for (Integer mindId : skillTpl.getTmpEffectIdMap().keySet()) {
					for (Map<Integer, List<Integer>> m : skillTpl.getTmpEffectIdMap().get(mindId).values()) {
						checkLevelSection(m.keySet(), skillLevelMax, skillTpl.getSheetName(), skillTpl.getId());
					}
				}
			}
			
			//生成等级对应的map
			Map<Integer, Map<Byte, Map<Byte, List<Integer>>>> em = skillTpl.getEffectIdMap();
			for (Integer mindId : skillTpl.getTmpEffectIdMap().keySet()) {
				Map<Byte, Map<Byte, List<Integer>>> em1 = Maps.newHashMap();
				em.put(mindId, em1);
				
				for (Integer mindLevelKey : skillTpl.getTmpEffectIdMap().get(mindId).keySet()) {
					Map<Byte, List<Integer>> tmp = Maps.newHashMap();
					for (Integer skillLevelKey : skillTpl.getTmpEffectIdMap().get(mindId).get(mindLevelKey).keySet()) {
						List<Integer> fList = new ArrayList<Integer>();
						fList.addAll(skillTpl.getTmpEffectIdMap().get(mindId).get(mindLevelKey).get(skillLevelKey));
						int lmin = skillLevelKey / MOD;
						int lmax = skillLevelKey % MOD;
						for (int j = lmin; j <= lmax; j++) {
							tmp.put((byte)j, fList);
						}
					}
					
					int min = mindLevelKey / MOD;
					int max = mindLevelKey % MOD;
					for (int i = min; i <= max; i++) {
						em1.put((byte)i, tmp);
					}
				}
			}
			//清除临时数据
			skillTpl.getTmpEffectIdMap().clear();
		}
		
	}
	
	private void checkLevelSection(Set<Integer> levelKeySet, int levelMax, String sheetName, int sheetId) {
		Map<Integer, Integer> tmpMap = new TreeMap<Integer, Integer>();
		for (Integer levelKey : levelKeySet) {
			int min = levelKey / MOD;
			int max = levelKey % MOD;
			if (tmpMap.containsKey(min)) {
				throw new TemplateConfigException(sheetName, sheetId, "等级段不能重叠！");
			}
			tmpMap.put(min, max);
		}
		
		int start = 0;
		int end = 0;
		int preEnd = 0;
		for (Entry<Integer, Integer> e : tmpMap.entrySet()) {
			if (start == 0) {
				start = e.getKey();
				//开始的等级必须是1级
				if (start != 1) {
					throw new TemplateConfigException(sheetName, sheetId, "等级段必须从1开始！");
				}
			}
			//等级段必须是连续的
			if (preEnd > 0) {
				if (e.getKey() != preEnd + 1) {
					throw new TemplateConfigException(sheetName, sheetId, "等级段重叠或缺失！");
				}
			}
			
			end = e.getValue();
			preEnd = end;
		}
		//至少要包含到当前最高等级
		if (end < levelMax) {
			throw new TemplateConfigException(sheetName, sheetId, "等级段缺失！end=" + end);
		}
	}
	
	private int calcLevelKey(int levelMin, int levelMax) {
		return levelMin * MOD + levelMax;
	}

	private void initSkillPerformMap() {
		for (SkillPerformTemplate tpl : templateService.getAll(SkillPerformTemplate.class).values()) {
			this.skillPerformMap.put(tpl.getComposeId(), tpl);
		}
	}
	
	/**
	 * 获取没有心法影响的技能效果
	 * @param skillId
	 * @param skillLevel
	 * @param skillLayer
	 * @return
	 */
	public List<IEffect> getSkillEffectsNoMind(int skillId, int skillLevel, int skillLayer) {
		return getSkillEffects(skillId, skillLevel, 1, 0, 0);
	}
	
	/**
	 * 获得skillId对应的战斗效果
	 * @param skillId
	 * @param skillLayer
	 * @return
	 */
	public List<IEffect> getSkillEffects(int skillId, int skillLevel, int skillLayer, int mindId, int mindLevel) {
		List<IEffect> effects = new ArrayList<IEffect>();
		List<Integer> eList = getSkillEffectIdList(skillId, skillLevel, mindId, mindLevel);
		if (eList != null && !eList.isEmpty()) {
			effects = EffectFactory.createSkillEffect(eList, skillId, skillLevel, skillLayer);
		}
		return effects;
	}
	
	public List<Integer> getSkillEffectIdList(int skillId, int skillLevel, int mindId, int mindLevel) {
		SkillTemplate tpl = templateService.get(skillId, SkillTemplate.class);
		if (tpl == null) {
			return null;
		}
		if (!tpl.isHasMindIdLimit()) {
			mindId = 0;
		}
		if (!tpl.isHasMindLevelLimit()) {
			mindLevel = 0;
		}
		if (!tpl.isHasSkillLevelLimit()) {
			skillLevel = 0;
		}
		
		byte ml = (byte)mindLevel;
		byte sl = (byte)skillLevel;
		
		List<Integer> eList = null;
		if (tpl.getEffectIdMap().containsKey(mindId) &&
				tpl.getEffectIdMap().get(mindId).containsKey(ml) &&
				tpl.getEffectIdMap().get(mindId).get(ml).containsKey(sl)) {
			eList = tpl.getEffectIdMap().get(mindId).get(ml).get(sl);
		}
		return eList;
	}
	
	public SkillEffectTemplate getSkillMainEffectTpl(int skillId, int skillLevel, int mindId, int mindLevel) {
		List<Integer> effectIdList = getSkillEffectIdList(skillId, skillLevel, mindId, mindLevel);
		if (effectIdList != null && !effectIdList.isEmpty()) {
			int eId = effectIdList.get(0);
			return templateService.get(eId, SkillEffectTemplate.class);
		}
		return null;
	}
	
	public int getNormalAttackEffectId() {
		List<Integer> effectIdList = getSkillEffectIdList(BattleDef.NORMAL_ATTACK_SKILL_ID, 0, 0, 0);
		return effectIdList.get(0);
	}
	
	public int getSkillPerformTime(String composeId) {
		int time = BattleDef.SKILL_PERFORM_TIME_DEFAULT;
		if (this.skillPerformMap.containsKey(composeId)) {
			if (this.skillPerformMap.get(composeId).getTotalTime() > 0) {
				//XXX 配置表的时间+2秒
				time = (int)(this.skillPerformMap.get(composeId).getTotalTime() * 1000) + 2000;
			}
		}
		return time;
	}
	
	public int getSkillPerformTimeMin(String composeId) {
		int time = BattleDef.SKILL_PERFORM_TIME_MIN;
		if (this.skillPerformMap.containsKey(composeId)) {
			if (this.skillPerformMap.get(composeId).getTotalTime() > 0) {
				time = (int)(this.skillPerformMap.get(composeId).getTotalTime() * 1000);
			}
		}
		return time;
	}
	
	/**
	 * 权重大于0的时候,说明就是走权重
	 * @param skillEffectIdList
	 * @num
	 * @return
	 */
	public SkillEffectTemplate getBuffWeightLst(List<Integer> skillEffectIdList, int num){
		if(skillEffectIdList == null || skillEffectIdList.isEmpty() || num <= 0){
			return null;
		}
		//四相决1级技能效果列表
//		List<Integer> skillEffectIdList = getSkillEffectIdList(813001, 1, 0, 0);
		List<Integer> buffWeightList = Lists.newArrayList();
		for (Integer effectId : skillEffectIdList) {
			for(SkillEffectTemplate tpl : templateService.getAll(SkillEffectTemplate.class).values()){
				if(effectId == tpl.getId()){
					buffWeightList.add(tpl.getEffectWeight());
				}
			}
		}
		
		List<Integer> randomList = RandomUtils.hitObjectsWithWeightNum(buffWeightList, skillEffectIdList, num);
		if(randomList.isEmpty()){
			return null;
		}
		
		return templateService.get(randomList.get(0), SkillEffectTemplate.class);
	}
	
	
	public List<Integer> getPetHorseAddSkillId(int skillId){
		List<Integer> lst = new ArrayList<Integer>();
		
		if(this.skillAddMap.containsKey(skillId)){
			lst.addAll(this.skillAddMap.get(skillId));
		}
		
		return lst;
	}
	
	/**
	 * 根据技能等级得到对应的值
	 * @param level
	 * @param effectTpl
	 * @return
	 */
	public int getFinalSkillValue(int level, SkillPetHorseAddTemplate effectTpl ){
		if(level <= 0 || effectTpl == null){
			return 0;
		}
		List<Integer> addList = effectTpl.getLevelAddList();
		for (int i = 0; i < addList.size(); i++) {
			if(level == i + 1){
				return addList.get(i);
			}
			
		}
		return 0;
	}

	
}