package com.imop.lj.gameserver.cache.template;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.nvn.template.NvnConWinScoreTemplate;
import com.imop.lj.gameserver.nvn.template.NvnEndConWinScoreTemplate;
import com.imop.lj.gameserver.nvn.template.NvnMatchRankTemplate;
import com.imop.lj.gameserver.nvn.template.NvnRankRewardTemplate;

public class NvnTemplateCache implements InitializeRequired {
	protected TemplateService templateService;

	//Map<排名，对应模板>，排名key从配置表第一列最小值到最大值都有，超过最大值的按最大值算即可，下面几个数据结构类似
	private Map<Integer, NvnRankRewardTemplate> rankRewardMap = Maps.newHashMap();
	//排名最大值，超过这个值按这个值算，这样就能从上面的map中直接取到对应模板，下面几个数据结构类似
	private int rankRewardMax;
	
	private Map<Integer, NvnConWinScoreTemplate> conWinMap = Maps.newHashMap();
	private int conWinMax; 
	
	private Map<Integer, NvnEndConWinScoreTemplate> endConWinMap = Maps.newHashMap();
	private int endConWinMax; 
	
	private Map<Integer, Integer> matchRankMap = Maps.newHashMap();
	private int matchRankMax;
	
	private List<String> showRewardList = new ArrayList<String>();
	private List<String> showRewardNameList = new ArrayList<String>();
	
	
	public NvnTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}
	
	@Override
	public void init() {
		initRankRewardMap();
		initConWinMap();
		initEndConWinMap();
		initMatchRankMap();
	}
	
	private void initRankRewardMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(NvnRankRewardTemplate.class).keySet());
		Collections.sort(rList);
		rankRewardMax = rList.get(rList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				rankRewardMap.put(j, templateService.get(rank1, NvnRankRewardTemplate.class));
			}
		}
		//放最后一个
		rankRewardMap.put(rankRewardMax, templateService.get(rankRewardMax, NvnRankRewardTemplate.class));
		
		if (!rankRewardMap.containsKey(1)) {
			throw new TemplateConfigException("", 0, "nvn.xls nvn排名奖励 不是从1开始的！");
		}
	}
	
	private void initConWinMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(NvnConWinScoreTemplate.class).keySet());
		Collections.sort(rList);
		conWinMax = rList.get(rList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				conWinMap.put(j, templateService.get(rank1, NvnConWinScoreTemplate.class));
			}
		}
		//放最后一个
		conWinMap.put(conWinMax, templateService.get(conWinMax, NvnConWinScoreTemplate.class));
	}
	
	private void initEndConWinMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(NvnEndConWinScoreTemplate.class).keySet());
		Collections.sort(rList);
		endConWinMax = rList.get(rList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				endConWinMap.put(j, templateService.get(rank1, NvnEndConWinScoreTemplate.class));
			}
		}
		//放最后一个
		endConWinMap.put(endConWinMax, templateService.get(endConWinMax, NvnEndConWinScoreTemplate.class));
	}
	
	private void initMatchRankMap() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(NvnMatchRankTemplate.class).keySet());
		Collections.sort(rList);
		matchRankMax = rList.get(rList.size() - 1);
		
		//放前面的n-1个
		for (int i = 0; i < rList.size() - 1; i++) {
			int rank1 = rList.get(i);
			int rank2 = rList.get(i + 1);
			for (int j = rank1; j < rank2; j++) {
				matchRankMap.put(j, rank1);
			}
		}
		//放最后一个
		matchRankMap.put(matchRankMax, matchRankMax);
		
		if (!matchRankMap.containsKey(1)) {
			throw new TemplateConfigException("", 0, "nvn.xls 匹配排名段 不是从1开始的！");
		}
	}
	
	public void initShowRewardList() {
		List<Integer> rList = new ArrayList<Integer>();
		rList.addAll(templateService.getAll(NvnRankRewardTemplate.class).keySet());
		Collections.sort(rList);
		for (Integer k : rList) {
			NvnRankRewardTemplate tpl = templateService.get(k, NvnRankRewardTemplate.class);
			RewardInfo info = Globals.getRewardService().createShowRewardInfo(tpl.getShowRewardId());
			this.showRewardList.add(info.getRewardStr());
			this.showRewardNameList.add(tpl.getShowRewardName());
		}
	}

	public NvnRankRewardTemplate getNvnRankRewardTemplate(int rank) {
		if (rank > rankRewardMax) {
			rank = rankRewardMax;
		}
		return rankRewardMap.get(rank);
	}
	
	public NvnConWinScoreTemplate getNvnConWinScoreTemplate(int conWin) {
		if (conWin > conWinMax) {
			conWin = conWinMax;
		}
		return conWinMap.get(conWin);
	}
	
	public NvnEndConWinScoreTemplate getNvnEndConWinScoreTemplate(int endConWin) {
		if (endConWin > endConWinMax) {
			endConWin = endConWinMax;
		}
		return endConWinMap.get(endConWin);
	}
	
	public int getMatchRankRange(int rank) {
		if (rank > matchRankMax) {
			rank = matchRankMax;
		}
		return matchRankMap.get(rank);
	}
	
	public List<String> getShowRewardList() {
		return this.showRewardList;
	}
	
	public List<String> getShowRewardNameList() {
		return this.showRewardNameList;
	}
}