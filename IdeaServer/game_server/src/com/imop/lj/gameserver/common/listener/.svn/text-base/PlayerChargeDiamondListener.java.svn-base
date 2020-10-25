package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.human.Human;

public class PlayerChargeDiamondListener implements IEventListener<PlayerChargeDiamondEvent> {

	@Override
	public void fireEvent(PlayerChargeDiamondEvent event) {
		Human human = event.getInfo();
		int chargeDiamond = event.getChargeDiamond();
		boolean isGM = event.isGM();
		// 玩家最后一次充值时间、累计充值等数据更新
		human.onCharge(chargeDiamond);
		
		// 通知VIP
		Globals.getVipService().onPlayerChargeDiamond(human.getRoleUUID(), chargeDiamond, isGM);
		
//		// 首充
//		Globals.getFirstChargeService().onChargeDiamond(human);
		
		// 精彩活动
		Globals.getGoodActivityService().onPlayerDoSth(human, event);
//		
//		// 钱庄
//		Globals.getBankWeekService().onPlayerChargeBond(human, chargeDiamond);
//		
//		// 每日首充
//		Globals.getEverydayChargeGiftService().onCharge(human);
//		
//		// qq
//		Globals.getQQService().sendWSTotalCharge(human, chargeDiamond);
		
	}
}
