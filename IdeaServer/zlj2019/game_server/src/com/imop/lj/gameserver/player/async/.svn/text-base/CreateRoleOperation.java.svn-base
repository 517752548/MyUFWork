package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.model.RoleInfo;

/**
 * 异步IO操作： 保存一个新角色
 * XXX 改为使用BindUUIDIoOperation，uuid为0，这样所有的创建角色就都在一个线程中执行，从而保证一个玩家一个服务器Id不能同时创建两个角色
 *
 * @author Fancy
 * @version 2009-7-31 下午07:04:40
 */
public class CreateRoleOperation implements BindUUIDIoOperation {

	/** 玩家 */
	private Player player;

	/** 角色 */
	private RoleInfo roleInfo;

	/** 是否创建成功 */
	private boolean isCreateSucc = false;

	/**
	 * @param player
	 */
	public CreateRoleOperation(Player player, RoleInfo roleInfo) {
		this.player = player;
		this.roleInfo = roleInfo;
	}

	@Override
	public int doIo() {
		do {
			if (!player.isOnline()) {
				break;
			}
			// 保存到数据库
			isCreateSucc = Globals.getOnlinePlayerService().createRole(player, roleInfo);
		} while (false);
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if (player.getState() == PlayerState.creatingrole) {
			if (isCreateSucc) {
				// 创建完角色后，如果是第一次创建，characters为空，所以重新加载角色列表，然后直接进入游戏
				Globals.getLoginLogicalProcessor().loadCharacters(player, true,
						roleInfo.getRoleUUID());
				
//				// qq平台的一些特殊处理
//				if (Globals.isQQPlatform()) {
//					// 发kaiying的新手日志
//					Globals.getQQKaiYingLogService().sendGuideLog(player, KaiyingLogGuideCat.LOAD, KaiyingLogGuideLoadStep.FINISH_CREATE_ROLE.getIndex());
//					// 发微博
//					String content = Globals.getLangService().readSysLang(LangConstants.QQ_CREATEROLE_WEIBO_CONTENT);
//					Globals.getQQService().addTOperation(player, content);
//				}
				
				//热云汇报
				Globals.getReyunService().reportRegister(player, roleInfo.getSelection().getPetTemplateId());
				//汇报dataEye
				Globals.getDataEyeService().levelUpLog(player, RoleConstants.HUMAN_INIT_LEVEL_NUM, 0);
			} else {
				player.setState(PlayerState.waitingselectrole);
			}
		}
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return 0;
	}
}
