package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.VipStateChangeEvent;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * VIP 状态改变监听
 * 
 * @author xiaowei.liu
 * 
 */
public class VipStateChangeListener implements IEventListener<VipStateChangeEvent> {

	@Override
	public void fireEvent(VipStateChangeEvent event) {
		
		// 行为管理器
		Player player = Globals.getOnlinePlayerService().getPlayer(event.getInfo().getRoleId());
		if(player != null){
			Human human = player.getHuman();
			if(human != null){
				human.getBehaviorManager().resetBehaviorMaxOpVip(false);
				human.getBindIdBehaviorManager().resetBehaviorMaxOpVip();
//				human.getCdManager().onVipChange();
				
				//功能开启
				Globals.getFuncService().onVipChanged(human);
				
				//精彩活动
				Globals.getGoodActivityService().onPlayerDoSth(human, event);
				
//				// VIP变化开启领地
//				Globals.getLandService().openOtherLand(human);
//				
//				// vip特权福利新手引导
//				if (Globals.getVipService().getVipLevel(human.getUUID()) > 0) {
//					Globals.getGuideService().onBecomeVIP(human);
//				}
				
				//通知附近玩家vip等级变化
				Globals.getMapService().noticeNearMapInfoChanged(human);
				
				//战斗加速数据可能变化
				Globals.getBattleService().noticeBattleSpeedup(human);
			}
		}
	}
}
