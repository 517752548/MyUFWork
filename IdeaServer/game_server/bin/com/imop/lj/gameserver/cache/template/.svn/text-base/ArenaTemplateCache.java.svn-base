package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.arena.template.ArenaBattleRewardTemplate;
import com.imop.lj.gameserver.arena.template.ArenaBuyTimesTemplate;
import com.imop.lj.gameserver.arena.template.ArenaConWinNoticeTemplate;
import com.imop.lj.gameserver.arena.template.ArenaLeaderSkillWeightTemplate;
import com.imop.lj.gameserver.arena.template.ArenaRankChallengeTemplate;
import com.imop.lj.gameserver.arena.template.ArenaRankRewardTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.JobType;

public class ArenaTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	protected Map<Integer, ArenaRankChallengeTemplate> challengeRankMap = Maps.newHashMap();
	protected int challengeRankMax;
	//不同规则的分界线，小于此分界线，用配置的范围；超过此分界线，用selfRank减去配置值
	protected int challengeRankCritical;
	
	protected Map<Integer, ArenaBattleRewardTemplate> battleRewardMap = Maps.newHashMap();
	protected int levelMax;
	
	protected Map<Integer, ArenaRankRewardTemplate> rankRewardMap = Maps.newHashMap();
	protected int rankMax;
	
	protected List<Integer> rankRewardKeyList = new ArrayList<Integer>();
	protected List<String> showRewardList = new ArrayList<String>();
	
	protected int buyTimesMax;
	
	/** 连胜公告配置模板列表，按照连胜排序 */
	protected List<ArenaConWinNoticeTemplate> conWinNoticeTplList = new LinkedList<ArenaConWinNoticeTemplate>();
	
	/** 主将按职业的技能Map<职业，Map<技能Id，权重模板>> */
	protected Map<JobType, Map<Integer, ArenaLeaderSkillWeightTemplate>> leaderSkillWeightMap = Maps.newHashMap();
	
	public ArenaTemplateCache(TemplateService templateService){
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initChallengeRankMap();
		initBattleRewardMap();
		initRankRewardMap();
		initConWinNoticeTplList();
		initBuyTimes();
		initLeaderSkillWeightMap();
	}
	
	private void initChallengeRankMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(ArenaRankChallengeTemplate.class).keySet());
		Collections.sort(rList);
		this.challengeRankMax = rList.get(rList.size() - 1);
		//不同规则的分界线
		this.challengeRankCritical = rList.get(1) - 1;
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				challengeRankMap.put(j, templateService.get(rank1, ArenaRankChallengeTemplate.class));
			}
		}
		//放最后一个
		this.challengeRankMap.put(this.challengeRankMax, templateService.get(this.challengeRankMax, ArenaRankChallengeTemplate.class));
		
		if (!this.challengeRankMap.containsKey(1)) {
			throw new TemplateConfigException("", 0, "arena.xls 对手排名 不是从1开始的！");
		}
	}
	
	
	
	private void initBattleRewardMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(ArenaBattleRewardTemplate.class).keySet());
		Collections.sort(rList);
		this.levelMax = rList.get(rList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				battleRewardMap.put(j, templateService.get(rank1, ArenaBattleRewardTemplate.class));
			}
		}
		//放最后一个
		this.battleRewardMap.put(this.levelMax, templateService.get(this.levelMax, ArenaBattleRewardTemplate.class));
		
		if (!this.battleRewardMap.containsKey(1)) {
			throw new TemplateConfigException("", 0, "arena.xls 战斗奖励 不是从1开始的！");
		}
	}
	
	private void initRankRewardMap() {
		rankRewardKeyList.addAll(templateService.getAll(ArenaRankRewardTemplate.class).keySet());
		Collections.sort(rankRewardKeyList);
		this.rankMax = rankRewardKeyList.get(rankRewardKeyList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rankRewardKeyList.size() - 1; i++) {
			int rank1 = rankRewardKeyList.get(i);
			int rank2 = rankRewardKeyList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				rankRewardMap.put(j, templateService.get(rank1, ArenaRankRewardTemplate.class));
			}
		}
		//放最后一个
		this.rankRewardMap.put(this.rankMax, templateService.get(this.rankMax, ArenaRankRewardTemplate.class));
		
		if (!this.rankRewardMap.containsKey(1)) {
			throw new TemplateConfigException("", 0, "arena.xls 排名奖励 不是从1开始的！");
		}
	}
	
	protected void initConWinNoticeTplList() {
		conWinNoticeTplList.addAll(templateService.getAll(ArenaConWinNoticeTemplate.class).values());
		Collections.sort(conWinNoticeTplList, new Comparator<ArenaConWinNoticeTemplate>() {
			/**
			 * 按照连胜次数排序
			 */
			@Override
			public int compare(ArenaConWinNoticeTemplate o1,
					ArenaConWinNoticeTemplate o2) {
				if (o1.getConWinTimes() > o2.getConWinTimes()) {
					return 1;
				} else if (o1.getConWinTimes() < o2.getConWinTimes()) {
					return -1;
				}
				return 0;
			}
		});
	}
	
	protected void initBuyTimes() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(ArenaBuyTimesTemplate.class).keySet());
		Collections.sort(rList);
		this.buyTimesMax = rList.get(rList.size() - 1);
		
		for (int i = 1; i <= this.buyTimesMax; i++) {
			if (null == templateService.get(i, ArenaBuyTimesTemplate.class)) {
				throw new TemplateConfigException("", 0, "竞技场购买消耗配置错误！缺少 " + i);
			}
		}
	}
	
	protected void initLeaderSkillWeightMap() {
		for (ArenaLeaderSkillWeightTemplate tpl : templateService.getAll(ArenaLeaderSkillWeightTemplate.class).values()) {
			JobType jt = JobType.valueOf(tpl.getJobTypeId());
			Map<Integer, ArenaLeaderSkillWeightTemplate> m = this.leaderSkillWeightMap.get(jt);
			if (m == null) {
				m = new HashMap<Integer, ArenaLeaderSkillWeightTemplate>();
				this.leaderSkillWeightMap.put(jt, m);
			}
			m.put(tpl.getSkillId(), tpl);
		}
	}
	
	public void initShowRankRewardList() {
		for (Integer rank : rankRewardKeyList) {
			ArenaRankRewardTemplate tpl = templateService.get(rank, ArenaRankRewardTemplate.class);
			RewardInfo rewardInfo = Globals.getRewardService().createShowRewardInfo(tpl.getShowRewardId());
			showRewardList.add(rewardInfo.getRewardStr());
		}
	}
	
	public int getChallengeRankCritical() {
		return this.challengeRankCritical;
	}
	
	public ArenaRankChallengeTemplate getRankChallengeTpl(int rank) {
		if (rank > this.challengeRankMax) {
			rank = this.challengeRankMax;
		}
		return this.challengeRankMap.get(rank);
	}
	
	public ArenaBattleRewardTemplate getBattleRewardTpl(int level) {
		if (level > this.levelMax) {
			level = this.levelMax;
		}
		return this.battleRewardMap.get(level);
	}
	
	public ArenaRankRewardTemplate getRankRewardTpl(int rank) {
		if (rank > rankMax) {
			rank = rankMax;
		}
		return this.rankRewardMap.get(rank);
	}
	
	public ArenaBuyTimesTemplate getBuyTimesTpl(int times) {
		if (times > this.buyTimesMax) {
			times = this.buyTimesMax;
		}
		return templateService.get(times, ArenaBuyTimesTemplate.class);
	}
	
	/**
	 * 根据连胜次数，获取连胜公告模板
	 * @param conWinTimes
	 * @return
	 */
	public ArenaConWinNoticeTemplate getConWinNoticeTplByConWinTimes(int conWinTimes) {
		for (ArenaConWinNoticeTemplate tpl : conWinNoticeTplList) {
			if (conWinTimes == tpl.getConWinTimes()) {
				return tpl;
			} else if (conWinTimes < tpl.getConWinTimes()) {
				break;
			}
		}
		return null;
	}
	
	/**
	 * 根据职业获取技能权重map
	 * @param jt
	 * @return
	 */
	public Map<Integer, ArenaLeaderSkillWeightTemplate> getLeaderSkillWeightMap(JobType jt) {
		return this.leaderSkillWeightMap.get(jt);
	}
	
	/**
	 * 获取排名奖励的排名列表，按排名从小到大排序
	 * @return
	 */
	public List<Integer> getRankRewardKeyList() {
		return this.rankRewardKeyList;
	}
	
	/**
	 * 获取排名奖励列表
	 * @return
	 */
	public List<String> getShowRewardList() {
		return this.showRewardList;
	}
}
