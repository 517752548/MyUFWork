package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.GiveMoneyEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class GiveMoneyListener implements IEventListener<GiveMoneyEvent> {

	@Override
	public void fireEvent(GiveMoneyEvent event) {
		Human human = event.getInfo();
		Currency currency = event.getCurrency();
		long amount = event.getAmount();
		// TODO
		switch (currency) {
		case SKILL_POINT:
			//心法功能按钮变化
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
			//提升
			if (Globals.getHumanSkillService().canMindLevelUpgrade(human) || Globals.getHumanSkillService().canMindSkillUpgrade(human)){
				Globals.getPromoteService().noticePromoteInfo(human);
			}
			break;
			
		default:
			break;
		}
	}
}
