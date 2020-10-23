package com.imop.lj.gameserver.player.charge.async;

import org.slf4j.Logger;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.PMKey;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.PM;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.TransferResponse;

/**
 * 玩家充钻石
 *
 *
 */
public class PlayerChargeDiamond implements LocalBindUUIDIoOperation {
	private static final Logger logger = Loggers.chargeLogger;
	/** player的uuid */
	private long roleUUID;
	/** 兑换的平台币数量 */
	private int mmCost;
//	/** 兑换后平台币余数 */
//	private int mmLeft;
	/** 错误号 */
	private int errno = -1;

	private boolean isSuccess = false;

	private ChargeOrderInfo orderInfo;

	private IChargeCallBack callBack;

	public PlayerChargeDiamond(long roleUUID, int mmCost,IChargeCallBack callBack) {
		this.roleUUID = roleUUID;
		this.mmCost = mmCost;
		this.orderInfo = new ChargeOrderInfo();
		this.callBack = callBack;
	}

	@Override
	public int doIo() {
		try {
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

			TransferResponse _transferResponse = null;
			// 调用接口了

			// XXX 快客登陆对充值的影响
			_transferResponse = Globals.getSynLocalService().transfer(_human.getPlayer().getPassportId(), _human.getUUID(), mmCost,
					_human.getLastLoginIp());

			if (_transferResponse == null) {
				if (logger.isErrorEnabled()) {
					logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", ""));
				}
				return IIoOperation.STAGE_IO_DONE;
			}

			String passportId = player.getPassportId();
			if (_transferResponse.isSuccess()) {
				orderInfo.setUser_id(_transferResponse.getUserId());
				orderInfo.setBalance(_transferResponse.getBalance());
				orderInfo.setOrderId(_transferResponse.getOrderID());
				orderInfo.setAmount(_transferResponse.getMoney());
				orderInfo.setCurrency(_transferResponse.getCurrency());
				orderInfo.setChargeType(_transferResponse.getChargetype());
				orderInfo.setPay_channel(_transferResponse.getPay_channel());
				orderInfo.setSub_channel(_transferResponse.getSub_channel());
				int mmCost = (int)Math.round( _transferResponse.getMoney());
				if(mmCost <= 0){
					mmCost = 0;
				}
				orderInfo.setGamepoints(String.valueOf(mmCost));

				if ((_transferResponse.getUserId() + "").equalsIgnoreCase(passportId)) {
					// 加钻石放入doStop主线程中处理
					errno = 0;
					isSuccess = true;
				} else {
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", "userId is error"));
					}
				}
				return IIoOperation.STAGE_IO_DONE;
			}else{
				errno = _transferResponse.getErrorCode();
				if (errno == 1) {
					// 签名错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Timestamp error!").tos()));
					}
				} else if (errno == 2) {
					// 时间戳错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Sign error!").tos()));
					}
				} else if (errno == 3) {
					// 参数格式错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Parameter error!").tos()));
					}
				} else if (errno == 4) {
					// 余额不足
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "left mmo not enough error!").tos()));
					}
				} else {
					// 未知错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Unknown error!").tos()));
					}
				}
			}
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", ""), e);
			}
			return IIoOperation.STAGE_IO_DONE;
		}
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值
			if (errno == 0) {// 平台返回成功，但是给不了钱了
				Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用充值接口成功，但是给用户金钱时失败"));
			}
			return IIoOperation.STAGE_STOP_DONE;
		}

		Human _human = player.getHuman();
		if (_human == null) {
			// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值
			if (errno == 0) {// 平台返回成功，但是给不了钱了
				Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用充值接口成功，但是给用户金钱时失败"));
			}
			return IIoOperation.STAGE_STOP_DONE;
		}

//		int _bondBefore = _human.getBond();
//		int _bondAfter = _human.getBond();
//		int _allDiamondBefore = _human.getAllBond();
//		// int _chargeDiamondBefore = _human.getTotalCharge();
//		if (errno == 0) {
//			// 加钻石
//			int _diamondConvMod = diamondConv;
//			int _allDiamondWill = _allDiamondBefore + diamondConv;
//			if (_allDiamondWill <= 0 || _allDiamondWill > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
//				// 钻石溢出，给玩家钻石加到最大值
//				_reason = LogReasons.ChargeLogReason.CHARGE_DIAMOND_OVERFLOW;
//				_diamondConvMod = SharedConstants.MAX_DIAMOND_CARRY_AMOUNT - _allDiamondBefore;
//			}
//
//			CurrencyProcessor.instance.giveMoney(_human, _diamondConvMod, Currency.BOND, false, MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND,
//					MessageFormat.format(MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND.getReasonText(), mmCost));
//
//			_human.snapChangedProperty(true);
//			// 发送成功消息
//			GCPlayerChargeDiamond _msg = new GCPlayerChargeDiamond(mmLeft);
//			player.sendMessage(_msg);
//			player.sendImportantMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + _diamondConvMod);
//			if (_reason == LogReasons.ChargeLogReason.CHARGE_DIAMOND_OVERFLOW) {
//				// 如果钻石溢出，给玩家发送提醒
//				player.sendErrorMessage(LangConstants.GAME_AFTER_CHARGE_DIAMOND_OVER_FLOW);
//			}
//
//			// 处理任务兑换钻石
//			PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(_human, _diamondConvMod);
//			Globals.getEventService().fireEvent(_event);
//			// 玩家vip等级改变推消息。
//			_human.onVipLevelChanged();
//			_bondAfter = _human.getBond();
//			Globals.getLocalScribeService().sendScribeGameIncomeReport(_human, MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND, LocalScribeDef.ChargeType.POINT,
//					mmCost, _diamondConvMod, _bondAfter);
//		} else if (errno == 4) {
//			// 发送失败消息，余额不足
//			_reason = LogReasons.ChargeLogReason.CHARGE_DIAMOND_FAIL;
//			player.sendErrorMessage(LangConstants.GAME_CHARGE_DIAMOND_FAIL);
//		} else {
//			// 调用接口异常
//			_reason = LogReasons.ChargeLogReason.CHARGE_DIAMOND_INVOKE_FAIL;
//			player.sendErrorMessage(LangConstants.GAME_CHARGE_DIAMOND_INVOKE_FAIL);
//		}
//
//		// 发送充值日志
//		Globals.getLogService().sendChargeLog(_human, _reason, "errno=" + errno, Currency.BOND.getIndex(), _bondBefore, _bondAfter, mmCost, "", "");


		if (!isSuccess) {
			if (errno == 4) {
				// 发送失败消息，余额不足
				_human.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_FAIL);
			} else {
				// 调用接口异常
				_human.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_INVOKE_FAIL);
			}
		}else{
			callBack.afterCheckComplete(this.roleUUID,this.orderInfo,this.isSuccess);
		}

		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return roleUUID;
	}
}