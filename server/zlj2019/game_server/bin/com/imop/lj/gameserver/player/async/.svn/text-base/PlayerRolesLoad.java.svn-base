package com.imop.lj.gameserver.player.async;

import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.GCNotifyException;

/**
 * 加载玩家的角色列表
 *
 */
public class PlayerRolesLoad implements IIoOperation {

	private static final Logger logger = Loggers.asyncDbLogger;
	private final Player player;
	private final String passportId;
	private boolean isOperateSucc = false;

	/** 是否加载完毕后使用指定charId直接进入游戏 */
	private boolean isForwardEnter;
	/** 需要直接进入游戏的charId */
	private long charId;

	/**
	 *
	 * @param player
	 *            玩家对象
	 * @param passportId
	 *            玩家的passportId
	 */
	public PlayerRolesLoad(Player player, boolean isForwardEnter,
			long charId) {
		this.player = player;
		this.passportId = player.getPassportId();
		this.isForwardEnter = isForwardEnter;
		this.charId = charId;
	}

	@Override
	public int doIo() {
		do {
			try {
				// 只有在玩家处理于连接状态的时候才加载他的角色列表
				if (!player.isOnline()) {
					break;
				}
				List<RoleInfo> roles = Globals.getOnlinePlayerService().loadPlayerRoleList(passportId);
				player.setRoles(roles);
				isOperateSucc = true;
			} catch (Exception e) {
				isOperateSucc = false;
				if (logger.isErrorEnabled()) {
					Loggers.playerLogger.error(LogUtils.buildLogInfoStr(
							passportId, "load character error"), e);
				}
			}
		} while (false);

		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if (isOperateSucc) {
			Globals.getLoginLogicalProcessor().onCharsLoad(this.player,	this.isForwardEnter, this.charId);
		} else {
			player.sendMessage(new GCNotifyException(DisconnectReason.FINISH_LOAD_HUMAN_EXCEPTION.code, Globals.getLangService().readSysLang(LangConstants.LOAD_PLAYER_ROLES)));
			player.exitReason = PlayerExitReason.SERVER_ERROR;
			player.disconnect();
		}
		return STAGE_STOP_DONE;
	}

}
