package com.imop.lj.gameserver.cache.template;

import java.util.Map;
import java.util.TreeMap;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.reward.template.ShowRewardTemplate;
import com.imop.lj.gameserver.xianhu.XianhuDef.XianhuRankType;
import com.imop.lj.gameserver.xianhu.template.XianhuRankRewardTemplate;

public class XianhuTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	protected Map<XianhuRankType, Map<Integer, XianhuRankRewardTemplate>> rankRewardMap = Maps.newHashMap();
	protected Map<XianhuRankType, Integer> rankMaxMap = Maps.newHashMap();
	
	public XianhuTemplateCache(TemplateService templateService){
		this.templateService = templateService;
	}

	@Override
	public void init() {
		//TODO FIXME
//		checkReward();
		initRankRewardMap();
	}
	
	private void checkReward() {
		//祝福奖励检查
		RewardConfigTemplate rewardTpl1 = templateService.get(Globals.getGameConstants().getXianhuZhufuRewardId(), RewardConfigTemplate.class);
		if (null == rewardTpl1) {
			throw new TemplateConfigException("", 0, String.format("仙葫祝福奖励Id不存在[%d]", Globals.getGameConstants().getXianhuZhufuRewardId()));
		}
		//祝福奖励类型检查
		if (rewardTpl1.getRewardReasonType() != RewardReasonType.XIANHU_ZHUFU_REWARD) {
			throw new TemplateConfigException("", 0, String.format("仙葫祝福奖励身份识别类型[%d]", rewardTpl1.getRewardReasonTypeId()));
		}
		
		//祈福奖励检查
		RewardConfigTemplate rewardTpl2 = templateService.get(Globals.getGameConstants().getXianhuQifuRewardId(), RewardConfigTemplate.class);
		if (null == rewardTpl2) {
			throw new TemplateConfigException("", 0, String.format("仙葫祈福奖励Id不存在[%d]", Globals.getGameConstants().getXianhuQifuRewardId()));
		}
		//祈福奖励类型检查
		if (rewardTpl2.getRewardReasonType() != RewardReasonType.XIANHU_QIFU_REWARD) {
			throw new TemplateConfigException("", 0, String.format("仙葫祈福奖励身份识别类型[%d]", rewardTpl2.getRewardReasonTypeId()));
		}
		
		//富贵奖励检查
		RewardConfigTemplate rewardTpl3 = templateService.get(Globals.getGameConstants().getXianhuFuguiRewardId(), RewardConfigTemplate.class);
		if (null == rewardTpl3) {
			throw new TemplateConfigException("", 0, String.format("仙葫富贵奖励Id不存在[%d]", Globals.getGameConstants().getXianhuFuguiRewardId()));
		}
		//富贵奖励类型检查
		if (rewardTpl3.getRewardReasonType() != RewardReasonType.XIANHU_EXTRA_REWARD) {
			throw new TemplateConfigException("", 0, String.format("仙葫富贵奖励身份识别类型[%d]", rewardTpl3.getRewardReasonTypeId()));
		}
		
		//至尊奖励检查
		RewardConfigTemplate rewardTpl4 = templateService.get(Globals.getGameConstants().getXianhuZhizunRewardId(), RewardConfigTemplate.class);
		if (null == rewardTpl4) {
			throw new TemplateConfigException("", 0, String.format("仙葫至尊奖励Id不存在[%d]", Globals.getGameConstants().getXianhuZhizunRewardId()));
		}
		//至尊奖励类型检查
		if (rewardTpl4.getRewardReasonType() != RewardReasonType.XIANHU_EXTRA_REWARD) {
			throw new TemplateConfigException("", 0, String.format("仙葫至尊奖励身份识别类型[%d]", rewardTpl4.getRewardReasonTypeId()));
		}
		
		//显示奖励id是否存在
		if (null == templateService.get(Globals.getGameConstants().getXianhuShowRewardId(), ShowRewardTemplate.class)) {
			throw new TemplateConfigException("", 0, String.format("祝福祈福仙葫显示奖励Id不存在[%d]", Globals.getGameConstants().getXianhuShowRewardId()));
		}
		if (null == templateService.get(Globals.getGameConstants().getXianhuFuguiShowRewardId(), ShowRewardTemplate.class)) {
			throw new TemplateConfigException("", 0, String.format("富贵仙葫显示奖励id不存在[%d]", Globals.getGameConstants().getXianhuFuguiShowRewardId()));
		}
		if (null == templateService.get(Globals.getGameConstants().getXianhuZhizunShowRewardId(), ShowRewardTemplate.class)) {
			throw new TemplateConfigException("", 0, String.format("至尊仙葫显示奖励id不存在[%d]", Globals.getGameConstants().getXianhuZhizunShowRewardId()));
		}
	}
	
	private void initRankRewardMap() {
		for (XianhuRankRewardTemplate tpl : templateService.getAll(XianhuRankRewardTemplate.class).values()) {
			XianhuRankType type = tpl.getRankType();
			Map<Integer, XianhuRankRewardTemplate> m1 = this.rankRewardMap.get(type);
			if (m1 == null) {
				m1 = new TreeMap<Integer, XianhuRankRewardTemplate>();
				this.rankRewardMap.put(type, m1);
			}
			if (m1.containsKey(tpl.getRankMax())) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "排名上限重复！");
			}
			
			m1.put(tpl.getRankMax(), tpl);
			
			if (this.rankMaxMap.get(type) == null ||
					this.rankMaxMap.get(type) < tpl.getRankMax()) {
				this.rankMaxMap.put(type, tpl.getRankMax());
			}
		}
	}
	
	/**
	 * 获取仙葫排名奖励模板
	 * @param type
	 * @param rank
	 * @return
	 */
	public XianhuRankRewardTemplate getRankRewardTpl(XianhuRankType type, int rank) {
		if (type != null && rank > 0 && this.rankRewardMap.get(type) != null) {
			if (rank <= this.rankMaxMap.get(type)) {
				Map<Integer, XianhuRankRewardTemplate> m1 = this.rankRewardMap.get(type);
				for (Integer rk : m1.keySet()) {
					if (rank <= rk) {
						return m1.get(rk);
					}
				}
			}
		}
		return null;
	}
	
	/**
	 * 是否有排名奖励
	 * @param type
	 * @param rank
	 * @return
	 */
	public boolean hasRankReward(XianhuRankType type, int rank) {
		if (type != null && rank > 0 &&
				this.rankMaxMap.get(type) != null &&
				rank <= this.rankMaxMap.get(type)) {
			return true;
		}
		return false;
	}
	
}
