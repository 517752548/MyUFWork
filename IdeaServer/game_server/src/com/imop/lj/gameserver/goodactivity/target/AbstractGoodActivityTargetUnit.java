package com.imop.lj.gameserver.goodactivity.target;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 活动目标（奖励）单元对象
 * @author yu.zhao
 *
 */
public abstract class AbstractGoodActivityTargetUnit implements IGoodActivityTargetUnit {
	/** 目标（奖励）Id */
	public static final String TARGET_ID_KEY = "1";
	/** 奖励信息 */
	public static final String REWARD_INFO_KEY = "2";
	/** 目标1描述 */
	public static final String COND_DESC_KEY = "3";
	/** 目标2描述 */
	public static final String COND_SECOND_DESC_KEY = "4";
	/** 目标面板链接 */
	public static final String PANEL_LINK_KEY = "5";
	/** 目标面板名称 */
	public static final String PANEL_LINK_NAME_KEY = "6";
	/** 能否领取奖励 */
	public static final String CAN_GIVE_KEY = "7";
	/** 是否领取过奖励 */
	public static final String HAS_GIVE_KEY = "8";
	/** 不能领奖时是否显示按钮 */
	public static final String SHOW_BTN_KEY = "9";
	/** 目标1分子 */
	public static final String CURR_NUM_KEY = "10";
	/** 目标2分子 */
	public static final String CURR_NUM_SECOND_KEY = "11";
	/** 目标1分母 */
	public static final String NEED_NUM_KEY = "12";
	/** 目标2分母 */
	public static final String NEED_NUM_SECOND_KEY = "13";
	/** 分组Id */
	public static final String TARGET_GROUP_KEY = "14";
	/** 目标面板类型 */
	public static final String PANEL_LINK_TYPE_KEY = "15";
	
	
	/** 所属活动 */
	private AbstractGoodActivity activity;
	/** 目标（奖励）模板 */
	private GoodActivityTargetTemplate targetTpl;
	
	/** 目标Id */
	private int targetId;
	/** 显示奖励缓存 */
	private RewardInfo showRewardInfo;
	
	public AbstractGoodActivityTargetUnit(AbstractGoodActivity activity, GoodActivityTargetTemplate targetTpl) {
		this.activity = activity;
		this.targetTpl = targetTpl;
		this.targetId = targetTpl.getId();
		if (targetTpl.getRewardId() > 0) {
			this.showRewardInfo = Globals.getRewardService().createRewardInfo(0, targetTpl.getRewardId(), "", null);
		} else {
			this.showRewardInfo = new RewardInfo();
		}
	}
	
	public final AbstractGoodActivity getActivity() {
		return activity;
	}

	public final int getTargetId() {
		return targetId;
	}

	public GoodActivityTargetTemplate getTargetTpl() {
		return targetTpl;
	}

	public String getCondDesc() {
		return targetTpl.getDesc();
	}
	
	public String getCondSecondDesc() {
		return targetTpl.getDescSecond();
	}

	public String getPanelType() {
		return targetTpl.getPanelType() + "";
	}
	
	public String getPanelLink() {
		return targetTpl.getPanelLink() + "";
	}
	
	public String getPanelLinkName() {
		return targetTpl.getLinkName();
	}

	public RewardInfo getRewardInfo() {
		return showRewardInfo;
	}
	
	/**
	 * 不可领取奖励时是否显示按钮
	 * @return
	 */
	public int getShowBtn() {
		return targetTpl.getShowBtn();
	}
	
	/**
	 * 获取显示目标的分组，默认为0，其他模块可重写
	 * @return
	 */
	public int getShowGroupId() {
		return 0;
	}
	
	public Reward createReward(long charId, String source) {
		if (targetTpl.getRewardId() > 0) {
			return Globals.getRewardService().createReward(charId, targetTpl.getRewardId(), source);
		}
		return null;
	}
	
	public boolean canGiveReward(AbstractUserGoodActivity userActivity) {
		if (activity.isInGiveBonusState()) {
			if (null != userActivity && null != userActivity.getUserDataModel()) {
				return userActivity.getUserDataModel().hasUnGiveBonus(getTargetId());
			}
		}
		return false;
	}

	public boolean hasGiveReward(AbstractUserGoodActivity userActivity) {
		if (null != userActivity && null != userActivity.getUserDataModel()) {
			return userActivity.getUserDataModel().hasGiveReward(getTargetId());
		}
		return false;
	}
	
	/**
	 * 获取显示的需求数量，默认为0，其他模块可重写
	 * @return
	 */
	public int getShowNeedNum() {
		return 0;
	}
	
	/**
	 * 获取第二个显示的需求数量，默认为0，其他模块可重写
	 * @return
	 */
	public int getShowNeedNumSecond() {
		return 0;
	}
	
	/**
	 * 第一个显示数值的分子显示的数值是否有限制，即不超过分母，默认是
	 * @return
	 */
	protected boolean isCurNumNeedShowLimit() {
		return true;
	}
	
	/**
	 * 第二个显示数值的分子显示的数值是否有限制，即不超过分母，默认是
	 * @return
	 */
	protected boolean isCurNumSecondShowLimit() {
		return true;
	}
	
	/**
	 * 获取目标的已达成数，即进度条的分子
	 * @param userActivity
	 * @return
	 */
	public int getCurNum(AbstractUserGoodActivity userActivity) {
		int curNum = 0;
		if (null != userActivity && null != userActivity.getUserDataModel()) {
			curNum = userActivity.getUserDataModel().getCurNum(getTargetId());
			int showNeedNum = getShowNeedNum();
			if (curNum > showNeedNum && isCurNumNeedShowLimit()) {
				// 分子不超过分母
				curNum = showNeedNum;
			}
		}
		return curNum;
	}
	
