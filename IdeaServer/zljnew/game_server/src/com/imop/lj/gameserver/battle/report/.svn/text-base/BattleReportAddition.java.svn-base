package com.imop.lj.gameserver.battle.report;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.Reward;

/**
 * 战报附加内容
 * 主要是奖励信息、文字描述信息等，在战斗之外设置，并在战报中发给前台显示用 
 * @author yu.zhao
 *
 */
public class BattleReportAddition {
//	/** 奖励显示对象 */
//	private RewardInfo rewardInfo;
	private List<Reward> rewardList;
	/** 文字描述信息 */
	private StringBuilder stringBuilder;
	/** 捕捉到的宠物信息 */
	private ReportCatchPetInfo catchPetInfo;
	
	public BattleReportAddition() {
//		rewardInfo = new RewardInfo();
		rewardList = new ArrayList<Reward>();
		stringBuilder = new StringBuilder();
		catchPetInfo = new ReportCatchPetInfo();
	}
	
	/**
	 * 获取附加内容的json字符串
	 * @return
	 */
	public String getReportAdditionJsonStr() {
		JSONObject js = new JSONObject();
		// 奖励信息
		js.put(BattleReportDefine.BATTLE_REPORT_ADDITION_REWARD, getFinalRewardInfo().getRewardStr());
		// 结果描述
		js.put(BattleReportDefine.BATTLE_REPORT_ADDITION_RESULT_DESC, stringBuilder.toString());
		// 捕捉的宠物信息
		js.put(BattleReportDefine.BATTLE_REPORT_ADDITION_CATCH_PET, catchPetInfoToJson());
		return js.toString();
	}

//	public RewardInfo getReward() {
//		return rewardInfo;
//	}

//	/**
//	 * 设置奖励
//	 * @param reward
//	 */
//	public void setReward(RewardInfo reward) {
//		if (null != reward) {
//			this.rewardInfo = reward;
//		}
//	}
	
	public void addReward(Reward reward) {
		rewardList.add(reward);
	}
	
	private RewardInfo getFinalRewardInfo() {
		if (!rewardList.isEmpty()) {
			Reward r = Globals.getRewardService().mergeReward(rewardList);
			return r.toRewardInfo();
		}
		return new RewardInfo();
	}
	
	public ReportCatchPetInfo getReportCatchPetInfo() {
		return this.catchPetInfo;
	}
	
	private JSONObject catchPetInfoToJson() {
		JSONObject js = new JSONObject();
		if (catchPetInfo != null) {
			js.put(BattleReportDefine.BATTLE_REPORT_ADDITION_CATCH_PET_ID, catchPetInfo.getPetTplId());
			js.put(BattleReportDefine.BATTLE_REPORT_ADDITION_CATCH_PET_GENE, catchPetInfo.getGeneTypeId());
		}
		return js;
	}
	
	/**
	 * 追加文字描述信息
	 * @param battleType
	 * @param win
	 * @param enemyName
	 */
	public void appendResultInfo(BattleType battleType, boolean win, String enemyName, String params) {
		// 根据类型获得不同的文字描述
		switch(battleType) {
//		case LANDLORD:
//			stringBuilder.append(params);
//			break;
//		case BOSSWAR:
//			stringBuilder.append(params);
//			break;
//		case ESCORT:
//			stringBuilder.append(params);
//			break;
		default:
			if(win) {
				stringBuilder.append(Globals.getLangService().readSysLang(LangConstants.BATTLE_RESULT_DESC_BATTLE_WIN, enemyName));
			} else {
				stringBuilder.append(Globals.getLangService().readSysLang(LangConstants.BATTLE_RESULT_DESC_BATTLE_LOSS, enemyName));
			}
			break;
		}
	}
}
