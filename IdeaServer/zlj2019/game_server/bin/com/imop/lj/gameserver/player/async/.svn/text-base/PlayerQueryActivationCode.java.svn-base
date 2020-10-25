package com.imop.lj.gameserver.player.async;

import org.slf4j.Logger;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.ActiveUseCodeResponse;


/**
 * 查询平台奖励列表
 *
 *
 */
public class PlayerQueryActivationCode implements LocalBindUUIDIoOperation {

	private final static Logger logger = Loggers.prizeLogger;

	private Player player;
	/** 调用平台查询返回的结果 */
	private volatile ActiveUseCodeResponse response;


	private String activationCode;

	public PlayerQueryActivationCode(Player player,String activationCode) {
		this.player = player;
		this.activationCode = activationCode;
	}

	@Override
	public int doIo() {
		// 调用接口
		try {
			Loggers.gameLogger.debug(activationCode);
			response = Globals.getSynLocalService().activeUseCode(
					player.getPassportId(),activationCode,
					player.getClientIp());
		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "",
					"玩家在查询平台奖励时出错"), ex);
			player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_VALADATE_FAIL);
		}
		Loggers.gameLogger.debug("激活码是否成功："+response.isSuccess());
		if (!response.isSuccess()) {
			// 根据错误码进行信息提示
			Loggers.gameLogger.debug(response.getErrorCode() + "");
			switch (response.getErrorCode()) {
			case 1:
			case 2:
			case 3:
			case 999:
				player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_VALADATE_FAIL);
				break;
			case 12:
				player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_NOT_EXIST);
				break;
			default:
				// 此处可能是平台添加的奖励出了问题
				player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_VALADATE_FAIL);
				break;
			}
		}

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		// 查询成功
		if (response.isSuccess()) {
			player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_OP_SUCCESS);
			Globals.getPrizeService().sendPrizeListMsg(player);

		}

		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.player.getRoleUUID();
	}

}