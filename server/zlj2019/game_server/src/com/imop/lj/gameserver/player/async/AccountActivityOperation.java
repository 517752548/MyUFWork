package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.ActiveUseCodeResponse;

/**
 * 帐号激活
 * 
 * @author xiaowei.liu
 * 
 */
public class AccountActivityOperation implements LocalBindUUIDIoOperation {
	private Player player;
	private String activityCode;
	/** 调用平台查询返回的结果 */
	private volatile ActiveUseCodeResponse response;
	
	public AccountActivityOperation(Player player, String activityCode){
		this.player = player;
		this.activityCode = activityCode;
	}
	
	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		// 调用接口
		try {
			if(Loggers.gameLogger.isDebugEnabled()){
				Loggers.gameLogger.debug(activityCode);
			}
			
			response = Globals.getSynLocalService().activeUseCode(player.getPassportId(), activityCode,	player.getClientIp());
		} catch (Exception ex) {
			Loggers.gameLogger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "玩家在激活帐号时出错"), ex);
			player.sendErrorMessage(LangConstants.PRIZE_ACTICATION_USE_CODE_VALADATE_FAIL);
		}
		
		if(Loggers.gameLogger.isDebugEnabled()){
			Loggers.gameLogger.debug("激活码是否成功：" + response.isSuccess());
		}
		
		if (!response.isSuccess()) {
			// 根据错误码进行信息提示
			if(Loggers.gameLogger.isDebugEnabled()){
				Loggers.gameLogger.debug(response.getErrorCode() + "");
			}
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
		}else{
			if(!player.isActivity()){
				player.setActivity(true);
				// 保存数据库
				Globals.getDaoService().getHumanDao().updateActivity(player.getPassportId(), 1);
			}else{
				if(Loggers.gameLogger.isWarnEnabled()){
					Loggers.gameLogger.warn("AccountActivityOperation.doIo dup activity");
				}
			}
		}

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
//		if(player.isActivity()){
//			// 发送消息
//			CreatePetInfo[] createPetInfos = Globals.getTemplateCacheService().getPetTemplateCache().getCreatePetInfos();
//			// 生成消息
//			GCRoleTemplate gcRoleTemplate = new GCRoleTemplate();
//			gcRoleTemplate.setCreatePetInfoList(createPetInfos);
//			
//			// 如果玩家角色列表为空且帐号未激活，则激活帐号
//			gcRoleTemplate.setActivity(player.isActivity() ? 1 : 0);
//			
//			player.sendMessage(gcRoleTemplate);
//			Globals.getLoginLogicalProcessor().getRoleRandomName(player,1);
//		}
		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return player.getRoleUUID();
	}

}
