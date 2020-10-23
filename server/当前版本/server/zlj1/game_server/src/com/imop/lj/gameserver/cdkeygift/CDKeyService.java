package com.imop.lj.gameserver.cdkeygift;

import java.util.ArrayList;
import java.util.List;

import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.across.cdkeyworld.msg.GWCdkeyCheckMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;

/**
 * gameservice cdkey领取礼包
 * 
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月5日 下午4:38:06
 * @version 1.0
 */

public class CDKeyService implements InitializeRequired {
	
	@Override
	public void init() {
		
	}
	/**
	 * 向worldservice 发送验证请求消息
	 * 
	 * @param human
	 * @param cdKeyStr
	 */
	public void takeCDKeyGiftRequestWS(Human human, String cdKeyStr) {
		GWCdkeyCheckMsg msg = new GWCdkeyCheckMsg();
		msg.setCharUUId(human.getUUID());
		msg.setOpenId(human.getPassportId());
		msg.setCdKeyStr(cdKeyStr);
		msg.setOnServerId(Globals.getServerConfig().getServerId());
		
		Globals.getWorldServerSession().sendMessage(msg);
	}
	/**
	 * worldserver 返回的cdkey验证
	 * 
	 * @param charUUID
	 * @param canUse
	 * @param failReason
	 * @param rewardStr
	 */
	public void takeCDKeyWorldServerResponse(long charUUID, int canUse, int failReason, String rewardStr) {
		Player player = Globals.getOnlinePlayerService().getPlayer(charUUID);
		if (null == player || player.getHuman() == null) {
			return;
		}
		Loggers.cdKeyLogger.info("#CDKeyService#takeCDKeyWorldServerResponse#start, charUUID=" + charUUID 
				+ ", canUse=" + canUse
				+ ", failReason=" + failReason
				+ ", rewardStr=" + rewardStr
				);
		// 不可用, 返回提示
		if(CDKeyStateEnum.CDKEY_STATE_CAN_NOT_USE.getIndex() == canUse) {
			Loggers.cdKeyLogger.info("#CDKeyService#takeCDKeyWorldServerResponse#check fail!");
			CDKeyStateEnum failReasonEnum = CDKeyStateEnum.valueOf(failReason);
			switch(failReasonEnum) {
			case CDKEY_FAIL_REASON_EFFECTIVE_TIME_OUT:
				player.getHuman().sendErrorMessage(LangConstants.CDKEY_CHECK_FAIL_REASON_EFFECTIVE_TIME_OUT);
				return;
			case CDKEY_FAIL_REASON_NULL:
				player.getHuman().sendErrorMessage(LangConstants.CDKEY_CHECK_FAIL_REASON_NULL);
				return;
			case CDKEY_FAIL_REASON_ALREADY_TAKEN:
				player.getHuman().sendErrorMessage(LangConstants.CDKEY_CHECK_FAIL_REASON_ALREADY_TAKEN);
				return;
			case CDKEY_FAIL_REASON_HAD_TAKEN_SAME_PLANSID_AND_GIFTID:
				player.getHuman().sendErrorMessage(LangConstants.CDKEY_FAIL_REASON_HAD_TAKEN_SAME_PLANSID_AND_GIFTID);
				return;
				
			default:
				break;
			}
		}
		
		Loggers.cdKeyLogger.info("#CDKeyService#takeCDKeyWorldServerResponse#give reward"); 
		
		List<RewardParam> rewardParamList = new ArrayList<RewardParam>();
		parseReward(rewardParamList, rewardStr);
		Reward reward = Globals.getRewardService().createRewardByFixedContent(charUUID, RewardReasonType.CDKEY_REWARD
				, rewardParamList, "#CDKeyService#takeCDKeyWorldServerResponse#rewardStr=" + rewardStr);
		boolean giveRewardFlag = Globals.getRewardService().giveReward(player.getHuman(), reward, true);
		if (!giveRewardFlag) {
			// 记录错误日志
			Loggers.cdKeyLogger.error("#CDKeyService#takeCDKeyWorldServerResponse#giveRewardFlag return false!humanId="
					+ player.getHuman().getUUID() + ", reward=" + reward);
		}
		Loggers.cdKeyLogger.info("#CDKeyService#takeCDKeyWorldServerResponse#give reward finish rewardstr =" + rewardStr);
	}

	
	/**
	 * 拆分奖励str
	 * 结构 ： {"coin":"2=1;3=100;9=1000","item":"10001=1;"}
	 */
	private void parseReward(List<RewardParam> rewardParams, String rewardStr) {
		RewardParam param = null;
		JSONObject jsonObj = JSONObject.fromObject(rewardStr);
		String currencyStr = JsonUtils.getString(jsonObj, "coin");
		String[] dataStrs = null;
		String[] keyAndValue = null;
		if(!StringUtils.isEmpty(currencyStr)) {
			dataStrs =  currencyStr.split(";");
			if(null != dataStrs) {
				for(String str : dataStrs) {
					keyAndValue = str.split("=");
					if(null != keyAndValue && keyAndValue.length == 2){
						param = new RewardParam(RewardType.REWARD_CURRENCY
								, Integer.parseInt(keyAndValue[0])
								, Integer.parseInt(keyAndValue[1])
								);
						rewardParams.add(param);
					}
				}
			}
		}
		String itemStr = JsonUtils.getString(jsonObj, "item");
		if(!StringUtils.isEmpty(itemStr)) {
			dataStrs =  itemStr.split(";");
			if(null != dataStrs) {
				for(String str : dataStrs) {
					keyAndValue = str.split("=");
					if(null != keyAndValue && keyAndValue.length == 2){
						param = new RewardParam(RewardType.REWARD_ITEM
								, Integer.parseInt(keyAndValue[0])
								, Integer.parseInt(keyAndValue[1])
								);
						rewardParams.add(param);
					}
				}
			}
		}
	}

}
