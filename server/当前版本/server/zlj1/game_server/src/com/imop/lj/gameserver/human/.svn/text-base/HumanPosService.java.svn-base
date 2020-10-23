package com.imop.lj.gameserver.human;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.gameserver.common.Globals;

/**
 * 玩家位置同步服务
 * @author yu.zhao
 *
 */
public class HumanPosService {
	
	/**
	 * 是否延迟发送位置信息，包括进出地图的判断也调用这里
	 * @return
	 */
	public boolean needDelayPos() {
		if (Globals.getOnlinePlayerService().getOnlinePlayerNumCache() >= SharedConstants.MapLocationNum2) {
			return true;
		}
		return false;
	}
	
	/**
	 * 根据服务器当前人数决定发送位置信息的策率
	 * @param human
	 */
	public void sendLocationInfo(Human human) {
		int count = human.getCurLocInfoListSize();
		//服务器人多时的策率
		if (needDelayPos()) {
			//取消人多的时候的条数策略，因为几乎都能走到，频率太高，只用时间的策略
			if (Globals.getTimeService().now() - human.getLastSendLocInfoTime() > SharedConstants.MapLocationTime2) {
				// 超过3秒发送
				human.sendLocationInfoAtOnce();
			}
		} else {
			//普通情况时的策率
			if (count >= SharedConstants.MapLocationCount) {
				// 超过10条消息发送
				human.sendLocationInfoAtOnce();
			} else if (Globals.getTimeService().now() - human.getLastSendLocInfoTime() > SharedConstants.MapLocationTime) {
				// 超过1秒发送
				human.sendLocationInfoAtOnce();
			}
		}
	}
	
}
