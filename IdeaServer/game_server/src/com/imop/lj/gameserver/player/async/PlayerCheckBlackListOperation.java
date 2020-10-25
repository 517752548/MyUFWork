package com.imop.lj.gameserver.player.async;

import org.slf4j.Logger;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.PMKey;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.PM;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.IsBlackListUserResqponse;

/**
 * 玩家充钻石
 *
 *
 */
public class PlayerCheckBlackListOperation implements LocalBindUUIDIoOperation {
	private static final Logger logger = Loggers.chargeLogger;

	/** player的uuid */
	private long roleUUID;

	private boolean isNotBlack;

	public PlayerCheckBlackListOperation(long roleUUID) {
		this.roleUUID = roleUUID;
		this.isNotBlack = false;
	}

	@Override
	public int doIo() {

		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			// 直接结束
			return STAGE_STOP_DONE;
		}
		Human _human = player.getHuman();
		if (_human == null) {
			// 直接结束
			return STAGE_STOP_DONE;
		}

//		IsBlackListUserResqponse isBlackListUserResqponse = null;
		// 调用接口了
		try {

			logger.info("PlayerCheckBlackListOperation.doIo.isBlackListUser " + "passportId=" + player.getPassportId() + ";uuid=" + player.getHuman().getUUID() + ";ip=" + player.getClientIp() + ";deviceID=" + player.getDeviceID());
			IsBlackListUserResqponse _response = Globals.getSynLocalService().isBlackListUser(_human.getPlayer().getPassportId(), player.getClientIp(), player.getDeviceID());

//			String[] infos = {"ok",""};
//			IsBlackListUserResqponse _response = new IsBlackListUserResqponse(infos);
//			_response.onSuccess(infos);

			if (_response.isSuccess()) {
				logger.info("PlayerCheckBlackListOperation.doIo.isBlackListUser is OK!" + "PlayerCheckBlackListOperation.doIo.isBlackListUser " + "passportId" + player.getPassportId() + ";uuid=" + player.getHuman().getUUID() + ";ip=" + player.getClientIp() + ";deviceID=" + player.getDeviceID());
				isNotBlack = true;
				return IIoOperation.STAGE_IO_DONE;
			}else{
				int errno = _response.getErrorCode();
				if (errno == 1) {
					// 签名错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "sing error!").tos()));
					}
				} else if (errno == 2) {
					// 时间戳错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", PM.kv(PMKey.REASON, "time error!")
								.tos()));
					}
				} else if (errno == 3) {
					// 参数格式错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Parameter error!").tos()));
					}
				} else if (errno == 4) {
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_USER_IN_BLACKLIST);
					// 黑名单玩家
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "user is exist in blackList!").tos()));
					}
				} else {
					// 未知错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", PM
								.kv(PMKey.REASON, "Unknown error!").tos()));
					}
				}
				logger.error("transaction error " + _response.getErrorCode());
				return STAGE_IO_DONE;
			}
		} catch (Exception e) {
			e.printStackTrace();
			return IIoOperation.STAGE_IO_DONE;
		}
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		logger.info("PlayerCheckBlackListOperation.doStop() 1");
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player != null) {
			logger.info("PlayerCheckBlackListOperation.doStop() 2");
			if (isNotBlack) {
				logger.info("PlayerCheckBlackListOperation.doStop() 3");
				Human human = player.getHuman();
				if (human == null) {
					return IIoOperation.STAGE_STOP_DONE;
				}
				logger.info("PlayerCheckBlackListOperation.doStop() 4");
				TerminalTypeEnum terminalTypeEnum = player.getCurrTerminalType();
				switch (terminalTypeEnum) {
				case IPHONE:
				case IPAD:
					logger.info("PlayerCheckBlackListOperation.doStop() 5");
//					GCChargeKinds gcChargeKinds = new GCChargeKinds();
//					gcChargeKinds.setChargeKinds(Globals.getIpadChargeService().getDefaultIPadCharges(player.getAppid()));
//					human.sendMessage(gcChargeKinds);
//
//					GCChargeKindsDetail gcChargeKindsDetail = new GCChargeKindsDetail();
//					List<IpadChargeTemplate> templateList = Globals.getIpadChargeService().getIpadChargeTemplateByAppid(player.getAppid());
//					List<IosChargeInfo> IosChargeInfoList = new ArrayList<IosChargeInfo>();
//					for(IpadChargeTemplate tmp : templateList){
//						IosChargeInfo iosChargeInfo = new IosChargeInfo();
//						iosChargeInfo.setCostRMB(tmp.getCostRMB());
//						iosChargeInfo.setDesc(tmp.getDesc());
//						iosChargeInfo.setIcon(tmp.getIcon());
//						iosChargeInfo.setName(tmp.getName());
//						iosChargeInfo.setProductId(tmp.getProductId());
//						IosChargeInfoList.add(iosChargeInfo);
//					}
//					gcChargeKindsDetail.setIosChargeInfoDataList(IosChargeInfoList.toArray(new IosChargeInfo[0]));
//					human.sendMessage(gcChargeKindsDetail);
					break;
				default:
					break;
				}
			}else{
				logger.info("PlayerCheckBlackListOperation.doStop() 6");
				Human human = player.getHuman();
				if (human == null) {
					return IIoOperation.STAGE_STOP_DONE;
				}

				TerminalTypeEnum terminalTypeEnum = player.getCurrTerminalType();
				switch (terminalTypeEnum) {
				case IPHONE:
				case IPAD:
//					GCChargeKindsDetail gcChargeKindsDetail = new GCChargeKindsDetail();
//					List<IosChargeInfo> IosChargeInfoList = new ArrayList<IosChargeInfo>();
//					gcChargeKindsDetail.setIosChargeInfoDataList(IosChargeInfoList.toArray(new IosChargeInfo[0]));
//					human.sendMessage(gcChargeKindsDetail);
					logger.info("PlayerCheckBlackListOperation.doStop() 7");
					break;
				default:
					break;
				}
			}
		}
		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return roleUUID;
	}

}