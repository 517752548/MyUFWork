package com.imop.lj.gameserver.offlinereward.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.offlinereward.OfflineReward;

public class SaveOfflineRewardOperation implements BindUUIDIoOperation {
	private OfflineReward offlineReward;
	private OfflineRewardEntity offlineRewardEntity;
	
	public SaveOfflineRewardOperation(OfflineReward offlineReward) {
		this.offlineReward = offlineReward;
	}
	
	@Override
	public int doStart() {
		try {
			this.offlineRewardEntity = offlineReward.toEntity();
		} catch (Exception e) {
			Loggers.offlineRewardLogger.error("#SaveOfflineRewardOperation#doStart#Error!offlineReward=" + offlineReward, e);
		}
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		try {
			if (this.offlineRewardEntity != null) {
				Globals.getDaoService().getOfflineRewardDao().save(this.offlineRewardEntity);
				this.offlineReward.setInDb(true);
			}
		} catch (Exception e) {
			Loggers.offlineRewardLogger.error("#SaveOfflineRewardOperation#doStart#Error!offlineReward=" + offlineReward, e);
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		// 这里为了让玩家能够即时收到这个奖励
		Globals.getOfflineRewardService().onlineSaveReward(offlineReward, true);
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		// 必须绑定到玩家Id上
		return offlineReward.getCharId();
	}

}
