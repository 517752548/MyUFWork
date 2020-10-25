package com.imop.lj.gameserver.wallow.async;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.wallow.msg.GCWallowAddInfoResult;
import com.imop.platform.local.response.AddWallowInfoResponse;

/**
 * 玩家填写防沉迷信息
 *
 *
 *
 */
public class PlayerAddWallowInfo implements LocalBindUUIDIoOperation {

	private long roleUUID;
	private String trueName;
	private String idCard;
	/** 错误号 */
	private volatile int errCode = -1;
	private boolean isSucc = false;

	public PlayerAddWallowInfo(long roleUUID, String trueName, String idCard) {
		this.roleUUID = roleUUID;
		this.trueName = trueName;
		this.idCard = idCard;
	}

	@Override
	public int doIo() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			// 直接结束
			return STAGE_STOP_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			// 直接结束
			return STAGE_STOP_DONE;
		}

		AddWallowInfoResponse response = Globals.getSynLocalService()
				.addWallowInfo(player.getPassportId(), trueName, idCard,
						player.getClientIp());
		if (response.isSuccess()) {
			String _userId = response.getUserId() + "";
			if (_userId.equalsIgnoreCase(player.getPassportId())) {
			} else {
				// 这什么情况
				return STAGE_STOP_DONE;
			}
			isSucc = true;
		} else {
			errCode = response.getErrorCode();
		}

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			// 人已经不在无法继续，记录日志
			if (errCode == -1) {// 平台返回成功
				Loggers.wallowLogger.error(LogUtils.buildLogInfoStr(roleUUID + "",
						"调用用户防沉迷信息注册接口成功，但是给用户提示时失败"));
			}
			return IIoOperation.STAGE_STOP_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			// 人已经不在无法继续，记录日志
			if (errCode == -1) {// 平台返回成功
				Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "",
						"调用用户防沉迷信息注册接口成功，但是给用户提示时失败"));
			}
			return IIoOperation.STAGE_STOP_DONE;
		}
		if (isSucc) {
			// 客户端收到空提示时关闭面板
			player.sendMessage(new GCWallowAddInfoResult(""));
			player.sendSystemMessage(LangConstants.WALLOW_CERTIFIED_SUCC);

			player.setWallowFlag(WallowConstants.WALLOW_FLAG_OFF);

		} else {
			// 认证结果返回客户端
			String result = getErrorInfo(errCode);
			player.sendMessage(new GCWallowAddInfoResult(result));

		}
		return IIoOperation.STAGE_STOP_DONE;
	}


	private String getErrorInfo(int errorCode) {
		Integer _langKey = null;
		switch (errorCode) {
		case 1:
			_langKey = LangConstants.LOCAL_CHARGE_SIGN_AUTH_FAIL;
			break;
		case 2:
			_langKey = LangConstants.LOCAL_CHARGE_TIMESTAMP_EXPIRSE;
			break;
		case 3:
			_langKey = LangConstants.LOCAL_CHARGE_PARAM_FORMAT_ERROR;
			break;
		case 4:
			_langKey = LangConstants.LOCAL_WALLOW_TRUE_NAME_ERROR;
			break;
		case 5:
			_langKey = LangConstants.LOCAL_WALLOW_IDCARD_ERROR;
			break;
		default:
			_langKey = LangConstants.LOCAL_WALLOW_INFO_ERROR;
			break;
		}
		return Globals.getLangService().readSysLang(_langKey);
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}

}
