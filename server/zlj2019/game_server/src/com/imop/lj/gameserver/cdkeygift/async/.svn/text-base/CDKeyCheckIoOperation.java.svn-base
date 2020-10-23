package com.imop.lj.gameserver.cdkeygift.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.db.model.CDKeyPlansEntity;
import com.imop.lj.db.model.WorldGiftEntity;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.acrossserver.cdkeyworld.msg.WGCdkeyCheckResultMsg;
import com.imop.lj.gameserver.cdkeygift.CDKeyStateEnum;
import com.imop.lj.gameserver.cdkeygift.persistance.CDKeyPO;
import com.imop.lj.gameserver.cdkeygift.persistance.CDKeyPlansPO;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年7月8日 下午2:42:16
 * @version 1.0
 */

public class CDKeyCheckIoOperation implements LocalBindUUIDIoOperation {

	private ServerClient serverClient;
	private String cdkey = "";
	private long charId = 0;
	private String openId = "";
	private String charName = "";
	private String serverId = "";
	private String rewardJsonStr = "";
	
	public CDKeyCheckIoOperation(ServerClient serverClient, String cdkey, long charUUID, String serverId, String charName, String openId) {
		this.serverClient = serverClient;
		this.cdkey = cdkey;
		this.charId = charUUID;
		this.openId = openId;
		this.charName = charName;
		this.serverId = serverId;
	}
	// 默认已领取
	private CDKeyStateEnum checkResultEnum = CDKeyStateEnum.CDKEY_STATE_CAN_NOT_USE;
	private CDKeyStateEnum failReason = null;
	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		
		Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo#start! cdkey=" + cdkey 
				+ ", charId =" + charId + ", serverId="+ serverId
				+ ", openId=" + openId);
		// 多线程中执行
		CDKeyEntity entity = Globals.getDaoService().getCDKeyDao().getCDKey(cdkey);
		if(null != entity) {
			Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# entity not null!");
			CDKeyPO po = new CDKeyPO();
			po.fromEntity(entity);
			// 是否删除了
			if(po.getIsDel() == 1) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# entity is del!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_NULL;
				return STAGE_IO_DONE;
			}
			// 验证是否领取过
			if(po.getState() == 1) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# entity is taken!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_ALREADY_TAKEN;
				return STAGE_IO_DONE;
			}
			// 验证角色是否已经领取过根据  cdkeyPlanId 和  giftId
			boolean isTakeTheSameFlag = Globals.getDaoService().getCDKeyDao().isTakenTheSamePlansAndGift(charId, po.getPlansId(), po.getGiftId());
			if(isTakeTheSameFlag) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# role is taken!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_HAD_TAKEN_SAME_PLANSID_AND_GIFTID;
				return STAGE_IO_DONE;
			}
			// 验证是否过期
			CDKeyPlansEntity plansEntity = Globals.getDaoService().getCDKeyPlansDao()
					.getCDKeyPlans(entity.getPlansId());
			if(plansEntity == null) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# plansEntity is null!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_NO_PLANS;
				return STAGE_IO_DONE;
			}
			// 是否删除了
			if(plansEntity.getIsDel() == 1) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# plansEntity is del!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_NULL;
				return STAGE_IO_DONE;
			}
			
			CDKeyPlansPO plansPO = new CDKeyPlansPO();
			plansPO.fromEntity(plansEntity);
			
			long now = Globals.getTimeService().now();
			if(plansPO.getStartTime() > now || now > plansPO.getEndTime()) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# plansEntity time over!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_EFFECTIVE_TIME_OUT;
				return STAGE_IO_DONE;
			}
			// 可以领取了--取奖励json
			checkResultEnum = CDKeyStateEnum.CDKEY_STATE_CAN_USE;
			WorldGiftEntity giftEntity = Globals.getDaoService().getWorldGiftDao().getWorldGift(entity.getGiftId());
			// 是否删除了
			if(null == giftEntity) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# giftEntity is null!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_NULL;
				return STAGE_IO_DONE;
			}
			if(giftEntity.getIsDel() == 1) {
				Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# giftEntity is del!");
				failReason = CDKeyStateEnum.CDKEY_FAIL_REASON_NULL;
				return STAGE_IO_DONE;
			}
			
			if(null != giftEntity) {
				rewardJsonStr = giftEntity.getGiftParams();
				checkResultEnum = CDKeyStateEnum.CDKEY_STATE_CAN_USE;
			}
			
			Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo# check succ!");
			po.setOpenId(openId);
			po.setCharId(charId);
			po.setCharName(charName);
			po.setTakeTime(now);
			po.setState(1);
			po.setChartServerId(serverId);
			
			po.setModified();
			return STAGE_IO_DONE;
		}
		Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doIo#start! cdkey entity is null");
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		// 回到主线程中
		WGCdkeyCheckResultMsg msg = new WGCdkeyCheckResultMsg();
		msg.setCharUUId(charId);
		msg.setRewardStr(rewardJsonStr);
		msg.setCanUse(checkResultEnum.getIndex());
		if(null != failReason) {
			msg.setFailReason(failReason.getIndex());
		}
		Loggers.cdKeyWorldLogger.info("#CDKeyCheckIoOperation#doStop# return msg!"); 
		serverClient.sendMessage(msg);
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return 0;
	}

}
