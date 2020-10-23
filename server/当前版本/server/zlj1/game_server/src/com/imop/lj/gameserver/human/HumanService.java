package com.imop.lj.gameserver.human;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.human.HumanInfo;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.human.async.QueryHumanInfoCallback;
import com.imop.lj.gameserver.player.Player;

public class HumanService {

	/**
	 * 查询玩家信息
	 * 当玩家在线时，从player中查；当玩家不在线时，从db中查
	 * 
	 * @param roleUUID
	 * @param callback
	 */
	public void doQueryHumanInfo(Long roleUUID, QueryHumanInfoCallback callback) {
		QueryHumanInfoOperation _task = new QueryHumanInfoOperation(roleUUID, callback);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_task);		
	}
	
	/**
	 * 玩家在线，通关player查询玩家信息
	 * @param roleUUID
	 * @return
	 */
	private HumanInfo getOnlineHumanInfo(long roleUUID) {
		HumanInfo info = null;
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player != null) {
			Human currentRole = player.getHuman();			
			if (currentRole != null)	{
				info = convertToHumanInfo(currentRole);
			}		
		}
		return info;
	}
	
	private HumanInfo convertToHumanInfo(Human human) {
		HumanInfo info = new HumanInfo();
		info.setRoleUUID(human.getUUID());
		info.setPassportId(human.getPassportId());
		info.setName(human.getName());
		info.setPhoto(human.getPhoto());
		info.setLevel(human.getLevel());
		return info;
	}
	
	/**
	 * 玩家不在线，通过db查询玩家信息
	 * @param roleUUID
	 * @return
	 */
	private HumanInfo getOfflineHumanInfo(long roleUUID) {
		HumanInfo info = null;
		HumanEntity humanEntity = Globals.getDaoService().getHumanDao().get(roleUUID);
		if (humanEntity != null) {
			info = new HumanInfo();
			info.setRoleUUID(humanEntity.getId());
			info.setPassportId(humanEntity.getPassportId());
			info.setName(humanEntity.getName());
			info.setPhoto(humanEntity.getPhoto());
			info.setLevel(humanEntity.getLevel());
		}
		return info;
	}
	
	/**
	 * 查询玩家信息的异步操作
	 * 当玩家在线时，从player中查；当玩家不在线时，从db中查
	 * 
	 * @author yu.zhao
	 *
	 */
	private static class QueryHumanInfoOperation implements BindUUIDIoOperation {

		private static final Logger logger = Loggers.asyncLogger;
		
		/**
		 * 被查询Human的 UUID
		 * 
		 */
		private long roleUUID;
		
		/**
		 * 信息取得后,回调
		 */
		private QueryHumanInfoCallback callback;
		
		/** 查询得到的HumanInfo */
		private HumanInfo humanInfo;
		
		public QueryHumanInfoOperation(long roleUUID, QueryHumanInfoCallback callback) {
			this.roleUUID = roleUUID;
			this.callback = callback;
		}
		
		@Override
		public int doStart() {
			humanInfo = Globals.getHumanService().getOnlineHumanInfo(roleUUID);
			if (humanInfo != null) {
				return STAGE_IO_DONE;
			}
			return STAGE_START_DONE;
		}
		
		@Override
		public int doIo() {
			try{			
				if(humanInfo == null) {
					humanInfo = Globals.getHumanService().getOfflineHumanInfo(roleUUID);
				}
			} catch(Exception e) {
				logger.error(String.format(
								"query other human roleId = [%s] info error",roleUUID), e);
			}
			return STAGE_IO_DONE;
		}
		

		@Override
		public int doStop() {
			if (humanInfo != null) {
				this.callback.afterQueryComplete(humanInfo);
			} else {
				Loggers.playerLogger.warn("#GC HumanService.QueryHumanInfoOperation.doStop humanInfo is null roleUUID="+roleUUID);
			}
			
			return STAGE_STOP_DONE;
		}

		@Override
		public long getBindUUID() {
			return this.roleUUID;
		}

	}
}
