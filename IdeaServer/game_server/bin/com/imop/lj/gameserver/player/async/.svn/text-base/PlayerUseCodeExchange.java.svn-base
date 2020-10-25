package com.imop.lj.gameserver.player.async;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.platform.local.response.ActiveUseCodeResponse;


/**
 * 兑换码兑换平台奖励
 *
 */
public class PlayerUseCodeExchange implements LocalBindUUIDIoOperation {
	private final static Logger logger = Loggers.localLogger;

	/** 调用平台查询返回的结果 */
	private volatile ActiveUseCodeResponse response;

	private long roleId;
	private String ip;
	private String activationCode;
	

	public PlayerUseCodeExchange(long roleId, String ip, String activationCode) {
		this.roleId = roleId;
		this.ip = ip;
		this.activationCode = activationCode;
	}

	@Override
	public int doIo() {
		// 调用接口
		try {
			//请求兑奖
			response = Globals.getSynLocalService().activeUseCode(roleId+"", activationCode, ip);
			
			//记录日志
			logger.info("PlayerUseCodeExchange roleId=" + roleId + ";ip=" + ip  
					+ ";res=" + response.isSuccess() + ";resUserId=" + response.getUserId() + ";resErrCode=" + response.getErrorCode());
		
			Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
			
			//查询成功
			if (response.isSuccess()) {
				int itemTplId = (int)response.getUserId();
				ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
				if (itemTpl != null) {
					//构建奖励
					List<RewardParam> paramList = new ArrayList<RewardParam>();
					RewardParam rp = new RewardParam(RewardType.REWARD_ITEM, itemTplId, 1);
					paramList.add(rp);
					Reward reward = Globals.getRewardService().createRewardByFixedContent(roleId, RewardReasonType.LOCAL_CODE_REWARD, paramList, "PlayerUseCodeExchange");
					if (reward == null || reward.isNull()) {
						logger.error("PlayerUseCodeExchange reward is null!roleId=" + roleId + ";itemTplId=" + itemTplId
								+ ";res=" + response.isSuccess() + ";resUserId=" + response.getUserId() + ";resErrCode=" + response.getErrorCode());
					}
					//给玩家发邮件
					Globals.getMailService().sendSysMail(roleId, MailType.SYSTEM, 
							Globals.getLangService().readSysLang(LangConstants.PRIZE_USE_CODE_MAIL_TITLE), 
							Globals.getLangService().readSysLang(LangConstants.PRIZE_USE_CODE_MAIL_CONTENT),
							reward);
					if (player != null) {
						player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_OP_SUCCESS);
					}
				} else {
					logger.error("PlayerUseCodeExchange itemTplId not exsit!roleId=" + roleId 
							+ ";res=" + response.isSuccess() + ";resUserId=" + response.getUserId() + ";resErrCode=" + response.getErrorCode());
					if (player != null) {
						player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_OP_FAILED1);
					}
				}
			} else {
				//兑换失败
				if (player != null) {
					player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_OP_FAILED);
				}
			}
		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(roleId + "",
					"玩家在查询平台奖励时出错"), ex);
		}
		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleId;
	}

}