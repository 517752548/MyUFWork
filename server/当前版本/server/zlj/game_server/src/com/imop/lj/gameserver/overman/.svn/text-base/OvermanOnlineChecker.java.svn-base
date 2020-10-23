package com.imop.lj.gameserver.overman;

import java.util.List;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.overman.msg.GCOvermanInfo;

/**
 * 用于检测师徒在线情况
 *
 */
public class OvermanOnlineChecker implements HeartbeatTask {
	/** 检查的时间间隔，60秒 */
	private static final long CHECK_EXPIRED_SPAN = 60 * TimeUtils.SECOND;
	private boolean isCanceled;
	private Human owner;
	public OvermanOnlineChecker(Human owner) {
		this.owner = owner;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		long uuid = this.owner.getCharId();
		boolean isOverman = Globals.getOvermanService().isNormalOverman(uuid);
		boolean isLowerman = Globals.getOvermanService().isNormalLowerman(uuid);
		
		//没有师徒关系的直接返回
		if(!isOverman && !isLowerman){
			return;
		}
		if(isOverman){
			Overman o = Globals.getOvermanService().getOverman(uuid);
			if(o == null){
				return;
			}
			List<LowermanInfo> infos = o.getLowermans();
			 //从离线中取得师徒各自的信息
	        long overmancharid = o.getCharId();
	        UserSnap overmansnap = Globals.getOfflineDataService().getUserSnap(overmancharid);

	        //给在线的徒弟发送消息
	        LowermanInfo[] l = Globals.getOvermanService().buildLowermanArray(o, infos, overmansnap);
	        //构造师徒消息
	        GCOvermanInfo gc = new GCOvermanInfo(o.getCharId(), overmansnap.getName(), overmansnap.getHumanTplId(),
	        		Globals.getOvermanService().isOnline(o.getCharId()), l);
	         
	        for (LowermanInfo lowermanInfo : l) {
	        	//徒弟不在线,给师傅发消息
	        	if (!Globals.getOvermanService().isOnline(lowermanInfo.getUuid())) {
	        		 this.owner.sendMessage(gc);
	        		 break;
				}
			}
		}
		
		if(isLowerman){
			Overman o = Globals.getOvermanService().getOverman(uuid);
			if(o == null){
				return;
			}
			List<LowermanInfo> infos = o.getLowermans();
			 //从离线中取得师徒各自的信息
	        long overmancharid = o.getCharId();
	        UserSnap overmansnap = Globals.getOfflineDataService().getUserSnap(overmancharid);

	        //给在线的徒弟发送消息
	        LowermanInfo[] l = Globals.getOvermanService().buildLowermanArray(o, infos, overmansnap);
	        //构造师徒消息
	        GCOvermanInfo gc = new GCOvermanInfo(o.getCharId(), overmansnap.getName(), overmansnap.getHumanTplId(),
	        		Globals.getOvermanService().isOnline(o.getCharId()), l);
	        
			//师傅不在线,给徒弟发消息
        	if (!Globals.getOvermanService().isOnline(overmancharid)) {
        		 this.owner.sendMessage(gc);
			}
		}
		
			
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_EXPIRED_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}
}
