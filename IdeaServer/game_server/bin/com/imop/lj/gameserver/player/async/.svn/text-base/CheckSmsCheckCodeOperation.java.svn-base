package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.msg.GCCheckSmsCheckcode;
import com.imop.platform.local.response.CaptchaCheckResponse;

/**
 * 向local发送 验证手机号
 *
 */
public class CheckSmsCheckCodeOperation implements LocalIoOperation {

	/** 用户 */
	private Player player;
	
	private String qqNum = "";
	private String phoneNum = "";
	private String checkCode = "";
	
	private CaptchaCheckResponse response;

	public CheckSmsCheckCodeOperation(Player player, String qqNum, String phoneNum, String checkCode) {
		this.player = player;
		this.qqNum = qqNum;
		this.phoneNum = phoneNum;
		this.checkCode = checkCode;
	}

	@Override
	public int doIo() {
		try {
			response = Globals.getSynLocalService().checkSmsCheckCode(player.getPassportId(), player.getCookieValue(), phoneNum, checkCode, player.getClientIp());
		} catch (Exception e) {
			Loggers.humanLogger.error("#CheckSmsCheckCodeOperation#doIo#Error!e=" + e.getMessage());
			e.printStackTrace();
		}
		
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if (player == null || player.getHuman() == null) {
			// 记录错误日志
			Loggers.humanLogger.error("#CheckSmsCheckCodeOperation#doStop#player is null or human is null!playerId=" + 
					(player != null ? player.getPassportId() : "0"));
			return IIoOperation.STAGE_STOP_DONE;
		}
		
		boolean isSuccess = false;
		if (response != null && response.isSuccess()) {
			// 成功
			isSuccess = true;
			// 保存玩家数据
			player.getHuman().getSmsCheckCodeManager().onCheckCodeSuccess(phoneNum, qqNum);
			// 记录日志
			Loggers.humanLogger.info("#CheckSmsCheckCodeOperation#doStop#success!playerId=" + player.getPassportId());
		} else {
			// 失败
			if (response == null) {
				// 给玩家错误提示
				player.sendErrorMessage(LangConstants.SMS_CHECKCODE_CHECK_FAIL);
				// 记录错误日志
				Loggers.humanLogger.error("#CheckSmsCheckCodeOperation#doStop#response is null!playerId=" + player.getPassportId());
			} else {
				switch (response.getErrorCode()) {
				// 请求的频率过高导致
				case 20001:
					player.sendErrorMessage(LangConstants.SMS_CHECKCODE_CHECKCODE_REQUEST_SENDED);
					break;
				// 输入的验证码错误，或验证码已过期
				case 20002:
					player.sendErrorMessage(LangConstants.SMS_CHECKCODE_CHECKCODE_WRONG);
					break;
				// 短时间内大量请求导致ip被封
				case 20003:
					player.sendErrorMessage(LangConstants.SMS_CHECKCODE_TOO_MUCH);
					break;
				default:
					player.sendErrorMessage(LangConstants.SMS_CHECKCODE_CHECK_FAIL);
					break;
				}
				// 记录错误日志
				Loggers.humanLogger.error("#CheckSmsCheckCodeOperation#doStop#response return error!playerId=" + 
						player.getPassportId() + ";errorCode=" + response.getErrorCode() + ";errorMsg=" + response.getErrorMsg());
			}
		}
		// 通知前台是否成功
		player.sendMessage(new GCCheckSmsCheckcode(isSuccess ? ResultTypes.SUCCESS.val : ResultTypes.FAIL.val, qqNum, phoneNum));
		
		return IIoOperation.STAGE_STOP_DONE;
	}

}