	/**
	 * 获取第二个目标的已达成数，即进度条的分子
	 * @param userActivity
	 * @return
	 */
	public int getCurNumSecond(AbstractUserGoodActivity userActivity) {
		int curNum = 0;
		if (null != userActivity && null != userActivity.getUserDataModel()) {
			curNum = userActivity.getUserDataModel().getCurNumSecond(getTargetId());
			int showNeedNum = getShowNeedNumSecond();
			if (curNum > showNeedNum && isCurNumSecondShowLimit()) {
				// 分子不超过分母
				curNum = showNeedNum;
			}
		}
		return curNum;
	}
	
	/**
	 * 领取奖励时是否需要消耗
	 * @return
	 */
	public boolean isNeedCost() {
		return false;
	}
	
	/**
	 * 需要的消耗是否足够
	 * @param human
	 * @param targetId
	 * @return
	 */
	public boolean isCostEnough(Human human, boolean notice) {
		if (isNeedCost()) {
			return false;
		}
		return true;
	}
	
	/**
	 * 领取奖励时扣除需要的消耗
	 * @param human
	 * @param targetId
	 * @return
	 */
	public boolean costOnGiveBonus(Human human) {
		return isCostEnough(human, false);
	}
	
	/**
	 * 目标条件检查，通用的目标包括前置目标限制，时间限制，vip限制，其他限制写到condCheckImpl中
	 * @param userActivity
	 * @param notice
	 * @return
	 */
	public final boolean condCheck(AbstractUserGoodActivity userActivity, boolean notice, Human human) {
		//前置目标是否已完成，没有完成则不能领取奖励
		if (!isPreTargetFinished(userActivity)) {
			return false;
		}
		
		//单个目标的时间限制
		if (!isTimeLimitOK()) {
			return false;
		}
		//vip限制
		if (!isVipLimitOK(userActivity, notice, human)) {
			return false;
		}
		
		return condCheckImpl(userActivity, notice, human);
	}
	
	/**
	 * 其他条件限制是否满足，有需要的功能自行实现
	 * @return
	 */
	protected boolean condCheckImpl(AbstractUserGoodActivity userActivity, boolean notice, Human human) {
		return true;
	}
	
	/**
	 * 获取前置目标Id，默认为0
	 * @return
	 */
	public int getPreTargetId() {
		return 0;
	}
	
	/**
	 * 是否有前置目标
	 * @return
	 */
	public final boolean hasPreTarget() {
		return getPreTargetId() > 0;
	}
	
	/**
	 * 前置目标是否已完成
	 * @param userActivity
	 * @return
	 */
	public boolean isPreTargetFinished(AbstractUserGoodActivity userActivity) {
		if (hasPreTarget()) {
			AbstractGoodActivityUserDataModel userDataModel = userActivity.getUserDataModel();
			//前置目标是否已经领取过奖励，是则认为已完成
			if (userDataModel != null && 
					userDataModel.hasGiveReward(getPreTargetId())) {
				return true;
			}
			return false;
		}
		return true;
	}
	
	/**
	 * 获取目标的vip限制
	 * @return
	 */
	public VipFuncTypeEnum getVipLimit() {
		return null;
	}
	
	/**
	 * 目标是否满足vip限制
	 * @param roleId
	 * @param notice
	 * @return
	 */
	public final boolean isVipLimitOK(AbstractUserGoodActivity userActivity, boolean notice, Human human) {
		VipFuncTypeEnum vipLimit = getVipLimit();
		if (vipLimit == null) {
			return true;
		}
		long roleId = userActivity.getCharId();
		if (!Globals.getVipService().checkVipRule(roleId, vipLimit)) {
			if (notice && human != null) {
				human.sendErrorMessage(LangConstants.VIP_NOT_ENOUGH);
			}
			return false;
		}
		return true;
	}
	
	/**
	 * 获取目标的时间限制
	 * @return
	 */
	public long getTimeLimit() {
		return 0;
	}
	
	/**
	 * 当前是否满足目标的时间限制
	 * @return
	 */
	public boolean isTimeLimitOK() {
		if (getTimeLimit() == 0) {
			return true;
		}
		return false;
	}
	
	/**
	 * 给目标的特殊奖励
	 * @param human
	 * @param giveBonusNum
	 * @return
	 */
	public boolean giveSpecialReward(Human human, int giveBonusNum) {
		return true;
	}
	
	@Override
	public String toJson(AbstractUserGoodActivity userActivity) {
		JSONObject json = new JSONObject();
		json.put(TARGET_ID_KEY, getTargetId());
		json.put(REWARD_INFO_KEY, getRewardInfo().getRewardStr());
		json.put(COND_DESC_KEY, getCondDesc());
		json.put(COND_SECOND_DESC_KEY, getCondSecondDesc());
		json.put(PANEL_LINK_TYPE_KEY, getPanelType());
		json.put(PANEL_LINK_KEY, getPanelLink());
		json.put(PANEL_LINK_NAME_KEY, getPanelLinkName());
		json.put(CAN_GIVE_KEY, canGiveReward(userActivity) ? 1 : 0);
		json.put(HAS_GIVE_KEY, hasGiveReward(userActivity) ? 1 : 0);
		json.put(SHOW_BTN_KEY, getShowBtn());
		json.put(CURR_NUM_KEY, getCurNum(userActivity));
		json.put(CURR_NUM_SECOND_KEY, getCurNumSecond(userActivity));
		json.put(NEED_NUM_KEY, getShowNeedNum());
		json.put(NEED_NUM_SECOND_KEY, getShowNeedNumSecond());
		json.put(TARGET_GROUP_KEY, getShowGroupId());
		return json.toString();
	}

}
