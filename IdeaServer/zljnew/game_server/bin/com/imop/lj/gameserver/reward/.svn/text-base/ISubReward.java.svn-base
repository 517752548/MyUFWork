package com.imop.lj.gameserver.reward;

import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.template.RewardTemplate;

/**
 * 奖励接口
 * 
 * @author xiaowei.liu
 * 
 */
public interface ISubReward {
	/**
	 * 添加奖励，之前需要调用checkParam
	 * 
	 * @param param
	 * @return
	 */
	boolean addReward(RewardParam param);

	/**
	 * 转化为奖励参数列表
	 * 
	 * @return
	 */
	List<RewardParam> toRewardParamList();

	/**
	 * 获取奖励描述
	 * 
	 * @return
	 */
	String getRewardString();

	/**
	 * 获取消息中的字符串
	 * 
	 * @return
	 */
	String getMsgString();

	/**
	 * 能否给个人奖励
	 * 
	 * @param human
	 * @param needNotify
	 * @return
	 */
	boolean canGiveReward(Human human, boolean needNotify);

	/**
	 * 给个人奖励
	 * 
	 * @param human
	 * @param needNotify
	 * @return
	 */
	boolean giveReward(Human human, boolean needNotify);

	/**
	 * 给军团奖励
	 * 
	 * @param corps
	 * @param needNotify
	 * @return
	 */
	boolean giveCorpsReward(Corps corps, boolean needNotify);

	/**
	 * 创建空的子类型奖励
	 * 
	 * @return
	 */
	ISubReward createEmptySubReward(Reward reward);

	/**
	 * 检查参数是否正常
	 * 
	 * @param param
	 * @return
	 */
	boolean checkParam(RewardParam param);

	/**
	 * 检查模版是否正确
	 * 
	 * @param setTmpl
	 * @param tmpl
	 * @return
	 */
	String checkTemplate(RewardTemplate tmpl);

	/**
	 * 奖励修正
	 * 
	 * @param amendMap
	 */
	void amend(Map<RewardAddedType, Integer> amendMap);
	
	/**
	 * 获取奖励类型
	 * @return
	 */
	RewardType getRewardType();
}
